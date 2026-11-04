Namespace SchoolTellingTime
	' Token: 0x0200000A RID: 10
	<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
	Public Partial Class Form1
		Inherits Global.System.Windows.Forms.Form

		' Token: 0x06000031 RID: 49 RVA: 0x00002DF4 File Offset: 0x000011F4
		<Global.System.Diagnostics.DebuggerNonUserCode()>
		Protected Overrides Sub Dispose(disposing As Boolean)
			Try
				Dim flag As Boolean = disposing AndAlso Me.components IsNot Nothing
				If flag Then
					Me.components.Dispose()
				End If
			Finally
				MyBase.Dispose(disposing)
			End Try
		End Sub

		' Token: 0x06000032 RID: 50 RVA: 0x00002E44 File Offset: 0x00001244
		<Global.System.Diagnostics.DebuggerStepThrough()>
		Private Sub InitializeComponent()
			Me.components = New Global.System.ComponentModel.Container()
			Dim resources As Global.System.ComponentModel.ComponentResourceManager = New Global.System.ComponentModel.ComponentResourceManager(GetType(Global.SchoolTellingTime.Form1))
			Me.Timer1 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.lblTimeShow = New Global.System.Windows.Forms.Label()
			Me.OpenFileDialog1 = New Global.System.Windows.Forms.OpenFileDialog()
			Me.Timer2 = New Global.System.Windows.Forms.Timer(Me.components)
			Me.lblPath = New Global.System.Windows.Forms.Label()
			Me.lblTopic2 = New Global.System.Windows.Forms.Label()
			Me.lblP = New Global.System.Windows.Forms.Label()
			Me.btnReset = New Global.System.Windows.Forms.Button()
			Me.lblCopyright = New Global.System.Windows.Forms.Label()
			Me.lblTopic1 = New Global.System.Windows.Forms.Label()
			Me.lblRemark = New Global.System.Windows.Forms.Label()
			Me.btnCancel = New Global.System.Windows.Forms.Button()
			Me.btnExit = New Global.System.Windows.Forms.Button()
			Me.btnEdit = New Global.System.Windows.Forms.Button()
			Me.btnSave = New Global.System.Windows.Forms.Button()
			Me.lblEdit = New Global.System.Windows.Forms.Label()
			Me.lblSave = New Global.System.Windows.Forms.Label()
			Me.lblCancel = New Global.System.Windows.Forms.Label()
			Me.lblReset = New Global.System.Windows.Forms.Label()
			Me.im05 = New Global.System.Windows.Forms.Label()
			Me.PictureBox1 = New Global.System.Windows.Forms.PictureBox()
			Me.listLangDisplay = New Global.System.Windows.Forms.ListBox()
			Me.lblLanguage = New Global.System.Windows.Forms.Label()
			Me.lblCanUse = New Global.System.Windows.Forms.Label()
			Me.lblCD = New Global.System.Windows.Forms.Label()
			Me.lblPayment = New Global.System.Windows.Forms.Label()
			Me.btnPayment = New Global.System.Windows.Forms.Button()
			Me.lblDev = New Global.System.Windows.Forms.Label()
			Me.lblWarning = New Global.System.Windows.Forms.Label()
			Me.PanelEachDay = New Global.System.Windows.Forms.Panel()
			Me.radioFri = New Global.System.Windows.Forms.RadioButton()
			Me.radioThu = New Global.System.Windows.Forms.RadioButton()
			Me.radioWed = New Global.System.Windows.Forms.RadioButton()
			Me.radioTue = New Global.System.Windows.Forms.RadioButton()
			Me.radioSat = New Global.System.Windows.Forms.RadioButton()
			Me.radioSun = New Global.System.Windows.Forms.RadioButton()
			Me.radioMon = New Global.System.Windows.Forms.RadioButton()
			Me.lblToday = New Global.System.Windows.Forms.Label()
			Me.radioAllDay = New Global.System.Windows.Forms.RadioButton()
			Me.panelAllDay = New Global.System.Windows.Forms.Panel()
			Me.radioEachDay = New Global.System.Windows.Forms.RadioButton()
			Me.PanelTime = New Global.System.Windows.Forms.Panel()
			Me.lbl22 = New Global.System.Windows.Forms.Label()
			Me.lbl23 = New Global.System.Windows.Forms.Label()
			Me.lbl24 = New Global.System.Windows.Forms.Label()
			Me.lbl17 = New Global.System.Windows.Forms.Label()
			Me.lbl18 = New Global.System.Windows.Forms.Label()
			Me.lbl19 = New Global.System.Windows.Forms.Label()
			Me.lbl20 = New Global.System.Windows.Forms.Label()
			Me.lbl21 = New Global.System.Windows.Forms.Label()
			Me.chkFirst24 = New Global.System.Windows.Forms.CheckBox()
			Me.chkLast24 = New Global.System.Windows.Forms.CheckBox()
			Me.chkTime24 = New Global.System.Windows.Forms.CheckBox()
			Me.comboSoundConEng24 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundCon24 = New Global.System.Windows.Forms.ComboBox()
			Me.chkCon24 = New Global.System.Windows.Forms.CheckBox()
			Me.btnPlay24 = New Global.System.Windows.Forms.Button()
			Me.comboMin24 = New Global.System.Windows.Forms.ComboBox()
			Me.comboHour24 = New Global.System.Windows.Forms.ComboBox()
			Me.chkFirst23 = New Global.System.Windows.Forms.CheckBox()
			Me.chkFirst22 = New Global.System.Windows.Forms.CheckBox()
			Me.chkFirst21 = New Global.System.Windows.Forms.CheckBox()
			Me.chkLast23 = New Global.System.Windows.Forms.CheckBox()
			Me.chkLast22 = New Global.System.Windows.Forms.CheckBox()
			Me.chkLast21 = New Global.System.Windows.Forms.CheckBox()
			Me.chkTime23 = New Global.System.Windows.Forms.CheckBox()
			Me.chkTime22 = New Global.System.Windows.Forms.CheckBox()
			Me.chkTime21 = New Global.System.Windows.Forms.CheckBox()
			Me.comboSoundConEng23 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundConEng22 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundConEng21 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundCon23 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundCon22 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundCon21 = New Global.System.Windows.Forms.ComboBox()
			Me.chkCon23 = New Global.System.Windows.Forms.CheckBox()
			Me.btnPlay23 = New Global.System.Windows.Forms.Button()
			Me.comboMin23 = New Global.System.Windows.Forms.ComboBox()
			Me.comboHour23 = New Global.System.Windows.Forms.ComboBox()
			Me.chkCon22 = New Global.System.Windows.Forms.CheckBox()
			Me.btnPlay22 = New Global.System.Windows.Forms.Button()
			Me.comboMin22 = New Global.System.Windows.Forms.ComboBox()
			Me.comboHour22 = New Global.System.Windows.Forms.ComboBox()
			Me.chkCon21 = New Global.System.Windows.Forms.CheckBox()
			Me.btnPlay21 = New Global.System.Windows.Forms.Button()
			Me.comboMin21 = New Global.System.Windows.Forms.ComboBox()
			Me.comboHour21 = New Global.System.Windows.Forms.ComboBox()
			Me.chkFirst20 = New Global.System.Windows.Forms.CheckBox()
			Me.chkFirst19 = New Global.System.Windows.Forms.CheckBox()
			Me.chkFirst18 = New Global.System.Windows.Forms.CheckBox()
			Me.chkFirst17 = New Global.System.Windows.Forms.CheckBox()
			Me.chkLast20 = New Global.System.Windows.Forms.CheckBox()
			Me.chkLast19 = New Global.System.Windows.Forms.CheckBox()
			Me.chkLast18 = New Global.System.Windows.Forms.CheckBox()
			Me.chkLast17 = New Global.System.Windows.Forms.CheckBox()
			Me.chkTime20 = New Global.System.Windows.Forms.CheckBox()
			Me.chkTime19 = New Global.System.Windows.Forms.CheckBox()
			Me.chkTime18 = New Global.System.Windows.Forms.CheckBox()
			Me.chkTime17 = New Global.System.Windows.Forms.CheckBox()
			Me.comboSoundConEng20 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundConEng19 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundConEng18 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundConEng17 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundCon20 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundCon19 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundCon18 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundCon17 = New Global.System.Windows.Forms.ComboBox()
			Me.chkCon20 = New Global.System.Windows.Forms.CheckBox()
			Me.btnPlay20 = New Global.System.Windows.Forms.Button()
			Me.comboMin20 = New Global.System.Windows.Forms.ComboBox()
			Me.comboHour20 = New Global.System.Windows.Forms.ComboBox()
			Me.chkCon19 = New Global.System.Windows.Forms.CheckBox()
			Me.btnPlay19 = New Global.System.Windows.Forms.Button()
			Me.comboMin19 = New Global.System.Windows.Forms.ComboBox()
			Me.comboHour19 = New Global.System.Windows.Forms.ComboBox()
			Me.chkCon18 = New Global.System.Windows.Forms.CheckBox()
			Me.btnPlay18 = New Global.System.Windows.Forms.Button()
			Me.comboMin18 = New Global.System.Windows.Forms.ComboBox()
			Me.comboHour18 = New Global.System.Windows.Forms.ComboBox()
			Me.chkCon17 = New Global.System.Windows.Forms.CheckBox()
			Me.btnPlay17 = New Global.System.Windows.Forms.Button()
			Me.comboMin17 = New Global.System.Windows.Forms.ComboBox()
			Me.comboHour17 = New Global.System.Windows.Forms.ComboBox()
			Me.lblEng = New Global.System.Windows.Forms.Label()
			Me.lblThai = New Global.System.Windows.Forms.Label()
			Me.PictureBox3 = New Global.System.Windows.Forms.PictureBox()
			Me.PictureBox2 = New Global.System.Windows.Forms.PictureBox()
			Me.lbl14 = New Global.System.Windows.Forms.Label()
			Me.lbl15 = New Global.System.Windows.Forms.Label()
			Me.lbl16 = New Global.System.Windows.Forms.Label()
			Me.lbl09 = New Global.System.Windows.Forms.Label()
			Me.lbl10 = New Global.System.Windows.Forms.Label()
			Me.lbl11 = New Global.System.Windows.Forms.Label()
			Me.lbl12 = New Global.System.Windows.Forms.Label()
			Me.lbl13 = New Global.System.Windows.Forms.Label()
			Me.lbl06 = New Global.System.Windows.Forms.Label()
			Me.lbl07 = New Global.System.Windows.Forms.Label()
			Me.lbl08 = New Global.System.Windows.Forms.Label()
			Me.lbl05 = New Global.System.Windows.Forms.Label()
			Me.lbl04 = New Global.System.Windows.Forms.Label()
			Me.lbl03 = New Global.System.Windows.Forms.Label()
			Me.lbl02 = New Global.System.Windows.Forms.Label()
			Me.lbl01 = New Global.System.Windows.Forms.Label()
			Me.chkFirst16 = New Global.System.Windows.Forms.CheckBox()
			Me.chkLast16 = New Global.System.Windows.Forms.CheckBox()
			Me.chkTime16 = New Global.System.Windows.Forms.CheckBox()
			Me.comboSoundConEng16 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundCon16 = New Global.System.Windows.Forms.ComboBox()
			Me.chkCon16 = New Global.System.Windows.Forms.CheckBox()
			Me.btnPlay16 = New Global.System.Windows.Forms.Button()
			Me.comboMin16 = New Global.System.Windows.Forms.ComboBox()
			Me.comboHour16 = New Global.System.Windows.Forms.ComboBox()
			Me.chkFirst15 = New Global.System.Windows.Forms.CheckBox()
			Me.chkFirst14 = New Global.System.Windows.Forms.CheckBox()
			Me.chkFirst13 = New Global.System.Windows.Forms.CheckBox()
			Me.chkLast15 = New Global.System.Windows.Forms.CheckBox()
			Me.chkLast14 = New Global.System.Windows.Forms.CheckBox()
			Me.chkLast13 = New Global.System.Windows.Forms.CheckBox()
			Me.chkTime15 = New Global.System.Windows.Forms.CheckBox()
			Me.chkTime14 = New Global.System.Windows.Forms.CheckBox()
			Me.chkTime13 = New Global.System.Windows.Forms.CheckBox()
			Me.comboSoundConEng15 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundConEng14 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundConEng13 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundCon15 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundCon14 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundCon13 = New Global.System.Windows.Forms.ComboBox()
			Me.chkCon15 = New Global.System.Windows.Forms.CheckBox()
			Me.btnPlay15 = New Global.System.Windows.Forms.Button()
			Me.comboMin15 = New Global.System.Windows.Forms.ComboBox()
			Me.comboHour15 = New Global.System.Windows.Forms.ComboBox()
			Me.chkCon14 = New Global.System.Windows.Forms.CheckBox()
			Me.btnPlay14 = New Global.System.Windows.Forms.Button()
			Me.comboMin14 = New Global.System.Windows.Forms.ComboBox()
			Me.comboHour14 = New Global.System.Windows.Forms.ComboBox()
			Me.chkCon13 = New Global.System.Windows.Forms.CheckBox()
			Me.btnPlay13 = New Global.System.Windows.Forms.Button()
			Me.comboMin13 = New Global.System.Windows.Forms.ComboBox()
			Me.comboHour13 = New Global.System.Windows.Forms.ComboBox()
			Me.chkFirst12 = New Global.System.Windows.Forms.CheckBox()
			Me.chkFirst11 = New Global.System.Windows.Forms.CheckBox()
			Me.chkFirst10 = New Global.System.Windows.Forms.CheckBox()
			Me.chkFirst9 = New Global.System.Windows.Forms.CheckBox()
			Me.chkFirst8 = New Global.System.Windows.Forms.CheckBox()
			Me.chkFirst7 = New Global.System.Windows.Forms.CheckBox()
			Me.chkFirst6 = New Global.System.Windows.Forms.CheckBox()
			Me.chkFirst5 = New Global.System.Windows.Forms.CheckBox()
			Me.chkFirst4 = New Global.System.Windows.Forms.CheckBox()
			Me.chkFirst3 = New Global.System.Windows.Forms.CheckBox()
			Me.chkFirst2 = New Global.System.Windows.Forms.CheckBox()
			Me.chkLastAll = New Global.System.Windows.Forms.CheckBox()
			Me.chkConAll = New Global.System.Windows.Forms.CheckBox()
			Me.chkTimeAll = New Global.System.Windows.Forms.CheckBox()
			Me.chkFirstAll = New Global.System.Windows.Forms.CheckBox()
			Me.chkFirst1 = New Global.System.Windows.Forms.CheckBox()
			Me.chkLast12 = New Global.System.Windows.Forms.CheckBox()
			Me.chkLast11 = New Global.System.Windows.Forms.CheckBox()
			Me.chkLast10 = New Global.System.Windows.Forms.CheckBox()
			Me.chkLast9 = New Global.System.Windows.Forms.CheckBox()
			Me.chkLast8 = New Global.System.Windows.Forms.CheckBox()
			Me.chkLast7 = New Global.System.Windows.Forms.CheckBox()
			Me.chkLast6 = New Global.System.Windows.Forms.CheckBox()
			Me.chkLast5 = New Global.System.Windows.Forms.CheckBox()
			Me.chkLast4 = New Global.System.Windows.Forms.CheckBox()
			Me.chkLast3 = New Global.System.Windows.Forms.CheckBox()
			Me.chkLast2 = New Global.System.Windows.Forms.CheckBox()
			Me.chkLast1 = New Global.System.Windows.Forms.CheckBox()
			Me.lblSuguest = New Global.System.Windows.Forms.Label()
			Me.lblReadCon = New Global.System.Windows.Forms.Label()
			Me.PictureBox6 = New Global.System.Windows.Forms.PictureBox()
			Me.lblReadTime = New Global.System.Windows.Forms.Label()
			Me.chkTime12 = New Global.System.Windows.Forms.CheckBox()
			Me.chkTime11 = New Global.System.Windows.Forms.CheckBox()
			Me.chkTime10 = New Global.System.Windows.Forms.CheckBox()
			Me.chkTime9 = New Global.System.Windows.Forms.CheckBox()
			Me.chkTime8 = New Global.System.Windows.Forms.CheckBox()
			Me.chkTime7 = New Global.System.Windows.Forms.CheckBox()
			Me.chkTime6 = New Global.System.Windows.Forms.CheckBox()
			Me.chkTime5 = New Global.System.Windows.Forms.CheckBox()
			Me.chkTime4 = New Global.System.Windows.Forms.CheckBox()
			Me.chkTime3 = New Global.System.Windows.Forms.CheckBox()
			Me.chkTime2 = New Global.System.Windows.Forms.CheckBox()
			Me.chkTime1 = New Global.System.Windows.Forms.CheckBox()
			Me.comboSoundConEng12 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundConEng11 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundConEng10 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundConEng9 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundConEng8 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundConEng7 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundConEng6 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundConEng5 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundConEng4 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundConEng3 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundConEng2 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundConEng1 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundCon12 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundCon11 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundCon10 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundCon9 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundCon8 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundCon7 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundCon6 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundCon5 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundCon4 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundCon3 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundCon2 = New Global.System.Windows.Forms.ComboBox()
			Me.comboSoundCon1 = New Global.System.Windows.Forms.ComboBox()
			Me.chkCon12 = New Global.System.Windows.Forms.CheckBox()
			Me.btnPlay12 = New Global.System.Windows.Forms.Button()
			Me.comboMin12 = New Global.System.Windows.Forms.ComboBox()
			Me.comboHour12 = New Global.System.Windows.Forms.ComboBox()
			Me.chkCon11 = New Global.System.Windows.Forms.CheckBox()
			Me.btnPlay11 = New Global.System.Windows.Forms.Button()
			Me.comboMin11 = New Global.System.Windows.Forms.ComboBox()
			Me.comboHour11 = New Global.System.Windows.Forms.ComboBox()
			Me.chkCon10 = New Global.System.Windows.Forms.CheckBox()
			Me.btnPlay10 = New Global.System.Windows.Forms.Button()
			Me.comboMin10 = New Global.System.Windows.Forms.ComboBox()
			Me.comboHour10 = New Global.System.Windows.Forms.ComboBox()
			Me.chkCon9 = New Global.System.Windows.Forms.CheckBox()
			Me.btnPlay9 = New Global.System.Windows.Forms.Button()
			Me.comboMin9 = New Global.System.Windows.Forms.ComboBox()
			Me.comboHour9 = New Global.System.Windows.Forms.ComboBox()
			Me.chkCon8 = New Global.System.Windows.Forms.CheckBox()
			Me.btnPlay8 = New Global.System.Windows.Forms.Button()
			Me.comboMin8 = New Global.System.Windows.Forms.ComboBox()
			Me.comboHour8 = New Global.System.Windows.Forms.ComboBox()
			Me.chkCon7 = New Global.System.Windows.Forms.CheckBox()
			Me.btnPlay7 = New Global.System.Windows.Forms.Button()
			Me.comboMin7 = New Global.System.Windows.Forms.ComboBox()
			Me.comboHour7 = New Global.System.Windows.Forms.ComboBox()
			Me.chkCon6 = New Global.System.Windows.Forms.CheckBox()
			Me.btnPlay6 = New Global.System.Windows.Forms.Button()
			Me.comboMin6 = New Global.System.Windows.Forms.ComboBox()
			Me.comboHour6 = New Global.System.Windows.Forms.ComboBox()
			Me.chkCon5 = New Global.System.Windows.Forms.CheckBox()
			Me.btnPlay5 = New Global.System.Windows.Forms.Button()
			Me.comboMin5 = New Global.System.Windows.Forms.ComboBox()
			Me.comboHour5 = New Global.System.Windows.Forms.ComboBox()
			Me.chkCon4 = New Global.System.Windows.Forms.CheckBox()
			Me.btnPlay4 = New Global.System.Windows.Forms.Button()
			Me.comboMin4 = New Global.System.Windows.Forms.ComboBox()
			Me.comboHour4 = New Global.System.Windows.Forms.ComboBox()
			Me.chkCon3 = New Global.System.Windows.Forms.CheckBox()
			Me.btnPlay3 = New Global.System.Windows.Forms.Button()
			Me.comboMin3 = New Global.System.Windows.Forms.ComboBox()
			Me.comboHour3 = New Global.System.Windows.Forms.ComboBox()
			Me.chkCon2 = New Global.System.Windows.Forms.CheckBox()
			Me.btnPlay2 = New Global.System.Windows.Forms.Button()
			Me.comboMin2 = New Global.System.Windows.Forms.ComboBox()
			Me.comboHour2 = New Global.System.Windows.Forms.ComboBox()
			Me.chkCon1 = New Global.System.Windows.Forms.CheckBox()
			Me.btnPlay1 = New Global.System.Windows.Forms.Button()
			Me.comboMin1 = New Global.System.Windows.Forms.ComboBox()
			Me.comboHour1 = New Global.System.Windows.Forms.ComboBox()
			Me.PictureBox7 = New Global.System.Windows.Forms.PictureBox()
			Me.panelSetting = New Global.System.Windows.Forms.Panel()
			Me.lblSetting = New Global.System.Windows.Forms.Label()
			Me.Label73 = New Global.System.Windows.Forms.Label()
			Me.comboMinShutdown = New Global.System.Windows.Forms.ComboBox()
			Me.comboHourShutdown = New Global.System.Windows.Forms.ComboBox()
			Me.ckShutDown = New Global.System.Windows.Forms.CheckBox()
			Me.chkEng = New Global.System.Windows.Forms.CheckBox()
			Me.btnPlaySound = New Global.System.Windows.Forms.Button()
			Me.lblAlarm = New Global.System.Windows.Forms.Label()
			Me.listSoundBell = New Global.System.Windows.Forms.ListBox()
			Me.chkThai = New Global.System.Windows.Forms.CheckBox()
			Me.lblLang = New Global.System.Windows.Forms.Label()
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.PanelEachDay.SuspendLayout()
			Me.panelAllDay.SuspendLayout()
			Me.PanelTime.SuspendLayout()
			CType(Me.PictureBox3, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.PictureBox2, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.PictureBox6, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.PictureBox7, Global.System.ComponentModel.ISupportInitialize).BeginInit()
			Me.panelSetting.SuspendLayout()
			Me.SuspendLayout()
			Me.lblTimeShow.AutoSize = True
			Me.lblTimeShow.BackColor = Global.System.Drawing.Color.FromArgb(224, 224, 224)
			Me.lblTimeShow.Font = New Global.System.Drawing.Font("Lucida Bright", 24F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblTimeShow.ForeColor = Global.System.Drawing.Color.Black
			Dim lblTimeShow As Global.System.Windows.Forms.Control = Me.lblTimeShow
			Dim point As Global.System.Drawing.Point = New Global.System.Drawing.Point(875, 58)
			lblTimeShow.Location = point
			Me.lblTimeShow.Name = "lblTimeShow"
			Dim lblTimeShow2 As Global.System.Windows.Forms.Control = Me.lblTimeShow
			Dim size As Global.System.Drawing.Size = New Global.System.Drawing.Size(100, 36)
			lblTimeShow2.Size = size
			Me.lblTimeShow.TabIndex = 9
			Me.lblTimeShow.Text = "TIME"
			Me.OpenFileDialog1.FileName = "OpenFileDialog1"
			Me.Timer2.Interval = 1000
			Me.lblPath.AutoSize = True
			Me.lblPath.BackColor = Global.System.Drawing.Color.Transparent
			Me.lblPath.ForeColor = Global.System.Drawing.Color.Black
			Dim lblPath As Global.System.Windows.Forms.Control = Me.lblPath
			point = New Global.System.Drawing.Point(764, 666)
			lblPath.Location = point
			Me.lblPath.Name = "lblPath"
			Dim lblPath2 As Global.System.Windows.Forms.Control = Me.lblPath
			size = New Global.System.Drawing.Size(29, 13)
			lblPath2.Size = size
			Me.lblPath.TabIndex = 132
			Me.lblPath.Text = "Path"
			Me.lblTopic2.AutoSize = True
			Me.lblTopic2.BackColor = Global.System.Drawing.Color.Transparent
			Me.lblTopic2.Font = New Global.System.Drawing.Font("Arial Narrow", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblTopic2.ForeColor = Global.System.Drawing.Color.Black
			Dim lblTopic As Global.System.Windows.Forms.Control = Me.lblTopic2
			point = New Global.System.Drawing.Point(116, 55)
			lblTopic.Location = point
			Me.lblTopic2.Name = "lblTopic2"
			Dim lblTopic2 As Global.System.Windows.Forms.Control = Me.lblTopic2
			size = New Global.System.Drawing.Size(169, 25)
			lblTopic2.Size = size
			Me.lblTopic2.TabIndex = 143
			Me.lblTopic2.Text = "โปรแกรมออดโรงเรียน"
			Me.lblP.AutoSize = True
			Me.lblP.BackColor = Global.System.Drawing.Color.Transparent
			Me.lblP.ForeColor = Global.System.Drawing.Color.Black
			Dim lblP As Global.System.Windows.Forms.Control = Me.lblP
			point = New Global.System.Drawing.Point(686, 666)
			lblP.Location = point
			Me.lblP.Name = "lblP"
			Dim lblP2 As Global.System.Windows.Forms.Control = Me.lblP
			size = New Global.System.Drawing.Size(78, 13)
			lblP2.Size = size
			Me.lblP.TabIndex = 144
			Me.lblP.Text = "ที่ตั้งโปรแกรม :"
			Me.btnReset.BackColor = Global.System.Drawing.Color.FloralWhite
			Me.btnReset.FlatStyle = Global.System.Windows.Forms.FlatStyle.Flat
			Me.btnReset.ForeColor = Global.System.Drawing.Color.White
			Dim btnReset As Global.System.Windows.Forms.Control = Me.btnReset
			point = New Global.System.Drawing.Point(904, 354)
			btnReset.Location = point
			Me.btnReset.Name = "btnReset"
			Dim btnReset2 As Global.System.Windows.Forms.Control = Me.btnReset
			size = New Global.System.Drawing.Size(59, 60)
			btnReset2.Size = size
			Me.btnReset.TabIndex = 207
			Me.btnReset.UseVisualStyleBackColor = False
			Me.lblCopyright.AutoSize = True
			Me.lblCopyright.BackColor = Global.System.Drawing.Color.MistyRose
			Me.lblCopyright.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 222)
			Me.lblCopyright.ForeColor = Global.System.Drawing.Color.Maroon
			Dim lblCopyright As Global.System.Windows.Forms.Control = Me.lblCopyright
			point = New Global.System.Drawing.Point(10, 651)
			lblCopyright.Location = point
			Me.lblCopyright.Name = "lblCopyright"
			Dim lblCopyright2 As Global.System.Windows.Forms.Control = Me.lblCopyright
			size = New Global.System.Drawing.Size(104, 13)
			lblCopyright2.Size = size
			Me.lblCopyright.TabIndex = 485
			Me.lblCopyright.Text = "Copyright @2017"
			Me.lblTopic1.AutoSize = True
			Me.lblTopic1.BackColor = Global.System.Drawing.Color.Transparent
			Me.lblTopic1.Font = New Global.System.Drawing.Font("Lucida Bright", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblTopic1.ForeColor = Global.System.Drawing.Color.Black
			Dim lblTopic3 As Global.System.Windows.Forms.Control = Me.lblTopic1
			point = New Global.System.Drawing.Point(111, 22)
			lblTopic3.Location = point
			Me.lblTopic1.Name = "lblTopic1"
			Dim lblTopic4 As Global.System.Windows.Forms.Control = Me.lblTopic1
			size = New Global.System.Drawing.Size(229, 24)
			lblTopic4.Size = size
			Me.lblTopic1.TabIndex = 143
			Me.lblTopic1.Text = "School Telling Time"
			Me.lblTopic1.TextAlign = Global.System.Drawing.ContentAlignment.TopCenter
			Me.lblRemark.AutoSize = True
			Me.lblRemark.BackColor = Global.System.Drawing.Color.Transparent
			Me.lblRemark.ForeColor = Global.System.Drawing.Color.Black
			Dim lblRemark As Global.System.Windows.Forms.Control = Me.lblRemark
			point = New Global.System.Drawing.Point(120, 651)
			lblRemark.Location = point
			Me.lblRemark.Name = "lblRemark"
			Dim lblRemark2 As Global.System.Windows.Forms.Control = Me.lblRemark
			size = New Global.System.Drawing.Size(52, 13)
			lblRemark2.Size = size
			Me.lblRemark.TabIndex = 522
			Me.lblRemark.Text = "หมายเหตุ"
			Me.btnCancel.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), Global.System.Drawing.Image)
			Dim btnCancel As Global.System.Windows.Forms.Control = Me.btnCancel
			point = New Global.System.Drawing.Point(972, 275)
			btnCancel.Location = point
			Me.btnCancel.Name = "btnCancel"
			Dim btnCancel2 As Global.System.Windows.Forms.Control = Me.btnCancel
			size = New Global.System.Drawing.Size(60, 60)
			btnCancel2.Size = size
			Me.btnCancel.TabIndex = 135
			Me.btnCancel.UseVisualStyleBackColor = False
			Me.btnExit.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), Global.System.Drawing.Image)
			Dim btnExit As Global.System.Windows.Forms.Control = Me.btnExit
			point = New Global.System.Drawing.Point(972, 354)
			btnExit.Location = point
			Me.btnExit.Name = "btnExit"
			Dim btnExit2 As Global.System.Windows.Forms.Control = Me.btnExit
			size = New Global.System.Drawing.Size(60, 60)
			btnExit2.Size = size
			Me.btnExit.TabIndex = 130
			Me.btnExit.UseVisualStyleBackColor = False
			Me.btnEdit.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), Global.System.Drawing.Image)
			Dim btnEdit As Global.System.Windows.Forms.Control = Me.btnEdit
			point = New Global.System.Drawing.Point(840, 275)
			btnEdit.Location = point
			Me.btnEdit.Name = "btnEdit"
			Dim btnEdit2 As Global.System.Windows.Forms.Control = Me.btnEdit
			size = New Global.System.Drawing.Size(60, 60)
			btnEdit2.Size = size
			Me.btnEdit.TabIndex = 129
			Me.btnEdit.UseVisualStyleBackColor = False
			Me.btnSave.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), Global.System.Drawing.Image)
			Dim btnSave As Global.System.Windows.Forms.Control = Me.btnSave
			point = New Global.System.Drawing.Point(906, 275)
			btnSave.Location = point
			Me.btnSave.Name = "btnSave"
			Dim btnSave2 As Global.System.Windows.Forms.Control = Me.btnSave
			size = New Global.System.Drawing.Size(60, 60)
			btnSave2.Size = size
			Me.btnSave.TabIndex = 128
			Me.btnSave.Tag = ""
			Me.btnSave.UseVisualStyleBackColor = False
			Me.lblEdit.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.lblEdit.AutoSize = True
			Me.lblEdit.BackColor = Global.System.Drawing.Color.Transparent
			Dim lblEdit As Global.System.Windows.Forms.Control = Me.lblEdit
			point = New Global.System.Drawing.Point(856, 338)
			lblEdit.Location = point
			Me.lblEdit.Name = "lblEdit"
			Dim lblEdit2 As Global.System.Windows.Forms.Control = Me.lblEdit
			size = New Global.System.Drawing.Size(25, 13)
			lblEdit2.Size = size
			Me.lblEdit.TabIndex = 627
			Me.lblEdit.Text = "Edit"
			Me.lblSave.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.lblSave.AutoSize = True
			Me.lblSave.BackColor = Global.System.Drawing.Color.Transparent
			Dim lblSave As Global.System.Windows.Forms.Control = Me.lblSave
			point = New Global.System.Drawing.Point(921, 338)
			lblSave.Location = point
			Me.lblSave.Name = "lblSave"
			Dim lblSave2 As Global.System.Windows.Forms.Control = Me.lblSave
			size = New Global.System.Drawing.Size(32, 13)
			lblSave2.Size = size
			Me.lblSave.TabIndex = 628
			Me.lblSave.Text = "Save"
			Me.lblCancel.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.lblCancel.AutoSize = True
			Me.lblCancel.BackColor = Global.System.Drawing.Color.Transparent
			Dim lblCancel As Global.System.Windows.Forms.Control = Me.lblCancel
			point = New Global.System.Drawing.Point(983, 338)
			lblCancel.Location = point
			Me.lblCancel.Name = "lblCancel"
			Dim lblCancel2 As Global.System.Windows.Forms.Control = Me.lblCancel
			size = New Global.System.Drawing.Size(40, 13)
			lblCancel2.Size = size
			Me.lblCancel.TabIndex = 629
			Me.lblCancel.Text = "Cancel"
			Me.lblReset.Anchor = Global.System.Windows.Forms.AnchorStyles.Top Or Global.System.Windows.Forms.AnchorStyles.Bottom Or Global.System.Windows.Forms.AnchorStyles.Left Or Global.System.Windows.Forms.AnchorStyles.Right
			Me.lblReset.AutoSize = True
			Me.lblReset.BackColor = Global.System.Drawing.Color.Transparent
			Dim lblReset As Global.System.Windows.Forms.Control = Me.lblReset
			point = New Global.System.Drawing.Point(916, 417)
			lblReset.Location = point
			Me.lblReset.Name = "lblReset"
			Dim lblReset2 As Global.System.Windows.Forms.Control = Me.lblReset
			size = New Global.System.Drawing.Size(35, 13)
			lblReset2.Size = size
			Me.lblReset.TabIndex = 630
			Me.lblReset.Text = "Reset"
			Me.im05.AutoSize = True
			Me.im05.BackColor = Global.System.Drawing.Color.Transparent
			Dim im As Global.System.Windows.Forms.Control = Me.im05
			point = New Global.System.Drawing.Point(988, 417)
			im.Location = point
			Me.im05.Name = "im05"
			Dim im2 As Global.System.Windows.Forms.Control = Me.im05
			size = New Global.System.Drawing.Size(33, 13)
			im2.Size = size
			Me.im05.TabIndex = 631
			Me.im05.Text = "Close"
			Me.PictureBox1.BackColor = Global.System.Drawing.Color.Transparent
			Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Global.System.Drawing.Image)
			Dim pictureBox As Global.System.Windows.Forms.Control = Me.PictureBox1
			point = New Global.System.Drawing.Point(26, 9)
			pictureBox.Location = point
			Me.PictureBox1.Name = "PictureBox1"
			Dim pictureBox2 As Global.System.Windows.Forms.Control = Me.PictureBox1
			size = New Global.System.Drawing.Size(79, 86)
			pictureBox2.Size = size
			Me.PictureBox1.TabIndex = 637
			Me.PictureBox1.TabStop = False
			Me.listLangDisplay.FormattingEnabled = True
			Me.listLangDisplay.Items.AddRange(New Object() { "Thai", "Eng" })
			Dim listLangDisplay As Global.System.Windows.Forms.Control = Me.listLangDisplay
			point = New Global.System.Drawing.Point(923, 14)
			listLangDisplay.Location = point
			Me.listLangDisplay.Name = "listLangDisplay"
			Dim listLangDisplay2 As Global.System.Windows.Forms.Control = Me.listLangDisplay
			size = New Global.System.Drawing.Size(40, 30)
			listLangDisplay2.Size = size
			Me.listLangDisplay.TabIndex = 638
			Me.lblLanguage.AutoSize = True
			Me.lblLanguage.BackColor = Global.System.Drawing.Color.Transparent
			Me.lblLanguage.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 11.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Me.lblLanguage.ForeColor = Global.System.Drawing.Color.Black
			Dim lblLanguage As Global.System.Windows.Forms.Control = Me.lblLanguage
			point = New Global.System.Drawing.Point(969, 14)
			lblLanguage.Location = point
			Me.lblLanguage.Name = "lblLanguage"
			Dim lblLanguage2 As Global.System.Windows.Forms.Control = Me.lblLanguage
			size = New Global.System.Drawing.Size(72, 18)
			lblLanguage2.Size = size
			Me.lblLanguage.TabIndex = 641
			Me.lblLanguage.Text = "Language"
			Me.lblCanUse.AutoSize = True
			Me.lblCanUse.BackColor = Global.System.Drawing.Color.Transparent
			Me.lblCanUse.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 12F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 222)
			Me.lblCanUse.ForeColor = Global.System.Drawing.Color.Black
			Dim lblCanUse As Global.System.Windows.Forms.Control = Me.lblCanUse
			point = New Global.System.Drawing.Point(840, 492)
			lblCanUse.Location = point
			Me.lblCanUse.Name = "lblCanUse"
			Dim lblCanUse2 As Global.System.Windows.Forms.Control = Me.lblCanUse
			size = New Global.System.Drawing.Size(93, 20)
			lblCanUse2.Size = size
			Me.lblCanUse.TabIndex = 724
			Me.lblCanUse.Text = "คงเหลือ/ครั้ง"
			Me.lblCD.AutoSize = True
			Me.lblCD.BackColor = Global.System.Drawing.Color.Yellow
			Me.lblCD.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 15.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 222)
			Me.lblCD.ForeColor = Global.System.Drawing.Color.OliveDrab
			Dim lblCD As Global.System.Windows.Forms.Control = Me.lblCD
			point = New Global.System.Drawing.Point(981, 488)
			lblCD.Location = point
			Me.lblCD.Name = "lblCD"
			Dim lblCD2 As Global.System.Windows.Forms.Control = Me.lblCD
			size = New Global.System.Drawing.Size(38, 25)
			lblCD2.Size = size
			Me.lblCD.TabIndex = 724
			Me.lblCD.Text = "00"
			Me.lblCD.TextAlign = Global.System.Drawing.ContentAlignment.MiddleRight
			Me.lblPayment.AutoSize = True
			Me.lblPayment.BackColor = Global.System.Drawing.Color.White
			Me.lblPayment.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 222)
			Me.lblPayment.ForeColor = Global.System.Drawing.Color.Maroon
			Dim lblPayment As Global.System.Windows.Forms.Control = Me.lblPayment
			point = New Global.System.Drawing.Point(824, 518)
			lblPayment.Location = point
			Me.lblPayment.Name = "lblPayment"
			Dim lblPayment2 As Global.System.Windows.Forms.Control = Me.lblPayment
			size = New Global.System.Drawing.Size(234, 117)
			lblPayment2.Size = size
			Me.lblPayment.TabIndex = 725
			Me.lblPayment.Text = resources.GetString("lblPayment.Text")
			Me.btnPayment.BackColor = Global.System.Drawing.Color.Lime
			Dim btnPayment As Global.System.Windows.Forms.Control = Me.btnPayment
			point = New Global.System.Drawing.Point(820, 640)
			btnPayment.Location = point
			Me.btnPayment.Name = "btnPayment"
			Dim btnPayment2 As Global.System.Windows.Forms.Control = Me.btnPayment
			size = New Global.System.Drawing.Size(238, 24)
			btnPayment2.Size = size
			Me.btnPayment.TabIndex = 726
			Me.btnPayment.Text = "กรอกโค้ดต่ออายุ"
			Me.btnPayment.UseVisualStyleBackColor = False
			Me.lblDev.AutoSize = True
			Me.lblDev.BackColor = Global.System.Drawing.Color.MistyRose
			Me.lblDev.ForeColor = Global.System.Drawing.Color.Maroon
			Dim lblDev As Global.System.Windows.Forms.Control = Me.lblDev
			point = New Global.System.Drawing.Point(10, 666)
			lblDev.Location = point
			Me.lblDev.Name = "lblDev"
			Dim lblDev2 As Global.System.Windows.Forms.Control = Me.lblDev
			size = New Global.System.Drawing.Size(25, 13)
			lblDev2.Size = size
			Me.lblDev.TabIndex = 522
			Me.lblDev.Text = "dev"
			Me.lblWarning.AutoSize = True
			Me.lblWarning.BackColor = Global.System.Drawing.Color.OrangeRed
			Me.lblWarning.Font = New Global.System.Drawing.Font("Lucida Bright", 24F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblWarning.ForeColor = Global.System.Drawing.Color.White
			Dim lblWarning As Global.System.Windows.Forms.Control = Me.lblWarning
			point = New Global.System.Drawing.Point(821, 446)
			lblWarning.Location = point
			Me.lblWarning.Name = "lblWarning"
			Dim lblWarning2 As Global.System.Windows.Forms.Control = Me.lblWarning
			size = New Global.System.Drawing.Size(233, 36)
			lblWarning2.Size = size
			Me.lblWarning.TabIndex = 9
			Me.lblWarning.Text = "กรุณาต่ออายุด้วยครับ"
			Me.PanelEachDay.BackColor = Global.System.Drawing.Color.White
			Me.PanelEachDay.Controls.Add(Me.radioFri)
			Me.PanelEachDay.Controls.Add(Me.radioThu)
			Me.PanelEachDay.Controls.Add(Me.radioWed)
			Me.PanelEachDay.Controls.Add(Me.radioTue)
			Me.PanelEachDay.Controls.Add(Me.radioSat)
			Me.PanelEachDay.Controls.Add(Me.radioSun)
			Me.PanelEachDay.Controls.Add(Me.radioMon)
			Me.PanelEachDay.Controls.Add(Me.lblToday)
			Dim panelEachDay As Global.System.Windows.Forms.Control = Me.PanelEachDay
			point = New Global.System.Drawing.Point(334, 58)
			panelEachDay.Location = point
			Me.PanelEachDay.Name = "PanelEachDay"
			Dim panelEachDay2 As Global.System.Windows.Forms.Control = Me.PanelEachDay
			size = New Global.System.Drawing.Size(491, 27)
			panelEachDay2.Size = size
			Me.PanelEachDay.TabIndex = 732
			Me.radioFri.AutoSize = True
			Dim radioFri As Global.System.Windows.Forms.Control = Me.radioFri
			point = New Global.System.Drawing.Point(373, 7)
			radioFri.Location = point
			Me.radioFri.Name = "radioFri"
			Dim radioFri2 As Global.System.Windows.Forms.Control = Me.radioFri
			size = New Global.System.Drawing.Size(46, 17)
			radioFri2.Size = size
			Me.radioFri.TabIndex = 739
			Me.radioFri.TabStop = True
			Me.radioFri.Text = "ศุกร์"
			Me.radioFri.UseVisualStyleBackColor = True
			Me.radioThu.AutoSize = True
			Dim radioThu As Global.System.Windows.Forms.Control = Me.radioThu
			point = New Global.System.Drawing.Point(297, 7)
			radioThu.Location = point
			Me.radioThu.Name = "radioThu"
			Dim radioThu2 As Global.System.Windows.Forms.Control = Me.radioThu
			size = New Global.System.Drawing.Size(67, 17)
			radioThu2.Size = size
			Me.radioThu.TabIndex = 738
			Me.radioThu.TabStop = True
			Me.radioThu.Text = "พฤหัสบดี"
			Me.radioThu.UseVisualStyleBackColor = True
			Me.radioWed.AutoSize = True
			Dim radioWed As Global.System.Windows.Forms.Control = Me.radioWed
			point = New Global.System.Drawing.Point(249, 7)
			radioWed.Location = point
			Me.radioWed.Name = "radioWed"
			Dim radioWed2 As Global.System.Windows.Forms.Control = Me.radioWed
			size = New Global.System.Drawing.Size(39, 17)
			radioWed2.Size = size
			Me.radioWed.TabIndex = 737
			Me.radioWed.TabStop = True
			Me.radioWed.Text = "พุธ"
			Me.radioWed.UseVisualStyleBackColor = True
			Me.radioTue.AutoSize = True
			Dim radioTue As Global.System.Windows.Forms.Control = Me.radioTue
			point = New Global.System.Drawing.Point(186, 7)
			radioTue.Location = point
			Me.radioTue.Name = "radioTue"
			Dim radioTue2 As Global.System.Windows.Forms.Control = Me.radioTue
			size = New Global.System.Drawing.Size(54, 17)
			radioTue2.Size = size
			Me.radioTue.TabIndex = 736
			Me.radioTue.TabStop = True
			Me.radioTue.Text = "อังคาร"
			Me.radioTue.UseVisualStyleBackColor = True
			Me.radioSat.AutoSize = True
			Dim radioSat As Global.System.Windows.Forms.Control = Me.radioSat
			point = New Global.System.Drawing.Point(428, 7)
			radioSat.Location = point
			Me.radioSat.Name = "radioSat"
			Dim radioSat2 As Global.System.Windows.Forms.Control = Me.radioSat
			size = New Global.System.Drawing.Size(47, 17)
			radioSat2.Size = size
			Me.radioSat.TabIndex = 733
			Me.radioSat.TabStop = True
			Me.radioSat.Text = "เสาร์"
			Me.radioSat.UseVisualStyleBackColor = True
			Me.radioSun.AutoSize = True
			Dim radioSun As Global.System.Windows.Forms.Control = Me.radioSun
			point = New Global.System.Drawing.Point(59, 7)
			radioSun.Location = point
			Me.radioSun.Name = "radioSun"
			Dim radioSun2 As Global.System.Windows.Forms.Control = Me.radioSun
			size = New Global.System.Drawing.Size(57, 17)
			radioSun2.Size = size
			Me.radioSun.TabIndex = 734
			Me.radioSun.TabStop = True
			Me.radioSun.Text = "อาทิตย์"
			Me.radioSun.UseVisualStyleBackColor = True
			Me.radioMon.AutoSize = True
			Dim radioMon As Global.System.Windows.Forms.Control = Me.radioMon
			point = New Global.System.Drawing.Point(125, 7)
			radioMon.Location = point
			Me.radioMon.Name = "radioMon"
			Dim radioMon2 As Global.System.Windows.Forms.Control = Me.radioMon
			size = New Global.System.Drawing.Size(52, 17)
			radioMon2.Size = size
			Me.radioMon.TabIndex = 735
			Me.radioMon.TabStop = True
			Me.radioMon.Text = "จันทร์"
			Me.radioMon.UseVisualStyleBackColor = True
			Me.lblToday.AutoSize = True
			Me.lblToday.BackColor = Global.System.Drawing.Color.Transparent
			Me.lblToday.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Me.lblToday.ForeColor = Global.System.Drawing.Color.Black
			Dim lblToday As Global.System.Windows.Forms.Control = Me.lblToday
			point = New Global.System.Drawing.Point(12, 9)
			lblToday.Location = point
			Me.lblToday.Name = "lblToday"
			Dim lblToday2 As Global.System.Windows.Forms.Control = Me.lblToday
			size = New Global.System.Drawing.Size(29, 13)
			lblToday2.Size = size
			Me.lblToday.TabIndex = 732
			Me.lblToday.Text = "วันนี้"
			Me.radioAllDay.AutoSize = True
			Me.radioAllDay.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Me.radioAllDay.ForeColor = Global.System.Drawing.Color.FromArgb(128, 64, 0)
			Dim radioAllDay As Global.System.Windows.Forms.Control = Me.radioAllDay
			point = New Global.System.Drawing.Point(36, 5)
			radioAllDay.Location = point
			Me.radioAllDay.Name = "radioAllDay"
			Dim radioAllDay2 As Global.System.Windows.Forms.Control = Me.radioAllDay
			size = New Global.System.Drawing.Size(101, 17)
			radioAllDay2.Size = size
			Me.radioAllDay.TabIndex = 740
			Me.radioAllDay.TabStop = True
			Me.radioAllDay.Text = "ทุกวันเหมือนกัน"
			Me.radioAllDay.UseVisualStyleBackColor = True
			Me.panelAllDay.BackColor = Global.System.Drawing.Color.White
			Me.panelAllDay.Controls.Add(Me.radioEachDay)
			Me.panelAllDay.Controls.Add(Me.radioAllDay)
			Dim panelAllDay As Global.System.Windows.Forms.Control = Me.panelAllDay
			point = New Global.System.Drawing.Point(517, 22)
			panelAllDay.Location = point
			Me.panelAllDay.Name = "panelAllDay"
			Dim panelAllDay2 As Global.System.Windows.Forms.Control = Me.panelAllDay
			size = New Global.System.Drawing.Size(308, 24)
			panelAllDay2.Size = size
			Me.panelAllDay.TabIndex = 733
			Me.radioEachDay.AutoSize = True
			Me.radioEachDay.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Me.radioEachDay.ForeColor = Global.System.Drawing.Color.FromArgb(128, 64, 0)
			Dim radioEachDay As Global.System.Windows.Forms.Control = Me.radioEachDay
			point = New Global.System.Drawing.Point(174, 5)
			radioEachDay.Location = point
			Me.radioEachDay.Name = "radioEachDay"
			Dim radioEachDay2 As Global.System.Windows.Forms.Control = Me.radioEachDay
			size = New Global.System.Drawing.Size(97, 17)
			radioEachDay2.Size = size
			Me.radioEachDay.TabIndex = 741
			Me.radioEachDay.TabStop = True
			Me.radioEachDay.Text = "แต่ละวันต่างกัน"
			Me.radioEachDay.UseVisualStyleBackColor = True
			Me.PanelTime.Controls.Add(Me.lbl22)
			Me.PanelTime.Controls.Add(Me.lbl23)
			Me.PanelTime.Controls.Add(Me.lbl24)
			Me.PanelTime.Controls.Add(Me.lbl17)
			Me.PanelTime.Controls.Add(Me.lbl18)
			Me.PanelTime.Controls.Add(Me.lbl19)
			Me.PanelTime.Controls.Add(Me.lbl20)
			Me.PanelTime.Controls.Add(Me.lbl21)
			Me.PanelTime.Controls.Add(Me.chkFirst24)
			Me.PanelTime.Controls.Add(Me.chkLast24)
			Me.PanelTime.Controls.Add(Me.chkTime24)
			Me.PanelTime.Controls.Add(Me.comboSoundConEng24)
			Me.PanelTime.Controls.Add(Me.comboSoundCon24)
			Me.PanelTime.Controls.Add(Me.chkCon24)
			Me.PanelTime.Controls.Add(Me.btnPlay24)
			Me.PanelTime.Controls.Add(Me.comboMin24)
			Me.PanelTime.Controls.Add(Me.comboHour24)
			Me.PanelTime.Controls.Add(Me.chkFirst23)
			Me.PanelTime.Controls.Add(Me.chkFirst22)
			Me.PanelTime.Controls.Add(Me.chkFirst21)
			Me.PanelTime.Controls.Add(Me.chkLast23)
			Me.PanelTime.Controls.Add(Me.chkLast22)
			Me.PanelTime.Controls.Add(Me.chkLast21)
			Me.PanelTime.Controls.Add(Me.chkTime23)
			Me.PanelTime.Controls.Add(Me.chkTime22)
			Me.PanelTime.Controls.Add(Me.chkTime21)
			Me.PanelTime.Controls.Add(Me.comboSoundConEng23)
			Me.PanelTime.Controls.Add(Me.comboSoundConEng22)
			Me.PanelTime.Controls.Add(Me.comboSoundConEng21)
			Me.PanelTime.Controls.Add(Me.comboSoundCon23)
			Me.PanelTime.Controls.Add(Me.comboSoundCon22)
			Me.PanelTime.Controls.Add(Me.comboSoundCon21)
			Me.PanelTime.Controls.Add(Me.chkCon23)
			Me.PanelTime.Controls.Add(Me.btnPlay23)
			Me.PanelTime.Controls.Add(Me.comboMin23)
			Me.PanelTime.Controls.Add(Me.comboHour23)
			Me.PanelTime.Controls.Add(Me.chkCon22)
			Me.PanelTime.Controls.Add(Me.btnPlay22)
			Me.PanelTime.Controls.Add(Me.comboMin22)
			Me.PanelTime.Controls.Add(Me.comboHour22)
			Me.PanelTime.Controls.Add(Me.chkCon21)
			Me.PanelTime.Controls.Add(Me.btnPlay21)
			Me.PanelTime.Controls.Add(Me.comboMin21)
			Me.PanelTime.Controls.Add(Me.comboHour21)
			Me.PanelTime.Controls.Add(Me.chkFirst20)
			Me.PanelTime.Controls.Add(Me.chkFirst19)
			Me.PanelTime.Controls.Add(Me.chkFirst18)
			Me.PanelTime.Controls.Add(Me.chkFirst17)
			Me.PanelTime.Controls.Add(Me.chkLast20)
			Me.PanelTime.Controls.Add(Me.chkLast19)
			Me.PanelTime.Controls.Add(Me.chkLast18)
			Me.PanelTime.Controls.Add(Me.chkLast17)
			Me.PanelTime.Controls.Add(Me.chkTime20)
			Me.PanelTime.Controls.Add(Me.chkTime19)
			Me.PanelTime.Controls.Add(Me.chkTime18)
			Me.PanelTime.Controls.Add(Me.chkTime17)
			Me.PanelTime.Controls.Add(Me.comboSoundConEng20)
			Me.PanelTime.Controls.Add(Me.comboSoundConEng19)
			Me.PanelTime.Controls.Add(Me.comboSoundConEng18)
			Me.PanelTime.Controls.Add(Me.comboSoundConEng17)
			Me.PanelTime.Controls.Add(Me.comboSoundCon20)
			Me.PanelTime.Controls.Add(Me.comboSoundCon19)
			Me.PanelTime.Controls.Add(Me.comboSoundCon18)
			Me.PanelTime.Controls.Add(Me.comboSoundCon17)
			Me.PanelTime.Controls.Add(Me.chkCon20)
			Me.PanelTime.Controls.Add(Me.btnPlay20)
			Me.PanelTime.Controls.Add(Me.comboMin20)
			Me.PanelTime.Controls.Add(Me.comboHour20)
			Me.PanelTime.Controls.Add(Me.chkCon19)
			Me.PanelTime.Controls.Add(Me.btnPlay19)
			Me.PanelTime.Controls.Add(Me.comboMin19)
			Me.PanelTime.Controls.Add(Me.comboHour19)
			Me.PanelTime.Controls.Add(Me.chkCon18)
			Me.PanelTime.Controls.Add(Me.btnPlay18)
			Me.PanelTime.Controls.Add(Me.comboMin18)
			Me.PanelTime.Controls.Add(Me.comboHour18)
			Me.PanelTime.Controls.Add(Me.chkCon17)
			Me.PanelTime.Controls.Add(Me.btnPlay17)
			Me.PanelTime.Controls.Add(Me.comboMin17)
			Me.PanelTime.Controls.Add(Me.comboHour17)
			Me.PanelTime.Controls.Add(Me.lblEng)
			Me.PanelTime.Controls.Add(Me.lblThai)
			Me.PanelTime.Controls.Add(Me.PictureBox3)
			Me.PanelTime.Controls.Add(Me.PictureBox2)
			Me.PanelTime.Controls.Add(Me.lbl14)
			Me.PanelTime.Controls.Add(Me.lbl15)
			Me.PanelTime.Controls.Add(Me.lbl16)
			Me.PanelTime.Controls.Add(Me.lbl09)
			Me.PanelTime.Controls.Add(Me.lbl10)
			Me.PanelTime.Controls.Add(Me.lbl11)
			Me.PanelTime.Controls.Add(Me.lbl12)
			Me.PanelTime.Controls.Add(Me.lbl13)
			Me.PanelTime.Controls.Add(Me.lbl06)
			Me.PanelTime.Controls.Add(Me.lbl07)
			Me.PanelTime.Controls.Add(Me.lbl08)
			Me.PanelTime.Controls.Add(Me.lbl05)
			Me.PanelTime.Controls.Add(Me.lbl04)
			Me.PanelTime.Controls.Add(Me.lbl03)
			Me.PanelTime.Controls.Add(Me.lbl02)
			Me.PanelTime.Controls.Add(Me.lbl01)
			Me.PanelTime.Controls.Add(Me.chkFirst16)
			Me.PanelTime.Controls.Add(Me.chkLast16)
			Me.PanelTime.Controls.Add(Me.chkTime16)
			Me.PanelTime.Controls.Add(Me.comboSoundConEng16)
			Me.PanelTime.Controls.Add(Me.comboSoundCon16)
			Me.PanelTime.Controls.Add(Me.chkCon16)
			Me.PanelTime.Controls.Add(Me.btnPlay16)
			Me.PanelTime.Controls.Add(Me.comboMin16)
			Me.PanelTime.Controls.Add(Me.comboHour16)
			Me.PanelTime.Controls.Add(Me.chkFirst15)
			Me.PanelTime.Controls.Add(Me.chkFirst14)
			Me.PanelTime.Controls.Add(Me.chkFirst13)
			Me.PanelTime.Controls.Add(Me.chkLast15)
			Me.PanelTime.Controls.Add(Me.chkLast14)
			Me.PanelTime.Controls.Add(Me.chkLast13)
			Me.PanelTime.Controls.Add(Me.chkTime15)
			Me.PanelTime.Controls.Add(Me.chkTime14)
			Me.PanelTime.Controls.Add(Me.chkTime13)
			Me.PanelTime.Controls.Add(Me.comboSoundConEng15)
			Me.PanelTime.Controls.Add(Me.comboSoundConEng14)
			Me.PanelTime.Controls.Add(Me.comboSoundConEng13)
			Me.PanelTime.Controls.Add(Me.comboSoundCon15)
			Me.PanelTime.Controls.Add(Me.comboSoundCon14)
			Me.PanelTime.Controls.Add(Me.comboSoundCon13)
			Me.PanelTime.Controls.Add(Me.chkCon15)
			Me.PanelTime.Controls.Add(Me.btnPlay15)
			Me.PanelTime.Controls.Add(Me.comboMin15)
			Me.PanelTime.Controls.Add(Me.comboHour15)
			Me.PanelTime.Controls.Add(Me.chkCon14)
			Me.PanelTime.Controls.Add(Me.btnPlay14)
			Me.PanelTime.Controls.Add(Me.comboMin14)
			Me.PanelTime.Controls.Add(Me.comboHour14)
			Me.PanelTime.Controls.Add(Me.chkCon13)
			Me.PanelTime.Controls.Add(Me.btnPlay13)
			Me.PanelTime.Controls.Add(Me.comboMin13)
			Me.PanelTime.Controls.Add(Me.comboHour13)
			Me.PanelTime.Controls.Add(Me.chkFirst12)
			Me.PanelTime.Controls.Add(Me.chkFirst11)
			Me.PanelTime.Controls.Add(Me.chkFirst10)
			Me.PanelTime.Controls.Add(Me.chkFirst9)
			Me.PanelTime.Controls.Add(Me.chkFirst8)
			Me.PanelTime.Controls.Add(Me.chkFirst7)
			Me.PanelTime.Controls.Add(Me.chkFirst6)
			Me.PanelTime.Controls.Add(Me.chkFirst5)
			Me.PanelTime.Controls.Add(Me.chkFirst4)
			Me.PanelTime.Controls.Add(Me.chkFirst3)
			Me.PanelTime.Controls.Add(Me.chkFirst2)
			Me.PanelTime.Controls.Add(Me.chkLastAll)
			Me.PanelTime.Controls.Add(Me.chkConAll)
			Me.PanelTime.Controls.Add(Me.chkTimeAll)
			Me.PanelTime.Controls.Add(Me.chkFirstAll)
			Me.PanelTime.Controls.Add(Me.chkFirst1)
			Me.PanelTime.Controls.Add(Me.chkLast12)
			Me.PanelTime.Controls.Add(Me.chkLast11)
			Me.PanelTime.Controls.Add(Me.chkLast10)
			Me.PanelTime.Controls.Add(Me.chkLast9)
			Me.PanelTime.Controls.Add(Me.chkLast8)
			Me.PanelTime.Controls.Add(Me.chkLast7)
			Me.PanelTime.Controls.Add(Me.chkLast6)
			Me.PanelTime.Controls.Add(Me.chkLast5)
			Me.PanelTime.Controls.Add(Me.chkLast4)
			Me.PanelTime.Controls.Add(Me.chkLast3)
			Me.PanelTime.Controls.Add(Me.chkLast2)
			Me.PanelTime.Controls.Add(Me.chkLast1)
			Me.PanelTime.Controls.Add(Me.lblSuguest)
			Me.PanelTime.Controls.Add(Me.lblReadCon)
			Me.PanelTime.Controls.Add(Me.PictureBox6)
			Me.PanelTime.Controls.Add(Me.lblReadTime)
			Me.PanelTime.Controls.Add(Me.chkTime12)
			Me.PanelTime.Controls.Add(Me.chkTime11)
			Me.PanelTime.Controls.Add(Me.chkTime10)
			Me.PanelTime.Controls.Add(Me.chkTime9)
			Me.PanelTime.Controls.Add(Me.chkTime8)
			Me.PanelTime.Controls.Add(Me.chkTime7)
			Me.PanelTime.Controls.Add(Me.chkTime6)
			Me.PanelTime.Controls.Add(Me.chkTime5)
			Me.PanelTime.Controls.Add(Me.chkTime4)
			Me.PanelTime.Controls.Add(Me.chkTime3)
			Me.PanelTime.Controls.Add(Me.chkTime2)
			Me.PanelTime.Controls.Add(Me.chkTime1)
			Me.PanelTime.Controls.Add(Me.comboSoundConEng12)
			Me.PanelTime.Controls.Add(Me.comboSoundConEng11)
			Me.PanelTime.Controls.Add(Me.comboSoundConEng10)
			Me.PanelTime.Controls.Add(Me.comboSoundConEng9)
			Me.PanelTime.Controls.Add(Me.comboSoundConEng8)
			Me.PanelTime.Controls.Add(Me.comboSoundConEng7)
			Me.PanelTime.Controls.Add(Me.comboSoundConEng6)
			Me.PanelTime.Controls.Add(Me.comboSoundConEng5)
			Me.PanelTime.Controls.Add(Me.comboSoundConEng4)
			Me.PanelTime.Controls.Add(Me.comboSoundConEng3)
			Me.PanelTime.Controls.Add(Me.comboSoundConEng2)
			Me.PanelTime.Controls.Add(Me.comboSoundConEng1)
			Me.PanelTime.Controls.Add(Me.comboSoundCon12)
			Me.PanelTime.Controls.Add(Me.comboSoundCon11)
			Me.PanelTime.Controls.Add(Me.comboSoundCon10)
			Me.PanelTime.Controls.Add(Me.comboSoundCon9)
			Me.PanelTime.Controls.Add(Me.comboSoundCon8)
			Me.PanelTime.Controls.Add(Me.comboSoundCon7)
			Me.PanelTime.Controls.Add(Me.comboSoundCon6)
			Me.PanelTime.Controls.Add(Me.comboSoundCon5)
			Me.PanelTime.Controls.Add(Me.comboSoundCon4)
			Me.PanelTime.Controls.Add(Me.comboSoundCon3)
			Me.PanelTime.Controls.Add(Me.comboSoundCon2)
			Me.PanelTime.Controls.Add(Me.comboSoundCon1)
			Me.PanelTime.Controls.Add(Me.chkCon12)
			Me.PanelTime.Controls.Add(Me.btnPlay12)
			Me.PanelTime.Controls.Add(Me.comboMin12)
			Me.PanelTime.Controls.Add(Me.comboHour12)
			Me.PanelTime.Controls.Add(Me.chkCon11)
			Me.PanelTime.Controls.Add(Me.btnPlay11)
			Me.PanelTime.Controls.Add(Me.comboMin11)
			Me.PanelTime.Controls.Add(Me.comboHour11)
			Me.PanelTime.Controls.Add(Me.chkCon10)
			Me.PanelTime.Controls.Add(Me.btnPlay10)
			Me.PanelTime.Controls.Add(Me.comboMin10)
			Me.PanelTime.Controls.Add(Me.comboHour10)
			Me.PanelTime.Controls.Add(Me.chkCon9)
			Me.PanelTime.Controls.Add(Me.btnPlay9)
			Me.PanelTime.Controls.Add(Me.comboMin9)
			Me.PanelTime.Controls.Add(Me.comboHour9)
			Me.PanelTime.Controls.Add(Me.chkCon8)
			Me.PanelTime.Controls.Add(Me.btnPlay8)
			Me.PanelTime.Controls.Add(Me.comboMin8)
			Me.PanelTime.Controls.Add(Me.comboHour8)
			Me.PanelTime.Controls.Add(Me.chkCon7)
			Me.PanelTime.Controls.Add(Me.btnPlay7)
			Me.PanelTime.Controls.Add(Me.comboMin7)
			Me.PanelTime.Controls.Add(Me.comboHour7)
			Me.PanelTime.Controls.Add(Me.chkCon6)
			Me.PanelTime.Controls.Add(Me.btnPlay6)
			Me.PanelTime.Controls.Add(Me.comboMin6)
			Me.PanelTime.Controls.Add(Me.comboHour6)
			Me.PanelTime.Controls.Add(Me.chkCon5)
			Me.PanelTime.Controls.Add(Me.btnPlay5)
			Me.PanelTime.Controls.Add(Me.comboMin5)
			Me.PanelTime.Controls.Add(Me.comboHour5)
			Me.PanelTime.Controls.Add(Me.chkCon4)
			Me.PanelTime.Controls.Add(Me.btnPlay4)
			Me.PanelTime.Controls.Add(Me.comboMin4)
			Me.PanelTime.Controls.Add(Me.comboHour4)
			Me.PanelTime.Controls.Add(Me.chkCon3)
			Me.PanelTime.Controls.Add(Me.btnPlay3)
			Me.PanelTime.Controls.Add(Me.comboMin3)
			Me.PanelTime.Controls.Add(Me.comboHour3)
			Me.PanelTime.Controls.Add(Me.chkCon2)
			Me.PanelTime.Controls.Add(Me.btnPlay2)
			Me.PanelTime.Controls.Add(Me.comboMin2)
			Me.PanelTime.Controls.Add(Me.comboHour2)
			Me.PanelTime.Controls.Add(Me.chkCon1)
			Me.PanelTime.Controls.Add(Me.btnPlay1)
			Me.PanelTime.Controls.Add(Me.comboMin1)
			Me.PanelTime.Controls.Add(Me.comboHour1)
			Me.PanelTime.Controls.Add(Me.PictureBox7)
			Dim panelTime As Global.System.Windows.Forms.Control = Me.PanelTime
			point = New Global.System.Drawing.Point(12, 91)
			panelTime.Location = point
			Me.PanelTime.Name = "PanelTime"
			Dim panelTime2 As Global.System.Windows.Forms.Control = Me.PanelTime
			size = New Global.System.Drawing.Size(802, 557)
			panelTime2.Size = size
			Me.PanelTime.TabIndex = 734
			Me.lbl22.AutoSize = True
			Me.lbl22.BackColor = Global.System.Drawing.Color.Transparent
			Me.lbl22.ForeColor = Global.System.Drawing.Color.Black
			Dim lbl As Global.System.Windows.Forms.Control = Me.lbl22
			point = New Global.System.Drawing.Point(50, 473)
			lbl.Location = point
			Me.lbl22.Name = "lbl22"
			Dim lbl2 As Global.System.Windows.Forms.Control = Me.lbl22
			size = New Global.System.Drawing.Size(45, 13)
			lbl2.Size = size
			Me.lbl22.TabIndex = 972
			Me.lbl22.Text = "Label22"
			Me.lbl23.AutoSize = True
			Me.lbl23.BackColor = Global.System.Drawing.Color.Transparent
			Me.lbl23.ForeColor = Global.System.Drawing.Color.Black
			Dim lbl3 As Global.System.Windows.Forms.Control = Me.lbl23
			point = New Global.System.Drawing.Point(50, 493)
			lbl3.Location = point
			Me.lbl23.Name = "lbl23"
			Dim lbl4 As Global.System.Windows.Forms.Control = Me.lbl23
			size = New Global.System.Drawing.Size(45, 13)
			lbl4.Size = size
			Me.lbl23.TabIndex = 971
			Me.lbl23.Text = "Label23"
			Me.lbl24.AutoSize = True
			Me.lbl24.BackColor = Global.System.Drawing.Color.Transparent
			Me.lbl24.ForeColor = Global.System.Drawing.Color.Black
			Dim lbl5 As Global.System.Windows.Forms.Control = Me.lbl24
			point = New Global.System.Drawing.Point(50, 513)
			lbl5.Location = point
			Me.lbl24.Name = "lbl24"
			Dim lbl6 As Global.System.Windows.Forms.Control = Me.lbl24
			size = New Global.System.Drawing.Size(45, 13)
			lbl6.Size = size
			Me.lbl24.TabIndex = 970
			Me.lbl24.Text = "Label24"
			Me.lbl17.AutoSize = True
			Me.lbl17.BackColor = Global.System.Drawing.Color.Transparent
			Me.lbl17.ForeColor = Global.System.Drawing.Color.Black
			Dim lbl7 As Global.System.Windows.Forms.Control = Me.lbl17
			point = New Global.System.Drawing.Point(50, 373)
			lbl7.Location = point
			Me.lbl17.Name = "lbl17"
			Dim lbl8 As Global.System.Windows.Forms.Control = Me.lbl17
			size = New Global.System.Drawing.Size(45, 13)
			lbl8.Size = size
			Me.lbl17.TabIndex = 969
			Me.lbl17.Text = "Label17"
			Me.lbl18.AutoSize = True
			Me.lbl18.BackColor = Global.System.Drawing.Color.Transparent
			Me.lbl18.ForeColor = Global.System.Drawing.Color.Black
			Dim lbl9 As Global.System.Windows.Forms.Control = Me.lbl18
			point = New Global.System.Drawing.Point(50, 393)
			lbl9.Location = point
			Me.lbl18.Name = "lbl18"
			Dim lbl10 As Global.System.Windows.Forms.Control = Me.lbl18
			size = New Global.System.Drawing.Size(45, 13)
			lbl10.Size = size
			Me.lbl18.TabIndex = 968
			Me.lbl18.Text = "Label18"
			Me.lbl19.AutoSize = True
			Me.lbl19.BackColor = Global.System.Drawing.Color.Transparent
			Me.lbl19.ForeColor = Global.System.Drawing.Color.Black
			Dim lbl11 As Global.System.Windows.Forms.Control = Me.lbl19
			point = New Global.System.Drawing.Point(50, 412)
			lbl11.Location = point
			Me.lbl19.Name = "lbl19"
			Dim lbl12 As Global.System.Windows.Forms.Control = Me.lbl19
			size = New Global.System.Drawing.Size(45, 13)
			lbl12.Size = size
			Me.lbl19.TabIndex = 967
			Me.lbl19.Text = "Label19"
			Me.lbl20.AutoSize = True
			Me.lbl20.BackColor = Global.System.Drawing.Color.Transparent
			Me.lbl20.ForeColor = Global.System.Drawing.Color.Black
			Dim lbl13 As Global.System.Windows.Forms.Control = Me.lbl20
			point = New Global.System.Drawing.Point(50, 433)
			lbl13.Location = point
			Me.lbl20.Name = "lbl20"
			Dim lbl14 As Global.System.Windows.Forms.Control = Me.lbl20
			size = New Global.System.Drawing.Size(45, 13)
			lbl14.Size = size
			Me.lbl20.TabIndex = 966
			Me.lbl20.Text = "Label20"
			Me.lbl21.AutoSize = True
			Me.lbl21.BackColor = Global.System.Drawing.Color.Transparent
			Me.lbl21.ForeColor = Global.System.Drawing.Color.Black
			Dim lbl15 As Global.System.Windows.Forms.Control = Me.lbl21
			point = New Global.System.Drawing.Point(50, 453)
			lbl15.Location = point
			Me.lbl21.Name = "lbl21"
			Dim lbl16 As Global.System.Windows.Forms.Control = Me.lbl21
			size = New Global.System.Drawing.Size(45, 13)
			lbl16.Size = size
			Me.lbl21.TabIndex = 965
			Me.lbl21.Text = "Label21"
			Me.chkFirst24.AutoSize = True
			Me.chkFirst24.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkFirst24.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkFirst As Global.System.Windows.Forms.Control = Me.chkFirst24
			point = New Global.System.Drawing.Point(31, 513)
			chkFirst.Location = point
			Me.chkFirst24.Name = "chkFirst24"
			Dim chkFirst2 As Global.System.Windows.Forms.Control = Me.chkFirst24
			size = New Global.System.Drawing.Size(15, 14)
			chkFirst2.Size = size
			Me.chkFirst24.TabIndex = 964
			Me.chkFirst24.UseVisualStyleBackColor = False
			Me.chkLast24.AutoSize = True
			Me.chkLast24.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkLast24.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkLast As Global.System.Windows.Forms.Control = Me.chkLast24
			point = New Global.System.Drawing.Point(735, 513)
			chkLast.Location = point
			Me.chkLast24.Name = "chkLast24"
			Dim chkLast2 As Global.System.Windows.Forms.Control = Me.chkLast24
			size = New Global.System.Drawing.Size(15, 14)
			chkLast2.Size = size
			Me.chkLast24.TabIndex = 963
			Me.chkLast24.UseVisualStyleBackColor = False
			Me.chkTime24.AutoSize = True
			Me.chkTime24.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkTime24.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkTime As Global.System.Windows.Forms.Control = Me.chkTime24
			point = New Global.System.Drawing.Point(110, 513)
			chkTime.Location = point
			Me.chkTime24.Name = "chkTime24"
			Dim chkTime2 As Global.System.Windows.Forms.Control = Me.chkTime24
			size = New Global.System.Drawing.Size(15, 14)
			chkTime2.Size = size
			Me.chkTime24.TabIndex = 962
			Me.chkTime24.UseVisualStyleBackColor = False
			Me.comboSoundConEng24.FormattingEnabled = True
			Dim comboSoundConEng As Global.System.Windows.Forms.Control = Me.comboSoundConEng24
			point = New Global.System.Drawing.Point(488, 510)
			comboSoundConEng.Location = point
			Me.comboSoundConEng24.Name = "comboSoundConEng24"
			Dim comboSoundConEng2 As Global.System.Windows.Forms.Control = Me.comboSoundConEng24
			size = New Global.System.Drawing.Size(238, 21)
			comboSoundConEng2.Size = size
			Me.comboSoundConEng24.TabIndex = 961
			Me.comboSoundCon24.FormattingEnabled = True
			Dim comboSoundCon As Global.System.Windows.Forms.Control = Me.comboSoundCon24
			point = New Global.System.Drawing.Point(250, 510)
			comboSoundCon.Location = point
			Me.comboSoundCon24.Name = "comboSoundCon24"
			Dim comboSoundCon2 As Global.System.Windows.Forms.Control = Me.comboSoundCon24
			size = New Global.System.Drawing.Size(232, 21)
			comboSoundCon2.Size = size
			Me.comboSoundCon24.TabIndex = 960
			Me.chkCon24.AutoSize = True
			Me.chkCon24.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkCon24.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkCon As Global.System.Windows.Forms.Control = Me.chkCon24
			point = New Global.System.Drawing.Point(229, 513)
			chkCon.Location = point
			Me.chkCon24.Name = "chkCon24"
			Dim chkCon2 As Global.System.Windows.Forms.Control = Me.chkCon24
			size = New Global.System.Drawing.Size(15, 14)
			chkCon2.Size = size
			Me.chkCon24.TabIndex = 959
			Me.chkCon24.UseVisualStyleBackColor = False
			Me.btnPlay24.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnPlay24.Image = CType(resources.GetObject("btnPlay24.Image"), Global.System.Drawing.Image)
			Dim btnPlay As Global.System.Windows.Forms.Control = Me.btnPlay24
			point = New Global.System.Drawing.Point(756, 508)
			btnPlay.Location = point
			Me.btnPlay24.Name = "btnPlay24"
			Dim btnPlay2 As Global.System.Windows.Forms.Control = Me.btnPlay24
			size = New Global.System.Drawing.Size(31, 21)
			btnPlay2.Size = size
			Me.btnPlay24.TabIndex = 958
			Me.btnPlay24.UseVisualStyleBackColor = False
			Me.comboMin24.FormattingEnabled = True
			Me.comboMin24.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" })
			Dim comboMin As Global.System.Windows.Forms.Control = Me.comboMin24
			point = New Global.System.Drawing.Point(177, 509)
			comboMin.Location = point
			Me.comboMin24.Name = "comboMin24"
			Dim comboMin2 As Global.System.Windows.Forms.Control = Me.comboMin24
			size = New Global.System.Drawing.Size(40, 21)
			comboMin2.Size = size
			Me.comboMin24.TabIndex = 957
			Me.comboHour24.FormattingEnabled = True
			Me.comboHour24.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" })
			Dim comboHour As Global.System.Windows.Forms.Control = Me.comboHour24
			point = New Global.System.Drawing.Point(132, 509)
			comboHour.Location = point
			Me.comboHour24.Name = "comboHour24"
			Dim comboHour2 As Global.System.Windows.Forms.Control = Me.comboHour24
			size = New Global.System.Drawing.Size(40, 21)
			comboHour2.Size = size
			Me.comboHour24.TabIndex = 956
			Me.chkFirst23.AutoSize = True
			Me.chkFirst23.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkFirst23.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkFirst3 As Global.System.Windows.Forms.Control = Me.chkFirst23
			point = New Global.System.Drawing.Point(31, 493)
			chkFirst3.Location = point
			Me.chkFirst23.Name = "chkFirst23"
			Dim chkFirst4 As Global.System.Windows.Forms.Control = Me.chkFirst23
			size = New Global.System.Drawing.Size(15, 14)
			chkFirst4.Size = size
			Me.chkFirst23.TabIndex = 955
			Me.chkFirst23.UseVisualStyleBackColor = False
			Me.chkFirst22.AutoSize = True
			Me.chkFirst22.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkFirst22.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkFirst5 As Global.System.Windows.Forms.Control = Me.chkFirst22
			point = New Global.System.Drawing.Point(31, 473)
			chkFirst5.Location = point
			Me.chkFirst22.Name = "chkFirst22"
			Dim chkFirst6 As Global.System.Windows.Forms.Control = Me.chkFirst22
			size = New Global.System.Drawing.Size(15, 14)
			chkFirst6.Size = size
			Me.chkFirst22.TabIndex = 954
			Me.chkFirst22.UseVisualStyleBackColor = False
			Me.chkFirst21.AutoSize = True
			Me.chkFirst21.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkFirst21.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkFirst7 As Global.System.Windows.Forms.Control = Me.chkFirst21
			point = New Global.System.Drawing.Point(31, 453)
			chkFirst7.Location = point
			Me.chkFirst21.Name = "chkFirst21"
			Dim chkFirst8 As Global.System.Windows.Forms.Control = Me.chkFirst21
			size = New Global.System.Drawing.Size(15, 14)
			chkFirst8.Size = size
			Me.chkFirst21.TabIndex = 953
			Me.chkFirst21.UseVisualStyleBackColor = False
			Me.chkLast23.AutoSize = True
			Me.chkLast23.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkLast23.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkLast3 As Global.System.Windows.Forms.Control = Me.chkLast23
			point = New Global.System.Drawing.Point(735, 493)
			chkLast3.Location = point
			Me.chkLast23.Name = "chkLast23"
			Dim chkLast4 As Global.System.Windows.Forms.Control = Me.chkLast23
			size = New Global.System.Drawing.Size(15, 14)
			chkLast4.Size = size
			Me.chkLast23.TabIndex = 952
			Me.chkLast23.UseVisualStyleBackColor = False
			Me.chkLast22.AutoSize = True
			Me.chkLast22.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkLast22.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkLast5 As Global.System.Windows.Forms.Control = Me.chkLast22
			point = New Global.System.Drawing.Point(735, 473)
			chkLast5.Location = point
			Me.chkLast22.Name = "chkLast22"
			Dim chkLast6 As Global.System.Windows.Forms.Control = Me.chkLast22
			size = New Global.System.Drawing.Size(15, 14)
			chkLast6.Size = size
			Me.chkLast22.TabIndex = 951
			Me.chkLast22.UseVisualStyleBackColor = False
			Me.chkLast21.AutoSize = True
			Me.chkLast21.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkLast21.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkLast7 As Global.System.Windows.Forms.Control = Me.chkLast21
			point = New Global.System.Drawing.Point(735, 453)
			chkLast7.Location = point
			Me.chkLast21.Name = "chkLast21"
			Dim chkLast8 As Global.System.Windows.Forms.Control = Me.chkLast21
			size = New Global.System.Drawing.Size(15, 14)
			chkLast8.Size = size
			Me.chkLast21.TabIndex = 950
			Me.chkLast21.UseVisualStyleBackColor = False
			Me.chkTime23.AutoSize = True
			Me.chkTime23.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkTime23.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkTime3 As Global.System.Windows.Forms.Control = Me.chkTime23
			point = New Global.System.Drawing.Point(110, 493)
			chkTime3.Location = point
			Me.chkTime23.Name = "chkTime23"
			Dim chkTime4 As Global.System.Windows.Forms.Control = Me.chkTime23
			size = New Global.System.Drawing.Size(15, 14)
			chkTime4.Size = size
			Me.chkTime23.TabIndex = 949
			Me.chkTime23.UseVisualStyleBackColor = False
			Me.chkTime22.AutoSize = True
			Me.chkTime22.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkTime22.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkTime5 As Global.System.Windows.Forms.Control = Me.chkTime22
			point = New Global.System.Drawing.Point(110, 473)
			chkTime5.Location = point
			Me.chkTime22.Name = "chkTime22"
			Dim chkTime6 As Global.System.Windows.Forms.Control = Me.chkTime22
			size = New Global.System.Drawing.Size(15, 14)
			chkTime6.Size = size
			Me.chkTime22.TabIndex = 948
			Me.chkTime22.UseVisualStyleBackColor = False
			Me.chkTime21.AutoSize = True
			Me.chkTime21.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkTime21.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkTime7 As Global.System.Windows.Forms.Control = Me.chkTime21
			point = New Global.System.Drawing.Point(110, 453)
			chkTime7.Location = point
			Me.chkTime21.Name = "chkTime21"
			Dim chkTime8 As Global.System.Windows.Forms.Control = Me.chkTime21
			size = New Global.System.Drawing.Size(15, 14)
			chkTime8.Size = size
			Me.chkTime21.TabIndex = 947
			Me.chkTime21.UseVisualStyleBackColor = False
			Me.comboSoundConEng23.FormattingEnabled = True
			Dim comboSoundConEng3 As Global.System.Windows.Forms.Control = Me.comboSoundConEng23
			point = New Global.System.Drawing.Point(488, 490)
			comboSoundConEng3.Location = point
			Me.comboSoundConEng23.Name = "comboSoundConEng23"
			Dim comboSoundConEng4 As Global.System.Windows.Forms.Control = Me.comboSoundConEng23
			size = New Global.System.Drawing.Size(238, 21)
			comboSoundConEng4.Size = size
			Me.comboSoundConEng23.TabIndex = 946
			Me.comboSoundConEng22.FormattingEnabled = True
			Dim comboSoundConEng5 As Global.System.Windows.Forms.Control = Me.comboSoundConEng22
			point = New Global.System.Drawing.Point(488, 470)
			comboSoundConEng5.Location = point
			Me.comboSoundConEng22.Name = "comboSoundConEng22"
			Dim comboSoundConEng6 As Global.System.Windows.Forms.Control = Me.comboSoundConEng22
			size = New Global.System.Drawing.Size(238, 21)
			comboSoundConEng6.Size = size
			Me.comboSoundConEng22.TabIndex = 945
			Me.comboSoundConEng21.FormattingEnabled = True
			Dim comboSoundConEng7 As Global.System.Windows.Forms.Control = Me.comboSoundConEng21
			point = New Global.System.Drawing.Point(488, 450)
			comboSoundConEng7.Location = point
			Me.comboSoundConEng21.Name = "comboSoundConEng21"
			Dim comboSoundConEng8 As Global.System.Windows.Forms.Control = Me.comboSoundConEng21
			size = New Global.System.Drawing.Size(238, 21)
			comboSoundConEng8.Size = size
			Me.comboSoundConEng21.TabIndex = 944
			Me.comboSoundCon23.FormattingEnabled = True
			Dim comboSoundCon3 As Global.System.Windows.Forms.Control = Me.comboSoundCon23
			point = New Global.System.Drawing.Point(250, 490)
			comboSoundCon3.Location = point
			Me.comboSoundCon23.Name = "comboSoundCon23"
			Dim comboSoundCon4 As Global.System.Windows.Forms.Control = Me.comboSoundCon23
			size = New Global.System.Drawing.Size(232, 21)
			comboSoundCon4.Size = size
			Me.comboSoundCon23.TabIndex = 943
			Me.comboSoundCon22.FormattingEnabled = True
			Dim comboSoundCon5 As Global.System.Windows.Forms.Control = Me.comboSoundCon22
			point = New Global.System.Drawing.Point(250, 470)
			comboSoundCon5.Location = point
			Me.comboSoundCon22.Name = "comboSoundCon22"
			Dim comboSoundCon6 As Global.System.Windows.Forms.Control = Me.comboSoundCon22
			size = New Global.System.Drawing.Size(232, 21)
			comboSoundCon6.Size = size
			Me.comboSoundCon22.TabIndex = 942
			Me.comboSoundCon21.FormattingEnabled = True
			Dim comboSoundCon7 As Global.System.Windows.Forms.Control = Me.comboSoundCon21
			point = New Global.System.Drawing.Point(250, 450)
			comboSoundCon7.Location = point
			Me.comboSoundCon21.Name = "comboSoundCon21"
			Dim comboSoundCon8 As Global.System.Windows.Forms.Control = Me.comboSoundCon21
			size = New Global.System.Drawing.Size(232, 21)
			comboSoundCon8.Size = size
			Me.comboSoundCon21.TabIndex = 941
			Me.chkCon23.AutoSize = True
			Me.chkCon23.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkCon23.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkCon3 As Global.System.Windows.Forms.Control = Me.chkCon23
			point = New Global.System.Drawing.Point(229, 493)
			chkCon3.Location = point
			Me.chkCon23.Name = "chkCon23"
			Dim chkCon4 As Global.System.Windows.Forms.Control = Me.chkCon23
			size = New Global.System.Drawing.Size(15, 14)
			chkCon4.Size = size
			Me.chkCon23.TabIndex = 940
			Me.chkCon23.UseVisualStyleBackColor = False
			Me.btnPlay23.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnPlay23.Image = CType(resources.GetObject("btnPlay23.Image"), Global.System.Drawing.Image)
			Dim btnPlay3 As Global.System.Windows.Forms.Control = Me.btnPlay23
			point = New Global.System.Drawing.Point(756, 489)
			btnPlay3.Location = point
			Me.btnPlay23.Name = "btnPlay23"
			Dim btnPlay4 As Global.System.Windows.Forms.Control = Me.btnPlay23
			size = New Global.System.Drawing.Size(31, 21)
			btnPlay4.Size = size
			Me.btnPlay23.TabIndex = 939
			Me.btnPlay23.UseVisualStyleBackColor = False
			Me.comboMin23.FormattingEnabled = True
			Me.comboMin23.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" })
			Dim comboMin3 As Global.System.Windows.Forms.Control = Me.comboMin23
			point = New Global.System.Drawing.Point(177, 490)
			comboMin3.Location = point
			Me.comboMin23.Name = "comboMin23"
			Dim comboMin4 As Global.System.Windows.Forms.Control = Me.comboMin23
			size = New Global.System.Drawing.Size(40, 21)
			comboMin4.Size = size
			Me.comboMin23.TabIndex = 938
			Me.comboHour23.FormattingEnabled = True
			Me.comboHour23.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" })
			Dim comboHour3 As Global.System.Windows.Forms.Control = Me.comboHour23
			point = New Global.System.Drawing.Point(132, 490)
			comboHour3.Location = point
			Me.comboHour23.Name = "comboHour23"
			Dim comboHour4 As Global.System.Windows.Forms.Control = Me.comboHour23
			size = New Global.System.Drawing.Size(40, 21)
			comboHour4.Size = size
			Me.comboHour23.TabIndex = 937
			Me.chkCon22.AutoSize = True
			Me.chkCon22.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkCon22.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkCon5 As Global.System.Windows.Forms.Control = Me.chkCon22
			point = New Global.System.Drawing.Point(229, 473)
			chkCon5.Location = point
			Me.chkCon22.Name = "chkCon22"
			Dim chkCon6 As Global.System.Windows.Forms.Control = Me.chkCon22
			size = New Global.System.Drawing.Size(15, 14)
			chkCon6.Size = size
			Me.chkCon22.TabIndex = 936
			Me.chkCon22.UseVisualStyleBackColor = False
			Me.btnPlay22.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnPlay22.Image = CType(resources.GetObject("btnPlay22.Image"), Global.System.Drawing.Image)
			Dim btnPlay5 As Global.System.Windows.Forms.Control = Me.btnPlay22
			point = New Global.System.Drawing.Point(756, 468)
			btnPlay5.Location = point
			Me.btnPlay22.Name = "btnPlay22"
			Dim btnPlay6 As Global.System.Windows.Forms.Control = Me.btnPlay22
			size = New Global.System.Drawing.Size(31, 22)
			btnPlay6.Size = size
			Me.btnPlay22.TabIndex = 935
			Me.btnPlay22.UseVisualStyleBackColor = False
			Me.comboMin22.FormattingEnabled = True
			Me.comboMin22.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" })
			Dim comboMin5 As Global.System.Windows.Forms.Control = Me.comboMin22
			point = New Global.System.Drawing.Point(177, 470)
			comboMin5.Location = point
			Me.comboMin22.Name = "comboMin22"
			Dim comboMin6 As Global.System.Windows.Forms.Control = Me.comboMin22
			size = New Global.System.Drawing.Size(40, 21)
			comboMin6.Size = size
			Me.comboMin22.TabIndex = 934
			Me.comboHour22.FormattingEnabled = True
			Me.comboHour22.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" })
			Dim comboHour5 As Global.System.Windows.Forms.Control = Me.comboHour22
			point = New Global.System.Drawing.Point(132, 470)
			comboHour5.Location = point
			Me.comboHour22.Name = "comboHour22"
			Dim comboHour6 As Global.System.Windows.Forms.Control = Me.comboHour22
			size = New Global.System.Drawing.Size(40, 21)
			comboHour6.Size = size
			Me.comboHour22.TabIndex = 933
			Me.chkCon21.AutoSize = True
			Me.chkCon21.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkCon21.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkCon7 As Global.System.Windows.Forms.Control = Me.chkCon21
			point = New Global.System.Drawing.Point(229, 453)
			chkCon7.Location = point
			Me.chkCon21.Name = "chkCon21"
			Dim chkCon8 As Global.System.Windows.Forms.Control = Me.chkCon21
			size = New Global.System.Drawing.Size(15, 14)
			chkCon8.Size = size
			Me.chkCon21.TabIndex = 932
			Me.chkCon21.UseVisualStyleBackColor = False
			Me.btnPlay21.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnPlay21.Image = CType(resources.GetObject("btnPlay21.Image"), Global.System.Drawing.Image)
			Dim btnPlay7 As Global.System.Windows.Forms.Control = Me.btnPlay21
			point = New Global.System.Drawing.Point(756, 449)
			btnPlay7.Location = point
			Me.btnPlay21.Name = "btnPlay21"
			Dim btnPlay8 As Global.System.Windows.Forms.Control = Me.btnPlay21
			size = New Global.System.Drawing.Size(31, 21)
			btnPlay8.Size = size
			Me.btnPlay21.TabIndex = 931
			Me.btnPlay21.UseVisualStyleBackColor = False
			Me.comboMin21.FormattingEnabled = True
			Me.comboMin21.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" })
			Dim comboMin7 As Global.System.Windows.Forms.Control = Me.comboMin21
			point = New Global.System.Drawing.Point(177, 450)
			comboMin7.Location = point
			Me.comboMin21.Name = "comboMin21"
			Dim comboMin8 As Global.System.Windows.Forms.Control = Me.comboMin21
			size = New Global.System.Drawing.Size(40, 21)
			comboMin8.Size = size
			Me.comboMin21.TabIndex = 930
			Me.comboHour21.FormattingEnabled = True
			Me.comboHour21.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" })
			Dim comboHour7 As Global.System.Windows.Forms.Control = Me.comboHour21
			point = New Global.System.Drawing.Point(132, 450)
			comboHour7.Location = point
			Me.comboHour21.Name = "comboHour21"
			Dim comboHour8 As Global.System.Windows.Forms.Control = Me.comboHour21
			size = New Global.System.Drawing.Size(40, 21)
			comboHour8.Size = size
			Me.comboHour21.TabIndex = 929
			Me.chkFirst20.AutoSize = True
			Me.chkFirst20.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkFirst20.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkFirst9 As Global.System.Windows.Forms.Control = Me.chkFirst20
			point = New Global.System.Drawing.Point(31, 433)
			chkFirst9.Location = point
			Me.chkFirst20.Name = "chkFirst20"
			Dim chkFirst10 As Global.System.Windows.Forms.Control = Me.chkFirst20
			size = New Global.System.Drawing.Size(15, 14)
			chkFirst10.Size = size
			Me.chkFirst20.TabIndex = 928
			Me.chkFirst20.UseVisualStyleBackColor = False
			Me.chkFirst19.AutoSize = True
			Me.chkFirst19.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkFirst19.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkFirst11 As Global.System.Windows.Forms.Control = Me.chkFirst19
			point = New Global.System.Drawing.Point(31, 413)
			chkFirst11.Location = point
			Me.chkFirst19.Name = "chkFirst19"
			Dim chkFirst12 As Global.System.Windows.Forms.Control = Me.chkFirst19
			size = New Global.System.Drawing.Size(15, 14)
			chkFirst12.Size = size
			Me.chkFirst19.TabIndex = 927
			Me.chkFirst19.UseVisualStyleBackColor = False
			Me.chkFirst18.AutoSize = True
			Me.chkFirst18.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkFirst18.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkFirst13 As Global.System.Windows.Forms.Control = Me.chkFirst18
			point = New Global.System.Drawing.Point(31, 393)
			chkFirst13.Location = point
			Me.chkFirst18.Name = "chkFirst18"
			Dim chkFirst14 As Global.System.Windows.Forms.Control = Me.chkFirst18
			size = New Global.System.Drawing.Size(15, 14)
			chkFirst14.Size = size
			Me.chkFirst18.TabIndex = 926
			Me.chkFirst18.UseVisualStyleBackColor = False
			Me.chkFirst17.AutoSize = True
			Me.chkFirst17.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkFirst17.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkFirst15 As Global.System.Windows.Forms.Control = Me.chkFirst17
			point = New Global.System.Drawing.Point(31, 373)
			chkFirst15.Location = point
			Me.chkFirst17.Name = "chkFirst17"
			Dim chkFirst16 As Global.System.Windows.Forms.Control = Me.chkFirst17
			size = New Global.System.Drawing.Size(15, 14)
			chkFirst16.Size = size
			Me.chkFirst17.TabIndex = 925
			Me.chkFirst17.UseVisualStyleBackColor = False
			Me.chkLast20.AutoSize = True
			Me.chkLast20.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkLast20.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkLast9 As Global.System.Windows.Forms.Control = Me.chkLast20
			point = New Global.System.Drawing.Point(735, 433)
			chkLast9.Location = point
			Me.chkLast20.Name = "chkLast20"
			Dim chkLast10 As Global.System.Windows.Forms.Control = Me.chkLast20
			size = New Global.System.Drawing.Size(15, 14)
			chkLast10.Size = size
			Me.chkLast20.TabIndex = 924
			Me.chkLast20.UseVisualStyleBackColor = False
			Me.chkLast19.AutoSize = True
			Me.chkLast19.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkLast19.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkLast11 As Global.System.Windows.Forms.Control = Me.chkLast19
			point = New Global.System.Drawing.Point(735, 413)
			chkLast11.Location = point
			Me.chkLast19.Name = "chkLast19"
			Dim chkLast12 As Global.System.Windows.Forms.Control = Me.chkLast19
			size = New Global.System.Drawing.Size(15, 14)
			chkLast12.Size = size
			Me.chkLast19.TabIndex = 923
			Me.chkLast19.UseVisualStyleBackColor = False
			Me.chkLast18.AutoSize = True
			Me.chkLast18.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkLast18.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkLast13 As Global.System.Windows.Forms.Control = Me.chkLast18
			point = New Global.System.Drawing.Point(735, 393)
			chkLast13.Location = point
			Me.chkLast18.Name = "chkLast18"
			Dim chkLast14 As Global.System.Windows.Forms.Control = Me.chkLast18
			size = New Global.System.Drawing.Size(15, 14)
			chkLast14.Size = size
			Me.chkLast18.TabIndex = 922
			Me.chkLast18.UseVisualStyleBackColor = False
			Me.chkLast17.AutoSize = True
			Me.chkLast17.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkLast17.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkLast15 As Global.System.Windows.Forms.Control = Me.chkLast17
			point = New Global.System.Drawing.Point(735, 373)
			chkLast15.Location = point
			Me.chkLast17.Name = "chkLast17"
			Dim chkLast16 As Global.System.Windows.Forms.Control = Me.chkLast17
			size = New Global.System.Drawing.Size(15, 14)
			chkLast16.Size = size
			Me.chkLast17.TabIndex = 921
			Me.chkLast17.UseVisualStyleBackColor = False
			Me.chkTime20.AutoSize = True
			Me.chkTime20.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkTime20.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkTime9 As Global.System.Windows.Forms.Control = Me.chkTime20
			point = New Global.System.Drawing.Point(110, 433)
			chkTime9.Location = point
			Me.chkTime20.Name = "chkTime20"
			Dim chkTime10 As Global.System.Windows.Forms.Control = Me.chkTime20
			size = New Global.System.Drawing.Size(15, 14)
			chkTime10.Size = size
			Me.chkTime20.TabIndex = 920
			Me.chkTime20.UseVisualStyleBackColor = False
			Me.chkTime19.AutoSize = True
			Me.chkTime19.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkTime19.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkTime11 As Global.System.Windows.Forms.Control = Me.chkTime19
			point = New Global.System.Drawing.Point(110, 413)
			chkTime11.Location = point
			Me.chkTime19.Name = "chkTime19"
			Dim chkTime12 As Global.System.Windows.Forms.Control = Me.chkTime19
			size = New Global.System.Drawing.Size(15, 14)
			chkTime12.Size = size
			Me.chkTime19.TabIndex = 919
			Me.chkTime19.UseVisualStyleBackColor = False
			Me.chkTime18.AutoSize = True
			Me.chkTime18.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkTime18.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkTime13 As Global.System.Windows.Forms.Control = Me.chkTime18
			point = New Global.System.Drawing.Point(110, 393)
			chkTime13.Location = point
			Me.chkTime18.Name = "chkTime18"
			Dim chkTime14 As Global.System.Windows.Forms.Control = Me.chkTime18
			size = New Global.System.Drawing.Size(15, 14)
			chkTime14.Size = size
			Me.chkTime18.TabIndex = 918
			Me.chkTime18.UseVisualStyleBackColor = False
			Me.chkTime17.AutoSize = True
			Me.chkTime17.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkTime17.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkTime15 As Global.System.Windows.Forms.Control = Me.chkTime17
			point = New Global.System.Drawing.Point(110, 373)
			chkTime15.Location = point
			Me.chkTime17.Name = "chkTime17"
			Dim chkTime16 As Global.System.Windows.Forms.Control = Me.chkTime17
			size = New Global.System.Drawing.Size(15, 14)
			chkTime16.Size = size
			Me.chkTime17.TabIndex = 917
			Me.chkTime17.UseVisualStyleBackColor = False
			Me.comboSoundConEng20.FormattingEnabled = True
			Dim comboSoundConEng9 As Global.System.Windows.Forms.Control = Me.comboSoundConEng20
			point = New Global.System.Drawing.Point(488, 430)
			comboSoundConEng9.Location = point
			Me.comboSoundConEng20.Name = "comboSoundConEng20"
			Dim comboSoundConEng10 As Global.System.Windows.Forms.Control = Me.comboSoundConEng20
			size = New Global.System.Drawing.Size(238, 21)
			comboSoundConEng10.Size = size
			Me.comboSoundConEng20.TabIndex = 916
			Me.comboSoundConEng19.FormattingEnabled = True
			Dim comboSoundConEng11 As Global.System.Windows.Forms.Control = Me.comboSoundConEng19
			point = New Global.System.Drawing.Point(488, 410)
			comboSoundConEng11.Location = point
			Me.comboSoundConEng19.Name = "comboSoundConEng19"
			Dim comboSoundConEng12 As Global.System.Windows.Forms.Control = Me.comboSoundConEng19
			size = New Global.System.Drawing.Size(238, 21)
			comboSoundConEng12.Size = size
			Me.comboSoundConEng19.TabIndex = 915
			Me.comboSoundConEng18.FormattingEnabled = True
			Dim comboSoundConEng13 As Global.System.Windows.Forms.Control = Me.comboSoundConEng18
			point = New Global.System.Drawing.Point(488, 390)
			comboSoundConEng13.Location = point
			Me.comboSoundConEng18.Name = "comboSoundConEng18"
			Dim comboSoundConEng14 As Global.System.Windows.Forms.Control = Me.comboSoundConEng18
			size = New Global.System.Drawing.Size(238, 21)
			comboSoundConEng14.Size = size
			Me.comboSoundConEng18.TabIndex = 914
			Me.comboSoundConEng17.FormattingEnabled = True
			Dim comboSoundConEng15 As Global.System.Windows.Forms.Control = Me.comboSoundConEng17
			point = New Global.System.Drawing.Point(488, 370)
			comboSoundConEng15.Location = point
			Me.comboSoundConEng17.Name = "comboSoundConEng17"
			Dim comboSoundConEng16 As Global.System.Windows.Forms.Control = Me.comboSoundConEng17
			size = New Global.System.Drawing.Size(238, 21)
			comboSoundConEng16.Size = size
			Me.comboSoundConEng17.TabIndex = 913
			Me.comboSoundCon20.FormattingEnabled = True
			Dim comboSoundCon9 As Global.System.Windows.Forms.Control = Me.comboSoundCon20
			point = New Global.System.Drawing.Point(250, 430)
			comboSoundCon9.Location = point
			Me.comboSoundCon20.Name = "comboSoundCon20"
			Dim comboSoundCon10 As Global.System.Windows.Forms.Control = Me.comboSoundCon20
			size = New Global.System.Drawing.Size(232, 21)
			comboSoundCon10.Size = size
			Me.comboSoundCon20.TabIndex = 912
			Me.comboSoundCon19.FormattingEnabled = True
			Dim comboSoundCon11 As Global.System.Windows.Forms.Control = Me.comboSoundCon19
			point = New Global.System.Drawing.Point(250, 410)
			comboSoundCon11.Location = point
			Me.comboSoundCon19.Name = "comboSoundCon19"
			Dim comboSoundCon12 As Global.System.Windows.Forms.Control = Me.comboSoundCon19
			size = New Global.System.Drawing.Size(232, 21)
			comboSoundCon12.Size = size
			Me.comboSoundCon19.TabIndex = 911
			Me.comboSoundCon18.FormattingEnabled = True
			Dim comboSoundCon13 As Global.System.Windows.Forms.Control = Me.comboSoundCon18
			point = New Global.System.Drawing.Point(250, 390)
			comboSoundCon13.Location = point
			Me.comboSoundCon18.Name = "comboSoundCon18"
			Dim comboSoundCon14 As Global.System.Windows.Forms.Control = Me.comboSoundCon18
			size = New Global.System.Drawing.Size(232, 21)
			comboSoundCon14.Size = size
			Me.comboSoundCon18.TabIndex = 910
			Me.comboSoundCon17.FormattingEnabled = True
			Dim comboSoundCon15 As Global.System.Windows.Forms.Control = Me.comboSoundCon17
			point = New Global.System.Drawing.Point(250, 370)
			comboSoundCon15.Location = point
			Me.comboSoundCon17.Name = "comboSoundCon17"
			Dim comboSoundCon16 As Global.System.Windows.Forms.Control = Me.comboSoundCon17
			size = New Global.System.Drawing.Size(232, 21)
			comboSoundCon16.Size = size
			Me.comboSoundCon17.TabIndex = 909
			Me.chkCon20.AutoSize = True
			Me.chkCon20.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkCon20.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkCon9 As Global.System.Windows.Forms.Control = Me.chkCon20
			point = New Global.System.Drawing.Point(229, 433)
			chkCon9.Location = point
			Me.chkCon20.Name = "chkCon20"
			Dim chkCon10 As Global.System.Windows.Forms.Control = Me.chkCon20
			size = New Global.System.Drawing.Size(15, 14)
			chkCon10.Size = size
			Me.chkCon20.TabIndex = 908
			Me.chkCon20.UseVisualStyleBackColor = False
			Me.btnPlay20.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnPlay20.Image = CType(resources.GetObject("btnPlay20.Image"), Global.System.Drawing.Image)
			Dim btnPlay9 As Global.System.Windows.Forms.Control = Me.btnPlay20
			point = New Global.System.Drawing.Point(756, 429)
			btnPlay9.Location = point
			Me.btnPlay20.Name = "btnPlay20"
			Dim btnPlay10 As Global.System.Windows.Forms.Control = Me.btnPlay20
			size = New Global.System.Drawing.Size(31, 21)
			btnPlay10.Size = size
			Me.btnPlay20.TabIndex = 907
			Me.btnPlay20.UseVisualStyleBackColor = False
			Me.comboMin20.FormattingEnabled = True
			Me.comboMin20.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" })
			Dim comboMin9 As Global.System.Windows.Forms.Control = Me.comboMin20
			point = New Global.System.Drawing.Point(177, 430)
			comboMin9.Location = point
			Me.comboMin20.Name = "comboMin20"
			Dim comboMin10 As Global.System.Windows.Forms.Control = Me.comboMin20
			size = New Global.System.Drawing.Size(40, 21)
			comboMin10.Size = size
			Me.comboMin20.TabIndex = 906
			Me.comboHour20.FormattingEnabled = True
			Me.comboHour20.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" })
			Dim comboHour9 As Global.System.Windows.Forms.Control = Me.comboHour20
			point = New Global.System.Drawing.Point(132, 430)
			comboHour9.Location = point
			Me.comboHour20.Name = "comboHour20"
			Dim comboHour10 As Global.System.Windows.Forms.Control = Me.comboHour20
			size = New Global.System.Drawing.Size(40, 21)
			comboHour10.Size = size
			Me.comboHour20.TabIndex = 905
			Me.chkCon19.AutoSize = True
			Me.chkCon19.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkCon19.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkCon11 As Global.System.Windows.Forms.Control = Me.chkCon19
			point = New Global.System.Drawing.Point(229, 413)
			chkCon11.Location = point
			Me.chkCon19.Name = "chkCon19"
			Dim chkCon12 As Global.System.Windows.Forms.Control = Me.chkCon19
			size = New Global.System.Drawing.Size(15, 14)
			chkCon12.Size = size
			Me.chkCon19.TabIndex = 904
			Me.chkCon19.UseVisualStyleBackColor = False
			Me.btnPlay19.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnPlay19.Image = CType(resources.GetObject("btnPlay19.Image"), Global.System.Drawing.Image)
			Dim btnPlay11 As Global.System.Windows.Forms.Control = Me.btnPlay19
			point = New Global.System.Drawing.Point(756, 408)
			btnPlay11.Location = point
			Me.btnPlay19.Name = "btnPlay19"
			Dim btnPlay12 As Global.System.Windows.Forms.Control = Me.btnPlay19
			size = New Global.System.Drawing.Size(31, 22)
			btnPlay12.Size = size
			Me.btnPlay19.TabIndex = 903
			Me.btnPlay19.UseVisualStyleBackColor = False
			Me.comboMin19.FormattingEnabled = True
			Me.comboMin19.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" })
			Dim comboMin11 As Global.System.Windows.Forms.Control = Me.comboMin19
			point = New Global.System.Drawing.Point(177, 410)
			comboMin11.Location = point
			Me.comboMin19.Name = "comboMin19"
			Dim comboMin12 As Global.System.Windows.Forms.Control = Me.comboMin19
			size = New Global.System.Drawing.Size(40, 21)
			comboMin12.Size = size
			Me.comboMin19.TabIndex = 902
			Me.comboHour19.FormattingEnabled = True
			Me.comboHour19.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" })
			Dim comboHour11 As Global.System.Windows.Forms.Control = Me.comboHour19
			point = New Global.System.Drawing.Point(132, 410)
			comboHour11.Location = point
			Me.comboHour19.Name = "comboHour19"
			Dim comboHour12 As Global.System.Windows.Forms.Control = Me.comboHour19
			size = New Global.System.Drawing.Size(40, 21)
			comboHour12.Size = size
			Me.comboHour19.TabIndex = 901
			Me.chkCon18.AutoSize = True
			Me.chkCon18.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkCon18.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkCon13 As Global.System.Windows.Forms.Control = Me.chkCon18
			point = New Global.System.Drawing.Point(229, 393)
			chkCon13.Location = point
			Me.chkCon18.Name = "chkCon18"
			Dim chkCon14 As Global.System.Windows.Forms.Control = Me.chkCon18
			size = New Global.System.Drawing.Size(15, 14)
			chkCon14.Size = size
			Me.chkCon18.TabIndex = 900
			Me.chkCon18.UseVisualStyleBackColor = False
			Me.btnPlay18.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnPlay18.Image = CType(resources.GetObject("btnPlay18.Image"), Global.System.Drawing.Image)
			Dim btnPlay13 As Global.System.Windows.Forms.Control = Me.btnPlay18
			point = New Global.System.Drawing.Point(756, 389)
			btnPlay13.Location = point
			Me.btnPlay18.Name = "btnPlay18"
			Dim btnPlay14 As Global.System.Windows.Forms.Control = Me.btnPlay18
			size = New Global.System.Drawing.Size(31, 21)
			btnPlay14.Size = size
			Me.btnPlay18.TabIndex = 899
			Me.btnPlay18.UseVisualStyleBackColor = False
			Me.comboMin18.FormattingEnabled = True
			Me.comboMin18.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" })
			Dim comboMin13 As Global.System.Windows.Forms.Control = Me.comboMin18
			point = New Global.System.Drawing.Point(177, 390)
			comboMin13.Location = point
			Me.comboMin18.Name = "comboMin18"
			Dim comboMin14 As Global.System.Windows.Forms.Control = Me.comboMin18
			size = New Global.System.Drawing.Size(40, 21)
			comboMin14.Size = size
			Me.comboMin18.TabIndex = 898
			Me.comboHour18.FormattingEnabled = True
			Me.comboHour18.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" })
			Dim comboHour13 As Global.System.Windows.Forms.Control = Me.comboHour18
			point = New Global.System.Drawing.Point(132, 390)
			comboHour13.Location = point
			Me.comboHour18.Name = "comboHour18"
			Dim comboHour14 As Global.System.Windows.Forms.Control = Me.comboHour18
			size = New Global.System.Drawing.Size(40, 21)
			comboHour14.Size = size
			Me.comboHour18.TabIndex = 897
			Me.chkCon17.AutoSize = True
			Me.chkCon17.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkCon17.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkCon15 As Global.System.Windows.Forms.Control = Me.chkCon17
			point = New Global.System.Drawing.Point(229, 373)
			chkCon15.Location = point
			Me.chkCon17.Name = "chkCon17"
			Dim chkCon16 As Global.System.Windows.Forms.Control = Me.chkCon17
			size = New Global.System.Drawing.Size(15, 14)
			chkCon16.Size = size
			Me.chkCon17.TabIndex = 896
			Me.chkCon17.UseVisualStyleBackColor = False
			Me.btnPlay17.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnPlay17.Image = CType(resources.GetObject("btnPlay17.Image"), Global.System.Drawing.Image)
			Dim btnPlay15 As Global.System.Windows.Forms.Control = Me.btnPlay17
			point = New Global.System.Drawing.Point(756, 369)
			btnPlay15.Location = point
			Me.btnPlay17.Name = "btnPlay17"
			Dim btnPlay16 As Global.System.Windows.Forms.Control = Me.btnPlay17
			size = New Global.System.Drawing.Size(31, 21)
			btnPlay16.Size = size
			Me.btnPlay17.TabIndex = 895
			Me.btnPlay17.UseVisualStyleBackColor = False
			Me.comboMin17.FormattingEnabled = True
			Me.comboMin17.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" })
			Dim comboMin15 As Global.System.Windows.Forms.Control = Me.comboMin17
			point = New Global.System.Drawing.Point(177, 370)
			comboMin15.Location = point
			Me.comboMin17.Name = "comboMin17"
			Dim comboMin16 As Global.System.Windows.Forms.Control = Me.comboMin17
			size = New Global.System.Drawing.Size(40, 21)
			comboMin16.Size = size
			Me.comboMin17.TabIndex = 894
			Me.comboHour17.FormattingEnabled = True
			Me.comboHour17.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" })
			Dim comboHour15 As Global.System.Windows.Forms.Control = Me.comboHour17
			point = New Global.System.Drawing.Point(132, 370)
			comboHour15.Location = point
			Me.comboHour17.Name = "comboHour17"
			Dim comboHour16 As Global.System.Windows.Forms.Control = Me.comboHour17
			size = New Global.System.Drawing.Size(40, 21)
			comboHour16.Size = size
			Me.comboHour17.TabIndex = 893
			Me.lblEng.AutoSize = True
			Me.lblEng.BackColor = Global.System.Drawing.Color.Transparent
			Me.lblEng.ForeColor = Global.System.Drawing.Color.Maroon
			Dim lblEng As Global.System.Windows.Forms.Control = Me.lblEng
			point = New Global.System.Drawing.Point(688, 32)
			lblEng.Location = point
			Me.lblEng.Name = "lblEng"
			Dim lblEng2 As Global.System.Windows.Forms.Control = Me.lblEng
			size = New Global.System.Drawing.Size(26, 13)
			lblEng2.Size = size
			Me.lblEng.TabIndex = 892
			Me.lblEng.Text = "Eng"
			Me.lblThai.AutoSize = True
			Me.lblThai.BackColor = Global.System.Drawing.Color.Transparent
			Me.lblThai.ForeColor = Global.System.Drawing.Color.Maroon
			Dim lblThai As Global.System.Windows.Forms.Control = Me.lblThai
			point = New Global.System.Drawing.Point(444, 32)
			lblThai.Location = point
			Me.lblThai.Name = "lblThai"
			Dim lblThai2 As Global.System.Windows.Forms.Control = Me.lblThai
			size = New Global.System.Drawing.Size(28, 13)
			lblThai2.Size = size
			Me.lblThai.TabIndex = 891
			Me.lblThai.Text = "Thai"
			Me.PictureBox3.BackColor = Global.System.Drawing.Color.Transparent
			Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), Global.System.Drawing.Image)
			Dim pictureBox3 As Global.System.Windows.Forms.Control = Me.PictureBox3
			point = New Global.System.Drawing.Point(734, 3)
			pictureBox3.Location = point
			Me.PictureBox3.Name = "PictureBox3"
			Dim pictureBox4 As Global.System.Windows.Forms.Control = Me.PictureBox3
			size = New Global.System.Drawing.Size(32, 28)
			pictureBox4.Size = size
			Me.PictureBox3.TabIndex = 890
			Me.PictureBox3.TabStop = False
			Me.PictureBox2.BackColor = Global.System.Drawing.Color.Transparent
			Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), Global.System.Drawing.Image)
			Dim pictureBox5 As Global.System.Windows.Forms.Control = Me.PictureBox2
			point = New Global.System.Drawing.Point(15, 3)
			pictureBox5.Location = point
			Me.PictureBox2.Name = "PictureBox2"
			Dim pictureBox6 As Global.System.Windows.Forms.Control = Me.PictureBox2
			size = New Global.System.Drawing.Size(32, 28)
			pictureBox6.Size = size
			Me.PictureBox2.TabIndex = 889
			Me.PictureBox2.TabStop = False
			Me.lbl14.AutoSize = True
			Me.lbl14.BackColor = Global.System.Drawing.Color.Transparent
			Me.lbl14.ForeColor = Global.System.Drawing.Color.Black
			Dim lbl17 As Global.System.Windows.Forms.Control = Me.lbl14
			point = New Global.System.Drawing.Point(50, 314)
			lbl17.Location = point
			Me.lbl14.Name = "lbl14"
			Dim lbl18 As Global.System.Windows.Forms.Control = Me.lbl14
			size = New Global.System.Drawing.Size(45, 13)
			lbl18.Size = size
			Me.lbl14.TabIndex = 888
			Me.lbl14.Text = "Label14"
			Me.lbl15.AutoSize = True
			Me.lbl15.BackColor = Global.System.Drawing.Color.Transparent
			Me.lbl15.ForeColor = Global.System.Drawing.Color.Black
			Dim lbl19 As Global.System.Windows.Forms.Control = Me.lbl15
			point = New Global.System.Drawing.Point(50, 334)
			lbl19.Location = point
			Me.lbl15.Name = "lbl15"
			Dim lbl20 As Global.System.Windows.Forms.Control = Me.lbl15
			size = New Global.System.Drawing.Size(45, 13)
			lbl20.Size = size
			Me.lbl15.TabIndex = 887
			Me.lbl15.Text = "Label15"
			Me.lbl16.AutoSize = True
			Me.lbl16.BackColor = Global.System.Drawing.Color.Transparent
			Me.lbl16.ForeColor = Global.System.Drawing.Color.Black
			Dim lbl21 As Global.System.Windows.Forms.Control = Me.lbl16
			point = New Global.System.Drawing.Point(50, 354)
			lbl21.Location = point
			Me.lbl16.Name = "lbl16"
			Dim lbl22 As Global.System.Windows.Forms.Control = Me.lbl16
			size = New Global.System.Drawing.Size(45, 13)
			lbl22.Size = size
			Me.lbl16.TabIndex = 886
			Me.lbl16.Text = "Label16"
			Me.lbl09.AutoSize = True
			Me.lbl09.BackColor = Global.System.Drawing.Color.Transparent
			Me.lbl09.ForeColor = Global.System.Drawing.Color.Black
			Dim lbl23 As Global.System.Windows.Forms.Control = Me.lbl09
			point = New Global.System.Drawing.Point(50, 214)
			lbl23.Location = point
			Me.lbl09.Name = "lbl09"
			Dim lbl24 As Global.System.Windows.Forms.Control = Me.lbl09
			size = New Global.System.Drawing.Size(39, 13)
			lbl24.Size = size
			Me.lbl09.TabIndex = 885
			Me.lbl09.Text = "Label9"
			Me.lbl10.AutoSize = True
			Me.lbl10.BackColor = Global.System.Drawing.Color.Transparent
			Me.lbl10.ForeColor = Global.System.Drawing.Color.Black
			Dim lbl25 As Global.System.Windows.Forms.Control = Me.lbl10
			point = New Global.System.Drawing.Point(50, 234)
			lbl25.Location = point
			Me.lbl10.Name = "lbl10"
			Dim lbl26 As Global.System.Windows.Forms.Control = Me.lbl10
			size = New Global.System.Drawing.Size(45, 13)
			lbl26.Size = size
			Me.lbl10.TabIndex = 884
			Me.lbl10.Text = "Label10"
			Me.lbl11.AutoSize = True
			Me.lbl11.BackColor = Global.System.Drawing.Color.Transparent
			Me.lbl11.ForeColor = Global.System.Drawing.Color.Black
			Dim lbl27 As Global.System.Windows.Forms.Control = Me.lbl11
			point = New Global.System.Drawing.Point(50, 253)
			lbl27.Location = point
			Me.lbl11.Name = "lbl11"
			Dim lbl28 As Global.System.Windows.Forms.Control = Me.lbl11
			size = New Global.System.Drawing.Size(45, 13)
			lbl28.Size = size
			Me.lbl11.TabIndex = 883
			Me.lbl11.Text = "Label11"
			Me.lbl12.AutoSize = True
			Me.lbl12.BackColor = Global.System.Drawing.Color.Transparent
			Me.lbl12.ForeColor = Global.System.Drawing.Color.Black
			Dim lbl29 As Global.System.Windows.Forms.Control = Me.lbl12
			point = New Global.System.Drawing.Point(50, 274)
			lbl29.Location = point
			Me.lbl12.Name = "lbl12"
			Dim lbl30 As Global.System.Windows.Forms.Control = Me.lbl12
			size = New Global.System.Drawing.Size(45, 13)
			lbl30.Size = size
			Me.lbl12.TabIndex = 882
			Me.lbl12.Text = "Label12"
			Me.lbl13.AutoSize = True
			Me.lbl13.BackColor = Global.System.Drawing.Color.Transparent
			Me.lbl13.ForeColor = Global.System.Drawing.Color.Black
			Dim lbl31 As Global.System.Windows.Forms.Control = Me.lbl13
			point = New Global.System.Drawing.Point(50, 294)
			lbl31.Location = point
			Me.lbl13.Name = "lbl13"
			Dim lbl32 As Global.System.Windows.Forms.Control = Me.lbl13
			size = New Global.System.Drawing.Size(45, 13)
			lbl32.Size = size
			Me.lbl13.TabIndex = 881
			Me.lbl13.Text = "Label13"
			Me.lbl06.AutoSize = True
			Me.lbl06.BackColor = Global.System.Drawing.Color.Transparent
			Me.lbl06.ForeColor = Global.System.Drawing.Color.Black
			Dim lbl33 As Global.System.Windows.Forms.Control = Me.lbl06
			point = New Global.System.Drawing.Point(50, 154)
			lbl33.Location = point
			Me.lbl06.Name = "lbl06"
			Dim lbl34 As Global.System.Windows.Forms.Control = Me.lbl06
			size = New Global.System.Drawing.Size(39, 13)
			lbl34.Size = size
			Me.lbl06.TabIndex = 880
			Me.lbl06.Text = "Label6"
			Me.lbl07.AutoSize = True
			Me.lbl07.BackColor = Global.System.Drawing.Color.Transparent
			Me.lbl07.ForeColor = Global.System.Drawing.Color.Black
			Dim lbl35 As Global.System.Windows.Forms.Control = Me.lbl07
			point = New Global.System.Drawing.Point(50, 174)
			lbl35.Location = point
			Me.lbl07.Name = "lbl07"
			Dim lbl36 As Global.System.Windows.Forms.Control = Me.lbl07
			size = New Global.System.Drawing.Size(39, 13)
			lbl36.Size = size
			Me.lbl07.TabIndex = 879
			Me.lbl07.Text = "Label7"
			Me.lbl08.AutoSize = True
			Me.lbl08.BackColor = Global.System.Drawing.Color.Transparent
			Me.lbl08.ForeColor = Global.System.Drawing.Color.Black
			Dim lbl37 As Global.System.Windows.Forms.Control = Me.lbl08
			point = New Global.System.Drawing.Point(50, 194)
			lbl37.Location = point
			Me.lbl08.Name = "lbl08"
			Dim lbl38 As Global.System.Windows.Forms.Control = Me.lbl08
			size = New Global.System.Drawing.Size(39, 13)
			lbl38.Size = size
			Me.lbl08.TabIndex = 878
			Me.lbl08.Text = "Label8"
			Me.lbl05.AutoSize = True
			Me.lbl05.BackColor = Global.System.Drawing.Color.Transparent
			Me.lbl05.ForeColor = Global.System.Drawing.Color.Black
			Dim lbl39 As Global.System.Windows.Forms.Control = Me.lbl05
			point = New Global.System.Drawing.Point(50, 135)
			lbl39.Location = point
			Me.lbl05.Name = "lbl05"
			Dim lbl40 As Global.System.Windows.Forms.Control = Me.lbl05
			size = New Global.System.Drawing.Size(39, 13)
			lbl40.Size = size
			Me.lbl05.TabIndex = 877
			Me.lbl05.Text = "Label5"
			Me.lbl04.AutoSize = True
			Me.lbl04.BackColor = Global.System.Drawing.Color.Transparent
			Me.lbl04.ForeColor = Global.System.Drawing.Color.Black
			Dim lbl41 As Global.System.Windows.Forms.Control = Me.lbl04
			point = New Global.System.Drawing.Point(50, 114)
			lbl41.Location = point
			Me.lbl04.Name = "lbl04"
			Dim lbl42 As Global.System.Windows.Forms.Control = Me.lbl04
			size = New Global.System.Drawing.Size(39, 13)
			lbl42.Size = size
			Me.lbl04.TabIndex = 876
			Me.lbl04.Text = "Label4"
			Me.lbl03.AutoSize = True
			Me.lbl03.BackColor = Global.System.Drawing.Color.Transparent
			Me.lbl03.ForeColor = Global.System.Drawing.Color.Black
			Dim lbl43 As Global.System.Windows.Forms.Control = Me.lbl03
			point = New Global.System.Drawing.Point(50, 94)
			lbl43.Location = point
			Me.lbl03.Name = "lbl03"
			Dim lbl44 As Global.System.Windows.Forms.Control = Me.lbl03
			size = New Global.System.Drawing.Size(39, 13)
			lbl44.Size = size
			Me.lbl03.TabIndex = 875
			Me.lbl03.Text = "Label3"
			Me.lbl02.AutoSize = True
			Me.lbl02.BackColor = Global.System.Drawing.Color.Transparent
			Me.lbl02.ForeColor = Global.System.Drawing.Color.Black
			Dim lbl45 As Global.System.Windows.Forms.Control = Me.lbl02
			point = New Global.System.Drawing.Point(50, 75)
			lbl45.Location = point
			Me.lbl02.Name = "lbl02"
			Dim lbl46 As Global.System.Windows.Forms.Control = Me.lbl02
			size = New Global.System.Drawing.Size(39, 13)
			lbl46.Size = size
			Me.lbl02.TabIndex = 874
			Me.lbl02.Text = "Label2"
			Me.lbl01.AutoSize = True
			Me.lbl01.BackColor = Global.System.Drawing.Color.Transparent
			Me.lbl01.ForeColor = Global.System.Drawing.Color.Black
			Dim lbl47 As Global.System.Windows.Forms.Control = Me.lbl01
			point = New Global.System.Drawing.Point(50, 55)
			lbl47.Location = point
			Me.lbl01.Name = "lbl01"
			Dim lbl48 As Global.System.Windows.Forms.Control = Me.lbl01
			size = New Global.System.Drawing.Size(39, 13)
			lbl48.Size = size
			Me.lbl01.TabIndex = 873
			Me.lbl01.Text = "Label1"
			Me.chkFirst16.AutoSize = True
			Me.chkFirst16.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkFirst16.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkFirst17 As Global.System.Windows.Forms.Control = Me.chkFirst16
			point = New Global.System.Drawing.Point(31, 354)
			chkFirst17.Location = point
			Me.chkFirst16.Name = "chkFirst16"
			Dim chkFirst18 As Global.System.Windows.Forms.Control = Me.chkFirst16
			size = New Global.System.Drawing.Size(15, 14)
			chkFirst18.Size = size
			Me.chkFirst16.TabIndex = 872
			Me.chkFirst16.UseVisualStyleBackColor = False
			Me.chkLast16.AutoSize = True
			Me.chkLast16.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkLast16.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkLast17 As Global.System.Windows.Forms.Control = Me.chkLast16
			point = New Global.System.Drawing.Point(735, 354)
			chkLast17.Location = point
			Me.chkLast16.Name = "chkLast16"
			Dim chkLast18 As Global.System.Windows.Forms.Control = Me.chkLast16
			size = New Global.System.Drawing.Size(15, 14)
			chkLast18.Size = size
			Me.chkLast16.TabIndex = 871
			Me.chkLast16.UseVisualStyleBackColor = False
			Me.chkTime16.AutoSize = True
			Me.chkTime16.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkTime16.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkTime17 As Global.System.Windows.Forms.Control = Me.chkTime16
			point = New Global.System.Drawing.Point(110, 354)
			chkTime17.Location = point
			Me.chkTime16.Name = "chkTime16"
			Dim chkTime18 As Global.System.Windows.Forms.Control = Me.chkTime16
			size = New Global.System.Drawing.Size(15, 14)
			chkTime18.Size = size
			Me.chkTime16.TabIndex = 870
			Me.chkTime16.UseVisualStyleBackColor = False
			Me.comboSoundConEng16.FormattingEnabled = True
			Dim comboSoundConEng17 As Global.System.Windows.Forms.Control = Me.comboSoundConEng16
			point = New Global.System.Drawing.Point(488, 351)
			comboSoundConEng17.Location = point
			Me.comboSoundConEng16.Name = "comboSoundConEng16"
			Dim comboSoundConEng18 As Global.System.Windows.Forms.Control = Me.comboSoundConEng16
			size = New Global.System.Drawing.Size(238, 21)
			comboSoundConEng18.Size = size
			Me.comboSoundConEng16.TabIndex = 869
			Me.comboSoundCon16.FormattingEnabled = True
			Dim comboSoundCon17 As Global.System.Windows.Forms.Control = Me.comboSoundCon16
			point = New Global.System.Drawing.Point(250, 351)
			comboSoundCon17.Location = point
			Me.comboSoundCon16.Name = "comboSoundCon16"
			Dim comboSoundCon18 As Global.System.Windows.Forms.Control = Me.comboSoundCon16
			size = New Global.System.Drawing.Size(232, 21)
			comboSoundCon18.Size = size
			Me.comboSoundCon16.TabIndex = 868
			Me.chkCon16.AutoSize = True
			Me.chkCon16.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkCon16.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkCon17 As Global.System.Windows.Forms.Control = Me.chkCon16
			point = New Global.System.Drawing.Point(229, 354)
			chkCon17.Location = point
			Me.chkCon16.Name = "chkCon16"
			Dim chkCon18 As Global.System.Windows.Forms.Control = Me.chkCon16
			size = New Global.System.Drawing.Size(15, 14)
			chkCon18.Size = size
			Me.chkCon16.TabIndex = 867
			Me.chkCon16.UseVisualStyleBackColor = False
			Me.btnPlay16.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnPlay16.Image = CType(resources.GetObject("btnPlay16.Image"), Global.System.Drawing.Image)
			Dim btnPlay17 As Global.System.Windows.Forms.Control = Me.btnPlay16
			point = New Global.System.Drawing.Point(756, 349)
			btnPlay17.Location = point
			Me.btnPlay16.Name = "btnPlay16"
			Dim btnPlay18 As Global.System.Windows.Forms.Control = Me.btnPlay16
			size = New Global.System.Drawing.Size(31, 21)
			btnPlay18.Size = size
			Me.btnPlay16.TabIndex = 866
			Me.btnPlay16.UseVisualStyleBackColor = False
			Me.comboMin16.FormattingEnabled = True
			Me.comboMin16.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" })
			Dim comboMin17 As Global.System.Windows.Forms.Control = Me.comboMin16
			point = New Global.System.Drawing.Point(177, 350)
			comboMin17.Location = point
			Me.comboMin16.Name = "comboMin16"
			Dim comboMin18 As Global.System.Windows.Forms.Control = Me.comboMin16
			size = New Global.System.Drawing.Size(40, 21)
			comboMin18.Size = size
			Me.comboMin16.TabIndex = 865
			Me.comboHour16.FormattingEnabled = True
			Me.comboHour16.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" })
			Dim comboHour17 As Global.System.Windows.Forms.Control = Me.comboHour16
			point = New Global.System.Drawing.Point(132, 350)
			comboHour17.Location = point
			Me.comboHour16.Name = "comboHour16"
			Dim comboHour18 As Global.System.Windows.Forms.Control = Me.comboHour16
			size = New Global.System.Drawing.Size(40, 21)
			comboHour18.Size = size
			Me.comboHour16.TabIndex = 864
			Me.chkFirst15.AutoSize = True
			Me.chkFirst15.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkFirst15.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkFirst19 As Global.System.Windows.Forms.Control = Me.chkFirst15
			point = New Global.System.Drawing.Point(31, 334)
			chkFirst19.Location = point
			Me.chkFirst15.Name = "chkFirst15"
			Dim chkFirst20 As Global.System.Windows.Forms.Control = Me.chkFirst15
			size = New Global.System.Drawing.Size(15, 14)
			chkFirst20.Size = size
			Me.chkFirst15.TabIndex = 863
			Me.chkFirst15.UseVisualStyleBackColor = False
			Me.chkFirst14.AutoSize = True
			Me.chkFirst14.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkFirst14.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkFirst21 As Global.System.Windows.Forms.Control = Me.chkFirst14
			point = New Global.System.Drawing.Point(31, 314)
			chkFirst21.Location = point
			Me.chkFirst14.Name = "chkFirst14"
			Dim chkFirst22 As Global.System.Windows.Forms.Control = Me.chkFirst14
			size = New Global.System.Drawing.Size(15, 14)
			chkFirst22.Size = size
			Me.chkFirst14.TabIndex = 862
			Me.chkFirst14.UseVisualStyleBackColor = False
			Me.chkFirst13.AutoSize = True
			Me.chkFirst13.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkFirst13.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkFirst23 As Global.System.Windows.Forms.Control = Me.chkFirst13
			point = New Global.System.Drawing.Point(31, 294)
			chkFirst23.Location = point
			Me.chkFirst13.Name = "chkFirst13"
			Dim chkFirst24 As Global.System.Windows.Forms.Control = Me.chkFirst13
			size = New Global.System.Drawing.Size(15, 14)
			chkFirst24.Size = size
			Me.chkFirst13.TabIndex = 861
			Me.chkFirst13.UseVisualStyleBackColor = False
			Me.chkLast15.AutoSize = True
			Me.chkLast15.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkLast15.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkLast19 As Global.System.Windows.Forms.Control = Me.chkLast15
			point = New Global.System.Drawing.Point(735, 334)
			chkLast19.Location = point
			Me.chkLast15.Name = "chkLast15"
			Dim chkLast20 As Global.System.Windows.Forms.Control = Me.chkLast15
			size = New Global.System.Drawing.Size(15, 14)
			chkLast20.Size = size
			Me.chkLast15.TabIndex = 860
			Me.chkLast15.UseVisualStyleBackColor = False
			Me.chkLast14.AutoSize = True
			Me.chkLast14.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkLast14.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkLast21 As Global.System.Windows.Forms.Control = Me.chkLast14
			point = New Global.System.Drawing.Point(735, 314)
			chkLast21.Location = point
			Me.chkLast14.Name = "chkLast14"
			Dim chkLast22 As Global.System.Windows.Forms.Control = Me.chkLast14
			size = New Global.System.Drawing.Size(15, 14)
			chkLast22.Size = size
			Me.chkLast14.TabIndex = 859
			Me.chkLast14.UseVisualStyleBackColor = False
			Me.chkLast13.AutoSize = True
			Me.chkLast13.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkLast13.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkLast23 As Global.System.Windows.Forms.Control = Me.chkLast13
			point = New Global.System.Drawing.Point(735, 294)
			chkLast23.Location = point
			Me.chkLast13.Name = "chkLast13"
			Dim chkLast24 As Global.System.Windows.Forms.Control = Me.chkLast13
			size = New Global.System.Drawing.Size(15, 14)
			chkLast24.Size = size
			Me.chkLast13.TabIndex = 858
			Me.chkLast13.UseVisualStyleBackColor = False
			Me.chkTime15.AutoSize = True
			Me.chkTime15.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkTime15.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkTime19 As Global.System.Windows.Forms.Control = Me.chkTime15
			point = New Global.System.Drawing.Point(110, 334)
			chkTime19.Location = point
			Me.chkTime15.Name = "chkTime15"
			Dim chkTime20 As Global.System.Windows.Forms.Control = Me.chkTime15
			size = New Global.System.Drawing.Size(15, 14)
			chkTime20.Size = size
			Me.chkTime15.TabIndex = 857
			Me.chkTime15.UseVisualStyleBackColor = False
			Me.chkTime14.AutoSize = True
			Me.chkTime14.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkTime14.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkTime21 As Global.System.Windows.Forms.Control = Me.chkTime14
			point = New Global.System.Drawing.Point(110, 314)
			chkTime21.Location = point
			Me.chkTime14.Name = "chkTime14"
			Dim chkTime22 As Global.System.Windows.Forms.Control = Me.chkTime14
			size = New Global.System.Drawing.Size(15, 14)
			chkTime22.Size = size
			Me.chkTime14.TabIndex = 856
			Me.chkTime14.UseVisualStyleBackColor = False
			Me.chkTime13.AutoSize = True
			Me.chkTime13.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkTime13.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkTime23 As Global.System.Windows.Forms.Control = Me.chkTime13
			point = New Global.System.Drawing.Point(110, 294)
			chkTime23.Location = point
			Me.chkTime13.Name = "chkTime13"
			Dim chkTime24 As Global.System.Windows.Forms.Control = Me.chkTime13
			size = New Global.System.Drawing.Size(15, 14)
			chkTime24.Size = size
			Me.chkTime13.TabIndex = 855
			Me.chkTime13.UseVisualStyleBackColor = False
			Me.comboSoundConEng15.FormattingEnabled = True
			Dim comboSoundConEng19 As Global.System.Windows.Forms.Control = Me.comboSoundConEng15
			point = New Global.System.Drawing.Point(488, 331)
			comboSoundConEng19.Location = point
			Me.comboSoundConEng15.Name = "comboSoundConEng15"
			Dim comboSoundConEng20 As Global.System.Windows.Forms.Control = Me.comboSoundConEng15
			size = New Global.System.Drawing.Size(238, 21)
			comboSoundConEng20.Size = size
			Me.comboSoundConEng15.TabIndex = 854
			Me.comboSoundConEng14.FormattingEnabled = True
			Dim comboSoundConEng21 As Global.System.Windows.Forms.Control = Me.comboSoundConEng14
			point = New Global.System.Drawing.Point(488, 311)
			comboSoundConEng21.Location = point
			Me.comboSoundConEng14.Name = "comboSoundConEng14"
			Dim comboSoundConEng22 As Global.System.Windows.Forms.Control = Me.comboSoundConEng14
			size = New Global.System.Drawing.Size(238, 21)
			comboSoundConEng22.Size = size
			Me.comboSoundConEng14.TabIndex = 853
			Me.comboSoundConEng13.FormattingEnabled = True
			Dim comboSoundConEng23 As Global.System.Windows.Forms.Control = Me.comboSoundConEng13
			point = New Global.System.Drawing.Point(488, 291)
			comboSoundConEng23.Location = point
			Me.comboSoundConEng13.Name = "comboSoundConEng13"
			Dim comboSoundConEng24 As Global.System.Windows.Forms.Control = Me.comboSoundConEng13
			size = New Global.System.Drawing.Size(238, 21)
			comboSoundConEng24.Size = size
			Me.comboSoundConEng13.TabIndex = 852
			Me.comboSoundCon15.FormattingEnabled = True
			Dim comboSoundCon19 As Global.System.Windows.Forms.Control = Me.comboSoundCon15
			point = New Global.System.Drawing.Point(250, 331)
			comboSoundCon19.Location = point
			Me.comboSoundCon15.Name = "comboSoundCon15"
			Dim comboSoundCon20 As Global.System.Windows.Forms.Control = Me.comboSoundCon15
			size = New Global.System.Drawing.Size(232, 21)
			comboSoundCon20.Size = size
			Me.comboSoundCon15.TabIndex = 851
			Me.comboSoundCon14.FormattingEnabled = True
			Dim comboSoundCon21 As Global.System.Windows.Forms.Control = Me.comboSoundCon14
			point = New Global.System.Drawing.Point(250, 311)
			comboSoundCon21.Location = point
			Me.comboSoundCon14.Name = "comboSoundCon14"
			Dim comboSoundCon22 As Global.System.Windows.Forms.Control = Me.comboSoundCon14
			size = New Global.System.Drawing.Size(232, 21)
			comboSoundCon22.Size = size
			Me.comboSoundCon14.TabIndex = 850
			Me.comboSoundCon13.FormattingEnabled = True
			Dim comboSoundCon23 As Global.System.Windows.Forms.Control = Me.comboSoundCon13
			point = New Global.System.Drawing.Point(250, 291)
			comboSoundCon23.Location = point
			Me.comboSoundCon13.Name = "comboSoundCon13"
			Dim comboSoundCon24 As Global.System.Windows.Forms.Control = Me.comboSoundCon13
			size = New Global.System.Drawing.Size(232, 21)
			comboSoundCon24.Size = size
			Me.comboSoundCon13.TabIndex = 849
			Me.chkCon15.AutoSize = True
			Me.chkCon15.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkCon15.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkCon19 As Global.System.Windows.Forms.Control = Me.chkCon15
			point = New Global.System.Drawing.Point(229, 334)
			chkCon19.Location = point
			Me.chkCon15.Name = "chkCon15"
			Dim chkCon20 As Global.System.Windows.Forms.Control = Me.chkCon15
			size = New Global.System.Drawing.Size(15, 14)
			chkCon20.Size = size
			Me.chkCon15.TabIndex = 848
			Me.chkCon15.UseVisualStyleBackColor = False
			Me.btnPlay15.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnPlay15.Image = CType(resources.GetObject("btnPlay15.Image"), Global.System.Drawing.Image)
			Dim btnPlay19 As Global.System.Windows.Forms.Control = Me.btnPlay15
			point = New Global.System.Drawing.Point(756, 330)
			btnPlay19.Location = point
			Me.btnPlay15.Name = "btnPlay15"
			Dim btnPlay20 As Global.System.Windows.Forms.Control = Me.btnPlay15
			size = New Global.System.Drawing.Size(31, 21)
			btnPlay20.Size = size
			Me.btnPlay15.TabIndex = 847
			Me.btnPlay15.UseVisualStyleBackColor = False
			Me.comboMin15.FormattingEnabled = True
			Me.comboMin15.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" })
			Dim comboMin19 As Global.System.Windows.Forms.Control = Me.comboMin15
			point = New Global.System.Drawing.Point(177, 331)
			comboMin19.Location = point
			Me.comboMin15.Name = "comboMin15"
			Dim comboMin20 As Global.System.Windows.Forms.Control = Me.comboMin15
			size = New Global.System.Drawing.Size(40, 21)
			comboMin20.Size = size
			Me.comboMin15.TabIndex = 846
			Me.comboHour15.FormattingEnabled = True
			Me.comboHour15.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" })
			Dim comboHour19 As Global.System.Windows.Forms.Control = Me.comboHour15
			point = New Global.System.Drawing.Point(132, 331)
			comboHour19.Location = point
			Me.comboHour15.Name = "comboHour15"
			Dim comboHour20 As Global.System.Windows.Forms.Control = Me.comboHour15
			size = New Global.System.Drawing.Size(40, 21)
			comboHour20.Size = size
			Me.comboHour15.TabIndex = 845
			Me.chkCon14.AutoSize = True
			Me.chkCon14.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkCon14.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkCon21 As Global.System.Windows.Forms.Control = Me.chkCon14
			point = New Global.System.Drawing.Point(229, 314)
			chkCon21.Location = point
			Me.chkCon14.Name = "chkCon14"
			Dim chkCon22 As Global.System.Windows.Forms.Control = Me.chkCon14
			size = New Global.System.Drawing.Size(15, 14)
			chkCon22.Size = size
			Me.chkCon14.TabIndex = 844
			Me.chkCon14.UseVisualStyleBackColor = False
			Me.btnPlay14.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnPlay14.Image = CType(resources.GetObject("btnPlay14.Image"), Global.System.Drawing.Image)
			Dim btnPlay21 As Global.System.Windows.Forms.Control = Me.btnPlay14
			point = New Global.System.Drawing.Point(756, 309)
			btnPlay21.Location = point
			Me.btnPlay14.Name = "btnPlay14"
			Dim btnPlay22 As Global.System.Windows.Forms.Control = Me.btnPlay14
			size = New Global.System.Drawing.Size(31, 22)
			btnPlay22.Size = size
			Me.btnPlay14.TabIndex = 843
			Me.btnPlay14.UseVisualStyleBackColor = False
			Me.comboMin14.FormattingEnabled = True
			Me.comboMin14.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" })
			Dim comboMin21 As Global.System.Windows.Forms.Control = Me.comboMin14
			point = New Global.System.Drawing.Point(177, 311)
			comboMin21.Location = point
			Me.comboMin14.Name = "comboMin14"
			Dim comboMin22 As Global.System.Windows.Forms.Control = Me.comboMin14
			size = New Global.System.Drawing.Size(40, 21)
			comboMin22.Size = size
			Me.comboMin14.TabIndex = 842
			Me.comboHour14.FormattingEnabled = True
			Me.comboHour14.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" })
			Dim comboHour21 As Global.System.Windows.Forms.Control = Me.comboHour14
			point = New Global.System.Drawing.Point(132, 311)
			comboHour21.Location = point
			Me.comboHour14.Name = "comboHour14"
			Dim comboHour22 As Global.System.Windows.Forms.Control = Me.comboHour14
			size = New Global.System.Drawing.Size(40, 21)
			comboHour22.Size = size
			Me.comboHour14.TabIndex = 841
			Me.chkCon13.AutoSize = True
			Me.chkCon13.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkCon13.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkCon23 As Global.System.Windows.Forms.Control = Me.chkCon13
			point = New Global.System.Drawing.Point(229, 294)
			chkCon23.Location = point
			Me.chkCon13.Name = "chkCon13"
			Dim chkCon24 As Global.System.Windows.Forms.Control = Me.chkCon13
			size = New Global.System.Drawing.Size(15, 14)
			chkCon24.Size = size
			Me.chkCon13.TabIndex = 840
			Me.chkCon13.UseVisualStyleBackColor = False
			Me.btnPlay13.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnPlay13.Image = CType(resources.GetObject("btnPlay13.Image"), Global.System.Drawing.Image)
			Dim btnPlay23 As Global.System.Windows.Forms.Control = Me.btnPlay13
			point = New Global.System.Drawing.Point(756, 290)
			btnPlay23.Location = point
			Me.btnPlay13.Name = "btnPlay13"
			Dim btnPlay24 As Global.System.Windows.Forms.Control = Me.btnPlay13
			size = New Global.System.Drawing.Size(31, 21)
			btnPlay24.Size = size
			Me.btnPlay13.TabIndex = 839
			Me.btnPlay13.UseVisualStyleBackColor = False
			Me.comboMin13.FormattingEnabled = True
			Me.comboMin13.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" })
			Dim comboMin23 As Global.System.Windows.Forms.Control = Me.comboMin13
			point = New Global.System.Drawing.Point(177, 291)
			comboMin23.Location = point
			Me.comboMin13.Name = "comboMin13"
			Dim comboMin24 As Global.System.Windows.Forms.Control = Me.comboMin13
			size = New Global.System.Drawing.Size(40, 21)
			comboMin24.Size = size
			Me.comboMin13.TabIndex = 838
			Me.comboHour13.FormattingEnabled = True
			Me.comboHour13.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" })
			Dim comboHour23 As Global.System.Windows.Forms.Control = Me.comboHour13
			point = New Global.System.Drawing.Point(132, 291)
			comboHour23.Location = point
			Me.comboHour13.Name = "comboHour13"
			Dim comboHour24 As Global.System.Windows.Forms.Control = Me.comboHour13
			size = New Global.System.Drawing.Size(40, 21)
			comboHour24.Size = size
			Me.comboHour13.TabIndex = 837
			Me.chkFirst12.AutoSize = True
			Me.chkFirst12.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkFirst12.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkFirst25 As Global.System.Windows.Forms.Control = Me.chkFirst12
			point = New Global.System.Drawing.Point(31, 274)
			chkFirst25.Location = point
			Me.chkFirst12.Name = "chkFirst12"
			Dim chkFirst26 As Global.System.Windows.Forms.Control = Me.chkFirst12
			size = New Global.System.Drawing.Size(15, 14)
			chkFirst26.Size = size
			Me.chkFirst12.TabIndex = 836
			Me.chkFirst12.UseVisualStyleBackColor = False
			Me.chkFirst11.AutoSize = True
			Me.chkFirst11.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkFirst11.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkFirst27 As Global.System.Windows.Forms.Control = Me.chkFirst11
			point = New Global.System.Drawing.Point(31, 254)
			chkFirst27.Location = point
			Me.chkFirst11.Name = "chkFirst11"
			Dim chkFirst28 As Global.System.Windows.Forms.Control = Me.chkFirst11
			size = New Global.System.Drawing.Size(15, 14)
			chkFirst28.Size = size
			Me.chkFirst11.TabIndex = 835
			Me.chkFirst11.UseVisualStyleBackColor = False
			Me.chkFirst10.AutoSize = True
			Me.chkFirst10.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkFirst10.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkFirst29 As Global.System.Windows.Forms.Control = Me.chkFirst10
			point = New Global.System.Drawing.Point(31, 234)
			chkFirst29.Location = point
			Me.chkFirst10.Name = "chkFirst10"
			Dim chkFirst30 As Global.System.Windows.Forms.Control = Me.chkFirst10
			size = New Global.System.Drawing.Size(15, 14)
			chkFirst30.Size = size
			Me.chkFirst10.TabIndex = 834
			Me.chkFirst10.UseVisualStyleBackColor = False
			Me.chkFirst9.AutoSize = True
			Me.chkFirst9.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkFirst9.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkFirst31 As Global.System.Windows.Forms.Control = Me.chkFirst9
			point = New Global.System.Drawing.Point(31, 214)
			chkFirst31.Location = point
			Me.chkFirst9.Name = "chkFirst9"
			Dim chkFirst32 As Global.System.Windows.Forms.Control = Me.chkFirst9
			size = New Global.System.Drawing.Size(15, 14)
			chkFirst32.Size = size
			Me.chkFirst9.TabIndex = 833
			Me.chkFirst9.UseVisualStyleBackColor = False
			Me.chkFirst8.AutoSize = True
			Me.chkFirst8.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkFirst8.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkFirst33 As Global.System.Windows.Forms.Control = Me.chkFirst8
			point = New Global.System.Drawing.Point(31, 194)
			chkFirst33.Location = point
			Me.chkFirst8.Name = "chkFirst8"
			Dim chkFirst34 As Global.System.Windows.Forms.Control = Me.chkFirst8
			size = New Global.System.Drawing.Size(15, 14)
			chkFirst34.Size = size
			Me.chkFirst8.TabIndex = 832
			Me.chkFirst8.UseVisualStyleBackColor = False
			Me.chkFirst7.AutoSize = True
			Me.chkFirst7.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkFirst7.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkFirst35 As Global.System.Windows.Forms.Control = Me.chkFirst7
			point = New Global.System.Drawing.Point(31, 174)
			chkFirst35.Location = point
			Me.chkFirst7.Name = "chkFirst7"
			Dim chkFirst36 As Global.System.Windows.Forms.Control = Me.chkFirst7
			size = New Global.System.Drawing.Size(15, 14)
			chkFirst36.Size = size
			Me.chkFirst7.TabIndex = 831
			Me.chkFirst7.UseVisualStyleBackColor = False
			Me.chkFirst6.AutoSize = True
			Me.chkFirst6.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkFirst6.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkFirst37 As Global.System.Windows.Forms.Control = Me.chkFirst6
			point = New Global.System.Drawing.Point(31, 154)
			chkFirst37.Location = point
			Me.chkFirst6.Name = "chkFirst6"
			Dim chkFirst38 As Global.System.Windows.Forms.Control = Me.chkFirst6
			size = New Global.System.Drawing.Size(15, 14)
			chkFirst38.Size = size
			Me.chkFirst6.TabIndex = 830
			Me.chkFirst6.UseVisualStyleBackColor = False
			Me.chkFirst5.AutoSize = True
			Me.chkFirst5.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkFirst5.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkFirst39 As Global.System.Windows.Forms.Control = Me.chkFirst5
			point = New Global.System.Drawing.Point(31, 134)
			chkFirst39.Location = point
			Me.chkFirst5.Name = "chkFirst5"
			Dim chkFirst40 As Global.System.Windows.Forms.Control = Me.chkFirst5
			size = New Global.System.Drawing.Size(15, 14)
			chkFirst40.Size = size
			Me.chkFirst5.TabIndex = 829
			Me.chkFirst5.UseVisualStyleBackColor = False
			Me.chkFirst4.AutoSize = True
			Me.chkFirst4.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkFirst4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkFirst41 As Global.System.Windows.Forms.Control = Me.chkFirst4
			point = New Global.System.Drawing.Point(31, 114)
			chkFirst41.Location = point
			Me.chkFirst4.Name = "chkFirst4"
			Dim chkFirst42 As Global.System.Windows.Forms.Control = Me.chkFirst4
			size = New Global.System.Drawing.Size(15, 14)
			chkFirst42.Size = size
			Me.chkFirst4.TabIndex = 828
			Me.chkFirst4.UseVisualStyleBackColor = False
			Me.chkFirst3.AutoSize = True
			Me.chkFirst3.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkFirst3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkFirst43 As Global.System.Windows.Forms.Control = Me.chkFirst3
			point = New Global.System.Drawing.Point(31, 94)
			chkFirst43.Location = point
			Me.chkFirst3.Name = "chkFirst3"
			Dim chkFirst44 As Global.System.Windows.Forms.Control = Me.chkFirst3
			size = New Global.System.Drawing.Size(15, 14)
			chkFirst44.Size = size
			Me.chkFirst3.TabIndex = 827
			Me.chkFirst3.UseVisualStyleBackColor = False
			Me.chkFirst2.AutoSize = True
			Me.chkFirst2.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkFirst2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkFirst45 As Global.System.Windows.Forms.Control = Me.chkFirst2
			point = New Global.System.Drawing.Point(31, 74)
			chkFirst45.Location = point
			Me.chkFirst2.Name = "chkFirst2"
			Dim chkFirst46 As Global.System.Windows.Forms.Control = Me.chkFirst2
			size = New Global.System.Drawing.Size(15, 14)
			chkFirst46.Size = size
			Me.chkFirst2.TabIndex = 826
			Me.chkFirst2.UseVisualStyleBackColor = False
			Me.chkLastAll.AutoSize = True
			Me.chkLastAll.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkLastAll.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkLastAll As Global.System.Windows.Forms.Control = Me.chkLastAll
			point = New Global.System.Drawing.Point(735, 34)
			chkLastAll.Location = point
			Me.chkLastAll.Name = "chkLastAll"
			Dim chkLastAll2 As Global.System.Windows.Forms.Control = Me.chkLastAll
			size = New Global.System.Drawing.Size(15, 14)
			chkLastAll2.Size = size
			Me.chkLastAll.TabIndex = 825
			Me.chkLastAll.UseVisualStyleBackColor = False
			Me.chkConAll.AutoSize = True
			Me.chkConAll.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkConAll.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkConAll As Global.System.Windows.Forms.Control = Me.chkConAll
			point = New Global.System.Drawing.Point(229, 34)
			chkConAll.Location = point
			Me.chkConAll.Name = "chkConAll"
			Dim chkConAll2 As Global.System.Windows.Forms.Control = Me.chkConAll
			size = New Global.System.Drawing.Size(15, 14)
			chkConAll2.Size = size
			Me.chkConAll.TabIndex = 825
			Me.chkConAll.UseVisualStyleBackColor = False
			Me.chkTimeAll.AutoSize = True
			Me.chkTimeAll.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkTimeAll.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkTimeAll As Global.System.Windows.Forms.Control = Me.chkTimeAll
			point = New Global.System.Drawing.Point(110, 34)
			chkTimeAll.Location = point
			Me.chkTimeAll.Name = "chkTimeAll"
			Dim chkTimeAll2 As Global.System.Windows.Forms.Control = Me.chkTimeAll
			size = New Global.System.Drawing.Size(15, 14)
			chkTimeAll2.Size = size
			Me.chkTimeAll.TabIndex = 825
			Me.chkTimeAll.UseVisualStyleBackColor = False
			Me.chkFirstAll.AutoSize = True
			Me.chkFirstAll.BackColor = Global.System.Drawing.SystemColors.Window
			Me.chkFirstAll.FlatAppearance.CheckedBackColor = Global.System.Drawing.Color.FromArgb(255, 128, 0)
			Me.chkFirstAll.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkFirstAll As Global.System.Windows.Forms.Control = Me.chkFirstAll
			point = New Global.System.Drawing.Point(31, 34)
			chkFirstAll.Location = point
			Me.chkFirstAll.Name = "chkFirstAll"
			Dim chkFirstAll2 As Global.System.Windows.Forms.Control = Me.chkFirstAll
			size = New Global.System.Drawing.Size(15, 14)
			chkFirstAll2.Size = size
			Me.chkFirstAll.TabIndex = 825
			Me.chkFirstAll.UseVisualStyleBackColor = False
			Me.chkFirst1.AutoSize = True
			Me.chkFirst1.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkFirst1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkFirst47 As Global.System.Windows.Forms.Control = Me.chkFirst1
			point = New Global.System.Drawing.Point(31, 54)
			chkFirst47.Location = point
			Me.chkFirst1.Name = "chkFirst1"
			Dim chkFirst48 As Global.System.Windows.Forms.Control = Me.chkFirst1
			size = New Global.System.Drawing.Size(15, 14)
			chkFirst48.Size = size
			Me.chkFirst1.TabIndex = 825
			Me.chkFirst1.UseVisualStyleBackColor = False
			Me.chkLast12.AutoSize = True
			Me.chkLast12.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkLast12.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkLast25 As Global.System.Windows.Forms.Control = Me.chkLast12
			point = New Global.System.Drawing.Point(735, 274)
			chkLast25.Location = point
			Me.chkLast12.Name = "chkLast12"
			Dim chkLast26 As Global.System.Windows.Forms.Control = Me.chkLast12
			size = New Global.System.Drawing.Size(15, 14)
			chkLast26.Size = size
			Me.chkLast12.TabIndex = 824
			Me.chkLast12.UseVisualStyleBackColor = False
			Me.chkLast11.AutoSize = True
			Me.chkLast11.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkLast11.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkLast27 As Global.System.Windows.Forms.Control = Me.chkLast11
			point = New Global.System.Drawing.Point(735, 254)
			chkLast27.Location = point
			Me.chkLast11.Name = "chkLast11"
			Dim chkLast28 As Global.System.Windows.Forms.Control = Me.chkLast11
			size = New Global.System.Drawing.Size(15, 14)
			chkLast28.Size = size
			Me.chkLast11.TabIndex = 823
			Me.chkLast11.UseVisualStyleBackColor = False
			Me.chkLast10.AutoSize = True
			Me.chkLast10.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkLast10.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkLast29 As Global.System.Windows.Forms.Control = Me.chkLast10
			point = New Global.System.Drawing.Point(735, 234)
			chkLast29.Location = point
			Me.chkLast10.Name = "chkLast10"
			Dim chkLast30 As Global.System.Windows.Forms.Control = Me.chkLast10
			size = New Global.System.Drawing.Size(15, 14)
			chkLast30.Size = size
			Me.chkLast10.TabIndex = 822
			Me.chkLast10.UseVisualStyleBackColor = False
			Me.chkLast9.AutoSize = True
			Me.chkLast9.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkLast9.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkLast31 As Global.System.Windows.Forms.Control = Me.chkLast9
			point = New Global.System.Drawing.Point(735, 214)
			chkLast31.Location = point
			Me.chkLast9.Name = "chkLast9"
			Dim chkLast32 As Global.System.Windows.Forms.Control = Me.chkLast9
			size = New Global.System.Drawing.Size(15, 14)
			chkLast32.Size = size
			Me.chkLast9.TabIndex = 821
			Me.chkLast9.UseVisualStyleBackColor = False
			Me.chkLast8.AutoSize = True
			Me.chkLast8.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkLast8.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkLast33 As Global.System.Windows.Forms.Control = Me.chkLast8
			point = New Global.System.Drawing.Point(735, 194)
			chkLast33.Location = point
			Me.chkLast8.Name = "chkLast8"
			Dim chkLast34 As Global.System.Windows.Forms.Control = Me.chkLast8
			size = New Global.System.Drawing.Size(15, 14)
			chkLast34.Size = size
			Me.chkLast8.TabIndex = 820
			Me.chkLast8.UseVisualStyleBackColor = False
			Me.chkLast7.AutoSize = True
			Me.chkLast7.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkLast7.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkLast35 As Global.System.Windows.Forms.Control = Me.chkLast7
			point = New Global.System.Drawing.Point(735, 174)
			chkLast35.Location = point
			Me.chkLast7.Name = "chkLast7"
			Dim chkLast36 As Global.System.Windows.Forms.Control = Me.chkLast7
			size = New Global.System.Drawing.Size(15, 14)
			chkLast36.Size = size
			Me.chkLast7.TabIndex = 819
			Me.chkLast7.UseVisualStyleBackColor = False
			Me.chkLast6.AutoSize = True
			Me.chkLast6.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkLast6.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkLast37 As Global.System.Windows.Forms.Control = Me.chkLast6
			point = New Global.System.Drawing.Point(735, 154)
			chkLast37.Location = point
			Me.chkLast6.Name = "chkLast6"
			Dim chkLast38 As Global.System.Windows.Forms.Control = Me.chkLast6
			size = New Global.System.Drawing.Size(15, 14)
			chkLast38.Size = size
			Me.chkLast6.TabIndex = 818
			Me.chkLast6.UseVisualStyleBackColor = False
			Me.chkLast5.AutoSize = True
			Me.chkLast5.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkLast5.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkLast39 As Global.System.Windows.Forms.Control = Me.chkLast5
			point = New Global.System.Drawing.Point(735, 134)
			chkLast39.Location = point
			Me.chkLast5.Name = "chkLast5"
			Dim chkLast40 As Global.System.Windows.Forms.Control = Me.chkLast5
			size = New Global.System.Drawing.Size(15, 14)
			chkLast40.Size = size
			Me.chkLast5.TabIndex = 817
			Me.chkLast5.UseVisualStyleBackColor = False
			Me.chkLast4.AutoSize = True
			Me.chkLast4.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkLast4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkLast41 As Global.System.Windows.Forms.Control = Me.chkLast4
			point = New Global.System.Drawing.Point(735, 114)
			chkLast41.Location = point
			Me.chkLast4.Name = "chkLast4"
			Dim chkLast42 As Global.System.Windows.Forms.Control = Me.chkLast4
			size = New Global.System.Drawing.Size(15, 14)
			chkLast42.Size = size
			Me.chkLast4.TabIndex = 816
			Me.chkLast4.UseVisualStyleBackColor = False
			Me.chkLast3.AutoSize = True
			Me.chkLast3.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkLast3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkLast43 As Global.System.Windows.Forms.Control = Me.chkLast3
			point = New Global.System.Drawing.Point(735, 94)
			chkLast43.Location = point
			Me.chkLast3.Name = "chkLast3"
			Dim chkLast44 As Global.System.Windows.Forms.Control = Me.chkLast3
			size = New Global.System.Drawing.Size(15, 14)
			chkLast44.Size = size
			Me.chkLast3.TabIndex = 815
			Me.chkLast3.UseVisualStyleBackColor = False
			Me.chkLast2.AutoSize = True
			Me.chkLast2.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkLast2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkLast45 As Global.System.Windows.Forms.Control = Me.chkLast2
			point = New Global.System.Drawing.Point(735, 74)
			chkLast45.Location = point
			Me.chkLast2.Name = "chkLast2"
			Dim chkLast46 As Global.System.Windows.Forms.Control = Me.chkLast2
			size = New Global.System.Drawing.Size(15, 14)
			chkLast46.Size = size
			Me.chkLast2.TabIndex = 814
			Me.chkLast2.UseVisualStyleBackColor = False
			Me.chkLast1.AutoSize = True
			Me.chkLast1.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkLast1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkLast47 As Global.System.Windows.Forms.Control = Me.chkLast1
			point = New Global.System.Drawing.Point(735, 54)
			chkLast47.Location = point
			Me.chkLast1.Name = "chkLast1"
			Dim chkLast48 As Global.System.Windows.Forms.Control = Me.chkLast1
			size = New Global.System.Drawing.Size(15, 14)
			chkLast48.Size = size
			Me.chkLast1.TabIndex = 813
			Me.chkLast1.UseVisualStyleBackColor = False
			Me.lblSuguest.AutoSize = True
			Me.lblSuguest.BackColor = Global.System.Drawing.Color.Red
			Me.lblSuguest.ForeColor = Global.System.Drawing.Color.White
			Dim lblSuguest As Global.System.Windows.Forms.Control = Me.lblSuguest
			point = New Global.System.Drawing.Point(217, 538)
			lblSuguest.Location = point
			Me.lblSuguest.Name = "lblSuguest"
			Dim lblSuguest2 As Global.System.Windows.Forms.Control = Me.lblSuguest
			size = New Global.System.Drawing.Size(537, 13)
			lblSuguest2.Size = size
			Me.lblSuguest.TabIndex = 812
			Me.lblSuguest.Text = "ท่านสามารถเพิ่มเสียงด้วยตัวเองได้ที่ C:/Sound/Thai/ConTN/ หรือ C:/Sound/Eng/ConTN/ นามสกุล .wav เท่านั้น"
			Me.lblReadCon.AutoSize = True
			Me.lblReadCon.BackColor = Global.System.Drawing.Color.Transparent
			Me.lblReadCon.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Me.lblReadCon.ForeColor = Global.System.Drawing.Color.Maroon
			Dim lblReadCon As Global.System.Windows.Forms.Control = Me.lblReadCon
			point = New Global.System.Drawing.Point(247, 6)
			lblReadCon.Location = point
			Me.lblReadCon.Name = "lblReadCon"
			Dim lblReadCon2 As Global.System.Windows.Forms.Control = Me.lblReadCon
			size = New Global.System.Drawing.Size(80, 16)
			lblReadCon2.Size = size
			Me.lblReadCon.TabIndex = 810
			Me.lblReadCon.Text = "อ่านเสียงต่อท้าย"
			Me.PictureBox6.BackColor = Global.System.Drawing.Color.Transparent
			Me.PictureBox6.ErrorImage = Nothing
			Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), Global.System.Drawing.Image)
			Me.PictureBox6.InitialImage = Nothing
			Dim pictureBox7 As Global.System.Windows.Forms.Control = Me.PictureBox6
			point = New Global.System.Drawing.Point(110, 3)
			pictureBox7.Location = point
			Me.PictureBox6.Name = "PictureBox6"
			Dim pictureBox8 As Global.System.Windows.Forms.Control = Me.PictureBox6
			size = New Global.System.Drawing.Size(20, 25)
			pictureBox8.Size = size
			Me.PictureBox6.TabIndex = 809
			Me.PictureBox6.TabStop = False
			Me.lblReadTime.AutoSize = True
			Me.lblReadTime.BackColor = Global.System.Drawing.Color.Transparent
			Me.lblReadTime.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Me.lblReadTime.ForeColor = Global.System.Drawing.Color.Maroon
			Dim lblReadTime As Global.System.Windows.Forms.Control = Me.lblReadTime
			point = New Global.System.Drawing.Point(130, 6)
			lblReadTime.Location = point
			Me.lblReadTime.Name = "lblReadTime"
			Dim lblReadTime2 As Global.System.Windows.Forms.Control = Me.lblReadTime
			size = New Global.System.Drawing.Size(46, 16)
			lblReadTime2.Size = size
			Me.lblReadTime.TabIndex = 808
			Me.lblReadTime.Text = "อ่านเวลา"
			Me.chkTime12.AutoSize = True
			Me.chkTime12.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkTime12.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkTime25 As Global.System.Windows.Forms.Control = Me.chkTime12
			point = New Global.System.Drawing.Point(110, 274)
			chkTime25.Location = point
			Me.chkTime12.Name = "chkTime12"
			Dim chkTime26 As Global.System.Windows.Forms.Control = Me.chkTime12
			size = New Global.System.Drawing.Size(15, 14)
			chkTime26.Size = size
			Me.chkTime12.TabIndex = 807
			Me.chkTime12.UseVisualStyleBackColor = False
			Me.chkTime11.AutoSize = True
			Me.chkTime11.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkTime11.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkTime27 As Global.System.Windows.Forms.Control = Me.chkTime11
			point = New Global.System.Drawing.Point(110, 254)
			chkTime27.Location = point
			Me.chkTime11.Name = "chkTime11"
			Dim chkTime28 As Global.System.Windows.Forms.Control = Me.chkTime11
			size = New Global.System.Drawing.Size(15, 14)
			chkTime28.Size = size
			Me.chkTime11.TabIndex = 806
			Me.chkTime11.UseVisualStyleBackColor = False
			Me.chkTime10.AutoSize = True
			Me.chkTime10.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkTime10.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkTime29 As Global.System.Windows.Forms.Control = Me.chkTime10
			point = New Global.System.Drawing.Point(110, 234)
			chkTime29.Location = point
			Me.chkTime10.Name = "chkTime10"
			Dim chkTime30 As Global.System.Windows.Forms.Control = Me.chkTime10
			size = New Global.System.Drawing.Size(15, 14)
			chkTime30.Size = size
			Me.chkTime10.TabIndex = 805
			Me.chkTime10.UseVisualStyleBackColor = False
			Me.chkTime9.AutoSize = True
			Me.chkTime9.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkTime9.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkTime31 As Global.System.Windows.Forms.Control = Me.chkTime9
			point = New Global.System.Drawing.Point(110, 214)
			chkTime31.Location = point
			Me.chkTime9.Name = "chkTime9"
			Dim chkTime32 As Global.System.Windows.Forms.Control = Me.chkTime9
			size = New Global.System.Drawing.Size(15, 14)
			chkTime32.Size = size
			Me.chkTime9.TabIndex = 804
			Me.chkTime9.UseVisualStyleBackColor = False
			Me.chkTime8.AutoSize = True
			Me.chkTime8.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkTime8.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkTime33 As Global.System.Windows.Forms.Control = Me.chkTime8
			point = New Global.System.Drawing.Point(110, 194)
			chkTime33.Location = point
			Me.chkTime8.Name = "chkTime8"
			Dim chkTime34 As Global.System.Windows.Forms.Control = Me.chkTime8
			size = New Global.System.Drawing.Size(15, 14)
			chkTime34.Size = size
			Me.chkTime8.TabIndex = 803
			Me.chkTime8.UseVisualStyleBackColor = False
			Me.chkTime7.AutoSize = True
			Me.chkTime7.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkTime7.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkTime35 As Global.System.Windows.Forms.Control = Me.chkTime7
			point = New Global.System.Drawing.Point(110, 174)
			chkTime35.Location = point
			Me.chkTime7.Name = "chkTime7"
			Dim chkTime36 As Global.System.Windows.Forms.Control = Me.chkTime7
			size = New Global.System.Drawing.Size(15, 14)
			chkTime36.Size = size
			Me.chkTime7.TabIndex = 802
			Me.chkTime7.UseVisualStyleBackColor = False
			Me.chkTime6.AutoSize = True
			Me.chkTime6.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkTime6.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkTime37 As Global.System.Windows.Forms.Control = Me.chkTime6
			point = New Global.System.Drawing.Point(110, 154)
			chkTime37.Location = point
			Me.chkTime6.Name = "chkTime6"
			Dim chkTime38 As Global.System.Windows.Forms.Control = Me.chkTime6
			size = New Global.System.Drawing.Size(15, 14)
			chkTime38.Size = size
			Me.chkTime6.TabIndex = 801
			Me.chkTime6.UseVisualStyleBackColor = False
			Me.chkTime5.AutoSize = True
			Me.chkTime5.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkTime5.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkTime39 As Global.System.Windows.Forms.Control = Me.chkTime5
			point = New Global.System.Drawing.Point(110, 134)
			chkTime39.Location = point
			Me.chkTime5.Name = "chkTime5"
			Dim chkTime40 As Global.System.Windows.Forms.Control = Me.chkTime5
			size = New Global.System.Drawing.Size(15, 14)
			chkTime40.Size = size
			Me.chkTime5.TabIndex = 800
			Me.chkTime5.UseVisualStyleBackColor = False
			Me.chkTime4.AutoSize = True
			Me.chkTime4.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkTime4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkTime41 As Global.System.Windows.Forms.Control = Me.chkTime4
			point = New Global.System.Drawing.Point(110, 114)
			chkTime41.Location = point
			Me.chkTime4.Name = "chkTime4"
			Dim chkTime42 As Global.System.Windows.Forms.Control = Me.chkTime4
			size = New Global.System.Drawing.Size(15, 14)
			chkTime42.Size = size
			Me.chkTime4.TabIndex = 799
			Me.chkTime4.UseVisualStyleBackColor = False
			Me.chkTime3.AutoSize = True
			Me.chkTime3.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkTime3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkTime43 As Global.System.Windows.Forms.Control = Me.chkTime3
			point = New Global.System.Drawing.Point(110, 94)
			chkTime43.Location = point
			Me.chkTime3.Name = "chkTime3"
			Dim chkTime44 As Global.System.Windows.Forms.Control = Me.chkTime3
			size = New Global.System.Drawing.Size(15, 14)
			chkTime44.Size = size
			Me.chkTime3.TabIndex = 798
			Me.chkTime3.UseVisualStyleBackColor = False
			Me.chkTime2.AutoSize = True
			Me.chkTime2.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkTime2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkTime45 As Global.System.Windows.Forms.Control = Me.chkTime2
			point = New Global.System.Drawing.Point(110, 74)
			chkTime45.Location = point
			Me.chkTime2.Name = "chkTime2"
			Dim chkTime46 As Global.System.Windows.Forms.Control = Me.chkTime2
			size = New Global.System.Drawing.Size(15, 14)
			chkTime46.Size = size
			Me.chkTime2.TabIndex = 797
			Me.chkTime2.UseVisualStyleBackColor = False
			Me.chkTime1.AutoSize = True
			Me.chkTime1.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkTime1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkTime47 As Global.System.Windows.Forms.Control = Me.chkTime1
			point = New Global.System.Drawing.Point(110, 54)
			chkTime47.Location = point
			Me.chkTime1.Name = "chkTime1"
			Dim chkTime48 As Global.System.Windows.Forms.Control = Me.chkTime1
			size = New Global.System.Drawing.Size(15, 14)
			chkTime48.Size = size
			Me.chkTime1.TabIndex = 796
			Me.chkTime1.UseVisualStyleBackColor = False
			Me.comboSoundConEng12.FormattingEnabled = True
			Dim comboSoundConEng25 As Global.System.Windows.Forms.Control = Me.comboSoundConEng12
			point = New Global.System.Drawing.Point(488, 271)
			comboSoundConEng25.Location = point
			Me.comboSoundConEng12.Name = "comboSoundConEng12"
			Dim comboSoundConEng26 As Global.System.Windows.Forms.Control = Me.comboSoundConEng12
			size = New Global.System.Drawing.Size(238, 21)
			comboSoundConEng26.Size = size
			Me.comboSoundConEng12.TabIndex = 795
			Me.comboSoundConEng11.FormattingEnabled = True
			Dim comboSoundConEng27 As Global.System.Windows.Forms.Control = Me.comboSoundConEng11
			point = New Global.System.Drawing.Point(488, 251)
			comboSoundConEng27.Location = point
			Me.comboSoundConEng11.Name = "comboSoundConEng11"
			Dim comboSoundConEng28 As Global.System.Windows.Forms.Control = Me.comboSoundConEng11
			size = New Global.System.Drawing.Size(238, 21)
			comboSoundConEng28.Size = size
			Me.comboSoundConEng11.TabIndex = 794
			Me.comboSoundConEng10.FormattingEnabled = True
			Dim comboSoundConEng29 As Global.System.Windows.Forms.Control = Me.comboSoundConEng10
			point = New Global.System.Drawing.Point(488, 231)
			comboSoundConEng29.Location = point
			Me.comboSoundConEng10.Name = "comboSoundConEng10"
			Dim comboSoundConEng30 As Global.System.Windows.Forms.Control = Me.comboSoundConEng10
			size = New Global.System.Drawing.Size(238, 21)
			comboSoundConEng30.Size = size
			Me.comboSoundConEng10.TabIndex = 793
			Me.comboSoundConEng9.FormattingEnabled = True
			Dim comboSoundConEng31 As Global.System.Windows.Forms.Control = Me.comboSoundConEng9
			point = New Global.System.Drawing.Point(488, 211)
			comboSoundConEng31.Location = point
			Me.comboSoundConEng9.Name = "comboSoundConEng9"
			Dim comboSoundConEng32 As Global.System.Windows.Forms.Control = Me.comboSoundConEng9
			size = New Global.System.Drawing.Size(238, 21)
			comboSoundConEng32.Size = size
			Me.comboSoundConEng9.TabIndex = 792
			Me.comboSoundConEng8.FormattingEnabled = True
			Dim comboSoundConEng33 As Global.System.Windows.Forms.Control = Me.comboSoundConEng8
			point = New Global.System.Drawing.Point(488, 191)
			comboSoundConEng33.Location = point
			Me.comboSoundConEng8.Name = "comboSoundConEng8"
			Dim comboSoundConEng34 As Global.System.Windows.Forms.Control = Me.comboSoundConEng8
			size = New Global.System.Drawing.Size(238, 21)
			comboSoundConEng34.Size = size
			Me.comboSoundConEng8.TabIndex = 791
			Me.comboSoundConEng7.FormattingEnabled = True
			Dim comboSoundConEng35 As Global.System.Windows.Forms.Control = Me.comboSoundConEng7
			point = New Global.System.Drawing.Point(488, 171)
			comboSoundConEng35.Location = point
			Me.comboSoundConEng7.Name = "comboSoundConEng7"
			Dim comboSoundConEng36 As Global.System.Windows.Forms.Control = Me.comboSoundConEng7
			size = New Global.System.Drawing.Size(238, 21)
			comboSoundConEng36.Size = size
			Me.comboSoundConEng7.TabIndex = 790
			Me.comboSoundConEng6.FormattingEnabled = True
			Dim comboSoundConEng37 As Global.System.Windows.Forms.Control = Me.comboSoundConEng6
			point = New Global.System.Drawing.Point(488, 151)
			comboSoundConEng37.Location = point
			Me.comboSoundConEng6.Name = "comboSoundConEng6"
			Dim comboSoundConEng38 As Global.System.Windows.Forms.Control = Me.comboSoundConEng6
			size = New Global.System.Drawing.Size(238, 21)
			comboSoundConEng38.Size = size
			Me.comboSoundConEng6.TabIndex = 789
			Me.comboSoundConEng5.FormattingEnabled = True
			Dim comboSoundConEng39 As Global.System.Windows.Forms.Control = Me.comboSoundConEng5
			point = New Global.System.Drawing.Point(488, 131)
			comboSoundConEng39.Location = point
			Me.comboSoundConEng5.Name = "comboSoundConEng5"
			Dim comboSoundConEng40 As Global.System.Windows.Forms.Control = Me.comboSoundConEng5
			size = New Global.System.Drawing.Size(238, 21)
			comboSoundConEng40.Size = size
			Me.comboSoundConEng5.TabIndex = 788
			Me.comboSoundConEng4.FormattingEnabled = True
			Dim comboSoundConEng41 As Global.System.Windows.Forms.Control = Me.comboSoundConEng4
			point = New Global.System.Drawing.Point(488, 111)
			comboSoundConEng41.Location = point
			Me.comboSoundConEng4.Name = "comboSoundConEng4"
			Dim comboSoundConEng42 As Global.System.Windows.Forms.Control = Me.comboSoundConEng4
			size = New Global.System.Drawing.Size(238, 21)
			comboSoundConEng42.Size = size
			Me.comboSoundConEng4.TabIndex = 787
			Me.comboSoundConEng3.FormattingEnabled = True
			Dim comboSoundConEng43 As Global.System.Windows.Forms.Control = Me.comboSoundConEng3
			point = New Global.System.Drawing.Point(488, 91)
			comboSoundConEng43.Location = point
			Me.comboSoundConEng3.Name = "comboSoundConEng3"
			Dim comboSoundConEng44 As Global.System.Windows.Forms.Control = Me.comboSoundConEng3
			size = New Global.System.Drawing.Size(238, 21)
			comboSoundConEng44.Size = size
			Me.comboSoundConEng3.TabIndex = 786
			Me.comboSoundConEng2.FormattingEnabled = True
			Dim comboSoundConEng45 As Global.System.Windows.Forms.Control = Me.comboSoundConEng2
			point = New Global.System.Drawing.Point(488, 71)
			comboSoundConEng45.Location = point
			Me.comboSoundConEng2.Name = "comboSoundConEng2"
			Dim comboSoundConEng46 As Global.System.Windows.Forms.Control = Me.comboSoundConEng2
			size = New Global.System.Drawing.Size(238, 21)
			comboSoundConEng46.Size = size
			Me.comboSoundConEng2.TabIndex = 785
			Me.comboSoundConEng1.FormattingEnabled = True
			Dim comboSoundConEng47 As Global.System.Windows.Forms.Control = Me.comboSoundConEng1
			point = New Global.System.Drawing.Point(488, 51)
			comboSoundConEng47.Location = point
			Me.comboSoundConEng1.Name = "comboSoundConEng1"
			Dim comboSoundConEng48 As Global.System.Windows.Forms.Control = Me.comboSoundConEng1
			size = New Global.System.Drawing.Size(238, 21)
			comboSoundConEng48.Size = size
			Me.comboSoundConEng1.TabIndex = 784
			Me.comboSoundCon12.FormattingEnabled = True
			Dim comboSoundCon25 As Global.System.Windows.Forms.Control = Me.comboSoundCon12
			point = New Global.System.Drawing.Point(250, 271)
			comboSoundCon25.Location = point
			Me.comboSoundCon12.Name = "comboSoundCon12"
			Dim comboSoundCon26 As Global.System.Windows.Forms.Control = Me.comboSoundCon12
			size = New Global.System.Drawing.Size(232, 21)
			comboSoundCon26.Size = size
			Me.comboSoundCon12.TabIndex = 783
			Me.comboSoundCon11.FormattingEnabled = True
			Dim comboSoundCon27 As Global.System.Windows.Forms.Control = Me.comboSoundCon11
			point = New Global.System.Drawing.Point(250, 251)
			comboSoundCon27.Location = point
			Me.comboSoundCon11.Name = "comboSoundCon11"
			Dim comboSoundCon28 As Global.System.Windows.Forms.Control = Me.comboSoundCon11
			size = New Global.System.Drawing.Size(232, 21)
			comboSoundCon28.Size = size
			Me.comboSoundCon11.TabIndex = 782
			Me.comboSoundCon10.FormattingEnabled = True
			Dim comboSoundCon29 As Global.System.Windows.Forms.Control = Me.comboSoundCon10
			point = New Global.System.Drawing.Point(250, 231)
			comboSoundCon29.Location = point
			Me.comboSoundCon10.Name = "comboSoundCon10"
			Dim comboSoundCon30 As Global.System.Windows.Forms.Control = Me.comboSoundCon10
			size = New Global.System.Drawing.Size(232, 21)
			comboSoundCon30.Size = size
			Me.comboSoundCon10.TabIndex = 781
			Me.comboSoundCon9.FormattingEnabled = True
			Dim comboSoundCon31 As Global.System.Windows.Forms.Control = Me.comboSoundCon9
			point = New Global.System.Drawing.Point(250, 211)
			comboSoundCon31.Location = point
			Me.comboSoundCon9.Name = "comboSoundCon9"
			Dim comboSoundCon32 As Global.System.Windows.Forms.Control = Me.comboSoundCon9
			size = New Global.System.Drawing.Size(232, 21)
			comboSoundCon32.Size = size
			Me.comboSoundCon9.TabIndex = 780
			Me.comboSoundCon8.FormattingEnabled = True
			Dim comboSoundCon33 As Global.System.Windows.Forms.Control = Me.comboSoundCon8
			point = New Global.System.Drawing.Point(250, 191)
			comboSoundCon33.Location = point
			Me.comboSoundCon8.Name = "comboSoundCon8"
			Dim comboSoundCon34 As Global.System.Windows.Forms.Control = Me.comboSoundCon8
			size = New Global.System.Drawing.Size(232, 21)
			comboSoundCon34.Size = size
			Me.comboSoundCon8.TabIndex = 779
			Me.comboSoundCon7.FormattingEnabled = True
			Dim comboSoundCon35 As Global.System.Windows.Forms.Control = Me.comboSoundCon7
			point = New Global.System.Drawing.Point(250, 171)
			comboSoundCon35.Location = point
			Me.comboSoundCon7.Name = "comboSoundCon7"
			Dim comboSoundCon36 As Global.System.Windows.Forms.Control = Me.comboSoundCon7
			size = New Global.System.Drawing.Size(232, 21)
			comboSoundCon36.Size = size
			Me.comboSoundCon7.TabIndex = 778
			Me.comboSoundCon6.FormattingEnabled = True
			Dim comboSoundCon37 As Global.System.Windows.Forms.Control = Me.comboSoundCon6
			point = New Global.System.Drawing.Point(250, 151)
			comboSoundCon37.Location = point
			Me.comboSoundCon6.Name = "comboSoundCon6"
			Dim comboSoundCon38 As Global.System.Windows.Forms.Control = Me.comboSoundCon6
			size = New Global.System.Drawing.Size(232, 21)
			comboSoundCon38.Size = size
			Me.comboSoundCon6.TabIndex = 777
			Me.comboSoundCon5.FormattingEnabled = True
			Dim comboSoundCon39 As Global.System.Windows.Forms.Control = Me.comboSoundCon5
			point = New Global.System.Drawing.Point(250, 131)
			comboSoundCon39.Location = point
			Me.comboSoundCon5.Name = "comboSoundCon5"
			Dim comboSoundCon40 As Global.System.Windows.Forms.Control = Me.comboSoundCon5
			size = New Global.System.Drawing.Size(232, 21)
			comboSoundCon40.Size = size
			Me.comboSoundCon5.TabIndex = 776
			Me.comboSoundCon4.FormattingEnabled = True
			Dim comboSoundCon41 As Global.System.Windows.Forms.Control = Me.comboSoundCon4
			point = New Global.System.Drawing.Point(250, 111)
			comboSoundCon41.Location = point
			Me.comboSoundCon4.Name = "comboSoundCon4"
			Dim comboSoundCon42 As Global.System.Windows.Forms.Control = Me.comboSoundCon4
			size = New Global.System.Drawing.Size(232, 21)
			comboSoundCon42.Size = size
			Me.comboSoundCon4.TabIndex = 775
			Me.comboSoundCon3.FormattingEnabled = True
			Dim comboSoundCon43 As Global.System.Windows.Forms.Control = Me.comboSoundCon3
			point = New Global.System.Drawing.Point(250, 91)
			comboSoundCon43.Location = point
			Me.comboSoundCon3.Name = "comboSoundCon3"
			Dim comboSoundCon44 As Global.System.Windows.Forms.Control = Me.comboSoundCon3
			size = New Global.System.Drawing.Size(232, 21)
			comboSoundCon44.Size = size
			Me.comboSoundCon3.TabIndex = 774
			Me.comboSoundCon2.FormattingEnabled = True
			Dim comboSoundCon45 As Global.System.Windows.Forms.Control = Me.comboSoundCon2
			point = New Global.System.Drawing.Point(250, 71)
			comboSoundCon45.Location = point
			Me.comboSoundCon2.Name = "comboSoundCon2"
			Dim comboSoundCon46 As Global.System.Windows.Forms.Control = Me.comboSoundCon2
			size = New Global.System.Drawing.Size(232, 21)
			comboSoundCon46.Size = size
			Me.comboSoundCon2.TabIndex = 773
			Me.comboSoundCon1.FormattingEnabled = True
			Dim comboSoundCon47 As Global.System.Windows.Forms.Control = Me.comboSoundCon1
			point = New Global.System.Drawing.Point(250, 51)
			comboSoundCon47.Location = point
			Me.comboSoundCon1.Name = "comboSoundCon1"
			Dim comboSoundCon48 As Global.System.Windows.Forms.Control = Me.comboSoundCon1
			size = New Global.System.Drawing.Size(232, 21)
			comboSoundCon48.Size = size
			Me.comboSoundCon1.TabIndex = 772
			Me.chkCon12.AutoSize = True
			Me.chkCon12.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkCon12.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkCon25 As Global.System.Windows.Forms.Control = Me.chkCon12
			point = New Global.System.Drawing.Point(229, 274)
			chkCon25.Location = point
			Me.chkCon12.Name = "chkCon12"
			Dim chkCon26 As Global.System.Windows.Forms.Control = Me.chkCon12
			size = New Global.System.Drawing.Size(15, 14)
			chkCon26.Size = size
			Me.chkCon12.TabIndex = 771
			Me.chkCon12.UseVisualStyleBackColor = False
			Me.btnPlay12.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnPlay12.Image = CType(resources.GetObject("btnPlay12.Image"), Global.System.Drawing.Image)
			Dim btnPlay25 As Global.System.Windows.Forms.Control = Me.btnPlay12
			point = New Global.System.Drawing.Point(756, 270)
			btnPlay25.Location = point
			Me.btnPlay12.Name = "btnPlay12"
			Dim btnPlay26 As Global.System.Windows.Forms.Control = Me.btnPlay12
			size = New Global.System.Drawing.Size(31, 21)
			btnPlay26.Size = size
			Me.btnPlay12.TabIndex = 770
			Me.btnPlay12.UseVisualStyleBackColor = False
			Me.comboMin12.FormattingEnabled = True
			Me.comboMin12.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" })
			Dim comboMin25 As Global.System.Windows.Forms.Control = Me.comboMin12
			point = New Global.System.Drawing.Point(177, 271)
			comboMin25.Location = point
			Me.comboMin12.Name = "comboMin12"
			Dim comboMin26 As Global.System.Windows.Forms.Control = Me.comboMin12
			size = New Global.System.Drawing.Size(40, 21)
			comboMin26.Size = size
			Me.comboMin12.TabIndex = 769
			Me.comboHour12.FormattingEnabled = True
			Me.comboHour12.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" })
			Dim comboHour25 As Global.System.Windows.Forms.Control = Me.comboHour12
			point = New Global.System.Drawing.Point(132, 271)
			comboHour25.Location = point
			Me.comboHour12.Name = "comboHour12"
			Dim comboHour26 As Global.System.Windows.Forms.Control = Me.comboHour12
			size = New Global.System.Drawing.Size(40, 21)
			comboHour26.Size = size
			Me.comboHour12.TabIndex = 768
			Me.chkCon11.AutoSize = True
			Me.chkCon11.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkCon11.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkCon27 As Global.System.Windows.Forms.Control = Me.chkCon11
			point = New Global.System.Drawing.Point(229, 254)
			chkCon27.Location = point
			Me.chkCon11.Name = "chkCon11"
			Dim chkCon28 As Global.System.Windows.Forms.Control = Me.chkCon11
			size = New Global.System.Drawing.Size(15, 14)
			chkCon28.Size = size
			Me.chkCon11.TabIndex = 767
			Me.chkCon11.UseVisualStyleBackColor = False
			Me.btnPlay11.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnPlay11.Image = CType(resources.GetObject("btnPlay11.Image"), Global.System.Drawing.Image)
			Dim btnPlay27 As Global.System.Windows.Forms.Control = Me.btnPlay11
			point = New Global.System.Drawing.Point(756, 249)
			btnPlay27.Location = point
			Me.btnPlay11.Name = "btnPlay11"
			Dim btnPlay28 As Global.System.Windows.Forms.Control = Me.btnPlay11
			size = New Global.System.Drawing.Size(31, 22)
			btnPlay28.Size = size
			Me.btnPlay11.TabIndex = 766
			Me.btnPlay11.UseVisualStyleBackColor = False
			Me.comboMin11.FormattingEnabled = True
			Me.comboMin11.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" })
			Dim comboMin27 As Global.System.Windows.Forms.Control = Me.comboMin11
			point = New Global.System.Drawing.Point(177, 251)
			comboMin27.Location = point
			Me.comboMin11.Name = "comboMin11"
			Dim comboMin28 As Global.System.Windows.Forms.Control = Me.comboMin11
			size = New Global.System.Drawing.Size(40, 21)
			comboMin28.Size = size
			Me.comboMin11.TabIndex = 765
			Me.comboHour11.FormattingEnabled = True
			Me.comboHour11.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" })
			Dim comboHour27 As Global.System.Windows.Forms.Control = Me.comboHour11
			point = New Global.System.Drawing.Point(132, 251)
			comboHour27.Location = point
			Me.comboHour11.Name = "comboHour11"
			Dim comboHour28 As Global.System.Windows.Forms.Control = Me.comboHour11
			size = New Global.System.Drawing.Size(40, 21)
			comboHour28.Size = size
			Me.comboHour11.TabIndex = 764
			Me.chkCon10.AutoSize = True
			Me.chkCon10.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkCon10.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkCon29 As Global.System.Windows.Forms.Control = Me.chkCon10
			point = New Global.System.Drawing.Point(229, 234)
			chkCon29.Location = point
			Me.chkCon10.Name = "chkCon10"
			Dim chkCon30 As Global.System.Windows.Forms.Control = Me.chkCon10
			size = New Global.System.Drawing.Size(15, 14)
			chkCon30.Size = size
			Me.chkCon10.TabIndex = 763
			Me.chkCon10.UseVisualStyleBackColor = False
			Me.btnPlay10.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnPlay10.Image = CType(resources.GetObject("btnPlay10.Image"), Global.System.Drawing.Image)
			Dim btnPlay29 As Global.System.Windows.Forms.Control = Me.btnPlay10
			point = New Global.System.Drawing.Point(756, 230)
			btnPlay29.Location = point
			Me.btnPlay10.Name = "btnPlay10"
			Dim btnPlay30 As Global.System.Windows.Forms.Control = Me.btnPlay10
			size = New Global.System.Drawing.Size(31, 21)
			btnPlay30.Size = size
			Me.btnPlay10.TabIndex = 762
			Me.btnPlay10.UseVisualStyleBackColor = False
			Me.comboMin10.FormattingEnabled = True
			Me.comboMin10.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" })
			Dim comboMin29 As Global.System.Windows.Forms.Control = Me.comboMin10
			point = New Global.System.Drawing.Point(177, 231)
			comboMin29.Location = point
			Me.comboMin10.Name = "comboMin10"
			Dim comboMin30 As Global.System.Windows.Forms.Control = Me.comboMin10
			size = New Global.System.Drawing.Size(40, 21)
			comboMin30.Size = size
			Me.comboMin10.TabIndex = 761
			Me.comboHour10.FormattingEnabled = True
			Me.comboHour10.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" })
			Dim comboHour29 As Global.System.Windows.Forms.Control = Me.comboHour10
			point = New Global.System.Drawing.Point(132, 231)
			comboHour29.Location = point
			Me.comboHour10.Name = "comboHour10"
			Dim comboHour30 As Global.System.Windows.Forms.Control = Me.comboHour10
			size = New Global.System.Drawing.Size(40, 21)
			comboHour30.Size = size
			Me.comboHour10.TabIndex = 760
			Me.chkCon9.AutoSize = True
			Me.chkCon9.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkCon9.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkCon31 As Global.System.Windows.Forms.Control = Me.chkCon9
			point = New Global.System.Drawing.Point(229, 214)
			chkCon31.Location = point
			Me.chkCon9.Name = "chkCon9"
			Dim chkCon32 As Global.System.Windows.Forms.Control = Me.chkCon9
			size = New Global.System.Drawing.Size(15, 14)
			chkCon32.Size = size
			Me.chkCon9.TabIndex = 759
			Me.chkCon9.UseVisualStyleBackColor = False
			Me.btnPlay9.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnPlay9.Image = CType(resources.GetObject("btnPlay9.Image"), Global.System.Drawing.Image)
			Dim btnPlay31 As Global.System.Windows.Forms.Control = Me.btnPlay9
			point = New Global.System.Drawing.Point(756, 210)
			btnPlay31.Location = point
			Me.btnPlay9.Name = "btnPlay9"
			Dim btnPlay32 As Global.System.Windows.Forms.Control = Me.btnPlay9
			size = New Global.System.Drawing.Size(31, 21)
			btnPlay32.Size = size
			Me.btnPlay9.TabIndex = 758
			Me.btnPlay9.UseVisualStyleBackColor = False
			Me.comboMin9.FormattingEnabled = True
			Me.comboMin9.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" })
			Dim comboMin31 As Global.System.Windows.Forms.Control = Me.comboMin9
			point = New Global.System.Drawing.Point(177, 211)
			comboMin31.Location = point
			Me.comboMin9.Name = "comboMin9"
			Dim comboMin32 As Global.System.Windows.Forms.Control = Me.comboMin9
			size = New Global.System.Drawing.Size(40, 21)
			comboMin32.Size = size
			Me.comboMin9.TabIndex = 757
			Me.comboHour9.FormattingEnabled = True
			Me.comboHour9.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" })
			Dim comboHour31 As Global.System.Windows.Forms.Control = Me.comboHour9
			point = New Global.System.Drawing.Point(132, 211)
			comboHour31.Location = point
			Me.comboHour9.Name = "comboHour9"
			Dim comboHour32 As Global.System.Windows.Forms.Control = Me.comboHour9
			size = New Global.System.Drawing.Size(40, 21)
			comboHour32.Size = size
			Me.comboHour9.TabIndex = 756
			Me.chkCon8.AutoSize = True
			Me.chkCon8.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkCon8.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkCon33 As Global.System.Windows.Forms.Control = Me.chkCon8
			point = New Global.System.Drawing.Point(229, 194)
			chkCon33.Location = point
			Me.chkCon8.Name = "chkCon8"
			Dim chkCon34 As Global.System.Windows.Forms.Control = Me.chkCon8
			size = New Global.System.Drawing.Size(15, 14)
			chkCon34.Size = size
			Me.chkCon8.TabIndex = 755
			Me.chkCon8.UseVisualStyleBackColor = False
			Me.btnPlay8.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnPlay8.Image = CType(resources.GetObject("btnPlay8.Image"), Global.System.Drawing.Image)
			Dim btnPlay33 As Global.System.Windows.Forms.Control = Me.btnPlay8
			point = New Global.System.Drawing.Point(756, 190)
			btnPlay33.Location = point
			Me.btnPlay8.Name = "btnPlay8"
			Dim btnPlay34 As Global.System.Windows.Forms.Control = Me.btnPlay8
			size = New Global.System.Drawing.Size(31, 21)
			btnPlay34.Size = size
			Me.btnPlay8.TabIndex = 754
			Me.btnPlay8.UseVisualStyleBackColor = False
			Me.comboMin8.FormattingEnabled = True
			Me.comboMin8.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" })
			Dim comboMin33 As Global.System.Windows.Forms.Control = Me.comboMin8
			point = New Global.System.Drawing.Point(177, 191)
			comboMin33.Location = point
			Me.comboMin8.Name = "comboMin8"
			Dim comboMin34 As Global.System.Windows.Forms.Control = Me.comboMin8
			size = New Global.System.Drawing.Size(40, 21)
			comboMin34.Size = size
			Me.comboMin8.TabIndex = 753
			Me.comboHour8.FormattingEnabled = True
			Me.comboHour8.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" })
			Dim comboHour33 As Global.System.Windows.Forms.Control = Me.comboHour8
			point = New Global.System.Drawing.Point(132, 191)
			comboHour33.Location = point
			Me.comboHour8.Name = "comboHour8"
			Dim comboHour34 As Global.System.Windows.Forms.Control = Me.comboHour8
			size = New Global.System.Drawing.Size(40, 21)
			comboHour34.Size = size
			Me.comboHour8.TabIndex = 752
			Me.chkCon7.AutoSize = True
			Me.chkCon7.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkCon7.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkCon35 As Global.System.Windows.Forms.Control = Me.chkCon7
			point = New Global.System.Drawing.Point(229, 174)
			chkCon35.Location = point
			Me.chkCon7.Name = "chkCon7"
			Dim chkCon36 As Global.System.Windows.Forms.Control = Me.chkCon7
			size = New Global.System.Drawing.Size(15, 14)
			chkCon36.Size = size
			Me.chkCon7.TabIndex = 751
			Me.chkCon7.UseVisualStyleBackColor = False
			Me.btnPlay7.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnPlay7.Image = CType(resources.GetObject("btnPlay7.Image"), Global.System.Drawing.Image)
			Dim btnPlay35 As Global.System.Windows.Forms.Control = Me.btnPlay7
			point = New Global.System.Drawing.Point(756, 170)
			btnPlay35.Location = point
			Me.btnPlay7.Name = "btnPlay7"
			Dim btnPlay36 As Global.System.Windows.Forms.Control = Me.btnPlay7
			size = New Global.System.Drawing.Size(31, 21)
			btnPlay36.Size = size
			Me.btnPlay7.TabIndex = 750
			Me.btnPlay7.UseVisualStyleBackColor = False
			Me.comboMin7.FormattingEnabled = True
			Me.comboMin7.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" })
			Dim comboMin35 As Global.System.Windows.Forms.Control = Me.comboMin7
			point = New Global.System.Drawing.Point(177, 171)
			comboMin35.Location = point
			Me.comboMin7.Name = "comboMin7"
			Dim comboMin36 As Global.System.Windows.Forms.Control = Me.comboMin7
			size = New Global.System.Drawing.Size(40, 21)
			comboMin36.Size = size
			Me.comboMin7.TabIndex = 749
			Me.comboHour7.FormattingEnabled = True
			Me.comboHour7.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" })
			Dim comboHour35 As Global.System.Windows.Forms.Control = Me.comboHour7
			point = New Global.System.Drawing.Point(132, 171)
			comboHour35.Location = point
			Me.comboHour7.Name = "comboHour7"
			Dim comboHour36 As Global.System.Windows.Forms.Control = Me.comboHour7
			size = New Global.System.Drawing.Size(40, 21)
			comboHour36.Size = size
			Me.comboHour7.TabIndex = 748
			Me.chkCon6.AutoSize = True
			Me.chkCon6.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkCon6.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkCon37 As Global.System.Windows.Forms.Control = Me.chkCon6
			point = New Global.System.Drawing.Point(229, 154)
			chkCon37.Location = point
			Me.chkCon6.Name = "chkCon6"
			Dim chkCon38 As Global.System.Windows.Forms.Control = Me.chkCon6
			size = New Global.System.Drawing.Size(15, 14)
			chkCon38.Size = size
			Me.chkCon6.TabIndex = 747
			Me.chkCon6.UseVisualStyleBackColor = False
			Me.btnPlay6.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnPlay6.Image = CType(resources.GetObject("btnPlay6.Image"), Global.System.Drawing.Image)
			Dim btnPlay37 As Global.System.Windows.Forms.Control = Me.btnPlay6
			point = New Global.System.Drawing.Point(756, 150)
			btnPlay37.Location = point
			Me.btnPlay6.Name = "btnPlay6"
			Dim btnPlay38 As Global.System.Windows.Forms.Control = Me.btnPlay6
			size = New Global.System.Drawing.Size(31, 22)
			btnPlay38.Size = size
			Me.btnPlay6.TabIndex = 746
			Me.btnPlay6.UseVisualStyleBackColor = False
			Me.comboMin6.FormattingEnabled = True
			Me.comboMin6.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" })
			Dim comboMin37 As Global.System.Windows.Forms.Control = Me.comboMin6
			point = New Global.System.Drawing.Point(177, 151)
			comboMin37.Location = point
			Me.comboMin6.Name = "comboMin6"
			Dim comboMin38 As Global.System.Windows.Forms.Control = Me.comboMin6
			size = New Global.System.Drawing.Size(40, 21)
			comboMin38.Size = size
			Me.comboMin6.TabIndex = 745
			Me.comboHour6.FormattingEnabled = True
			Me.comboHour6.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" })
			Dim comboHour37 As Global.System.Windows.Forms.Control = Me.comboHour6
			point = New Global.System.Drawing.Point(132, 151)
			comboHour37.Location = point
			Me.comboHour6.Name = "comboHour6"
			Dim comboHour38 As Global.System.Windows.Forms.Control = Me.comboHour6
			size = New Global.System.Drawing.Size(40, 21)
			comboHour38.Size = size
			Me.comboHour6.TabIndex = 744
			Me.chkCon5.AutoSize = True
			Me.chkCon5.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkCon5.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkCon39 As Global.System.Windows.Forms.Control = Me.chkCon5
			point = New Global.System.Drawing.Point(229, 134)
			chkCon39.Location = point
			Me.chkCon5.Name = "chkCon5"
			Dim chkCon40 As Global.System.Windows.Forms.Control = Me.chkCon5
			size = New Global.System.Drawing.Size(15, 14)
			chkCon40.Size = size
			Me.chkCon5.TabIndex = 743
			Me.chkCon5.UseVisualStyleBackColor = False
			Me.btnPlay5.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnPlay5.Image = CType(resources.GetObject("btnPlay5.Image"), Global.System.Drawing.Image)
			Dim btnPlay39 As Global.System.Windows.Forms.Control = Me.btnPlay5
			point = New Global.System.Drawing.Point(756, 130)
			btnPlay39.Location = point
			Me.btnPlay5.Name = "btnPlay5"
			Dim btnPlay40 As Global.System.Windows.Forms.Control = Me.btnPlay5
			size = New Global.System.Drawing.Size(31, 21)
			btnPlay40.Size = size
			Me.btnPlay5.TabIndex = 742
			Me.btnPlay5.UseVisualStyleBackColor = False
			Me.comboMin5.FormattingEnabled = True
			Me.comboMin5.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" })
			Dim comboMin39 As Global.System.Windows.Forms.Control = Me.comboMin5
			point = New Global.System.Drawing.Point(177, 131)
			comboMin39.Location = point
			Me.comboMin5.Name = "comboMin5"
			Dim comboMin40 As Global.System.Windows.Forms.Control = Me.comboMin5
			size = New Global.System.Drawing.Size(40, 21)
			comboMin40.Size = size
			Me.comboMin5.TabIndex = 741
			Me.comboHour5.FormattingEnabled = True
			Me.comboHour5.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" })
			Dim comboHour39 As Global.System.Windows.Forms.Control = Me.comboHour5
			point = New Global.System.Drawing.Point(132, 131)
			comboHour39.Location = point
			Me.comboHour5.Name = "comboHour5"
			Dim comboHour40 As Global.System.Windows.Forms.Control = Me.comboHour5
			size = New Global.System.Drawing.Size(40, 21)
			comboHour40.Size = size
			Me.comboHour5.TabIndex = 740
			Me.chkCon4.AutoSize = True
			Me.chkCon4.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkCon4.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkCon41 As Global.System.Windows.Forms.Control = Me.chkCon4
			point = New Global.System.Drawing.Point(229, 114)
			chkCon41.Location = point
			Me.chkCon4.Name = "chkCon4"
			Dim chkCon42 As Global.System.Windows.Forms.Control = Me.chkCon4
			size = New Global.System.Drawing.Size(15, 14)
			chkCon42.Size = size
			Me.chkCon4.TabIndex = 739
			Me.chkCon4.UseVisualStyleBackColor = False
			Me.btnPlay4.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnPlay4.Image = CType(resources.GetObject("btnPlay4.Image"), Global.System.Drawing.Image)
			Dim btnPlay41 As Global.System.Windows.Forms.Control = Me.btnPlay4
			point = New Global.System.Drawing.Point(756, 110)
			btnPlay41.Location = point
			Me.btnPlay4.Name = "btnPlay4"
			Dim btnPlay42 As Global.System.Windows.Forms.Control = Me.btnPlay4
			size = New Global.System.Drawing.Size(31, 21)
			btnPlay42.Size = size
			Me.btnPlay4.TabIndex = 738
			Me.btnPlay4.UseVisualStyleBackColor = False
			Me.comboMin4.FormattingEnabled = True
			Me.comboMin4.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" })
			Dim comboMin41 As Global.System.Windows.Forms.Control = Me.comboMin4
			point = New Global.System.Drawing.Point(177, 111)
			comboMin41.Location = point
			Me.comboMin4.Name = "comboMin4"
			Dim comboMin42 As Global.System.Windows.Forms.Control = Me.comboMin4
			size = New Global.System.Drawing.Size(40, 21)
			comboMin42.Size = size
			Me.comboMin4.TabIndex = 737
			Me.comboHour4.FormattingEnabled = True
			Me.comboHour4.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" })
			Dim comboHour41 As Global.System.Windows.Forms.Control = Me.comboHour4
			point = New Global.System.Drawing.Point(132, 111)
			comboHour41.Location = point
			Me.comboHour4.Name = "comboHour4"
			Dim comboHour42 As Global.System.Windows.Forms.Control = Me.comboHour4
			size = New Global.System.Drawing.Size(40, 21)
			comboHour42.Size = size
			Me.comboHour4.TabIndex = 736
			Me.chkCon3.AutoSize = True
			Me.chkCon3.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkCon3.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkCon43 As Global.System.Windows.Forms.Control = Me.chkCon3
			point = New Global.System.Drawing.Point(229, 94)
			chkCon43.Location = point
			Me.chkCon3.Name = "chkCon3"
			Dim chkCon44 As Global.System.Windows.Forms.Control = Me.chkCon3
			size = New Global.System.Drawing.Size(15, 14)
			chkCon44.Size = size
			Me.chkCon3.TabIndex = 735
			Me.chkCon3.UseVisualStyleBackColor = False
			Me.btnPlay3.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnPlay3.Image = CType(resources.GetObject("btnPlay3.Image"), Global.System.Drawing.Image)
			Dim btnPlay43 As Global.System.Windows.Forms.Control = Me.btnPlay3
			point = New Global.System.Drawing.Point(756, 90)
			btnPlay43.Location = point
			Me.btnPlay3.Name = "btnPlay3"
			Dim btnPlay44 As Global.System.Windows.Forms.Control = Me.btnPlay3
			size = New Global.System.Drawing.Size(31, 21)
			btnPlay44.Size = size
			Me.btnPlay3.TabIndex = 734
			Me.btnPlay3.UseVisualStyleBackColor = False
			Me.comboMin3.FormattingEnabled = True
			Me.comboMin3.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" })
			Dim comboMin43 As Global.System.Windows.Forms.Control = Me.comboMin3
			point = New Global.System.Drawing.Point(177, 91)
			comboMin43.Location = point
			Me.comboMin3.Name = "comboMin3"
			Dim comboMin44 As Global.System.Windows.Forms.Control = Me.comboMin3
			size = New Global.System.Drawing.Size(40, 21)
			comboMin44.Size = size
			Me.comboMin3.TabIndex = 733
			Me.comboHour3.FormattingEnabled = True
			Me.comboHour3.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" })
			Dim comboHour43 As Global.System.Windows.Forms.Control = Me.comboHour3
			point = New Global.System.Drawing.Point(132, 91)
			comboHour43.Location = point
			Me.comboHour3.Name = "comboHour3"
			Dim comboHour44 As Global.System.Windows.Forms.Control = Me.comboHour3
			size = New Global.System.Drawing.Size(40, 21)
			comboHour44.Size = size
			Me.comboHour3.TabIndex = 732
			Me.chkCon2.AutoSize = True
			Me.chkCon2.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkCon2.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkCon45 As Global.System.Windows.Forms.Control = Me.chkCon2
			point = New Global.System.Drawing.Point(229, 74)
			chkCon45.Location = point
			Me.chkCon2.Name = "chkCon2"
			Dim chkCon46 As Global.System.Windows.Forms.Control = Me.chkCon2
			size = New Global.System.Drawing.Size(15, 14)
			chkCon46.Size = size
			Me.chkCon2.TabIndex = 731
			Me.chkCon2.UseVisualStyleBackColor = False
			Me.btnPlay2.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnPlay2.Image = CType(resources.GetObject("btnPlay2.Image"), Global.System.Drawing.Image)
			Dim btnPlay45 As Global.System.Windows.Forms.Control = Me.btnPlay2
			point = New Global.System.Drawing.Point(756, 70)
			btnPlay45.Location = point
			Me.btnPlay2.Name = "btnPlay2"
			Dim btnPlay46 As Global.System.Windows.Forms.Control = Me.btnPlay2
			size = New Global.System.Drawing.Size(31, 21)
			btnPlay46.Size = size
			Me.btnPlay2.TabIndex = 730
			Me.btnPlay2.UseVisualStyleBackColor = False
			Me.comboMin2.FormattingEnabled = True
			Me.comboMin2.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" })
			Dim comboMin45 As Global.System.Windows.Forms.Control = Me.comboMin2
			point = New Global.System.Drawing.Point(177, 71)
			comboMin45.Location = point
			Me.comboMin2.Name = "comboMin2"
			Dim comboMin46 As Global.System.Windows.Forms.Control = Me.comboMin2
			size = New Global.System.Drawing.Size(40, 21)
			comboMin46.Size = size
			Me.comboMin2.TabIndex = 729
			Me.comboHour2.FormattingEnabled = True
			Me.comboHour2.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" })
			Dim comboHour45 As Global.System.Windows.Forms.Control = Me.comboHour2
			point = New Global.System.Drawing.Point(132, 71)
			comboHour45.Location = point
			Me.comboHour2.Name = "comboHour2"
			Dim comboHour46 As Global.System.Windows.Forms.Control = Me.comboHour2
			size = New Global.System.Drawing.Size(40, 21)
			comboHour46.Size = size
			Me.comboHour2.TabIndex = 728
			Me.chkCon1.AutoSize = True
			Me.chkCon1.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkCon1.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Dim chkCon47 As Global.System.Windows.Forms.Control = Me.chkCon1
			point = New Global.System.Drawing.Point(229, 54)
			chkCon47.Location = point
			Me.chkCon1.Name = "chkCon1"
			Dim chkCon48 As Global.System.Windows.Forms.Control = Me.chkCon1
			size = New Global.System.Drawing.Size(15, 14)
			chkCon48.Size = size
			Me.chkCon1.TabIndex = 727
			Me.chkCon1.UseVisualStyleBackColor = False
			Me.btnPlay1.BackColor = Global.System.Drawing.Color.Transparent
			Me.btnPlay1.Image = CType(resources.GetObject("btnPlay1.Image"), Global.System.Drawing.Image)
			Dim btnPlay47 As Global.System.Windows.Forms.Control = Me.btnPlay1
			point = New Global.System.Drawing.Point(756, 50)
			btnPlay47.Location = point
			Me.btnPlay1.Name = "btnPlay1"
			Dim btnPlay48 As Global.System.Windows.Forms.Control = Me.btnPlay1
			size = New Global.System.Drawing.Size(31, 21)
			btnPlay48.Size = size
			Me.btnPlay1.TabIndex = 726
			Me.btnPlay1.UseVisualStyleBackColor = False
			Me.comboMin1.FormattingEnabled = True
			Me.comboMin1.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59" })
			Dim comboMin47 As Global.System.Windows.Forms.Control = Me.comboMin1
			point = New Global.System.Drawing.Point(177, 51)
			comboMin47.Location = point
			Me.comboMin1.Name = "comboMin1"
			Dim comboMin48 As Global.System.Windows.Forms.Control = Me.comboMin1
			size = New Global.System.Drawing.Size(40, 21)
			comboMin48.Size = size
			Me.comboMin1.TabIndex = 725
			Me.comboHour1.FormattingEnabled = True
			Me.comboHour1.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" })
			Dim comboHour47 As Global.System.Windows.Forms.Control = Me.comboHour1
			point = New Global.System.Drawing.Point(132, 51)
			comboHour47.Location = point
			Me.comboHour1.Name = "comboHour1"
			Dim comboHour48 As Global.System.Windows.Forms.Control = Me.comboHour1
			size = New Global.System.Drawing.Size(40, 21)
			comboHour48.Size = size
			Me.comboHour1.TabIndex = 724
			Me.PictureBox7.BackColor = Global.System.Drawing.Color.Transparent
			Me.PictureBox7.ErrorImage = Nothing
			Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), Global.System.Drawing.Image)
			Me.PictureBox7.InitialImage = Nothing
			Dim pictureBox9 As Global.System.Windows.Forms.Control = Me.PictureBox7
			point = New Global.System.Drawing.Point(229, 3)
			pictureBox9.Location = point
			Me.PictureBox7.Name = "PictureBox7"
			Dim pictureBox10 As Global.System.Windows.Forms.Control = Me.PictureBox7
			size = New Global.System.Drawing.Size(20, 25)
			pictureBox10.Size = size
			Me.PictureBox7.TabIndex = 811
			Me.PictureBox7.TabStop = False
			Me.panelSetting.Controls.Add(Me.lblSetting)
			Me.panelSetting.Controls.Add(Me.Label73)
			Me.panelSetting.Controls.Add(Me.comboMinShutdown)
			Me.panelSetting.Controls.Add(Me.comboHourShutdown)
			Me.panelSetting.Controls.Add(Me.ckShutDown)
			Me.panelSetting.Controls.Add(Me.chkEng)
			Me.panelSetting.Controls.Add(Me.btnPlaySound)
			Me.panelSetting.Controls.Add(Me.lblAlarm)
			Me.panelSetting.Controls.Add(Me.listSoundBell)
			Me.panelSetting.Controls.Add(Me.chkThai)
			Me.panelSetting.Controls.Add(Me.lblLang)
			Dim panelSetting As Global.System.Windows.Forms.Control = Me.panelSetting
			point = New Global.System.Drawing.Point(821, 113)
			panelSetting.Location = point
			Me.panelSetting.Name = "panelSetting"
			Dim panelSetting2 As Global.System.Windows.Forms.Control = Me.panelSetting
			size = New Global.System.Drawing.Size(246, 150)
			panelSetting2.Size = size
			Me.panelSetting.TabIndex = 735
			Me.lblSetting.AutoSize = True
			Me.lblSetting.Font = New Global.System.Drawing.Font("Lucida Fax", 14.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.lblSetting.ForeColor = Global.System.Drawing.Color.Black
			Dim lblSetting As Global.System.Windows.Forms.Control = Me.lblSetting
			point = New Global.System.Drawing.Point(1, 3)
			lblSetting.Location = point
			Me.lblSetting.Name = "lblSetting"
			Dim lblSetting2 As Global.System.Windows.Forms.Control = Me.lblSetting
			size = New Global.System.Drawing.Size(80, 22)
			lblSetting2.Size = size
			Me.lblSetting.TabIndex = 637
			Me.lblSetting.Text = "Setting"
			Me.Label73.AutoSize = True
			Me.Label73.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 9.75F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 222)
			Me.Label73.ForeColor = Global.System.Drawing.Color.Black
			Dim label As Global.System.Windows.Forms.Control = Me.Label73
			point = New Global.System.Drawing.Point(177, 129)
			label.Location = point
			Me.Label73.Name = "Label73"
			Dim label2 As Global.System.Windows.Forms.Control = Me.Label73
			size = New Global.System.Drawing.Size(12, 16)
			label2.Size = size
			Me.Label73.TabIndex = 636
			Me.Label73.Text = ":"
			Me.comboMinShutdown.FormattingEnabled = True
			Me.comboMinShutdown.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60" })
			Dim comboMinShutdown As Global.System.Windows.Forms.Control = Me.comboMinShutdown
			point = New Global.System.Drawing.Point(189, 127)
			comboMinShutdown.Location = point
			Me.comboMinShutdown.Name = "comboMinShutdown"
			Dim comboMinShutdown2 As Global.System.Windows.Forms.Control = Me.comboMinShutdown
			size = New Global.System.Drawing.Size(40, 21)
			comboMinShutdown2.Size = size
			Me.comboMinShutdown.TabIndex = 635
			Me.comboHourShutdown.FormattingEnabled = True
			Me.comboHourShutdown.Items.AddRange(New Object() { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" })
			Dim comboHourShutdown As Global.System.Windows.Forms.Control = Me.comboHourShutdown
			point = New Global.System.Drawing.Point(136, 127)
			comboHourShutdown.Location = point
			Me.comboHourShutdown.Name = "comboHourShutdown"
			Dim comboHourShutdown2 As Global.System.Windows.Forms.Control = Me.comboHourShutdown
			size = New Global.System.Drawing.Size(40, 21)
			comboHourShutdown2.Size = size
			Me.comboHourShutdown.TabIndex = 634
			Me.ckShutDown.AutoSize = True
			Me.ckShutDown.BackColor = Global.System.Drawing.Color.Transparent
			Me.ckShutDown.Font = New Global.System.Drawing.Font("Lucida Bright", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 0)
			Me.ckShutDown.ForeColor = Global.System.Drawing.Color.Black
			Dim ckShutDown As Global.System.Windows.Forms.Control = Me.ckShutDown
			point = New Global.System.Drawing.Point(10, 129)
			ckShutDown.Location = point
			Me.ckShutDown.Name = "ckShutDown"
			Dim ckShutDown2 As Global.System.Windows.Forms.Control = Me.ckShutDown
			size = New Global.System.Drawing.Size(107, 18)
			ckShutDown2.Size = size
			Me.ckShutDown.TabIndex = 633
			Me.ckShutDown.Text = "ปิดคอมฯ อัตโนมัติ"
			Me.ckShutDown.UseVisualStyleBackColor = False
			Me.chkEng.AutoSize = True
			Me.chkEng.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkEng.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Me.chkEng.ForeColor = Global.System.Drawing.Color.Black
			Dim chkEng As Global.System.Windows.Forms.Control = Me.chkEng
			point = New Global.System.Drawing.Point(12, 69)
			chkEng.Location = point
			Me.chkEng.Name = "chkEng"
			Dim chkEng2 As Global.System.Windows.Forms.Control = Me.chkEng
			size = New Global.System.Drawing.Size(59, 17)
			chkEng2.Size = size
			Me.chkEng.TabIndex = 632
			Me.chkEng.Text = "อังกฤษ"
			Me.chkEng.UseVisualStyleBackColor = False
			Me.btnPlaySound.Image = CType(resources.GetObject("btnPlaySound.Image"), Global.System.Drawing.Image)
			Dim btnPlaySound As Global.System.Windows.Forms.Control = Me.btnPlaySound
			point = New Global.System.Drawing.Point(204, 47)
			btnPlaySound.Location = point
			Me.btnPlaySound.Name = "btnPlaySound"
			Dim btnPlaySound2 As Global.System.Windows.Forms.Control = Me.btnPlaySound
			size = New Global.System.Drawing.Size(31, 32)
			btnPlaySound2.Size = size
			Me.btnPlaySound.TabIndex = 630
			Me.btnPlaySound.UseVisualStyleBackColor = True
			Me.lblAlarm.AutoSize = True
			Me.lblAlarm.BackColor = Global.System.Drawing.Color.Transparent
			Me.lblAlarm.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 222)
			Me.lblAlarm.ForeColor = Global.System.Drawing.Color.Black
			Dim lblAlarm As Global.System.Windows.Forms.Control = Me.lblAlarm
			point = New Global.System.Drawing.Point(133, 29)
			lblAlarm.Location = point
			Me.lblAlarm.Name = "lblAlarm"
			Dim lblAlarm2 As Global.System.Windows.Forms.Control = Me.lblAlarm
			size = New Global.System.Drawing.Size(56, 13)
			lblAlarm2.Size = size
			Me.lblAlarm.TabIndex = 629
			Me.lblAlarm.Text = "เสียงออด"
			Me.listSoundBell.FormattingEnabled = True
			Me.listSoundBell.Items.AddRange(New Object() { "sound01", "sound02", "sound03", "sound04", "sound05" })
			Dim listSoundBell As Global.System.Windows.Forms.Control = Me.listSoundBell
			point = New Global.System.Drawing.Point(136, 48)
			listSoundBell.Location = point
			Me.listSoundBell.Name = "listSoundBell"
			Dim listSoundBell2 As Global.System.Windows.Forms.Control = Me.listSoundBell
			size = New Global.System.Drawing.Size(63, 69)
			listSoundBell2.Size = size
			Me.listSoundBell.TabIndex = 628
			Me.chkThai.AutoSize = True
			Me.chkThai.BackColor = Global.System.Drawing.Color.Transparent
			Me.chkThai.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Regular, Global.System.Drawing.GraphicsUnit.Point, 222)
			Me.chkThai.ForeColor = Global.System.Drawing.Color.Black
			Dim chkThai As Global.System.Windows.Forms.Control = Me.chkThai
			point = New Global.System.Drawing.Point(12, 48)
			chkThai.Location = point
			Me.chkThai.Name = "chkThai"
			Dim chkThai2 As Global.System.Windows.Forms.Control = Me.chkThai
			size = New Global.System.Drawing.Size(46, 17)
			chkThai2.Size = size
			Me.chkThai.TabIndex = 627
			Me.chkThai.Text = "ไทย"
			Me.chkThai.UseVisualStyleBackColor = False
			Me.lblLang.AutoSize = True
			Me.lblLang.BackColor = Global.System.Drawing.Color.Transparent
			Me.lblLang.Font = New Global.System.Drawing.Font("Microsoft Sans Serif", 8.25F, Global.System.Drawing.FontStyle.Bold, Global.System.Drawing.GraphicsUnit.Point, 222)
			Me.lblLang.ForeColor = Global.System.Drawing.Color.Black
			Dim lblLang As Global.System.Windows.Forms.Control = Me.lblLang
			point = New Global.System.Drawing.Point(7, 29)
			lblLang.Location = point
			Me.lblLang.Name = "lblLang"
			Dim lblLang2 As Global.System.Windows.Forms.Control = Me.lblLang
			size = New Global.System.Drawing.Size(36, 13)
			lblLang2.Size = size
			Me.lblLang.TabIndex = 626
			Me.lblLang.Text = "ภาษา"
			Dim sizeF As Global.System.Drawing.SizeF = New Global.System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleDimensions = sizeF
			Me.AutoScaleMode = Global.System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = Global.System.Drawing.Color.White
			size = New Global.System.Drawing.Size(1075, 681)
			Me.ClientSize = size
			Me.Controls.Add(Me.panelSetting)
			Me.Controls.Add(Me.PanelTime)
			Me.Controls.Add(Me.panelAllDay)
			Me.Controls.Add(Me.PanelEachDay)
			Me.Controls.Add(Me.lblWarning)
			Me.Controls.Add(Me.btnPayment)
			Me.Controls.Add(Me.lblPayment)
			Me.Controls.Add(Me.lblCD)
			Me.Controls.Add(Me.lblCanUse)
			Me.Controls.Add(Me.lblLanguage)
			Me.Controls.Add(Me.listLangDisplay)
			Me.Controls.Add(Me.PictureBox1)
			Me.Controls.Add(Me.im05)
			Me.Controls.Add(Me.lblReset)
			Me.Controls.Add(Me.lblCancel)
			Me.Controls.Add(Me.lblSave)
			Me.Controls.Add(Me.lblEdit)
			Me.Controls.Add(Me.lblTopic2)
			Me.Controls.Add(Me.lblDev)
			Me.Controls.Add(Me.lblRemark)
			Me.Controls.Add(Me.lblCopyright)
			Me.Controls.Add(Me.btnReset)
			Me.Controls.Add(Me.lblP)
			Me.Controls.Add(Me.lblTopic1)
			Me.Controls.Add(Me.btnCancel)
			Me.Controls.Add(Me.lblPath)
			Me.Controls.Add(Me.btnExit)
			Me.Controls.Add(Me.btnEdit)
			Me.Controls.Add(Me.btnSave)
			Me.Controls.Add(Me.lblTimeShow)
			Me.ForeColor = Global.System.Drawing.SystemColors.ControlText
			Me.MaximizeBox = False
			Me.Name = "Form1"
			Me.Text = "School Telling Time โปรแกรมบอกเวลาโรงเรียน"
			CType(Me.PictureBox1, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.PanelEachDay.ResumeLayout(False)
			Me.PanelEachDay.PerformLayout()
			Me.panelAllDay.ResumeLayout(False)
			Me.panelAllDay.PerformLayout()
			Me.PanelTime.ResumeLayout(False)
			Me.PanelTime.PerformLayout()
			CType(Me.PictureBox3, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.PictureBox2, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.PictureBox6, Global.System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.PictureBox7, Global.System.ComponentModel.ISupportInitialize).EndInit()
			Me.panelSetting.ResumeLayout(False)
			Me.panelSetting.PerformLayout()
			Me.ResumeLayout(False)
			Me.PerformLayout()
		End Sub

		' Token: 0x0400000E RID: 14
		Private components As Global.System.ComponentModel.IContainer
	End Class
End Namespace
