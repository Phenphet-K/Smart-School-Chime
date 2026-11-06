# ผลตรวจ Smart School Chime — 5 พฤศจิกายน 2569

> เอกสารนี้เป็นผลตรวจก่อนแก้ไข ดูสถานะการแก้และการทดสอบล่าสุดใน [FIXES_AND_TESTS_TH.md](FIXES_AND_TESTS_TH.md) และชุด regression tests ใน `tests/`

## ขอบเขตและข้อสรุป

ตรวจ source Python ทั้ง 6 โมดูล, README, LICENSE, launcher, PyInstaller spec, installer, รายการเสียง และ dependency ใน Python ที่ใช้ตรวจ พร้อมค้นเอกสารทางการประกอบ ขณะเริ่มตรวจ git working tree สะอาด

ระบบมีพื้นฐานที่เหมาะกับโปรแกรมโรงเรียนขนาดเล็ก: SQLite, ทำงานออฟไลน์, แยกส่วนเสียงและฐานข้อมูล, มีคีย์ลัดและ NVDA แต่ยังมีข้อผิดพลาดที่กระทบความตรงเวลา ความคงอยู่ของข้อมูล และความปลอดภัยของช่องประกาศ จึงควรแก้ความถูกต้องก่อนเพิ่มความซับซ้อนหรือเปลี่ยน GUI ทั้งชุด

รายงานนี้เป็นการตรวจและเสนอแผน ยังไม่ได้แก้ source สำหรับใช้งานจริง ไม่ได้เปิดลำโพง สั่ง shutdown เปิด server หรือเขียนข้อมูลลงฐานข้อมูลใช้งานเดิม ไม่ได้ทดสอบ GUI/NVDA บนอุปกรณ์จริงหรือ installer ในเครื่องสะอาด และไม่ได้รับรองว่าไม่มีข้อผิดพลาดอื่น

## ผลที่ทดสอบซ้ำได้

ใช้ `python audit_checks.py` ซึ่งใช้ SQLite ชั่วคราวและจำลองการเล่นเสียง ผลที่ได้:

1. Python ทั้ง 6 โมดูล parse ผ่าน ไม่ใช่การยืนยันว่า runtime ถูกต้องทั้งหมด
2. `database.reset_to_default_schedule(2)` ล้มเหลวด้วย `OperationalError: 11 values for 10 columns` เมื่อถึง slot 15 หลัง error connection ที่ไม่ปิดอาจค้าง transaction; การทดสอบครั้งแรกพบ `database is locked` ต่อเนื่องด้วย เมธอดนี้ยังไม่ได้ถูกเรียกจากปุ่มรีเซ็ตปัจจุบัน ซึ่งเรียกรีเซ็ตทั้งหมด
3. ส่งข้อมูลรูปแบบเดียวกับ GUI ไปบันทึก ทำให้ label ของคาบจากมีข้อความกลายเป็นสตริงว่าง
4. ปิดเสียงทุกคาบแล้วเรียก `init_db()` อีกครั้ง กลับมีคาบเปิดเสียง 84 รายการ เพราะระบบถือว่าตารางที่ไม่มีเสียงคือข้อมูลเริ่มต้นที่ยังไม่สร้าง
5. `save_all_day_slots()` ยอมบันทึกเวลา `99:99`
6. จำลองให้ worker เสียงเก่ายังทำงานแล้วเริ่ม sequence ใหม่ พบว่า sequence เก่ากลับไปเล่นไฟล์ถัดไปได้ เพราะใช้ stop Event ร่วมกันและ clear ก่อน worker เก่าจบ
7. ไฟล์ประกาศที่ DEFAULT_PERIODS อ้างถึงมีครบ และพบไฟล์ใน Sound รวม 198 ไฟล์ ยังไม่ได้ตรวจการ decode คุณภาพเสียง ระดับเสียง หรือความหมายของทุกไฟล์

## ปัญหาที่ควรจัดการตามลำดับ

P1 = ควรแก้ก่อนใช้งานจริงหรือแจกเวอร์ชันถัดไป; P2 = แก้เพื่อความน่าเชื่อถือและการบำรุงรักษา; P3 = ปรับปรุงเอกสาร/ประสบการณ์

| ระดับ | จุดอ้างอิง | หลักฐาน / ผลกระทบ | แนวแก้ |
|---|---|---|---|
| P1 | main.py:1392–1413 | scheduler ทำงานเฉพาะ `now.second == 0`; ถ้าเครื่องหน่วงหรือ sleep ข้ามจาก :59 ไป :01 จะข้ามคาบนั้น ทั้ง loop ไม่มีตัวดัก exception ครอบการ trigger จึงเสี่ยง thread ตายเงียบ | เทียบช่วงเวลาที่ผ่านไป ใช้ occurrence ID กันซ้ำ กำหนด grace window และบันทึก missed event ห้ามเล่นย้อนหลังทั้งหมดหลังตื่นเครื่อง |
| P1 | database.py:112 | ถ้าผู้ใช้ตั้งใจปิดเสียงทุกคาบ การเปิดใหม่จะคืนค่า default พร้อมเปิดเสียงอีกครั้ง ทดสอบยืนยันแล้ว | seed เฉพาะฐานข้อมูลใหม่/ตารางไม่มีข้อมูล ใช้ schema version แยกจากสถานะเปิดเสียง |
| P1 | database.py:198 | รีเซ็ตวันเดียวมี SQL จำนวนค่าไม่ตรงและ connection ไม่ปิดเมื่อ exception ทดสอบยืนยันแล้ว | แก้ column list ให้ตรง ใช้ transaction และ try/finally ปิด connection ทุกเส้นทาง |
| P1 | broadcast_server.py:781 | POST `/api/broadcast` ไม่มี authentication, ขีดจำกัดขนาด, timeout หรือการตรวจ WAV; เปิดทุก network interface และ CORS `*` | pairing token อายุสั้น, session/สิทธิ์ประกาศ, ตรวจ Origin, ปิด HTTP upload, จำกัด body/ระยะเวลา/คำขอพร้อมกัน, validate PCM WAV ก่อนรับงาน |
| P1 | broadcast_server.py:25, 798 | ทุกคำขอเขียน `live_broadcast_temp.wav` เดียวกัน ขณะที่ callback เล่นแบบ background | ใช้ไฟล์ชั่วคราวเฉพาะงานและลบหลังจบ หรือ buffer ในคิวที่มีเจ้าของชัดเจน ปฏิเสธ/จัดคิวผู้ประกาศซ้อน |
| P1 | audio_player.py:111; main.py:881 | เสียงตารางกับประกาศใช้เส้นทางควบคุมต่างกัน; worker เก่าอาจกลับมาทำงานหลัง clear Event และ `_is_playing` อาจผิด | AudioService เดียว มี worker/queue เดียว generation ID หรือ cancellation token เฉพาะงาน และนโยบาย priority |
| P1 | main.py:887–905, 1292 | Esc หยุดเสียงปัจจุบันได้ แต่ broadcast worker ที่ยังรอ 0.1/1.2 วินาทีสามารถเริ่มเสียงใหม่หลังหยุดได้; รอกริ่งคงที่ 1.2 วินาทีไม่สัมพันธ์ความยาวไฟล์ | cancel ครอบทุกงานและงานที่รออยู่ ต่อเสียงตาม completion จริง |
| P1 | database.py:13; config_manager.py:13; SmartSchoolChime.spec | DB/config อ้าง `__file__`; ใน onefile อยู่โฟลเดอร์แตกชั่วคราว ขณะที่ spec คัดลอก data/config ข้าง exe แต่ไม่มีตัวเลือกเส้นทางไปใช้ ค่าที่เขียนจึงเสี่ยงไม่คงอยู่; ถ้าย้ายไปเขียน Program Files ตรงๆ จะติดสิทธิ์ผู้ใช้ปกติ | แยก bundled assets / persistent user data / temporary data; ย้าย DB/config ไป LocalAppData หรือ ProgramData ที่จัด ACL ถูกต้อง พร้อม migration |
| P1 | audio_player.py:22–38; build_exe.bat | Sound ไม่ได้ bundle ในคำสั่ง build; การค้นหาเสียงอาศัย cwd หรือ C:\\Sound จึงขึ้นกับวิธีเปิดและ shortcut | กำหนด asset root ชัดเจน ใช้ build spec จุดเดียว ทดสอบเปิดจาก Start Menu และ cwd อื่น |
| P2 | main.py:1204; database.py:291 | GUI ไม่ส่ง label แต่ DB เขียน label ว่างทับทุกครั้ง ยืนยันแล้ว | เก็บ label ใน model/UI หรืออัปเดตเฉพาะ field ที่ส่ง |
| P2 | database.py:291,354; config_manager.py:49 | ไม่มี validation ขอบเขตเวลา วัน slot enum และโครงสร้าง import; ค่า config ผิด เช่น auto_shutdown ไม่ใช่เลข ทำให้เปิดแอปไม่สำเร็จได้ | schema เดียวสำหรับ GUI/DB/import/config; ปฏิเสธข้อมูลผิดพร้อมข้อความภาษาไทยก่อนเริ่ม transaction |
| P2 | config_manager.py:49; database.py:set_setting | เขียน JSON ทับตรงๆ และกลืน error; settings ซ้ำใน JSON/SQLite แต่ไม่เป็น transaction เดียว จึงอาจแสดงบันทึกสำเร็จทั้งที่บางส่วนไม่สำเร็จ | กำหนดแหล่งข้อมูลหลักเดียว; ถ้าใช้ JSON ให้ temporary file + replace และส่ง error กลับ UI |
| P2 | main.py:1392,1419,1271 | background thread อ่าน Tk variables และ callback บางส่วนแก้ widget โดยตรง; การ marshal ของ Tk ขึ้นกับ event loop และอาจมีปัญหาตอนปิดแอป | snapshot settings บน UI thread; ใช้ queue + main-thread after polling; ยกเลิก callback และ join worker อย่างมีขอบเขต [S2] |
| P2 | broadcast_server.py:837,872 | is_running ถูกตั้ง true แม้ bind ไม่สำเร็จทั้งสองพอร์ต; URL ไม่สะท้อน HTTPS ที่ล้มเหลว; stop ไม่เรียก server_close | สถานะแยกราย listener แจ้ง error จริง ปิด socket/worker ให้ครบ และทดสอบ start-stop-start/port conflict |
| P2 | broadcast_server.py:39 | cert ไม่มี Subject Alternative Name ของ host/IP, ไม่มีตรวจหมดอายุ และเป็น self-signed; ไม่ใช่ HTTPS ที่มือถือเชื่อถือพร้อมใช้งานอัตโนมัติ | วางแผนชื่อ host/cert ที่มือถือเชื่อถือ การเปลี่ยน IP และ renewal; ทดสอบ iOS/Android จริง การเข้าผ่าน HTTP IP ไม่ให้ใช้ไมค์ตามปกติ [S3] |
| P2 | broadcast_server.py:stopRecording ใน HTML | ส่งไฟล์เมื่อปล่อยปุ่มเท่านั้น แต่ข้อความบอกกำลังส่งเสียงสด; HTTP 200 แค่รับงาน ไม่ได้ยืนยันว่าเล่นสำเร็จ | ระบุว่าอัดแล้วส่ง หรือทำ WebRTC จริง; แสดง accepted/queued/playing/completed/failed จากสถานะงาน |
| P2 | main.py:1457 | ใช้ break หลังพบคาบแรก เวลาเดียวกันหลายคาบจึงเล่นเฉพาะรายการแรก | ตรวจซ้ำก่อนบันทึกหรือกำหนดวิธี merge/queue ที่ผู้ใช้เข้าใจ |
| P2 | main.py:1424 | auto shutdown มี priority เหนือคาบเวลาเดียวกันและไม่มีปุ่มยกเลิก countdown ในแอป | นโยบายไม่ปิดกลางประกาศ, เตือนล่วงหน้า, ปุ่มยกเลิกที่เรียก shutdown /a และตรวจผลคำสั่ง |
| P2 | database.py:344,354 | export มีเฉพาะ schedules; import เป็นการ merge/replace ทีละ key ไม่ใช่แทนทั้งตารางตามที่ผู้ใช้อาจเข้าใจ ไม่มี version/preview/backup ก่อนทับ | backup แบบ versioned ครอบ settings+schedule+asset manifest; preview, validate, restore แบบ transaction และ rollback |
| P2 | broadcast_server.py:481 | createScriptProcessor เป็น API deprecated; delay 100ms ปัจจุบันคือไม่เก็บช่วงต้น ไม่ใช่ pre-roll เก็บเสียงก่อนกด จึงอาจตัดพยางค์แรก [S4] | ใช้ AudioWorklet; ถ้าต้องการ pre-roll จริงต้องมี ring buffer และระบุการใช้ไมค์ให้ชัดเจน |
| P2 | ทั้งโปรเจกต์ | ไม่มี dependency manifest/lock, test suite หรือ CI ใน source ที่ตรวจ; logs ใช้ print และ logger โดยไม่ตั้ง file handler | เพิ่ม pyproject/lock, tests ที่แก้ clock/audio ได้, logging แบบหมุนไฟล์ และ CI Windows |
| P3 | main.py:1465 | รายการถัดไปดูเฉพาะวันนี้ อัปเดตตอน trigger ราย minute; หลังแก้ตารางอาจไม่สะท้อนทันที | คำนวณใหม่เมื่อ save/mode/import และข้ามวัน/วันหยุดได้ |
| P3 | README / LICENSE | README ระบุ MIT แต่ LICENSE เป็น Apache-2.0; คำอ้าง NVDA 100% ยังไม่มีหลักฐานทดสอบจริง | ทำข้อความให้ตรงใบอนุญาตที่เจ้าของเลือก และระบุ accessibility ตามผลทดสอบ พร้อมตรวจที่มา DLL/เสียงแยกต่างหาก |

เลขบรรทัดอ้าง source ณ วันที่ตรวจ รายการที่ไม่ได้ระบุว่าทดสอบยืนยันเป็นผลวิเคราะห์โค้ดและสถานการณ์เสี่ยง ไม่ใช่ผลทดสอบอุปกรณ์จริง

## ไลบรารีและโครงการที่เหมาะนำมาต่อยอด

| ส่วนงาน | ข้อเสนอ | เหตุผล / ข้อจำกัด |
|---|---|---|
| GUI | รักษา Tkinter ระหว่างแก้ core | การเปลี่ยน framework ไม่แก้ race/scheduler/data loss; ประเมิน wxPython หรือ PySide6 ภายหลังด้วย prototype และ NVDA จริงก่อนตัดสินใจ ไม่รับรอง accessibility จากชื่อ framework |
| Scheduler | core ที่ทดสอบ clock ได้ หรือ APScheduler | APScheduler มี misfire_grace_time และ coalescing [S5]; เลือกรุ่น stable ตรวจ API ของรุ่นที่ล็อก ห้ามผสมตัวอย่าง 3.x กับ master; ยังคงต้องมี event ledger และนโยบายวันหยุด |
| Audio | sounddevice + ตัวอ่านเสียงที่เหมาะกับ format เช่น soundfile เมื่อจำเป็น | sounddevice มี OutputStream/RawOutputStream และเลือกอุปกรณ์ได้ [S6]; ต้องทดสอบ PortAudio/Windows device และการแพ็ก ไม่จำเป็นต้องเปลี่ยนทันทีถ้ายังใช้ WAV ง่ายๆ |
| Broadcast API | FastAPI พร้อม ASGI server หรือ aiohttp เมื่อเพิ่ม streaming | แยก HTTP ออกจาก Tk และทำ validation/lifecycle ชัดเจน [S7]; framework ไม่ได้เพิ่ม auth/rate limit/ความปลอดภัยให้อัตโนมัติ Python ระบุว่า http.server ไม่แนะนำสำหรับ production [S8] |
| ถ่ายทอดสดจริง | aiortc และ browser WebRTC | โครงการ Python สำหรับ WebRTC [S9]; ต้องออกแบบ signaling, auth, Opus/audio conversion, jitter buffer และ playback เอง ดู examples ทางการก่อนนำมาใช้ |
| Browser audio | AudioWorklet | ทดแทน ScriptProcessorNode ที่ deprecated [S4]; การเปลี่ยน capture เพียงอย่างเดียวไม่ได้ทำให้ upload ทั้งไฟล์กลายเป็น live |
| Validation | Pydantic หรือ dataclasses + validators | schema ชัดเจน ใช้ร่วมกับ import/config/API [S10]; สำหรับข้อมูลขนาดเล็ก validator ปกติก็เพียงพอ ไม่จำเป็นต้องเพิ่มทุก lib |
| Data paths | platformdirs | มี user data/config/log directory ตาม platform [S11]; ถ้าโรงเรียนต้องแชร์หลายบัญชี Windows ต้องเลือก shared directory พร้อมสิทธิ์และ migration |
| Quality/security | pytest, Ruff, pip-audit | แยก dev dependencies; pip-audit ตรวจ known vulnerabilities จาก dependency จริง [S12] ไม่ใช่ใบรับรองความปลอดภัยทั้งหมด |
| Accessibility | NV Access controller client ทางการ | ใช้เป็น reference สำหรับ DLL/API [S13], ระบุ ctypes signatures และใช้ DLL จากแหล่งเชื่อถือได้; speech API ไม่เท่ากับ accessible names/roles/state ของ widget |

สภาพแวดล้อมที่ตรวจ: Python 3.11.9, Pillow 12.3.0, qrcode 8.2, cryptography 50.0.1, PyInstaller 6.21.0, pytest 9.0.3; ไม่พบ Ruff/pip-audit ใน environment นี้ รายการนี้เป็นรุ่นที่ติดตั้งอยู่ ไม่ใช่รายการแนะนำให้อัปเกรดตามทันที ยังไม่ได้ทำ CVE audit จริงหรือยืนยัน compatibility ของทุกเวอร์ชัน ควรสร้าง virtualenv สะอาด ล็อกชุดที่ผ่านทดสอบ แล้วค่อยอัปเกรดทีละกลุ่ม

## โครงสร้างที่เสนอ

```text
Tk GUI -> Application services -> Schedule engine -> Event ledger (SQLite)
                         |                 |
HTTP/WebRTC -> Auth -> Announcement queue -> Audio service -> Output device
                         |
               Validation / Settings / Audit log / Backup
```

ให้เสียงทุกประเภทผ่าน AudioService เดียว: เหตุฉุกเฉิน > ประกาศที่ได้รับสิทธิ์ > ตาราง > ทดสอบ โดยกำหนดให้ชัดว่ารายการที่ถูกแทรกจะหยุด ยกเลิก หรือกลับมาเล่นต่อ งานทุกงานมี ID, cancellation และสถานะ แยก resource ที่อ่านอย่างเดียวออกจากข้อมูลถาวร และแยก scheduler จาก Tk เพื่อทดสอบเวลาโดยไม่เปิดหน้าต่าง

## ฟังก์ชันที่ควรเพิ่ม

1. ปฏิทินวันหยุด/ปิดเทอม/ตารางสอบและข้อยกเว้นรายวันที่มีลำดับความสำคัญชัดเจน; วันหยุดราชการไม่ควรเท่ากับวันหยุดของทุกโรงเรียนโดยอัตโนมัติ
2. ตารางล่วงหน้า 7 วัน, ปุ่มพักกริ่งชั่วคราวพร้อมวันสิ้นสุด, เตือนเวลาซ้ำ และตรวจไฟล์เสียงก่อนอนุญาตบันทึก
3. เลือกลำโพง ทดสอบสัญญาณ แสดงอุปกรณ์หาย/เปลี่ยน และกำหนดระดับเสียงที่ไม่ clipping; ทดสอบสัญญาณจริงต้องให้เจ้าหน้าที่ควบคุม
4. หน้าสุขภาพระบบ: scheduler ยังทำงานไหม, คาบล่าสุดสำเร็จไหม, missed event, audio device, DB/config writable, certificate และ listener ที่เปิดได้จริง
5. pairing มือถือแบบ token อายุสั้น การเพิกถอนสิทธิ์ คิวประกาศ ผู้ควบคุมหนึ่งคนต่อครั้ง และประวัติผู้สั่งงาน
6. backup อัตโนมัติพร้อม retention, restore preview, schema version และทดสอบกู้คืน; ไม่เก็บเสียงประกาศระยะยาวโดยไม่มีความต้องการ
7. บันทึกการเปลี่ยนตารางและผลเล่นเสียง พร้อม export diagnostic ที่ตัด token/ข้อมูลลับออก
8. ป้องกันเปิดโปรแกรมซ้ำ, autostart แบบเลือกได้, เตือนก่อนปิดขณะงานกำลังเล่น และปุ่มยกเลิก shutdown
9. ปรับขนาดตัวอักษร/High Contrast/keyboard focus ชัดเจน และทดสอบ NVDA ทุกฟังก์ชัน; หน้าเว็บอนุญาต zoom ปัจจุบันปิดด้วย user-scalable=no
10. จัดการชุดเสียงและนำเข้าเสียงพร้อมตรวจ format/duration/ระดับเสียง; TTS เป็นทางเลือกหลัง core เสถียร โดยคำนึงถึงออฟไลน์และเสียงอ่านภาษาไทย

## แผนพัฒนาและเกณฑ์ผ่าน

**ระยะ 1: ป้องกันคาบหายและข้อมูลหาย** — แก้ scheduler, seed/reset, label, validation, persistent paths, atomic settings และ single audio owner ก่อนเพิ่มฟีเจอร์

**ระยะ 2: ช่องประกาศที่เชื่อถือได้** — auth/pairing, request limits, WAV validation, per-job buffer, queue/cancel, สถานะ listener/certificate และแยกคำว่าอัดแล้วส่งกับสด

**ระยะ 3: การดูแลและประสบการณ์** — calendar exception, backup/restore, diagnostics, device selection, accessibility และ CI/build จาก environment สะอาด จากนั้นจึงทำ WebRTC ถ้าต้องการ live จริง

เกณฑ์ทดสอบที่เสนอ (เป็นเป้าหมาย ยังไม่มีผล measurement):

- จำลองเวลาข้าม :00, โปรแกรมเริ่มกลางนาที, sleep/resume, นาฬิกาปรับย้อน/เดินหน้า, เปลี่ยนวัน และหลายรายการเวลาเดียวกัน ต้องได้ผลตามนโยบายและไม่เล่นซ้ำ
- เปิดใหม่หลังปิดทุกคาบต้องคงปิด; reset รายวันไม่แตะวันอื่น; save/load ต้องรักษา label; import ผิดต้องไม่เปลี่ยนข้อมูล; error ต้องไม่ทิ้ง DB lock
- ส่งเสียงสองมือถือพร้อมกันไม่ทับ buffer; Esc ต้องยกเลิกทั้งเสียงและงานรอ; เสียงกริ่งและประกาศไม่แย่งลำโพงโดยไร้นโยบาย
- ทดสอบ request ไม่มีสิทธิ์, payload เกินกำหนด, WAV เสีย, slow request และพอร์ตชนแบบ local controlled environment โดยไม่กระทบเครือข่ายโรงเรียน
- ติดตั้งใหม่/อัปเกรดใน Windows บัญชีผู้ใช้ปกติ เปิดจาก shortcut และ cwd อื่น รวม path ภาษาไทย ต้องโหลดเสียงและรักษาข้อมูลเดิมได้
- ทดสอบ iOS Safari / Android Chrome กับ certificate ที่เชื่อถือได้, Wi-Fi หลุด, ปิดหน้าจอ และไมค์ถูกปฏิเสธ
- ทดสอบเปิดทิ้ง 24–72 ชั่วโมง พร้อมวัด memory/thread/file handles, latency ของกริ่ง และจำนวน missed/duplicate events; กำหนดเกณฑ์ latency หลังมี baseline บนเครื่องเป้าหมาย
- ตรวจ NVDA จริง การอ่านชื่อ/ชนิด/สถานะของ control, ลำดับ Tab, menu, focus หลัง dialog และ DPI 100–200%; ยังไม่ควรใช้คำว่าเข้าถึงได้ 100%

## แหล่งข้อมูลทางการที่ค้นประกอบ

- [S1 PyInstaller runtime paths](https://www.pyinstaller.org/en/stable/runtime-information.html) — ความแตกต่างของ bundled __file__ กับ sys.executable
- [S2 Tkinter threading model](https://docs.python.org/3/library/tkinter.html#threading-model)
- [S3 getUserMedia และ secure context](https://developer.mozilla.org/en-US/docs/Web/API/MediaDevices/getUserMedia)
- [S4 ScriptProcessorNode audioprocess deprecation](https://developer.mozilla.org/en-US/docs/Web/API/ScriptProcessorNode/audioprocess_event)
- [S5 APScheduler 3.x user guide](https://apscheduler.readthedocs.io/en/3.x/userguide.html)
- [S6 sounddevice streams](https://python-sounddevice.readthedocs.io/en/0.5.3/api/streams.html)
- [S7 FastAPI](https://fastapi.tiangolo.com/)
- [S8 Python http.server](https://docs.python.org/3/library/http.server.html)
- [S9 aiortc](https://aiortc.readthedocs.io/)
- [S10 Pydantic](https://docs.pydantic.dev/latest/)
- [S11 platformdirs](https://platformdirs.readthedocs.io/en/stable/api.html)
- [S12 pip-audit](https://github.com/pypa/pip-audit)
- [S13 NVDA controller client](https://github.com/nvaccess/nvda/tree/master/extras/controllerClient)
- [S14 winsound](https://docs.python.org/3/library/winsound.html) — PlaySound(None, ...) หยุด waveform ปัจจุบัน; SND_PURGE ไม่รองรับบน Windows รุ่นใหม่ จึงไม่ควรพึ่ง flag นี้

Git remote ชี้ https://github.com/Phenphet-K/Smart-School-Chime แต่การเปิดหน้า repo ผ่าน web tool ครั้งนี้ไม่สำเร็จ จึงไม่ได้อ้างว่าได้ตรวจ issues/releases/CI ฝั่ง remote; ข้อสรุปโค้ดอ้างจาก workspace นี้
