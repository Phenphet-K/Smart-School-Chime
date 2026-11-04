Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data.OleDb
Imports System.Diagnostics
Imports System.Drawing
Imports System.IO
Imports System.Runtime.CompilerServices
Imports System.Threading
Imports System.Windows.Forms
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices
Imports SchoolTellingTime.My

Namespace SchoolTellingTime
	' Token: 0x0200000A RID: 10
	<DesignerGenerated()>
	Public Partial Class Form1
		Inherits Form

		' Token: 0x0600002F RID: 47 RVA: 0x00002CB8 File Offset: 0x000010B8
		<DebuggerNonUserCode()>
		Public Sub New()
			AddHandler MyBase.Load, AddressOf Me.Form1_Load
			Form1.__ENCAddToList(Me)
			Me.InitializeComponent()
		End Sub

		' Token: 0x06000030 RID: 48 RVA: 0x00002CE4 File Offset: 0x000010E4
		<DebuggerNonUserCode()>
		Private Shared Sub __ENCAddToList(value As Object)
			Dim _ENCList As List(Of WeakReference) = Form1.__ENCList
			Dim flag As Boolean = False
			Try
				Monitor.Enter(_ENCList, flag)
				Dim flag2 As Boolean = Form1.__ENCList.Count = Form1.__ENCList.Capacity
				If flag2 Then
					Dim num As Integer = 0
					Dim num2 As Integer = 0
					Dim num3 As Integer = Form1.__ENCList.Count - 1
					Dim num4 As Integer = num2
					While True
						Dim num5 As Integer = num4
						Dim num6 As Integer = num3
						If num5 > num6 Then
							Exit For
						End If
						Dim weakReference As WeakReference = Form1.__ENCList(num4)
						flag2 = weakReference.IsAlive
						If flag2 Then
							Dim flag3 As Boolean = num4 <> num
							If flag3 Then
								Form1.__ENCList(num) = Form1.__ENCList(num4)
							End If
							num += 1
						End If
						num4 += 1
					End While
					Form1.__ENCList.RemoveRange(num, Form1.__ENCList.Count - num)
					Form1.__ENCList.Capacity = Form1.__ENCList.Count
				End If
				Form1.__ENCList.Add(New WeakReference(RuntimeHelpers.GetObjectValue(value)))
			Finally
				Dim flag3 As Boolean = flag
				If flag3 Then
					Monitor.[Exit](_ENCList)
				End If
			End Try
		End Sub

		' Token: 0x1700000B RID: 11
		' (get) Token: 0x06000033 RID: 51 RVA: 0x000160E4 File Offset: 0x000144E4
		' (set) Token: 0x06000034 RID: 52 RVA: 0x000160FC File Offset: 0x000144FC
		Friend Overridable Property Timer1 As Global.System.Windows.Forms.Timer
			<DebuggerNonUserCode()>
			Get
				Return Me._Timer1
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Global.System.Windows.Forms.Timer)
				Dim eventHandler As EventHandler = AddressOf Me.Timer1_Tick
				Dim flag As Boolean = Me._Timer1 IsNot Nothing
				If flag Then
					RemoveHandler Me._Timer1.Tick, eventHandler
				End If
				Me._Timer1 = value
				flag = Me._Timer1 IsNot Nothing
				If flag Then
					AddHandler Me._Timer1.Tick, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700000C RID: 12
		' (get) Token: 0x06000035 RID: 53 RVA: 0x0001615C File Offset: 0x0001455C
		' (set) Token: 0x06000036 RID: 54 RVA: 0x00016174 File Offset: 0x00014574
		Friend Overridable Property lblTimeShow As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lblTimeShow
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lblTimeShow = value
			End Set
		End Property

		' Token: 0x1700000D RID: 13
		' (get) Token: 0x06000037 RID: 55 RVA: 0x00016180 File Offset: 0x00014580
		' (set) Token: 0x06000038 RID: 56 RVA: 0x00016198 File Offset: 0x00014598
		Friend Overridable Property OpenFileDialog1 As OpenFileDialog
			<DebuggerNonUserCode()>
			Get
				Return Me._OpenFileDialog1
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As OpenFileDialog)
				Me._OpenFileDialog1 = value
			End Set
		End Property

		' Token: 0x1700000E RID: 14
		' (get) Token: 0x06000039 RID: 57 RVA: 0x000161A4 File Offset: 0x000145A4
		' (set) Token: 0x0600003A RID: 58 RVA: 0x000161BC File Offset: 0x000145BC
		Friend Overridable Property btnSave As Button
			<DebuggerNonUserCode()>
			Get
				Return Me._btnSave
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnSave_Click
				Dim flag As Boolean = Me._btnSave IsNot Nothing
				If flag Then
					RemoveHandler Me._btnSave.Click, eventHandler
				End If
				Me._btnSave = value
				flag = Me._btnSave IsNot Nothing
				If flag Then
					AddHandler Me._btnSave.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700000F RID: 15
		' (get) Token: 0x0600003B RID: 59 RVA: 0x0001621C File Offset: 0x0001461C
		' (set) Token: 0x0600003C RID: 60 RVA: 0x00016234 File Offset: 0x00014634
		Friend Overridable Property btnEdit As Button
			<DebuggerNonUserCode()>
			Get
				Return Me._btnEdit
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnEdit_Click
				Dim flag As Boolean = Me._btnEdit IsNot Nothing
				If flag Then
					RemoveHandler Me._btnEdit.Click, eventHandler
				End If
				Me._btnEdit = value
				flag = Me._btnEdit IsNot Nothing
				If flag Then
					AddHandler Me._btnEdit.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000010 RID: 16
		' (get) Token: 0x0600003D RID: 61 RVA: 0x00016294 File Offset: 0x00014694
		' (set) Token: 0x0600003E RID: 62 RVA: 0x000162AC File Offset: 0x000146AC
		Friend Overridable Property btnExit As Button
			<DebuggerNonUserCode()>
			Get
				Return Me._btnExit
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnExit_Click
				Dim flag As Boolean = Me._btnExit IsNot Nothing
				If flag Then
					RemoveHandler Me._btnExit.Click, eventHandler
				End If
				Me._btnExit = value
				flag = Me._btnExit IsNot Nothing
				If flag Then
					AddHandler Me._btnExit.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000011 RID: 17
		' (get) Token: 0x0600003F RID: 63 RVA: 0x0001630C File Offset: 0x0001470C
		' (set) Token: 0x06000040 RID: 64 RVA: 0x00016324 File Offset: 0x00014724
		Friend Overridable Property Timer2 As Global.System.Windows.Forms.Timer
			<DebuggerNonUserCode()>
			Get
				Return Me._Timer2
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Global.System.Windows.Forms.Timer)
				Dim eventHandler As EventHandler = AddressOf Me.Timer2_Tick
				Dim flag As Boolean = Me._Timer2 IsNot Nothing
				If flag Then
					RemoveHandler Me._Timer2.Tick, eventHandler
				End If
				Me._Timer2 = value
				flag = Me._Timer2 IsNot Nothing
				If flag Then
					AddHandler Me._Timer2.Tick, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000012 RID: 18
		' (get) Token: 0x06000041 RID: 65 RVA: 0x00016384 File Offset: 0x00014784
		' (set) Token: 0x06000042 RID: 66 RVA: 0x0001639C File Offset: 0x0001479C
		Friend Overridable Property lblPath As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lblPath
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lblPath = value
			End Set
		End Property

		' Token: 0x17000013 RID: 19
		' (get) Token: 0x06000043 RID: 67 RVA: 0x000163A8 File Offset: 0x000147A8
		' (set) Token: 0x06000044 RID: 68 RVA: 0x000163C0 File Offset: 0x000147C0
		Friend Overridable Property btnCancel As Button
			<DebuggerNonUserCode()>
			Get
				Return Me._btnCancel
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnCancel_Click
				Dim flag As Boolean = Me._btnCancel IsNot Nothing
				If flag Then
					RemoveHandler Me._btnCancel.Click, eventHandler
				End If
				Me._btnCancel = value
				flag = Me._btnCancel IsNot Nothing
				If flag Then
					AddHandler Me._btnCancel.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000014 RID: 20
		' (get) Token: 0x06000045 RID: 69 RVA: 0x00016420 File Offset: 0x00014820
		' (set) Token: 0x06000046 RID: 70 RVA: 0x00016438 File Offset: 0x00014838
		Friend Overridable Property lblTopic2 As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lblTopic2
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lblTopic2 = value
			End Set
		End Property

		' Token: 0x17000015 RID: 21
		' (get) Token: 0x06000047 RID: 71 RVA: 0x00016444 File Offset: 0x00014844
		' (set) Token: 0x06000048 RID: 72 RVA: 0x0001645C File Offset: 0x0001485C
		Friend Overridable Property lblP As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lblP
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lblP = value
			End Set
		End Property

		' Token: 0x17000016 RID: 22
		' (get) Token: 0x06000049 RID: 73 RVA: 0x00016468 File Offset: 0x00014868
		' (set) Token: 0x0600004A RID: 74 RVA: 0x00016480 File Offset: 0x00014880
		Friend Overridable Property btnReset As Button
			<DebuggerNonUserCode()>
			Get
				Return Me._btnReset
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnReset_Click
				Dim flag As Boolean = Me._btnReset IsNot Nothing
				If flag Then
					RemoveHandler Me._btnReset.Click, eventHandler
				End If
				Me._btnReset = value
				flag = Me._btnReset IsNot Nothing
				If flag Then
					AddHandler Me._btnReset.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000017 RID: 23
		' (get) Token: 0x0600004B RID: 75 RVA: 0x000164E0 File Offset: 0x000148E0
		' (set) Token: 0x0600004C RID: 76 RVA: 0x000164F8 File Offset: 0x000148F8
		Friend Overridable Property lblCopyright As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lblCopyright
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lblCopyright = value
			End Set
		End Property

		' Token: 0x17000018 RID: 24
		' (get) Token: 0x0600004D RID: 77 RVA: 0x00016504 File Offset: 0x00014904
		' (set) Token: 0x0600004E RID: 78 RVA: 0x0001651C File Offset: 0x0001491C
		Friend Overridable Property lblTopic1 As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lblTopic1
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lblTopic1 = value
			End Set
		End Property

		' Token: 0x17000019 RID: 25
		' (get) Token: 0x0600004F RID: 79 RVA: 0x00016528 File Offset: 0x00014928
		' (set) Token: 0x06000050 RID: 80 RVA: 0x00016540 File Offset: 0x00014940
		Friend Overridable Property lblRemark As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lblRemark
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lblRemark = value
			End Set
		End Property

		' Token: 0x1700001A RID: 26
		' (get) Token: 0x06000051 RID: 81 RVA: 0x0001654C File Offset: 0x0001494C
		' (set) Token: 0x06000052 RID: 82 RVA: 0x00016564 File Offset: 0x00014964
		Friend Overridable Property lblEdit As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lblEdit
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lblEdit = value
			End Set
		End Property

		' Token: 0x1700001B RID: 27
		' (get) Token: 0x06000053 RID: 83 RVA: 0x00016570 File Offset: 0x00014970
		' (set) Token: 0x06000054 RID: 84 RVA: 0x00016588 File Offset: 0x00014988
		Friend Overridable Property lblSave As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lblSave
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lblSave = value
			End Set
		End Property

		' Token: 0x1700001C RID: 28
		' (get) Token: 0x06000055 RID: 85 RVA: 0x00016594 File Offset: 0x00014994
		' (set) Token: 0x06000056 RID: 86 RVA: 0x000165AC File Offset: 0x000149AC
		Friend Overridable Property lblCancel As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lblCancel
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lblCancel = value
			End Set
		End Property

		' Token: 0x1700001D RID: 29
		' (get) Token: 0x06000057 RID: 87 RVA: 0x000165B8 File Offset: 0x000149B8
		' (set) Token: 0x06000058 RID: 88 RVA: 0x000165D0 File Offset: 0x000149D0
		Friend Overridable Property lblReset As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lblReset
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lblReset = value
			End Set
		End Property

		' Token: 0x1700001E RID: 30
		' (get) Token: 0x06000059 RID: 89 RVA: 0x000165DC File Offset: 0x000149DC
		' (set) Token: 0x0600005A RID: 90 RVA: 0x000165F4 File Offset: 0x000149F4
		Friend Overridable Property im05 As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._im05
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._im05 = value
			End Set
		End Property

		' Token: 0x1700001F RID: 31
		' (get) Token: 0x0600005B RID: 91 RVA: 0x00016600 File Offset: 0x00014A00
		' (set) Token: 0x0600005C RID: 92 RVA: 0x00016618 File Offset: 0x00014A18
		Friend Overridable Property PictureBox1 As PictureBox
			<DebuggerNonUserCode()>
			Get
				Return Me._PictureBox1
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As PictureBox)
				Me._PictureBox1 = value
			End Set
		End Property

		' Token: 0x17000020 RID: 32
		' (get) Token: 0x0600005D RID: 93 RVA: 0x00016624 File Offset: 0x00014A24
		' (set) Token: 0x0600005E RID: 94 RVA: 0x0001663C File Offset: 0x00014A3C
		Friend Overridable Property listLangDisplay As ListBox
			<DebuggerNonUserCode()>
			Get
				Return Me._listLangDisplay
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ListBox)
				Dim eventHandler As EventHandler = AddressOf Me.ListBox1_SelectedIndexChanged
				Dim flag As Boolean = Me._listLangDisplay IsNot Nothing
				If flag Then
					RemoveHandler Me._listLangDisplay.SelectedIndexChanged, eventHandler
				End If
				Me._listLangDisplay = value
				flag = Me._listLangDisplay IsNot Nothing
				If flag Then
					AddHandler Me._listLangDisplay.SelectedIndexChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000021 RID: 33
		' (get) Token: 0x0600005F RID: 95 RVA: 0x0001669C File Offset: 0x00014A9C
		' (set) Token: 0x06000060 RID: 96 RVA: 0x000166B4 File Offset: 0x00014AB4
		Friend Overridable Property lblLanguage As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lblLanguage
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lblLanguage = value
			End Set
		End Property

		' Token: 0x17000022 RID: 34
		' (get) Token: 0x06000061 RID: 97 RVA: 0x000166C0 File Offset: 0x00014AC0
		' (set) Token: 0x06000062 RID: 98 RVA: 0x000166D8 File Offset: 0x00014AD8
		Friend Overridable Property lblCanUse As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lblCanUse
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lblCanUse = value
			End Set
		End Property

		' Token: 0x17000023 RID: 35
		' (get) Token: 0x06000063 RID: 99 RVA: 0x000166E4 File Offset: 0x00014AE4
		' (set) Token: 0x06000064 RID: 100 RVA: 0x000166FC File Offset: 0x00014AFC
		Friend Overridable Property lblCD As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lblCD
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lblCD = value
			End Set
		End Property

		' Token: 0x17000024 RID: 36
		' (get) Token: 0x06000065 RID: 101 RVA: 0x00016708 File Offset: 0x00014B08
		' (set) Token: 0x06000066 RID: 102 RVA: 0x00016720 File Offset: 0x00014B20
		Friend Overridable Property lblPayment As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lblPayment
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lblPayment = value
			End Set
		End Property

		' Token: 0x17000025 RID: 37
		' (get) Token: 0x06000067 RID: 103 RVA: 0x0001672C File Offset: 0x00014B2C
		' (set) Token: 0x06000068 RID: 104 RVA: 0x00016744 File Offset: 0x00014B44
		Friend Overridable Property btnPayment As Button
			<DebuggerNonUserCode()>
			Get
				Return Me._btnPayment
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnPayment_Click
				Dim flag As Boolean = Me._btnPayment IsNot Nothing
				If flag Then
					RemoveHandler Me._btnPayment.Click, eventHandler
				End If
				Me._btnPayment = value
				flag = Me._btnPayment IsNot Nothing
				If flag Then
					AddHandler Me._btnPayment.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000026 RID: 38
		' (get) Token: 0x06000069 RID: 105 RVA: 0x000167A4 File Offset: 0x00014BA4
		' (set) Token: 0x0600006A RID: 106 RVA: 0x000167BC File Offset: 0x00014BBC
		Friend Overridable Property lblDev As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lblDev
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lblDev = value
			End Set
		End Property

		' Token: 0x17000027 RID: 39
		' (get) Token: 0x0600006B RID: 107 RVA: 0x000167C8 File Offset: 0x00014BC8
		' (set) Token: 0x0600006C RID: 108 RVA: 0x000167E0 File Offset: 0x00014BE0
		Friend Overridable Property lblWarning As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lblWarning
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lblWarning = value
			End Set
		End Property

		' Token: 0x17000028 RID: 40
		' (get) Token: 0x0600006D RID: 109 RVA: 0x000167EC File Offset: 0x00014BEC
		' (set) Token: 0x0600006E RID: 110 RVA: 0x00016804 File Offset: 0x00014C04
		Friend Overridable Property PanelEachDay As Panel
			<DebuggerNonUserCode()>
			Get
				Return Me._PanelEachDay
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Panel)
				Me._PanelEachDay = value
			End Set
		End Property

		' Token: 0x17000029 RID: 41
		' (get) Token: 0x0600006F RID: 111 RVA: 0x00016810 File Offset: 0x00014C10
		' (set) Token: 0x06000070 RID: 112 RVA: 0x00016828 File Offset: 0x00014C28
		Friend Overridable Property radioFri As RadioButton
			<DebuggerNonUserCode()>
			Get
				Return Me._radioFri
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim eventHandler As EventHandler = AddressOf Me.radioFri_CheckedChanged
				Dim flag As Boolean = Me._radioFri IsNot Nothing
				If flag Then
					RemoveHandler Me._radioFri.CheckedChanged, eventHandler
				End If
				Me._radioFri = value
				flag = Me._radioFri IsNot Nothing
				If flag Then
					AddHandler Me._radioFri.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700002A RID: 42
		' (get) Token: 0x06000071 RID: 113 RVA: 0x00016888 File Offset: 0x00014C88
		' (set) Token: 0x06000072 RID: 114 RVA: 0x000168A0 File Offset: 0x00014CA0
		Friend Overridable Property radioThu As RadioButton
			<DebuggerNonUserCode()>
			Get
				Return Me._radioThu
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim eventHandler As EventHandler = AddressOf Me.radioThu_CheckedChanged
				Dim flag As Boolean = Me._radioThu IsNot Nothing
				If flag Then
					RemoveHandler Me._radioThu.CheckedChanged, eventHandler
				End If
				Me._radioThu = value
				flag = Me._radioThu IsNot Nothing
				If flag Then
					AddHandler Me._radioThu.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700002B RID: 43
		' (get) Token: 0x06000073 RID: 115 RVA: 0x00016900 File Offset: 0x00014D00
		' (set) Token: 0x06000074 RID: 116 RVA: 0x00016918 File Offset: 0x00014D18
		Friend Overridable Property radioWed As RadioButton
			<DebuggerNonUserCode()>
			Get
				Return Me._radioWed
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim eventHandler As EventHandler = AddressOf Me.radioWed_CheckedChanged
				Dim flag As Boolean = Me._radioWed IsNot Nothing
				If flag Then
					RemoveHandler Me._radioWed.CheckedChanged, eventHandler
				End If
				Me._radioWed = value
				flag = Me._radioWed IsNot Nothing
				If flag Then
					AddHandler Me._radioWed.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700002C RID: 44
		' (get) Token: 0x06000075 RID: 117 RVA: 0x00016978 File Offset: 0x00014D78
		' (set) Token: 0x06000076 RID: 118 RVA: 0x00016990 File Offset: 0x00014D90
		Friend Overridable Property radioTue As RadioButton
			<DebuggerNonUserCode()>
			Get
				Return Me._radioTue
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim eventHandler As EventHandler = AddressOf Me.radioTue_CheckedChanged
				Dim flag As Boolean = Me._radioTue IsNot Nothing
				If flag Then
					RemoveHandler Me._radioTue.CheckedChanged, eventHandler
				End If
				Me._radioTue = value
				flag = Me._radioTue IsNot Nothing
				If flag Then
					AddHandler Me._radioTue.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700002D RID: 45
		' (get) Token: 0x06000077 RID: 119 RVA: 0x000169F0 File Offset: 0x00014DF0
		' (set) Token: 0x06000078 RID: 120 RVA: 0x00016A08 File Offset: 0x00014E08
		Friend Overridable Property radioSat As RadioButton
			<DebuggerNonUserCode()>
			Get
				Return Me._radioSat
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim eventHandler As EventHandler = AddressOf Me.radioSat_CheckedChanged
				Dim flag As Boolean = Me._radioSat IsNot Nothing
				If flag Then
					RemoveHandler Me._radioSat.CheckedChanged, eventHandler
				End If
				Me._radioSat = value
				flag = Me._radioSat IsNot Nothing
				If flag Then
					AddHandler Me._radioSat.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700002E RID: 46
		' (get) Token: 0x06000079 RID: 121 RVA: 0x00016A68 File Offset: 0x00014E68
		' (set) Token: 0x0600007A RID: 122 RVA: 0x00016A80 File Offset: 0x00014E80
		Friend Overridable Property radioSun As RadioButton
			<DebuggerNonUserCode()>
			Get
				Return Me._radioSun
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim eventHandler As EventHandler = AddressOf Me.radioSun_CheckedChanged
				Dim flag As Boolean = Me._radioSun IsNot Nothing
				If flag Then
					RemoveHandler Me._radioSun.CheckedChanged, eventHandler
				End If
				Me._radioSun = value
				flag = Me._radioSun IsNot Nothing
				If flag Then
					AddHandler Me._radioSun.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700002F RID: 47
		' (get) Token: 0x0600007B RID: 123 RVA: 0x00016AE0 File Offset: 0x00014EE0
		' (set) Token: 0x0600007C RID: 124 RVA: 0x00016AF8 File Offset: 0x00014EF8
		Friend Overridable Property radioMon As RadioButton
			<DebuggerNonUserCode()>
			Get
				Return Me._radioMon
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim eventHandler As EventHandler = AddressOf Me.radioMon_CheckedChanged
				Dim flag As Boolean = Me._radioMon IsNot Nothing
				If flag Then
					RemoveHandler Me._radioMon.CheckedChanged, eventHandler
				End If
				Me._radioMon = value
				flag = Me._radioMon IsNot Nothing
				If flag Then
					AddHandler Me._radioMon.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000030 RID: 48
		' (get) Token: 0x0600007D RID: 125 RVA: 0x00016B58 File Offset: 0x00014F58
		' (set) Token: 0x0600007E RID: 126 RVA: 0x00016B70 File Offset: 0x00014F70
		Friend Overridable Property lblToday As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lblToday
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lblToday = value
			End Set
		End Property

		' Token: 0x17000031 RID: 49
		' (get) Token: 0x0600007F RID: 127 RVA: 0x00016B7C File Offset: 0x00014F7C
		' (set) Token: 0x06000080 RID: 128 RVA: 0x00016B94 File Offset: 0x00014F94
		Friend Overridable Property radioAllDay As RadioButton
			<DebuggerNonUserCode()>
			Get
				Return Me._radioAllDay
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim eventHandler As EventHandler = AddressOf Me.radioAllDay_CheckedChanged
				Dim flag As Boolean = Me._radioAllDay IsNot Nothing
				If flag Then
					RemoveHandler Me._radioAllDay.CheckedChanged, eventHandler
				End If
				Me._radioAllDay = value
				flag = Me._radioAllDay IsNot Nothing
				If flag Then
					AddHandler Me._radioAllDay.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000032 RID: 50
		' (get) Token: 0x06000081 RID: 129 RVA: 0x00016BF4 File Offset: 0x00014FF4
		' (set) Token: 0x06000082 RID: 130 RVA: 0x00016C0C File Offset: 0x0001500C
		Friend Overridable Property panelAllDay As Panel
			<DebuggerNonUserCode()>
			Get
				Return Me._panelAllDay
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Panel)
				Me._panelAllDay = value
			End Set
		End Property

		' Token: 0x17000033 RID: 51
		' (get) Token: 0x06000083 RID: 131 RVA: 0x00016C18 File Offset: 0x00015018
		' (set) Token: 0x06000084 RID: 132 RVA: 0x00016C30 File Offset: 0x00015030
		Friend Overridable Property radioEachDay As RadioButton
			<DebuggerNonUserCode()>
			Get
				Return Me._radioEachDay
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As RadioButton)
				Dim eventHandler As EventHandler = AddressOf Me.radioEachDay_CheckedChanged
				Dim flag As Boolean = Me._radioEachDay IsNot Nothing
				If flag Then
					RemoveHandler Me._radioEachDay.CheckedChanged, eventHandler
				End If
				Me._radioEachDay = value
				flag = Me._radioEachDay IsNot Nothing
				If flag Then
					AddHandler Me._radioEachDay.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000034 RID: 52
		' (get) Token: 0x06000085 RID: 133 RVA: 0x00016C90 File Offset: 0x00015090
		' (set) Token: 0x06000086 RID: 134 RVA: 0x00016CA8 File Offset: 0x000150A8
		Friend Overridable Property PanelTime As Panel
			<DebuggerNonUserCode()>
			Get
				Return Me._PanelTime
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Panel)
				Me._PanelTime = value
			End Set
		End Property

		' Token: 0x17000035 RID: 53
		' (get) Token: 0x06000087 RID: 135 RVA: 0x00016CB4 File Offset: 0x000150B4
		' (set) Token: 0x06000088 RID: 136 RVA: 0x00016CCC File Offset: 0x000150CC
		Friend Overridable Property lbl22 As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lbl22
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lbl22 = value
			End Set
		End Property

		' Token: 0x17000036 RID: 54
		' (get) Token: 0x06000089 RID: 137 RVA: 0x00016CD8 File Offset: 0x000150D8
		' (set) Token: 0x0600008A RID: 138 RVA: 0x00016CF0 File Offset: 0x000150F0
		Friend Overridable Property lbl23 As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lbl23
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lbl23 = value
			End Set
		End Property

		' Token: 0x17000037 RID: 55
		' (get) Token: 0x0600008B RID: 139 RVA: 0x00016CFC File Offset: 0x000150FC
		' (set) Token: 0x0600008C RID: 140 RVA: 0x00016D14 File Offset: 0x00015114
		Friend Overridable Property lbl24 As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lbl24
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lbl24 = value
			End Set
		End Property

		' Token: 0x17000038 RID: 56
		' (get) Token: 0x0600008D RID: 141 RVA: 0x00016D20 File Offset: 0x00015120
		' (set) Token: 0x0600008E RID: 142 RVA: 0x00016D38 File Offset: 0x00015138
		Friend Overridable Property lbl17 As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lbl17
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lbl17 = value
			End Set
		End Property

		' Token: 0x17000039 RID: 57
		' (get) Token: 0x0600008F RID: 143 RVA: 0x00016D44 File Offset: 0x00015144
		' (set) Token: 0x06000090 RID: 144 RVA: 0x00016D5C File Offset: 0x0001515C
		Friend Overridable Property lbl18 As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lbl18
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lbl18 = value
			End Set
		End Property

		' Token: 0x1700003A RID: 58
		' (get) Token: 0x06000091 RID: 145 RVA: 0x00016D68 File Offset: 0x00015168
		' (set) Token: 0x06000092 RID: 146 RVA: 0x00016D80 File Offset: 0x00015180
		Friend Overridable Property lbl19 As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lbl19
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lbl19 = value
			End Set
		End Property

		' Token: 0x1700003B RID: 59
		' (get) Token: 0x06000093 RID: 147 RVA: 0x00016D8C File Offset: 0x0001518C
		' (set) Token: 0x06000094 RID: 148 RVA: 0x00016DA4 File Offset: 0x000151A4
		Friend Overridable Property lbl20 As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lbl20
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lbl20 = value
			End Set
		End Property

		' Token: 0x1700003C RID: 60
		' (get) Token: 0x06000095 RID: 149 RVA: 0x00016DB0 File Offset: 0x000151B0
		' (set) Token: 0x06000096 RID: 150 RVA: 0x00016DC8 File Offset: 0x000151C8
		Friend Overridable Property lbl21 As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lbl21
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lbl21 = value
			End Set
		End Property

		' Token: 0x1700003D RID: 61
		' (get) Token: 0x06000097 RID: 151 RVA: 0x00016DD4 File Offset: 0x000151D4
		' (set) Token: 0x06000098 RID: 152 RVA: 0x00016DEC File Offset: 0x000151EC
		Friend Overridable Property chkFirst24 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkFirst24
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkFirst24 = value
			End Set
		End Property

		' Token: 0x1700003E RID: 62
		' (get) Token: 0x06000099 RID: 153 RVA: 0x00016DF8 File Offset: 0x000151F8
		' (set) Token: 0x0600009A RID: 154 RVA: 0x00016E10 File Offset: 0x00015210
		Friend Overridable Property chkLast24 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkLast24
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkLast24 = value
			End Set
		End Property

		' Token: 0x1700003F RID: 63
		' (get) Token: 0x0600009B RID: 155 RVA: 0x00016E1C File Offset: 0x0001521C
		' (set) Token: 0x0600009C RID: 156 RVA: 0x00016E34 File Offset: 0x00015234
		Friend Overridable Property chkTime24 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkTime24
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkTime24 = value
			End Set
		End Property

		' Token: 0x17000040 RID: 64
		' (get) Token: 0x0600009D RID: 157 RVA: 0x00016E40 File Offset: 0x00015240
		' (set) Token: 0x0600009E RID: 158 RVA: 0x00016E58 File Offset: 0x00015258
		Friend Overridable Property comboSoundConEng24 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundConEng24
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundConEng24 = value
			End Set
		End Property

		' Token: 0x17000041 RID: 65
		' (get) Token: 0x0600009F RID: 159 RVA: 0x00016E64 File Offset: 0x00015264
		' (set) Token: 0x060000A0 RID: 160 RVA: 0x00016E7C File Offset: 0x0001527C
		Friend Overridable Property comboSoundCon24 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundCon24
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundCon24 = value
			End Set
		End Property

		' Token: 0x17000042 RID: 66
		' (get) Token: 0x060000A1 RID: 161 RVA: 0x00016E88 File Offset: 0x00015288
		' (set) Token: 0x060000A2 RID: 162 RVA: 0x00016EA0 File Offset: 0x000152A0
		Friend Overridable Property chkCon24 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkCon24
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkCon24_CheckedChanged
				Dim flag As Boolean = Me._chkCon24 IsNot Nothing
				If flag Then
					RemoveHandler Me._chkCon24.CheckedChanged, eventHandler
				End If
				Me._chkCon24 = value
				flag = Me._chkCon24 IsNot Nothing
				If flag Then
					AddHandler Me._chkCon24.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000043 RID: 67
		' (get) Token: 0x060000A3 RID: 163 RVA: 0x00016F00 File Offset: 0x00015300
		' (set) Token: 0x060000A4 RID: 164 RVA: 0x00016F18 File Offset: 0x00015318
		Friend Overridable Property btnPlay24 As Button
			<DebuggerNonUserCode()>
			Get
				Return Me._btnPlay24
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnPlay24_Click
				Dim flag As Boolean = Me._btnPlay24 IsNot Nothing
				If flag Then
					RemoveHandler Me._btnPlay24.Click, eventHandler
				End If
				Me._btnPlay24 = value
				flag = Me._btnPlay24 IsNot Nothing
				If flag Then
					AddHandler Me._btnPlay24.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000044 RID: 68
		' (get) Token: 0x060000A5 RID: 165 RVA: 0x00016F78 File Offset: 0x00015378
		' (set) Token: 0x060000A6 RID: 166 RVA: 0x00016F90 File Offset: 0x00015390
		Friend Overridable Property comboMin24 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboMin24
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboMin24 = value
			End Set
		End Property

		' Token: 0x17000045 RID: 69
		' (get) Token: 0x060000A7 RID: 167 RVA: 0x00016F9C File Offset: 0x0001539C
		' (set) Token: 0x060000A8 RID: 168 RVA: 0x00016FB4 File Offset: 0x000153B4
		Friend Overridable Property comboHour24 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboHour24
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboHour24 = value
			End Set
		End Property

		' Token: 0x17000046 RID: 70
		' (get) Token: 0x060000A9 RID: 169 RVA: 0x00016FC0 File Offset: 0x000153C0
		' (set) Token: 0x060000AA RID: 170 RVA: 0x00016FD8 File Offset: 0x000153D8
		Friend Overridable Property chkFirst23 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkFirst23
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkFirst23 = value
			End Set
		End Property

		' Token: 0x17000047 RID: 71
		' (get) Token: 0x060000AB RID: 171 RVA: 0x00016FE4 File Offset: 0x000153E4
		' (set) Token: 0x060000AC RID: 172 RVA: 0x00016FFC File Offset: 0x000153FC
		Friend Overridable Property chkFirst22 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkFirst22
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkFirst22 = value
			End Set
		End Property

		' Token: 0x17000048 RID: 72
		' (get) Token: 0x060000AD RID: 173 RVA: 0x00017008 File Offset: 0x00015408
		' (set) Token: 0x060000AE RID: 174 RVA: 0x00017020 File Offset: 0x00015420
		Friend Overridable Property chkFirst21 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkFirst21
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkFirst21 = value
			End Set
		End Property

		' Token: 0x17000049 RID: 73
		' (get) Token: 0x060000AF RID: 175 RVA: 0x0001702C File Offset: 0x0001542C
		' (set) Token: 0x060000B0 RID: 176 RVA: 0x00017044 File Offset: 0x00015444
		Friend Overridable Property chkLast23 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkLast23
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkLast23 = value
			End Set
		End Property

		' Token: 0x1700004A RID: 74
		' (get) Token: 0x060000B1 RID: 177 RVA: 0x00017050 File Offset: 0x00015450
		' (set) Token: 0x060000B2 RID: 178 RVA: 0x00017068 File Offset: 0x00015468
		Friend Overridable Property chkLast22 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkLast22
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkLast22 = value
			End Set
		End Property

		' Token: 0x1700004B RID: 75
		' (get) Token: 0x060000B3 RID: 179 RVA: 0x00017074 File Offset: 0x00015474
		' (set) Token: 0x060000B4 RID: 180 RVA: 0x0001708C File Offset: 0x0001548C
		Friend Overridable Property chkLast21 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkLast21
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkLast21 = value
			End Set
		End Property

		' Token: 0x1700004C RID: 76
		' (get) Token: 0x060000B5 RID: 181 RVA: 0x00017098 File Offset: 0x00015498
		' (set) Token: 0x060000B6 RID: 182 RVA: 0x000170B0 File Offset: 0x000154B0
		Friend Overridable Property chkTime23 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkTime23
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkTime23 = value
			End Set
		End Property

		' Token: 0x1700004D RID: 77
		' (get) Token: 0x060000B7 RID: 183 RVA: 0x000170BC File Offset: 0x000154BC
		' (set) Token: 0x060000B8 RID: 184 RVA: 0x000170D4 File Offset: 0x000154D4
		Friend Overridable Property chkTime22 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkTime22
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkTime22 = value
			End Set
		End Property

		' Token: 0x1700004E RID: 78
		' (get) Token: 0x060000B9 RID: 185 RVA: 0x000170E0 File Offset: 0x000154E0
		' (set) Token: 0x060000BA RID: 186 RVA: 0x000170F8 File Offset: 0x000154F8
		Friend Overridable Property chkTime21 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkTime21
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkTime21 = value
			End Set
		End Property

		' Token: 0x1700004F RID: 79
		' (get) Token: 0x060000BB RID: 187 RVA: 0x00017104 File Offset: 0x00015504
		' (set) Token: 0x060000BC RID: 188 RVA: 0x0001711C File Offset: 0x0001551C
		Friend Overridable Property comboSoundConEng23 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundConEng23
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundConEng23 = value
			End Set
		End Property

		' Token: 0x17000050 RID: 80
		' (get) Token: 0x060000BD RID: 189 RVA: 0x00017128 File Offset: 0x00015528
		' (set) Token: 0x060000BE RID: 190 RVA: 0x00017140 File Offset: 0x00015540
		Friend Overridable Property comboSoundConEng22 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundConEng22
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundConEng22 = value
			End Set
		End Property

		' Token: 0x17000051 RID: 81
		' (get) Token: 0x060000BF RID: 191 RVA: 0x0001714C File Offset: 0x0001554C
		' (set) Token: 0x060000C0 RID: 192 RVA: 0x00017164 File Offset: 0x00015564
		Friend Overridable Property comboSoundConEng21 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundConEng21
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundConEng21 = value
			End Set
		End Property

		' Token: 0x17000052 RID: 82
		' (get) Token: 0x060000C1 RID: 193 RVA: 0x00017170 File Offset: 0x00015570
		' (set) Token: 0x060000C2 RID: 194 RVA: 0x00017188 File Offset: 0x00015588
		Friend Overridable Property comboSoundCon23 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundCon23
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundCon23 = value
			End Set
		End Property

		' Token: 0x17000053 RID: 83
		' (get) Token: 0x060000C3 RID: 195 RVA: 0x00017194 File Offset: 0x00015594
		' (set) Token: 0x060000C4 RID: 196 RVA: 0x000171AC File Offset: 0x000155AC
		Friend Overridable Property comboSoundCon22 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundCon22
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundCon22 = value
			End Set
		End Property

		' Token: 0x17000054 RID: 84
		' (get) Token: 0x060000C5 RID: 197 RVA: 0x000171B8 File Offset: 0x000155B8
		' (set) Token: 0x060000C6 RID: 198 RVA: 0x000171D0 File Offset: 0x000155D0
		Friend Overridable Property comboSoundCon21 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundCon21
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundCon21 = value
			End Set
		End Property

		' Token: 0x17000055 RID: 85
		' (get) Token: 0x060000C7 RID: 199 RVA: 0x000171DC File Offset: 0x000155DC
		' (set) Token: 0x060000C8 RID: 200 RVA: 0x000171F4 File Offset: 0x000155F4
		Friend Overridable Property chkCon23 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkCon23
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkCon23_CheckedChanged
				Dim flag As Boolean = Me._chkCon23 IsNot Nothing
				If flag Then
					RemoveHandler Me._chkCon23.CheckedChanged, eventHandler
				End If
				Me._chkCon23 = value
				flag = Me._chkCon23 IsNot Nothing
				If flag Then
					AddHandler Me._chkCon23.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000056 RID: 86
		' (get) Token: 0x060000C9 RID: 201 RVA: 0x00017254 File Offset: 0x00015654
		' (set) Token: 0x060000CA RID: 202 RVA: 0x0001726C File Offset: 0x0001566C
		Friend Overridable Property btnPlay23 As Button
			<DebuggerNonUserCode()>
			Get
				Return Me._btnPlay23
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnPlay23_Click
				Dim flag As Boolean = Me._btnPlay23 IsNot Nothing
				If flag Then
					RemoveHandler Me._btnPlay23.Click, eventHandler
				End If
				Me._btnPlay23 = value
				flag = Me._btnPlay23 IsNot Nothing
				If flag Then
					AddHandler Me._btnPlay23.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000057 RID: 87
		' (get) Token: 0x060000CB RID: 203 RVA: 0x000172CC File Offset: 0x000156CC
		' (set) Token: 0x060000CC RID: 204 RVA: 0x000172E4 File Offset: 0x000156E4
		Friend Overridable Property comboMin23 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboMin23
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboMin23 = value
			End Set
		End Property

		' Token: 0x17000058 RID: 88
		' (get) Token: 0x060000CD RID: 205 RVA: 0x000172F0 File Offset: 0x000156F0
		' (set) Token: 0x060000CE RID: 206 RVA: 0x00017308 File Offset: 0x00015708
		Friend Overridable Property comboHour23 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboHour23
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboHour23 = value
			End Set
		End Property

		' Token: 0x17000059 RID: 89
		' (get) Token: 0x060000CF RID: 207 RVA: 0x00017314 File Offset: 0x00015714
		' (set) Token: 0x060000D0 RID: 208 RVA: 0x0001732C File Offset: 0x0001572C
		Friend Overridable Property chkCon22 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkCon22
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkCon22_CheckedChanged
				Dim flag As Boolean = Me._chkCon22 IsNot Nothing
				If flag Then
					RemoveHandler Me._chkCon22.CheckedChanged, eventHandler
				End If
				Me._chkCon22 = value
				flag = Me._chkCon22 IsNot Nothing
				If flag Then
					AddHandler Me._chkCon22.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700005A RID: 90
		' (get) Token: 0x060000D1 RID: 209 RVA: 0x0001738C File Offset: 0x0001578C
		' (set) Token: 0x060000D2 RID: 210 RVA: 0x000173A4 File Offset: 0x000157A4
		Friend Overridable Property btnPlay22 As Button
			<DebuggerNonUserCode()>
			Get
				Return Me._btnPlay22
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnPlay22_Click
				Dim flag As Boolean = Me._btnPlay22 IsNot Nothing
				If flag Then
					RemoveHandler Me._btnPlay22.Click, eventHandler
				End If
				Me._btnPlay22 = value
				flag = Me._btnPlay22 IsNot Nothing
				If flag Then
					AddHandler Me._btnPlay22.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700005B RID: 91
		' (get) Token: 0x060000D3 RID: 211 RVA: 0x00017404 File Offset: 0x00015804
		' (set) Token: 0x060000D4 RID: 212 RVA: 0x0001741C File Offset: 0x0001581C
		Friend Overridable Property comboMin22 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboMin22
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboMin22 = value
			End Set
		End Property

		' Token: 0x1700005C RID: 92
		' (get) Token: 0x060000D5 RID: 213 RVA: 0x00017428 File Offset: 0x00015828
		' (set) Token: 0x060000D6 RID: 214 RVA: 0x00017440 File Offset: 0x00015840
		Friend Overridable Property comboHour22 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboHour22
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboHour22 = value
			End Set
		End Property

		' Token: 0x1700005D RID: 93
		' (get) Token: 0x060000D7 RID: 215 RVA: 0x0001744C File Offset: 0x0001584C
		' (set) Token: 0x060000D8 RID: 216 RVA: 0x00017464 File Offset: 0x00015864
		Friend Overridable Property chkCon21 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkCon21
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkCon21_CheckedChanged
				Dim flag As Boolean = Me._chkCon21 IsNot Nothing
				If flag Then
					RemoveHandler Me._chkCon21.CheckedChanged, eventHandler
				End If
				Me._chkCon21 = value
				flag = Me._chkCon21 IsNot Nothing
				If flag Then
					AddHandler Me._chkCon21.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700005E RID: 94
		' (get) Token: 0x060000D9 RID: 217 RVA: 0x000174C4 File Offset: 0x000158C4
		' (set) Token: 0x060000DA RID: 218 RVA: 0x000174DC File Offset: 0x000158DC
		Friend Overridable Property btnPlay21 As Button
			<DebuggerNonUserCode()>
			Get
				Return Me._btnPlay21
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnPlay21_Click
				Dim flag As Boolean = Me._btnPlay21 IsNot Nothing
				If flag Then
					RemoveHandler Me._btnPlay21.Click, eventHandler
				End If
				Me._btnPlay21 = value
				flag = Me._btnPlay21 IsNot Nothing
				If flag Then
					AddHandler Me._btnPlay21.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700005F RID: 95
		' (get) Token: 0x060000DB RID: 219 RVA: 0x0001753C File Offset: 0x0001593C
		' (set) Token: 0x060000DC RID: 220 RVA: 0x00017554 File Offset: 0x00015954
		Friend Overridable Property comboMin21 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboMin21
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboMin21 = value
			End Set
		End Property

		' Token: 0x17000060 RID: 96
		' (get) Token: 0x060000DD RID: 221 RVA: 0x00017560 File Offset: 0x00015960
		' (set) Token: 0x060000DE RID: 222 RVA: 0x00017578 File Offset: 0x00015978
		Friend Overridable Property comboHour21 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboHour21
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboHour21 = value
			End Set
		End Property

		' Token: 0x17000061 RID: 97
		' (get) Token: 0x060000DF RID: 223 RVA: 0x00017584 File Offset: 0x00015984
		' (set) Token: 0x060000E0 RID: 224 RVA: 0x0001759C File Offset: 0x0001599C
		Friend Overridable Property chkFirst20 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkFirst20
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkFirst20 = value
			End Set
		End Property

		' Token: 0x17000062 RID: 98
		' (get) Token: 0x060000E1 RID: 225 RVA: 0x000175A8 File Offset: 0x000159A8
		' (set) Token: 0x060000E2 RID: 226 RVA: 0x000175C0 File Offset: 0x000159C0
		Friend Overridable Property chkFirst19 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkFirst19
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkFirst19 = value
			End Set
		End Property

		' Token: 0x17000063 RID: 99
		' (get) Token: 0x060000E3 RID: 227 RVA: 0x000175CC File Offset: 0x000159CC
		' (set) Token: 0x060000E4 RID: 228 RVA: 0x000175E4 File Offset: 0x000159E4
		Friend Overridable Property chkFirst18 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkFirst18
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkFirst18 = value
			End Set
		End Property

		' Token: 0x17000064 RID: 100
		' (get) Token: 0x060000E5 RID: 229 RVA: 0x000175F0 File Offset: 0x000159F0
		' (set) Token: 0x060000E6 RID: 230 RVA: 0x00017608 File Offset: 0x00015A08
		Friend Overridable Property chkFirst17 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkFirst17
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkFirst17 = value
			End Set
		End Property

		' Token: 0x17000065 RID: 101
		' (get) Token: 0x060000E7 RID: 231 RVA: 0x00017614 File Offset: 0x00015A14
		' (set) Token: 0x060000E8 RID: 232 RVA: 0x0001762C File Offset: 0x00015A2C
		Friend Overridable Property chkLast20 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkLast20
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkLast20 = value
			End Set
		End Property

		' Token: 0x17000066 RID: 102
		' (get) Token: 0x060000E9 RID: 233 RVA: 0x00017638 File Offset: 0x00015A38
		' (set) Token: 0x060000EA RID: 234 RVA: 0x00017650 File Offset: 0x00015A50
		Friend Overridable Property chkLast19 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkLast19
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkLast19 = value
			End Set
		End Property

		' Token: 0x17000067 RID: 103
		' (get) Token: 0x060000EB RID: 235 RVA: 0x0001765C File Offset: 0x00015A5C
		' (set) Token: 0x060000EC RID: 236 RVA: 0x00017674 File Offset: 0x00015A74
		Friend Overridable Property chkLast18 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkLast18
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkLast18 = value
			End Set
		End Property

		' Token: 0x17000068 RID: 104
		' (get) Token: 0x060000ED RID: 237 RVA: 0x00017680 File Offset: 0x00015A80
		' (set) Token: 0x060000EE RID: 238 RVA: 0x00017698 File Offset: 0x00015A98
		Friend Overridable Property chkLast17 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkLast17
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkLast17 = value
			End Set
		End Property

		' Token: 0x17000069 RID: 105
		' (get) Token: 0x060000EF RID: 239 RVA: 0x000176A4 File Offset: 0x00015AA4
		' (set) Token: 0x060000F0 RID: 240 RVA: 0x000176BC File Offset: 0x00015ABC
		Friend Overridable Property chkTime20 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkTime20
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkTime20 = value
			End Set
		End Property

		' Token: 0x1700006A RID: 106
		' (get) Token: 0x060000F1 RID: 241 RVA: 0x000176C8 File Offset: 0x00015AC8
		' (set) Token: 0x060000F2 RID: 242 RVA: 0x000176E0 File Offset: 0x00015AE0
		Friend Overridable Property chkTime19 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkTime19
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkTime19 = value
			End Set
		End Property

		' Token: 0x1700006B RID: 107
		' (get) Token: 0x060000F3 RID: 243 RVA: 0x000176EC File Offset: 0x00015AEC
		' (set) Token: 0x060000F4 RID: 244 RVA: 0x00017704 File Offset: 0x00015B04
		Friend Overridable Property chkTime18 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkTime18
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkTime18 = value
			End Set
		End Property

		' Token: 0x1700006C RID: 108
		' (get) Token: 0x060000F5 RID: 245 RVA: 0x00017710 File Offset: 0x00015B10
		' (set) Token: 0x060000F6 RID: 246 RVA: 0x00017728 File Offset: 0x00015B28
		Friend Overridable Property chkTime17 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkTime17
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkTime17 = value
			End Set
		End Property

		' Token: 0x1700006D RID: 109
		' (get) Token: 0x060000F7 RID: 247 RVA: 0x00017734 File Offset: 0x00015B34
		' (set) Token: 0x060000F8 RID: 248 RVA: 0x0001774C File Offset: 0x00015B4C
		Friend Overridable Property comboSoundConEng20 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundConEng20
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundConEng20 = value
			End Set
		End Property

		' Token: 0x1700006E RID: 110
		' (get) Token: 0x060000F9 RID: 249 RVA: 0x00017758 File Offset: 0x00015B58
		' (set) Token: 0x060000FA RID: 250 RVA: 0x00017770 File Offset: 0x00015B70
		Friend Overridable Property comboSoundConEng19 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundConEng19
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundConEng19 = value
			End Set
		End Property

		' Token: 0x1700006F RID: 111
		' (get) Token: 0x060000FB RID: 251 RVA: 0x0001777C File Offset: 0x00015B7C
		' (set) Token: 0x060000FC RID: 252 RVA: 0x00017794 File Offset: 0x00015B94
		Friend Overridable Property comboSoundConEng18 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundConEng18
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundConEng18 = value
			End Set
		End Property

		' Token: 0x17000070 RID: 112
		' (get) Token: 0x060000FD RID: 253 RVA: 0x000177A0 File Offset: 0x00015BA0
		' (set) Token: 0x060000FE RID: 254 RVA: 0x000177B8 File Offset: 0x00015BB8
		Friend Overridable Property comboSoundConEng17 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundConEng17
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundConEng17 = value
			End Set
		End Property

		' Token: 0x17000071 RID: 113
		' (get) Token: 0x060000FF RID: 255 RVA: 0x000177C4 File Offset: 0x00015BC4
		' (set) Token: 0x06000100 RID: 256 RVA: 0x000177DC File Offset: 0x00015BDC
		Friend Overridable Property comboSoundCon20 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundCon20
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundCon20 = value
			End Set
		End Property

		' Token: 0x17000072 RID: 114
		' (get) Token: 0x06000101 RID: 257 RVA: 0x000177E8 File Offset: 0x00015BE8
		' (set) Token: 0x06000102 RID: 258 RVA: 0x00017800 File Offset: 0x00015C00
		Friend Overridable Property comboSoundCon19 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundCon19
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundCon19 = value
			End Set
		End Property

		' Token: 0x17000073 RID: 115
		' (get) Token: 0x06000103 RID: 259 RVA: 0x0001780C File Offset: 0x00015C0C
		' (set) Token: 0x06000104 RID: 260 RVA: 0x00017824 File Offset: 0x00015C24
		Friend Overridable Property comboSoundCon18 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundCon18
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundCon18 = value
			End Set
		End Property

		' Token: 0x17000074 RID: 116
		' (get) Token: 0x06000105 RID: 261 RVA: 0x00017830 File Offset: 0x00015C30
		' (set) Token: 0x06000106 RID: 262 RVA: 0x00017848 File Offset: 0x00015C48
		Friend Overridable Property comboSoundCon17 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundCon17
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundCon17 = value
			End Set
		End Property

		' Token: 0x17000075 RID: 117
		' (get) Token: 0x06000107 RID: 263 RVA: 0x00017854 File Offset: 0x00015C54
		' (set) Token: 0x06000108 RID: 264 RVA: 0x0001786C File Offset: 0x00015C6C
		Friend Overridable Property chkCon20 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkCon20
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkCon20_CheckedChanged
				Dim flag As Boolean = Me._chkCon20 IsNot Nothing
				If flag Then
					RemoveHandler Me._chkCon20.CheckedChanged, eventHandler
				End If
				Me._chkCon20 = value
				flag = Me._chkCon20 IsNot Nothing
				If flag Then
					AddHandler Me._chkCon20.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000076 RID: 118
		' (get) Token: 0x06000109 RID: 265 RVA: 0x000178CC File Offset: 0x00015CCC
		' (set) Token: 0x0600010A RID: 266 RVA: 0x000178E4 File Offset: 0x00015CE4
		Friend Overridable Property btnPlay20 As Button
			<DebuggerNonUserCode()>
			Get
				Return Me._btnPlay20
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnPlay20_Click
				Dim flag As Boolean = Me._btnPlay20 IsNot Nothing
				If flag Then
					RemoveHandler Me._btnPlay20.Click, eventHandler
				End If
				Me._btnPlay20 = value
				flag = Me._btnPlay20 IsNot Nothing
				If flag Then
					AddHandler Me._btnPlay20.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000077 RID: 119
		' (get) Token: 0x0600010B RID: 267 RVA: 0x00017944 File Offset: 0x00015D44
		' (set) Token: 0x0600010C RID: 268 RVA: 0x0001795C File Offset: 0x00015D5C
		Friend Overridable Property comboMin20 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboMin20
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboMin20 = value
			End Set
		End Property

		' Token: 0x17000078 RID: 120
		' (get) Token: 0x0600010D RID: 269 RVA: 0x00017968 File Offset: 0x00015D68
		' (set) Token: 0x0600010E RID: 270 RVA: 0x00017980 File Offset: 0x00015D80
		Friend Overridable Property comboHour20 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboHour20
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboHour20 = value
			End Set
		End Property

		' Token: 0x17000079 RID: 121
		' (get) Token: 0x0600010F RID: 271 RVA: 0x0001798C File Offset: 0x00015D8C
		' (set) Token: 0x06000110 RID: 272 RVA: 0x000179A4 File Offset: 0x00015DA4
		Friend Overridable Property chkCon19 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkCon19
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkCon19_CheckedChanged
				Dim flag As Boolean = Me._chkCon19 IsNot Nothing
				If flag Then
					RemoveHandler Me._chkCon19.CheckedChanged, eventHandler
				End If
				Me._chkCon19 = value
				flag = Me._chkCon19 IsNot Nothing
				If flag Then
					AddHandler Me._chkCon19.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700007A RID: 122
		' (get) Token: 0x06000111 RID: 273 RVA: 0x00017A04 File Offset: 0x00015E04
		' (set) Token: 0x06000112 RID: 274 RVA: 0x00017A1C File Offset: 0x00015E1C
		Friend Overridable Property btnPlay19 As Button
			<DebuggerNonUserCode()>
			Get
				Return Me._btnPlay19
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnPlay19_Click
				Dim flag As Boolean = Me._btnPlay19 IsNot Nothing
				If flag Then
					RemoveHandler Me._btnPlay19.Click, eventHandler
				End If
				Me._btnPlay19 = value
				flag = Me._btnPlay19 IsNot Nothing
				If flag Then
					AddHandler Me._btnPlay19.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700007B RID: 123
		' (get) Token: 0x06000113 RID: 275 RVA: 0x00017A7C File Offset: 0x00015E7C
		' (set) Token: 0x06000114 RID: 276 RVA: 0x00017A94 File Offset: 0x00015E94
		Friend Overridable Property comboMin19 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboMin19
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboMin19 = value
			End Set
		End Property

		' Token: 0x1700007C RID: 124
		' (get) Token: 0x06000115 RID: 277 RVA: 0x00017AA0 File Offset: 0x00015EA0
		' (set) Token: 0x06000116 RID: 278 RVA: 0x00017AB8 File Offset: 0x00015EB8
		Friend Overridable Property comboHour19 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboHour19
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboHour19 = value
			End Set
		End Property

		' Token: 0x1700007D RID: 125
		' (get) Token: 0x06000117 RID: 279 RVA: 0x00017AC4 File Offset: 0x00015EC4
		' (set) Token: 0x06000118 RID: 280 RVA: 0x00017ADC File Offset: 0x00015EDC
		Friend Overridable Property chkCon18 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkCon18
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkCon18_CheckedChanged
				Dim flag As Boolean = Me._chkCon18 IsNot Nothing
				If flag Then
					RemoveHandler Me._chkCon18.CheckedChanged, eventHandler
				End If
				Me._chkCon18 = value
				flag = Me._chkCon18 IsNot Nothing
				If flag Then
					AddHandler Me._chkCon18.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700007E RID: 126
		' (get) Token: 0x06000119 RID: 281 RVA: 0x00017B3C File Offset: 0x00015F3C
		' (set) Token: 0x0600011A RID: 282 RVA: 0x00017B54 File Offset: 0x00015F54
		Friend Overridable Property btnPlay18 As Button
			<DebuggerNonUserCode()>
			Get
				Return Me._btnPlay18
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnPlay18_Click
				Dim flag As Boolean = Me._btnPlay18 IsNot Nothing
				If flag Then
					RemoveHandler Me._btnPlay18.Click, eventHandler
				End If
				Me._btnPlay18 = value
				flag = Me._btnPlay18 IsNot Nothing
				If flag Then
					AddHandler Me._btnPlay18.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700007F RID: 127
		' (get) Token: 0x0600011B RID: 283 RVA: 0x00017BB4 File Offset: 0x00015FB4
		' (set) Token: 0x0600011C RID: 284 RVA: 0x00017BCC File Offset: 0x00015FCC
		Friend Overridable Property comboMin18 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboMin18
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboMin18 = value
			End Set
		End Property

		' Token: 0x17000080 RID: 128
		' (get) Token: 0x0600011D RID: 285 RVA: 0x00017BD8 File Offset: 0x00015FD8
		' (set) Token: 0x0600011E RID: 286 RVA: 0x00017BF0 File Offset: 0x00015FF0
		Friend Overridable Property comboHour18 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboHour18
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboHour18 = value
			End Set
		End Property

		' Token: 0x17000081 RID: 129
		' (get) Token: 0x0600011F RID: 287 RVA: 0x00017BFC File Offset: 0x00015FFC
		' (set) Token: 0x06000120 RID: 288 RVA: 0x00017C14 File Offset: 0x00016014
		Friend Overridable Property chkCon17 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkCon17
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkCon17_CheckedChanged
				Dim flag As Boolean = Me._chkCon17 IsNot Nothing
				If flag Then
					RemoveHandler Me._chkCon17.CheckedChanged, eventHandler
				End If
				Me._chkCon17 = value
				flag = Me._chkCon17 IsNot Nothing
				If flag Then
					AddHandler Me._chkCon17.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000082 RID: 130
		' (get) Token: 0x06000121 RID: 289 RVA: 0x00017C74 File Offset: 0x00016074
		' (set) Token: 0x06000122 RID: 290 RVA: 0x00017C8C File Offset: 0x0001608C
		Friend Overridable Property btnPlay17 As Button
			<DebuggerNonUserCode()>
			Get
				Return Me._btnPlay17
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnPlay17_Click
				Dim flag As Boolean = Me._btnPlay17 IsNot Nothing
				If flag Then
					RemoveHandler Me._btnPlay17.Click, eventHandler
				End If
				Me._btnPlay17 = value
				flag = Me._btnPlay17 IsNot Nothing
				If flag Then
					AddHandler Me._btnPlay17.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000083 RID: 131
		' (get) Token: 0x06000123 RID: 291 RVA: 0x00017CEC File Offset: 0x000160EC
		' (set) Token: 0x06000124 RID: 292 RVA: 0x00017D04 File Offset: 0x00016104
		Friend Overridable Property comboMin17 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboMin17
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboMin17 = value
			End Set
		End Property

		' Token: 0x17000084 RID: 132
		' (get) Token: 0x06000125 RID: 293 RVA: 0x00017D10 File Offset: 0x00016110
		' (set) Token: 0x06000126 RID: 294 RVA: 0x00017D28 File Offset: 0x00016128
		Friend Overridable Property comboHour17 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboHour17
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboHour17 = value
			End Set
		End Property

		' Token: 0x17000085 RID: 133
		' (get) Token: 0x06000127 RID: 295 RVA: 0x00017D34 File Offset: 0x00016134
		' (set) Token: 0x06000128 RID: 296 RVA: 0x00017D4C File Offset: 0x0001614C
		Friend Overridable Property lblEng As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lblEng
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lblEng = value
			End Set
		End Property

		' Token: 0x17000086 RID: 134
		' (get) Token: 0x06000129 RID: 297 RVA: 0x00017D58 File Offset: 0x00016158
		' (set) Token: 0x0600012A RID: 298 RVA: 0x00017D70 File Offset: 0x00016170
		Friend Overridable Property lblThai As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lblThai
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lblThai = value
			End Set
		End Property

		' Token: 0x17000087 RID: 135
		' (get) Token: 0x0600012B RID: 299 RVA: 0x00017D7C File Offset: 0x0001617C
		' (set) Token: 0x0600012C RID: 300 RVA: 0x00017D94 File Offset: 0x00016194
		Friend Overridable Property PictureBox3 As PictureBox
			<DebuggerNonUserCode()>
			Get
				Return Me._PictureBox3
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As PictureBox)
				Me._PictureBox3 = value
			End Set
		End Property

		' Token: 0x17000088 RID: 136
		' (get) Token: 0x0600012D RID: 301 RVA: 0x00017DA0 File Offset: 0x000161A0
		' (set) Token: 0x0600012E RID: 302 RVA: 0x00017DB8 File Offset: 0x000161B8
		Friend Overridable Property PictureBox2 As PictureBox
			<DebuggerNonUserCode()>
			Get
				Return Me._PictureBox2
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As PictureBox)
				Me._PictureBox2 = value
			End Set
		End Property

		' Token: 0x17000089 RID: 137
		' (get) Token: 0x0600012F RID: 303 RVA: 0x00017DC4 File Offset: 0x000161C4
		' (set) Token: 0x06000130 RID: 304 RVA: 0x00017DDC File Offset: 0x000161DC
		Friend Overridable Property lbl14 As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lbl14
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lbl14 = value
			End Set
		End Property

		' Token: 0x1700008A RID: 138
		' (get) Token: 0x06000131 RID: 305 RVA: 0x00017DE8 File Offset: 0x000161E8
		' (set) Token: 0x06000132 RID: 306 RVA: 0x00017E00 File Offset: 0x00016200
		Friend Overridable Property lbl15 As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lbl15
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lbl15 = value
			End Set
		End Property

		' Token: 0x1700008B RID: 139
		' (get) Token: 0x06000133 RID: 307 RVA: 0x00017E0C File Offset: 0x0001620C
		' (set) Token: 0x06000134 RID: 308 RVA: 0x00017E24 File Offset: 0x00016224
		Friend Overridable Property lbl16 As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lbl16
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lbl16 = value
			End Set
		End Property

		' Token: 0x1700008C RID: 140
		' (get) Token: 0x06000135 RID: 309 RVA: 0x00017E30 File Offset: 0x00016230
		' (set) Token: 0x06000136 RID: 310 RVA: 0x00017E48 File Offset: 0x00016248
		Friend Overridable Property lbl09 As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lbl09
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lbl09 = value
			End Set
		End Property

		' Token: 0x1700008D RID: 141
		' (get) Token: 0x06000137 RID: 311 RVA: 0x00017E54 File Offset: 0x00016254
		' (set) Token: 0x06000138 RID: 312 RVA: 0x00017E6C File Offset: 0x0001626C
		Friend Overridable Property lbl10 As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lbl10
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lbl10 = value
			End Set
		End Property

		' Token: 0x1700008E RID: 142
		' (get) Token: 0x06000139 RID: 313 RVA: 0x00017E78 File Offset: 0x00016278
		' (set) Token: 0x0600013A RID: 314 RVA: 0x00017E90 File Offset: 0x00016290
		Friend Overridable Property lbl11 As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lbl11
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lbl11 = value
			End Set
		End Property

		' Token: 0x1700008F RID: 143
		' (get) Token: 0x0600013B RID: 315 RVA: 0x00017E9C File Offset: 0x0001629C
		' (set) Token: 0x0600013C RID: 316 RVA: 0x00017EB4 File Offset: 0x000162B4
		Friend Overridable Property lbl12 As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lbl12
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lbl12 = value
			End Set
		End Property

		' Token: 0x17000090 RID: 144
		' (get) Token: 0x0600013D RID: 317 RVA: 0x00017EC0 File Offset: 0x000162C0
		' (set) Token: 0x0600013E RID: 318 RVA: 0x00017ED8 File Offset: 0x000162D8
		Friend Overridable Property lbl13 As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lbl13
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lbl13 = value
			End Set
		End Property

		' Token: 0x17000091 RID: 145
		' (get) Token: 0x0600013F RID: 319 RVA: 0x00017EE4 File Offset: 0x000162E4
		' (set) Token: 0x06000140 RID: 320 RVA: 0x00017EFC File Offset: 0x000162FC
		Friend Overridable Property lbl06 As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lbl06
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lbl06 = value
			End Set
		End Property

		' Token: 0x17000092 RID: 146
		' (get) Token: 0x06000141 RID: 321 RVA: 0x00017F08 File Offset: 0x00016308
		' (set) Token: 0x06000142 RID: 322 RVA: 0x00017F20 File Offset: 0x00016320
		Friend Overridable Property lbl07 As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lbl07
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lbl07 = value
			End Set
		End Property

		' Token: 0x17000093 RID: 147
		' (get) Token: 0x06000143 RID: 323 RVA: 0x00017F2C File Offset: 0x0001632C
		' (set) Token: 0x06000144 RID: 324 RVA: 0x00017F44 File Offset: 0x00016344
		Friend Overridable Property lbl08 As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lbl08
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lbl08 = value
			End Set
		End Property

		' Token: 0x17000094 RID: 148
		' (get) Token: 0x06000145 RID: 325 RVA: 0x00017F50 File Offset: 0x00016350
		' (set) Token: 0x06000146 RID: 326 RVA: 0x00017F68 File Offset: 0x00016368
		Friend Overridable Property lbl05 As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lbl05
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lbl05 = value
			End Set
		End Property

		' Token: 0x17000095 RID: 149
		' (get) Token: 0x06000147 RID: 327 RVA: 0x00017F74 File Offset: 0x00016374
		' (set) Token: 0x06000148 RID: 328 RVA: 0x00017F8C File Offset: 0x0001638C
		Friend Overridable Property lbl04 As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lbl04
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lbl04 = value
			End Set
		End Property

		' Token: 0x17000096 RID: 150
		' (get) Token: 0x06000149 RID: 329 RVA: 0x00017F98 File Offset: 0x00016398
		' (set) Token: 0x0600014A RID: 330 RVA: 0x00017FB0 File Offset: 0x000163B0
		Friend Overridable Property lbl03 As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lbl03
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lbl03 = value
			End Set
		End Property

		' Token: 0x17000097 RID: 151
		' (get) Token: 0x0600014B RID: 331 RVA: 0x00017FBC File Offset: 0x000163BC
		' (set) Token: 0x0600014C RID: 332 RVA: 0x00017FD4 File Offset: 0x000163D4
		Friend Overridable Property lbl02 As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lbl02
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lbl02 = value
			End Set
		End Property

		' Token: 0x17000098 RID: 152
		' (get) Token: 0x0600014D RID: 333 RVA: 0x00017FE0 File Offset: 0x000163E0
		' (set) Token: 0x0600014E RID: 334 RVA: 0x00017FF8 File Offset: 0x000163F8
		Friend Overridable Property lbl01 As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lbl01
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lbl01 = value
			End Set
		End Property

		' Token: 0x17000099 RID: 153
		' (get) Token: 0x0600014F RID: 335 RVA: 0x00018004 File Offset: 0x00016404
		' (set) Token: 0x06000150 RID: 336 RVA: 0x0001801C File Offset: 0x0001641C
		Friend Overridable Property chkFirst16 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkFirst16
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkFirst16 = value
			End Set
		End Property

		' Token: 0x1700009A RID: 154
		' (get) Token: 0x06000151 RID: 337 RVA: 0x00018028 File Offset: 0x00016428
		' (set) Token: 0x06000152 RID: 338 RVA: 0x00018040 File Offset: 0x00016440
		Friend Overridable Property chkLast16 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkLast16
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkLast16 = value
			End Set
		End Property

		' Token: 0x1700009B RID: 155
		' (get) Token: 0x06000153 RID: 339 RVA: 0x0001804C File Offset: 0x0001644C
		' (set) Token: 0x06000154 RID: 340 RVA: 0x00018064 File Offset: 0x00016464
		Friend Overridable Property chkTime16 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkTime16
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkTime16 = value
			End Set
		End Property

		' Token: 0x1700009C RID: 156
		' (get) Token: 0x06000155 RID: 341 RVA: 0x00018070 File Offset: 0x00016470
		' (set) Token: 0x06000156 RID: 342 RVA: 0x00018088 File Offset: 0x00016488
		Friend Overridable Property comboSoundConEng16 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundConEng16
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundConEng16 = value
			End Set
		End Property

		' Token: 0x1700009D RID: 157
		' (get) Token: 0x06000157 RID: 343 RVA: 0x00018094 File Offset: 0x00016494
		' (set) Token: 0x06000158 RID: 344 RVA: 0x000180AC File Offset: 0x000164AC
		Friend Overridable Property comboSoundCon16 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundCon16
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundCon16 = value
			End Set
		End Property

		' Token: 0x1700009E RID: 158
		' (get) Token: 0x06000159 RID: 345 RVA: 0x000180B8 File Offset: 0x000164B8
		' (set) Token: 0x0600015A RID: 346 RVA: 0x000180D0 File Offset: 0x000164D0
		Friend Overridable Property chkCon16 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkCon16
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkCon16_CheckedChanged
				Dim flag As Boolean = Me._chkCon16 IsNot Nothing
				If flag Then
					RemoveHandler Me._chkCon16.CheckedChanged, eventHandler
				End If
				Me._chkCon16 = value
				flag = Me._chkCon16 IsNot Nothing
				If flag Then
					AddHandler Me._chkCon16.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700009F RID: 159
		' (get) Token: 0x0600015B RID: 347 RVA: 0x00018130 File Offset: 0x00016530
		' (set) Token: 0x0600015C RID: 348 RVA: 0x00018148 File Offset: 0x00016548
		Friend Overridable Property btnPlay16 As Button
			<DebuggerNonUserCode()>
			Get
				Return Me._btnPlay16
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnPlay16_Click
				Dim flag As Boolean = Me._btnPlay16 IsNot Nothing
				If flag Then
					RemoveHandler Me._btnPlay16.Click, eventHandler
				End If
				Me._btnPlay16 = value
				flag = Me._btnPlay16 IsNot Nothing
				If flag Then
					AddHandler Me._btnPlay16.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170000A0 RID: 160
		' (get) Token: 0x0600015D RID: 349 RVA: 0x000181A8 File Offset: 0x000165A8
		' (set) Token: 0x0600015E RID: 350 RVA: 0x000181C0 File Offset: 0x000165C0
		Friend Overridable Property comboMin16 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboMin16
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboMin16 = value
			End Set
		End Property

		' Token: 0x170000A1 RID: 161
		' (get) Token: 0x0600015F RID: 351 RVA: 0x000181CC File Offset: 0x000165CC
		' (set) Token: 0x06000160 RID: 352 RVA: 0x000181E4 File Offset: 0x000165E4
		Friend Overridable Property comboHour16 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboHour16
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboHour16 = value
			End Set
		End Property

		' Token: 0x170000A2 RID: 162
		' (get) Token: 0x06000161 RID: 353 RVA: 0x000181F0 File Offset: 0x000165F0
		' (set) Token: 0x06000162 RID: 354 RVA: 0x00018208 File Offset: 0x00016608
		Friend Overridable Property chkFirst15 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkFirst15
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkFirst15 = value
			End Set
		End Property

		' Token: 0x170000A3 RID: 163
		' (get) Token: 0x06000163 RID: 355 RVA: 0x00018214 File Offset: 0x00016614
		' (set) Token: 0x06000164 RID: 356 RVA: 0x0001822C File Offset: 0x0001662C
		Friend Overridable Property chkFirst14 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkFirst14
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkFirst14 = value
			End Set
		End Property

		' Token: 0x170000A4 RID: 164
		' (get) Token: 0x06000165 RID: 357 RVA: 0x00018238 File Offset: 0x00016638
		' (set) Token: 0x06000166 RID: 358 RVA: 0x00018250 File Offset: 0x00016650
		Friend Overridable Property chkFirst13 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkFirst13
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkFirst13 = value
			End Set
		End Property

		' Token: 0x170000A5 RID: 165
		' (get) Token: 0x06000167 RID: 359 RVA: 0x0001825C File Offset: 0x0001665C
		' (set) Token: 0x06000168 RID: 360 RVA: 0x00018274 File Offset: 0x00016674
		Friend Overridable Property chkLast15 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkLast15
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkLast15 = value
			End Set
		End Property

		' Token: 0x170000A6 RID: 166
		' (get) Token: 0x06000169 RID: 361 RVA: 0x00018280 File Offset: 0x00016680
		' (set) Token: 0x0600016A RID: 362 RVA: 0x00018298 File Offset: 0x00016698
		Friend Overridable Property chkLast14 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkLast14
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkLast14 = value
			End Set
		End Property

		' Token: 0x170000A7 RID: 167
		' (get) Token: 0x0600016B RID: 363 RVA: 0x000182A4 File Offset: 0x000166A4
		' (set) Token: 0x0600016C RID: 364 RVA: 0x000182BC File Offset: 0x000166BC
		Friend Overridable Property chkLast13 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkLast13
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkLast13 = value
			End Set
		End Property

		' Token: 0x170000A8 RID: 168
		' (get) Token: 0x0600016D RID: 365 RVA: 0x000182C8 File Offset: 0x000166C8
		' (set) Token: 0x0600016E RID: 366 RVA: 0x000182E0 File Offset: 0x000166E0
		Friend Overridable Property chkTime15 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkTime15
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkTime15 = value
			End Set
		End Property

		' Token: 0x170000A9 RID: 169
		' (get) Token: 0x0600016F RID: 367 RVA: 0x000182EC File Offset: 0x000166EC
		' (set) Token: 0x06000170 RID: 368 RVA: 0x00018304 File Offset: 0x00016704
		Friend Overridable Property chkTime14 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkTime14
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkTime14 = value
			End Set
		End Property

		' Token: 0x170000AA RID: 170
		' (get) Token: 0x06000171 RID: 369 RVA: 0x00018310 File Offset: 0x00016710
		' (set) Token: 0x06000172 RID: 370 RVA: 0x00018328 File Offset: 0x00016728
		Friend Overridable Property chkTime13 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkTime13
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkTime13 = value
			End Set
		End Property

		' Token: 0x170000AB RID: 171
		' (get) Token: 0x06000173 RID: 371 RVA: 0x00018334 File Offset: 0x00016734
		' (set) Token: 0x06000174 RID: 372 RVA: 0x0001834C File Offset: 0x0001674C
		Friend Overridable Property comboSoundConEng15 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundConEng15
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundConEng15 = value
			End Set
		End Property

		' Token: 0x170000AC RID: 172
		' (get) Token: 0x06000175 RID: 373 RVA: 0x00018358 File Offset: 0x00016758
		' (set) Token: 0x06000176 RID: 374 RVA: 0x00018370 File Offset: 0x00016770
		Friend Overridable Property comboSoundConEng14 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundConEng14
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundConEng14 = value
			End Set
		End Property

		' Token: 0x170000AD RID: 173
		' (get) Token: 0x06000177 RID: 375 RVA: 0x0001837C File Offset: 0x0001677C
		' (set) Token: 0x06000178 RID: 376 RVA: 0x00018394 File Offset: 0x00016794
		Friend Overridable Property comboSoundConEng13 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundConEng13
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundConEng13 = value
			End Set
		End Property

		' Token: 0x170000AE RID: 174
		' (get) Token: 0x06000179 RID: 377 RVA: 0x000183A0 File Offset: 0x000167A0
		' (set) Token: 0x0600017A RID: 378 RVA: 0x000183B8 File Offset: 0x000167B8
		Friend Overridable Property comboSoundCon15 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundCon15
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundCon15 = value
			End Set
		End Property

		' Token: 0x170000AF RID: 175
		' (get) Token: 0x0600017B RID: 379 RVA: 0x000183C4 File Offset: 0x000167C4
		' (set) Token: 0x0600017C RID: 380 RVA: 0x000183DC File Offset: 0x000167DC
		Friend Overridable Property comboSoundCon14 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundCon14
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundCon14 = value
			End Set
		End Property

		' Token: 0x170000B0 RID: 176
		' (get) Token: 0x0600017D RID: 381 RVA: 0x000183E8 File Offset: 0x000167E8
		' (set) Token: 0x0600017E RID: 382 RVA: 0x00018400 File Offset: 0x00016800
		Friend Overridable Property comboSoundCon13 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundCon13
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundCon13 = value
			End Set
		End Property

		' Token: 0x170000B1 RID: 177
		' (get) Token: 0x0600017F RID: 383 RVA: 0x0001840C File Offset: 0x0001680C
		' (set) Token: 0x06000180 RID: 384 RVA: 0x00018424 File Offset: 0x00016824
		Friend Overridable Property chkCon15 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkCon15
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkCon15_CheckedChanged
				Dim flag As Boolean = Me._chkCon15 IsNot Nothing
				If flag Then
					RemoveHandler Me._chkCon15.CheckedChanged, eventHandler
				End If
				Me._chkCon15 = value
				flag = Me._chkCon15 IsNot Nothing
				If flag Then
					AddHandler Me._chkCon15.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170000B2 RID: 178
		' (get) Token: 0x06000181 RID: 385 RVA: 0x00018484 File Offset: 0x00016884
		' (set) Token: 0x06000182 RID: 386 RVA: 0x0001849C File Offset: 0x0001689C
		Friend Overridable Property btnPlay15 As Button
			<DebuggerNonUserCode()>
			Get
				Return Me._btnPlay15
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnPlay15_Click
				Dim flag As Boolean = Me._btnPlay15 IsNot Nothing
				If flag Then
					RemoveHandler Me._btnPlay15.Click, eventHandler
				End If
				Me._btnPlay15 = value
				flag = Me._btnPlay15 IsNot Nothing
				If flag Then
					AddHandler Me._btnPlay15.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170000B3 RID: 179
		' (get) Token: 0x06000183 RID: 387 RVA: 0x000184FC File Offset: 0x000168FC
		' (set) Token: 0x06000184 RID: 388 RVA: 0x00018514 File Offset: 0x00016914
		Friend Overridable Property comboMin15 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboMin15
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboMin15 = value
			End Set
		End Property

		' Token: 0x170000B4 RID: 180
		' (get) Token: 0x06000185 RID: 389 RVA: 0x00018520 File Offset: 0x00016920
		' (set) Token: 0x06000186 RID: 390 RVA: 0x00018538 File Offset: 0x00016938
		Friend Overridable Property comboHour15 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboHour15
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboHour15 = value
			End Set
		End Property

		' Token: 0x170000B5 RID: 181
		' (get) Token: 0x06000187 RID: 391 RVA: 0x00018544 File Offset: 0x00016944
		' (set) Token: 0x06000188 RID: 392 RVA: 0x0001855C File Offset: 0x0001695C
		Friend Overridable Property chkCon14 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkCon14
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkCon14_CheckedChanged
				Dim flag As Boolean = Me._chkCon14 IsNot Nothing
				If flag Then
					RemoveHandler Me._chkCon14.CheckedChanged, eventHandler
				End If
				Me._chkCon14 = value
				flag = Me._chkCon14 IsNot Nothing
				If flag Then
					AddHandler Me._chkCon14.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170000B6 RID: 182
		' (get) Token: 0x06000189 RID: 393 RVA: 0x000185BC File Offset: 0x000169BC
		' (set) Token: 0x0600018A RID: 394 RVA: 0x000185D4 File Offset: 0x000169D4
		Friend Overridable Property btnPlay14 As Button
			<DebuggerNonUserCode()>
			Get
				Return Me._btnPlay14
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnPlay14_Click
				Dim flag As Boolean = Me._btnPlay14 IsNot Nothing
				If flag Then
					RemoveHandler Me._btnPlay14.Click, eventHandler
				End If
				Me._btnPlay14 = value
				flag = Me._btnPlay14 IsNot Nothing
				If flag Then
					AddHandler Me._btnPlay14.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170000B7 RID: 183
		' (get) Token: 0x0600018B RID: 395 RVA: 0x00018634 File Offset: 0x00016A34
		' (set) Token: 0x0600018C RID: 396 RVA: 0x0001864C File Offset: 0x00016A4C
		Friend Overridable Property comboMin14 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboMin14
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboMin14 = value
			End Set
		End Property

		' Token: 0x170000B8 RID: 184
		' (get) Token: 0x0600018D RID: 397 RVA: 0x00018658 File Offset: 0x00016A58
		' (set) Token: 0x0600018E RID: 398 RVA: 0x00018670 File Offset: 0x00016A70
		Friend Overridable Property comboHour14 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboHour14
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboHour14 = value
			End Set
		End Property

		' Token: 0x170000B9 RID: 185
		' (get) Token: 0x0600018F RID: 399 RVA: 0x0001867C File Offset: 0x00016A7C
		' (set) Token: 0x06000190 RID: 400 RVA: 0x00018694 File Offset: 0x00016A94
		Friend Overridable Property chkCon13 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkCon13
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkCon13_CheckedChanged
				Dim flag As Boolean = Me._chkCon13 IsNot Nothing
				If flag Then
					RemoveHandler Me._chkCon13.CheckedChanged, eventHandler
				End If
				Me._chkCon13 = value
				flag = Me._chkCon13 IsNot Nothing
				If flag Then
					AddHandler Me._chkCon13.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170000BA RID: 186
		' (get) Token: 0x06000191 RID: 401 RVA: 0x000186F4 File Offset: 0x00016AF4
		' (set) Token: 0x06000192 RID: 402 RVA: 0x0001870C File Offset: 0x00016B0C
		Friend Overridable Property btnPlay13 As Button
			<DebuggerNonUserCode()>
			Get
				Return Me._btnPlay13
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnPlay13_Click
				Dim flag As Boolean = Me._btnPlay13 IsNot Nothing
				If flag Then
					RemoveHandler Me._btnPlay13.Click, eventHandler
				End If
				Me._btnPlay13 = value
				flag = Me._btnPlay13 IsNot Nothing
				If flag Then
					AddHandler Me._btnPlay13.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170000BB RID: 187
		' (get) Token: 0x06000193 RID: 403 RVA: 0x0001876C File Offset: 0x00016B6C
		' (set) Token: 0x06000194 RID: 404 RVA: 0x00018784 File Offset: 0x00016B84
		Friend Overridable Property comboMin13 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboMin13
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboMin13 = value
			End Set
		End Property

		' Token: 0x170000BC RID: 188
		' (get) Token: 0x06000195 RID: 405 RVA: 0x00018790 File Offset: 0x00016B90
		' (set) Token: 0x06000196 RID: 406 RVA: 0x000187A8 File Offset: 0x00016BA8
		Friend Overridable Property comboHour13 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboHour13
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboHour13 = value
			End Set
		End Property

		' Token: 0x170000BD RID: 189
		' (get) Token: 0x06000197 RID: 407 RVA: 0x000187B4 File Offset: 0x00016BB4
		' (set) Token: 0x06000198 RID: 408 RVA: 0x000187CC File Offset: 0x00016BCC
		Friend Overridable Property chkFirst12 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkFirst12
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkFirst12 = value
			End Set
		End Property

		' Token: 0x170000BE RID: 190
		' (get) Token: 0x06000199 RID: 409 RVA: 0x000187D8 File Offset: 0x00016BD8
		' (set) Token: 0x0600019A RID: 410 RVA: 0x000187F0 File Offset: 0x00016BF0
		Friend Overridable Property chkFirst11 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkFirst11
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkFirst11 = value
			End Set
		End Property

		' Token: 0x170000BF RID: 191
		' (get) Token: 0x0600019B RID: 411 RVA: 0x000187FC File Offset: 0x00016BFC
		' (set) Token: 0x0600019C RID: 412 RVA: 0x00018814 File Offset: 0x00016C14
		Friend Overridable Property chkFirst10 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkFirst10
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkFirst10 = value
			End Set
		End Property

		' Token: 0x170000C0 RID: 192
		' (get) Token: 0x0600019D RID: 413 RVA: 0x00018820 File Offset: 0x00016C20
		' (set) Token: 0x0600019E RID: 414 RVA: 0x00018838 File Offset: 0x00016C38
		Friend Overridable Property chkFirst9 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkFirst9
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkFirst9 = value
			End Set
		End Property

		' Token: 0x170000C1 RID: 193
		' (get) Token: 0x0600019F RID: 415 RVA: 0x00018844 File Offset: 0x00016C44
		' (set) Token: 0x060001A0 RID: 416 RVA: 0x0001885C File Offset: 0x00016C5C
		Friend Overridable Property chkFirst8 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkFirst8
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkFirst8 = value
			End Set
		End Property

		' Token: 0x170000C2 RID: 194
		' (get) Token: 0x060001A1 RID: 417 RVA: 0x00018868 File Offset: 0x00016C68
		' (set) Token: 0x060001A2 RID: 418 RVA: 0x00018880 File Offset: 0x00016C80
		Friend Overridable Property chkFirst7 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkFirst7
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkFirst7 = value
			End Set
		End Property

		' Token: 0x170000C3 RID: 195
		' (get) Token: 0x060001A3 RID: 419 RVA: 0x0001888C File Offset: 0x00016C8C
		' (set) Token: 0x060001A4 RID: 420 RVA: 0x000188A4 File Offset: 0x00016CA4
		Friend Overridable Property chkFirst6 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkFirst6
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkFirst6 = value
			End Set
		End Property

		' Token: 0x170000C4 RID: 196
		' (get) Token: 0x060001A5 RID: 421 RVA: 0x000188B0 File Offset: 0x00016CB0
		' (set) Token: 0x060001A6 RID: 422 RVA: 0x000188C8 File Offset: 0x00016CC8
		Friend Overridable Property chkFirst5 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkFirst5
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkFirst5 = value
			End Set
		End Property

		' Token: 0x170000C5 RID: 197
		' (get) Token: 0x060001A7 RID: 423 RVA: 0x000188D4 File Offset: 0x00016CD4
		' (set) Token: 0x060001A8 RID: 424 RVA: 0x000188EC File Offset: 0x00016CEC
		Friend Overridable Property chkFirst4 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkFirst4
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkFirst4 = value
			End Set
		End Property

		' Token: 0x170000C6 RID: 198
		' (get) Token: 0x060001A9 RID: 425 RVA: 0x000188F8 File Offset: 0x00016CF8
		' (set) Token: 0x060001AA RID: 426 RVA: 0x00018910 File Offset: 0x00016D10
		Friend Overridable Property chkFirst3 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkFirst3
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkFirst3 = value
			End Set
		End Property

		' Token: 0x170000C7 RID: 199
		' (get) Token: 0x060001AB RID: 427 RVA: 0x0001891C File Offset: 0x00016D1C
		' (set) Token: 0x060001AC RID: 428 RVA: 0x00018934 File Offset: 0x00016D34
		Friend Overridable Property chkFirst2 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkFirst2
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkFirst2 = value
			End Set
		End Property

		' Token: 0x170000C8 RID: 200
		' (get) Token: 0x060001AD RID: 429 RVA: 0x00018940 File Offset: 0x00016D40
		' (set) Token: 0x060001AE RID: 430 RVA: 0x00018958 File Offset: 0x00016D58
		Friend Overridable Property chkFirst1 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkFirst1
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkFirst1 = value
			End Set
		End Property

		' Token: 0x170000C9 RID: 201
		' (get) Token: 0x060001AF RID: 431 RVA: 0x00018964 File Offset: 0x00016D64
		' (set) Token: 0x060001B0 RID: 432 RVA: 0x0001897C File Offset: 0x00016D7C
		Friend Overridable Property chkLast12 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkLast12
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkLast12 = value
			End Set
		End Property

		' Token: 0x170000CA RID: 202
		' (get) Token: 0x060001B1 RID: 433 RVA: 0x00018988 File Offset: 0x00016D88
		' (set) Token: 0x060001B2 RID: 434 RVA: 0x000189A0 File Offset: 0x00016DA0
		Friend Overridable Property chkLast11 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkLast11
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkLast11 = value
			End Set
		End Property

		' Token: 0x170000CB RID: 203
		' (get) Token: 0x060001B3 RID: 435 RVA: 0x000189AC File Offset: 0x00016DAC
		' (set) Token: 0x060001B4 RID: 436 RVA: 0x000189C4 File Offset: 0x00016DC4
		Friend Overridable Property chkLast10 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkLast10
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkLast10 = value
			End Set
		End Property

		' Token: 0x170000CC RID: 204
		' (get) Token: 0x060001B5 RID: 437 RVA: 0x000189D0 File Offset: 0x00016DD0
		' (set) Token: 0x060001B6 RID: 438 RVA: 0x000189E8 File Offset: 0x00016DE8
		Friend Overridable Property chkLast9 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkLast9
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkLast9 = value
			End Set
		End Property

		' Token: 0x170000CD RID: 205
		' (get) Token: 0x060001B7 RID: 439 RVA: 0x000189F4 File Offset: 0x00016DF4
		' (set) Token: 0x060001B8 RID: 440 RVA: 0x00018A0C File Offset: 0x00016E0C
		Friend Overridable Property chkLast8 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkLast8
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkLast8 = value
			End Set
		End Property

		' Token: 0x170000CE RID: 206
		' (get) Token: 0x060001B9 RID: 441 RVA: 0x00018A18 File Offset: 0x00016E18
		' (set) Token: 0x060001BA RID: 442 RVA: 0x00018A30 File Offset: 0x00016E30
		Friend Overridable Property chkLast7 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkLast7
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkLast7 = value
			End Set
		End Property

		' Token: 0x170000CF RID: 207
		' (get) Token: 0x060001BB RID: 443 RVA: 0x00018A3C File Offset: 0x00016E3C
		' (set) Token: 0x060001BC RID: 444 RVA: 0x00018A54 File Offset: 0x00016E54
		Friend Overridable Property chkLast6 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkLast6
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkLast6 = value
			End Set
		End Property

		' Token: 0x170000D0 RID: 208
		' (get) Token: 0x060001BD RID: 445 RVA: 0x00018A60 File Offset: 0x00016E60
		' (set) Token: 0x060001BE RID: 446 RVA: 0x00018A78 File Offset: 0x00016E78
		Friend Overridable Property chkLast5 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkLast5
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkLast5 = value
			End Set
		End Property

		' Token: 0x170000D1 RID: 209
		' (get) Token: 0x060001BF RID: 447 RVA: 0x00018A84 File Offset: 0x00016E84
		' (set) Token: 0x060001C0 RID: 448 RVA: 0x00018A9C File Offset: 0x00016E9C
		Friend Overridable Property chkLast4 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkLast4
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkLast4 = value
			End Set
		End Property

		' Token: 0x170000D2 RID: 210
		' (get) Token: 0x060001C1 RID: 449 RVA: 0x00018AA8 File Offset: 0x00016EA8
		' (set) Token: 0x060001C2 RID: 450 RVA: 0x00018AC0 File Offset: 0x00016EC0
		Friend Overridable Property chkLast3 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkLast3
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkLast3 = value
			End Set
		End Property

		' Token: 0x170000D3 RID: 211
		' (get) Token: 0x060001C3 RID: 451 RVA: 0x00018ACC File Offset: 0x00016ECC
		' (set) Token: 0x060001C4 RID: 452 RVA: 0x00018AE4 File Offset: 0x00016EE4
		Friend Overridable Property chkLast2 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkLast2
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkLast2 = value
			End Set
		End Property

		' Token: 0x170000D4 RID: 212
		' (get) Token: 0x060001C5 RID: 453 RVA: 0x00018AF0 File Offset: 0x00016EF0
		' (set) Token: 0x060001C6 RID: 454 RVA: 0x00018B08 File Offset: 0x00016F08
		Friend Overridable Property chkLast1 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkLast1
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkLast1 = value
			End Set
		End Property

		' Token: 0x170000D5 RID: 213
		' (get) Token: 0x060001C7 RID: 455 RVA: 0x00018B14 File Offset: 0x00016F14
		' (set) Token: 0x060001C8 RID: 456 RVA: 0x00018B2C File Offset: 0x00016F2C
		Friend Overridable Property lblSuguest As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lblSuguest
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lblSuguest = value
			End Set
		End Property

		' Token: 0x170000D6 RID: 214
		' (get) Token: 0x060001C9 RID: 457 RVA: 0x00018B38 File Offset: 0x00016F38
		' (set) Token: 0x060001CA RID: 458 RVA: 0x00018B50 File Offset: 0x00016F50
		Friend Overridable Property lblReadCon As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lblReadCon
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lblReadCon = value
			End Set
		End Property

		' Token: 0x170000D7 RID: 215
		' (get) Token: 0x060001CB RID: 459 RVA: 0x00018B5C File Offset: 0x00016F5C
		' (set) Token: 0x060001CC RID: 460 RVA: 0x00018B74 File Offset: 0x00016F74
		Friend Overridable Property PictureBox6 As PictureBox
			<DebuggerNonUserCode()>
			Get
				Return Me._PictureBox6
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As PictureBox)
				Me._PictureBox6 = value
			End Set
		End Property

		' Token: 0x170000D8 RID: 216
		' (get) Token: 0x060001CD RID: 461 RVA: 0x00018B80 File Offset: 0x00016F80
		' (set) Token: 0x060001CE RID: 462 RVA: 0x00018B98 File Offset: 0x00016F98
		Friend Overridable Property lblReadTime As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lblReadTime
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lblReadTime = value
			End Set
		End Property

		' Token: 0x170000D9 RID: 217
		' (get) Token: 0x060001CF RID: 463 RVA: 0x00018BA4 File Offset: 0x00016FA4
		' (set) Token: 0x060001D0 RID: 464 RVA: 0x00018BBC File Offset: 0x00016FBC
		Friend Overridable Property chkTime12 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkTime12
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkTime12 = value
			End Set
		End Property

		' Token: 0x170000DA RID: 218
		' (get) Token: 0x060001D1 RID: 465 RVA: 0x00018BC8 File Offset: 0x00016FC8
		' (set) Token: 0x060001D2 RID: 466 RVA: 0x00018BE0 File Offset: 0x00016FE0
		Friend Overridable Property chkTime11 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkTime11
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkTime11 = value
			End Set
		End Property

		' Token: 0x170000DB RID: 219
		' (get) Token: 0x060001D3 RID: 467 RVA: 0x00018BEC File Offset: 0x00016FEC
		' (set) Token: 0x060001D4 RID: 468 RVA: 0x00018C04 File Offset: 0x00017004
		Friend Overridable Property chkTime10 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkTime10
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkTime10 = value
			End Set
		End Property

		' Token: 0x170000DC RID: 220
		' (get) Token: 0x060001D5 RID: 469 RVA: 0x00018C10 File Offset: 0x00017010
		' (set) Token: 0x060001D6 RID: 470 RVA: 0x00018C28 File Offset: 0x00017028
		Friend Overridable Property chkTime9 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkTime9
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkTime9 = value
			End Set
		End Property

		' Token: 0x170000DD RID: 221
		' (get) Token: 0x060001D7 RID: 471 RVA: 0x00018C34 File Offset: 0x00017034
		' (set) Token: 0x060001D8 RID: 472 RVA: 0x00018C4C File Offset: 0x0001704C
		Friend Overridable Property chkTime8 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkTime8
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkTime8 = value
			End Set
		End Property

		' Token: 0x170000DE RID: 222
		' (get) Token: 0x060001D9 RID: 473 RVA: 0x00018C58 File Offset: 0x00017058
		' (set) Token: 0x060001DA RID: 474 RVA: 0x00018C70 File Offset: 0x00017070
		Friend Overridable Property chkTime7 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkTime7
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkTime7 = value
			End Set
		End Property

		' Token: 0x170000DF RID: 223
		' (get) Token: 0x060001DB RID: 475 RVA: 0x00018C7C File Offset: 0x0001707C
		' (set) Token: 0x060001DC RID: 476 RVA: 0x00018C94 File Offset: 0x00017094
		Friend Overridable Property chkTime6 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkTime6
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkTime6 = value
			End Set
		End Property

		' Token: 0x170000E0 RID: 224
		' (get) Token: 0x060001DD RID: 477 RVA: 0x00018CA0 File Offset: 0x000170A0
		' (set) Token: 0x060001DE RID: 478 RVA: 0x00018CB8 File Offset: 0x000170B8
		Friend Overridable Property chkTime5 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkTime5
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkTime5 = value
			End Set
		End Property

		' Token: 0x170000E1 RID: 225
		' (get) Token: 0x060001DF RID: 479 RVA: 0x00018CC4 File Offset: 0x000170C4
		' (set) Token: 0x060001E0 RID: 480 RVA: 0x00018CDC File Offset: 0x000170DC
		Friend Overridable Property chkTime4 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkTime4
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkTime4 = value
			End Set
		End Property

		' Token: 0x170000E2 RID: 226
		' (get) Token: 0x060001E1 RID: 481 RVA: 0x00018CE8 File Offset: 0x000170E8
		' (set) Token: 0x060001E2 RID: 482 RVA: 0x00018D00 File Offset: 0x00017100
		Friend Overridable Property chkTime3 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkTime3
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkTime3 = value
			End Set
		End Property

		' Token: 0x170000E3 RID: 227
		' (get) Token: 0x060001E3 RID: 483 RVA: 0x00018D0C File Offset: 0x0001710C
		' (set) Token: 0x060001E4 RID: 484 RVA: 0x00018D24 File Offset: 0x00017124
		Friend Overridable Property chkTime2 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkTime2
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkTime2 = value
			End Set
		End Property

		' Token: 0x170000E4 RID: 228
		' (get) Token: 0x060001E5 RID: 485 RVA: 0x00018D30 File Offset: 0x00017130
		' (set) Token: 0x060001E6 RID: 486 RVA: 0x00018D48 File Offset: 0x00017148
		Friend Overridable Property chkTime1 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkTime1
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkTime1 = value
			End Set
		End Property

		' Token: 0x170000E5 RID: 229
		' (get) Token: 0x060001E7 RID: 487 RVA: 0x00018D54 File Offset: 0x00017154
		' (set) Token: 0x060001E8 RID: 488 RVA: 0x00018D6C File Offset: 0x0001716C
		Friend Overridable Property comboSoundConEng12 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundConEng12
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundConEng12 = value
			End Set
		End Property

		' Token: 0x170000E6 RID: 230
		' (get) Token: 0x060001E9 RID: 489 RVA: 0x00018D78 File Offset: 0x00017178
		' (set) Token: 0x060001EA RID: 490 RVA: 0x00018D90 File Offset: 0x00017190
		Friend Overridable Property comboSoundConEng11 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundConEng11
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundConEng11 = value
			End Set
		End Property

		' Token: 0x170000E7 RID: 231
		' (get) Token: 0x060001EB RID: 491 RVA: 0x00018D9C File Offset: 0x0001719C
		' (set) Token: 0x060001EC RID: 492 RVA: 0x00018DB4 File Offset: 0x000171B4
		Friend Overridable Property comboSoundConEng10 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundConEng10
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundConEng10 = value
			End Set
		End Property

		' Token: 0x170000E8 RID: 232
		' (get) Token: 0x060001ED RID: 493 RVA: 0x00018DC0 File Offset: 0x000171C0
		' (set) Token: 0x060001EE RID: 494 RVA: 0x00018DD8 File Offset: 0x000171D8
		Friend Overridable Property comboSoundConEng9 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundConEng9
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundConEng9 = value
			End Set
		End Property

		' Token: 0x170000E9 RID: 233
		' (get) Token: 0x060001EF RID: 495 RVA: 0x00018DE4 File Offset: 0x000171E4
		' (set) Token: 0x060001F0 RID: 496 RVA: 0x00018DFC File Offset: 0x000171FC
		Friend Overridable Property comboSoundConEng8 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundConEng8
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundConEng8 = value
			End Set
		End Property

		' Token: 0x170000EA RID: 234
		' (get) Token: 0x060001F1 RID: 497 RVA: 0x00018E08 File Offset: 0x00017208
		' (set) Token: 0x060001F2 RID: 498 RVA: 0x00018E20 File Offset: 0x00017220
		Friend Overridable Property comboSoundConEng7 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundConEng7
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundConEng7 = value
			End Set
		End Property

		' Token: 0x170000EB RID: 235
		' (get) Token: 0x060001F3 RID: 499 RVA: 0x00018E2C File Offset: 0x0001722C
		' (set) Token: 0x060001F4 RID: 500 RVA: 0x00018E44 File Offset: 0x00017244
		Friend Overridable Property comboSoundConEng6 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundConEng6
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundConEng6 = value
			End Set
		End Property

		' Token: 0x170000EC RID: 236
		' (get) Token: 0x060001F5 RID: 501 RVA: 0x00018E50 File Offset: 0x00017250
		' (set) Token: 0x060001F6 RID: 502 RVA: 0x00018E68 File Offset: 0x00017268
		Friend Overridable Property comboSoundConEng5 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundConEng5
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundConEng5 = value
			End Set
		End Property

		' Token: 0x170000ED RID: 237
		' (get) Token: 0x060001F7 RID: 503 RVA: 0x00018E74 File Offset: 0x00017274
		' (set) Token: 0x060001F8 RID: 504 RVA: 0x00018E8C File Offset: 0x0001728C
		Friend Overridable Property comboSoundConEng4 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundConEng4
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundConEng4 = value
			End Set
		End Property

		' Token: 0x170000EE RID: 238
		' (get) Token: 0x060001F9 RID: 505 RVA: 0x00018E98 File Offset: 0x00017298
		' (set) Token: 0x060001FA RID: 506 RVA: 0x00018EB0 File Offset: 0x000172B0
		Friend Overridable Property comboSoundConEng3 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundConEng3
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundConEng3 = value
			End Set
		End Property

		' Token: 0x170000EF RID: 239
		' (get) Token: 0x060001FB RID: 507 RVA: 0x00018EBC File Offset: 0x000172BC
		' (set) Token: 0x060001FC RID: 508 RVA: 0x00018ED4 File Offset: 0x000172D4
		Friend Overridable Property comboSoundConEng2 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundConEng2
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundConEng2 = value
			End Set
		End Property

		' Token: 0x170000F0 RID: 240
		' (get) Token: 0x060001FD RID: 509 RVA: 0x00018EE0 File Offset: 0x000172E0
		' (set) Token: 0x060001FE RID: 510 RVA: 0x00018EF8 File Offset: 0x000172F8
		Friend Overridable Property comboSoundConEng1 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundConEng1
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundConEng1 = value
			End Set
		End Property

		' Token: 0x170000F1 RID: 241
		' (get) Token: 0x060001FF RID: 511 RVA: 0x00018F04 File Offset: 0x00017304
		' (set) Token: 0x06000200 RID: 512 RVA: 0x00018F1C File Offset: 0x0001731C
		Friend Overridable Property comboSoundCon12 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundCon12
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundCon12 = value
			End Set
		End Property

		' Token: 0x170000F2 RID: 242
		' (get) Token: 0x06000201 RID: 513 RVA: 0x00018F28 File Offset: 0x00017328
		' (set) Token: 0x06000202 RID: 514 RVA: 0x00018F40 File Offset: 0x00017340
		Friend Overridable Property comboSoundCon11 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundCon11
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundCon11 = value
			End Set
		End Property

		' Token: 0x170000F3 RID: 243
		' (get) Token: 0x06000203 RID: 515 RVA: 0x00018F4C File Offset: 0x0001734C
		' (set) Token: 0x06000204 RID: 516 RVA: 0x00018F64 File Offset: 0x00017364
		Friend Overridable Property comboSoundCon10 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundCon10
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundCon10 = value
			End Set
		End Property

		' Token: 0x170000F4 RID: 244
		' (get) Token: 0x06000205 RID: 517 RVA: 0x00018F70 File Offset: 0x00017370
		' (set) Token: 0x06000206 RID: 518 RVA: 0x00018F88 File Offset: 0x00017388
		Friend Overridable Property comboSoundCon9 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundCon9
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundCon9 = value
			End Set
		End Property

		' Token: 0x170000F5 RID: 245
		' (get) Token: 0x06000207 RID: 519 RVA: 0x00018F94 File Offset: 0x00017394
		' (set) Token: 0x06000208 RID: 520 RVA: 0x00018FAC File Offset: 0x000173AC
		Friend Overridable Property comboSoundCon8 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundCon8
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundCon8 = value
			End Set
		End Property

		' Token: 0x170000F6 RID: 246
		' (get) Token: 0x06000209 RID: 521 RVA: 0x00018FB8 File Offset: 0x000173B8
		' (set) Token: 0x0600020A RID: 522 RVA: 0x00018FD0 File Offset: 0x000173D0
		Friend Overridable Property comboSoundCon7 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundCon7
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundCon7 = value
			End Set
		End Property

		' Token: 0x170000F7 RID: 247
		' (get) Token: 0x0600020B RID: 523 RVA: 0x00018FDC File Offset: 0x000173DC
		' (set) Token: 0x0600020C RID: 524 RVA: 0x00018FF4 File Offset: 0x000173F4
		Friend Overridable Property comboSoundCon6 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundCon6
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundCon6 = value
			End Set
		End Property

		' Token: 0x170000F8 RID: 248
		' (get) Token: 0x0600020D RID: 525 RVA: 0x00019000 File Offset: 0x00017400
		' (set) Token: 0x0600020E RID: 526 RVA: 0x00019018 File Offset: 0x00017418
		Friend Overridable Property comboSoundCon5 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundCon5
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundCon5 = value
			End Set
		End Property

		' Token: 0x170000F9 RID: 249
		' (get) Token: 0x0600020F RID: 527 RVA: 0x00019024 File Offset: 0x00017424
		' (set) Token: 0x06000210 RID: 528 RVA: 0x0001903C File Offset: 0x0001743C
		Friend Overridable Property comboSoundCon4 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundCon4
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundCon4 = value
			End Set
		End Property

		' Token: 0x170000FA RID: 250
		' (get) Token: 0x06000211 RID: 529 RVA: 0x00019048 File Offset: 0x00017448
		' (set) Token: 0x06000212 RID: 530 RVA: 0x00019060 File Offset: 0x00017460
		Friend Overridable Property comboSoundCon3 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundCon3
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundCon3 = value
			End Set
		End Property

		' Token: 0x170000FB RID: 251
		' (get) Token: 0x06000213 RID: 531 RVA: 0x0001906C File Offset: 0x0001746C
		' (set) Token: 0x06000214 RID: 532 RVA: 0x00019084 File Offset: 0x00017484
		Friend Overridable Property comboSoundCon2 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundCon2
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundCon2 = value
			End Set
		End Property

		' Token: 0x170000FC RID: 252
		' (get) Token: 0x06000215 RID: 533 RVA: 0x00019090 File Offset: 0x00017490
		' (set) Token: 0x06000216 RID: 534 RVA: 0x000190A8 File Offset: 0x000174A8
		Friend Overridable Property comboSoundCon1 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboSoundCon1
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboSoundCon1 = value
			End Set
		End Property

		' Token: 0x170000FD RID: 253
		' (get) Token: 0x06000217 RID: 535 RVA: 0x000190B4 File Offset: 0x000174B4
		' (set) Token: 0x06000218 RID: 536 RVA: 0x000190CC File Offset: 0x000174CC
		Friend Overridable Property chkCon12 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkCon12
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkCon12_CheckedChanged
				Dim flag As Boolean = Me._chkCon12 IsNot Nothing
				If flag Then
					RemoveHandler Me._chkCon12.CheckedChanged, eventHandler
				End If
				Me._chkCon12 = value
				flag = Me._chkCon12 IsNot Nothing
				If flag Then
					AddHandler Me._chkCon12.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170000FE RID: 254
		' (get) Token: 0x06000219 RID: 537 RVA: 0x0001912C File Offset: 0x0001752C
		' (set) Token: 0x0600021A RID: 538 RVA: 0x00019144 File Offset: 0x00017544
		Friend Overridable Property btnPlay12 As Button
			<DebuggerNonUserCode()>
			Get
				Return Me._btnPlay12
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnPlay12_Click
				Dim flag As Boolean = Me._btnPlay12 IsNot Nothing
				If flag Then
					RemoveHandler Me._btnPlay12.Click, eventHandler
				End If
				Me._btnPlay12 = value
				flag = Me._btnPlay12 IsNot Nothing
				If flag Then
					AddHandler Me._btnPlay12.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x170000FF RID: 255
		' (get) Token: 0x0600021B RID: 539 RVA: 0x000191A4 File Offset: 0x000175A4
		' (set) Token: 0x0600021C RID: 540 RVA: 0x000191BC File Offset: 0x000175BC
		Friend Overridable Property comboMin12 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboMin12
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboMin12 = value
			End Set
		End Property

		' Token: 0x17000100 RID: 256
		' (get) Token: 0x0600021D RID: 541 RVA: 0x000191C8 File Offset: 0x000175C8
		' (set) Token: 0x0600021E RID: 542 RVA: 0x000191E0 File Offset: 0x000175E0
		Friend Overridable Property comboHour12 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboHour12
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboHour12 = value
			End Set
		End Property

		' Token: 0x17000101 RID: 257
		' (get) Token: 0x0600021F RID: 543 RVA: 0x000191EC File Offset: 0x000175EC
		' (set) Token: 0x06000220 RID: 544 RVA: 0x00019204 File Offset: 0x00017604
		Friend Overridable Property chkCon11 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkCon11
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkCon11_CheckedChanged
				Dim flag As Boolean = Me._chkCon11 IsNot Nothing
				If flag Then
					RemoveHandler Me._chkCon11.CheckedChanged, eventHandler
				End If
				Me._chkCon11 = value
				flag = Me._chkCon11 IsNot Nothing
				If flag Then
					AddHandler Me._chkCon11.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000102 RID: 258
		' (get) Token: 0x06000221 RID: 545 RVA: 0x00019264 File Offset: 0x00017664
		' (set) Token: 0x06000222 RID: 546 RVA: 0x0001927C File Offset: 0x0001767C
		Friend Overridable Property btnPlay11 As Button
			<DebuggerNonUserCode()>
			Get
				Return Me._btnPlay11
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnPlay11_Click
				Dim flag As Boolean = Me._btnPlay11 IsNot Nothing
				If flag Then
					RemoveHandler Me._btnPlay11.Click, eventHandler
				End If
				Me._btnPlay11 = value
				flag = Me._btnPlay11 IsNot Nothing
				If flag Then
					AddHandler Me._btnPlay11.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000103 RID: 259
		' (get) Token: 0x06000223 RID: 547 RVA: 0x000192DC File Offset: 0x000176DC
		' (set) Token: 0x06000224 RID: 548 RVA: 0x000192F4 File Offset: 0x000176F4
		Friend Overridable Property comboMin11 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboMin11
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboMin11 = value
			End Set
		End Property

		' Token: 0x17000104 RID: 260
		' (get) Token: 0x06000225 RID: 549 RVA: 0x00019300 File Offset: 0x00017700
		' (set) Token: 0x06000226 RID: 550 RVA: 0x00019318 File Offset: 0x00017718
		Friend Overridable Property comboHour11 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboHour11
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboHour11 = value
			End Set
		End Property

		' Token: 0x17000105 RID: 261
		' (get) Token: 0x06000227 RID: 551 RVA: 0x00019324 File Offset: 0x00017724
		' (set) Token: 0x06000228 RID: 552 RVA: 0x0001933C File Offset: 0x0001773C
		Friend Overridable Property chkCon10 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkCon10
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkCon10_CheckedChanged
				Dim flag As Boolean = Me._chkCon10 IsNot Nothing
				If flag Then
					RemoveHandler Me._chkCon10.CheckedChanged, eventHandler
				End If
				Me._chkCon10 = value
				flag = Me._chkCon10 IsNot Nothing
				If flag Then
					AddHandler Me._chkCon10.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000106 RID: 262
		' (get) Token: 0x06000229 RID: 553 RVA: 0x0001939C File Offset: 0x0001779C
		' (set) Token: 0x0600022A RID: 554 RVA: 0x000193B4 File Offset: 0x000177B4
		Friend Overridable Property btnPlay10 As Button
			<DebuggerNonUserCode()>
			Get
				Return Me._btnPlay10
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnPlay10_Click
				Dim flag As Boolean = Me._btnPlay10 IsNot Nothing
				If flag Then
					RemoveHandler Me._btnPlay10.Click, eventHandler
				End If
				Me._btnPlay10 = value
				flag = Me._btnPlay10 IsNot Nothing
				If flag Then
					AddHandler Me._btnPlay10.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000107 RID: 263
		' (get) Token: 0x0600022B RID: 555 RVA: 0x00019414 File Offset: 0x00017814
		' (set) Token: 0x0600022C RID: 556 RVA: 0x0001942C File Offset: 0x0001782C
		Friend Overridable Property comboMin10 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboMin10
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboMin10 = value
			End Set
		End Property

		' Token: 0x17000108 RID: 264
		' (get) Token: 0x0600022D RID: 557 RVA: 0x00019438 File Offset: 0x00017838
		' (set) Token: 0x0600022E RID: 558 RVA: 0x00019450 File Offset: 0x00017850
		Friend Overridable Property comboHour10 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboHour10
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboHour10 = value
			End Set
		End Property

		' Token: 0x17000109 RID: 265
		' (get) Token: 0x0600022F RID: 559 RVA: 0x0001945C File Offset: 0x0001785C
		' (set) Token: 0x06000230 RID: 560 RVA: 0x00019474 File Offset: 0x00017874
		Friend Overridable Property chkCon9 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkCon9
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkCon9_CheckedChanged
				Dim flag As Boolean = Me._chkCon9 IsNot Nothing
				If flag Then
					RemoveHandler Me._chkCon9.CheckedChanged, eventHandler
				End If
				Me._chkCon9 = value
				flag = Me._chkCon9 IsNot Nothing
				If flag Then
					AddHandler Me._chkCon9.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700010A RID: 266
		' (get) Token: 0x06000231 RID: 561 RVA: 0x000194D4 File Offset: 0x000178D4
		' (set) Token: 0x06000232 RID: 562 RVA: 0x000194EC File Offset: 0x000178EC
		Friend Overridable Property btnPlay9 As Button
			<DebuggerNonUserCode()>
			Get
				Return Me._btnPlay9
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnPlay9_Click
				Dim flag As Boolean = Me._btnPlay9 IsNot Nothing
				If flag Then
					RemoveHandler Me._btnPlay9.Click, eventHandler
				End If
				Me._btnPlay9 = value
				flag = Me._btnPlay9 IsNot Nothing
				If flag Then
					AddHandler Me._btnPlay9.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700010B RID: 267
		' (get) Token: 0x06000233 RID: 563 RVA: 0x0001954C File Offset: 0x0001794C
		' (set) Token: 0x06000234 RID: 564 RVA: 0x00019564 File Offset: 0x00017964
		Friend Overridable Property comboMin9 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboMin9
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboMin9 = value
			End Set
		End Property

		' Token: 0x1700010C RID: 268
		' (get) Token: 0x06000235 RID: 565 RVA: 0x00019570 File Offset: 0x00017970
		' (set) Token: 0x06000236 RID: 566 RVA: 0x00019588 File Offset: 0x00017988
		Friend Overridable Property comboHour9 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboHour9
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboHour9 = value
			End Set
		End Property

		' Token: 0x1700010D RID: 269
		' (get) Token: 0x06000237 RID: 567 RVA: 0x00019594 File Offset: 0x00017994
		' (set) Token: 0x06000238 RID: 568 RVA: 0x000195AC File Offset: 0x000179AC
		Friend Overridable Property chkCon8 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkCon8
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkCon8_CheckedChanged
				Dim flag As Boolean = Me._chkCon8 IsNot Nothing
				If flag Then
					RemoveHandler Me._chkCon8.CheckedChanged, eventHandler
				End If
				Me._chkCon8 = value
				flag = Me._chkCon8 IsNot Nothing
				If flag Then
					AddHandler Me._chkCon8.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700010E RID: 270
		' (get) Token: 0x06000239 RID: 569 RVA: 0x0001960C File Offset: 0x00017A0C
		' (set) Token: 0x0600023A RID: 570 RVA: 0x00019624 File Offset: 0x00017A24
		Friend Overridable Property btnPlay8 As Button
			<DebuggerNonUserCode()>
			Get
				Return Me._btnPlay8
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnPlay8_Click
				Dim flag As Boolean = Me._btnPlay8 IsNot Nothing
				If flag Then
					RemoveHandler Me._btnPlay8.Click, eventHandler
				End If
				Me._btnPlay8 = value
				flag = Me._btnPlay8 IsNot Nothing
				If flag Then
					AddHandler Me._btnPlay8.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700010F RID: 271
		' (get) Token: 0x0600023B RID: 571 RVA: 0x00019684 File Offset: 0x00017A84
		' (set) Token: 0x0600023C RID: 572 RVA: 0x0001969C File Offset: 0x00017A9C
		Friend Overridable Property comboMin8 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboMin8
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboMin8 = value
			End Set
		End Property

		' Token: 0x17000110 RID: 272
		' (get) Token: 0x0600023D RID: 573 RVA: 0x000196A8 File Offset: 0x00017AA8
		' (set) Token: 0x0600023E RID: 574 RVA: 0x000196C0 File Offset: 0x00017AC0
		Friend Overridable Property comboHour8 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboHour8
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboHour8 = value
			End Set
		End Property

		' Token: 0x17000111 RID: 273
		' (get) Token: 0x0600023F RID: 575 RVA: 0x000196CC File Offset: 0x00017ACC
		' (set) Token: 0x06000240 RID: 576 RVA: 0x000196E4 File Offset: 0x00017AE4
		Friend Overridable Property chkCon7 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkCon7
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkCon7_CheckedChanged
				Dim flag As Boolean = Me._chkCon7 IsNot Nothing
				If flag Then
					RemoveHandler Me._chkCon7.CheckedChanged, eventHandler
				End If
				Me._chkCon7 = value
				flag = Me._chkCon7 IsNot Nothing
				If flag Then
					AddHandler Me._chkCon7.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000112 RID: 274
		' (get) Token: 0x06000241 RID: 577 RVA: 0x00019744 File Offset: 0x00017B44
		' (set) Token: 0x06000242 RID: 578 RVA: 0x0001975C File Offset: 0x00017B5C
		Friend Overridable Property btnPlay7 As Button
			<DebuggerNonUserCode()>
			Get
				Return Me._btnPlay7
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnPlay7_Click
				Dim flag As Boolean = Me._btnPlay7 IsNot Nothing
				If flag Then
					RemoveHandler Me._btnPlay7.Click, eventHandler
				End If
				Me._btnPlay7 = value
				flag = Me._btnPlay7 IsNot Nothing
				If flag Then
					AddHandler Me._btnPlay7.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000113 RID: 275
		' (get) Token: 0x06000243 RID: 579 RVA: 0x000197BC File Offset: 0x00017BBC
		' (set) Token: 0x06000244 RID: 580 RVA: 0x000197D4 File Offset: 0x00017BD4
		Friend Overridable Property comboMin7 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboMin7
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboMin7 = value
			End Set
		End Property

		' Token: 0x17000114 RID: 276
		' (get) Token: 0x06000245 RID: 581 RVA: 0x000197E0 File Offset: 0x00017BE0
		' (set) Token: 0x06000246 RID: 582 RVA: 0x000197F8 File Offset: 0x00017BF8
		Friend Overridable Property comboHour7 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboHour7
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboHour7 = value
			End Set
		End Property

		' Token: 0x17000115 RID: 277
		' (get) Token: 0x06000247 RID: 583 RVA: 0x00019804 File Offset: 0x00017C04
		' (set) Token: 0x06000248 RID: 584 RVA: 0x0001981C File Offset: 0x00017C1C
		Friend Overridable Property chkCon6 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkCon6
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkCon6_CheckedChanged
				Dim flag As Boolean = Me._chkCon6 IsNot Nothing
				If flag Then
					RemoveHandler Me._chkCon6.CheckedChanged, eventHandler
				End If
				Me._chkCon6 = value
				flag = Me._chkCon6 IsNot Nothing
				If flag Then
					AddHandler Me._chkCon6.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000116 RID: 278
		' (get) Token: 0x06000249 RID: 585 RVA: 0x0001987C File Offset: 0x00017C7C
		' (set) Token: 0x0600024A RID: 586 RVA: 0x00019894 File Offset: 0x00017C94
		Friend Overridable Property btnPlay6 As Button
			<DebuggerNonUserCode()>
			Get
				Return Me._btnPlay6
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnPlay6_Click
				Dim flag As Boolean = Me._btnPlay6 IsNot Nothing
				If flag Then
					RemoveHandler Me._btnPlay6.Click, eventHandler
				End If
				Me._btnPlay6 = value
				flag = Me._btnPlay6 IsNot Nothing
				If flag Then
					AddHandler Me._btnPlay6.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000117 RID: 279
		' (get) Token: 0x0600024B RID: 587 RVA: 0x000198F4 File Offset: 0x00017CF4
		' (set) Token: 0x0600024C RID: 588 RVA: 0x0001990C File Offset: 0x00017D0C
		Friend Overridable Property comboMin6 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboMin6
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboMin6 = value
			End Set
		End Property

		' Token: 0x17000118 RID: 280
		' (get) Token: 0x0600024D RID: 589 RVA: 0x00019918 File Offset: 0x00017D18
		' (set) Token: 0x0600024E RID: 590 RVA: 0x00019930 File Offset: 0x00017D30
		Friend Overridable Property comboHour6 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboHour6
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboHour6 = value
			End Set
		End Property

		' Token: 0x17000119 RID: 281
		' (get) Token: 0x0600024F RID: 591 RVA: 0x0001993C File Offset: 0x00017D3C
		' (set) Token: 0x06000250 RID: 592 RVA: 0x00019954 File Offset: 0x00017D54
		Friend Overridable Property chkCon5 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkCon5
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkCon5_CheckedChanged
				Dim flag As Boolean = Me._chkCon5 IsNot Nothing
				If flag Then
					RemoveHandler Me._chkCon5.CheckedChanged, eventHandler
				End If
				Me._chkCon5 = value
				flag = Me._chkCon5 IsNot Nothing
				If flag Then
					AddHandler Me._chkCon5.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700011A RID: 282
		' (get) Token: 0x06000251 RID: 593 RVA: 0x000199B4 File Offset: 0x00017DB4
		' (set) Token: 0x06000252 RID: 594 RVA: 0x000199CC File Offset: 0x00017DCC
		Friend Overridable Property btnPlay5 As Button
			<DebuggerNonUserCode()>
			Get
				Return Me._btnPlay5
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnPlay5_Click
				Dim flag As Boolean = Me._btnPlay5 IsNot Nothing
				If flag Then
					RemoveHandler Me._btnPlay5.Click, eventHandler
				End If
				Me._btnPlay5 = value
				flag = Me._btnPlay5 IsNot Nothing
				If flag Then
					AddHandler Me._btnPlay5.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700011B RID: 283
		' (get) Token: 0x06000253 RID: 595 RVA: 0x00019A2C File Offset: 0x00017E2C
		' (set) Token: 0x06000254 RID: 596 RVA: 0x00019A44 File Offset: 0x00017E44
		Friend Overridable Property comboMin5 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboMin5
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboMin5 = value
			End Set
		End Property

		' Token: 0x1700011C RID: 284
		' (get) Token: 0x06000255 RID: 597 RVA: 0x00019A50 File Offset: 0x00017E50
		' (set) Token: 0x06000256 RID: 598 RVA: 0x00019A68 File Offset: 0x00017E68
		Friend Overridable Property comboHour5 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboHour5
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboHour5 = value
			End Set
		End Property

		' Token: 0x1700011D RID: 285
		' (get) Token: 0x06000257 RID: 599 RVA: 0x00019A74 File Offset: 0x00017E74
		' (set) Token: 0x06000258 RID: 600 RVA: 0x00019A8C File Offset: 0x00017E8C
		Friend Overridable Property chkCon4 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkCon4
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkCon4_CheckedChanged
				Dim flag As Boolean = Me._chkCon4 IsNot Nothing
				If flag Then
					RemoveHandler Me._chkCon4.CheckedChanged, eventHandler
				End If
				Me._chkCon4 = value
				flag = Me._chkCon4 IsNot Nothing
				If flag Then
					AddHandler Me._chkCon4.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700011E RID: 286
		' (get) Token: 0x06000259 RID: 601 RVA: 0x00019AEC File Offset: 0x00017EEC
		' (set) Token: 0x0600025A RID: 602 RVA: 0x00019B04 File Offset: 0x00017F04
		Friend Overridable Property btnPlay4 As Button
			<DebuggerNonUserCode()>
			Get
				Return Me._btnPlay4
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnPlay4_Click
				Dim flag As Boolean = Me._btnPlay4 IsNot Nothing
				If flag Then
					RemoveHandler Me._btnPlay4.Click, eventHandler
				End If
				Me._btnPlay4 = value
				flag = Me._btnPlay4 IsNot Nothing
				If flag Then
					AddHandler Me._btnPlay4.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700011F RID: 287
		' (get) Token: 0x0600025B RID: 603 RVA: 0x00019B64 File Offset: 0x00017F64
		' (set) Token: 0x0600025C RID: 604 RVA: 0x00019B7C File Offset: 0x00017F7C
		Friend Overridable Property comboMin4 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboMin4
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboMin4 = value
			End Set
		End Property

		' Token: 0x17000120 RID: 288
		' (get) Token: 0x0600025D RID: 605 RVA: 0x00019B88 File Offset: 0x00017F88
		' (set) Token: 0x0600025E RID: 606 RVA: 0x00019BA0 File Offset: 0x00017FA0
		Friend Overridable Property comboHour4 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboHour4
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboHour4 = value
			End Set
		End Property

		' Token: 0x17000121 RID: 289
		' (get) Token: 0x0600025F RID: 607 RVA: 0x00019BAC File Offset: 0x00017FAC
		' (set) Token: 0x06000260 RID: 608 RVA: 0x00019BC4 File Offset: 0x00017FC4
		Friend Overridable Property chkCon3 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkCon3
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkCon3_CheckedChanged
				Dim flag As Boolean = Me._chkCon3 IsNot Nothing
				If flag Then
					RemoveHandler Me._chkCon3.CheckedChanged, eventHandler
				End If
				Me._chkCon3 = value
				flag = Me._chkCon3 IsNot Nothing
				If flag Then
					AddHandler Me._chkCon3.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000122 RID: 290
		' (get) Token: 0x06000261 RID: 609 RVA: 0x00019C24 File Offset: 0x00018024
		' (set) Token: 0x06000262 RID: 610 RVA: 0x00019C3C File Offset: 0x0001803C
		Friend Overridable Property btnPlay3 As Button
			<DebuggerNonUserCode()>
			Get
				Return Me._btnPlay3
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnPlay3_Click
				Dim flag As Boolean = Me._btnPlay3 IsNot Nothing
				If flag Then
					RemoveHandler Me._btnPlay3.Click, eventHandler
				End If
				Me._btnPlay3 = value
				flag = Me._btnPlay3 IsNot Nothing
				If flag Then
					AddHandler Me._btnPlay3.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000123 RID: 291
		' (get) Token: 0x06000263 RID: 611 RVA: 0x00019C9C File Offset: 0x0001809C
		' (set) Token: 0x06000264 RID: 612 RVA: 0x00019CB4 File Offset: 0x000180B4
		Friend Overridable Property comboMin3 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboMin3
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboMin3 = value
			End Set
		End Property

		' Token: 0x17000124 RID: 292
		' (get) Token: 0x06000265 RID: 613 RVA: 0x00019CC0 File Offset: 0x000180C0
		' (set) Token: 0x06000266 RID: 614 RVA: 0x00019CD8 File Offset: 0x000180D8
		Friend Overridable Property comboHour3 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboHour3
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboHour3 = value
			End Set
		End Property

		' Token: 0x17000125 RID: 293
		' (get) Token: 0x06000267 RID: 615 RVA: 0x00019CE4 File Offset: 0x000180E4
		' (set) Token: 0x06000268 RID: 616 RVA: 0x00019CFC File Offset: 0x000180FC
		Friend Overridable Property chkCon2 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkCon2
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkCon2_CheckedChanged
				Dim flag As Boolean = Me._chkCon2 IsNot Nothing
				If flag Then
					RemoveHandler Me._chkCon2.CheckedChanged, eventHandler
				End If
				Me._chkCon2 = value
				flag = Me._chkCon2 IsNot Nothing
				If flag Then
					AddHandler Me._chkCon2.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000126 RID: 294
		' (get) Token: 0x06000269 RID: 617 RVA: 0x00019D5C File Offset: 0x0001815C
		' (set) Token: 0x0600026A RID: 618 RVA: 0x00019D74 File Offset: 0x00018174
		Friend Overridable Property btnPlay2 As Button
			<DebuggerNonUserCode()>
			Get
				Return Me._btnPlay2
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnPlay2_Click_1
				Dim flag As Boolean = Me._btnPlay2 IsNot Nothing
				If flag Then
					RemoveHandler Me._btnPlay2.Click, eventHandler
				End If
				Me._btnPlay2 = value
				flag = Me._btnPlay2 IsNot Nothing
				If flag Then
					AddHandler Me._btnPlay2.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000127 RID: 295
		' (get) Token: 0x0600026B RID: 619 RVA: 0x00019DD4 File Offset: 0x000181D4
		' (set) Token: 0x0600026C RID: 620 RVA: 0x00019DEC File Offset: 0x000181EC
		Friend Overridable Property comboMin2 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboMin2
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboMin2 = value
			End Set
		End Property

		' Token: 0x17000128 RID: 296
		' (get) Token: 0x0600026D RID: 621 RVA: 0x00019DF8 File Offset: 0x000181F8
		' (set) Token: 0x0600026E RID: 622 RVA: 0x00019E10 File Offset: 0x00018210
		Friend Overridable Property comboHour2 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboHour2
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboHour2 = value
			End Set
		End Property

		' Token: 0x17000129 RID: 297
		' (get) Token: 0x0600026F RID: 623 RVA: 0x00019E1C File Offset: 0x0001821C
		' (set) Token: 0x06000270 RID: 624 RVA: 0x00019E34 File Offset: 0x00018234
		Friend Overridable Property chkCon1 As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkCon1
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkcon1_CheckedChanged
				Dim flag As Boolean = Me._chkCon1 IsNot Nothing
				If flag Then
					RemoveHandler Me._chkCon1.CheckedChanged, eventHandler
				End If
				Me._chkCon1 = value
				flag = Me._chkCon1 IsNot Nothing
				If flag Then
					AddHandler Me._chkCon1.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700012A RID: 298
		' (get) Token: 0x06000271 RID: 625 RVA: 0x00019E94 File Offset: 0x00018294
		' (set) Token: 0x06000272 RID: 626 RVA: 0x00019EAC File Offset: 0x000182AC
		Friend Overridable Property btnPlay1 As Button
			<DebuggerNonUserCode()>
			Get
				Return Me._btnPlay1
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnPlay1_Click_1
				Dim flag As Boolean = Me._btnPlay1 IsNot Nothing
				If flag Then
					RemoveHandler Me._btnPlay1.Click, eventHandler
				End If
				Me._btnPlay1 = value
				flag = Me._btnPlay1 IsNot Nothing
				If flag Then
					AddHandler Me._btnPlay1.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700012B RID: 299
		' (get) Token: 0x06000273 RID: 627 RVA: 0x00019F0C File Offset: 0x0001830C
		' (set) Token: 0x06000274 RID: 628 RVA: 0x00019F24 File Offset: 0x00018324
		Friend Overridable Property comboMin1 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboMin1
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboMin1 = value
			End Set
		End Property

		' Token: 0x1700012C RID: 300
		' (get) Token: 0x06000275 RID: 629 RVA: 0x00019F30 File Offset: 0x00018330
		' (set) Token: 0x06000276 RID: 630 RVA: 0x00019F48 File Offset: 0x00018348
		Friend Overridable Property comboHour1 As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboHour1
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboHour1 = value
			End Set
		End Property

		' Token: 0x1700012D RID: 301
		' (get) Token: 0x06000277 RID: 631 RVA: 0x00019F54 File Offset: 0x00018354
		' (set) Token: 0x06000278 RID: 632 RVA: 0x00019F6C File Offset: 0x0001836C
		Friend Overridable Property PictureBox7 As PictureBox
			<DebuggerNonUserCode()>
			Get
				Return Me._PictureBox7
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As PictureBox)
				Me._PictureBox7 = value
			End Set
		End Property

		' Token: 0x1700012E RID: 302
		' (get) Token: 0x06000279 RID: 633 RVA: 0x00019F78 File Offset: 0x00018378
		' (set) Token: 0x0600027A RID: 634 RVA: 0x00019F90 File Offset: 0x00018390
		Friend Overridable Property panelSetting As Panel
			<DebuggerNonUserCode()>
			Get
				Return Me._panelSetting
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Panel)
				Me._panelSetting = value
			End Set
		End Property

		' Token: 0x1700012F RID: 303
		' (get) Token: 0x0600027B RID: 635 RVA: 0x00019F9C File Offset: 0x0001839C
		' (set) Token: 0x0600027C RID: 636 RVA: 0x00019FB4 File Offset: 0x000183B4
		Friend Overridable Property lblSetting As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lblSetting
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lblSetting = value
			End Set
		End Property

		' Token: 0x17000130 RID: 304
		' (get) Token: 0x0600027D RID: 637 RVA: 0x00019FC0 File Offset: 0x000183C0
		' (set) Token: 0x0600027E RID: 638 RVA: 0x00019FD8 File Offset: 0x000183D8
		Friend Overridable Property Label73 As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._Label73
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._Label73 = value
			End Set
		End Property

		' Token: 0x17000131 RID: 305
		' (get) Token: 0x0600027F RID: 639 RVA: 0x00019FE4 File Offset: 0x000183E4
		' (set) Token: 0x06000280 RID: 640 RVA: 0x00019FFC File Offset: 0x000183FC
		Friend Overridable Property comboMinShutdown As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboMinShutdown
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboMinShutdown = value
			End Set
		End Property

		' Token: 0x17000132 RID: 306
		' (get) Token: 0x06000281 RID: 641 RVA: 0x0001A008 File Offset: 0x00018408
		' (set) Token: 0x06000282 RID: 642 RVA: 0x0001A020 File Offset: 0x00018420
		Friend Overridable Property comboHourShutdown As ComboBox
			<DebuggerNonUserCode()>
			Get
				Return Me._comboHourShutdown
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ComboBox)
				Me._comboHourShutdown = value
			End Set
		End Property

		' Token: 0x17000133 RID: 307
		' (get) Token: 0x06000283 RID: 643 RVA: 0x0001A02C File Offset: 0x0001842C
		' (set) Token: 0x06000284 RID: 644 RVA: 0x0001A044 File Offset: 0x00018444
		Friend Overridable Property ckShutDown As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._ckShutDown
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._ckShutDown = value
			End Set
		End Property

		' Token: 0x17000134 RID: 308
		' (get) Token: 0x06000285 RID: 645 RVA: 0x0001A050 File Offset: 0x00018450
		' (set) Token: 0x06000286 RID: 646 RVA: 0x0001A068 File Offset: 0x00018468
		Friend Overridable Property chkEng As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkEng
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkEng = value
			End Set
		End Property

		' Token: 0x17000135 RID: 309
		' (get) Token: 0x06000287 RID: 647 RVA: 0x0001A074 File Offset: 0x00018474
		' (set) Token: 0x06000288 RID: 648 RVA: 0x0001A08C File Offset: 0x0001848C
		Friend Overridable Property btnPlaySound As Button
			<DebuggerNonUserCode()>
			Get
				Return Me._btnPlaySound
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Button)
				Dim eventHandler As EventHandler = AddressOf Me.btnPlaySound_Click_1
				Dim flag As Boolean = Me._btnPlaySound IsNot Nothing
				If flag Then
					RemoveHandler Me._btnPlaySound.Click, eventHandler
				End If
				Me._btnPlaySound = value
				flag = Me._btnPlaySound IsNot Nothing
				If flag Then
					AddHandler Me._btnPlaySound.Click, eventHandler
				End If
			End Set
		End Property

		' Token: 0x17000136 RID: 310
		' (get) Token: 0x06000289 RID: 649 RVA: 0x0001A0EC File Offset: 0x000184EC
		' (set) Token: 0x0600028A RID: 650 RVA: 0x0001A104 File Offset: 0x00018504
		Friend Overridable Property lblAlarm As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lblAlarm
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lblAlarm = value
			End Set
		End Property

		' Token: 0x17000137 RID: 311
		' (get) Token: 0x0600028B RID: 651 RVA: 0x0001A110 File Offset: 0x00018510
		' (set) Token: 0x0600028C RID: 652 RVA: 0x0001A128 File Offset: 0x00018528
		Friend Overridable Property listSoundBell As ListBox
			<DebuggerNonUserCode()>
			Get
				Return Me._listSoundBell
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As ListBox)
				Me._listSoundBell = value
			End Set
		End Property

		' Token: 0x17000138 RID: 312
		' (get) Token: 0x0600028D RID: 653 RVA: 0x0001A134 File Offset: 0x00018534
		' (set) Token: 0x0600028E RID: 654 RVA: 0x0001A14C File Offset: 0x0001854C
		Friend Overridable Property chkThai As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkThai
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Me._chkThai = value
			End Set
		End Property

		' Token: 0x17000139 RID: 313
		' (get) Token: 0x0600028F RID: 655 RVA: 0x0001A158 File Offset: 0x00018558
		' (set) Token: 0x06000290 RID: 656 RVA: 0x0001A170 File Offset: 0x00018570
		Friend Overridable Property lblLang As Label
			<DebuggerNonUserCode()>
			Get
				Return Me._lblLang
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As Label)
				Me._lblLang = value
			End Set
		End Property

		' Token: 0x1700013A RID: 314
		' (get) Token: 0x06000291 RID: 657 RVA: 0x0001A17C File Offset: 0x0001857C
		' (set) Token: 0x06000292 RID: 658 RVA: 0x0001A194 File Offset: 0x00018594
		Friend Overridable Property chkLastAll As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkLastAll
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkLastAll_CheckedChanged
				Dim flag As Boolean = Me._chkLastAll IsNot Nothing
				If flag Then
					RemoveHandler Me._chkLastAll.CheckedChanged, eventHandler
				End If
				Me._chkLastAll = value
				flag = Me._chkLastAll IsNot Nothing
				If flag Then
					AddHandler Me._chkLastAll.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700013B RID: 315
		' (get) Token: 0x06000293 RID: 659 RVA: 0x0001A1F4 File Offset: 0x000185F4
		' (set) Token: 0x06000294 RID: 660 RVA: 0x0001A20C File Offset: 0x0001860C
		Friend Overridable Property chkConAll As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkConAll
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkConAll_CheckedChanged
				Dim flag As Boolean = Me._chkConAll IsNot Nothing
				If flag Then
					RemoveHandler Me._chkConAll.CheckedChanged, eventHandler
				End If
				Me._chkConAll = value
				flag = Me._chkConAll IsNot Nothing
				If flag Then
					AddHandler Me._chkConAll.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700013C RID: 316
		' (get) Token: 0x06000295 RID: 661 RVA: 0x0001A26C File Offset: 0x0001866C
		' (set) Token: 0x06000296 RID: 662 RVA: 0x0001A284 File Offset: 0x00018684
		Friend Overridable Property chkTimeAll As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkTimeAll
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkTimeAll_CheckedChanged
				Dim flag As Boolean = Me._chkTimeAll IsNot Nothing
				If flag Then
					RemoveHandler Me._chkTimeAll.CheckedChanged, eventHandler
				End If
				Me._chkTimeAll = value
				flag = Me._chkTimeAll IsNot Nothing
				If flag Then
					AddHandler Me._chkTimeAll.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x1700013D RID: 317
		' (get) Token: 0x06000297 RID: 663 RVA: 0x0001A2E4 File Offset: 0x000186E4
		' (set) Token: 0x06000298 RID: 664 RVA: 0x0001A2FC File Offset: 0x000186FC
		Friend Overridable Property chkFirstAll As CheckBox
			<DebuggerNonUserCode()>
			Get
				Return Me._chkFirstAll
			End Get
			<DebuggerNonUserCode()>
			<MethodImpl(MethodImplOptions.Synchronized)>
			Set(value As CheckBox)
				Dim eventHandler As EventHandler = AddressOf Me.chkFirstAll_CheckedChanged
				Dim flag As Boolean = Me._chkFirstAll IsNot Nothing
				If flag Then
					RemoveHandler Me._chkFirstAll.CheckedChanged, eventHandler
				End If
				Me._chkFirstAll = value
				flag = Me._chkFirstAll IsNot Nothing
				If flag Then
					AddHandler Me._chkFirstAll.CheckedChanged, eventHandler
				End If
			End Set
		End Property

		' Token: 0x06000299 RID: 665 RVA: 0x0001A35C File Offset: 0x0001875C
		Private Sub Timer1_Tick(sender As Object, e As EventArgs)
			Me.lblTimeShow.Text = String.Format(Conversions.ToString(DateAndTime.TimeOfDay), "HH:mm:ss")
		End Sub

		' Token: 0x0600029A RID: 666 RVA: 0x0001A380 File Offset: 0x00018780
		<MethodImpl(MethodImplOptions.NoInlining Or MethodImplOptions.NoOptimization)>
		Private Sub Timer2_Tick(sender As Object, e As EventArgs)
			Dim flag As Boolean = Conversions.ToInteger(Me.lblCD.Text) < 1
			If flag Then
				Me.lblCD.Text = "0"
			Else
				flag = DateAndTime.TimeOfDay.Hour <> 0
				Dim flag3 As Boolean
				If flag Then
					Dim flag2 As Boolean = (DateAndTime.TimeOfDay.Hour = Conversions.ToInteger(Me.comboHour1.Text)) And (DateAndTime.TimeOfDay.Minute = Conversions.ToInteger(Me.comboMin1.Text)) And (DateAndTime.TimeOfDay.Second = 0)
					If flag2 Then
						flag3 = Me.chkFirst1.Checked
						If flag3 Then
							Me.PlaySoundFirst()
						End If
						flag3 = Me.chkThai.Checked
						If flag3 Then
							Me.VoiceTimeThai(Me.chkTime1.Checked)
							Me.VoiceConThai(Me.chkCon1.Checked, Me.comboSoundCon1.Text)
						End If
						flag3 = Me.chkEng.Checked
						If flag3 Then
							Me.VoiceTimeEng(Me.chkTime1.Checked)
							Me.VoiceConEng(Me.chkCon1.Checked, Me.comboSoundConEng1.Text)
						End If
						flag3 = Me.chkLast1.Checked
						If flag3 Then
							Me.PlaySoundLast()
						End If
					Else
						flag3 = (DateAndTime.TimeOfDay.Hour = Conversions.ToInteger(Me.comboHour2.Text)) And (DateAndTime.TimeOfDay.Minute = Conversions.ToInteger(Me.comboMin2.Text)) And (DateAndTime.TimeOfDay.Second = 0)
						If flag3 Then
							flag2 = Me.chkFirst2.Checked
							If flag2 Then
								Me.PlaySoundFirst()
							End If
							flag3 = Me.chkThai.Checked
							If flag3 Then
								Me.VoiceTimeThai(Me.chkTime2.Checked)
								Me.VoiceConThai(Me.chkCon2.Checked, Me.comboSoundCon2.Text)
							End If
							flag3 = Me.chkEng.Checked
							If flag3 Then
								Me.VoiceTimeEng(Me.chkTime2.Checked)
								Me.VoiceConEng(Me.chkCon2.Checked, Me.comboSoundConEng2.Text)
							End If
							flag3 = Me.chkLast2.Checked
							If flag3 Then
								Me.PlaySoundLast()
							End If
						Else
							flag3 = (DateAndTime.TimeOfDay.Hour = Conversions.ToInteger(Me.comboHour3.Text)) And (DateAndTime.TimeOfDay.Minute = Conversions.ToInteger(Me.comboMin3.Text)) And (DateAndTime.TimeOfDay.Second = 0)
							If flag3 Then
								flag2 = Me.chkFirst3.Checked
								If flag2 Then
									Me.PlaySoundFirst()
								End If
								flag3 = Me.chkThai.Checked
								If flag3 Then
									Me.VoiceTimeThai(Me.chkTime3.Checked)
									Me.VoiceConThai(Me.chkCon3.Checked, Me.comboSoundCon3.Text)
								End If
								flag3 = Me.chkEng.Checked
								If flag3 Then
									Me.VoiceTimeEng(Me.chkTime3.Checked)
									Me.VoiceConEng(Me.chkCon3.Checked, Me.comboSoundConEng3.Text)
								End If
								flag3 = Me.chkLast3.Checked
								If flag3 Then
									Me.PlaySoundLast()
								End If
							Else
								flag3 = (DateAndTime.TimeOfDay.Hour = Conversions.ToInteger(Me.comboHour4.Text)) And (DateAndTime.TimeOfDay.Minute = Conversions.ToInteger(Me.comboMin4.Text)) And (DateAndTime.TimeOfDay.Second = 0)
								If flag3 Then
									flag2 = Me.chkFirst4.Checked
									If flag2 Then
										Me.PlaySoundFirst()
									End If
									flag3 = Me.chkThai.Checked
									If flag3 Then
										Me.VoiceTimeThai(Me.chkTime4.Checked)
										Me.VoiceConThai(Me.chkCon4.Checked, Me.comboSoundCon4.Text)
									End If
									flag3 = Me.chkEng.Checked
									If flag3 Then
										Me.VoiceTimeEng(Me.chkTime4.Checked)
										Me.VoiceConEng(Me.chkCon4.Checked, Me.comboSoundConEng4.Text)
									End If
									flag3 = Me.chkLast4.Checked
									If flag3 Then
										Me.PlaySoundLast()
									End If
								Else
									flag3 = (DateAndTime.TimeOfDay.Hour = Conversions.ToInteger(Me.comboHour5.Text)) And (DateAndTime.TimeOfDay.Minute = Conversions.ToInteger(Me.comboMin5.Text)) And (DateAndTime.TimeOfDay.Second = 0)
									If flag3 Then
										flag2 = Me.chkFirst5.Checked
										If flag2 Then
											Me.PlaySoundFirst()
										End If
										flag3 = Me.chkThai.Checked
										If flag3 Then
											Me.VoiceTimeThai(Me.chkTime5.Checked)
											Me.VoiceConThai(Me.chkCon5.Checked, Me.comboSoundCon5.Text)
										End If
										flag3 = Me.chkEng.Checked
										If flag3 Then
											Me.VoiceTimeEng(Me.chkTime5.Checked)
											Me.VoiceConEng(Me.chkCon5.Checked, Me.comboSoundConEng5.Text)
										End If
										flag3 = Me.chkLast5.Checked
										If flag3 Then
											Me.PlaySoundLast()
										End If
									Else
										flag3 = (DateAndTime.TimeOfDay.Hour = Conversions.ToInteger(Me.comboHour6.Text)) And (DateAndTime.TimeOfDay.Minute = Conversions.ToInteger(Me.comboMin6.Text)) And (DateAndTime.TimeOfDay.Second = 0)
										If flag3 Then
											flag2 = Me.chkFirst6.Checked
											If flag2 Then
												Me.PlaySoundFirst()
											End If
											flag3 = Me.chkThai.Checked
											If flag3 Then
												Me.VoiceTimeThai(Me.chkTime6.Checked)
												Me.VoiceConThai(Me.chkCon6.Checked, Me.comboSoundCon6.Text)
											End If
											flag3 = Me.chkEng.Checked
											If flag3 Then
												Me.VoiceTimeEng(Me.chkTime6.Checked)
												Me.VoiceConEng(Me.chkCon6.Checked, Me.comboSoundConEng6.Text)
											End If
											flag3 = Me.chkLast6.Checked
											If flag3 Then
												Me.PlaySoundLast()
											End If
										Else
											flag3 = (DateAndTime.TimeOfDay.Hour = Conversions.ToInteger(Me.comboHour7.Text)) And (DateAndTime.TimeOfDay.Minute = Conversions.ToInteger(Me.comboMin7.Text)) And (DateAndTime.TimeOfDay.Second = 0)
											If flag3 Then
												flag2 = Me.chkFirst7.Checked
												If flag2 Then
													Me.PlaySoundFirst()
												End If
												flag3 = Me.chkThai.Checked
												If flag3 Then
													Me.VoiceTimeThai(Me.chkTime7.Checked)
													Me.VoiceConThai(Me.chkCon7.Checked, Me.comboSoundCon7.Text)
												End If
												flag3 = Me.chkEng.Checked
												If flag3 Then
													Me.VoiceTimeEng(Me.chkTime7.Checked)
													Me.VoiceConEng(Me.chkCon7.Checked, Me.comboSoundConEng7.Text)
												End If
												flag3 = Me.chkLast7.Checked
												If flag3 Then
													Me.PlaySoundLast()
												End If
											Else
												flag3 = (DateAndTime.TimeOfDay.Hour = Conversions.ToInteger(Me.comboHour8.Text)) And (DateAndTime.TimeOfDay.Minute = Conversions.ToInteger(Me.comboMin8.Text)) And (DateAndTime.TimeOfDay.Second = 0)
												If flag3 Then
													flag2 = Me.chkFirst8.Checked
													If flag2 Then
														Me.PlaySoundFirst()
													End If
													flag3 = Me.chkThai.Checked
													If flag3 Then
														Me.VoiceTimeThai(Me.chkTime8.Checked)
														Me.VoiceConThai(Me.chkCon8.Checked, Me.comboSoundCon8.Text)
													End If
													flag3 = Me.chkEng.Checked
													If flag3 Then
														Me.VoiceTimeEng(Me.chkTime8.Checked)
														Me.VoiceConEng(Me.chkCon8.Checked, Me.comboSoundConEng8.Text)
													End If
													flag3 = Me.chkLast8.Checked
													If flag3 Then
														Me.PlaySoundLast()
													End If
												Else
													flag3 = (DateAndTime.TimeOfDay.Hour = Conversions.ToInteger(Me.comboHour9.Text)) And (DateAndTime.TimeOfDay.Minute = Conversions.ToInteger(Me.comboMin9.Text)) And (DateAndTime.TimeOfDay.Second = 0)
													If flag3 Then
														flag2 = Me.chkFirst9.Checked
														If flag2 Then
															Me.PlaySoundFirst()
														End If
														flag3 = Me.chkThai.Checked
														If flag3 Then
															Me.VoiceTimeThai(Me.chkTime9.Checked)
															Me.VoiceConThai(Me.chkCon9.Checked, Me.comboSoundCon9.Text)
														End If
														flag3 = Me.chkEng.Checked
														If flag3 Then
															Me.VoiceTimeEng(Me.chkTime9.Checked)
															Me.VoiceConEng(Me.chkCon9.Checked, Me.comboSoundConEng9.Text)
														End If
														flag3 = Me.chkLast9.Checked
														If flag3 Then
															Me.PlaySoundLast()
														End If
													Else
														flag3 = (DateAndTime.TimeOfDay.Hour = Conversions.ToInteger(Me.comboHour10.Text)) And (DateAndTime.TimeOfDay.Minute = Conversions.ToInteger(Me.comboMin10.Text)) And (DateAndTime.TimeOfDay.Second = 0)
														If flag3 Then
															flag2 = Me.chkFirst10.Checked
															If flag2 Then
																Me.PlaySoundFirst()
															End If
															flag3 = Me.chkThai.Checked
															If flag3 Then
																Me.VoiceTimeThai(Me.chkTime10.Checked)
																Me.VoiceConThai(Me.chkCon10.Checked, Me.comboSoundCon10.Text)
															End If
															flag3 = Me.chkEng.Checked
															If flag3 Then
																Me.VoiceTimeEng(Me.chkTime10.Checked)
																Me.VoiceConEng(Me.chkCon10.Checked, Me.comboSoundConEng10.Text)
															End If
															flag3 = Me.chkLast10.Checked
															If flag3 Then
																Me.PlaySoundLast()
															End If
														Else
															flag3 = (DateAndTime.TimeOfDay.Hour = Conversions.ToInteger(Me.comboHour11.Text)) And (DateAndTime.TimeOfDay.Minute = Conversions.ToInteger(Me.comboMin11.Text)) And (DateAndTime.TimeOfDay.Second = 0)
															If flag3 Then
																flag2 = Me.chkFirst11.Checked
																If flag2 Then
																	Me.PlaySoundFirst()
																End If
																flag3 = Me.chkThai.Checked
																If flag3 Then
																	Me.VoiceTimeThai(Me.chkTime11.Checked)
																	Me.VoiceConThai(Me.chkCon11.Checked, Me.comboSoundCon11.Text)
																End If
																flag3 = Me.chkEng.Checked
																If flag3 Then
																	Me.VoiceTimeEng(Me.chkTime11.Checked)
																	Me.VoiceConEng(Me.chkCon11.Checked, Me.comboSoundConEng11.Text)
																End If
																flag3 = Me.chkLast11.Checked
																If flag3 Then
																	Me.PlaySoundLast()
																End If
															Else
																flag3 = (DateAndTime.TimeOfDay.Hour = Conversions.ToInteger(Me.comboHour12.Text)) And (DateAndTime.TimeOfDay.Minute = Conversions.ToInteger(Me.comboMin12.Text)) And (DateAndTime.TimeOfDay.Second = 0)
																If flag3 Then
																	flag2 = Me.chkFirst12.Checked
																	If flag2 Then
																		Me.PlaySoundFirst()
																	End If
																	flag3 = Me.chkThai.Checked
																	If flag3 Then
																		Me.VoiceTimeThai(Me.chkTime12.Checked)
																		Me.VoiceConThai(Me.chkCon12.Checked, Me.comboSoundCon12.Text)
																	End If
																	flag3 = Me.chkEng.Checked
																	If flag3 Then
																		Me.VoiceTimeEng(Me.chkTime12.Checked)
																		Me.VoiceConEng(Me.chkCon12.Checked, Me.comboSoundConEng12.Text)
																	End If
																	flag3 = Me.chkLast12.Checked
																	If flag3 Then
																		Me.PlaySoundLast()
																	End If
																Else
																	flag3 = (DateAndTime.TimeOfDay.Hour = Conversions.ToInteger(Me.comboHour13.Text)) And (DateAndTime.TimeOfDay.Minute = Conversions.ToInteger(Me.comboMin13.Text)) And (DateAndTime.TimeOfDay.Second = 0)
																	If flag3 Then
																		flag2 = Me.chkFirst13.Checked
																		If flag2 Then
																			Me.PlaySoundFirst()
																		End If
																		flag3 = Me.chkThai.Checked
																		If flag3 Then
																			Me.VoiceTimeThai(Me.chkTime13.Checked)
																			Me.VoiceConThai(Me.chkCon13.Checked, Me.comboSoundCon13.Text)
																		End If
																		flag3 = Me.chkEng.Checked
																		If flag3 Then
																			Me.VoiceTimeEng(Me.chkTime13.Checked)
																			Me.VoiceConEng(Me.chkCon13.Checked, Me.comboSoundConEng13.Text)
																		End If
																		flag3 = Me.chkLast13.Checked
																		If flag3 Then
																			Me.PlaySoundLast()
																		End If
																	Else
																		flag3 = (DateAndTime.TimeOfDay.Hour = Conversions.ToInteger(Me.comboHour14.Text)) And (DateAndTime.TimeOfDay.Minute = Conversions.ToInteger(Me.comboMin14.Text)) And (DateAndTime.TimeOfDay.Second = 0)
																		If flag3 Then
																			flag2 = Me.chkFirst14.Checked
																			If flag2 Then
																				Me.PlaySoundFirst()
																			End If
																			flag3 = Me.chkThai.Checked
																			If flag3 Then
																				Me.VoiceTimeThai(Me.chkTime14.Checked)
																				Me.VoiceConThai(Me.chkCon14.Checked, Me.comboSoundCon14.Text)
																			End If
																			flag3 = Me.chkEng.Checked
																			If flag3 Then
																				Me.VoiceTimeEng(Me.chkTime14.Checked)
																				Me.VoiceConEng(Me.chkCon14.Checked, Me.comboSoundConEng14.Text)
																			End If
																			flag3 = Me.chkLast14.Checked
																			If flag3 Then
																				Me.PlaySoundLast()
																			End If
																		Else
																			flag3 = (DateAndTime.TimeOfDay.Hour = Conversions.ToInteger(Me.comboHour15.Text)) And (DateAndTime.TimeOfDay.Minute = Conversions.ToInteger(Me.comboMin15.Text)) And (DateAndTime.TimeOfDay.Second = 0)
																			If flag3 Then
																				flag2 = Me.chkFirst15.Checked
																				If flag2 Then
																					Me.PlaySoundFirst()
																				End If
																				flag3 = Me.chkThai.Checked
																				If flag3 Then
																					Me.VoiceTimeThai(Me.chkTime15.Checked)
																					Me.VoiceConThai(Me.chkCon15.Checked, Me.comboSoundCon15.Text)
																				End If
																				flag3 = Me.chkEng.Checked
																				If flag3 Then
																					Me.VoiceTimeEng(Me.chkTime15.Checked)
																					Me.VoiceConEng(Me.chkCon15.Checked, Me.comboSoundConEng15.Text)
																				End If
																				flag3 = Me.chkLast15.Checked
																				If flag3 Then
																					Me.PlaySoundLast()
																				End If
																			Else
																				flag3 = (DateAndTime.TimeOfDay.Hour = Conversions.ToInteger(Me.comboHour16.Text)) And (DateAndTime.TimeOfDay.Minute = Conversions.ToInteger(Me.comboMin16.Text)) And (DateAndTime.TimeOfDay.Second = 0)
																				If flag3 Then
																					flag2 = Me.chkFirst16.Checked
																					If flag2 Then
																						Me.PlaySoundFirst()
																					End If
																					flag3 = Me.chkThai.Checked
																					If flag3 Then
																						Me.VoiceTimeThai(Me.chkTime16.Checked)
																						Me.VoiceConThai(Me.chkCon16.Checked, Me.comboSoundCon16.Text)
																					End If
																					flag3 = Me.chkEng.Checked
																					If flag3 Then
																						Me.VoiceTimeEng(Me.chkTime16.Checked)
																						Me.VoiceConEng(Me.chkCon16.Checked, Me.comboSoundConEng16.Text)
																					End If
																					flag3 = Me.chkLast16.Checked
																					If flag3 Then
																						Me.PlaySoundLast()
																					End If
																				Else
																					flag3 = (DateAndTime.TimeOfDay.Hour = Conversions.ToInteger(Me.comboHour17.Text)) And (DateAndTime.TimeOfDay.Minute = Conversions.ToInteger(Me.comboMin17.Text)) And (DateAndTime.TimeOfDay.Second = 0)
																					If flag3 Then
																						flag2 = Me.chkFirst17.Checked
																						If flag2 Then
																							Me.PlaySoundFirst()
																						End If
																						flag3 = Me.chkThai.Checked
																						If flag3 Then
																							Me.VoiceTimeThai(Me.chkTime17.Checked)
																							Me.VoiceConThai(Me.chkCon17.Checked, Me.comboSoundCon17.Text)
																						End If
																						flag3 = Me.chkEng.Checked
																						If flag3 Then
																							Me.VoiceTimeEng(Me.chkTime17.Checked)
																							Me.VoiceConEng(Me.chkCon17.Checked, Me.comboSoundConEng17.Text)
																						End If
																						flag3 = Me.chkLast17.Checked
																						If flag3 Then
																							Me.PlaySoundLast()
																						End If
																					Else
																						flag3 = (DateAndTime.TimeOfDay.Hour = Conversions.ToInteger(Me.comboHour18.Text)) And (DateAndTime.TimeOfDay.Minute = Conversions.ToInteger(Me.comboMin18.Text)) And (DateAndTime.TimeOfDay.Second = 0)
																						If flag3 Then
																							flag2 = Me.chkFirst18.Checked
																							If flag2 Then
																								Me.PlaySoundFirst()
																							End If
																							flag3 = Me.chkThai.Checked
																							If flag3 Then
																								Me.VoiceTimeThai(Me.chkTime18.Checked)
																								Me.VoiceConThai(Me.chkCon18.Checked, Me.comboSoundCon18.Text)
																							End If
																							flag3 = Me.chkEng.Checked
																							If flag3 Then
																								Me.VoiceTimeEng(Me.chkTime18.Checked)
																								Me.VoiceConEng(Me.chkCon18.Checked, Me.comboSoundConEng18.Text)
																							End If
																							flag3 = Me.chkLast18.Checked
																							If flag3 Then
																								Me.PlaySoundLast()
																							End If
																						Else
																							flag3 = (DateAndTime.TimeOfDay.Hour = Conversions.ToInteger(Me.comboHour19.Text)) And (DateAndTime.TimeOfDay.Minute = Conversions.ToInteger(Me.comboMin19.Text)) And (DateAndTime.TimeOfDay.Second = 0)
																							If flag3 Then
																								flag2 = Me.chkFirst19.Checked
																								If flag2 Then
																									Me.PlaySoundFirst()
																								End If
																								flag3 = Me.chkThai.Checked
																								If flag3 Then
																									Me.VoiceTimeThai(Me.chkTime19.Checked)
																									Me.VoiceConThai(Me.chkCon19.Checked, Me.comboSoundCon19.Text)
																								End If
																								flag3 = Me.chkEng.Checked
																								If flag3 Then
																									Me.VoiceTimeEng(Me.chkTime19.Checked)
																									Me.VoiceConEng(Me.chkCon19.Checked, Me.comboSoundConEng19.Text)
																								End If
																								flag3 = Me.chkLast19.Checked
																								If flag3 Then
																									Me.PlaySoundLast()
																								End If
																							Else
																								flag3 = (DateAndTime.TimeOfDay.Hour = Conversions.ToInteger(Me.comboHour20.Text)) And (DateAndTime.TimeOfDay.Minute = Conversions.ToInteger(Me.comboMin20.Text)) And (DateAndTime.TimeOfDay.Second = 0)
																								If flag3 Then
																									flag2 = Me.chkFirst20.Checked
																									If flag2 Then
																										Me.PlaySoundFirst()
																									End If
																									flag3 = Me.chkThai.Checked
																									If flag3 Then
																										Me.VoiceTimeThai(Me.chkTime20.Checked)
																										Me.VoiceConThai(Me.chkCon20.Checked, Me.comboSoundCon20.Text)
																									End If
																									flag3 = Me.chkEng.Checked
																									If flag3 Then
																										Me.VoiceTimeEng(Me.chkTime20.Checked)
																										Me.VoiceConEng(Me.chkCon20.Checked, Me.comboSoundConEng20.Text)
																									End If
																									flag3 = Me.chkLast20.Checked
																									If flag3 Then
																										Me.PlaySoundLast()
																									End If
																								Else
																									flag3 = (DateAndTime.TimeOfDay.Hour = Conversions.ToInteger(Me.comboHour21.Text)) And (DateAndTime.TimeOfDay.Minute = Conversions.ToInteger(Me.comboMin21.Text)) And (DateAndTime.TimeOfDay.Second = 0)
																									If flag3 Then
																										flag2 = Me.chkFirst21.Checked
																										If flag2 Then
																											Me.PlaySoundFirst()
																										End If
																										flag3 = Me.chkThai.Checked
																										If flag3 Then
																											Me.VoiceTimeThai(Me.chkTime21.Checked)
																											Me.VoiceConThai(Me.chkCon21.Checked, Me.comboSoundCon21.Text)
																										End If
																										flag3 = Me.chkEng.Checked
																										If flag3 Then
																											Me.VoiceTimeEng(Me.chkTime21.Checked)
																											Me.VoiceConEng(Me.chkCon21.Checked, Me.comboSoundConEng21.Text)
																										End If
																										flag3 = Me.chkLast21.Checked
																										If flag3 Then
																											Me.PlaySoundLast()
																										End If
																									Else
																										flag3 = (DateAndTime.TimeOfDay.Hour = Conversions.ToInteger(Me.comboHour22.Text)) And (DateAndTime.TimeOfDay.Minute = Conversions.ToInteger(Me.comboMin22.Text)) And (DateAndTime.TimeOfDay.Second = 0)
																										If flag3 Then
																											flag2 = Me.chkFirst22.Checked
																											If flag2 Then
																												Me.PlaySoundFirst()
																											End If
																											flag3 = Me.chkThai.Checked
																											If flag3 Then
																												Me.VoiceTimeThai(Me.chkTime22.Checked)
																												Me.VoiceConThai(Me.chkCon22.Checked, Me.comboSoundCon22.Text)
																											End If
																											flag3 = Me.chkEng.Checked
																											If flag3 Then
																												Me.VoiceTimeEng(Me.chkTime22.Checked)
																												Me.VoiceConEng(Me.chkCon22.Checked, Me.comboSoundConEng22.Text)
																											End If
																											flag3 = Me.chkLast22.Checked
																											If flag3 Then
																												Me.PlaySoundLast()
																											End If
																										Else
																											flag3 = (DateAndTime.TimeOfDay.Hour = Conversions.ToInteger(Me.comboHour23.Text)) And (DateAndTime.TimeOfDay.Minute = Conversions.ToInteger(Me.comboMin23.Text)) And (DateAndTime.TimeOfDay.Second = 0)
																											If flag3 Then
																												flag2 = Me.chkFirst23.Checked
																												If flag2 Then
																													Me.PlaySoundFirst()
																												End If
																												flag3 = Me.chkThai.Checked
																												If flag3 Then
																													Me.VoiceTimeThai(Me.chkTime23.Checked)
																													Me.VoiceConThai(Me.chkCon23.Checked, Me.comboSoundCon23.Text)
																												End If
																												flag3 = Me.chkEng.Checked
																												If flag3 Then
																													Me.VoiceTimeEng(Me.chkTime23.Checked)
																													Me.VoiceConEng(Me.chkCon23.Checked, Me.comboSoundConEng23.Text)
																												End If
																												flag3 = Me.chkLast23.Checked
																												If flag3 Then
																													Me.PlaySoundLast()
																												End If
																											Else
																												flag3 = (DateAndTime.TimeOfDay.Hour = Conversions.ToInteger(Me.comboHour24.Text)) And (DateAndTime.TimeOfDay.Minute = Conversions.ToInteger(Me.comboMin24.Text)) And (DateAndTime.TimeOfDay.Second = 0)
																												If flag3 Then
																													flag2 = Me.chkFirst24.Checked
																													If flag2 Then
																														Me.PlaySoundFirst()
																													End If
																													flag3 = Me.chkThai.Checked
																													If flag3 Then
																														Me.VoiceTimeThai(Me.chkTime24.Checked)
																														Me.VoiceConThai(Me.chkCon24.Checked, Me.comboSoundCon24.Text)
																													End If
																													flag3 = Me.chkEng.Checked
																													If flag3 Then
																														Me.VoiceTimeEng(Me.chkTime24.Checked)
																														Me.VoiceConEng(Me.chkCon24.Checked, Me.comboSoundConEng24.Text)
																													End If
																													flag3 = Me.chkLast24.Checked
																													If flag3 Then
																														Me.PlaySoundLast()
																													End If
																												End If
																											End If
																										End If
																									End If
																								End If
																							End If
																						End If
																					End If
																				End If
																			End If
																		End If
																	End If
																End If
															End If
														End If
													End If
												End If
											End If
										End If
									End If
								End If
							End If
						End If
					End If
				End If
				flag3 = Me.ckShutDown.Checked
				If flag3 Then
					Dim flag2 As Boolean = (DateAndTime.TimeOfDay.Hour = Conversions.ToInteger(Me.comboHourShutdown.Text)) And (DateAndTime.TimeOfDay.Minute = Conversions.ToInteger(Me.comboMinShutdown.Text)) And (DateAndTime.TimeOfDay.Second = 0)
					If flag2 Then
						Process.Start("shutdown", "-s -t 00")
						ProjectData.EndApp()
					End If
				End If
			End If
		End Sub

		' Token: 0x0600029B RID: 667 RVA: 0x0001BFEC File Offset: 0x0001A3EC
		Private Sub Form1_Load(sender As Object, e As EventArgs)
			' The following expression was wrapped in a checked-statement
			Me.Left = (Screen.PrimaryScreen.WorkingArea.Width - Me.Width) / 2
			Me.Top = (Screen.PrimaryScreen.WorkingArea.Height - Me.Height) / 2
			Me.getPath()
			Me.loadSetting()
			Dim chkday As Integer = Me.getSettingDay()
			Dim flag As Boolean = chkday = 1
			If flag Then
				Me.loadData(8)
				Me.radioAllDay.Checked = True
				Me.PanelEachDay.Visible = False
				Me.BackColor = Color.White
			Else
				Me.radioEachDay.Checked = True
				Me.PanelEachDay.Visible = True
				Me.loadDay()
			End If
			Me.editClose()
			flag = Conversions.ToInteger(Me.lblCD.Text) < 1
			If flag Then
				Me.lblCD.Text = "0"
				Me.lblWarning.Visible = True
			Else
				Me.updateCountDown()
				Me.lblWarning.Visible = False
			End If
			Me.Timer1.Start()
			Me.Timer2.Start()
			Try
				For Each ff As String In MyProject.Computer.FileSystem.GetFiles("C:\Sound\Thai\ConTN\")
					Dim f As String = Path.GetFileName(ff)
					Me.comboSoundCon1.Items.Add(f)
					Me.comboSoundCon2.Items.Add(f)
					Me.comboSoundCon3.Items.Add(f)
					Me.comboSoundCon4.Items.Add(f)
					Me.comboSoundCon5.Items.Add(f)
					Me.comboSoundCon6.Items.Add(f)
					Me.comboSoundCon7.Items.Add(f)
					Me.comboSoundCon8.Items.Add(f)
					Me.comboSoundCon9.Items.Add(f)
					Me.comboSoundCon10.Items.Add(f)
					Me.comboSoundCon11.Items.Add(f)
					Me.comboSoundCon12.Items.Add(f)
					Me.comboSoundCon13.Items.Add(f)
					Me.comboSoundCon14.Items.Add(f)
					Me.comboSoundCon15.Items.Add(f)
					Me.comboSoundCon16.Items.Add(f)
					Me.comboSoundCon17.Items.Add(f)
					Me.comboSoundCon18.Items.Add(f)
					Me.comboSoundCon19.Items.Add(f)
					Me.comboSoundCon20.Items.Add(f)
					Me.comboSoundCon21.Items.Add(f)
					Me.comboSoundCon22.Items.Add(f)
					Me.comboSoundCon23.Items.Add(f)
					Me.comboSoundCon24.Items.Add(f)
				Next
			Finally
				Dim enumerator As IEnumerator(Of String)
				flag = enumerator IsNot Nothing
				If flag Then
					enumerator.Dispose()
				End If
			End Try
			Try
				For Each ff2 As String In MyProject.Computer.FileSystem.GetFiles("C:\Sound\Eng\ConTN\")
					Dim f2 As String = Path.GetFileName(ff2)
					Me.comboSoundConEng1.Items.Add(f2)
					Me.comboSoundConEng2.Items.Add(f2)
					Me.comboSoundConEng3.Items.Add(f2)
					Me.comboSoundConEng4.Items.Add(f2)
					Me.comboSoundConEng5.Items.Add(f2)
					Me.comboSoundConEng6.Items.Add(f2)
					Me.comboSoundConEng7.Items.Add(f2)
					Me.comboSoundConEng8.Items.Add(f2)
					Me.comboSoundConEng9.Items.Add(f2)
					Me.comboSoundConEng10.Items.Add(f2)
					Me.comboSoundConEng11.Items.Add(f2)
					Me.comboSoundConEng12.Items.Add(f2)
					Me.comboSoundConEng13.Items.Add(f2)
					Me.comboSoundConEng14.Items.Add(f2)
					Me.comboSoundConEng15.Items.Add(f2)
					Me.comboSoundConEng16.Items.Add(f2)
					Me.comboSoundConEng17.Items.Add(f2)
					Me.comboSoundConEng18.Items.Add(f2)
					Me.comboSoundConEng19.Items.Add(f2)
					Me.comboSoundConEng20.Items.Add(f2)
					Me.comboSoundConEng21.Items.Add(f2)
					Me.comboSoundConEng22.Items.Add(f2)
					Me.comboSoundConEng23.Items.Add(f2)
					Me.comboSoundConEng24.Items.Add(f2)
				Next
			Finally
				Dim enumerator2 As IEnumerator(Of String)
				flag = enumerator2 IsNot Nothing
				If flag Then
					enumerator2.Dispose()
				End If
			End Try
		End Sub

		' Token: 0x0600029C RID: 668 RVA: 0x0001C570 File Offset: 0x0001A970
		Public Sub PlaySoundFirst()
			NewLateBinding.LateCall(MyProject.Computer.Audio, Nothing, "Play", New Object() { Operators.ConcatenateObject(Operators.ConcatenateObject("C:\Sound\Bell\", Me.listSoundBell.SelectedItem), "\First.wav"), AudioPlayMode.WaitToComplete }, Nothing, Nothing, Nothing, True)
		End Sub

		' Token: 0x0600029D RID: 669 RVA: 0x0001C5D0 File Offset: 0x0001A9D0
		Public Sub PlaySoundLast()
			NewLateBinding.LateCall(MyProject.Computer.Audio, Nothing, "Play", New Object() { Operators.ConcatenateObject(Operators.ConcatenateObject("C:\Sound\Bell\", Me.listSoundBell.SelectedItem), "\Last.wav"), AudioPlayMode.WaitToComplete }, Nothing, Nothing, Nothing, True)
		End Sub

		' Token: 0x0600029E RID: 670 RVA: 0x0001C630 File Offset: 0x0001AA30
		Public Sub VoiceConEng(c As Object, e As Object)
			Dim num2 As Integer
			Dim num4 As Integer
			Dim obj As Object
			Try
				IL_0001:
				Dim num As Integer = 1
				Dim flag As Boolean = Conversions.ToBoolean(Operators.AndObject(c, Strings.Right(Conversions.ToString(e), 4).Equals(".wav")))
				If Not flag Then
					GoTo IL_0074
				End If
				IL_002F:
				num = 2
				NewLateBinding.LateCall(MyProject.Computer.Audio, Nothing, "Play", New Object() { Operators.ConcatenateObject("C:\Sound\Eng\ConTN\", e), AudioPlayMode.WaitToComplete }, Nothing, Nothing, Nothing, True)
				IL_006C:
				ProjectData.ClearProjectError()
				num2 = -2
				IL_0074:
				IL_0075:
				GoTo IL_00E3
				IL_007A:
				Dim num3 As Integer = num4 + 1
				num4 = 0
				switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3)
				IL_009C:
				GoTo IL_00D8
				IL_009E:
				num4 = num
				switch(ICSharpCode.Decompiler.ILAst.ILLabel[], If((num2 > -2), num2, 1))
				IL_00B6:
			Catch obj2 When endfilter((TypeOf obj Is Exception) And (num2 <> 0) And (num4 = 0))
				Dim ex As Exception = CType(obj2, Exception)
				GoTo IL_009E
			End Try
			IL_00D8:
			Throw ProjectData.CreateProjectError(-2146828237)
			IL_00E3:
			If num4 <> 0 Then
				ProjectData.ClearProjectError()
			End If
		End Sub

		' Token: 0x0600029F RID: 671 RVA: 0x0001C73C File Offset: 0x0001AB3C
		Public Sub VoiceConThai(c As Object, t As Object)
			Dim num2 As Integer
			Dim num4 As Integer
			Dim obj As Object
			Try
				IL_0001:
				Dim num As Integer = 1
				Dim flag As Boolean = Conversions.ToBoolean(Operators.AndObject(c, Strings.Right(Conversions.ToString(t), 4).Equals(".wav")))
				If Not flag Then
					GoTo IL_0074
				End If
				IL_002F:
				num = 2
				NewLateBinding.LateCall(MyProject.Computer.Audio, Nothing, "Play", New Object() { Operators.ConcatenateObject("C:\Sound\Thai\ConTN\", t), AudioPlayMode.WaitToComplete }, Nothing, Nothing, Nothing, True)
				IL_006C:
				ProjectData.ClearProjectError()
				num2 = -2
				IL_0074:
				IL_0075:
				GoTo IL_00E3
				IL_007A:
				Dim num3 As Integer = num4 + 1
				num4 = 0
				switch(ICSharpCode.Decompiler.ILAst.ILLabel[], num3)
				IL_009C:
				GoTo IL_00D8
				IL_009E:
				num4 = num
				switch(ICSharpCode.Decompiler.ILAst.ILLabel[], If((num2 > -2), num2, 1))
				IL_00B6:
			Catch obj2 When endfilter((TypeOf obj Is Exception) And (num2 <> 0) And (num4 = 0))
				Dim ex As Exception = CType(obj2, Exception)
				GoTo IL_009E
			End Try
			IL_00D8:
			Throw ProjectData.CreateProjectError(-2146828237)
			IL_00E3:
			If num4 <> 0 Then
				ProjectData.ClearProjectError()
			End If
		End Sub

		' Token: 0x060002A0 RID: 672 RVA: 0x0001C848 File Offset: 0x0001AC48
		Public Sub VoiceTimeThai(c As Object)
			Dim flag As Boolean = Conversions.ToBoolean(c)
			If flag Then
				MyProject.Computer.Audio.Play("C:\Sound\Thai\Now.wav", AudioPlayMode.WaitToComplete)
				MyProject.Computer.Audio.Play("C:\Sound\Thai\" + Conversions.ToString(DateAndTime.TimeOfDay.Hour) + ".wav", AudioPlayMode.WaitToComplete)
				MyProject.Computer.Audio.Play("C:\Sound\Thai\OClock.wav", AudioPlayMode.WaitToComplete)
				MyProject.Computer.Audio.Play("C:\Sound\Thai\" + Conversions.ToString(DateAndTime.TimeOfDay.Minute) + ".wav", AudioPlayMode.WaitToComplete)
				flag = DateAndTime.TimeOfDay.Minute <> 0
				If flag Then
					MyProject.Computer.Audio.Play("C:\Sound\Thai\Minute.wav", AudioPlayMode.WaitToComplete)
				End If
			End If
		End Sub

		' Token: 0x060002A1 RID: 673 RVA: 0x0001C924 File Offset: 0x0001AD24
		Public Sub VoiceTimeEng(c As Object)
			Dim flag As Boolean = Conversions.ToBoolean(c)
			If flag Then
				MyProject.Computer.Audio.Play("C:\Sound\Eng\Now.wav", AudioPlayMode.WaitToComplete)
				flag = DateAndTime.TimeOfDay.Minute = 30
				If flag Then
					MyProject.Computer.Audio.Play("C:\Sound\Eng\HalfPast.wav", AudioPlayMode.WaitToComplete)
					MyProject.Computer.Audio.Play("C:\Sound\Eng\" + Conversions.ToString(DateAndTime.TimeOfDay.Hour) + ".wav", AudioPlayMode.WaitToComplete)
				Else
					MyProject.Computer.Audio.Play("C:\Sound\Eng\" + Conversions.ToString(DateAndTime.TimeOfDay.Hour) + ".wav", AudioPlayMode.WaitToComplete)
					MyProject.Computer.Audio.Play("C:\Sound\Eng\" + Conversions.ToString(DateAndTime.TimeOfDay.Minute) + ".wav", AudioPlayMode.WaitToComplete)
				End If
			End If
		End Sub

		' Token: 0x060002A2 RID: 674 RVA: 0x0001CA1C File Offset: 0x0001AE1C
		Public Sub PlaySoundTest(c As Object, h As Object, m As Object)
			Dim flag As Boolean = Conversions.ToBoolean(c)
			If flag Then
				Dim flag2 As Boolean = Me.chkThai.Checked
				If flag2 Then
					MyProject.Computer.Audio.Play("C:\Sound\Thai\Now.wav", AudioPlayMode.WaitToComplete)
					MyProject.Computer.Audio.Play("C:\Sound\Thai\" + Conversions.ToInteger(h).ToString() + ".wav", AudioPlayMode.WaitToComplete)
					MyProject.Computer.Audio.Play("C:\Sound\Thai\OClock.wav", AudioPlayMode.WaitToComplete)
					MyProject.Computer.Audio.Play("C:\Sound\Thai\" + Conversions.ToInteger(m).ToString() + ".wav", AudioPlayMode.WaitToComplete)
					flag2 = Conversions.ToInteger(m) <> 0
					If flag2 Then
						MyProject.Computer.Audio.Play("C:\Sound\Thai\Minute.wav", AudioPlayMode.WaitToComplete)
					End If
				End If
				flag2 = Me.chkEng.Checked
				If flag2 Then
					MyProject.Computer.Audio.Play("C:\Sound\Eng\Now.wav", AudioPlayMode.WaitToComplete)
					flag2 = Conversions.ToInteger(m) = 30
					If flag2 Then
						MyProject.Computer.Audio.Play("C:\Sound\Eng\HalfPast.wav", AudioPlayMode.WaitToComplete)
						MyProject.Computer.Audio.Play("C:\Sound\Eng\" + Conversions.ToInteger(h).ToString() + ".wav", AudioPlayMode.WaitToComplete)
					Else
						MyProject.Computer.Audio.Play("C:\Sound\Eng\" + Conversions.ToInteger(h).ToString() + ".wav", AudioPlayMode.WaitToComplete)
						MyProject.Computer.Audio.Play("C:\Sound\Eng\" + Conversions.ToInteger(m).ToString() + ".wav", AudioPlayMode.WaitToComplete)
					End If
				End If
			End If
		End Sub

		' Token: 0x060002A3 RID: 675 RVA: 0x0001CBD8 File Offset: 0x0001AFD8
		Public Sub getPath()
			Dim strPath As String = Environment.CurrentDirectory
			Dim i As Integer = Strings.Len(strPath)
			While True
				Dim num As Integer = i
				Dim num2 As Integer = 1
				If num < num2 Then
					GoTo IL_0050
				End If
				Dim flag As Boolean = Operators.CompareString(Strings.Mid(strPath, i, 1), "\", False) = 0
				Dim CountBackSlash As Integer
				If flag Then
					CountBackSlash += 1
				End If
				flag = CountBackSlash = 3
				If flag Then
					Exit For
				End If
				i += -1
			End While
			strPath = Strings.Mid(strPath, 1, i)
			IL_0050:
			Me.lblPath.Text = strPath
		End Sub

		' Token: 0x060002A4 RID: 676 RVA: 0x0001CC44 File Offset: 0x0001B044
		Public Sub loadDay()
			Dim flag As Boolean = Operators.CompareString(DateAndTime.WeekdayName(DateAndTime.Weekday(DateTime.Today, FirstDayOfWeek.Sunday), False, FirstDayOfWeek.System), FirstDayOfWeek.Sunday.ToString(), False) = 0
			If flag Then
				Me.loadData(1)
				Me.radioSun.Checked = True
				Me.BackColor = Color.Tomato
			Else
				flag = Operators.CompareString(DateAndTime.WeekdayName(DateAndTime.Weekday(DateTime.Today, FirstDayOfWeek.Sunday), False, FirstDayOfWeek.System), FirstDayOfWeek.Monday.ToString(), False) = 0
				If flag Then
					Me.loadData(2)
					Me.radioMon.Checked = True
					Me.BackColor = Color.Yellow
				Else
					flag = Operators.CompareString(DateAndTime.WeekdayName(DateAndTime.Weekday(DateTime.Today, FirstDayOfWeek.Sunday), False, FirstDayOfWeek.System), FirstDayOfWeek.Tuesday.ToString(), False) = 0
					If flag Then
						Me.loadData(3)
						Me.radioTue.Checked = True
						Me.BackColor = Color.MistyRose
					Else
						flag = Operators.CompareString(DateAndTime.WeekdayName(DateAndTime.Weekday(DateTime.Today, FirstDayOfWeek.Sunday), False, FirstDayOfWeek.System), FirstDayOfWeek.Wednesday.ToString(), False) = 0
						If flag Then
							Me.loadData(4)
							Me.radioWed.Checked = True
							Me.BackColor = Color.DarkSeaGreen
						Else
							flag = Operators.CompareString(DateAndTime.WeekdayName(DateAndTime.Weekday(DateTime.Today, FirstDayOfWeek.Sunday), False, FirstDayOfWeek.System), FirstDayOfWeek.Thursday.ToString(), False) = 0
							If flag Then
								Me.loadData(5)
								Me.radioThu.Checked = True
								Me.BackColor = Color.Orange
							Else
								flag = Operators.CompareString(DateAndTime.WeekdayName(DateAndTime.Weekday(DateTime.Today, FirstDayOfWeek.Sunday), False, FirstDayOfWeek.System), FirstDayOfWeek.Friday.ToString(), False) = 0
								If flag Then
									Me.loadData(6)
									Me.radioFri.Checked = True
									Me.BackColor = Color.Aquamarine
								Else
									flag = Operators.CompareString(DateAndTime.WeekdayName(DateAndTime.Weekday(DateTime.Today, FirstDayOfWeek.Sunday), False, FirstDayOfWeek.System), FirstDayOfWeek.Saturday.ToString(), False) = 0
									If flag Then
										Me.loadData(7)
										Me.radioSat.Checked = True
										Me.BackColor = Color.Violet
									End If
								End If
							End If
						End If
					End If
				End If
			End If
		End Sub

		' Token: 0x060002A5 RID: 677 RVA: 0x0001CE7C File Offset: 0x0001B27C
		Private Function getSettingDay() As Integer
			Dim chkday As Integer
			Try
				Dim strConn As String = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\db.accdb; Persist Security Info=false; Jet OLEDB:Database Password='toona201'"
				Dim Conn As OleDbConnection = New OleDbConnection(strConn)
				Conn.Open()
				Dim strSQL2 As String = "SELECT * FROM normal_setting"
				Dim cmd2 As OleDbCommand = New OleDbCommand(strSQL2, Conn)
				Dim reader2 As OleDbDataReader = cmd2.ExecuteReader()
				Dim hasRows As Boolean = reader2.HasRows
				If hasRows Then
					While reader2.Read()
						Dim flag As Boolean = Conversions.ToInteger(reader2(0)) = 7
						If flag Then
							chkday = Conversions.ToInteger(reader2(2))
						End If
					End While
				End If
				Conn.Close()
			Catch ex As Exception
				Interaction.MsgBox("ERROR : " + ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
			Return chkday
		End Function

		' Token: 0x060002A6 RID: 678 RVA: 0x0001CF54 File Offset: 0x0001B354
		Public Sub loadSetting()
			Try
				Dim strConn As String = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\db.accdb; Persist Security Info=false; Jet OLEDB:Database Password='toona201'"
				Dim Conn As OleDbConnection = New OleDbConnection(strConn)
				Conn.Open()
				Dim strSQL2 As String = "SELECT * FROM normal_setting"
				Dim cmd2 As OleDbCommand = New OleDbCommand(strSQL2, Conn)
				Dim reader2 As OleDbDataReader = cmd2.ExecuteReader()
				Dim hasRows As Boolean = reader2.HasRows
				If hasRows Then
					While reader2.Read()
						Dim flag As Boolean = Conversions.ToInteger(reader2(0)) = 1
						If flag Then
							Me.chkThai.Checked = Conversions.ToBoolean(reader2(2))
						Else
							flag = Conversions.ToInteger(reader2(0)) = 2
							If flag Then
								Me.chkEng.Checked = Conversions.ToBoolean(reader2(2))
							Else
								flag = Conversions.ToInteger(reader2(0)) = 3
								If flag Then
									Me.listSoundBell.SetSelected(Conversions.ToInteger(reader2(2)), True)
								Else
									flag = Conversions.ToInteger(reader2(0)) = 4
									If flag Then
										Me.ckShutDown.Checked = Conversions.ToBoolean(reader2(2))
										Me.comboHourShutdown.Text = reader2(3).ToString()
										Me.comboMinShutdown.Text = reader2(4).ToString()
									Else
										flag = Conversions.ToInteger(reader2(0)) = 5
										If flag Then
											Me.listLangDisplay.SelectedIndex = Conversions.ToInteger(reader2(2).ToString())
										Else
											flag = Conversions.ToInteger(reader2(0)) = 6
											If flag Then
												Me.lblCD.Text = reader2(2).ToString()
											End If
										End If
									End If
								End If
							End If
						End If
					End While
				End If
				Conn.Close()
			Catch ex As Exception
				Interaction.MsgBox("ERROR : " + ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
		End Sub

		' Token: 0x060002A7 RID: 679 RVA: 0x0001D16C File Offset: 0x0001B56C
		Public Sub loadData(d As Integer)
			Try
				Dim strConn As String = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\db.accdb; Persist Security Info=false; Jet OLEDB:Database Password='toona201'"
				Dim Conn As OleDbConnection = New OleDbConnection(strConn)
				Conn.Open()
				Dim strSQL As String = "SELECT * FROM normal_time WHERE todayID = " + Conversions.ToString(d)
				Dim cmd As OleDbCommand = New OleDbCommand(strSQL, Conn)
				Dim reader As OleDbDataReader = cmd.ExecuteReader()
				Dim hasRows As Boolean = reader.HasRows
				If hasRows Then
					Dim flag As Boolean = d = 1
					If flag Then
						While reader.Read()
							Dim flag2 As Boolean = Conversions.ToInteger(reader(0)) = 1
							If flag2 Then
								Me.chkFirst1.Checked = Conversions.ToBoolean(reader(1))
								Me.chkTime1.Checked = Conversions.ToBoolean(reader(2))
								Me.comboHour1.Text = reader(3).ToString()
								Me.comboMin1.Text = reader(4).ToString()
								Me.chkCon1.Checked = Conversions.ToBoolean(reader(5))
								Me.comboSoundCon1.Text = reader(6).ToString()
								Me.comboSoundConEng1.Text = reader(7).ToString()
								Me.chkLast1.Checked = Conversions.ToBoolean(reader(8))
							Else
								flag2 = Conversions.ToInteger(reader(0)) = 2
								If flag2 Then
									Me.chkFirst2.Checked = Conversions.ToBoolean(reader(1))
									Me.chkTime2.Checked = Conversions.ToBoolean(reader(2))
									Me.comboHour2.Text = reader(3).ToString()
									Me.comboMin2.Text = reader(4).ToString()
									Me.chkCon2.Checked = Conversions.ToBoolean(reader(5))
									Me.comboSoundCon2.Text = reader(6).ToString()
									Me.comboSoundConEng2.Text = reader(7).ToString()
									Me.chkLast2.Checked = Conversions.ToBoolean(reader(8))
								Else
									flag2 = Conversions.ToInteger(reader(0)) = 3
									If flag2 Then
										Me.chkFirst3.Checked = Conversions.ToBoolean(reader(1))
										Me.chkTime3.Checked = Conversions.ToBoolean(reader(2))
										Me.comboHour3.Text = reader(3).ToString()
										Me.comboMin3.Text = reader(4).ToString()
										Me.chkCon3.Checked = Conversions.ToBoolean(reader(5))
										Me.comboSoundCon3.Text = reader(6).ToString()
										Me.comboSoundConEng3.Text = reader(7).ToString()
										Me.chkLast3.Checked = Conversions.ToBoolean(reader(8))
									Else
										flag2 = Conversions.ToInteger(reader(0)) = 4
										If flag2 Then
											Me.chkFirst4.Checked = Conversions.ToBoolean(reader(1))
											Me.chkTime4.Checked = Conversions.ToBoolean(reader(2))
											Me.comboHour4.Text = reader(3).ToString()
											Me.comboMin4.Text = reader(4).ToString()
											Me.chkCon4.Checked = Conversions.ToBoolean(reader(5))
											Me.comboSoundCon4.Text = reader(6).ToString()
											Me.comboSoundConEng4.Text = reader(7).ToString()
											Me.chkLast4.Checked = Conversions.ToBoolean(reader(8))
										Else
											flag2 = Conversions.ToInteger(reader(0)) = 5
											If flag2 Then
												Me.chkFirst5.Checked = Conversions.ToBoolean(reader(1))
												Me.chkTime5.Checked = Conversions.ToBoolean(reader(2))
												Me.comboHour5.Text = reader(3).ToString()
												Me.comboMin5.Text = reader(4).ToString()
												Me.chkCon5.Checked = Conversions.ToBoolean(reader(5))
												Me.comboSoundCon5.Text = reader(6).ToString()
												Me.comboSoundConEng5.Text = reader(7).ToString()
												Me.chkLast5.Checked = Conversions.ToBoolean(reader(8))
											Else
												flag2 = Conversions.ToInteger(reader(0)) = 6
												If flag2 Then
													Me.chkFirst6.Checked = Conversions.ToBoolean(reader(1))
													Me.chkTime6.Checked = Conversions.ToBoolean(reader(2))
													Me.comboHour6.Text = reader(3).ToString()
													Me.comboMin6.Text = reader(4).ToString()
													Me.chkCon6.Checked = Conversions.ToBoolean(reader(5))
													Me.comboSoundCon6.Text = reader(6).ToString()
													Me.comboSoundConEng6.Text = reader(7).ToString()
													Me.chkLast6.Checked = Conversions.ToBoolean(reader(8))
												Else
													flag2 = Conversions.ToInteger(reader(0)) = 7
													If flag2 Then
														Me.chkFirst7.Checked = Conversions.ToBoolean(reader(1))
														Me.chkTime7.Checked = Conversions.ToBoolean(reader(2))
														Me.comboHour7.Text = reader(3).ToString()
														Me.comboMin7.Text = reader(4).ToString()
														Me.chkCon7.Checked = Conversions.ToBoolean(reader(5))
														Me.comboSoundCon7.Text = reader(6).ToString()
														Me.comboSoundConEng7.Text = reader(7).ToString()
														Me.chkLast7.Checked = Conversions.ToBoolean(reader(8))
													Else
														flag2 = Conversions.ToInteger(reader(0)) = 8
														If flag2 Then
															Me.chkFirst8.Checked = Conversions.ToBoolean(reader(1))
															Me.chkTime8.Checked = Conversions.ToBoolean(reader(2))
															Me.comboHour8.Text = reader(3).ToString()
															Me.comboMin8.Text = reader(4).ToString()
															Me.chkCon8.Checked = Conversions.ToBoolean(reader(5))
															Me.comboSoundCon8.Text = reader(6).ToString()
															Me.comboSoundConEng8.Text = reader(7).ToString()
															Me.chkLast8.Checked = Conversions.ToBoolean(reader(8))
														Else
															flag2 = Conversions.ToInteger(reader(0)) = 9
															If flag2 Then
																Me.chkFirst9.Checked = Conversions.ToBoolean(reader(1))
																Me.chkTime9.Checked = Conversions.ToBoolean(reader(2))
																Me.comboHour9.Text = reader(3).ToString()
																Me.comboMin9.Text = reader(4).ToString()
																Me.chkCon9.Checked = Conversions.ToBoolean(reader(5))
																Me.comboSoundCon9.Text = reader(6).ToString()
																Me.comboSoundConEng9.Text = reader(7).ToString()
																Me.chkLast9.Checked = Conversions.ToBoolean(reader(8))
															Else
																flag2 = Conversions.ToInteger(reader(0)) = 10
																If flag2 Then
																	Me.chkFirst10.Checked = Conversions.ToBoolean(reader(1))
																	Me.chkTime10.Checked = Conversions.ToBoolean(reader(2))
																	Me.comboHour10.Text = reader(3).ToString()
																	Me.comboMin10.Text = reader(4).ToString()
																	Me.chkCon10.Checked = Conversions.ToBoolean(reader(5))
																	Me.comboSoundCon10.Text = reader(6).ToString()
																	Me.comboSoundConEng10.Text = reader(7).ToString()
																	Me.chkLast10.Checked = Conversions.ToBoolean(reader(8))
																Else
																	flag2 = Conversions.ToInteger(reader(0)) = 11
																	If flag2 Then
																		Me.chkFirst11.Checked = Conversions.ToBoolean(reader(1))
																		Me.chkTime11.Checked = Conversions.ToBoolean(reader(2))
																		Me.comboHour11.Text = reader(3).ToString()
																		Me.comboMin11.Text = reader(4).ToString()
																		Me.chkCon11.Checked = Conversions.ToBoolean(reader(5))
																		Me.comboSoundCon11.Text = reader(6).ToString()
																		Me.comboSoundConEng11.Text = reader(7).ToString()
																		Me.chkLast11.Checked = Conversions.ToBoolean(reader(8))
																	Else
																		flag2 = Conversions.ToInteger(reader(0)) = 12
																		If flag2 Then
																			Me.chkFirst12.Checked = Conversions.ToBoolean(reader(1))
																			Me.chkTime12.Checked = Conversions.ToBoolean(reader(2))
																			Me.comboHour12.Text = reader(3).ToString()
																			Me.comboMin12.Text = reader(4).ToString()
																			Me.chkCon12.Checked = Conversions.ToBoolean(reader(5))
																			Me.comboSoundCon12.Text = reader(6).ToString()
																			Me.comboSoundConEng12.Text = reader(7).ToString()
																			Me.chkLast12.Checked = Conversions.ToBoolean(reader(8))
																		Else
																			flag2 = Conversions.ToInteger(reader(0)) = 13
																			If flag2 Then
																				Me.chkFirst13.Checked = Conversions.ToBoolean(reader(1))
																				Me.chkTime13.Checked = Conversions.ToBoolean(reader(2))
																				Me.comboHour13.Text = reader(3).ToString()
																				Me.comboMin13.Text = reader(4).ToString()
																				Me.chkCon13.Checked = Conversions.ToBoolean(reader(5))
																				Me.comboSoundCon13.Text = reader(6).ToString()
																				Me.comboSoundConEng13.Text = reader(7).ToString()
																				Me.chkLast13.Checked = Conversions.ToBoolean(reader(8))
																			Else
																				flag2 = Conversions.ToInteger(reader(0)) = 14
																				If flag2 Then
																					Me.chkFirst14.Checked = Conversions.ToBoolean(reader(1))
																					Me.chkTime14.Checked = Conversions.ToBoolean(reader(2))
																					Me.comboHour14.Text = reader(3).ToString()
																					Me.comboMin14.Text = reader(4).ToString()
																					Me.chkCon14.Checked = Conversions.ToBoolean(reader(5))
																					Me.comboSoundCon14.Text = reader(6).ToString()
																					Me.comboSoundConEng14.Text = reader(7).ToString()
																					Me.chkLast14.Checked = Conversions.ToBoolean(reader(8))
																				Else
																					flag2 = Conversions.ToInteger(reader(0)) = 15
																					If flag2 Then
																						Me.chkFirst15.Checked = Conversions.ToBoolean(reader(1))
																						Me.chkTime15.Checked = Conversions.ToBoolean(reader(2))
																						Me.comboHour15.Text = reader(3).ToString()
																						Me.comboMin15.Text = reader(4).ToString()
																						Me.chkCon15.Checked = Conversions.ToBoolean(reader(5))
																						Me.comboSoundCon15.Text = reader(6).ToString()
																						Me.comboSoundConEng15.Text = reader(7).ToString()
																						Me.chkLast15.Checked = Conversions.ToBoolean(reader(8))
																					Else
																						flag2 = Conversions.ToInteger(reader(0)) = 16
																						If flag2 Then
																							Me.chkFirst16.Checked = Conversions.ToBoolean(reader(1))
																							Me.chkTime16.Checked = Conversions.ToBoolean(reader(2))
																							Me.comboHour16.Text = reader(3).ToString()
																							Me.comboMin16.Text = reader(4).ToString()
																							Me.chkCon16.Checked = Conversions.ToBoolean(reader(5))
																							Me.comboSoundCon16.Text = reader(6).ToString()
																							Me.comboSoundConEng16.Text = reader(7).ToString()
																							Me.chkLast16.Checked = Conversions.ToBoolean(reader(8))
																						Else
																							flag2 = Conversions.ToInteger(reader(0)) = 17
																							If flag2 Then
																								Me.chkFirst17.Checked = Conversions.ToBoolean(reader(1))
																								Me.chkTime17.Checked = Conversions.ToBoolean(reader(2))
																								Me.comboHour17.Text = reader(3).ToString()
																								Me.comboMin17.Text = reader(4).ToString()
																								Me.chkCon17.Checked = Conversions.ToBoolean(reader(5))
																								Me.comboSoundCon17.Text = reader(6).ToString()
																								Me.comboSoundConEng17.Text = reader(7).ToString()
																								Me.chkLast17.Checked = Conversions.ToBoolean(reader(8))
																							Else
																								flag2 = Conversions.ToInteger(reader(0)) = 18
																								If flag2 Then
																									Me.chkFirst18.Checked = Conversions.ToBoolean(reader(1))
																									Me.chkTime18.Checked = Conversions.ToBoolean(reader(2))
																									Me.comboHour18.Text = reader(3).ToString()
																									Me.comboMin18.Text = reader(4).ToString()
																									Me.chkCon18.Checked = Conversions.ToBoolean(reader(5))
																									Me.comboSoundCon18.Text = reader(6).ToString()
																									Me.comboSoundConEng18.Text = reader(7).ToString()
																									Me.chkLast18.Checked = Conversions.ToBoolean(reader(8))
																								Else
																									flag2 = Conversions.ToInteger(reader(0)) = 19
																									If flag2 Then
																										Me.chkFirst19.Checked = Conversions.ToBoolean(reader(1))
																										Me.chkTime19.Checked = Conversions.ToBoolean(reader(2))
																										Me.comboHour19.Text = reader(3).ToString()
																										Me.comboMin19.Text = reader(4).ToString()
																										Me.chkCon19.Checked = Conversions.ToBoolean(reader(5))
																										Me.comboSoundCon19.Text = reader(6).ToString()
																										Me.comboSoundConEng19.Text = reader(7).ToString()
																										Me.chkLast19.Checked = Conversions.ToBoolean(reader(8))
																									Else
																										flag2 = Conversions.ToInteger(reader(0)) = 20
																										If flag2 Then
																											Me.chkFirst20.Checked = Conversions.ToBoolean(reader(1))
																											Me.chkTime20.Checked = Conversions.ToBoolean(reader(2))
																											Me.comboHour20.Text = reader(3).ToString()
																											Me.comboMin20.Text = reader(4).ToString()
																											Me.chkCon20.Checked = Conversions.ToBoolean(reader(5))
																											Me.comboSoundCon20.Text = reader(6).ToString()
																											Me.comboSoundConEng20.Text = reader(7).ToString()
																											Me.chkLast20.Checked = Conversions.ToBoolean(reader(8))
																										Else
																											flag2 = Conversions.ToInteger(reader(0)) = 21
																											If flag2 Then
																												Me.chkFirst21.Checked = Conversions.ToBoolean(reader(1))
																												Me.chkTime21.Checked = Conversions.ToBoolean(reader(2))
																												Me.comboHour21.Text = reader(3).ToString()
																												Me.comboMin21.Text = reader(4).ToString()
																												Me.chkCon21.Checked = Conversions.ToBoolean(reader(5))
																												Me.comboSoundCon21.Text = reader(6).ToString()
																												Me.comboSoundConEng21.Text = reader(7).ToString()
																												Me.chkLast21.Checked = Conversions.ToBoolean(reader(8))
																											Else
																												flag2 = Conversions.ToInteger(reader(0)) = 22
																												If flag2 Then
																													Me.chkFirst22.Checked = Conversions.ToBoolean(reader(1))
																													Me.chkTime22.Checked = Conversions.ToBoolean(reader(2))
																													Me.comboHour22.Text = reader(3).ToString()
																													Me.comboMin22.Text = reader(4).ToString()
																													Me.chkCon22.Checked = Conversions.ToBoolean(reader(5))
																													Me.comboSoundCon22.Text = reader(6).ToString()
																													Me.comboSoundConEng22.Text = reader(7).ToString()
																													Me.chkLast22.Checked = Conversions.ToBoolean(reader(8))
																												Else
																													flag2 = Conversions.ToInteger(reader(0)) = 23
																													If flag2 Then
																														Me.chkFirst23.Checked = Conversions.ToBoolean(reader(1))
																														Me.chkTime23.Checked = Conversions.ToBoolean(reader(2))
																														Me.comboHour23.Text = reader(3).ToString()
																														Me.comboMin23.Text = reader(4).ToString()
																														Me.chkCon23.Checked = Conversions.ToBoolean(reader(5))
																														Me.comboSoundCon23.Text = reader(6).ToString()
																														Me.comboSoundConEng23.Text = reader(7).ToString()
																														Me.chkLast23.Checked = Conversions.ToBoolean(reader(8))
																													Else
																														flag2 = Conversions.ToInteger(reader(0)) = 24
																														If flag2 Then
																															Me.chkFirst24.Checked = Conversions.ToBoolean(reader(1))
																															Me.chkTime24.Checked = Conversions.ToBoolean(reader(2))
																															Me.comboHour24.Text = reader(3).ToString()
																															Me.comboMin24.Text = reader(4).ToString()
																															Me.chkCon24.Checked = Conversions.ToBoolean(reader(5))
																															Me.comboSoundCon24.Text = reader(6).ToString()
																															Me.comboSoundConEng24.Text = reader(7).ToString()
																															Me.chkLast24.Checked = Conversions.ToBoolean(reader(8))
																														End If
																													End If
																												End If
																											End If
																										End If
																									End If
																								End If
																							End If
																						End If
																					End If
																				End If
																			End If
																		End If
																	End If
																End If
															End If
														End If
													End If
												End If
											End If
										End If
									End If
								End If
							End If
						End While
					Else
						Dim flag2 As Boolean = d = 2
						If flag2 Then
							While reader.Read()
								flag = Conversions.ToInteger(reader(0)) = 25
								If flag Then
									Me.chkFirst1.Checked = Conversions.ToBoolean(reader(1))
									Me.chkTime1.Checked = Conversions.ToBoolean(reader(2))
									Me.comboHour1.Text = reader(3).ToString()
									Me.comboMin1.Text = reader(4).ToString()
									Me.chkCon1.Checked = Conversions.ToBoolean(reader(5))
									Me.comboSoundCon1.Text = reader(6).ToString()
									Me.comboSoundConEng1.Text = reader(7).ToString()
									Me.chkLast1.Checked = Conversions.ToBoolean(reader(8))
								Else
									flag2 = Conversions.ToInteger(reader(0)) = 26
									If flag2 Then
										Me.chkFirst2.Checked = Conversions.ToBoolean(reader(1))
										Me.chkTime2.Checked = Conversions.ToBoolean(reader(2))
										Me.comboHour2.Text = reader(3).ToString()
										Me.comboMin2.Text = reader(4).ToString()
										Me.chkCon2.Checked = Conversions.ToBoolean(reader(5))
										Me.comboSoundCon2.Text = reader(6).ToString()
										Me.comboSoundConEng2.Text = reader(7).ToString()
										Me.chkLast2.Checked = Conversions.ToBoolean(reader(8))
									Else
										flag2 = Conversions.ToInteger(reader(0)) = 27
										If flag2 Then
											Me.chkFirst3.Checked = Conversions.ToBoolean(reader(1))
											Me.chkTime3.Checked = Conversions.ToBoolean(reader(2))
											Me.comboHour3.Text = reader(3).ToString()
											Me.comboMin3.Text = reader(4).ToString()
											Me.chkCon3.Checked = Conversions.ToBoolean(reader(5))
											Me.comboSoundCon3.Text = reader(6).ToString()
											Me.comboSoundConEng3.Text = reader(7).ToString()
											Me.chkLast3.Checked = Conversions.ToBoolean(reader(8))
										Else
											flag2 = Conversions.ToInteger(reader(0)) = 28
											If flag2 Then
												Me.chkFirst4.Checked = Conversions.ToBoolean(reader(1))
												Me.chkTime4.Checked = Conversions.ToBoolean(reader(2))
												Me.comboHour4.Text = reader(3).ToString()
												Me.comboMin4.Text = reader(4).ToString()
												Me.chkCon4.Checked = Conversions.ToBoolean(reader(5))
												Me.comboSoundCon4.Text = reader(6).ToString()
												Me.comboSoundConEng4.Text = reader(7).ToString()
												Me.chkLast4.Checked = Conversions.ToBoolean(reader(8))
											Else
												flag2 = Conversions.ToInteger(reader(0)) = 29
												If flag2 Then
													Me.chkFirst5.Checked = Conversions.ToBoolean(reader(1))
													Me.chkTime5.Checked = Conversions.ToBoolean(reader(2))
													Me.comboHour5.Text = reader(3).ToString()
													Me.comboMin5.Text = reader(4).ToString()
													Me.chkCon5.Checked = Conversions.ToBoolean(reader(5))
													Me.comboSoundCon5.Text = reader(6).ToString()
													Me.comboSoundConEng5.Text = reader(7).ToString()
													Me.chkLast5.Checked = Conversions.ToBoolean(reader(8))
												Else
													flag2 = Conversions.ToInteger(reader(0)) = 30
													If flag2 Then
														Me.chkFirst6.Checked = Conversions.ToBoolean(reader(1))
														Me.chkTime6.Checked = Conversions.ToBoolean(reader(2))
														Me.comboHour6.Text = reader(3).ToString()
														Me.comboMin6.Text = reader(4).ToString()
														Me.chkCon6.Checked = Conversions.ToBoolean(reader(5))
														Me.comboSoundCon6.Text = reader(6).ToString()
														Me.comboSoundConEng6.Text = reader(7).ToString()
														Me.chkLast6.Checked = Conversions.ToBoolean(reader(8))
													Else
														flag2 = Conversions.ToInteger(reader(0)) = 31
														If flag2 Then
															Me.chkFirst7.Checked = Conversions.ToBoolean(reader(1))
															Me.chkTime7.Checked = Conversions.ToBoolean(reader(2))
															Me.comboHour7.Text = reader(3).ToString()
															Me.comboMin7.Text = reader(4).ToString()
															Me.chkCon7.Checked = Conversions.ToBoolean(reader(5))
															Me.comboSoundCon7.Text = reader(6).ToString()
															Me.comboSoundConEng7.Text = reader(7).ToString()
															Me.chkLast7.Checked = Conversions.ToBoolean(reader(8))
														Else
															flag2 = Conversions.ToInteger(reader(0)) = 32
															If flag2 Then
																Me.chkFirst8.Checked = Conversions.ToBoolean(reader(1))
																Me.chkTime8.Checked = Conversions.ToBoolean(reader(2))
																Me.comboHour8.Text = reader(3).ToString()
																Me.comboMin8.Text = reader(4).ToString()
																Me.chkCon8.Checked = Conversions.ToBoolean(reader(5))
																Me.comboSoundCon8.Text = reader(6).ToString()
																Me.comboSoundConEng8.Text = reader(7).ToString()
																Me.chkLast8.Checked = Conversions.ToBoolean(reader(8))
															Else
																flag2 = Conversions.ToInteger(reader(0)) = 33
																If flag2 Then
																	Me.chkFirst9.Checked = Conversions.ToBoolean(reader(1))
																	Me.chkTime9.Checked = Conversions.ToBoolean(reader(2))
																	Me.comboHour9.Text = reader(3).ToString()
																	Me.comboMin9.Text = reader(4).ToString()
																	Me.chkCon9.Checked = Conversions.ToBoolean(reader(5))
																	Me.comboSoundCon9.Text = reader(6).ToString()
																	Me.comboSoundConEng9.Text = reader(7).ToString()
																	Me.chkLast9.Checked = Conversions.ToBoolean(reader(8))
																Else
																	flag2 = Conversions.ToInteger(reader(0)) = 34
																	If flag2 Then
																		Me.chkFirst10.Checked = Conversions.ToBoolean(reader(1))
																		Me.chkTime10.Checked = Conversions.ToBoolean(reader(2))
																		Me.comboHour10.Text = reader(3).ToString()
																		Me.comboMin10.Text = reader(4).ToString()
																		Me.chkCon10.Checked = Conversions.ToBoolean(reader(5))
																		Me.comboSoundCon10.Text = reader(6).ToString()
																		Me.comboSoundConEng10.Text = reader(7).ToString()
																		Me.chkLast10.Checked = Conversions.ToBoolean(reader(8))
																	Else
																		flag2 = Conversions.ToInteger(reader(0)) = 35
																		If flag2 Then
																			Me.chkFirst11.Checked = Conversions.ToBoolean(reader(1))
																			Me.chkTime11.Checked = Conversions.ToBoolean(reader(2))
																			Me.comboHour11.Text = reader(3).ToString()
																			Me.comboMin11.Text = reader(4).ToString()
																			Me.chkCon11.Checked = Conversions.ToBoolean(reader(5))
																			Me.comboSoundCon11.Text = reader(6).ToString()
																			Me.comboSoundConEng11.Text = reader(7).ToString()
																			Me.chkLast11.Checked = Conversions.ToBoolean(reader(8))
																		Else
																			flag2 = Conversions.ToInteger(reader(0)) = 36
																			If flag2 Then
																				Me.chkFirst12.Checked = Conversions.ToBoolean(reader(1))
																				Me.chkTime12.Checked = Conversions.ToBoolean(reader(2))
																				Me.comboHour12.Text = reader(3).ToString()
																				Me.comboMin12.Text = reader(4).ToString()
																				Me.chkCon12.Checked = Conversions.ToBoolean(reader(5))
																				Me.comboSoundCon12.Text = reader(6).ToString()
																				Me.comboSoundConEng12.Text = reader(7).ToString()
																				Me.chkLast12.Checked = Conversions.ToBoolean(reader(8))
																			Else
																				flag2 = Conversions.ToInteger(reader(0)) = 37
																				If flag2 Then
																					Me.chkFirst13.Checked = Conversions.ToBoolean(reader(1))
																					Me.chkTime13.Checked = Conversions.ToBoolean(reader(2))
																					Me.comboHour13.Text = reader(3).ToString()
																					Me.comboMin13.Text = reader(4).ToString()
																					Me.chkCon13.Checked = Conversions.ToBoolean(reader(5))
																					Me.comboSoundCon13.Text = reader(6).ToString()
																					Me.comboSoundConEng13.Text = reader(7).ToString()
																					Me.chkLast13.Checked = Conversions.ToBoolean(reader(8))
																				Else
																					flag2 = Conversions.ToInteger(reader(0)) = 38
																					If flag2 Then
																						Me.chkFirst14.Checked = Conversions.ToBoolean(reader(1))
																						Me.chkTime14.Checked = Conversions.ToBoolean(reader(2))
																						Me.comboHour14.Text = reader(3).ToString()
																						Me.comboMin14.Text = reader(4).ToString()
																						Me.chkCon14.Checked = Conversions.ToBoolean(reader(5))
																						Me.comboSoundCon14.Text = reader(6).ToString()
																						Me.comboSoundConEng14.Text = reader(7).ToString()
																						Me.chkLast14.Checked = Conversions.ToBoolean(reader(8))
																					Else
																						flag2 = Conversions.ToInteger(reader(0)) = 39
																						If flag2 Then
																							Me.chkFirst15.Checked = Conversions.ToBoolean(reader(1))
																							Me.chkTime15.Checked = Conversions.ToBoolean(reader(2))
																							Me.comboHour15.Text = reader(3).ToString()
																							Me.comboMin15.Text = reader(4).ToString()
																							Me.chkCon15.Checked = Conversions.ToBoolean(reader(5))
																							Me.comboSoundCon15.Text = reader(6).ToString()
																							Me.comboSoundConEng15.Text = reader(7).ToString()
																							Me.chkLast15.Checked = Conversions.ToBoolean(reader(8))
																						Else
																							flag2 = Conversions.ToInteger(reader(0)) = 40
																							If flag2 Then
																								Me.chkFirst16.Checked = Conversions.ToBoolean(reader(1))
																								Me.chkTime16.Checked = Conversions.ToBoolean(reader(2))
																								Me.comboHour16.Text = reader(3).ToString()
																								Me.comboMin16.Text = reader(4).ToString()
																								Me.chkCon16.Checked = Conversions.ToBoolean(reader(5))
																								Me.comboSoundCon16.Text = reader(6).ToString()
																								Me.comboSoundConEng16.Text = reader(7).ToString()
																								Me.chkLast16.Checked = Conversions.ToBoolean(reader(8))
																							Else
																								flag2 = Conversions.ToInteger(reader(0)) = 41
																								If flag2 Then
																									Me.chkFirst17.Checked = Conversions.ToBoolean(reader(1))
																									Me.chkTime17.Checked = Conversions.ToBoolean(reader(2))
																									Me.comboHour17.Text = reader(3).ToString()
																									Me.comboMin17.Text = reader(4).ToString()
																									Me.chkCon17.Checked = Conversions.ToBoolean(reader(5))
																									Me.comboSoundCon17.Text = reader(6).ToString()
																									Me.comboSoundConEng17.Text = reader(7).ToString()
																									Me.chkLast17.Checked = Conversions.ToBoolean(reader(8))
																								Else
																									flag2 = Conversions.ToInteger(reader(0)) = 42
																									If flag2 Then
																										Me.chkFirst18.Checked = Conversions.ToBoolean(reader(1))
																										Me.chkTime18.Checked = Conversions.ToBoolean(reader(2))
																										Me.comboHour18.Text = reader(3).ToString()
																										Me.comboMin18.Text = reader(4).ToString()
																										Me.chkCon18.Checked = Conversions.ToBoolean(reader(5))
																										Me.comboSoundCon18.Text = reader(6).ToString()
																										Me.comboSoundConEng18.Text = reader(7).ToString()
																										Me.chkLast18.Checked = Conversions.ToBoolean(reader(8))
																									Else
																										flag2 = Conversions.ToInteger(reader(0)) = 43
																										If flag2 Then
																											Me.chkFirst19.Checked = Conversions.ToBoolean(reader(1))
																											Me.chkTime19.Checked = Conversions.ToBoolean(reader(2))
																											Me.comboHour19.Text = reader(3).ToString()
																											Me.comboMin19.Text = reader(4).ToString()
																											Me.chkCon19.Checked = Conversions.ToBoolean(reader(5))
																											Me.comboSoundCon19.Text = reader(6).ToString()
																											Me.comboSoundConEng19.Text = reader(7).ToString()
																											Me.chkLast19.Checked = Conversions.ToBoolean(reader(8))
																										Else
																											flag2 = Conversions.ToInteger(reader(0)) = 44
																											If flag2 Then
																												Me.chkFirst20.Checked = Conversions.ToBoolean(reader(1))
																												Me.chkTime20.Checked = Conversions.ToBoolean(reader(2))
																												Me.comboHour20.Text = reader(3).ToString()
																												Me.comboMin20.Text = reader(4).ToString()
																												Me.chkCon20.Checked = Conversions.ToBoolean(reader(5))
																												Me.comboSoundCon20.Text = reader(6).ToString()
																												Me.comboSoundConEng20.Text = reader(7).ToString()
																												Me.chkLast20.Checked = Conversions.ToBoolean(reader(8))
																											Else
																												flag2 = Conversions.ToInteger(reader(0)) = 45
																												If flag2 Then
																													Me.chkFirst21.Checked = Conversions.ToBoolean(reader(1))
																													Me.chkTime21.Checked = Conversions.ToBoolean(reader(2))
																													Me.comboHour21.Text = reader(3).ToString()
																													Me.comboMin21.Text = reader(4).ToString()
																													Me.chkCon21.Checked = Conversions.ToBoolean(reader(5))
																													Me.comboSoundCon21.Text = reader(6).ToString()
																													Me.comboSoundConEng21.Text = reader(7).ToString()
																													Me.chkLast21.Checked = Conversions.ToBoolean(reader(8))
																												Else
																													flag2 = Conversions.ToInteger(reader(0)) = 46
																													If flag2 Then
																														Me.chkFirst22.Checked = Conversions.ToBoolean(reader(1))
																														Me.chkTime22.Checked = Conversions.ToBoolean(reader(2))
																														Me.comboHour22.Text = reader(3).ToString()
																														Me.comboMin22.Text = reader(4).ToString()
																														Me.chkCon22.Checked = Conversions.ToBoolean(reader(5))
																														Me.comboSoundCon22.Text = reader(6).ToString()
																														Me.comboSoundConEng22.Text = reader(7).ToString()
																														Me.chkLast22.Checked = Conversions.ToBoolean(reader(8))
																													Else
																														flag2 = Conversions.ToInteger(reader(0)) = 47
																														If flag2 Then
																															Me.chkFirst23.Checked = Conversions.ToBoolean(reader(1))
																															Me.chkTime23.Checked = Conversions.ToBoolean(reader(2))
																															Me.comboHour23.Text = reader(3).ToString()
																															Me.comboMin23.Text = reader(4).ToString()
																															Me.chkCon23.Checked = Conversions.ToBoolean(reader(5))
																															Me.comboSoundCon23.Text = reader(6).ToString()
																															Me.comboSoundConEng23.Text = reader(7).ToString()
																															Me.chkLast23.Checked = Conversions.ToBoolean(reader(8))
																														Else
																															flag2 = Conversions.ToInteger(reader(0)) = 48
																															If flag2 Then
																																Me.chkFirst24.Checked = Conversions.ToBoolean(reader(1))
																																Me.chkTime24.Checked = Conversions.ToBoolean(reader(2))
																																Me.comboHour24.Text = reader(3).ToString()
																																Me.comboMin24.Text = reader(4).ToString()
																																Me.chkCon24.Checked = Conversions.ToBoolean(reader(5))
																																Me.comboSoundCon24.Text = reader(6).ToString()
																																Me.comboSoundConEng24.Text = reader(7).ToString()
																																Me.chkLast24.Checked = Conversions.ToBoolean(reader(8))
																															End If
																														End If
																													End If
																												End If
																											End If
																										End If
																									End If
																								End If
																							End If
																						End If
																					End If
																				End If
																			End If
																		End If
																	End If
																End If
															End If
														End If
													End If
												End If
											End If
										End If
									End If
								End If
							End While
						Else
							flag2 = d = 3
							If flag2 Then
								While reader.Read()
									flag = Conversions.ToInteger(reader(0)) = 49
									If flag Then
										Me.chkFirst1.Checked = Conversions.ToBoolean(reader(1))
										Me.chkTime1.Checked = Conversions.ToBoolean(reader(2))
										Me.comboHour1.Text = reader(3).ToString()
										Me.comboMin1.Text = reader(4).ToString()
										Me.chkCon1.Checked = Conversions.ToBoolean(reader(5))
										Me.comboSoundCon1.Text = reader(6).ToString()
										Me.comboSoundConEng1.Text = reader(7).ToString()
										Me.chkLast1.Checked = Conversions.ToBoolean(reader(8))
									Else
										flag2 = Conversions.ToInteger(reader(0)) = 50
										If flag2 Then
											Me.chkFirst2.Checked = Conversions.ToBoolean(reader(1))
											Me.chkTime2.Checked = Conversions.ToBoolean(reader(2))
											Me.comboHour2.Text = reader(3).ToString()
											Me.comboMin2.Text = reader(4).ToString()
											Me.chkCon2.Checked = Conversions.ToBoolean(reader(5))
											Me.comboSoundCon2.Text = reader(6).ToString()
											Me.comboSoundConEng2.Text = reader(7).ToString()
											Me.chkLast2.Checked = Conversions.ToBoolean(reader(8))
										Else
											flag2 = Conversions.ToInteger(reader(0)) = 51
											If flag2 Then
												Me.chkFirst3.Checked = Conversions.ToBoolean(reader(1))
												Me.chkTime3.Checked = Conversions.ToBoolean(reader(2))
												Me.comboHour3.Text = reader(3).ToString()
												Me.comboMin3.Text = reader(4).ToString()
												Me.chkCon3.Checked = Conversions.ToBoolean(reader(5))
												Me.comboSoundCon3.Text = reader(6).ToString()
												Me.comboSoundConEng3.Text = reader(7).ToString()
												Me.chkLast3.Checked = Conversions.ToBoolean(reader(8))
											Else
												flag2 = Conversions.ToInteger(reader(0)) = 52
												If flag2 Then
													Me.chkFirst4.Checked = Conversions.ToBoolean(reader(1))
													Me.chkTime4.Checked = Conversions.ToBoolean(reader(2))
													Me.comboHour4.Text = reader(3).ToString()
													Me.comboMin4.Text = reader(4).ToString()
													Me.chkCon4.Checked = Conversions.ToBoolean(reader(5))
													Me.comboSoundCon4.Text = reader(6).ToString()
													Me.comboSoundConEng4.Text = reader(7).ToString()
													Me.chkLast4.Checked = Conversions.ToBoolean(reader(8))
												Else
													flag2 = Conversions.ToInteger(reader(0)) = 53
													If flag2 Then
														Me.chkFirst5.Checked = Conversions.ToBoolean(reader(1))
														Me.chkTime5.Checked = Conversions.ToBoolean(reader(2))
														Me.comboHour5.Text = reader(3).ToString()
														Me.comboMin5.Text = reader(4).ToString()
														Me.chkCon5.Checked = Conversions.ToBoolean(reader(5))
														Me.comboSoundCon5.Text = reader(6).ToString()
														Me.comboSoundConEng5.Text = reader(7).ToString()
														Me.chkLast5.Checked = Conversions.ToBoolean(reader(8))
													Else
														flag2 = Conversions.ToInteger(reader(0)) = 54
														If flag2 Then
															Me.chkFirst6.Checked = Conversions.ToBoolean(reader(1))
															Me.chkTime6.Checked = Conversions.ToBoolean(reader(2))
															Me.comboHour6.Text = reader(3).ToString()
															Me.comboMin6.Text = reader(4).ToString()
															Me.chkCon6.Checked = Conversions.ToBoolean(reader(5))
															Me.comboSoundCon6.Text = reader(6).ToString()
															Me.comboSoundConEng6.Text = reader(7).ToString()
															Me.chkLast6.Checked = Conversions.ToBoolean(reader(8))
														Else
															flag2 = Conversions.ToInteger(reader(0)) = 55
															If flag2 Then
																Me.chkFirst7.Checked = Conversions.ToBoolean(reader(1))
																Me.chkTime7.Checked = Conversions.ToBoolean(reader(2))
																Me.comboHour7.Text = reader(3).ToString()
																Me.comboMin7.Text = reader(4).ToString()
																Me.chkCon7.Checked = Conversions.ToBoolean(reader(5))
																Me.comboSoundCon7.Text = reader(6).ToString()
																Me.comboSoundConEng7.Text = reader(7).ToString()
																Me.chkLast7.Checked = Conversions.ToBoolean(reader(8))
															Else
																flag2 = Conversions.ToInteger(reader(0)) = 56
																If flag2 Then
																	Me.chkFirst8.Checked = Conversions.ToBoolean(reader(1))
																	Me.chkTime8.Checked = Conversions.ToBoolean(reader(2))
																	Me.comboHour8.Text = reader(3).ToString()
																	Me.comboMin8.Text = reader(4).ToString()
																	Me.chkCon8.Checked = Conversions.ToBoolean(reader(5))
																	Me.comboSoundCon8.Text = reader(6).ToString()
																	Me.comboSoundConEng8.Text = reader(7).ToString()
																	Me.chkLast8.Checked = Conversions.ToBoolean(reader(8))
																Else
																	flag2 = Conversions.ToInteger(reader(0)) = 57
																	If flag2 Then
																		Me.chkFirst9.Checked = Conversions.ToBoolean(reader(1))
																		Me.chkTime9.Checked = Conversions.ToBoolean(reader(2))
																		Me.comboHour9.Text = reader(3).ToString()
																		Me.comboMin9.Text = reader(4).ToString()
																		Me.chkCon9.Checked = Conversions.ToBoolean(reader(5))
																		Me.comboSoundCon9.Text = reader(6).ToString()
																		Me.comboSoundConEng9.Text = reader(7).ToString()
																		Me.chkLast9.Checked = Conversions.ToBoolean(reader(8))
																	Else
																		flag2 = Conversions.ToInteger(reader(0)) = 58
																		If flag2 Then
																			Me.chkFirst10.Checked = Conversions.ToBoolean(reader(1))
																			Me.chkTime10.Checked = Conversions.ToBoolean(reader(2))
																			Me.comboHour10.Text = reader(3).ToString()
																			Me.comboMin10.Text = reader(4).ToString()
																			Me.chkCon10.Checked = Conversions.ToBoolean(reader(5))
																			Me.comboSoundCon10.Text = reader(6).ToString()
																			Me.comboSoundConEng10.Text = reader(7).ToString()
																			Me.chkLast10.Checked = Conversions.ToBoolean(reader(8))
																		Else
																			flag2 = Conversions.ToInteger(reader(0)) = 59
																			If flag2 Then
																				Me.chkFirst11.Checked = Conversions.ToBoolean(reader(1))
																				Me.chkTime11.Checked = Conversions.ToBoolean(reader(2))
																				Me.comboHour11.Text = reader(3).ToString()
																				Me.comboMin11.Text = reader(4).ToString()
																				Me.chkCon11.Checked = Conversions.ToBoolean(reader(5))
																				Me.comboSoundCon11.Text = reader(6).ToString()
																				Me.comboSoundConEng11.Text = reader(7).ToString()
																				Me.chkLast11.Checked = Conversions.ToBoolean(reader(8))
																			Else
																				flag2 = Conversions.ToInteger(reader(0)) = 60
																				If flag2 Then
																					Me.chkFirst12.Checked = Conversions.ToBoolean(reader(1))
																					Me.chkTime12.Checked = Conversions.ToBoolean(reader(2))
																					Me.comboHour12.Text = reader(3).ToString()
																					Me.comboMin12.Text = reader(4).ToString()
																					Me.chkCon12.Checked = Conversions.ToBoolean(reader(5))
																					Me.comboSoundCon12.Text = reader(6).ToString()
																					Me.comboSoundConEng12.Text = reader(7).ToString()
																					Me.chkLast12.Checked = Conversions.ToBoolean(reader(8))
																				Else
																					flag2 = Conversions.ToInteger(reader(0)) = 61
																					If flag2 Then
																						Me.chkFirst13.Checked = Conversions.ToBoolean(reader(1))
																						Me.chkTime13.Checked = Conversions.ToBoolean(reader(2))
																						Me.comboHour13.Text = reader(3).ToString()
																						Me.comboMin13.Text = reader(4).ToString()
																						Me.chkCon13.Checked = Conversions.ToBoolean(reader(5))
																						Me.comboSoundCon13.Text = reader(6).ToString()
																						Me.comboSoundConEng13.Text = reader(7).ToString()
																						Me.chkLast13.Checked = Conversions.ToBoolean(reader(8))
																					Else
																						flag2 = Conversions.ToInteger(reader(0)) = 62
																						If flag2 Then
																							Me.chkFirst14.Checked = Conversions.ToBoolean(reader(1))
																							Me.chkTime14.Checked = Conversions.ToBoolean(reader(2))
																							Me.comboHour14.Text = reader(3).ToString()
																							Me.comboMin14.Text = reader(4).ToString()
																							Me.chkCon14.Checked = Conversions.ToBoolean(reader(5))
																							Me.comboSoundCon14.Text = reader(6).ToString()
																							Me.comboSoundConEng14.Text = reader(7).ToString()
																							Me.chkLast14.Checked = Conversions.ToBoolean(reader(8))
																						Else
																							flag2 = Conversions.ToInteger(reader(0)) = 63
																							If flag2 Then
																								Me.chkFirst15.Checked = Conversions.ToBoolean(reader(1))
																								Me.chkTime15.Checked = Conversions.ToBoolean(reader(2))
																								Me.comboHour15.Text = reader(3).ToString()
																								Me.comboMin15.Text = reader(4).ToString()
																								Me.chkCon15.Checked = Conversions.ToBoolean(reader(5))
																								Me.comboSoundCon15.Text = reader(6).ToString()
																								Me.comboSoundConEng15.Text = reader(7).ToString()
																								Me.chkLast15.Checked = Conversions.ToBoolean(reader(8))
																							Else
																								flag2 = Conversions.ToInteger(reader(0)) = 64
																								If flag2 Then
																									Me.chkFirst16.Checked = Conversions.ToBoolean(reader(1))
																									Me.chkTime16.Checked = Conversions.ToBoolean(reader(2))
																									Me.comboHour16.Text = reader(3).ToString()
																									Me.comboMin16.Text = reader(4).ToString()
																									Me.chkCon16.Checked = Conversions.ToBoolean(reader(5))
																									Me.comboSoundCon16.Text = reader(6).ToString()
																									Me.comboSoundConEng16.Text = reader(7).ToString()
																									Me.chkLast16.Checked = Conversions.ToBoolean(reader(8))
																								Else
																									flag2 = Conversions.ToInteger(reader(0)) = 65
																									If flag2 Then
																										Me.chkFirst17.Checked = Conversions.ToBoolean(reader(1))
																										Me.chkTime17.Checked = Conversions.ToBoolean(reader(2))
																										Me.comboHour17.Text = reader(3).ToString()
																										Me.comboMin17.Text = reader(4).ToString()
																										Me.chkCon17.Checked = Conversions.ToBoolean(reader(5))
																										Me.comboSoundCon17.Text = reader(6).ToString()
																										Me.comboSoundConEng17.Text = reader(7).ToString()
																										Me.chkLast17.Checked = Conversions.ToBoolean(reader(8))
																									Else
																										flag2 = Conversions.ToInteger(reader(0)) = 66
																										If flag2 Then
																											Me.chkFirst18.Checked = Conversions.ToBoolean(reader(1))
																											Me.chkTime18.Checked = Conversions.ToBoolean(reader(2))
																											Me.comboHour18.Text = reader(3).ToString()
																											Me.comboMin18.Text = reader(4).ToString()
																											Me.chkCon18.Checked = Conversions.ToBoolean(reader(5))
																											Me.comboSoundCon18.Text = reader(6).ToString()
																											Me.comboSoundConEng18.Text = reader(7).ToString()
																											Me.chkLast18.Checked = Conversions.ToBoolean(reader(8))
																										Else
																											flag2 = Conversions.ToInteger(reader(0)) = 67
																											If flag2 Then
																												Me.chkFirst19.Checked = Conversions.ToBoolean(reader(1))
																												Me.chkTime19.Checked = Conversions.ToBoolean(reader(2))
																												Me.comboHour19.Text = reader(3).ToString()
																												Me.comboMin19.Text = reader(4).ToString()
																												Me.chkCon19.Checked = Conversions.ToBoolean(reader(5))
																												Me.comboSoundCon19.Text = reader(6).ToString()
																												Me.comboSoundConEng19.Text = reader(7).ToString()
																												Me.chkLast19.Checked = Conversions.ToBoolean(reader(8))
																											Else
																												flag2 = Conversions.ToInteger(reader(0)) = 68
																												If flag2 Then
																													Me.chkFirst20.Checked = Conversions.ToBoolean(reader(1))
																													Me.chkTime20.Checked = Conversions.ToBoolean(reader(2))
																													Me.comboHour20.Text = reader(3).ToString()
																													Me.comboMin20.Text = reader(4).ToString()
																													Me.chkCon20.Checked = Conversions.ToBoolean(reader(5))
																													Me.comboSoundCon20.Text = reader(6).ToString()
																													Me.comboSoundConEng20.Text = reader(7).ToString()
																													Me.chkLast20.Checked = Conversions.ToBoolean(reader(8))
																												Else
																													flag2 = Conversions.ToInteger(reader(0)) = 69
																													If flag2 Then
																														Me.chkFirst21.Checked = Conversions.ToBoolean(reader(1))
																														Me.chkTime21.Checked = Conversions.ToBoolean(reader(2))
																														Me.comboHour21.Text = reader(3).ToString()
																														Me.comboMin21.Text = reader(4).ToString()
																														Me.chkCon21.Checked = Conversions.ToBoolean(reader(5))
																														Me.comboSoundCon21.Text = reader(6).ToString()
																														Me.comboSoundConEng21.Text = reader(7).ToString()
																														Me.chkLast21.Checked = Conversions.ToBoolean(reader(8))
																													Else
																														flag2 = Conversions.ToInteger(reader(0)) = 70
																														If flag2 Then
																															Me.chkFirst22.Checked = Conversions.ToBoolean(reader(1))
																															Me.chkTime22.Checked = Conversions.ToBoolean(reader(2))
																															Me.comboHour22.Text = reader(3).ToString()
																															Me.comboMin22.Text = reader(4).ToString()
																															Me.chkCon22.Checked = Conversions.ToBoolean(reader(5))
																															Me.comboSoundCon22.Text = reader(6).ToString()
																															Me.comboSoundConEng22.Text = reader(7).ToString()
																															Me.chkLast22.Checked = Conversions.ToBoolean(reader(8))
																														Else
																															flag2 = Conversions.ToInteger(reader(0)) = 71
																															If flag2 Then
																																Me.chkFirst23.Checked = Conversions.ToBoolean(reader(1))
																																Me.chkTime23.Checked = Conversions.ToBoolean(reader(2))
																																Me.comboHour23.Text = reader(3).ToString()
																																Me.comboMin23.Text = reader(4).ToString()
																																Me.chkCon23.Checked = Conversions.ToBoolean(reader(5))
																																Me.comboSoundCon23.Text = reader(6).ToString()
																																Me.comboSoundConEng23.Text = reader(7).ToString()
																																Me.chkLast23.Checked = Conversions.ToBoolean(reader(8))
																															Else
																																flag2 = Conversions.ToInteger(reader(0)) = 72
																																If flag2 Then
																																	Me.chkFirst24.Checked = Conversions.ToBoolean(reader(1))
																																	Me.chkTime24.Checked = Conversions.ToBoolean(reader(2))
																																	Me.comboHour24.Text = reader(3).ToString()
																																	Me.comboMin24.Text = reader(4).ToString()
																																	Me.chkCon24.Checked = Conversions.ToBoolean(reader(5))
																																	Me.comboSoundCon24.Text = reader(6).ToString()
																																	Me.comboSoundConEng24.Text = reader(7).ToString()
																																	Me.chkLast24.Checked = Conversions.ToBoolean(reader(8))
																																End If
																															End If
																														End If
																													End If
																												End If
																											End If
																										End If
																									End If
																								End If
																							End If
																						End If
																					End If
																				End If
																			End If
																		End If
																	End If
																End If
															End If
														End If
													End If
												End If
											End If
										End If
									End If
								End While
							Else
								flag2 = d = 4
								If flag2 Then
									While reader.Read()
										flag = Conversions.ToInteger(reader(0)) = 73
										If flag Then
											Me.chkFirst1.Checked = Conversions.ToBoolean(reader(1))
											Me.chkTime1.Checked = Conversions.ToBoolean(reader(2))
											Me.comboHour1.Text = reader(3).ToString()
											Me.comboMin1.Text = reader(4).ToString()
											Me.chkCon1.Checked = Conversions.ToBoolean(reader(5))
											Me.comboSoundCon1.Text = reader(6).ToString()
											Me.comboSoundConEng1.Text = reader(7).ToString()
											Me.chkLast1.Checked = Conversions.ToBoolean(reader(8))
										Else
											flag2 = Conversions.ToInteger(reader(0)) = 74
											If flag2 Then
												Me.chkFirst2.Checked = Conversions.ToBoolean(reader(1))
												Me.chkTime2.Checked = Conversions.ToBoolean(reader(2))
												Me.comboHour2.Text = reader(3).ToString()
												Me.comboMin2.Text = reader(4).ToString()
												Me.chkCon2.Checked = Conversions.ToBoolean(reader(5))
												Me.comboSoundCon2.Text = reader(6).ToString()
												Me.comboSoundConEng2.Text = reader(7).ToString()
												Me.chkLast2.Checked = Conversions.ToBoolean(reader(8))
											Else
												flag2 = Conversions.ToInteger(reader(0)) = 75
												If flag2 Then
													Me.chkFirst3.Checked = Conversions.ToBoolean(reader(1))
													Me.chkTime3.Checked = Conversions.ToBoolean(reader(2))
													Me.comboHour3.Text = reader(3).ToString()
													Me.comboMin3.Text = reader(4).ToString()
													Me.chkCon3.Checked = Conversions.ToBoolean(reader(5))
													Me.comboSoundCon3.Text = reader(6).ToString()
													Me.comboSoundConEng3.Text = reader(7).ToString()
													Me.chkLast3.Checked = Conversions.ToBoolean(reader(8))
												Else
													flag2 = Conversions.ToInteger(reader(0)) = 76
													If flag2 Then
														Me.chkFirst4.Checked = Conversions.ToBoolean(reader(1))
														Me.chkTime4.Checked = Conversions.ToBoolean(reader(2))
														Me.comboHour4.Text = reader(3).ToString()
														Me.comboMin4.Text = reader(4).ToString()
														Me.chkCon4.Checked = Conversions.ToBoolean(reader(5))
														Me.comboSoundCon4.Text = reader(6).ToString()
														Me.comboSoundConEng4.Text = reader(7).ToString()
														Me.chkLast4.Checked = Conversions.ToBoolean(reader(8))
													Else
														flag2 = Conversions.ToInteger(reader(0)) = 77
														If flag2 Then
															Me.chkFirst5.Checked = Conversions.ToBoolean(reader(1))
															Me.chkTime5.Checked = Conversions.ToBoolean(reader(2))
															Me.comboHour5.Text = reader(3).ToString()
															Me.comboMin5.Text = reader(4).ToString()
															Me.chkCon5.Checked = Conversions.ToBoolean(reader(5))
															Me.comboSoundCon5.Text = reader(6).ToString()
															Me.comboSoundConEng5.Text = reader(7).ToString()
															Me.chkLast5.Checked = Conversions.ToBoolean(reader(8))
														Else
															flag2 = Conversions.ToInteger(reader(0)) = 78
															If flag2 Then
																Me.chkFirst6.Checked = Conversions.ToBoolean(reader(1))
																Me.chkTime6.Checked = Conversions.ToBoolean(reader(2))
																Me.comboHour6.Text = reader(3).ToString()
																Me.comboMin6.Text = reader(4).ToString()
																Me.chkCon6.Checked = Conversions.ToBoolean(reader(5))
																Me.comboSoundCon6.Text = reader(6).ToString()
																Me.comboSoundConEng6.Text = reader(7).ToString()
																Me.chkLast6.Checked = Conversions.ToBoolean(reader(8))
															Else
																flag2 = Conversions.ToInteger(reader(0)) = 79
																If flag2 Then
																	Me.chkFirst7.Checked = Conversions.ToBoolean(reader(1))
																	Me.chkTime7.Checked = Conversions.ToBoolean(reader(2))
																	Me.comboHour7.Text = reader(3).ToString()
																	Me.comboMin7.Text = reader(4).ToString()
																	Me.chkCon7.Checked = Conversions.ToBoolean(reader(5))
																	Me.comboSoundCon7.Text = reader(6).ToString()
																	Me.comboSoundConEng7.Text = reader(7).ToString()
																	Me.chkLast7.Checked = Conversions.ToBoolean(reader(8))
																Else
																	flag2 = Conversions.ToInteger(reader(0)) = 80
																	If flag2 Then
																		Me.chkFirst8.Checked = Conversions.ToBoolean(reader(1))
																		Me.chkTime8.Checked = Conversions.ToBoolean(reader(2))
																		Me.comboHour8.Text = reader(3).ToString()
																		Me.comboMin8.Text = reader(4).ToString()
																		Me.chkCon8.Checked = Conversions.ToBoolean(reader(5))
																		Me.comboSoundCon8.Text = reader(6).ToString()
																		Me.comboSoundConEng8.Text = reader(7).ToString()
																		Me.chkLast8.Checked = Conversions.ToBoolean(reader(8))
																	Else
																		flag2 = Conversions.ToInteger(reader(0)) = 81
																		If flag2 Then
																			Me.chkFirst9.Checked = Conversions.ToBoolean(reader(1))
																			Me.chkTime9.Checked = Conversions.ToBoolean(reader(2))
																			Me.comboHour9.Text = reader(3).ToString()
																			Me.comboMin9.Text = reader(4).ToString()
																			Me.chkCon9.Checked = Conversions.ToBoolean(reader(5))
																			Me.comboSoundCon9.Text = reader(6).ToString()
																			Me.comboSoundConEng9.Text = reader(7).ToString()
																			Me.chkLast9.Checked = Conversions.ToBoolean(reader(8))
																		Else
																			flag2 = Conversions.ToInteger(reader(0)) = 82
																			If flag2 Then
																				Me.chkFirst10.Checked = Conversions.ToBoolean(reader(1))
																				Me.chkTime10.Checked = Conversions.ToBoolean(reader(2))
																				Me.comboHour10.Text = reader(3).ToString()
																				Me.comboMin10.Text = reader(4).ToString()
																				Me.chkCon10.Checked = Conversions.ToBoolean(reader(5))
																				Me.comboSoundCon10.Text = reader(6).ToString()
																				Me.comboSoundConEng10.Text = reader(7).ToString()
																				Me.chkLast10.Checked = Conversions.ToBoolean(reader(8))
																			Else
																				flag2 = Conversions.ToInteger(reader(0)) = 83
																				If flag2 Then
																					Me.chkFirst11.Checked = Conversions.ToBoolean(reader(1))
																					Me.chkTime11.Checked = Conversions.ToBoolean(reader(2))
																					Me.comboHour11.Text = reader(3).ToString()
																					Me.comboMin11.Text = reader(4).ToString()
																					Me.chkCon11.Checked = Conversions.ToBoolean(reader(5))
																					Me.comboSoundCon11.Text = reader(6).ToString()
																					Me.comboSoundConEng11.Text = reader(7).ToString()
																					Me.chkLast11.Checked = Conversions.ToBoolean(reader(8))
																				Else
																					flag2 = Conversions.ToInteger(reader(0)) = 84
																					If flag2 Then
																						Me.chkFirst12.Checked = Conversions.ToBoolean(reader(1))
																						Me.chkTime12.Checked = Conversions.ToBoolean(reader(2))
																						Me.comboHour12.Text = reader(3).ToString()
																						Me.comboMin12.Text = reader(4).ToString()
																						Me.chkCon12.Checked = Conversions.ToBoolean(reader(5))
																						Me.comboSoundCon12.Text = reader(6).ToString()
																						Me.comboSoundConEng12.Text = reader(7).ToString()
																						Me.chkLast12.Checked = Conversions.ToBoolean(reader(8))
																					Else
																						flag2 = Conversions.ToInteger(reader(0)) = 85
																						If flag2 Then
																							Me.chkFirst13.Checked = Conversions.ToBoolean(reader(1))
																							Me.chkTime13.Checked = Conversions.ToBoolean(reader(2))
																							Me.comboHour13.Text = reader(3).ToString()
																							Me.comboMin13.Text = reader(4).ToString()
																							Me.chkCon13.Checked = Conversions.ToBoolean(reader(5))
																							Me.comboSoundCon13.Text = reader(6).ToString()
																							Me.comboSoundConEng13.Text = reader(7).ToString()
																							Me.chkLast13.Checked = Conversions.ToBoolean(reader(8))
																						Else
																							flag2 = Conversions.ToInteger(reader(0)) = 86
																							If flag2 Then
																								Me.chkFirst14.Checked = Conversions.ToBoolean(reader(1))
																								Me.chkTime14.Checked = Conversions.ToBoolean(reader(2))
																								Me.comboHour14.Text = reader(3).ToString()
																								Me.comboMin14.Text = reader(4).ToString()
																								Me.chkCon14.Checked = Conversions.ToBoolean(reader(5))
																								Me.comboSoundCon14.Text = reader(6).ToString()
																								Me.comboSoundConEng14.Text = reader(7).ToString()
																								Me.chkLast14.Checked = Conversions.ToBoolean(reader(8))
																							Else
																								flag2 = Conversions.ToInteger(reader(0)) = 87
																								If flag2 Then
																									Me.chkFirst15.Checked = Conversions.ToBoolean(reader(1))
																									Me.chkTime15.Checked = Conversions.ToBoolean(reader(2))
																									Me.comboHour15.Text = reader(3).ToString()
																									Me.comboMin15.Text = reader(4).ToString()
																									Me.chkCon15.Checked = Conversions.ToBoolean(reader(5))
																									Me.comboSoundCon15.Text = reader(6).ToString()
																									Me.comboSoundConEng15.Text = reader(7).ToString()
																									Me.chkLast15.Checked = Conversions.ToBoolean(reader(8))
																								Else
																									flag2 = Conversions.ToInteger(reader(0)) = 88
																									If flag2 Then
																										Me.chkFirst16.Checked = Conversions.ToBoolean(reader(1))
																										Me.chkTime16.Checked = Conversions.ToBoolean(reader(2))
																										Me.comboHour16.Text = reader(3).ToString()
																										Me.comboMin16.Text = reader(4).ToString()
																										Me.chkCon16.Checked = Conversions.ToBoolean(reader(5))
																										Me.comboSoundCon16.Text = reader(6).ToString()
																										Me.comboSoundConEng16.Text = reader(7).ToString()
																										Me.chkLast16.Checked = Conversions.ToBoolean(reader(8))
																									Else
																										flag2 = Conversions.ToInteger(reader(0)) = 89
																										If flag2 Then
																											Me.chkFirst17.Checked = Conversions.ToBoolean(reader(1))
																											Me.chkTime17.Checked = Conversions.ToBoolean(reader(2))
																											Me.comboHour17.Text = reader(3).ToString()
																											Me.comboMin17.Text = reader(4).ToString()
																											Me.chkCon17.Checked = Conversions.ToBoolean(reader(5))
																											Me.comboSoundCon17.Text = reader(6).ToString()
																											Me.comboSoundConEng17.Text = reader(7).ToString()
																											Me.chkLast17.Checked = Conversions.ToBoolean(reader(8))
																										Else
																											flag2 = Conversions.ToInteger(reader(0)) = 90
																											If flag2 Then
																												Me.chkFirst18.Checked = Conversions.ToBoolean(reader(1))
																												Me.chkTime18.Checked = Conversions.ToBoolean(reader(2))
																												Me.comboHour18.Text = reader(3).ToString()
																												Me.comboMin18.Text = reader(4).ToString()
																												Me.chkCon18.Checked = Conversions.ToBoolean(reader(5))
																												Me.comboSoundCon18.Text = reader(6).ToString()
																												Me.comboSoundConEng18.Text = reader(7).ToString()
																												Me.chkLast18.Checked = Conversions.ToBoolean(reader(8))
																											Else
																												flag2 = Conversions.ToInteger(reader(0)) = 91
																												If flag2 Then
																													Me.chkFirst19.Checked = Conversions.ToBoolean(reader(1))
																													Me.chkTime19.Checked = Conversions.ToBoolean(reader(2))
																													Me.comboHour19.Text = reader(3).ToString()
																													Me.comboMin19.Text = reader(4).ToString()
																													Me.chkCon19.Checked = Conversions.ToBoolean(reader(5))
																													Me.comboSoundCon19.Text = reader(6).ToString()
																													Me.comboSoundConEng19.Text = reader(7).ToString()
																													Me.chkLast19.Checked = Conversions.ToBoolean(reader(8))
																												Else
																													flag2 = Conversions.ToInteger(reader(0)) = 92
																													If flag2 Then
																														Me.chkFirst20.Checked = Conversions.ToBoolean(reader(1))
																														Me.chkTime20.Checked = Conversions.ToBoolean(reader(2))
																														Me.comboHour20.Text = reader(3).ToString()
																														Me.comboMin20.Text = reader(4).ToString()
																														Me.chkCon20.Checked = Conversions.ToBoolean(reader(5))
																														Me.comboSoundCon20.Text = reader(6).ToString()
																														Me.comboSoundConEng20.Text = reader(7).ToString()
																														Me.chkLast20.Checked = Conversions.ToBoolean(reader(8))
																													Else
																														flag2 = Conversions.ToInteger(reader(0)) = 93
																														If flag2 Then
																															Me.chkFirst21.Checked = Conversions.ToBoolean(reader(1))
																															Me.chkTime21.Checked = Conversions.ToBoolean(reader(2))
																															Me.comboHour21.Text = reader(3).ToString()
																															Me.comboMin21.Text = reader(4).ToString()
																															Me.chkCon21.Checked = Conversions.ToBoolean(reader(5))
																															Me.comboSoundCon21.Text = reader(6).ToString()
																															Me.comboSoundConEng21.Text = reader(7).ToString()
																															Me.chkLast21.Checked = Conversions.ToBoolean(reader(8))
																														Else
																															flag2 = Conversions.ToInteger(reader(0)) = 94
																															If flag2 Then
																																Me.chkFirst22.Checked = Conversions.ToBoolean(reader(1))
																																Me.chkTime22.Checked = Conversions.ToBoolean(reader(2))
																																Me.comboHour22.Text = reader(3).ToString()
																																Me.comboMin22.Text = reader(4).ToString()
																																Me.chkCon22.Checked = Conversions.ToBoolean(reader(5))
																																Me.comboSoundCon22.Text = reader(6).ToString()
																																Me.comboSoundConEng22.Text = reader(7).ToString()
																																Me.chkLast22.Checked = Conversions.ToBoolean(reader(8))
																															Else
																																flag2 = Conversions.ToInteger(reader(0)) = 95
																																If flag2 Then
																																	Me.chkFirst23.Checked = Conversions.ToBoolean(reader(1))
																																	Me.chkTime23.Checked = Conversions.ToBoolean(reader(2))
																																	Me.comboHour23.Text = reader(3).ToString()
																																	Me.comboMin23.Text = reader(4).ToString()
																																	Me.chkCon23.Checked = Conversions.ToBoolean(reader(5))
																																	Me.comboSoundCon23.Text = reader(6).ToString()
																																	Me.comboSoundConEng23.Text = reader(7).ToString()
																																	Me.chkLast23.Checked = Conversions.ToBoolean(reader(8))
																																Else
																																	flag2 = Conversions.ToInteger(reader(0)) = 96
																																	If flag2 Then
																																		Me.chkFirst24.Checked = Conversions.ToBoolean(reader(1))
																																		Me.chkTime24.Checked = Conversions.ToBoolean(reader(2))
																																		Me.comboHour24.Text = reader(3).ToString()
																																		Me.comboMin24.Text = reader(4).ToString()
																																		Me.chkCon24.Checked = Conversions.ToBoolean(reader(5))
																																		Me.comboSoundCon24.Text = reader(6).ToString()
																																		Me.comboSoundConEng24.Text = reader(7).ToString()
																																		Me.chkLast24.Checked = Conversions.ToBoolean(reader(8))
																																	End If
																																End If
																															End If
																														End If
																													End If
																												End If
																											End If
																										End If
																									End If
																								End If
																							End If
																						End If
																					End If
																				End If
																			End If
																		End If
																	End If
																End If
															End If
														End If
													End If
												End If
											End If
										End If
									End While
								Else
									flag2 = d = 5
									If flag2 Then
										While reader.Read()
											flag = Conversions.ToInteger(reader(0)) = 97
											If flag Then
												Me.chkFirst1.Checked = Conversions.ToBoolean(reader(1))
												Me.chkTime1.Checked = Conversions.ToBoolean(reader(2))
												Me.comboHour1.Text = reader(3).ToString()
												Me.comboMin1.Text = reader(4).ToString()
												Me.chkCon1.Checked = Conversions.ToBoolean(reader(5))
												Me.comboSoundCon1.Text = reader(6).ToString()
												Me.comboSoundConEng1.Text = reader(7).ToString()
												Me.chkLast1.Checked = Conversions.ToBoolean(reader(8))
											Else
												flag2 = Conversions.ToInteger(reader(0)) = 98
												If flag2 Then
													Me.chkFirst2.Checked = Conversions.ToBoolean(reader(1))
													Me.chkTime2.Checked = Conversions.ToBoolean(reader(2))
													Me.comboHour2.Text = reader(3).ToString()
													Me.comboMin2.Text = reader(4).ToString()
													Me.chkCon2.Checked = Conversions.ToBoolean(reader(5))
													Me.comboSoundCon2.Text = reader(6).ToString()
													Me.comboSoundConEng2.Text = reader(7).ToString()
													Me.chkLast2.Checked = Conversions.ToBoolean(reader(8))
												Else
													flag2 = Conversions.ToInteger(reader(0)) = 99
													If flag2 Then
														Me.chkFirst3.Checked = Conversions.ToBoolean(reader(1))
														Me.chkTime3.Checked = Conversions.ToBoolean(reader(2))
														Me.comboHour3.Text = reader(3).ToString()
														Me.comboMin3.Text = reader(4).ToString()
														Me.chkCon3.Checked = Conversions.ToBoolean(reader(5))
														Me.comboSoundCon3.Text = reader(6).ToString()
														Me.comboSoundConEng3.Text = reader(7).ToString()
														Me.chkLast3.Checked = Conversions.ToBoolean(reader(8))
													Else
														flag2 = Conversions.ToInteger(reader(0)) = 100
														If flag2 Then
															Me.chkFirst4.Checked = Conversions.ToBoolean(reader(1))
															Me.chkTime4.Checked = Conversions.ToBoolean(reader(2))
															Me.comboHour4.Text = reader(3).ToString()
															Me.comboMin4.Text = reader(4).ToString()
															Me.chkCon4.Checked = Conversions.ToBoolean(reader(5))
															Me.comboSoundCon4.Text = reader(6).ToString()
															Me.comboSoundConEng4.Text = reader(7).ToString()
															Me.chkLast4.Checked = Conversions.ToBoolean(reader(8))
														Else
															flag2 = Conversions.ToInteger(reader(0)) = 101
															If flag2 Then
																Me.chkFirst5.Checked = Conversions.ToBoolean(reader(1))
																Me.chkTime5.Checked = Conversions.ToBoolean(reader(2))
																Me.comboHour5.Text = reader(3).ToString()
																Me.comboMin5.Text = reader(4).ToString()
																Me.chkCon5.Checked = Conversions.ToBoolean(reader(5))
																Me.comboSoundCon5.Text = reader(6).ToString()
																Me.comboSoundConEng5.Text = reader(7).ToString()
																Me.chkLast5.Checked = Conversions.ToBoolean(reader(8))
															Else
																flag2 = Conversions.ToInteger(reader(0)) = 102
																If flag2 Then
																	Me.chkFirst6.Checked = Conversions.ToBoolean(reader(1))
																	Me.chkTime6.Checked = Conversions.ToBoolean(reader(2))
																	Me.comboHour6.Text = reader(3).ToString()
																	Me.comboMin6.Text = reader(4).ToString()
																	Me.chkCon6.Checked = Conversions.ToBoolean(reader(5))
																	Me.comboSoundCon6.Text = reader(6).ToString()
																	Me.comboSoundConEng6.Text = reader(7).ToString()
																	Me.chkLast6.Checked = Conversions.ToBoolean(reader(8))
																Else
																	flag2 = Conversions.ToInteger(reader(0)) = 103
																	If flag2 Then
																		Me.chkFirst7.Checked = Conversions.ToBoolean(reader(1))
																		Me.chkTime7.Checked = Conversions.ToBoolean(reader(2))
																		Me.comboHour7.Text = reader(3).ToString()
																		Me.comboMin7.Text = reader(4).ToString()
																		Me.chkCon7.Checked = Conversions.ToBoolean(reader(5))
																		Me.comboSoundCon7.Text = reader(6).ToString()
																		Me.comboSoundConEng7.Text = reader(7).ToString()
																		Me.chkLast7.Checked = Conversions.ToBoolean(reader(8))
																	Else
																		flag2 = Conversions.ToInteger(reader(0)) = 104
																		If flag2 Then
																			Me.chkFirst8.Checked = Conversions.ToBoolean(reader(1))
																			Me.chkTime8.Checked = Conversions.ToBoolean(reader(2))
																			Me.comboHour8.Text = reader(3).ToString()
																			Me.comboMin8.Text = reader(4).ToString()
																			Me.chkCon8.Checked = Conversions.ToBoolean(reader(5))
																			Me.comboSoundCon8.Text = reader(6).ToString()
																			Me.comboSoundConEng8.Text = reader(7).ToString()
																			Me.chkLast8.Checked = Conversions.ToBoolean(reader(8))
																		Else
																			flag2 = Conversions.ToInteger(reader(0)) = 105
																			If flag2 Then
																				Me.chkFirst9.Checked = Conversions.ToBoolean(reader(1))
																				Me.chkTime9.Checked = Conversions.ToBoolean(reader(2))
																				Me.comboHour9.Text = reader(3).ToString()
																				Me.comboMin9.Text = reader(4).ToString()
																				Me.chkCon9.Checked = Conversions.ToBoolean(reader(5))
																				Me.comboSoundCon9.Text = reader(6).ToString()
																				Me.comboSoundConEng9.Text = reader(7).ToString()
																				Me.chkLast9.Checked = Conversions.ToBoolean(reader(8))
																			Else
																				flag2 = Conversions.ToInteger(reader(0)) = 106
																				If flag2 Then
																					Me.chkFirst10.Checked = Conversions.ToBoolean(reader(1))
																					Me.chkTime10.Checked = Conversions.ToBoolean(reader(2))
																					Me.comboHour10.Text = reader(3).ToString()
																					Me.comboMin10.Text = reader(4).ToString()
																					Me.chkCon10.Checked = Conversions.ToBoolean(reader(5))
																					Me.comboSoundCon10.Text = reader(6).ToString()
																					Me.comboSoundConEng10.Text = reader(7).ToString()
																					Me.chkLast10.Checked = Conversions.ToBoolean(reader(8))
																				Else
																					flag2 = Conversions.ToInteger(reader(0)) = 107
																					If flag2 Then
																						Me.chkFirst11.Checked = Conversions.ToBoolean(reader(1))
																						Me.chkTime11.Checked = Conversions.ToBoolean(reader(2))
																						Me.comboHour11.Text = reader(3).ToString()
																						Me.comboMin11.Text = reader(4).ToString()
																						Me.chkCon11.Checked = Conversions.ToBoolean(reader(5))
																						Me.comboSoundCon11.Text = reader(6).ToString()
																						Me.comboSoundConEng11.Text = reader(7).ToString()
																						Me.chkLast11.Checked = Conversions.ToBoolean(reader(8))
																					Else
																						flag2 = Conversions.ToInteger(reader(0)) = 108
																						If flag2 Then
																							Me.chkFirst12.Checked = Conversions.ToBoolean(reader(1))
																							Me.chkTime12.Checked = Conversions.ToBoolean(reader(2))
																							Me.comboHour12.Text = reader(3).ToString()
																							Me.comboMin12.Text = reader(4).ToString()
																							Me.chkCon12.Checked = Conversions.ToBoolean(reader(5))
																							Me.comboSoundCon12.Text = reader(6).ToString()
																							Me.comboSoundConEng12.Text = reader(7).ToString()
																							Me.chkLast12.Checked = Conversions.ToBoolean(reader(8))
																						Else
																							flag2 = Conversions.ToInteger(reader(0)) = 109
																							If flag2 Then
																								Me.chkFirst13.Checked = Conversions.ToBoolean(reader(1))
																								Me.chkTime13.Checked = Conversions.ToBoolean(reader(2))
																								Me.comboHour13.Text = reader(3).ToString()
																								Me.comboMin13.Text = reader(4).ToString()
																								Me.chkCon13.Checked = Conversions.ToBoolean(reader(5))
																								Me.comboSoundCon13.Text = reader(6).ToString()
																								Me.comboSoundConEng13.Text = reader(7).ToString()
																								Me.chkLast13.Checked = Conversions.ToBoolean(reader(8))
																							Else
																								flag2 = Conversions.ToInteger(reader(0)) = 110
																								If flag2 Then
																									Me.chkFirst14.Checked = Conversions.ToBoolean(reader(1))
																									Me.chkTime14.Checked = Conversions.ToBoolean(reader(2))
																									Me.comboHour14.Text = reader(3).ToString()
																									Me.comboMin14.Text = reader(4).ToString()
																									Me.chkCon14.Checked = Conversions.ToBoolean(reader(5))
																									Me.comboSoundCon14.Text = reader(6).ToString()
																									Me.comboSoundConEng14.Text = reader(7).ToString()
																									Me.chkLast14.Checked = Conversions.ToBoolean(reader(8))
																								Else
																									flag2 = Conversions.ToInteger(reader(0)) = 111
																									If flag2 Then
																										Me.chkFirst15.Checked = Conversions.ToBoolean(reader(1))
																										Me.chkTime15.Checked = Conversions.ToBoolean(reader(2))
																										Me.comboHour15.Text = reader(3).ToString()
																										Me.comboMin15.Text = reader(4).ToString()
																										Me.chkCon15.Checked = Conversions.ToBoolean(reader(5))
																										Me.comboSoundCon15.Text = reader(6).ToString()
																										Me.comboSoundConEng15.Text = reader(7).ToString()
																										Me.chkLast15.Checked = Conversions.ToBoolean(reader(8))
																									Else
																										flag2 = Conversions.ToInteger(reader(0)) = 112
																										If flag2 Then
																											Me.chkFirst16.Checked = Conversions.ToBoolean(reader(1))
																											Me.chkTime16.Checked = Conversions.ToBoolean(reader(2))
																											Me.comboHour16.Text = reader(3).ToString()
																											Me.comboMin16.Text = reader(4).ToString()
																											Me.chkCon16.Checked = Conversions.ToBoolean(reader(5))
																											Me.comboSoundCon16.Text = reader(6).ToString()
																											Me.comboSoundConEng16.Text = reader(7).ToString()
																											Me.chkLast16.Checked = Conversions.ToBoolean(reader(8))
																										Else
																											flag2 = Conversions.ToInteger(reader(0)) = 113
																											If flag2 Then
																												Me.chkFirst17.Checked = Conversions.ToBoolean(reader(1))
																												Me.chkTime17.Checked = Conversions.ToBoolean(reader(2))
																												Me.comboHour17.Text = reader(3).ToString()
																												Me.comboMin17.Text = reader(4).ToString()
																												Me.chkCon17.Checked = Conversions.ToBoolean(reader(5))
																												Me.comboSoundCon17.Text = reader(6).ToString()
																												Me.comboSoundConEng17.Text = reader(7).ToString()
																												Me.chkLast17.Checked = Conversions.ToBoolean(reader(8))
																											Else
																												flag2 = Conversions.ToInteger(reader(0)) = 114
																												If flag2 Then
																													Me.chkFirst18.Checked = Conversions.ToBoolean(reader(1))
																													Me.chkTime18.Checked = Conversions.ToBoolean(reader(2))
																													Me.comboHour18.Text = reader(3).ToString()
																													Me.comboMin18.Text = reader(4).ToString()
																													Me.chkCon18.Checked = Conversions.ToBoolean(reader(5))
																													Me.comboSoundCon18.Text = reader(6).ToString()
																													Me.comboSoundConEng18.Text = reader(7).ToString()
																													Me.chkLast18.Checked = Conversions.ToBoolean(reader(8))
																												Else
																													flag2 = Conversions.ToInteger(reader(0)) = 115
																													If flag2 Then
																														Me.chkFirst19.Checked = Conversions.ToBoolean(reader(1))
																														Me.chkTime19.Checked = Conversions.ToBoolean(reader(2))
																														Me.comboHour19.Text = reader(3).ToString()
																														Me.comboMin19.Text = reader(4).ToString()
																														Me.chkCon19.Checked = Conversions.ToBoolean(reader(5))
																														Me.comboSoundCon19.Text = reader(6).ToString()
																														Me.comboSoundConEng19.Text = reader(7).ToString()
																														Me.chkLast19.Checked = Conversions.ToBoolean(reader(8))
																													Else
																														flag2 = Conversions.ToInteger(reader(0)) = 116
																														If flag2 Then
																															Me.chkFirst20.Checked = Conversions.ToBoolean(reader(1))
																															Me.chkTime20.Checked = Conversions.ToBoolean(reader(2))
																															Me.comboHour20.Text = reader(3).ToString()
																															Me.comboMin20.Text = reader(4).ToString()
																															Me.chkCon20.Checked = Conversions.ToBoolean(reader(5))
																															Me.comboSoundCon20.Text = reader(6).ToString()
																															Me.comboSoundConEng20.Text = reader(7).ToString()
																															Me.chkLast20.Checked = Conversions.ToBoolean(reader(8))
																														Else
																															flag2 = Conversions.ToInteger(reader(0)) = 117
																															If flag2 Then
																																Me.chkFirst21.Checked = Conversions.ToBoolean(reader(1))
																																Me.chkTime21.Checked = Conversions.ToBoolean(reader(2))
																																Me.comboHour21.Text = reader(3).ToString()
																																Me.comboMin21.Text = reader(4).ToString()
																																Me.chkCon21.Checked = Conversions.ToBoolean(reader(5))
																																Me.comboSoundCon21.Text = reader(6).ToString()
																																Me.comboSoundConEng21.Text = reader(7).ToString()
																																Me.chkLast21.Checked = Conversions.ToBoolean(reader(8))
																															Else
																																flag2 = Conversions.ToInteger(reader(0)) = 118
																																If flag2 Then
																																	Me.chkFirst22.Checked = Conversions.ToBoolean(reader(1))
																																	Me.chkTime22.Checked = Conversions.ToBoolean(reader(2))
																																	Me.comboHour22.Text = reader(3).ToString()
																																	Me.comboMin22.Text = reader(4).ToString()
																																	Me.chkCon22.Checked = Conversions.ToBoolean(reader(5))
																																	Me.comboSoundCon22.Text = reader(6).ToString()
																																	Me.comboSoundConEng22.Text = reader(7).ToString()
																																	Me.chkLast22.Checked = Conversions.ToBoolean(reader(8))
																																Else
																																	flag2 = Conversions.ToInteger(reader(0)) = 119
																																	If flag2 Then
																																		Me.chkFirst23.Checked = Conversions.ToBoolean(reader(1))
																																		Me.chkTime23.Checked = Conversions.ToBoolean(reader(2))
																																		Me.comboHour23.Text = reader(3).ToString()
																																		Me.comboMin23.Text = reader(4).ToString()
																																		Me.chkCon23.Checked = Conversions.ToBoolean(reader(5))
																																		Me.comboSoundCon23.Text = reader(6).ToString()
																																		Me.comboSoundConEng23.Text = reader(7).ToString()
																																		Me.chkLast23.Checked = Conversions.ToBoolean(reader(8))
																																	Else
																																		flag2 = Conversions.ToInteger(reader(0)) = 120
																																		If flag2 Then
																																			Me.chkFirst24.Checked = Conversions.ToBoolean(reader(1))
																																			Me.chkTime24.Checked = Conversions.ToBoolean(reader(2))
																																			Me.comboHour24.Text = reader(3).ToString()
																																			Me.comboMin24.Text = reader(4).ToString()
																																			Me.chkCon24.Checked = Conversions.ToBoolean(reader(5))
																																			Me.comboSoundCon24.Text = reader(6).ToString()
																																			Me.comboSoundConEng24.Text = reader(7).ToString()
																																			Me.chkLast24.Checked = Conversions.ToBoolean(reader(8))
																																		End If
																																	End If
																																End If
																															End If
																														End If
																													End If
																												End If
																											End If
																										End If
																									End If
																								End If
																							End If
																						End If
																					End If
																				End If
																			End If
																		End If
																	End If
																End If
															End If
														End If
													End If
												End If
											End If
										End While
									Else
										flag2 = d = 6
										If flag2 Then
											While reader.Read()
												flag = Conversions.ToInteger(reader(0)) = 121
												If flag Then
													Me.chkFirst1.Checked = Conversions.ToBoolean(reader(1))
													Me.chkTime1.Checked = Conversions.ToBoolean(reader(2))
													Me.comboHour1.Text = reader(3).ToString()
													Me.comboMin1.Text = reader(4).ToString()
													Me.chkCon1.Checked = Conversions.ToBoolean(reader(5))
													Me.comboSoundCon1.Text = reader(6).ToString()
													Me.comboSoundConEng1.Text = reader(7).ToString()
													Me.chkLast1.Checked = Conversions.ToBoolean(reader(8))
												Else
													flag2 = Conversions.ToInteger(reader(0)) = 122
													If flag2 Then
														Me.chkFirst2.Checked = Conversions.ToBoolean(reader(1))
														Me.chkTime2.Checked = Conversions.ToBoolean(reader(2))
														Me.comboHour2.Text = reader(3).ToString()
														Me.comboMin2.Text = reader(4).ToString()
														Me.chkCon2.Checked = Conversions.ToBoolean(reader(5))
														Me.comboSoundCon2.Text = reader(6).ToString()
														Me.comboSoundConEng2.Text = reader(7).ToString()
														Me.chkLast2.Checked = Conversions.ToBoolean(reader(8))
													Else
														flag2 = Conversions.ToInteger(reader(0)) = 123
														If flag2 Then
															Me.chkFirst3.Checked = Conversions.ToBoolean(reader(1))
															Me.chkTime3.Checked = Conversions.ToBoolean(reader(2))
															Me.comboHour3.Text = reader(3).ToString()
															Me.comboMin3.Text = reader(4).ToString()
															Me.chkCon3.Checked = Conversions.ToBoolean(reader(5))
															Me.comboSoundCon3.Text = reader(6).ToString()
															Me.comboSoundConEng3.Text = reader(7).ToString()
															Me.chkLast3.Checked = Conversions.ToBoolean(reader(8))
														Else
															flag2 = Conversions.ToInteger(reader(0)) = 124
															If flag2 Then
																Me.chkFirst4.Checked = Conversions.ToBoolean(reader(1))
																Me.chkTime4.Checked = Conversions.ToBoolean(reader(2))
																Me.comboHour4.Text = reader(3).ToString()
																Me.comboMin4.Text = reader(4).ToString()
																Me.chkCon4.Checked = Conversions.ToBoolean(reader(5))
																Me.comboSoundCon4.Text = reader(6).ToString()
																Me.comboSoundConEng4.Text = reader(7).ToString()
																Me.chkLast4.Checked = Conversions.ToBoolean(reader(8))
															Else
																flag2 = Conversions.ToInteger(reader(0)) = 125
																If flag2 Then
																	Me.chkFirst5.Checked = Conversions.ToBoolean(reader(1))
																	Me.chkTime5.Checked = Conversions.ToBoolean(reader(2))
																	Me.comboHour5.Text = reader(3).ToString()
																	Me.comboMin5.Text = reader(4).ToString()
																	Me.chkCon5.Checked = Conversions.ToBoolean(reader(5))
																	Me.comboSoundCon5.Text = reader(6).ToString()
																	Me.comboSoundConEng5.Text = reader(7).ToString()
																	Me.chkLast5.Checked = Conversions.ToBoolean(reader(8))
																Else
																	flag2 = Conversions.ToInteger(reader(0)) = 126
																	If flag2 Then
																		Me.chkFirst6.Checked = Conversions.ToBoolean(reader(1))
																		Me.chkTime6.Checked = Conversions.ToBoolean(reader(2))
																		Me.comboHour6.Text = reader(3).ToString()
																		Me.comboMin6.Text = reader(4).ToString()
																		Me.chkCon6.Checked = Conversions.ToBoolean(reader(5))
																		Me.comboSoundCon6.Text = reader(6).ToString()
																		Me.comboSoundConEng6.Text = reader(7).ToString()
																		Me.chkLast6.Checked = Conversions.ToBoolean(reader(8))
																	Else
																		flag2 = Conversions.ToInteger(reader(0)) = 127
																		If flag2 Then
																			Me.chkFirst7.Checked = Conversions.ToBoolean(reader(1))
																			Me.chkTime7.Checked = Conversions.ToBoolean(reader(2))
																			Me.comboHour7.Text = reader(3).ToString()
																			Me.comboMin7.Text = reader(4).ToString()
																			Me.chkCon7.Checked = Conversions.ToBoolean(reader(5))
																			Me.comboSoundCon7.Text = reader(6).ToString()
																			Me.comboSoundConEng7.Text = reader(7).ToString()
																			Me.chkLast7.Checked = Conversions.ToBoolean(reader(8))
																		Else
																			flag2 = Conversions.ToInteger(reader(0)) = 128
																			If flag2 Then
																				Me.chkFirst8.Checked = Conversions.ToBoolean(reader(1))
																				Me.chkTime8.Checked = Conversions.ToBoolean(reader(2))
																				Me.comboHour8.Text = reader(3).ToString()
																				Me.comboMin8.Text = reader(4).ToString()
																				Me.chkCon8.Checked = Conversions.ToBoolean(reader(5))
																				Me.comboSoundCon8.Text = reader(6).ToString()
																				Me.comboSoundConEng8.Text = reader(7).ToString()
																				Me.chkLast8.Checked = Conversions.ToBoolean(reader(8))
																			Else
																				flag2 = Conversions.ToInteger(reader(0)) = 129
																				If flag2 Then
																					Me.chkFirst9.Checked = Conversions.ToBoolean(reader(1))
																					Me.chkTime9.Checked = Conversions.ToBoolean(reader(2))
																					Me.comboHour9.Text = reader(3).ToString()
																					Me.comboMin9.Text = reader(4).ToString()
																					Me.chkCon9.Checked = Conversions.ToBoolean(reader(5))
																					Me.comboSoundCon9.Text = reader(6).ToString()
																					Me.comboSoundConEng9.Text = reader(7).ToString()
																					Me.chkLast9.Checked = Conversions.ToBoolean(reader(8))
																				Else
																					flag2 = Conversions.ToInteger(reader(0)) = 130
																					If flag2 Then
																						Me.chkFirst10.Checked = Conversions.ToBoolean(reader(1))
																						Me.chkTime10.Checked = Conversions.ToBoolean(reader(2))
																						Me.comboHour10.Text = reader(3).ToString()
																						Me.comboMin10.Text = reader(4).ToString()
																						Me.chkCon10.Checked = Conversions.ToBoolean(reader(5))
																						Me.comboSoundCon10.Text = reader(6).ToString()
																						Me.comboSoundConEng10.Text = reader(7).ToString()
																						Me.chkLast10.Checked = Conversions.ToBoolean(reader(8))
																					Else
																						flag2 = Conversions.ToInteger(reader(0)) = 131
																						If flag2 Then
																							Me.chkFirst11.Checked = Conversions.ToBoolean(reader(1))
																							Me.chkTime11.Checked = Conversions.ToBoolean(reader(2))
																							Me.comboHour11.Text = reader(3).ToString()
																							Me.comboMin11.Text = reader(4).ToString()
																							Me.chkCon11.Checked = Conversions.ToBoolean(reader(5))
																							Me.comboSoundCon11.Text = reader(6).ToString()
																							Me.comboSoundConEng11.Text = reader(7).ToString()
																							Me.chkLast11.Checked = Conversions.ToBoolean(reader(8))
																						Else
																							flag2 = Conversions.ToInteger(reader(0)) = 132
																							If flag2 Then
																								Me.chkFirst12.Checked = Conversions.ToBoolean(reader(1))
																								Me.chkTime12.Checked = Conversions.ToBoolean(reader(2))
																								Me.comboHour12.Text = reader(3).ToString()
																								Me.comboMin12.Text = reader(4).ToString()
																								Me.chkCon12.Checked = Conversions.ToBoolean(reader(5))
																								Me.comboSoundCon12.Text = reader(6).ToString()
																								Me.comboSoundConEng12.Text = reader(7).ToString()
																								Me.chkLast12.Checked = Conversions.ToBoolean(reader(8))
																							Else
																								flag2 = Conversions.ToInteger(reader(0)) = 133
																								If flag2 Then
																									Me.chkFirst13.Checked = Conversions.ToBoolean(reader(1))
																									Me.chkTime13.Checked = Conversions.ToBoolean(reader(2))
																									Me.comboHour13.Text = reader(3).ToString()
																									Me.comboMin13.Text = reader(4).ToString()
																									Me.chkCon13.Checked = Conversions.ToBoolean(reader(5))
																									Me.comboSoundCon13.Text = reader(6).ToString()
																									Me.comboSoundConEng13.Text = reader(7).ToString()
																									Me.chkLast13.Checked = Conversions.ToBoolean(reader(8))
																								Else
																									flag2 = Conversions.ToInteger(reader(0)) = 134
																									If flag2 Then
																										Me.chkFirst14.Checked = Conversions.ToBoolean(reader(1))
																										Me.chkTime14.Checked = Conversions.ToBoolean(reader(2))
																										Me.comboHour14.Text = reader(3).ToString()
																										Me.comboMin14.Text = reader(4).ToString()
																										Me.chkCon14.Checked = Conversions.ToBoolean(reader(5))
																										Me.comboSoundCon14.Text = reader(6).ToString()
																										Me.comboSoundConEng14.Text = reader(7).ToString()
																										Me.chkLast14.Checked = Conversions.ToBoolean(reader(8))
																									Else
																										flag2 = Conversions.ToInteger(reader(0)) = 135
																										If flag2 Then
																											Me.chkFirst15.Checked = Conversions.ToBoolean(reader(1))
																											Me.chkTime15.Checked = Conversions.ToBoolean(reader(2))
																											Me.comboHour15.Text = reader(3).ToString()
																											Me.comboMin15.Text = reader(4).ToString()
																											Me.chkCon15.Checked = Conversions.ToBoolean(reader(5))
																											Me.comboSoundCon15.Text = reader(6).ToString()
																											Me.comboSoundConEng15.Text = reader(7).ToString()
																											Me.chkLast15.Checked = Conversions.ToBoolean(reader(8))
																										Else
																											flag2 = Conversions.ToInteger(reader(0)) = 136
																											If flag2 Then
																												Me.chkFirst16.Checked = Conversions.ToBoolean(reader(1))
																												Me.chkTime16.Checked = Conversions.ToBoolean(reader(2))
																												Me.comboHour16.Text = reader(3).ToString()
																												Me.comboMin16.Text = reader(4).ToString()
																												Me.chkCon16.Checked = Conversions.ToBoolean(reader(5))
																												Me.comboSoundCon16.Text = reader(6).ToString()
																												Me.comboSoundConEng16.Text = reader(7).ToString()
																												Me.chkLast16.Checked = Conversions.ToBoolean(reader(8))
																											Else
																												flag2 = Conversions.ToInteger(reader(0)) = 137
																												If flag2 Then
																													Me.chkFirst17.Checked = Conversions.ToBoolean(reader(1))
																													Me.chkTime17.Checked = Conversions.ToBoolean(reader(2))
																													Me.comboHour17.Text = reader(3).ToString()
																													Me.comboMin17.Text = reader(4).ToString()
																													Me.chkCon17.Checked = Conversions.ToBoolean(reader(5))
																													Me.comboSoundCon17.Text = reader(6).ToString()
																													Me.comboSoundConEng17.Text = reader(7).ToString()
																													Me.chkLast17.Checked = Conversions.ToBoolean(reader(8))
																												Else
																													flag2 = Conversions.ToInteger(reader(0)) = 138
																													If flag2 Then
																														Me.chkFirst18.Checked = Conversions.ToBoolean(reader(1))
																														Me.chkTime18.Checked = Conversions.ToBoolean(reader(2))
																														Me.comboHour18.Text = reader(3).ToString()
																														Me.comboMin18.Text = reader(4).ToString()
																														Me.chkCon18.Checked = Conversions.ToBoolean(reader(5))
																														Me.comboSoundCon18.Text = reader(6).ToString()
																														Me.comboSoundConEng18.Text = reader(7).ToString()
																														Me.chkLast18.Checked = Conversions.ToBoolean(reader(8))
																													Else
																														flag2 = Conversions.ToInteger(reader(0)) = 139
																														If flag2 Then
																															Me.chkFirst19.Checked = Conversions.ToBoolean(reader(1))
																															Me.chkTime19.Checked = Conversions.ToBoolean(reader(2))
																															Me.comboHour19.Text = reader(3).ToString()
																															Me.comboMin19.Text = reader(4).ToString()
																															Me.chkCon19.Checked = Conversions.ToBoolean(reader(5))
																															Me.comboSoundCon19.Text = reader(6).ToString()
																															Me.comboSoundConEng19.Text = reader(7).ToString()
																															Me.chkLast19.Checked = Conversions.ToBoolean(reader(8))
																														Else
																															flag2 = Conversions.ToInteger(reader(0)) = 140
																															If flag2 Then
																																Me.chkFirst20.Checked = Conversions.ToBoolean(reader(1))
																																Me.chkTime20.Checked = Conversions.ToBoolean(reader(2))
																																Me.comboHour20.Text = reader(3).ToString()
																																Me.comboMin20.Text = reader(4).ToString()
																																Me.chkCon20.Checked = Conversions.ToBoolean(reader(5))
																																Me.comboSoundCon20.Text = reader(6).ToString()
																																Me.comboSoundConEng20.Text = reader(7).ToString()
																																Me.chkLast20.Checked = Conversions.ToBoolean(reader(8))
																															Else
																																flag2 = Conversions.ToInteger(reader(0)) = 141
																																If flag2 Then
																																	Me.chkFirst21.Checked = Conversions.ToBoolean(reader(1))
																																	Me.chkTime21.Checked = Conversions.ToBoolean(reader(2))
																																	Me.comboHour21.Text = reader(3).ToString()
																																	Me.comboMin21.Text = reader(4).ToString()
																																	Me.chkCon21.Checked = Conversions.ToBoolean(reader(5))
																																	Me.comboSoundCon21.Text = reader(6).ToString()
																																	Me.comboSoundConEng21.Text = reader(7).ToString()
																																	Me.chkLast21.Checked = Conversions.ToBoolean(reader(8))
																																Else
																																	flag2 = Conversions.ToInteger(reader(0)) = 142
																																	If flag2 Then
																																		Me.chkFirst22.Checked = Conversions.ToBoolean(reader(1))
																																		Me.chkTime22.Checked = Conversions.ToBoolean(reader(2))
																																		Me.comboHour22.Text = reader(3).ToString()
																																		Me.comboMin22.Text = reader(4).ToString()
																																		Me.chkCon22.Checked = Conversions.ToBoolean(reader(5))
																																		Me.comboSoundCon22.Text = reader(6).ToString()
																																		Me.comboSoundConEng22.Text = reader(7).ToString()
																																		Me.chkLast22.Checked = Conversions.ToBoolean(reader(8))
																																	Else
																																		flag2 = Conversions.ToInteger(reader(0)) = 143
																																		If flag2 Then
																																			Me.chkFirst23.Checked = Conversions.ToBoolean(reader(1))
																																			Me.chkTime23.Checked = Conversions.ToBoolean(reader(2))
																																			Me.comboHour23.Text = reader(3).ToString()
																																			Me.comboMin23.Text = reader(4).ToString()
																																			Me.chkCon23.Checked = Conversions.ToBoolean(reader(5))
																																			Me.comboSoundCon23.Text = reader(6).ToString()
																																			Me.comboSoundConEng23.Text = reader(7).ToString()
																																			Me.chkLast23.Checked = Conversions.ToBoolean(reader(8))
																																		Else
																																			flag2 = Conversions.ToInteger(reader(0)) = 144
																																			If flag2 Then
																																				Me.chkFirst24.Checked = Conversions.ToBoolean(reader(1))
																																				Me.chkTime24.Checked = Conversions.ToBoolean(reader(2))
																																				Me.comboHour24.Text = reader(3).ToString()
																																				Me.comboMin24.Text = reader(4).ToString()
																																				Me.chkCon24.Checked = Conversions.ToBoolean(reader(5))
																																				Me.comboSoundCon24.Text = reader(6).ToString()
																																				Me.comboSoundConEng24.Text = reader(7).ToString()
																																				Me.chkLast24.Checked = Conversions.ToBoolean(reader(8))
																																			End If
																																		End If
																																	End If
																																End If
																															End If
																														End If
																													End If
																												End If
																											End If
																										End If
																									End If
																								End If
																							End If
																						End If
																					End If
																				End If
																			End If
																		End If
																	End If
																End If
															End If
														End If
													End If
												End If
											End While
										Else
											flag2 = d = 7
											If flag2 Then
												While reader.Read()
													flag = Conversions.ToInteger(reader(0)) = 145
													If flag Then
														Me.chkFirst1.Checked = Conversions.ToBoolean(reader(1))
														Me.chkTime1.Checked = Conversions.ToBoolean(reader(2))
														Me.comboHour1.Text = reader(3).ToString()
														Me.comboMin1.Text = reader(4).ToString()
														Me.chkCon1.Checked = Conversions.ToBoolean(reader(5))
														Me.comboSoundCon1.Text = reader(6).ToString()
														Me.comboSoundConEng1.Text = reader(7).ToString()
														Me.chkLast1.Checked = Conversions.ToBoolean(reader(8))
													Else
														flag2 = Conversions.ToInteger(reader(0)) = 146
														If flag2 Then
															Me.chkFirst2.Checked = Conversions.ToBoolean(reader(1))
															Me.chkTime2.Checked = Conversions.ToBoolean(reader(2))
															Me.comboHour2.Text = reader(3).ToString()
															Me.comboMin2.Text = reader(4).ToString()
															Me.chkCon2.Checked = Conversions.ToBoolean(reader(5))
															Me.comboSoundCon2.Text = reader(6).ToString()
															Me.comboSoundConEng2.Text = reader(7).ToString()
															Me.chkLast2.Checked = Conversions.ToBoolean(reader(8))
														Else
															flag2 = Conversions.ToInteger(reader(0)) = 147
															If flag2 Then
																Me.chkFirst3.Checked = Conversions.ToBoolean(reader(1))
																Me.chkTime3.Checked = Conversions.ToBoolean(reader(2))
																Me.comboHour3.Text = reader(3).ToString()
																Me.comboMin3.Text = reader(4).ToString()
																Me.chkCon3.Checked = Conversions.ToBoolean(reader(5))
																Me.comboSoundCon3.Text = reader(6).ToString()
																Me.comboSoundConEng3.Text = reader(7).ToString()
																Me.chkLast3.Checked = Conversions.ToBoolean(reader(8))
															Else
																flag2 = Conversions.ToInteger(reader(0)) = 148
																If flag2 Then
																	Me.chkFirst4.Checked = Conversions.ToBoolean(reader(1))
																	Me.chkTime4.Checked = Conversions.ToBoolean(reader(2))
																	Me.comboHour4.Text = reader(3).ToString()
																	Me.comboMin4.Text = reader(4).ToString()
																	Me.chkCon4.Checked = Conversions.ToBoolean(reader(5))
																	Me.comboSoundCon4.Text = reader(6).ToString()
																	Me.comboSoundConEng4.Text = reader(7).ToString()
																	Me.chkLast4.Checked = Conversions.ToBoolean(reader(8))
																Else
																	flag2 = Conversions.ToInteger(reader(0)) = 149
																	If flag2 Then
																		Me.chkFirst5.Checked = Conversions.ToBoolean(reader(1))
																		Me.chkTime5.Checked = Conversions.ToBoolean(reader(2))
																		Me.comboHour5.Text = reader(3).ToString()
																		Me.comboMin5.Text = reader(4).ToString()
																		Me.chkCon5.Checked = Conversions.ToBoolean(reader(5))
																		Me.comboSoundCon5.Text = reader(6).ToString()
																		Me.comboSoundConEng5.Text = reader(7).ToString()
																		Me.chkLast5.Checked = Conversions.ToBoolean(reader(8))
																	Else
																		flag2 = Conversions.ToInteger(reader(0)) = 150
																		If flag2 Then
																			Me.chkFirst6.Checked = Conversions.ToBoolean(reader(1))
																			Me.chkTime6.Checked = Conversions.ToBoolean(reader(2))
																			Me.comboHour6.Text = reader(3).ToString()
																			Me.comboMin6.Text = reader(4).ToString()
																			Me.chkCon6.Checked = Conversions.ToBoolean(reader(5))
																			Me.comboSoundCon6.Text = reader(6).ToString()
																			Me.comboSoundConEng6.Text = reader(7).ToString()
																			Me.chkLast6.Checked = Conversions.ToBoolean(reader(8))
																		Else
																			flag2 = Conversions.ToInteger(reader(0)) = 151
																			If flag2 Then
																				Me.chkFirst7.Checked = Conversions.ToBoolean(reader(1))
																				Me.chkTime7.Checked = Conversions.ToBoolean(reader(2))
																				Me.comboHour7.Text = reader(3).ToString()
																				Me.comboMin7.Text = reader(4).ToString()
																				Me.chkCon7.Checked = Conversions.ToBoolean(reader(5))
																				Me.comboSoundCon7.Text = reader(6).ToString()
																				Me.comboSoundConEng7.Text = reader(7).ToString()
																				Me.chkLast7.Checked = Conversions.ToBoolean(reader(8))
																			Else
																				flag2 = Conversions.ToInteger(reader(0)) = 152
																				If flag2 Then
																					Me.chkFirst8.Checked = Conversions.ToBoolean(reader(1))
																					Me.chkTime8.Checked = Conversions.ToBoolean(reader(2))
																					Me.comboHour8.Text = reader(3).ToString()
																					Me.comboMin8.Text = reader(4).ToString()
																					Me.chkCon8.Checked = Conversions.ToBoolean(reader(5))
																					Me.comboSoundCon8.Text = reader(6).ToString()
																					Me.comboSoundConEng8.Text = reader(7).ToString()
																					Me.chkLast8.Checked = Conversions.ToBoolean(reader(8))
																				Else
																					flag2 = Conversions.ToInteger(reader(0)) = 153
																					If flag2 Then
																						Me.chkFirst9.Checked = Conversions.ToBoolean(reader(1))
																						Me.chkTime9.Checked = Conversions.ToBoolean(reader(2))
																						Me.comboHour9.Text = reader(3).ToString()
																						Me.comboMin9.Text = reader(4).ToString()
																						Me.chkCon9.Checked = Conversions.ToBoolean(reader(5))
																						Me.comboSoundCon9.Text = reader(6).ToString()
																						Me.comboSoundConEng9.Text = reader(7).ToString()
																						Me.chkLast9.Checked = Conversions.ToBoolean(reader(8))
																					Else
																						flag2 = Conversions.ToInteger(reader(0)) = 154
																						If flag2 Then
																							Me.chkFirst10.Checked = Conversions.ToBoolean(reader(1))
																							Me.chkTime10.Checked = Conversions.ToBoolean(reader(2))
																							Me.comboHour10.Text = reader(3).ToString()
																							Me.comboMin10.Text = reader(4).ToString()
																							Me.chkCon10.Checked = Conversions.ToBoolean(reader(5))
																							Me.comboSoundCon10.Text = reader(6).ToString()
																							Me.comboSoundConEng10.Text = reader(7).ToString()
																							Me.chkLast10.Checked = Conversions.ToBoolean(reader(8))
																						Else
																							flag2 = Conversions.ToInteger(reader(0)) = 155
																							If flag2 Then
																								Me.chkFirst11.Checked = Conversions.ToBoolean(reader(1))
																								Me.chkTime11.Checked = Conversions.ToBoolean(reader(2))
																								Me.comboHour11.Text = reader(3).ToString()
																								Me.comboMin11.Text = reader(4).ToString()
																								Me.chkCon11.Checked = Conversions.ToBoolean(reader(5))
																								Me.comboSoundCon11.Text = reader(6).ToString()
																								Me.comboSoundConEng11.Text = reader(7).ToString()
																								Me.chkLast11.Checked = Conversions.ToBoolean(reader(8))
																							Else
																								flag2 = Conversions.ToInteger(reader(0)) = 156
																								If flag2 Then
																									Me.chkFirst12.Checked = Conversions.ToBoolean(reader(1))
																									Me.chkTime12.Checked = Conversions.ToBoolean(reader(2))
																									Me.comboHour12.Text = reader(3).ToString()
																									Me.comboMin12.Text = reader(4).ToString()
																									Me.chkCon12.Checked = Conversions.ToBoolean(reader(5))
																									Me.comboSoundCon12.Text = reader(6).ToString()
																									Me.comboSoundConEng12.Text = reader(7).ToString()
																									Me.chkLast12.Checked = Conversions.ToBoolean(reader(8))
																								Else
																									flag2 = Conversions.ToInteger(reader(0)) = 157
																									If flag2 Then
																										Me.chkFirst13.Checked = Conversions.ToBoolean(reader(1))
																										Me.chkTime13.Checked = Conversions.ToBoolean(reader(2))
																										Me.comboHour13.Text = reader(3).ToString()
																										Me.comboMin13.Text = reader(4).ToString()
																										Me.chkCon13.Checked = Conversions.ToBoolean(reader(5))
																										Me.comboSoundCon13.Text = reader(6).ToString()
																										Me.comboSoundConEng13.Text = reader(7).ToString()
																										Me.chkLast13.Checked = Conversions.ToBoolean(reader(8))
																									Else
																										flag2 = Conversions.ToInteger(reader(0)) = 158
																										If flag2 Then
																											Me.chkFirst14.Checked = Conversions.ToBoolean(reader(1))
																											Me.chkTime14.Checked = Conversions.ToBoolean(reader(2))
																											Me.comboHour14.Text = reader(3).ToString()
																											Me.comboMin14.Text = reader(4).ToString()
																											Me.chkCon14.Checked = Conversions.ToBoolean(reader(5))
																											Me.comboSoundCon14.Text = reader(6).ToString()
																											Me.comboSoundConEng14.Text = reader(7).ToString()
																											Me.chkLast14.Checked = Conversions.ToBoolean(reader(8))
																										Else
																											flag2 = Conversions.ToInteger(reader(0)) = 159
																											If flag2 Then
																												Me.chkFirst15.Checked = Conversions.ToBoolean(reader(1))
																												Me.chkTime15.Checked = Conversions.ToBoolean(reader(2))
																												Me.comboHour15.Text = reader(3).ToString()
																												Me.comboMin15.Text = reader(4).ToString()
																												Me.chkCon15.Checked = Conversions.ToBoolean(reader(5))
																												Me.comboSoundCon15.Text = reader(6).ToString()
																												Me.comboSoundConEng15.Text = reader(7).ToString()
																												Me.chkLast15.Checked = Conversions.ToBoolean(reader(8))
																											Else
																												flag2 = Conversions.ToInteger(reader(0)) = 160
																												If flag2 Then
																													Me.chkFirst16.Checked = Conversions.ToBoolean(reader(1))
																													Me.chkTime16.Checked = Conversions.ToBoolean(reader(2))
																													Me.comboHour16.Text = reader(3).ToString()
																													Me.comboMin16.Text = reader(4).ToString()
																													Me.chkCon16.Checked = Conversions.ToBoolean(reader(5))
																													Me.comboSoundCon16.Text = reader(6).ToString()
																													Me.comboSoundConEng16.Text = reader(7).ToString()
																													Me.chkLast16.Checked = Conversions.ToBoolean(reader(8))
																												Else
																													flag2 = Conversions.ToInteger(reader(0)) = 161
																													If flag2 Then
																														Me.chkFirst17.Checked = Conversions.ToBoolean(reader(1))
																														Me.chkTime17.Checked = Conversions.ToBoolean(reader(2))
																														Me.comboHour17.Text = reader(3).ToString()
																														Me.comboMin17.Text = reader(4).ToString()
																														Me.chkCon17.Checked = Conversions.ToBoolean(reader(5))
																														Me.comboSoundCon17.Text = reader(6).ToString()
																														Me.comboSoundConEng17.Text = reader(7).ToString()
																														Me.chkLast17.Checked = Conversions.ToBoolean(reader(8))
																													Else
																														flag2 = Conversions.ToInteger(reader(0)) = 162
																														If flag2 Then
																															Me.chkFirst18.Checked = Conversions.ToBoolean(reader(1))
																															Me.chkTime18.Checked = Conversions.ToBoolean(reader(2))
																															Me.comboHour18.Text = reader(3).ToString()
																															Me.comboMin18.Text = reader(4).ToString()
																															Me.chkCon18.Checked = Conversions.ToBoolean(reader(5))
																															Me.comboSoundCon18.Text = reader(6).ToString()
																															Me.comboSoundConEng18.Text = reader(7).ToString()
																															Me.chkLast18.Checked = Conversions.ToBoolean(reader(8))
																														Else
																															flag2 = Conversions.ToInteger(reader(0)) = 163
																															If flag2 Then
																																Me.chkFirst19.Checked = Conversions.ToBoolean(reader(1))
																																Me.chkTime19.Checked = Conversions.ToBoolean(reader(2))
																																Me.comboHour19.Text = reader(3).ToString()
																																Me.comboMin19.Text = reader(4).ToString()
																																Me.chkCon19.Checked = Conversions.ToBoolean(reader(5))
																																Me.comboSoundCon19.Text = reader(6).ToString()
																																Me.comboSoundConEng19.Text = reader(7).ToString()
																																Me.chkLast19.Checked = Conversions.ToBoolean(reader(8))
																															Else
																																flag2 = Conversions.ToInteger(reader(0)) = 164
																																If flag2 Then
																																	Me.chkFirst20.Checked = Conversions.ToBoolean(reader(1))
																																	Me.chkTime20.Checked = Conversions.ToBoolean(reader(2))
																																	Me.comboHour20.Text = reader(3).ToString()
																																	Me.comboMin20.Text = reader(4).ToString()
																																	Me.chkCon20.Checked = Conversions.ToBoolean(reader(5))
																																	Me.comboSoundCon20.Text = reader(6).ToString()
																																	Me.comboSoundConEng20.Text = reader(7).ToString()
																																	Me.chkLast20.Checked = Conversions.ToBoolean(reader(8))
																																Else
																																	flag2 = Conversions.ToInteger(reader(0)) = 165
																																	If flag2 Then
																																		Me.chkFirst21.Checked = Conversions.ToBoolean(reader(1))
																																		Me.chkTime21.Checked = Conversions.ToBoolean(reader(2))
																																		Me.comboHour21.Text = reader(3).ToString()
																																		Me.comboMin21.Text = reader(4).ToString()
																																		Me.chkCon21.Checked = Conversions.ToBoolean(reader(5))
																																		Me.comboSoundCon21.Text = reader(6).ToString()
																																		Me.comboSoundConEng21.Text = reader(7).ToString()
																																		Me.chkLast21.Checked = Conversions.ToBoolean(reader(8))
																																	Else
																																		flag2 = Conversions.ToInteger(reader(0)) = 166
																																		If flag2 Then
																																			Me.chkFirst22.Checked = Conversions.ToBoolean(reader(1))
																																			Me.chkTime22.Checked = Conversions.ToBoolean(reader(2))
																																			Me.comboHour22.Text = reader(3).ToString()
																																			Me.comboMin22.Text = reader(4).ToString()
																																			Me.chkCon22.Checked = Conversions.ToBoolean(reader(5))
																																			Me.comboSoundCon22.Text = reader(6).ToString()
																																			Me.comboSoundConEng22.Text = reader(7).ToString()
																																			Me.chkLast22.Checked = Conversions.ToBoolean(reader(8))
																																		Else
																																			flag2 = Conversions.ToInteger(reader(0)) = 167
																																			If flag2 Then
																																				Me.chkFirst23.Checked = Conversions.ToBoolean(reader(1))
																																				Me.chkTime23.Checked = Conversions.ToBoolean(reader(2))
																																				Me.comboHour23.Text = reader(3).ToString()
																																				Me.comboMin23.Text = reader(4).ToString()
																																				Me.chkCon23.Checked = Conversions.ToBoolean(reader(5))
																																				Me.comboSoundCon23.Text = reader(6).ToString()
																																				Me.comboSoundConEng23.Text = reader(7).ToString()
																																				Me.chkLast23.Checked = Conversions.ToBoolean(reader(8))
																																			Else
																																				flag2 = Conversions.ToInteger(reader(0)) = 168
																																				If flag2 Then
																																					Me.chkFirst24.Checked = Conversions.ToBoolean(reader(1))
																																					Me.chkTime24.Checked = Conversions.ToBoolean(reader(2))
																																					Me.comboHour24.Text = reader(3).ToString()
																																					Me.comboMin24.Text = reader(4).ToString()
																																					Me.chkCon24.Checked = Conversions.ToBoolean(reader(5))
																																					Me.comboSoundCon24.Text = reader(6).ToString()
																																					Me.comboSoundConEng24.Text = reader(7).ToString()
																																					Me.chkLast24.Checked = Conversions.ToBoolean(reader(8))
																																				End If
																																			End If
																																		End If
																																	End If
																																End If
																															End If
																														End If
																													End If
																												End If
																											End If
																										End If
																									End If
																								End If
																							End If
																						End If
																					End If
																				End If
																			End If
																		End If
																	End If
																End If
															End If
														End If
													End If
												End While
											Else
												flag2 = d = 8
												If flag2 Then
													While reader.Read()
														flag = Conversions.ToInteger(reader(0)) = 169
														If flag Then
															Me.chkFirst1.Checked = Conversions.ToBoolean(reader(1))
															Me.chkTime1.Checked = Conversions.ToBoolean(reader(2))
															Me.comboHour1.Text = reader(3).ToString()
															Me.comboMin1.Text = reader(4).ToString()
															Me.chkCon1.Checked = Conversions.ToBoolean(reader(5))
															Me.comboSoundCon1.Text = reader(6).ToString()
															Me.comboSoundConEng1.Text = reader(7).ToString()
															Me.chkLast1.Checked = Conversions.ToBoolean(reader(8))
														Else
															flag2 = Conversions.ToInteger(reader(0)) = 170
															If flag2 Then
																Me.chkFirst2.Checked = Conversions.ToBoolean(reader(1))
																Me.chkTime2.Checked = Conversions.ToBoolean(reader(2))
																Me.comboHour2.Text = reader(3).ToString()
																Me.comboMin2.Text = reader(4).ToString()
																Me.chkCon2.Checked = Conversions.ToBoolean(reader(5))
																Me.comboSoundCon2.Text = reader(6).ToString()
																Me.comboSoundConEng2.Text = reader(7).ToString()
																Me.chkLast2.Checked = Conversions.ToBoolean(reader(8))
															Else
																flag2 = Conversions.ToInteger(reader(0)) = 171
																If flag2 Then
																	Me.chkFirst3.Checked = Conversions.ToBoolean(reader(1))
																	Me.chkTime3.Checked = Conversions.ToBoolean(reader(2))
																	Me.comboHour3.Text = reader(3).ToString()
																	Me.comboMin3.Text = reader(4).ToString()
																	Me.chkCon3.Checked = Conversions.ToBoolean(reader(5))
																	Me.comboSoundCon3.Text = reader(6).ToString()
																	Me.comboSoundConEng3.Text = reader(7).ToString()
																	Me.chkLast3.Checked = Conversions.ToBoolean(reader(8))
																Else
																	flag2 = Conversions.ToInteger(reader(0)) = 172
																	If flag2 Then
																		Me.chkFirst4.Checked = Conversions.ToBoolean(reader(1))
																		Me.chkTime4.Checked = Conversions.ToBoolean(reader(2))
																		Me.comboHour4.Text = reader(3).ToString()
																		Me.comboMin4.Text = reader(4).ToString()
																		Me.chkCon4.Checked = Conversions.ToBoolean(reader(5))
																		Me.comboSoundCon4.Text = reader(6).ToString()
																		Me.comboSoundConEng4.Text = reader(7).ToString()
																		Me.chkLast4.Checked = Conversions.ToBoolean(reader(8))
																	Else
																		flag2 = Conversions.ToInteger(reader(0)) = 173
																		If flag2 Then
																			Me.chkFirst5.Checked = Conversions.ToBoolean(reader(1))
																			Me.chkTime5.Checked = Conversions.ToBoolean(reader(2))
																			Me.comboHour5.Text = reader(3).ToString()
																			Me.comboMin5.Text = reader(4).ToString()
																			Me.chkCon5.Checked = Conversions.ToBoolean(reader(5))
																			Me.comboSoundCon5.Text = reader(6).ToString()
																			Me.comboSoundConEng5.Text = reader(7).ToString()
																			Me.chkLast5.Checked = Conversions.ToBoolean(reader(8))
																		Else
																			flag2 = Conversions.ToInteger(reader(0)) = 174
																			If flag2 Then
																				Me.chkFirst6.Checked = Conversions.ToBoolean(reader(1))
																				Me.chkTime6.Checked = Conversions.ToBoolean(reader(2))
																				Me.comboHour6.Text = reader(3).ToString()
																				Me.comboMin6.Text = reader(4).ToString()
																				Me.chkCon6.Checked = Conversions.ToBoolean(reader(5))
																				Me.comboSoundCon6.Text = reader(6).ToString()
																				Me.comboSoundConEng6.Text = reader(7).ToString()
																				Me.chkLast6.Checked = Conversions.ToBoolean(reader(8))
																			Else
																				flag2 = Conversions.ToInteger(reader(0)) = 175
																				If flag2 Then
																					Me.chkFirst7.Checked = Conversions.ToBoolean(reader(1))
																					Me.chkTime7.Checked = Conversions.ToBoolean(reader(2))
																					Me.comboHour7.Text = reader(3).ToString()
																					Me.comboMin7.Text = reader(4).ToString()
																					Me.chkCon7.Checked = Conversions.ToBoolean(reader(5))
																					Me.comboSoundCon7.Text = reader(6).ToString()
																					Me.comboSoundConEng7.Text = reader(7).ToString()
																					Me.chkLast7.Checked = Conversions.ToBoolean(reader(8))
																				Else
																					flag2 = Conversions.ToInteger(reader(0)) = 176
																					If flag2 Then
																						Me.chkFirst8.Checked = Conversions.ToBoolean(reader(1))
																						Me.chkTime8.Checked = Conversions.ToBoolean(reader(2))
																						Me.comboHour8.Text = reader(3).ToString()
																						Me.comboMin8.Text = reader(4).ToString()
																						Me.chkCon8.Checked = Conversions.ToBoolean(reader(5))
																						Me.comboSoundCon8.Text = reader(6).ToString()
																						Me.comboSoundConEng8.Text = reader(7).ToString()
																						Me.chkLast8.Checked = Conversions.ToBoolean(reader(8))
																					Else
																						flag2 = Conversions.ToInteger(reader(0)) = 177
																						If flag2 Then
																							Me.chkFirst9.Checked = Conversions.ToBoolean(reader(1))
																							Me.chkTime9.Checked = Conversions.ToBoolean(reader(2))
																							Me.comboHour9.Text = reader(3).ToString()
																							Me.comboMin9.Text = reader(4).ToString()
																							Me.chkCon9.Checked = Conversions.ToBoolean(reader(5))
																							Me.comboSoundCon9.Text = reader(6).ToString()
																							Me.comboSoundConEng9.Text = reader(7).ToString()
																							Me.chkLast9.Checked = Conversions.ToBoolean(reader(8))
																						Else
																							flag2 = Conversions.ToInteger(reader(0)) = 178
																							If flag2 Then
																								Me.chkFirst10.Checked = Conversions.ToBoolean(reader(1))
																								Me.chkTime10.Checked = Conversions.ToBoolean(reader(2))
																								Me.comboHour10.Text = reader(3).ToString()
																								Me.comboMin10.Text = reader(4).ToString()
																								Me.chkCon10.Checked = Conversions.ToBoolean(reader(5))
																								Me.comboSoundCon10.Text = reader(6).ToString()
																								Me.comboSoundConEng10.Text = reader(7).ToString()
																								Me.chkLast10.Checked = Conversions.ToBoolean(reader(8))
																							Else
																								flag2 = Conversions.ToInteger(reader(0)) = 179
																								If flag2 Then
																									Me.chkFirst11.Checked = Conversions.ToBoolean(reader(1))
																									Me.chkTime11.Checked = Conversions.ToBoolean(reader(2))
																									Me.comboHour11.Text = reader(3).ToString()
																									Me.comboMin11.Text = reader(4).ToString()
																									Me.chkCon11.Checked = Conversions.ToBoolean(reader(5))
																									Me.comboSoundCon11.Text = reader(6).ToString()
																									Me.comboSoundConEng11.Text = reader(7).ToString()
																									Me.chkLast11.Checked = Conversions.ToBoolean(reader(8))
																								Else
																									flag2 = Conversions.ToInteger(reader(0)) = 180
																									If flag2 Then
																										Me.chkFirst12.Checked = Conversions.ToBoolean(reader(1))
																										Me.chkTime12.Checked = Conversions.ToBoolean(reader(2))
																										Me.comboHour12.Text = reader(3).ToString()
																										Me.comboMin12.Text = reader(4).ToString()
																										Me.chkCon12.Checked = Conversions.ToBoolean(reader(5))
																										Me.comboSoundCon12.Text = reader(6).ToString()
																										Me.comboSoundConEng12.Text = reader(7).ToString()
																										Me.chkLast12.Checked = Conversions.ToBoolean(reader(8))
																									Else
																										flag2 = Conversions.ToInteger(reader(0)) = 181
																										If flag2 Then
																											Me.chkFirst13.Checked = Conversions.ToBoolean(reader(1))
																											Me.chkTime13.Checked = Conversions.ToBoolean(reader(2))
																											Me.comboHour13.Text = reader(3).ToString()
																											Me.comboMin13.Text = reader(4).ToString()
																											Me.chkCon13.Checked = Conversions.ToBoolean(reader(5))
																											Me.comboSoundCon13.Text = reader(6).ToString()
																											Me.comboSoundConEng13.Text = reader(7).ToString()
																											Me.chkLast13.Checked = Conversions.ToBoolean(reader(8))
																										Else
																											flag2 = Conversions.ToInteger(reader(0)) = 182
																											If flag2 Then
																												Me.chkFirst14.Checked = Conversions.ToBoolean(reader(1))
																												Me.chkTime14.Checked = Conversions.ToBoolean(reader(2))
																												Me.comboHour14.Text = reader(3).ToString()
																												Me.comboMin14.Text = reader(4).ToString()
																												Me.chkCon14.Checked = Conversions.ToBoolean(reader(5))
																												Me.comboSoundCon14.Text = reader(6).ToString()
																												Me.comboSoundConEng14.Text = reader(7).ToString()
																												Me.chkLast14.Checked = Conversions.ToBoolean(reader(8))
																											Else
																												flag2 = Conversions.ToInteger(reader(0)) = 183
																												If flag2 Then
																													Me.chkFirst15.Checked = Conversions.ToBoolean(reader(1))
																													Me.chkTime15.Checked = Conversions.ToBoolean(reader(2))
																													Me.comboHour15.Text = reader(3).ToString()
																													Me.comboMin15.Text = reader(4).ToString()
																													Me.chkCon15.Checked = Conversions.ToBoolean(reader(5))
																													Me.comboSoundCon15.Text = reader(6).ToString()
																													Me.comboSoundConEng15.Text = reader(7).ToString()
																													Me.chkLast15.Checked = Conversions.ToBoolean(reader(8))
																												Else
																													flag2 = Conversions.ToInteger(reader(0)) = 184
																													If flag2 Then
																														Me.chkFirst16.Checked = Conversions.ToBoolean(reader(1))
																														Me.chkTime16.Checked = Conversions.ToBoolean(reader(2))
																														Me.comboHour16.Text = reader(3).ToString()
																														Me.comboMin16.Text = reader(4).ToString()
																														Me.chkCon16.Checked = Conversions.ToBoolean(reader(5))
																														Me.comboSoundCon16.Text = reader(6).ToString()
																														Me.comboSoundConEng16.Text = reader(7).ToString()
																														Me.chkLast16.Checked = Conversions.ToBoolean(reader(8))
																													Else
																														flag2 = Conversions.ToInteger(reader(0)) = 185
																														If flag2 Then
																															Me.chkFirst17.Checked = Conversions.ToBoolean(reader(1))
																															Me.chkTime17.Checked = Conversions.ToBoolean(reader(2))
																															Me.comboHour17.Text = reader(3).ToString()
																															Me.comboMin17.Text = reader(4).ToString()
																															Me.chkCon17.Checked = Conversions.ToBoolean(reader(5))
																															Me.comboSoundCon17.Text = reader(6).ToString()
																															Me.comboSoundConEng17.Text = reader(7).ToString()
																															Me.chkLast17.Checked = Conversions.ToBoolean(reader(8))
																														Else
																															flag2 = Conversions.ToInteger(reader(0)) = 186
																															If flag2 Then
																																Me.chkFirst18.Checked = Conversions.ToBoolean(reader(1))
																																Me.chkTime18.Checked = Conversions.ToBoolean(reader(2))
																																Me.comboHour18.Text = reader(3).ToString()
																																Me.comboMin18.Text = reader(4).ToString()
																																Me.chkCon18.Checked = Conversions.ToBoolean(reader(5))
																																Me.comboSoundCon18.Text = reader(6).ToString()
																																Me.comboSoundConEng18.Text = reader(7).ToString()
																																Me.chkLast18.Checked = Conversions.ToBoolean(reader(8))
																															Else
																																flag2 = Conversions.ToInteger(reader(0)) = 187
																																If flag2 Then
																																	Me.chkFirst19.Checked = Conversions.ToBoolean(reader(1))
																																	Me.chkTime19.Checked = Conversions.ToBoolean(reader(2))
																																	Me.comboHour19.Text = reader(3).ToString()
																																	Me.comboMin19.Text = reader(4).ToString()
																																	Me.chkCon19.Checked = Conversions.ToBoolean(reader(5))
																																	Me.comboSoundCon19.Text = reader(6).ToString()
																																	Me.comboSoundConEng19.Text = reader(7).ToString()
																																	Me.chkLast19.Checked = Conversions.ToBoolean(reader(8))
																																Else
																																	flag2 = Conversions.ToInteger(reader(0)) = 188
																																	If flag2 Then
																																		Me.chkFirst20.Checked = Conversions.ToBoolean(reader(1))
																																		Me.chkTime20.Checked = Conversions.ToBoolean(reader(2))
																																		Me.comboHour20.Text = reader(3).ToString()
																																		Me.comboMin20.Text = reader(4).ToString()
																																		Me.chkCon20.Checked = Conversions.ToBoolean(reader(5))
																																		Me.comboSoundCon20.Text = reader(6).ToString()
																																		Me.comboSoundConEng20.Text = reader(7).ToString()
																																		Me.chkLast20.Checked = Conversions.ToBoolean(reader(8))
																																	Else
																																		flag2 = Conversions.ToInteger(reader(0)) = 189
																																		If flag2 Then
																																			Me.chkFirst21.Checked = Conversions.ToBoolean(reader(1))
																																			Me.chkTime21.Checked = Conversions.ToBoolean(reader(2))
																																			Me.comboHour21.Text = reader(3).ToString()
																																			Me.comboMin21.Text = reader(4).ToString()
																																			Me.chkCon21.Checked = Conversions.ToBoolean(reader(5))
																																			Me.comboSoundCon21.Text = reader(6).ToString()
																																			Me.comboSoundConEng21.Text = reader(7).ToString()
																																			Me.chkLast21.Checked = Conversions.ToBoolean(reader(8))
																																		Else
																																			flag2 = Conversions.ToInteger(reader(0)) = 190
																																			If flag2 Then
																																				Me.chkFirst22.Checked = Conversions.ToBoolean(reader(1))
																																				Me.chkTime22.Checked = Conversions.ToBoolean(reader(2))
																																				Me.comboHour22.Text = reader(3).ToString()
																																				Me.comboMin22.Text = reader(4).ToString()
																																				Me.chkCon22.Checked = Conversions.ToBoolean(reader(5))
																																				Me.comboSoundCon22.Text = reader(6).ToString()
																																				Me.comboSoundConEng22.Text = reader(7).ToString()
																																				Me.chkLast22.Checked = Conversions.ToBoolean(reader(8))
																																			Else
																																				flag2 = Conversions.ToInteger(reader(0)) = 191
																																				If flag2 Then
																																					Me.chkFirst23.Checked = Conversions.ToBoolean(reader(1))
																																					Me.chkTime23.Checked = Conversions.ToBoolean(reader(2))
																																					Me.comboHour23.Text = reader(3).ToString()
																																					Me.comboMin23.Text = reader(4).ToString()
																																					Me.chkCon23.Checked = Conversions.ToBoolean(reader(5))
																																					Me.comboSoundCon23.Text = reader(6).ToString()
																																					Me.comboSoundConEng23.Text = reader(7).ToString()
																																					Me.chkLast23.Checked = Conversions.ToBoolean(reader(8))
																																				Else
																																					flag2 = Conversions.ToInteger(reader(0)) = 192
																																					If flag2 Then
																																						Me.chkFirst24.Checked = Conversions.ToBoolean(reader(1))
																																						Me.chkTime24.Checked = Conversions.ToBoolean(reader(2))
																																						Me.comboHour24.Text = reader(3).ToString()
																																						Me.comboMin24.Text = reader(4).ToString()
																																						Me.chkCon24.Checked = Conversions.ToBoolean(reader(5))
																																						Me.comboSoundCon24.Text = reader(6).ToString()
																																						Me.comboSoundConEng24.Text = reader(7).ToString()
																																						Me.chkLast24.Checked = Conversions.ToBoolean(reader(8))
																																					End If
																																				End If
																																			End If
																																		End If
																																	End If
																																End If
																															End If
																														End If
																													End If
																												End If
																											End If
																										End If
																									End If
																								End If
																							End If
																						End If
																					End If
																				End If
																			End If
																		End If
																	End If
																End If
															End If
														End If
													End While
												End If
											End If
										End If
									End If
								End If
							End If
						End If
					End If
				End If
				Conn.Close()
			Catch ex As Exception
				Interaction.MsgBox("ERROR : " + ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
		End Sub

		' Token: 0x060002A8 RID: 680 RVA: 0x00027A70 File Offset: 0x00025E70
		Private Sub btnSave_Click(sender As Object, e As EventArgs)
			Dim id As Integer() = New Integer(23) {}
			Dim flag As Boolean = Me.radioAllDay.Checked
			Dim rd As Integer
			If flag Then
				Dim i As Integer = 1
				Dim num As Integer
				Dim num2 As Integer
				Do
					id(i - 1) = i + 168
					i += 1
					num = i
					num2 = 24
				Loop While num <= num2
				rd = 1
			Else
				rd = 0
				flag = Me.radioSun.Checked
				If flag Then
					Dim j As Integer = 1
					Dim num2 As Integer
					Dim num3 As Integer
					Do
						id(j - 1) = j + 0
						j += 1
						num3 = j
						num2 = 24
					Loop While num3 <= num2
				Else
					flag = Me.radioMon.Checked
					If flag Then
						Dim k As Integer = 1
						Dim num2 As Integer
						Dim num4 As Integer
						Do
							id(k - 1) = k + 24
							k += 1
							num4 = k
							num2 = 24
						Loop While num4 <= num2
					Else
						flag = Me.radioTue.Checked
						If flag Then
							Dim l As Integer = 1
							Dim num2 As Integer
							Dim num5 As Integer
							Do
								id(l - 1) = l + 48
								l += 1
								num5 = l
								num2 = 24
							Loop While num5 <= num2
						Else
							flag = Me.radioWed.Checked
							If flag Then
								Dim m As Integer = 1
								Dim num2 As Integer
								Dim num6 As Integer
								Do
									id(m - 1) = m + 72
									m += 1
									num6 = m
									num2 = 24
								Loop While num6 <= num2
							Else
								flag = Me.radioThu.Checked
								If flag Then
									Dim n As Integer = 1
									Dim num2 As Integer
									Dim num7 As Integer
									Do
										id(n - 1) = n + 96
										n += 1
										num7 = n
										num2 = 24
									Loop While num7 <= num2
								Else
									flag = Me.radioFri.Checked
									If flag Then
										Dim i2 As Integer = 1
										Dim num2 As Integer
										Dim num8 As Integer
										Do
											id(i2 - 1) = i2 + 120
											i2 += 1
											num8 = i2
											num2 = 24
										Loop While num8 <= num2
									Else
										flag = Me.radioSat.Checked
										If flag Then
											Dim i3 As Integer = 1
											Dim num2 As Integer
											Dim num9 As Integer
											Do
												id(i3 - 1) = i3 + 144
												i3 += 1
												num9 = i3
												num2 = 24
											Loop While num9 <= num2
										End If
									End If
								End If
							End If
						End If
					End If
				End If
			End If
			flag = Not Me.chkThai.Checked And Not Me.chkEng.Checked
			If flag Then
				Interaction.MsgBox("Please choose language one! กรุณาเลือกภาษา!", MsgBoxStyle.OkOnly, "เลือกภาษา")
			Else
				flag = Interaction.MsgBox("Do you want to save? ต้องการบันทึกข้อมูลใช่หรือไม่?", MsgBoxStyle.YesNo, "บันทึกข้อมูล") = MsgBoxResult.Yes
				If flag Then
					Try
						Dim strConn As String = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\db.accdb; Persist Security Info=False; Jet OLEDB:Database Password='toona201'"
						Dim Conn As OleDbConnection = New OleDbConnection(strConn)
						Conn.Open()
						Dim strSQLSetting As String = "UPDATE normal_setting SET settingSelect=" + Conversions.ToString(CInt(Me.chkThai.CheckState)) + " WHERE settingID = 1"
						Dim strSQLSetting2 As String = "UPDATE normal_setting SET settingSelect=" + Conversions.ToString(CInt(Me.chkEng.CheckState)) + " WHERE settingID = 2"
						Dim strSQLSetting3 As String = "UPDATE normal_setting SET settingSelect=" + Conversions.ToString(Me.listSoundBell.SelectedIndex) + " WHERE settingID = 3"
						Dim strSQLSetting4 As String = String.Concat(New String() { "UPDATE normal_setting SET settingSelect=", Conversions.ToString(CInt(Me.ckShutDown.CheckState)), ", shutdownHour='", Me.comboHourShutdown.Text, "',shutdownMin='", Me.comboMinShutdown.Text, "' WHERE settingID = 4" })
						Dim strSQLSetting5 As String = "UPDATE normal_setting SET settingSelect=" + Conversions.ToString(Me.listLangDisplay.SelectedIndex) + " WHERE settingID = 5"
						Dim strSQLSetting6 As String = "UPDATE normal_setting SET settingSelect=" + Conversions.ToString(rd) + " WHERE settingID = 7"
						Dim strSQL As String = String.Concat(New String() { "UPDATE normal_time SET soundFirst = '", Conversions.ToString(CInt(Me.chkFirst1.CheckState)), "', soundTime = '", Conversions.ToString(CInt(Me.chkTime1.CheckState)), "',timeHour='", Me.comboHour1.Text, "' , timeMin='", Me.comboMin1.Text, "' , soundCon=", Conversions.ToString(CInt(Me.chkCon1.CheckState)), ",soundData='", Me.comboSoundCon1.Text, "', soundDataEng='", Me.comboSoundConEng1.Text, "', soundLast=", Conversions.ToString(CInt(Me.chkLast1.CheckState)), " WHERE pptimerID = ", Conversions.ToString(id(0)) })
						Dim strSQL2 As String = String.Concat(New String() { "UPDATE normal_time SET soundFirst = '", Conversions.ToString(CInt(Me.chkFirst2.CheckState)), "', soundTime = '", Conversions.ToString(CInt(Me.chkTime2.CheckState)), "',timeHour='", Me.comboHour2.Text, "' , timeMin='", Me.comboMin2.Text, "' , soundCon=", Conversions.ToString(CInt(Me.chkCon2.CheckState)), ",soundData='", Me.comboSoundCon2.Text, "', soundDataEng='", Me.comboSoundConEng2.Text, "', soundLast=", Conversions.ToString(CInt(Me.chkLast2.CheckState)), " WHERE pptimerID = ", Conversions.ToString(id(1)) })
						Dim strSQL3 As String = String.Concat(New String() { "UPDATE normal_time SET soundFirst = '", Conversions.ToString(CInt(Me.chkFirst3.CheckState)), "', soundTime = '", Conversions.ToString(CInt(Me.chkTime3.CheckState)), "',timeHour='", Me.comboHour3.Text, "' , timeMin='", Me.comboMin3.Text, "' , soundCon=", Conversions.ToString(CInt(Me.chkCon3.CheckState)), ",soundData='", Me.comboSoundCon3.Text, "', soundDataEng='", Me.comboSoundConEng3.Text, "', soundLast=", Conversions.ToString(CInt(Me.chkLast3.CheckState)), " WHERE pptimerID = ", Conversions.ToString(id(2)) })
						Dim strSQL4 As String = String.Concat(New String() { "UPDATE normal_time SET soundFirst = '", Conversions.ToString(CInt(Me.chkFirst4.CheckState)), "', soundTime = '", Conversions.ToString(CInt(Me.chkTime4.CheckState)), "',timeHour='", Me.comboHour4.Text, "' , timeMin='", Me.comboMin4.Text, "' , soundCon=", Conversions.ToString(CInt(Me.chkCon4.CheckState)), ",soundData='", Me.comboSoundCon4.Text, "', soundDataEng='", Me.comboSoundConEng4.Text, "', soundLast=", Conversions.ToString(CInt(Me.chkLast4.CheckState)), " WHERE pptimerID = ", Conversions.ToString(id(3)) })
						Dim strSQL5 As String = String.Concat(New String() { "UPDATE normal_time SET soundFirst = '", Conversions.ToString(CInt(Me.chkFirst5.CheckState)), "', soundTime = '", Conversions.ToString(CInt(Me.chkTime5.CheckState)), "',timeHour='", Me.comboHour5.Text, "' , timeMin='", Me.comboMin5.Text, "' , soundCon=", Conversions.ToString(CInt(Me.chkCon5.CheckState)), ",soundData='", Me.comboSoundCon5.Text, "', soundDataEng='", Me.comboSoundConEng5.Text, "', soundLast=", Conversions.ToString(CInt(Me.chkLast5.CheckState)), " WHERE pptimerID = ", Conversions.ToString(id(4)) })
						Dim strSQL6 As String = String.Concat(New String() { "UPDATE normal_time SET soundFirst = '", Conversions.ToString(CInt(Me.chkFirst6.CheckState)), "', soundTime = '", Conversions.ToString(CInt(Me.chkTime6.CheckState)), "',timeHour='", Me.comboHour6.Text, "' , timeMin='", Me.comboMin6.Text, "' , soundCon=", Conversions.ToString(CInt(Me.chkCon6.CheckState)), ",soundData='", Me.comboSoundCon6.Text, "', soundDataEng='", Me.comboSoundConEng6.Text, "', soundLast=", Conversions.ToString(CInt(Me.chkLast6.CheckState)), " WHERE pptimerID = ", Conversions.ToString(id(5)) })
						Dim strSQL7 As String = String.Concat(New String() { "UPDATE normal_time SET soundFirst = '", Conversions.ToString(CInt(Me.chkFirst7.CheckState)), "', soundTime = '", Conversions.ToString(CInt(Me.chkTime7.CheckState)), "',timeHour='", Me.comboHour7.Text, "' , timeMin='", Me.comboMin7.Text, "' , soundCon=", Conversions.ToString(CInt(Me.chkCon7.CheckState)), ",soundData='", Me.comboSoundCon7.Text, "', soundDataEng='", Me.comboSoundConEng7.Text, "', soundLast=", Conversions.ToString(CInt(Me.chkLast7.CheckState)), " WHERE pptimerID = ", Conversions.ToString(id(6)) })
						Dim strSQL8 As String = String.Concat(New String() { "UPDATE normal_time SET soundFirst = '", Conversions.ToString(CInt(Me.chkFirst8.CheckState)), "', soundTime = '", Conversions.ToString(CInt(Me.chkTime8.CheckState)), "',timeHour='", Me.comboHour8.Text, "' , timeMin='", Me.comboMin8.Text, "' , soundCon=", Conversions.ToString(CInt(Me.chkCon8.CheckState)), ",soundData='", Me.comboSoundCon8.Text, "', soundDataEng='", Me.comboSoundConEng8.Text, "', soundLast=", Conversions.ToString(CInt(Me.chkLast8.CheckState)), " WHERE pptimerID = ", Conversions.ToString(id(7)) })
						Dim strSQL9 As String = String.Concat(New String() { "UPDATE normal_time SET soundFirst = '", Conversions.ToString(CInt(Me.chkFirst9.CheckState)), "', soundTime = '", Conversions.ToString(CInt(Me.chkTime9.CheckState)), "',timeHour='", Me.comboHour9.Text, "' , timeMin='", Me.comboMin9.Text, "' , soundCon=", Conversions.ToString(CInt(Me.chkCon9.CheckState)), ",soundData='", Me.comboSoundCon9.Text, "', soundDataEng='", Me.comboSoundConEng9.Text, "', soundLast=", Conversions.ToString(CInt(Me.chkLast9.CheckState)), " WHERE pptimerID = ", Conversions.ToString(id(8)) })
						Dim strSQL10 As String = String.Concat(New String() { "UPDATE normal_time SET soundFirst = '", Conversions.ToString(CInt(Me.chkFirst10.CheckState)), "', soundTime = '", Conversions.ToString(CInt(Me.chkTime10.CheckState)), "',timeHour='", Me.comboHour10.Text, "' , timeMin='", Me.comboMin10.Text, "' , soundCon=", Conversions.ToString(CInt(Me.chkCon10.CheckState)), ",soundData='", Me.comboSoundCon10.Text, "', soundDataEng='", Me.comboSoundConEng10.Text, "', soundLast=", Conversions.ToString(CInt(Me.chkLast10.CheckState)), " WHERE pptimerID = ", Conversions.ToString(id(9)) })
						Dim strSQL11 As String = String.Concat(New String() { "UPDATE normal_time SET soundFirst = '", Conversions.ToString(CInt(Me.chkFirst11.CheckState)), "', soundTime = '", Conversions.ToString(CInt(Me.chkTime11.CheckState)), "',timeHour='", Me.comboHour11.Text, "' , timeMin='", Me.comboMin11.Text, "' , soundCon=", Conversions.ToString(CInt(Me.chkCon11.CheckState)), ",soundData='", Me.comboSoundCon11.Text, "', soundDataEng='", Me.comboSoundConEng11.Text, "', soundLast=", Conversions.ToString(CInt(Me.chkLast11.CheckState)), " WHERE pptimerID = ", Conversions.ToString(id(10)) })
						Dim strSQL12 As String = String.Concat(New String() { "UPDATE normal_time SET soundFirst = '", Conversions.ToString(CInt(Me.chkFirst12.CheckState)), "', soundTime = '", Conversions.ToString(CInt(Me.chkTime12.CheckState)), "',timeHour='", Me.comboHour12.Text, "' , timeMin='", Me.comboMin12.Text, "' , soundCon=", Conversions.ToString(CInt(Me.chkCon12.CheckState)), ",soundData='", Me.comboSoundCon12.Text, "', soundDataEng='", Me.comboSoundConEng12.Text, "', soundLast=", Conversions.ToString(CInt(Me.chkLast12.CheckState)), " WHERE pptimerID = ", Conversions.ToString(id(11)) })
						Dim strSQL13 As String = String.Concat(New String() { "UPDATE normal_time SET soundFirst = '", Conversions.ToString(CInt(Me.chkFirst13.CheckState)), "', soundTime = '", Conversions.ToString(CInt(Me.chkTime13.CheckState)), "',timeHour='", Me.comboHour13.Text, "' , timeMin='", Me.comboMin13.Text, "' , soundCon=", Conversions.ToString(CInt(Me.chkCon13.CheckState)), ",soundData='", Me.comboSoundCon13.Text, "', soundDataEng='", Me.comboSoundConEng13.Text, "', soundLast=", Conversions.ToString(CInt(Me.chkLast13.CheckState)), " WHERE pptimerID = ", Conversions.ToString(id(12)) })
						Dim strSQL14 As String = String.Concat(New String() { "UPDATE normal_time SET soundFirst = '", Conversions.ToString(CInt(Me.chkFirst14.CheckState)), "', soundTime = '", Conversions.ToString(CInt(Me.chkTime14.CheckState)), "',timeHour='", Me.comboHour14.Text, "' , timeMin='", Me.comboMin14.Text, "' , soundCon=", Conversions.ToString(CInt(Me.chkCon14.CheckState)), ",soundData='", Me.comboSoundCon14.Text, "', soundDataEng='", Me.comboSoundConEng14.Text, "', soundLast=", Conversions.ToString(CInt(Me.chkLast14.CheckState)), " WHERE pptimerID = ", Conversions.ToString(id(13)) })
						Dim strSQL15 As String = String.Concat(New String() { "UPDATE normal_time SET soundFirst = '", Conversions.ToString(CInt(Me.chkFirst15.CheckState)), "', soundTime = '", Conversions.ToString(CInt(Me.chkTime15.CheckState)), "',timeHour='", Me.comboHour15.Text, "' , timeMin='", Me.comboMin15.Text, "' , soundCon=", Conversions.ToString(CInt(Me.chkCon15.CheckState)), ",soundData='", Me.comboSoundCon15.Text, "', soundDataEng='", Me.comboSoundConEng15.Text, "', soundLast=", Conversions.ToString(CInt(Me.chkLast15.CheckState)), " WHERE pptimerID = ", Conversions.ToString(id(14)) })
						Dim strSQL16 As String = String.Concat(New String() { "UPDATE normal_time SET soundFirst = '", Conversions.ToString(CInt(Me.chkFirst16.CheckState)), "', soundTime = '", Conversions.ToString(CInt(Me.chkTime16.CheckState)), "',timeHour='", Me.comboHour16.Text, "' , timeMin='", Me.comboMin16.Text, "' , soundCon=", Conversions.ToString(CInt(Me.chkCon16.CheckState)), ",soundData='", Me.comboSoundCon16.Text, "', soundDataEng='", Me.comboSoundConEng16.Text, "', soundLast=", Conversions.ToString(CInt(Me.chkLast16.CheckState)), " WHERE pptimerID = ", Conversions.ToString(id(15)) })
						Dim strSQL17 As String = String.Concat(New String() { "UPDATE normal_time SET soundFirst = '", Conversions.ToString(CInt(Me.chkFirst17.CheckState)), "', soundTime = '", Conversions.ToString(CInt(Me.chkTime17.CheckState)), "',timeHour='", Me.comboHour17.Text, "' , timeMin='", Me.comboMin17.Text, "' , soundCon=", Conversions.ToString(CInt(Me.chkCon17.CheckState)), ",soundData='", Me.comboSoundCon17.Text, "', soundDataEng='", Me.comboSoundConEng17.Text, "', soundLast=", Conversions.ToString(CInt(Me.chkLast17.CheckState)), " WHERE pptimerID = ", Conversions.ToString(id(16)) })
						Dim strSQL18 As String = String.Concat(New String() { "UPDATE normal_time SET soundFirst = '", Conversions.ToString(CInt(Me.chkFirst18.CheckState)), "', soundTime = '", Conversions.ToString(CInt(Me.chkTime18.CheckState)), "',timeHour='", Me.comboHour18.Text, "' , timeMin='", Me.comboMin18.Text, "' , soundCon=", Conversions.ToString(CInt(Me.chkCon18.CheckState)), ",soundData='", Me.comboSoundCon18.Text, "', soundDataEng='", Me.comboSoundConEng18.Text, "', soundLast=", Conversions.ToString(CInt(Me.chkLast18.CheckState)), " WHERE pptimerID = ", Conversions.ToString(id(17)) })
						Dim strSQL19 As String = String.Concat(New String() { "UPDATE normal_time SET soundFirst = '", Conversions.ToString(CInt(Me.chkFirst19.CheckState)), "', soundTime = '", Conversions.ToString(CInt(Me.chkTime19.CheckState)), "',timeHour='", Me.comboHour19.Text, "' , timeMin='", Me.comboMin19.Text, "' , soundCon=", Conversions.ToString(CInt(Me.chkCon19.CheckState)), ",soundData='", Me.comboSoundCon19.Text, "', soundDataEng='", Me.comboSoundConEng19.Text, "', soundLast=", Conversions.ToString(CInt(Me.chkLast19.CheckState)), " WHERE pptimerID = ", Conversions.ToString(id(18)) })
						Dim strSQL20 As String = String.Concat(New String() { "UPDATE normal_time SET soundFirst = '", Conversions.ToString(CInt(Me.chkFirst20.CheckState)), "', soundTime = '", Conversions.ToString(CInt(Me.chkTime20.CheckState)), "',timeHour='", Me.comboHour20.Text, "' , timeMin='", Me.comboMin20.Text, "' , soundCon=", Conversions.ToString(CInt(Me.chkCon20.CheckState)), ",soundData='", Me.comboSoundCon20.Text, "', soundDataEng='", Me.comboSoundConEng20.Text, "', soundLast=", Conversions.ToString(CInt(Me.chkLast20.CheckState)), " WHERE pptimerID = ", Conversions.ToString(id(19)) })
						Dim strSQL21 As String = String.Concat(New String() { "UPDATE normal_time SET soundFirst = '", Conversions.ToString(CInt(Me.chkFirst21.CheckState)), "', soundTime = '", Conversions.ToString(CInt(Me.chkTime21.CheckState)), "',timeHour='", Me.comboHour21.Text, "' , timeMin='", Me.comboMin21.Text, "' , soundCon=", Conversions.ToString(CInt(Me.chkCon21.CheckState)), ",soundData='", Me.comboSoundCon21.Text, "', soundDataEng='", Me.comboSoundConEng21.Text, "', soundLast=", Conversions.ToString(CInt(Me.chkLast21.CheckState)), " WHERE pptimerID = ", Conversions.ToString(id(20)) })
						Dim strSQL22 As String = String.Concat(New String() { "UPDATE normal_time SET soundFirst = '", Conversions.ToString(CInt(Me.chkFirst22.CheckState)), "', soundTime = '", Conversions.ToString(CInt(Me.chkTime22.CheckState)), "',timeHour='", Me.comboHour22.Text, "' , timeMin='", Me.comboMin22.Text, "' , soundCon=", Conversions.ToString(CInt(Me.chkCon22.CheckState)), ",soundData='", Me.comboSoundCon22.Text, "', soundDataEng='", Me.comboSoundConEng22.Text, "', soundLast=", Conversions.ToString(CInt(Me.chkLast22.CheckState)), " WHERE pptimerID = ", Conversions.ToString(id(21)) })
						Dim strSQL23 As String = String.Concat(New String() { "UPDATE normal_time SET soundFirst = '", Conversions.ToString(CInt(Me.chkFirst23.CheckState)), "', soundTime = '", Conversions.ToString(CInt(Me.chkTime23.CheckState)), "',timeHour='", Me.comboHour23.Text, "' , timeMin='", Me.comboMin23.Text, "' , soundCon=", Conversions.ToString(CInt(Me.chkCon23.CheckState)), ",soundData='", Me.comboSoundCon23.Text, "', soundDataEng='", Me.comboSoundConEng23.Text, "', soundLast=", Conversions.ToString(CInt(Me.chkLast23.CheckState)), " WHERE pptimerID = ", Conversions.ToString(id(22)) })
						Dim strSQL24 As String = String.Concat(New String() { "UPDATE normal_time SET soundFirst = '", Conversions.ToString(CInt(Me.chkFirst24.CheckState)), "', soundTime = '", Conversions.ToString(CInt(Me.chkTime24.CheckState)), "',timeHour='", Me.comboHour24.Text, "' , timeMin='", Me.comboMin24.Text, "' , soundCon=", Conversions.ToString(CInt(Me.chkCon24.CheckState)), ",soundData='", Me.comboSoundCon24.Text, "', soundDataEng='", Me.comboSoundConEng24.Text, "', soundLast=", Conversions.ToString(CInt(Me.chkLast24.CheckState)), " WHERE pptimerID = ", Conversions.ToString(id(23)) })
						Dim cmd As OleDbCommand = New OleDbCommand(strSQLSetting, Conn)
						cmd.ExecuteNonQuery()
						cmd = New OleDbCommand(strSQLSetting2, Conn)
						cmd.ExecuteNonQuery()
						cmd = New OleDbCommand(strSQLSetting3, Conn)
						cmd.ExecuteNonQuery()
						cmd = New OleDbCommand(strSQLSetting4, Conn)
						cmd.ExecuteNonQuery()
						cmd = New OleDbCommand(strSQLSetting5, Conn)
						cmd.ExecuteNonQuery()
						cmd = New OleDbCommand(strSQLSetting6, Conn)
						cmd.ExecuteNonQuery()
						cmd = New OleDbCommand(strSQL, Conn)
						cmd.ExecuteNonQuery()
						cmd = New OleDbCommand(strSQL2, Conn)
						cmd.ExecuteNonQuery()
						cmd = New OleDbCommand(strSQL3, Conn)
						cmd.ExecuteNonQuery()
						cmd = New OleDbCommand(strSQL4, Conn)
						cmd.ExecuteNonQuery()
						cmd = New OleDbCommand(strSQL5, Conn)
						cmd.ExecuteNonQuery()
						cmd = New OleDbCommand(strSQL6, Conn)
						cmd.ExecuteNonQuery()
						cmd = New OleDbCommand(strSQL7, Conn)
						cmd.ExecuteNonQuery()
						cmd = New OleDbCommand(strSQL8, Conn)
						cmd.ExecuteNonQuery()
						cmd = New OleDbCommand(strSQL9, Conn)
						cmd.ExecuteNonQuery()
						cmd = New OleDbCommand(strSQL10, Conn)
						cmd.ExecuteNonQuery()
						cmd = New OleDbCommand(strSQL11, Conn)
						cmd.ExecuteNonQuery()
						cmd = New OleDbCommand(strSQL12, Conn)
						cmd.ExecuteNonQuery()
						cmd = New OleDbCommand(strSQL13, Conn)
						cmd.ExecuteNonQuery()
						cmd = New OleDbCommand(strSQL14, Conn)
						cmd.ExecuteNonQuery()
						cmd = New OleDbCommand(strSQL15, Conn)
						cmd.ExecuteNonQuery()
						cmd = New OleDbCommand(strSQL16, Conn)
						cmd.ExecuteNonQuery()
						cmd = New OleDbCommand(strSQL17, Conn)
						cmd.ExecuteNonQuery()
						cmd = New OleDbCommand(strSQL18, Conn)
						cmd.ExecuteNonQuery()
						cmd = New OleDbCommand(strSQL19, Conn)
						cmd.ExecuteNonQuery()
						cmd = New OleDbCommand(strSQL20, Conn)
						cmd.ExecuteNonQuery()
						cmd = New OleDbCommand(strSQL21, Conn)
						cmd.ExecuteNonQuery()
						cmd = New OleDbCommand(strSQL22, Conn)
						cmd.ExecuteNonQuery()
						cmd = New OleDbCommand(strSQL23, Conn)
						cmd.ExecuteNonQuery()
						cmd = New OleDbCommand(strSQL24, Conn)
						cmd.ExecuteNonQuery()
						Conn.Close()
						Me.editClose()
						Me.loadSetting()
						Dim chkday As Integer = Me.getSettingDay()
						flag = chkday = 1
						If flag Then
							Me.loadData(8)
							Me.radioAllDay.Checked = True
							Me.PanelEachDay.Visible = False
							Me.BackColor = Color.White
						Else
							Me.radioEachDay.Checked = True
							Me.PanelEachDay.Visible = True
							Me.loadDay()
						End If
					Catch ex As Exception
						Interaction.MsgBox("ERROR : " + ex.Message, MsgBoxStyle.OkOnly, Nothing)
					End Try
				End If
			End If
		End Sub

		' Token: 0x060002A9 RID: 681 RVA: 0x00029ACC File Offset: 0x00027ECC
		Public Sub editOpen()
			Me.Timer2.[Stop]()
			Me.PanelEachDay.Enabled = True
			Me.panelAllDay.Enabled = True
			Me.PanelTime.Enabled = True
			Me.panelSetting.Enabled = True
			Me.lblSuguest.Visible = True
			Me.chkThai.Enabled = True
			Me.btnEdit.Enabled = False
			Me.btnExit.Enabled = False
			Me.btnSave.Enabled = True
			Me.btnCancel.Enabled = True
			Me.btnReset.Enabled = True
			Dim flag As Boolean = Me.chkCon1.Checked
			If flag Then
				Me.comboSoundCon1.Enabled = True
				Me.comboSoundConEng1.Enabled = True
				Me.btnPlay1.Enabled = True
			Else
				Me.comboSoundCon1.Enabled = False
				Me.comboSoundConEng1.Enabled = False
				Me.btnPlay1.Enabled = False
			End If
			flag = Me.chkCon2.Checked
			If flag Then
				Me.comboSoundCon2.Enabled = True
				Me.comboSoundConEng2.Enabled = True
				Me.btnPlay2.Enabled = True
			Else
				Me.comboSoundCon2.Enabled = False
				Me.comboSoundConEng2.Enabled = False
				Me.btnPlay2.Enabled = False
			End If
			flag = Me.chkCon3.Checked
			If flag Then
				Me.comboSoundCon3.Enabled = True
				Me.comboSoundConEng3.Enabled = True
				Me.btnPlay3.Enabled = True
			Else
				Me.comboSoundCon3.Enabled = False
				Me.comboSoundConEng3.Enabled = False
				Me.btnPlay3.Enabled = False
			End If
			flag = Me.chkCon4.Checked
			If flag Then
				Me.comboSoundCon4.Enabled = True
				Me.comboSoundConEng4.Enabled = True
				Me.btnPlay4.Enabled = True
			Else
				Me.comboSoundCon4.Enabled = False
				Me.comboSoundConEng4.Enabled = False
				Me.btnPlay4.Enabled = False
			End If
			flag = Me.chkCon5.Checked
			If flag Then
				Me.comboSoundCon5.Enabled = True
				Me.comboSoundConEng5.Enabled = True
				Me.btnPlay5.Enabled = True
			Else
				Me.comboSoundCon5.Enabled = False
				Me.comboSoundConEng5.Enabled = False
				Me.btnPlay5.Enabled = False
			End If
			flag = Me.chkCon6.Checked
			If flag Then
				Me.comboSoundCon6.Enabled = True
				Me.comboSoundConEng6.Enabled = True
				Me.btnPlay6.Enabled = True
			Else
				Me.comboSoundCon6.Enabled = False
				Me.comboSoundConEng6.Enabled = False
				Me.btnPlay6.Enabled = False
			End If
			flag = Me.chkCon7.Checked
			If flag Then
				Me.comboSoundCon7.Enabled = True
				Me.comboSoundConEng7.Enabled = True
				Me.btnPlay7.Enabled = True
			Else
				Me.comboSoundCon7.Enabled = False
				Me.comboSoundConEng7.Enabled = False
				Me.btnPlay7.Enabled = False
			End If
			flag = Me.chkCon8.Checked
			If flag Then
				Me.comboSoundCon8.Enabled = True
				Me.comboSoundConEng8.Enabled = True
				Me.btnPlay8.Enabled = True
			Else
				Me.comboSoundCon8.Enabled = False
				Me.comboSoundConEng8.Enabled = False
				Me.btnPlay8.Enabled = False
			End If
			flag = Me.chkCon9.Checked
			If flag Then
				Me.comboSoundCon9.Enabled = True
				Me.comboSoundConEng9.Enabled = True
				Me.btnPlay9.Enabled = True
			Else
				Me.comboSoundCon9.Enabled = False
				Me.comboSoundConEng9.Enabled = False
				Me.btnPlay9.Enabled = False
			End If
			flag = Me.chkCon10.Checked
			If flag Then
				Me.comboSoundCon10.Enabled = True
				Me.comboSoundConEng10.Enabled = True
				Me.btnPlay10.Enabled = True
			Else
				Me.comboSoundCon10.Enabled = False
				Me.comboSoundConEng10.Enabled = False
				Me.btnPlay10.Enabled = False
			End If
			flag = Me.chkCon11.Checked
			If flag Then
				Me.comboSoundCon11.Enabled = True
				Me.comboSoundConEng11.Enabled = True
				Me.btnPlay11.Enabled = True
			Else
				Me.comboSoundCon11.Enabled = False
				Me.comboSoundConEng11.Enabled = False
				Me.btnPlay11.Enabled = False
			End If
			flag = Me.chkCon12.Checked
			If flag Then
				Me.comboSoundCon12.Enabled = True
				Me.comboSoundConEng12.Enabled = True
				Me.btnPlay12.Enabled = True
			Else
				Me.comboSoundCon12.Enabled = False
				Me.comboSoundConEng12.Enabled = False
				Me.btnPlay12.Enabled = False
			End If
			flag = Me.chkCon13.Checked
			If flag Then
				Me.comboSoundCon13.Enabled = True
				Me.comboSoundConEng13.Enabled = True
				Me.btnPlay13.Enabled = True
			Else
				Me.comboSoundCon13.Enabled = False
				Me.comboSoundConEng13.Enabled = False
				Me.btnPlay13.Enabled = False
			End If
			flag = Me.chkCon14.Checked
			If flag Then
				Me.comboSoundCon14.Enabled = True
				Me.comboSoundConEng14.Enabled = True
				Me.btnPlay14.Enabled = True
			Else
				Me.comboSoundCon14.Enabled = False
				Me.comboSoundConEng14.Enabled = False
				Me.btnPlay14.Enabled = False
			End If
			flag = Me.chkCon15.Checked
			If flag Then
				Me.comboSoundCon15.Enabled = True
				Me.comboSoundConEng15.Enabled = True
				Me.btnPlay15.Enabled = True
			Else
				Me.comboSoundCon15.Enabled = False
				Me.comboSoundConEng15.Enabled = False
				Me.btnPlay15.Enabled = False
			End If
			flag = Me.chkCon16.Checked
			If flag Then
				Me.comboSoundCon16.Enabled = True
				Me.comboSoundConEng16.Enabled = True
				Me.btnPlay16.Enabled = True
			Else
				Me.comboSoundCon16.Enabled = False
				Me.comboSoundConEng16.Enabled = False
				Me.btnPlay16.Enabled = False
			End If
			flag = Me.chkCon17.Checked
			If flag Then
				Me.comboSoundCon17.Enabled = True
				Me.comboSoundConEng17.Enabled = True
				Me.btnPlay17.Enabled = True
			Else
				Me.comboSoundCon17.Enabled = False
				Me.comboSoundConEng17.Enabled = False
				Me.btnPlay17.Enabled = False
			End If
			flag = Me.chkCon18.Checked
			If flag Then
				Me.comboSoundCon18.Enabled = True
				Me.comboSoundConEng18.Enabled = True
				Me.btnPlay18.Enabled = True
			Else
				Me.comboSoundCon18.Enabled = False
				Me.comboSoundConEng18.Enabled = False
				Me.btnPlay18.Enabled = False
			End If
			flag = Me.chkCon19.Checked
			If flag Then
				Me.comboSoundCon19.Enabled = True
				Me.comboSoundConEng19.Enabled = True
				Me.btnPlay19.Enabled = True
			Else
				Me.comboSoundCon19.Enabled = False
				Me.comboSoundConEng19.Enabled = False
				Me.btnPlay19.Enabled = False
			End If
			flag = Me.chkCon20.Checked
			If flag Then
				Me.comboSoundCon20.Enabled = True
				Me.comboSoundConEng20.Enabled = True
				Me.btnPlay20.Enabled = True
			Else
				Me.comboSoundCon20.Enabled = False
				Me.comboSoundConEng20.Enabled = False
				Me.btnPlay20.Enabled = False
			End If
			flag = Me.chkCon21.Checked
			If flag Then
				Me.comboSoundCon21.Enabled = True
				Me.comboSoundConEng21.Enabled = True
				Me.btnPlay21.Enabled = True
			Else
				Me.comboSoundCon21.Enabled = False
				Me.comboSoundConEng21.Enabled = False
				Me.btnPlay21.Enabled = False
			End If
			flag = Me.chkCon22.Checked
			If flag Then
				Me.comboSoundCon22.Enabled = True
				Me.comboSoundConEng22.Enabled = True
				Me.btnPlay22.Enabled = True
			Else
				Me.comboSoundCon22.Enabled = False
				Me.comboSoundConEng22.Enabled = False
				Me.btnPlay22.Enabled = False
			End If
			flag = Me.chkCon23.Checked
			If flag Then
				Me.comboSoundCon23.Enabled = True
				Me.comboSoundConEng23.Enabled = True
				Me.btnPlay23.Enabled = True
			Else
				Me.comboSoundCon23.Enabled = False
				Me.comboSoundConEng23.Enabled = False
				Me.btnPlay23.Enabled = False
			End If
			flag = Me.chkCon24.Checked
			If flag Then
				Me.comboSoundCon24.Enabled = True
				Me.comboSoundConEng24.Enabled = True
				Me.btnPlay24.Enabled = True
			Else
				Me.comboSoundCon24.Enabled = False
				Me.comboSoundConEng24.Enabled = False
				Me.btnPlay24.Enabled = False
			End If
		End Sub

		' Token: 0x060002AA RID: 682 RVA: 0x0002A490 File Offset: 0x00028890
		Public Sub editClose()
			Me.Timer2.Start()
			Me.PanelEachDay.Enabled = False
			Me.panelAllDay.Enabled = False
			Me.PanelTime.Enabled = False
			Me.panelSetting.Enabled = False
			Me.btnExit.Enabled = True
			Me.btnSave.Enabled = False
			Me.btnEdit.Enabled = True
			Me.btnCancel.Enabled = False
			Me.btnReset.Enabled = False
			Me.lblSuguest.Visible = False
		End Sub

		' Token: 0x060002AB RID: 683 RVA: 0x0002A530 File Offset: 0x00028930
		Private Sub btnSoundStop_Click(sender As Object, e As EventArgs)
			MyProject.Computer.Audio.[Stop]()
		End Sub

		' Token: 0x060002AC RID: 684 RVA: 0x0002A544 File Offset: 0x00028944
		Private Sub btnSelectSound1_Click(sender As Object, e As EventArgs)
			Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
			openFileDialog.Filter = "Wave Files (*.wav)|*.wav"
			openFileDialog.FilterIndex = 1
			Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
			If flag Then
				For Each file As String In openFileDialog.FileNames
					Me.comboSoundCon1.Text = file
					Me.comboSoundCon1.Focus()
				Next
			End If
		End Sub

		' Token: 0x060002AD RID: 685 RVA: 0x0002A5B8 File Offset: 0x000289B8
		Private Sub btnSelectSound2_Click(sender As Object, e As EventArgs)
			Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
			openFileDialog.Filter = "Wave Files (*.wav)|*.wav"
			openFileDialog.FilterIndex = 1
			Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
			If flag Then
				For Each file As String In openFileDialog.FileNames
					Me.comboSoundCon2.Text = file
					Me.comboSoundCon2.Focus()
				Next
			End If
		End Sub

		' Token: 0x060002AE RID: 686 RVA: 0x0002A62C File Offset: 0x00028A2C
		Private Sub btnSelectSound3_Click(sender As Object, e As EventArgs)
			Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
			openFileDialog.Filter = "Wave Files (*.wav)|*.wav"
			openFileDialog.FilterIndex = 1
			Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
			If flag Then
				For Each file As String In openFileDialog.FileNames
					Me.comboSoundCon3.Text = file
					Me.comboSoundCon3.Focus()
				Next
			End If
		End Sub

		' Token: 0x060002AF RID: 687 RVA: 0x0002A6A0 File Offset: 0x00028AA0
		Private Sub btnSelectSound4_Click(sender As Object, e As EventArgs)
			Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
			openFileDialog.Filter = "Wave Files (*.wav)|*.wav"
			openFileDialog.FilterIndex = 1
			Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
			If flag Then
				For Each file As String In openFileDialog.FileNames
					Me.comboSoundCon4.Text = file
					Me.comboSoundCon4.Focus()
				Next
			End If
		End Sub

		' Token: 0x060002B0 RID: 688 RVA: 0x0002A714 File Offset: 0x00028B14
		Private Sub btnSelectSound5_Click(sender As Object, e As EventArgs)
			Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
			openFileDialog.Filter = "Wave Files (*.wav)|*.wav"
			openFileDialog.FilterIndex = 1
			Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
			If flag Then
				For Each file As String In openFileDialog.FileNames
					Me.comboSoundCon5.Text = file
					Me.comboSoundCon5.Focus()
				Next
			End If
		End Sub

		' Token: 0x060002B1 RID: 689 RVA: 0x0002A788 File Offset: 0x00028B88
		Private Sub btnSelectSound6_Click(sender As Object, e As EventArgs)
			Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
			openFileDialog.Filter = "Wave Files (*.wav)|*.wav"
			openFileDialog.FilterIndex = 1
			Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
			If flag Then
				For Each file As String In openFileDialog.FileNames
					Me.comboSoundCon6.Text = file
					Me.comboSoundCon6.Focus()
				Next
			End If
		End Sub

		' Token: 0x060002B2 RID: 690 RVA: 0x0002A7FC File Offset: 0x00028BFC
		Private Sub btnSelectSound7_Click(sender As Object, e As EventArgs)
			Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
			openFileDialog.Filter = "Wave Files (*.wav)|*.wav"
			openFileDialog.FilterIndex = 1
			Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
			If flag Then
				For Each file As String In openFileDialog.FileNames
					Me.comboSoundCon7.Text = file
					Me.comboSoundCon7.Focus()
				Next
			End If
		End Sub

		' Token: 0x060002B3 RID: 691 RVA: 0x0002A870 File Offset: 0x00028C70
		Private Sub btnSelectSound8_Click(sender As Object, e As EventArgs)
			Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
			openFileDialog.Filter = "Wave Files (*.wav)|*.wav"
			openFileDialog.FilterIndex = 1
			Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
			If flag Then
				For Each file As String In openFileDialog.FileNames
					Me.comboSoundCon8.Text = file
					Me.comboSoundCon8.Focus()
				Next
			End If
		End Sub

		' Token: 0x060002B4 RID: 692 RVA: 0x0002A8E4 File Offset: 0x00028CE4
		Private Sub btnSelectSound9_Click(sender As Object, e As EventArgs)
			Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
			openFileDialog.Filter = "Wave Files (*.wav)|*.wav"
			openFileDialog.FilterIndex = 1
			Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
			If flag Then
				For Each file As String In openFileDialog.FileNames
					Me.comboSoundCon9.Text = file
					Me.comboSoundCon9.Focus()
				Next
			End If
		End Sub

		' Token: 0x060002B5 RID: 693 RVA: 0x0002A958 File Offset: 0x00028D58
		Private Sub btnSelectSound10_Click(sender As Object, e As EventArgs)
			Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
			openFileDialog.Filter = "Wave Files (*.wav)|*.wav"
			openFileDialog.FilterIndex = 1
			Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
			If flag Then
				For Each file As String In openFileDialog.FileNames
					Me.comboSoundCon10.Text = file
					Me.comboSoundCon10.Focus()
				Next
			End If
		End Sub

		' Token: 0x060002B6 RID: 694 RVA: 0x0002A9CC File Offset: 0x00028DCC
		Private Sub btnSelectSound11_Click(sender As Object, e As EventArgs)
			Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
			openFileDialog.Filter = "Wave Files (*.wav)|*.wav"
			openFileDialog.FilterIndex = 1
			Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
			If flag Then
				For Each file As String In openFileDialog.FileNames
					Me.comboSoundCon11.Text = file
					Me.comboSoundCon11.Focus()
				Next
			End If
		End Sub

		' Token: 0x060002B7 RID: 695 RVA: 0x0002AA40 File Offset: 0x00028E40
		Private Sub btnSelectSound12_Click(sender As Object, e As EventArgs)
			Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
			openFileDialog.Filter = "Wave Files (*.wav)|*.wav"
			openFileDialog.FilterIndex = 1
			Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
			If flag Then
				For Each file As String In openFileDialog.FileNames
					Me.comboSoundCon12.Text = file
					Me.comboSoundCon12.Focus()
				Next
			End If
		End Sub

		' Token: 0x060002B8 RID: 696 RVA: 0x0002AAB4 File Offset: 0x00028EB4
		Private Sub btnSelectSound13_Click(sender As Object, e As EventArgs)
			Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
			openFileDialog.Filter = "Wave Files (*.wav)|*.wav"
			openFileDialog.FilterIndex = 1
			Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
			If flag Then
				For Each file As String In openFileDialog.FileNames
					Me.comboSoundCon13.Text = file
					Me.comboSoundCon13.Focus()
				Next
			End If
		End Sub

		' Token: 0x060002B9 RID: 697 RVA: 0x0002AB28 File Offset: 0x00028F28
		Private Sub btnSelectSound14_Click(sender As Object, e As EventArgs)
			Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
			openFileDialog.Filter = "Wave Files (*.wav)|*.wav"
			openFileDialog.FilterIndex = 1
			Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
			If flag Then
				For Each file As String In openFileDialog.FileNames
					Me.comboSoundCon14.Text = file
					Me.comboSoundCon14.Focus()
				Next
			End If
		End Sub

		' Token: 0x060002BA RID: 698 RVA: 0x0002AB9C File Offset: 0x00028F9C
		Private Sub btnSelectSound15_Click(sender As Object, e As EventArgs)
			Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
			openFileDialog.Filter = "Wave Files (*.wav)|*.wav"
			openFileDialog.FilterIndex = 1
			Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
			If flag Then
				For Each file As String In openFileDialog.FileNames
					Me.comboSoundCon15.Text = file
					Me.comboSoundCon15.Focus()
				Next
			End If
		End Sub

		' Token: 0x060002BB RID: 699 RVA: 0x0002AC10 File Offset: 0x00029010
		Private Sub btnSelectSound16_Click(sender As Object, e As EventArgs)
			Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
			openFileDialog.Filter = "Wave Files (*.wav)|*.wav"
			openFileDialog.FilterIndex = 1
			Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
			If flag Then
				For Each file As String In openFileDialog.FileNames
					Me.comboSoundCon16.Text = file
					Me.comboSoundCon16.Focus()
				Next
			End If
		End Sub

		' Token: 0x060002BC RID: 700 RVA: 0x0002AC84 File Offset: 0x00029084
		Private Sub btnSelectSound17_Click(sender As Object, e As EventArgs)
			Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
			openFileDialog.Filter = "Wave Files (*.wav)|*.wav"
			openFileDialog.FilterIndex = 1
			Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
			If flag Then
				For Each file As String In openFileDialog.FileNames
					Me.comboSoundCon17.Text = file
					Me.comboSoundCon17.Focus()
				Next
			End If
		End Sub

		' Token: 0x060002BD RID: 701 RVA: 0x0002ACF8 File Offset: 0x000290F8
		Private Sub btnSelectSound18_Click(sender As Object, e As EventArgs)
			Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
			openFileDialog.Filter = "Wave Files (*.wav)|*.wav"
			openFileDialog.FilterIndex = 1
			Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
			If flag Then
				For Each file As String In openFileDialog.FileNames
					Me.comboSoundCon18.Text = file
					Me.comboSoundCon18.Focus()
				Next
			End If
		End Sub

		' Token: 0x060002BE RID: 702 RVA: 0x0002AD6C File Offset: 0x0002916C
		Private Sub btnSelectSound19_Click(sender As Object, e As EventArgs)
			Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
			openFileDialog.Filter = "Wave Files (*.wav)|*.wav"
			openFileDialog.FilterIndex = 1
			Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
			If flag Then
				For Each file As String In openFileDialog.FileNames
					Me.comboSoundCon19.Text = file
					Me.comboSoundCon19.Focus()
				Next
			End If
		End Sub

		' Token: 0x060002BF RID: 703 RVA: 0x0002ADE0 File Offset: 0x000291E0
		Private Sub btnSelectSound20_Click(sender As Object, e As EventArgs)
			Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
			openFileDialog.Filter = "Wave Files (*.wav)|*.wav"
			openFileDialog.FilterIndex = 1
			Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
			If flag Then
				For Each file As String In openFileDialog.FileNames
					Me.comboSoundCon20.Text = file
					Me.comboSoundCon20.Focus()
				Next
			End If
		End Sub

		' Token: 0x060002C0 RID: 704 RVA: 0x0002AE54 File Offset: 0x00029254
		Private Sub btnSelectSound21_Click(sender As Object, e As EventArgs)
			Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
			openFileDialog.Filter = "Wave Files (*.wav)|*.wav"
			openFileDialog.FilterIndex = 1
			Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
			If flag Then
				For Each file As String In openFileDialog.FileNames
					Me.comboSoundCon21.Text = file
					Me.comboSoundCon21.Focus()
				Next
			End If
		End Sub

		' Token: 0x060002C1 RID: 705 RVA: 0x0002AEC8 File Offset: 0x000292C8
		Private Sub btnSelectSound22_Click(sender As Object, e As EventArgs)
			Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
			openFileDialog.Filter = "Wave Files (*.wav)|*.wav"
			openFileDialog.FilterIndex = 1
			Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
			If flag Then
				For Each file As String In openFileDialog.FileNames
					Me.comboSoundCon22.Text = file
					Me.comboSoundCon22.Focus()
				Next
			End If
		End Sub

		' Token: 0x060002C2 RID: 706 RVA: 0x0002AF3C File Offset: 0x0002933C
		Private Sub btnSelectSound23_Click(sender As Object, e As EventArgs)
			Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
			openFileDialog.Filter = "Wave Files (*.wav)|*.wav"
			openFileDialog.FilterIndex = 1
			Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
			If flag Then
				For Each file As String In openFileDialog.FileNames
					Me.comboSoundCon23.Text = file
					Me.comboSoundCon23.Focus()
				Next
			End If
		End Sub

		' Token: 0x060002C3 RID: 707 RVA: 0x0002AFB0 File Offset: 0x000293B0
		Private Sub btnSelectSound24_Click(sender As Object, e As EventArgs)
			Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
			openFileDialog.Filter = "Wave Files (*.wav)|*.wav"
			openFileDialog.FilterIndex = 1
			Dim flag As Boolean = openFileDialog.ShowDialog() = DialogResult.OK
			If flag Then
				For Each file As String In openFileDialog.FileNames
					Me.comboSoundCon24.Text = file
					Me.comboSoundCon24.Focus()
				Next
			End If
		End Sub

		' Token: 0x060002C4 RID: 708 RVA: 0x0002B024 File Offset: 0x00029424
		Private Sub btnExit_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Interaction.MsgBox("Do you want to exit? ต้องการออกจากโปรแกรมใช่หรือไม่?", MsgBoxStyle.YesNo, "ออกจากโปรแกรม") = MsgBoxResult.Yes
			If flag Then
				Me.Close()
			End If
		End Sub

		' Token: 0x060002C5 RID: 709 RVA: 0x0002B054 File Offset: 0x00029454
		Private Sub btnEdit_Click(sender As Object, e As EventArgs)
			Me.editOpen()
		End Sub

		' Token: 0x060002C6 RID: 710 RVA: 0x0002B060 File Offset: 0x00029460
		Private Sub btnCancel_Click(sender As Object, e As EventArgs)
			Me.editClose()
			Me.loadSetting()
			Dim chkday As Integer = Me.getSettingDay()
			Dim flag As Boolean = chkday = 1
			If flag Then
				Me.loadData(8)
				Me.radioAllDay.Checked = True
				Me.PanelEachDay.Visible = False
				Me.BackColor = Color.White
			Else
				Me.radioEachDay.Checked = True
				Me.PanelEachDay.Visible = True
				Me.loadDay()
			End If
		End Sub

		' Token: 0x060002C7 RID: 711 RVA: 0x0002B0E0 File Offset: 0x000294E0
		Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon1.Checked
			If checked Then
				Me.comboSoundCon1.Enabled = True
				Me.comboSoundConEng1.Enabled = True
				Me.btnPlay1.Enabled = True
			Else
				Me.comboSoundCon1.Enabled = False
				Me.comboSoundConEng1.Enabled = False
				Me.btnPlay1.Enabled = False
			End If
		End Sub

		' Token: 0x060002C8 RID: 712 RVA: 0x0002B150 File Offset: 0x00029550
		Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon2.Checked
			If checked Then
				Me.comboSoundCon2.Enabled = True
				Me.comboSoundConEng2.Enabled = True
				Me.btnPlay2.Enabled = True
			Else
				Me.comboSoundCon2.Enabled = False
				Me.comboSoundConEng2.Enabled = False
				Me.btnPlay2.Enabled = False
			End If
		End Sub

		' Token: 0x060002C9 RID: 713 RVA: 0x0002B1C0 File Offset: 0x000295C0
		Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon3.Checked
			If checked Then
				Me.comboSoundCon3.Enabled = True
				Me.comboSoundConEng3.Enabled = True
				Me.btnPlay3.Enabled = True
			Else
				Me.comboSoundCon3.Enabled = False
				Me.comboSoundConEng3.Enabled = False
				Me.btnPlay3.Enabled = False
			End If
		End Sub

		' Token: 0x060002CA RID: 714 RVA: 0x0002B230 File Offset: 0x00029630
		Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon4.Checked
			If checked Then
				Me.comboSoundCon4.Enabled = True
				Me.comboSoundConEng4.Enabled = True
				Me.btnPlay4.Enabled = True
			Else
				Me.comboSoundCon4.Enabled = False
				Me.comboSoundConEng4.Enabled = False
				Me.btnPlay4.Enabled = False
			End If
		End Sub

		' Token: 0x060002CB RID: 715 RVA: 0x0002B2A0 File Offset: 0x000296A0
		Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon5.Checked
			If checked Then
				Me.comboSoundCon5.Enabled = True
				Me.comboSoundConEng5.Enabled = True
				Me.btnPlay5.Enabled = True
			Else
				Me.comboSoundCon5.Enabled = False
				Me.comboSoundConEng5.Enabled = False
				Me.btnPlay5.Enabled = False
			End If
		End Sub

		' Token: 0x060002CC RID: 716 RVA: 0x0002B310 File Offset: 0x00029710
		Private Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon6.Checked
			If checked Then
				Me.comboSoundCon6.Enabled = True
				Me.comboSoundConEng6.Enabled = True
				Me.btnPlay6.Enabled = True
			Else
				Me.comboSoundCon6.Enabled = False
				Me.comboSoundConEng6.Enabled = False
				Me.btnPlay6.Enabled = False
			End If
		End Sub

		' Token: 0x060002CD RID: 717 RVA: 0x0002B380 File Offset: 0x00029780
		Private Sub CheckBox7_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon7.Checked
			If checked Then
				Me.comboSoundCon7.Enabled = True
				Me.comboSoundConEng7.Enabled = True
				Me.btnPlay7.Enabled = True
			Else
				Me.comboSoundCon7.Enabled = False
				Me.comboSoundConEng7.Enabled = False
				Me.btnPlay7.Enabled = False
			End If
		End Sub

		' Token: 0x060002CE RID: 718 RVA: 0x0002B3F0 File Offset: 0x000297F0
		Private Sub CheckBox8_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon8.Checked
			If checked Then
				Me.comboSoundCon8.Enabled = True
				Me.comboSoundConEng8.Enabled = True
				Me.btnPlay8.Enabled = True
			Else
				Me.comboSoundCon8.Enabled = False
				Me.comboSoundConEng8.Enabled = False
				Me.btnPlay8.Enabled = False
			End If
		End Sub

		' Token: 0x060002CF RID: 719 RVA: 0x0002B460 File Offset: 0x00029860
		Private Sub CheckBox9_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon9.Checked
			If checked Then
				Me.comboSoundCon9.Enabled = True
				Me.comboSoundConEng9.Enabled = True
				Me.btnPlay9.Enabled = True
			Else
				Me.comboSoundCon9.Enabled = False
				Me.comboSoundConEng9.Enabled = False
				Me.btnPlay9.Enabled = False
			End If
		End Sub

		' Token: 0x060002D0 RID: 720 RVA: 0x0002B4D0 File Offset: 0x000298D0
		Private Sub CheckBox10_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon10.Checked
			If checked Then
				Me.comboSoundCon10.Enabled = True
				Me.comboSoundConEng10.Enabled = True
				Me.btnPlay10.Enabled = True
			Else
				Me.comboSoundCon10.Enabled = False
				Me.comboSoundConEng10.Enabled = False
				Me.btnPlay10.Enabled = False
			End If
		End Sub

		' Token: 0x060002D1 RID: 721 RVA: 0x0002B540 File Offset: 0x00029940
		Private Sub CheckBox11_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon11.Checked
			If checked Then
				Me.comboSoundCon11.Enabled = True
				Me.comboSoundConEng11.Enabled = True
				Me.btnPlay11.Enabled = True
			Else
				Me.comboSoundCon11.Enabled = False
				Me.comboSoundConEng11.Enabled = False
				Me.btnPlay11.Enabled = False
			End If
		End Sub

		' Token: 0x060002D2 RID: 722 RVA: 0x0002B5B0 File Offset: 0x000299B0
		Private Sub CheckBox12_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon12.Checked
			If checked Then
				Me.comboSoundCon12.Enabled = True
				Me.comboSoundConEng12.Enabled = True
				Me.btnPlay12.Enabled = True
			Else
				Me.comboSoundCon12.Enabled = False
				Me.comboSoundConEng12.Enabled = False
				Me.btnPlay12.Enabled = False
			End If
		End Sub

		' Token: 0x060002D3 RID: 723 RVA: 0x0002B620 File Offset: 0x00029A20
		Private Sub CheckBox13_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon13.Checked
			If checked Then
				Me.comboSoundCon13.Enabled = True
				Me.comboSoundConEng13.Enabled = True
				Me.btnPlay13.Enabled = True
			Else
				Me.comboSoundCon13.Enabled = False
				Me.comboSoundConEng13.Enabled = False
				Me.btnPlay13.Enabled = False
			End If
		End Sub

		' Token: 0x060002D4 RID: 724 RVA: 0x0002B690 File Offset: 0x00029A90
		Private Sub CheckBox14_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon14.Checked
			If checked Then
				Me.comboSoundCon14.Enabled = True
				Me.comboSoundConEng14.Enabled = True
				Me.btnPlay14.Enabled = True
			Else
				Me.comboSoundCon14.Enabled = False
				Me.comboSoundConEng14.Enabled = False
				Me.btnPlay14.Enabled = False
			End If
		End Sub

		' Token: 0x060002D5 RID: 725 RVA: 0x0002B700 File Offset: 0x00029B00
		Private Sub CheckBox15_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon15.Checked
			If checked Then
				Me.comboSoundCon15.Enabled = True
				Me.comboSoundConEng15.Enabled = True
				Me.btnPlay15.Enabled = True
			Else
				Me.comboSoundCon15.Enabled = False
				Me.comboSoundConEng15.Enabled = False
				Me.btnPlay15.Enabled = False
			End If
		End Sub

		' Token: 0x060002D6 RID: 726 RVA: 0x0002B770 File Offset: 0x00029B70
		Private Sub CheckBox16_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon16.Checked
			If checked Then
				Me.comboSoundCon16.Enabled = True
				Me.comboSoundConEng16.Enabled = True
				Me.btnPlay16.Enabled = True
			Else
				Me.comboSoundCon16.Enabled = False
				Me.comboSoundConEng16.Enabled = False
				Me.btnPlay16.Enabled = False
			End If
		End Sub

		' Token: 0x060002D7 RID: 727 RVA: 0x0002B7E0 File Offset: 0x00029BE0
		Private Sub CheckBox17_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon17.Checked
			If checked Then
				Me.comboSoundCon17.Enabled = True
				Me.comboSoundConEng17.Enabled = True
				Me.btnPlay17.Enabled = True
			Else
				Me.comboSoundCon17.Enabled = False
				Me.comboSoundConEng17.Enabled = False
				Me.btnPlay17.Enabled = False
			End If
		End Sub

		' Token: 0x060002D8 RID: 728 RVA: 0x0002B850 File Offset: 0x00029C50
		Private Sub CheckBox18_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon18.Checked
			If checked Then
				Me.comboSoundCon18.Enabled = True
				Me.comboSoundConEng18.Enabled = True
				Me.btnPlay18.Enabled = True
			Else
				Me.comboSoundCon18.Enabled = False
				Me.comboSoundConEng18.Enabled = False
				Me.btnPlay18.Enabled = False
			End If
		End Sub

		' Token: 0x060002D9 RID: 729 RVA: 0x0002B8C0 File Offset: 0x00029CC0
		Private Sub CheckBox19_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon19.Checked
			If checked Then
				Me.comboSoundCon19.Enabled = True
				Me.comboSoundConEng19.Enabled = True
				Me.btnPlay19.Enabled = True
			Else
				Me.comboSoundCon19.Enabled = False
				Me.comboSoundConEng19.Enabled = False
				Me.btnPlay19.Enabled = False
			End If
		End Sub

		' Token: 0x060002DA RID: 730 RVA: 0x0002B930 File Offset: 0x00029D30
		Private Sub CheckBox20_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon20.Checked
			If checked Then
				Me.comboSoundCon20.Enabled = True
				Me.comboSoundConEng20.Enabled = True
				Me.btnPlay20.Enabled = True
			Else
				Me.comboSoundCon20.Enabled = False
				Me.comboSoundConEng20.Enabled = False
				Me.btnPlay20.Enabled = False
			End If
		End Sub

		' Token: 0x060002DB RID: 731 RVA: 0x0002B9A0 File Offset: 0x00029DA0
		Private Sub CheckBox21_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon21.Checked
			If checked Then
				Me.comboSoundCon21.Enabled = True
				Me.comboSoundConEng21.Enabled = True
				Me.btnPlay21.Enabled = True
			Else
				Me.comboSoundCon21.Enabled = False
				Me.comboSoundConEng21.Enabled = False
				Me.btnPlay21.Enabled = False
			End If
		End Sub

		' Token: 0x060002DC RID: 732 RVA: 0x0002BA10 File Offset: 0x00029E10
		Private Sub CheckBox22_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon22.Checked
			If checked Then
				Me.comboSoundCon22.Enabled = True
				Me.comboSoundConEng22.Enabled = True
				Me.btnPlay22.Enabled = True
			Else
				Me.comboSoundCon22.Enabled = False
				Me.comboSoundConEng22.Enabled = False
				Me.btnPlay22.Enabled = False
			End If
		End Sub

		' Token: 0x060002DD RID: 733 RVA: 0x0002BA80 File Offset: 0x00029E80
		Private Sub CheckBox23_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon23.Checked
			If checked Then
				Me.comboSoundCon23.Enabled = True
				Me.comboSoundConEng23.Enabled = True
				Me.btnPlay23.Enabled = True
			Else
				Me.comboSoundCon23.Enabled = False
				Me.comboSoundConEng23.Enabled = False
				Me.btnPlay23.Enabled = False
			End If
		End Sub

		' Token: 0x060002DE RID: 734 RVA: 0x0002BAF0 File Offset: 0x00029EF0
		Private Sub CheckBox24_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon24.Checked
			If checked Then
				Me.comboSoundCon24.Enabled = True
				Me.comboSoundConEng24.Enabled = True
				Me.btnPlay24.Enabled = True
			Else
				Me.comboSoundCon24.Enabled = False
				Me.comboSoundConEng24.Enabled = False
				Me.btnPlay24.Enabled = False
			End If
		End Sub

		' Token: 0x060002DF RID: 735 RVA: 0x0002BB60 File Offset: 0x00029F60
		Private Sub btnPlaySound_Click(sender As Object, e As EventArgs)
			MyProject.Computer.Audio.Play(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("C:\Sound\bell\", Me.listSoundBell.SelectedItem), "\first.wav")))
			MyProject.Computer.Audio.Play(Conversions.ToString(Operators.ConcatenateObject(Operators.ConcatenateObject("C:\Sound\bell\", Me.listSoundBell.SelectedItem), "\last.wav")))
		End Sub

		' Token: 0x060002E0 RID: 736 RVA: 0x0002BBD8 File Offset: 0x00029FD8
		Private Sub btnStopSound1_Click(sender As Object, e As EventArgs)
			MyProject.Computer.Audio.[Stop]()
		End Sub

		' Token: 0x060002E1 RID: 737 RVA: 0x0002BBEC File Offset: 0x00029FEC
		Private Sub btnStopSound2_Click(sender As Object, e As EventArgs)
			MyProject.Computer.Audio.[Stop]()
		End Sub

		' Token: 0x060002E2 RID: 738 RVA: 0x0002BC00 File Offset: 0x0002A000
		Private Sub btnReset_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Interaction.MsgBox("ต้องการล้างค่าใช่หรือไม่?", MsgBoxStyle.YesNo, Nothing) = MsgBoxResult.Yes
			If flag Then
				Me.comboHour1.Text = "00"
				Me.comboHour2.Text = "00"
				Me.comboHour3.Text = "00"
				Me.comboHour4.Text = "00"
				Me.comboHour5.Text = "00"
				Me.comboHour6.Text = "00"
				Me.comboHour7.Text = "00"
				Me.comboHour8.Text = "00"
				Me.comboHour9.Text = "00"
				Me.comboHour10.Text = "00"
				Me.comboHour11.Text = "00"
				Me.comboHour12.Text = "00"
				Me.comboHour13.Text = "00"
				Me.comboHour14.Text = "00"
				Me.comboHour15.Text = "00"
				Me.comboHour16.Text = "00"
				Me.comboHour17.Text = "00"
				Me.comboHour18.Text = "00"
				Me.comboHour19.Text = "00"
				Me.comboHour20.Text = "00"
				Me.comboHour21.Text = "00"
				Me.comboHour22.Text = "00"
				Me.comboHour23.Text = "00"
				Me.comboHour24.Text = "00"
				Me.comboMin1.Text = "00"
				Me.comboMin2.Text = "00"
				Me.comboMin3.Text = "00"
				Me.comboMin4.Text = "00"
				Me.comboMin5.Text = "00"
				Me.comboMin6.Text = "00"
				Me.comboMin7.Text = "00"
				Me.comboMin8.Text = "00"
				Me.comboMin9.Text = "00"
				Me.comboMin10.Text = "00"
				Me.comboMin11.Text = "00"
				Me.comboMin12.Text = "00"
				Me.comboMin13.Text = "00"
				Me.comboMin14.Text = "00"
				Me.comboMin15.Text = "00"
				Me.comboMin16.Text = "00"
				Me.comboMin17.Text = "00"
				Me.comboMin18.Text = "00"
				Me.comboMin19.Text = "00"
				Me.comboMin20.Text = "00"
				Me.comboMin21.Text = "00"
				Me.comboMin22.Text = "00"
				Me.comboMin23.Text = "00"
				Me.comboMin24.Text = "00"
				Me.chkCon1.Checked = False
				Me.chkCon2.Checked = False
				Me.chkCon3.Checked = False
				Me.chkCon4.Checked = False
				Me.chkCon5.Checked = False
				Me.chkCon6.Checked = False
				Me.chkCon7.Checked = False
				Me.chkCon8.Checked = False
				Me.chkCon9.Checked = False
				Me.chkCon10.Checked = False
				Me.chkCon11.Checked = False
				Me.chkCon12.Checked = False
				Me.chkCon13.Checked = False
				Me.chkCon14.Checked = False
				Me.chkCon15.Checked = False
				Me.chkCon16.Checked = False
				Me.chkCon17.Checked = False
				Me.chkCon18.Checked = False
				Me.chkCon19.Checked = False
				Me.chkCon20.Checked = False
				Me.chkCon21.Checked = False
				Me.chkCon22.Checked = False
				Me.chkCon23.Checked = False
				Me.chkCon24.Checked = False
				Me.chkTime1.Checked = False
				Me.chkTime2.Checked = False
				Me.chkTime3.Checked = False
				Me.chkTime4.Checked = False
				Me.chkTime5.Checked = False
				Me.chkTime6.Checked = False
				Me.chkTime7.Checked = False
				Me.chkTime8.Checked = False
				Me.chkTime9.Checked = False
				Me.chkTime10.Checked = False
				Me.chkTime11.Checked = False
				Me.chkTime12.Checked = False
				Me.chkTime13.Checked = False
				Me.chkTime14.Checked = False
				Me.chkTime15.Checked = False
				Me.chkTime16.Checked = False
				Me.chkTime17.Checked = False
				Me.chkTime18.Checked = False
				Me.chkTime19.Checked = False
				Me.chkTime20.Checked = False
				Me.chkTime21.Checked = False
				Me.chkTime22.Checked = False
				Me.chkTime23.Checked = False
				Me.chkTime24.Checked = False
				Me.chkFirst1.Checked = False
				Me.chkFirst2.Checked = False
				Me.chkFirst3.Checked = False
				Me.chkFirst4.Checked = False
				Me.chkFirst5.Checked = False
				Me.chkFirst6.Checked = False
				Me.chkFirst7.Checked = False
				Me.chkFirst8.Checked = False
				Me.chkFirst9.Checked = False
				Me.chkFirst10.Checked = False
				Me.chkFirst11.Checked = False
				Me.chkFirst12.Checked = False
				Me.chkFirst13.Checked = False
				Me.chkFirst14.Checked = False
				Me.chkFirst15.Checked = False
				Me.chkFirst16.Checked = False
				Me.chkFirst17.Checked = False
				Me.chkFirst18.Checked = False
				Me.chkFirst19.Checked = False
				Me.chkFirst20.Checked = False
				Me.chkFirst21.Checked = False
				Me.chkFirst22.Checked = False
				Me.chkFirst23.Checked = False
				Me.chkFirst24.Checked = False
				Me.chkLast1.Checked = False
				Me.chkLast2.Checked = False
				Me.chkLast3.Checked = False
				Me.chkLast4.Checked = False
				Me.chkLast5.Checked = False
				Me.chkLast6.Checked = False
				Me.chkLast7.Checked = False
				Me.chkLast8.Checked = False
				Me.chkLast9.Checked = False
				Me.chkLast10.Checked = False
				Me.chkLast11.Checked = False
				Me.chkLast12.Checked = False
				Me.chkLast13.Checked = False
				Me.chkLast14.Checked = False
				Me.chkLast15.Checked = False
				Me.chkLast16.Checked = False
				Me.chkLast17.Checked = False
				Me.chkLast18.Checked = False
				Me.chkLast19.Checked = False
				Me.chkLast20.Checked = False
				Me.chkLast21.Checked = False
				Me.chkLast22.Checked = False
				Me.chkLast23.Checked = False
				Me.chkLast24.Checked = False
				Me.comboSoundCon1.Text = ""
				Me.comboSoundCon2.Text = ""
				Me.comboSoundCon3.Text = ""
				Me.comboSoundCon4.Text = ""
				Me.comboSoundCon5.Text = ""
				Me.comboSoundCon6.Text = ""
				Me.comboSoundCon7.Text = ""
				Me.comboSoundCon8.Text = ""
				Me.comboSoundCon9.Text = ""
				Me.comboSoundCon10.Text = ""
				Me.comboSoundCon11.Text = ""
				Me.comboSoundCon12.Text = ""
				Me.comboSoundCon13.Text = ""
				Me.comboSoundCon14.Text = ""
				Me.comboSoundCon15.Text = ""
				Me.comboSoundCon16.Text = ""
				Me.comboSoundCon17.Text = ""
				Me.comboSoundCon18.Text = ""
				Me.comboSoundCon19.Text = ""
				Me.comboSoundCon20.Text = ""
				Me.comboSoundCon21.Text = ""
				Me.comboSoundCon22.Text = ""
				Me.comboSoundCon23.Text = ""
				Me.comboSoundCon24.Text = ""
				Me.comboSoundConEng1.Text = ""
				Me.comboSoundConEng2.Text = ""
				Me.comboSoundConEng3.Text = ""
				Me.comboSoundConEng4.Text = ""
				Me.comboSoundConEng5.Text = ""
				Me.comboSoundConEng6.Text = ""
				Me.comboSoundConEng7.Text = ""
				Me.comboSoundConEng8.Text = ""
				Me.comboSoundConEng9.Text = ""
				Me.comboSoundConEng10.Text = ""
				Me.comboSoundConEng11.Text = ""
				Me.comboSoundConEng12.Text = ""
				Me.comboSoundConEng13.Text = ""
				Me.comboSoundConEng14.Text = ""
				Me.comboSoundConEng15.Text = ""
				Me.comboSoundConEng16.Text = ""
				Me.comboSoundConEng17.Text = ""
				Me.comboSoundConEng18.Text = ""
				Me.comboSoundConEng19.Text = ""
				Me.comboSoundConEng20.Text = ""
				Me.comboSoundConEng21.Text = ""
				Me.comboSoundConEng22.Text = ""
				Me.comboSoundConEng23.Text = ""
				Me.comboSoundConEng24.Text = ""
			End If
		End Sub

		' Token: 0x060002E3 RID: 739 RVA: 0x0002C768 File Offset: 0x0002AB68
		Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.listLangDisplay.SelectedIndex = 0
			If flag Then
				Me.lbl01.Text = "เวลา 1"
				Me.lbl02.Text = "เวลา 2"
				Me.lbl03.Text = "เวลา 3"
				Me.lbl04.Text = "เวลา 4"
				Me.lbl05.Text = "เวลา 5"
				Me.lbl06.Text = "เวลา 6"
				Me.lbl07.Text = "เวลา 7"
				Me.lbl08.Text = "เวลา 8"
				Me.lbl09.Text = "เวลา 9"
				Me.lbl10.Text = "เวลา 10"
				Me.lbl11.Text = "เวลา 11"
				Me.lbl12.Text = "เวลา 12"
				Me.lbl13.Text = "เวลา 13"
				Me.lbl14.Text = "เวลา 14"
				Me.lbl15.Text = "เวลา 15"
				Me.lbl16.Text = "เวลา 16"
				Me.lbl17.Text = "เวลา 17"
				Me.lbl18.Text = "เวลา 18"
				Me.lbl19.Text = "เวลา 19"
				Me.lbl20.Text = "เวลา 20"
				Me.lbl21.Text = "เวลา 21"
				Me.lbl22.Text = "เวลา 22"
				Me.lbl23.Text = "เวลา 23"
				Me.lbl24.Text = "เวลา 24"
				Me.lblTopic1.Text = "School Telling Time 5.1"
				Me.lblTopic2.Text = "โปรแกรมออดโรงเรียน"
				Me.lblReadTime.Text = "บอกเวลา"
				Me.lblReadCon.Text = "ได้เวลาทำกิจกรรม"
				Me.lblLanguage.Text = "ภาษาแสดงผล"
				Me.lblEng.Text = "อังกฤษ"
				Me.lblThai.Text = "ไทย"
				Me.lblToday.Text = "วันนี้"
				Me.lblEdit.Text = "แก้ไข"
				Me.lblSave.Text = "บันทึก"
				Me.lblCancel.Text = "ยกเลิก"
				Me.lblReset.Text = "ล้างค่า"
				Me.im05.Text = "ออก"
				Me.lblSetting.Text = "ตั้งค่าทั่วไป"
				Me.lblLang.Text = "เลือกภาษาบอกเวลา"
				Me.chkEng.Text = "อังกฤษ"
				Me.chkThai.Text = "ไทย"
				Me.ckShutDown.Text = "ปิดคอมฯ อัตโนมัติเวลา"
				Me.lblP.Text = "ที่ตั้งโปรแกรม"
				Me.lblRemark.Text = "หมายเหตุ. : Sound ติดตั้งไดร์ C:/ | โปรแกรมติดตั้งไดร์ D:/ หรือไดร์อื่นๆ"
				Me.lblAlarm.Text = "เสียงออด"
				Me.lblSuguest.Text = "ท่านสามารถเพิ่มเสียงด้วยตัวเองได้ที่ C:/Sound/Thai/ConTN/ หรือ C:/Sound/Eng/ConTN/ นามสกุล .wav เท่านั้น"
				Me.lblCanUse.Text = "คงเหลือ/ครั้ง "
				Me.lblDev.Text = "ผู้พัฒนาโปรแกรม : พงศพล คำโสภา 088-009-5899  / เสียงภาษาไทย : รุจิราภรณ์ มูลสาระ  /  เสียงภาษาอังกฤษ : Miss Alvina Huang From USA"
				Me.radioSun.Text = "อาทิตย์"
				Me.radioMon.Text = "จันทร์"
				Me.radioTue.Text = "อังคาร"
				Me.radioWed.Text = "พุธ"
				Me.radioThu.Text = "พฤหัสบดี"
				Me.radioFri.Text = "ศุกร์"
				Me.radioSat.Text = "เสาร์"
				Me.radioAllDay.Text = "เหมือนกันทุกวัน"
				Me.radioEachDay.Text = "แต่ละวันต่างกัน"
				Me.btnPayment.Text = "กรอกโค้ดต่ออายุ"
				Me.lblWarning.Text = "กรุณาต่ออายุด้วยครับ"
			Else
				Me.lbl01.Text = "Time 1"
				Me.lbl02.Text = "Time 2"
				Me.lbl03.Text = "Time 3"
				Me.lbl04.Text = "Time 4"
				Me.lbl05.Text = "Time 5"
				Me.lbl06.Text = "Time 6"
				Me.lbl07.Text = "Time 7"
				Me.lbl08.Text = "Time 8"
				Me.lbl09.Text = "Time 9"
				Me.lbl10.Text = "Time 10"
				Me.lbl11.Text = "Time 11"
				Me.lbl12.Text = "Time 12"
				Me.lbl13.Text = "Time 13"
				Me.lbl14.Text = "Time 14"
				Me.lbl15.Text = "Time 15"
				Me.lbl16.Text = "Time 16"
				Me.lbl17.Text = "Time 17"
				Me.lbl18.Text = "Time 18"
				Me.lbl19.Text = "Time 19"
				Me.lbl20.Text = "Time 20"
				Me.lbl21.Text = "Time 21"
				Me.lbl22.Text = "Time 22"
				Me.lbl23.Text = "Time 23"
				Me.lbl24.Text = "Time 24"
				Me.lblTopic1.Text = "School Telling Time 5.1"
				Me.lblTopic2.Text = "โปรแกรมออดโรงเรียน"
				Me.lblReadTime.Text = "Telling time"
				Me.lblReadCon.Text = "it time to do activity ..."
				Me.lblLanguage.Text = "Lang Display"
				Me.lblEng.Text = "Eng"
				Me.lblThai.Text = "Thai"
				Me.lblToday.Text = "Today"
				Me.lblEdit.Text = "Edit"
				Me.lblSave.Text = "Save"
				Me.lblCancel.Text = "Cancel"
				Me.lblReset.Text = "Reset"
				Me.im05.Text = "Exit"
				Me.lblSetting.Text = "General Setting."
				Me.lblLang.Text = "Language voice"
				Me.chkEng.Text = "English."
				Me.chkThai.Text = "Thai."
				Me.ckShutDown.Text = "Shutdown at"
				Me.lblP.Text = "Path installed"
				Me.lblRemark.Text = "Remark. : Copy Sound Folder to C:/ And install software to D:/ or else"
				Me.lblAlarm.Text = "Sound"
				Me.lblSuguest.Text = "You can add other voice into C:/Sound/Thai/ConTN/ or C:/Sound/Eng/ConTN/ type must only .wav "
				Me.lblCanUse.Text = "You can use "
				Me.lblDev.Text = "Developer : Pongsapon Khumsopa / Thai voice : Ruchirapawn Moonsara  /  English voice : Miss Alvina Huang From USA"
				Me.radioSun.Text = "Sun"
				Me.radioMon.Text = "Mon"
				Me.radioTue.Text = "Tue"
				Me.radioWed.Text = "Wed"
				Me.radioThu.Text = "Thu"
				Me.radioFri.Text = "Fri"
				Me.radioSat.Text = "Sat"
				Me.radioAllDay.Text = "Same day"
				Me.radioEachDay.Text = "Each day"
				Me.btnPayment.Text = "Enter Code Here."
				Me.lblWarning.Text = "Please Pay for Renew."
			End If
		End Sub

		' Token: 0x060002E4 RID: 740 RVA: 0x0002CF6C File Offset: 0x0002B36C
		Private Sub btnPayment_Click(sender As Object, e As EventArgs)
			Dim strCode As String = Interaction.InputBox("กรุณากรอกโค้ดเพื่อต่ออายุ", "", "", -1, -1)
			Dim a As Boolean = True
			Dim b As Boolean = True
			Dim c As Boolean = False
			Try
				Dim strConn As String = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\db.accdb; Persist Security Info=false; Jet OLEDB:Database Password='toona201'"
				Dim Conn As OleDbConnection = New OleDbConnection(strConn)
				Conn.Open()
				Dim strSQL As String = "SELECT * FROM payment"
				Dim cmd As OleDbCommand = New OleDbCommand(strSQL, Conn)
				Dim reader As OleDbDataReader = cmd.ExecuteReader()
				Dim hasRows As Boolean = reader.HasRows
				If hasRows Then
					Dim flag As Boolean
					While reader.Read()
						flag = Conversions.ToBoolean(Operators.AndObject(String.Compare(Conversions.ToString(reader(2)), strCode) = 0, Operators.CompareObjectEqual(reader(3), False, False)))
						If flag Then
							Me.updateCountDown(Conversions.ToInteger(reader(1)), Conversions.ToString(reader(0)))
							Interaction.MsgBox(Operators.ConcatenateObject(Operators.ConcatenateObject("ต่ออายุแล้วท่านสามารถใช้ได้อีก ", reader(1)), " ครั้ง"), MsgBoxStyle.OkOnly, Nothing)
							Me.loadData(2)
							Me.lblPayment.Visible = False
							Me.btnPayment.Visible = False
							Me.lblWarning.Visible = False
							a = False
						Else
							flag = Conversions.ToBoolean(Operators.AndObject(String.Compare(Conversions.ToString(reader(2)), strCode) = 0, Operators.CompareObjectEqual(reader(3), True, False)))
							If flag Then
								Interaction.MsgBox("โค้ด " + strCode + " ได้ถูกใช้ไปแล้ว", MsgBoxStyle.OkOnly, Nothing)
								b = False
							Else
								c = True
							End If
						End If
					End While
					flag = a AndAlso b AndAlso c
					If flag Then
						Interaction.MsgBox("โค้ดไม่ถูกต้อง", MsgBoxStyle.OkOnly, Nothing)
					End If
				End If
				Conn.Close()
			Catch ex As Exception
				Interaction.MsgBox("ERROR : " + ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
		End Sub

		' Token: 0x060002E5 RID: 741 RVA: 0x0002D184 File Offset: 0x0002B584
		Public Sub updateCountDown(a As Integer, b As String)
			Try
				Dim strConn As String = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\db.accdb; Persist Security Info=False; Jet OLEDB:Database Password='toona201'"
				Dim Conn As OleDbConnection = New OleDbConnection(strConn)
				Conn.Open()
				Dim strSQL As String = "UPDATE normal_setting SET settingSelect = " + Conversions.ToString(Conversions.ToInteger(Me.lblCD.Text) + a) + " WHERE settingID = 6"
				Dim strSQL2 As String = "UPDATE payment SET payed = '1' WHERE paymentID = '" + b + "'"
				Dim cmd As OleDbCommand = New OleDbCommand(strSQL, Conn)
				cmd.ExecuteNonQuery()
				cmd = New OleDbCommand(strSQL2, Conn)
				cmd.ExecuteNonQuery()
				Conn.Close()
				Me.editClose()
			Catch ex As Exception
				Interaction.MsgBox("ERROR : " + ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
		End Sub

		' Token: 0x060002E6 RID: 742 RVA: 0x0002D25C File Offset: 0x0002B65C
		Public Sub updateCountDown()
			Try
				Dim strConn As String = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + Application.StartupPath + "\db.accdb; Persist Security Info=False; Jet OLEDB:Database Password='toona201'"
				Dim Conn As OleDbConnection = New OleDbConnection(strConn)
				Conn.Open()
				Dim strSQL As String = "UPDATE normal_setting SET settingSelect=" + Conversions.ToString(Conversions.ToInteger(Me.lblCD.Text) - 1) + " WHERE settingID = 6"
				Dim cmd As OleDbCommand = New OleDbCommand(strSQL, Conn)
				cmd.ExecuteNonQuery()
				Conn.Close()
				Me.editClose()
			Catch ex As Exception
				Interaction.MsgBox("ERROR : " + ex.Message, MsgBoxStyle.OkOnly, Nothing)
			End Try
		End Sub

		' Token: 0x060002E7 RID: 743 RVA: 0x0002D310 File Offset: 0x0002B710
		Private Sub radioSun_CheckedChanged(sender As Object, e As EventArgs)
			Me.loadData(1)
			Me.BackColor = Color.Tomato
		End Sub

		' Token: 0x060002E8 RID: 744 RVA: 0x0002D334 File Offset: 0x0002B734
		Private Sub radioMon_CheckedChanged(sender As Object, e As EventArgs)
			Me.loadData(2)
			Me.BackColor = Color.Yellow
		End Sub

		' Token: 0x060002E9 RID: 745 RVA: 0x0002D358 File Offset: 0x0002B758
		Private Sub radioTue_CheckedChanged(sender As Object, e As EventArgs)
			Me.loadData(3)
			Me.BackColor = Color.MistyRose
		End Sub

		' Token: 0x060002EA RID: 746 RVA: 0x0002D37C File Offset: 0x0002B77C
		Private Sub radioWed_CheckedChanged(sender As Object, e As EventArgs)
			Me.loadData(4)
			Me.BackColor = Color.DarkSeaGreen
		End Sub

		' Token: 0x060002EB RID: 747 RVA: 0x0002D3A0 File Offset: 0x0002B7A0
		Private Sub radioThu_CheckedChanged(sender As Object, e As EventArgs)
			Me.loadData(5)
			Me.BackColor = Color.Orange
		End Sub

		' Token: 0x060002EC RID: 748 RVA: 0x0002D3C4 File Offset: 0x0002B7C4
		Private Sub radioFri_CheckedChanged(sender As Object, e As EventArgs)
			Me.loadData(6)
			Me.BackColor = Color.Aquamarine
		End Sub

		' Token: 0x060002ED RID: 749 RVA: 0x0002D3E8 File Offset: 0x0002B7E8
		Private Sub radioSat_CheckedChanged(sender As Object, e As EventArgs)
			Me.loadData(7)
			Me.BackColor = Color.Violet
		End Sub

		' Token: 0x060002EE RID: 750 RVA: 0x0002D40C File Offset: 0x0002B80C
		Private Sub radioAllDay_CheckedChanged(sender As Object, e As EventArgs)
			Me.PanelEachDay.Visible = False
			Me.loadData(8)
			Me.BackColor = Color.White
		End Sub

		' Token: 0x060002EF RID: 751 RVA: 0x0002D43C File Offset: 0x0002B83C
		Private Sub radioEachDay_CheckedChanged(sender As Object, e As EventArgs)
			Me.PanelEachDay.Visible = True
			Me.loadDay()
		End Sub

		' Token: 0x060002F0 RID: 752 RVA: 0x0002D454 File Offset: 0x0002B854
		Private Sub chkcon1_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon1.Checked
			If checked Then
				Me.comboSoundCon1.Enabled = True
				Me.comboSoundConEng1.Enabled = True
				Me.btnPlay1.Enabled = True
			Else
				Me.comboSoundCon1.Enabled = False
				Me.comboSoundConEng1.Enabled = False
				Me.btnPlay1.Enabled = False
			End If
		End Sub

		' Token: 0x060002F1 RID: 753 RVA: 0x0002D4C4 File Offset: 0x0002B8C4
		Private Sub chkCon2_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon2.Checked
			If checked Then
				Me.comboSoundCon2.Enabled = True
				Me.comboSoundConEng2.Enabled = True
				Me.btnPlay2.Enabled = True
			Else
				Me.comboSoundCon2.Enabled = False
				Me.comboSoundConEng2.Enabled = False
				Me.btnPlay2.Enabled = False
			End If
		End Sub

		' Token: 0x060002F2 RID: 754 RVA: 0x0002D534 File Offset: 0x0002B934
		Private Sub chkCon3_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon3.Checked
			If checked Then
				Me.comboSoundCon3.Enabled = True
				Me.comboSoundConEng3.Enabled = True
				Me.btnPlay3.Enabled = True
			Else
				Me.comboSoundCon3.Enabled = False
				Me.comboSoundConEng3.Enabled = False
				Me.btnPlay3.Enabled = False
			End If
		End Sub

		' Token: 0x060002F3 RID: 755 RVA: 0x0002D5A4 File Offset: 0x0002B9A4
		Private Sub chkCon4_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon4.Checked
			If checked Then
				Me.comboSoundCon4.Enabled = True
				Me.comboSoundConEng4.Enabled = True
				Me.btnPlay4.Enabled = True
			Else
				Me.comboSoundCon4.Enabled = False
				Me.comboSoundConEng4.Enabled = False
				Me.btnPlay4.Enabled = False
			End If
		End Sub

		' Token: 0x060002F4 RID: 756 RVA: 0x0002D614 File Offset: 0x0002BA14
		Private Sub chkCon5_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon5.Checked
			If checked Then
				Me.comboSoundCon5.Enabled = True
				Me.comboSoundConEng5.Enabled = True
				Me.btnPlay5.Enabled = True
			Else
				Me.comboSoundCon5.Enabled = False
				Me.comboSoundConEng5.Enabled = False
				Me.btnPlay5.Enabled = False
			End If
		End Sub

		' Token: 0x060002F5 RID: 757 RVA: 0x0002D684 File Offset: 0x0002BA84
		Private Sub chkCon6_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon6.Checked
			If checked Then
				Me.comboSoundCon6.Enabled = True
				Me.comboSoundConEng6.Enabled = True
				Me.btnPlay6.Enabled = True
			Else
				Me.comboSoundCon6.Enabled = False
				Me.comboSoundConEng6.Enabled = False
				Me.btnPlay6.Enabled = False
			End If
		End Sub

		' Token: 0x060002F6 RID: 758 RVA: 0x0002D6F4 File Offset: 0x0002BAF4
		Private Sub chkCon7_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon7.Checked
			If checked Then
				Me.comboSoundCon7.Enabled = True
				Me.comboSoundConEng7.Enabled = True
				Me.btnPlay7.Enabled = True
			Else
				Me.comboSoundCon7.Enabled = False
				Me.comboSoundConEng7.Enabled = False
				Me.btnPlay7.Enabled = False
			End If
		End Sub

		' Token: 0x060002F7 RID: 759 RVA: 0x0002D764 File Offset: 0x0002BB64
		Private Sub chkCon8_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon8.Checked
			If checked Then
				Me.comboSoundCon8.Enabled = True
				Me.comboSoundConEng8.Enabled = True
				Me.btnPlay8.Enabled = True
			Else
				Me.comboSoundCon8.Enabled = False
				Me.comboSoundConEng8.Enabled = False
				Me.btnPlay8.Enabled = False
			End If
		End Sub

		' Token: 0x060002F8 RID: 760 RVA: 0x0002D7D4 File Offset: 0x0002BBD4
		Private Sub chkCon9_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon9.Checked
			If checked Then
				Me.comboSoundCon9.Enabled = True
				Me.comboSoundConEng9.Enabled = True
				Me.btnPlay9.Enabled = True
			Else
				Me.comboSoundCon9.Enabled = False
				Me.comboSoundConEng9.Enabled = False
				Me.btnPlay9.Enabled = False
			End If
		End Sub

		' Token: 0x060002F9 RID: 761 RVA: 0x0002D844 File Offset: 0x0002BC44
		Private Sub chkCon10_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon10.Checked
			If checked Then
				Me.comboSoundCon10.Enabled = True
				Me.comboSoundConEng10.Enabled = True
				Me.btnPlay10.Enabled = True
			Else
				Me.comboSoundCon10.Enabled = False
				Me.comboSoundConEng10.Enabled = False
				Me.btnPlay10.Enabled = False
			End If
		End Sub

		' Token: 0x060002FA RID: 762 RVA: 0x0002D8B4 File Offset: 0x0002BCB4
		Private Sub chkCon11_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon11.Checked
			If checked Then
				Me.comboSoundCon11.Enabled = True
				Me.comboSoundConEng11.Enabled = True
				Me.btnPlay11.Enabled = True
			Else
				Me.comboSoundCon11.Enabled = False
				Me.comboSoundConEng11.Enabled = False
				Me.btnPlay11.Enabled = False
			End If
		End Sub

		' Token: 0x060002FB RID: 763 RVA: 0x0002D924 File Offset: 0x0002BD24
		Private Sub chkCon12_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon12.Checked
			If checked Then
				Me.comboSoundCon12.Enabled = True
				Me.comboSoundConEng12.Enabled = True
				Me.btnPlay12.Enabled = True
			Else
				Me.comboSoundCon12.Enabled = False
				Me.comboSoundConEng12.Enabled = False
				Me.btnPlay12.Enabled = False
			End If
		End Sub

		' Token: 0x060002FC RID: 764 RVA: 0x0002D994 File Offset: 0x0002BD94
		Private Sub chkCon13_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon13.Checked
			If checked Then
				Me.comboSoundCon13.Enabled = True
				Me.comboSoundConEng13.Enabled = True
				Me.btnPlay13.Enabled = True
			Else
				Me.comboSoundCon13.Enabled = False
				Me.comboSoundConEng13.Enabled = False
				Me.btnPlay13.Enabled = False
			End If
		End Sub

		' Token: 0x060002FD RID: 765 RVA: 0x0002DA04 File Offset: 0x0002BE04
		Private Sub chkCon14_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon14.Checked
			If checked Then
				Me.comboSoundCon14.Enabled = True
				Me.comboSoundConEng14.Enabled = True
				Me.btnPlay14.Enabled = True
			Else
				Me.comboSoundCon14.Enabled = False
				Me.comboSoundConEng14.Enabled = False
				Me.btnPlay14.Enabled = False
			End If
		End Sub

		' Token: 0x060002FE RID: 766 RVA: 0x0002DA74 File Offset: 0x0002BE74
		Private Sub chkCon15_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon15.Checked
			If checked Then
				Me.comboSoundCon15.Enabled = True
				Me.comboSoundConEng15.Enabled = True
				Me.btnPlay15.Enabled = True
			Else
				Me.comboSoundCon15.Enabled = False
				Me.comboSoundConEng15.Enabled = False
				Me.btnPlay15.Enabled = False
			End If
		End Sub

		' Token: 0x060002FF RID: 767 RVA: 0x0002DAE4 File Offset: 0x0002BEE4
		Private Sub chkCon16_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon16.Checked
			If checked Then
				Me.comboSoundCon16.Enabled = True
				Me.comboSoundConEng16.Enabled = True
				Me.btnPlay16.Enabled = True
			Else
				Me.comboSoundCon16.Enabled = False
				Me.comboSoundConEng16.Enabled = False
				Me.btnPlay16.Enabled = False
			End If
		End Sub

		' Token: 0x06000300 RID: 768 RVA: 0x0002DB54 File Offset: 0x0002BF54
		Private Sub chkCon17_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon17.Checked
			If checked Then
				Me.comboSoundCon17.Enabled = True
				Me.comboSoundConEng17.Enabled = True
				Me.btnPlay17.Enabled = True
			Else
				Me.comboSoundCon17.Enabled = False
				Me.comboSoundConEng17.Enabled = False
				Me.btnPlay17.Enabled = False
			End If
		End Sub

		' Token: 0x06000301 RID: 769 RVA: 0x0002DBC4 File Offset: 0x0002BFC4
		Private Sub chkCon18_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon18.Checked
			If checked Then
				Me.comboSoundCon18.Enabled = True
				Me.comboSoundConEng18.Enabled = True
				Me.btnPlay18.Enabled = True
			Else
				Me.comboSoundCon18.Enabled = False
				Me.comboSoundConEng18.Enabled = False
				Me.btnPlay18.Enabled = False
			End If
		End Sub

		' Token: 0x06000302 RID: 770 RVA: 0x0002DC34 File Offset: 0x0002C034
		Private Sub chkCon19_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon19.Checked
			If checked Then
				Me.comboSoundCon19.Enabled = True
				Me.comboSoundConEng19.Enabled = True
				Me.btnPlay19.Enabled = True
			Else
				Me.comboSoundCon19.Enabled = False
				Me.comboSoundConEng19.Enabled = False
				Me.btnPlay19.Enabled = False
			End If
		End Sub

		' Token: 0x06000303 RID: 771 RVA: 0x0002DCA4 File Offset: 0x0002C0A4
		Private Sub chkCon20_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon20.Checked
			If checked Then
				Me.comboSoundCon20.Enabled = True
				Me.comboSoundConEng20.Enabled = True
				Me.btnPlay20.Enabled = True
			Else
				Me.comboSoundCon20.Enabled = False
				Me.comboSoundConEng20.Enabled = False
				Me.btnPlay20.Enabled = False
			End If
		End Sub

		' Token: 0x06000304 RID: 772 RVA: 0x0002DD14 File Offset: 0x0002C114
		Private Sub chkCon21_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon21.Checked
			If checked Then
				Me.comboSoundCon21.Enabled = True
				Me.comboSoundConEng21.Enabled = True
				Me.btnPlay21.Enabled = True
			Else
				Me.comboSoundCon21.Enabled = False
				Me.comboSoundConEng21.Enabled = False
				Me.btnPlay21.Enabled = False
			End If
		End Sub

		' Token: 0x06000305 RID: 773 RVA: 0x0002DD84 File Offset: 0x0002C184
		Private Sub chkCon22_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon22.Checked
			If checked Then
				Me.comboSoundCon22.Enabled = True
				Me.comboSoundConEng22.Enabled = True
				Me.btnPlay22.Enabled = True
			Else
				Me.comboSoundCon22.Enabled = False
				Me.comboSoundConEng22.Enabled = False
				Me.btnPlay22.Enabled = False
			End If
		End Sub

		' Token: 0x06000306 RID: 774 RVA: 0x0002DDF4 File Offset: 0x0002C1F4
		Private Sub chkCon23_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon23.Checked
			If checked Then
				Me.comboSoundCon23.Enabled = True
				Me.comboSoundConEng23.Enabled = True
				Me.btnPlay23.Enabled = True
			Else
				Me.comboSoundCon23.Enabled = False
				Me.comboSoundConEng23.Enabled = False
				Me.btnPlay23.Enabled = False
			End If
		End Sub

		' Token: 0x06000307 RID: 775 RVA: 0x0002DE64 File Offset: 0x0002C264
		Private Sub chkCon24_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkCon24.Checked
			If checked Then
				Me.comboSoundCon24.Enabled = True
				Me.comboSoundConEng24.Enabled = True
				Me.btnPlay24.Enabled = True
			Else
				Me.comboSoundCon24.Enabled = False
				Me.comboSoundConEng24.Enabled = False
				Me.btnPlay24.Enabled = False
			End If
		End Sub

		' Token: 0x06000308 RID: 776 RVA: 0x0002DED4 File Offset: 0x0002C2D4
		Private Sub btnPlay1_Click_1(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.chkThai.Checked
			If flag Then
				Me.VoiceTimeThai(Me.chkTime1.Checked)
				Me.VoiceConThai(Me.chkCon1.Checked, Me.comboSoundCon1.Text)
			End If
			flag = Me.chkEng.Checked
			If flag Then
				Me.VoiceTimeEng(Me.chkTime1.Checked)
				Me.VoiceConEng(Me.chkCon1.Checked, Me.comboSoundConEng1.Text)
			End If
		End Sub

		' Token: 0x06000309 RID: 777 RVA: 0x0002DF78 File Offset: 0x0002C378
		Private Sub btnPlay2_Click_1(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.chkThai.Checked
			If flag Then
				Me.VoiceTimeThai(Me.chkTime2.Checked)
				Me.VoiceConThai(Me.chkCon2.Checked, Me.comboSoundCon2.Text)
			End If
			flag = Me.chkEng.Checked
			If flag Then
				Me.VoiceTimeEng(Me.chkTime2.Checked)
				Me.VoiceConEng(Me.chkCon2.Checked, Me.comboSoundConEng2.Text)
			End If
		End Sub

		' Token: 0x0600030A RID: 778 RVA: 0x0002E01C File Offset: 0x0002C41C
		Private Sub btnPlay3_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.chkThai.Checked
			If flag Then
				Me.VoiceTimeThai(Me.chkTime3.Checked)
				Me.VoiceConThai(Me.chkCon3.Checked, Me.comboSoundCon3.Text)
			End If
			flag = Me.chkEng.Checked
			If flag Then
				Me.VoiceTimeEng(Me.chkTime3.Checked)
				Me.VoiceConEng(Me.chkCon3.Checked, Me.comboSoundConEng3.Text)
			End If
		End Sub

		' Token: 0x0600030B RID: 779 RVA: 0x0002E0C0 File Offset: 0x0002C4C0
		Private Sub btnPlay4_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.chkThai.Checked
			If flag Then
				Me.VoiceTimeThai(Me.chkTime4.Checked)
				Me.VoiceConThai(Me.chkCon4.Checked, Me.comboSoundCon4.Text)
			End If
			flag = Me.chkEng.Checked
			If flag Then
				Me.VoiceTimeEng(Me.chkTime4.Checked)
				Me.VoiceConEng(Me.chkCon4.Checked, Me.comboSoundConEng4.Text)
			End If
		End Sub

		' Token: 0x0600030C RID: 780 RVA: 0x0002E164 File Offset: 0x0002C564
		Private Sub btnPlay5_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.chkThai.Checked
			If flag Then
				Me.VoiceTimeThai(Me.chkTime5.Checked)
				Me.VoiceConThai(Me.chkCon5.Checked, Me.comboSoundCon5.Text)
			End If
			flag = Me.chkEng.Checked
			If flag Then
				Me.VoiceTimeEng(Me.chkTime5.Checked)
				Me.VoiceConEng(Me.chkCon5.Checked, Me.comboSoundConEng5.Text)
			End If
		End Sub

		' Token: 0x0600030D RID: 781 RVA: 0x0002E208 File Offset: 0x0002C608
		Private Sub btnPlay6_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.chkThai.Checked
			If flag Then
				Me.VoiceTimeThai(Me.chkTime6.Checked)
				Me.VoiceConThai(Me.chkCon6.Checked, Me.comboSoundCon6.Text)
			End If
			flag = Me.chkEng.Checked
			If flag Then
				Me.VoiceTimeEng(Me.chkTime6.Checked)
				Me.VoiceConEng(Me.chkCon6.Checked, Me.comboSoundConEng6.Text)
			End If
		End Sub

		' Token: 0x0600030E RID: 782 RVA: 0x0002E2AC File Offset: 0x0002C6AC
		Private Sub btnPlay7_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.chkThai.Checked
			If flag Then
				Me.VoiceTimeThai(Me.chkTime7.Checked)
				Me.VoiceConThai(Me.chkCon7.Checked, Me.comboSoundCon7.Text)
			End If
			flag = Me.chkEng.Checked
			If flag Then
				Me.VoiceTimeEng(Me.chkTime7.Checked)
				Me.VoiceConEng(Me.chkCon7.Checked, Me.comboSoundConEng7.Text)
			End If
		End Sub

		' Token: 0x0600030F RID: 783 RVA: 0x0002E350 File Offset: 0x0002C750
		Private Sub btnPlay8_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.chkThai.Checked
			If flag Then
				Me.VoiceTimeThai(Me.chkTime8.Checked)
				Me.VoiceConThai(Me.chkCon8.Checked, Me.comboSoundCon8.Text)
			End If
			flag = Me.chkEng.Checked
			If flag Then
				Me.VoiceTimeEng(Me.chkTime8.Checked)
				Me.VoiceConEng(Me.chkCon8.Checked, Me.comboSoundConEng8.Text)
			End If
		End Sub

		' Token: 0x06000310 RID: 784 RVA: 0x0002E3F4 File Offset: 0x0002C7F4
		Private Sub btnPlay9_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.chkThai.Checked
			If flag Then
				Me.VoiceTimeThai(Me.chkTime9.Checked)
				Me.VoiceConThai(Me.chkCon9.Checked, Me.comboSoundCon9.Text)
			End If
			flag = Me.chkEng.Checked
			If flag Then
				Me.VoiceTimeEng(Me.chkTime9.Checked)
				Me.VoiceConEng(Me.chkCon9.Checked, Me.comboSoundConEng9.Text)
			End If
		End Sub

		' Token: 0x06000311 RID: 785 RVA: 0x0002E498 File Offset: 0x0002C898
		Private Sub btnPlay10_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.chkThai.Checked
			If flag Then
				Me.VoiceTimeThai(Me.chkTime10.Checked)
				Me.VoiceConThai(Me.chkCon10.Checked, Me.comboSoundCon10.Text)
			End If
			flag = Me.chkEng.Checked
			If flag Then
				Me.VoiceTimeEng(Me.chkTime10.Checked)
				Me.VoiceConEng(Me.chkCon10.Checked, Me.comboSoundConEng10.Text)
			End If
		End Sub

		' Token: 0x06000312 RID: 786 RVA: 0x0002E53C File Offset: 0x0002C93C
		Private Sub btnPlay11_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.chkThai.Checked
			If flag Then
				Me.VoiceTimeThai(Me.chkTime11.Checked)
				Me.VoiceConThai(Me.chkCon11.Checked, Me.comboSoundCon11.Text)
			End If
			flag = Me.chkEng.Checked
			If flag Then
				Me.VoiceTimeEng(Me.chkTime11.Checked)
				Me.VoiceConEng(Me.chkCon11.Checked, Me.comboSoundConEng11.Text)
			End If
		End Sub

		' Token: 0x06000313 RID: 787 RVA: 0x0002E5E0 File Offset: 0x0002C9E0
		Private Sub btnPlay12_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.chkThai.Checked
			If flag Then
				Me.VoiceTimeThai(Me.chkTime12.Checked)
				Me.VoiceConThai(Me.chkCon12.Checked, Me.comboSoundCon12.Text)
			End If
			flag = Me.chkEng.Checked
			If flag Then
				Me.VoiceTimeEng(Me.chkTime12.Checked)
				Me.VoiceConEng(Me.chkCon12.Checked, Me.comboSoundConEng12.Text)
			End If
		End Sub

		' Token: 0x06000314 RID: 788 RVA: 0x0002E684 File Offset: 0x0002CA84
		Private Sub btnPlay13_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.chkThai.Checked
			If flag Then
				Me.VoiceTimeThai(Me.chkTime13.Checked)
				Me.VoiceConThai(Me.chkCon13.Checked, Me.comboSoundCon13.Text)
			End If
			flag = Me.chkEng.Checked
			If flag Then
				Me.VoiceTimeEng(Me.chkTime13.Checked)
				Me.VoiceConEng(Me.chkCon13.Checked, Me.comboSoundConEng13.Text)
			End If
		End Sub

		' Token: 0x06000315 RID: 789 RVA: 0x0002E728 File Offset: 0x0002CB28
		Private Sub btnPlay14_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.chkThai.Checked
			If flag Then
				Me.VoiceTimeThai(Me.chkTime14.Checked)
				Me.VoiceConThai(Me.chkCon14.Checked, Me.comboSoundCon14.Text)
			End If
			flag = Me.chkEng.Checked
			If flag Then
				Me.VoiceTimeEng(Me.chkTime14.Checked)
				Me.VoiceConEng(Me.chkCon14.Checked, Me.comboSoundConEng14.Text)
			End If
		End Sub

		' Token: 0x06000316 RID: 790 RVA: 0x0002E7CC File Offset: 0x0002CBCC
		Private Sub btnPlay15_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.chkThai.Checked
			If flag Then
				Me.VoiceTimeThai(Me.chkTime15.Checked)
				Me.VoiceConThai(Me.chkCon15.Checked, Me.comboSoundCon15.Text)
			End If
			flag = Me.chkEng.Checked
			If flag Then
				Me.VoiceTimeEng(Me.chkTime15.Checked)
				Me.VoiceConEng(Me.chkCon15.Checked, Me.comboSoundConEng15.Text)
			End If
		End Sub

		' Token: 0x06000317 RID: 791 RVA: 0x0002E870 File Offset: 0x0002CC70
		Private Sub btnPlay16_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.chkThai.Checked
			If flag Then
				Me.VoiceTimeThai(Me.chkTime16.Checked)
				Me.VoiceConThai(Me.chkCon16.Checked, Me.comboSoundCon16.Text)
			End If
			flag = Me.chkEng.Checked
			If flag Then
				Me.VoiceTimeEng(Me.chkTime16.Checked)
				Me.VoiceConEng(Me.chkCon16.Checked, Me.comboSoundConEng16.Text)
			End If
		End Sub

		' Token: 0x06000318 RID: 792 RVA: 0x0002E914 File Offset: 0x0002CD14
		Private Sub btnPlay17_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.chkThai.Checked
			If flag Then
				Me.VoiceTimeThai(Me.chkTime17.Checked)
				Me.VoiceConThai(Me.chkCon17.Checked, Me.comboSoundCon17.Text)
			End If
			flag = Me.chkEng.Checked
			If flag Then
				Me.VoiceTimeEng(Me.chkTime17.Checked)
				Me.VoiceConEng(Me.chkCon17.Checked, Me.comboSoundConEng17.Text)
			End If
		End Sub

		' Token: 0x06000319 RID: 793 RVA: 0x0002E9B8 File Offset: 0x0002CDB8
		Private Sub btnPlay18_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.chkThai.Checked
			If flag Then
				Me.VoiceTimeThai(Me.chkTime18.Checked)
				Me.VoiceConThai(Me.chkCon18.Checked, Me.comboSoundCon18.Text)
			End If
			flag = Me.chkEng.Checked
			If flag Then
				Me.VoiceTimeEng(Me.chkTime18.Checked)
				Me.VoiceConEng(Me.chkCon18.Checked, Me.comboSoundConEng18.Text)
			End If
		End Sub

		' Token: 0x0600031A RID: 794 RVA: 0x0002EA5C File Offset: 0x0002CE5C
		Private Sub btnPlay19_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.chkThai.Checked
			If flag Then
				Me.VoiceTimeThai(Me.chkTime19.Checked)
				Me.VoiceConThai(Me.chkCon19.Checked, Me.comboSoundCon19.Text)
			End If
			flag = Me.chkEng.Checked
			If flag Then
				Me.VoiceTimeEng(Me.chkTime19.Checked)
				Me.VoiceConEng(Me.chkCon19.Checked, Me.comboSoundConEng19.Text)
			End If
		End Sub

		' Token: 0x0600031B RID: 795 RVA: 0x0002EB00 File Offset: 0x0002CF00
		Private Sub btnPlay20_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.chkThai.Checked
			If flag Then
				Me.VoiceTimeThai(Me.chkTime20.Checked)
				Me.VoiceConThai(Me.chkCon20.Checked, Me.comboSoundCon20.Text)
			End If
			flag = Me.chkEng.Checked
			If flag Then
				Me.VoiceTimeEng(Me.chkTime20.Checked)
				Me.VoiceConEng(Me.chkCon20.Checked, Me.comboSoundConEng20.Text)
			End If
		End Sub

		' Token: 0x0600031C RID: 796 RVA: 0x0002EBA4 File Offset: 0x0002CFA4
		Private Sub btnPlay21_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.chkThai.Checked
			If flag Then
				Me.VoiceTimeThai(Me.chkTime21.Checked)
				Me.VoiceConThai(Me.chkCon21.Checked, Me.comboSoundCon21.Text)
			End If
			flag = Me.chkEng.Checked
			If flag Then
				Me.VoiceTimeEng(Me.chkTime21.Checked)
				Me.VoiceConEng(Me.chkCon21.Checked, Me.comboSoundConEng21.Text)
			End If
		End Sub

		' Token: 0x0600031D RID: 797 RVA: 0x0002EC48 File Offset: 0x0002D048
		Private Sub btnPlay22_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.chkThai.Checked
			If flag Then
				Me.VoiceTimeThai(Me.chkTime22.Checked)
				Me.VoiceConThai(Me.chkCon22.Checked, Me.comboSoundCon22.Text)
			End If
			flag = Me.chkEng.Checked
			If flag Then
				Me.VoiceTimeEng(Me.chkTime22.Checked)
				Me.VoiceConEng(Me.chkCon22.Checked, Me.comboSoundConEng22.Text)
			End If
		End Sub

		' Token: 0x0600031E RID: 798 RVA: 0x0002ECEC File Offset: 0x0002D0EC
		Private Sub btnPlay23_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.chkThai.Checked
			If flag Then
				Me.VoiceTimeThai(Me.chkTime23.Checked)
				Me.VoiceConThai(Me.chkCon23.Checked, Me.comboSoundCon23.Text)
			End If
			flag = Me.chkEng.Checked
			If flag Then
				Me.VoiceTimeEng(Me.chkTime23.Checked)
				Me.VoiceConEng(Me.chkCon23.Checked, Me.comboSoundConEng23.Text)
			End If
		End Sub

		' Token: 0x0600031F RID: 799 RVA: 0x0002ED90 File Offset: 0x0002D190
		Private Sub btnPlay24_Click(sender As Object, e As EventArgs)
			Dim flag As Boolean = Me.chkThai.Checked
			If flag Then
				Me.VoiceTimeThai(Me.chkTime24.Checked)
				Me.VoiceConThai(Me.chkCon24.Checked, Me.comboSoundCon24.Text)
			End If
			flag = Me.chkEng.Checked
			If flag Then
				Me.VoiceTimeEng(Me.chkTime24.Checked)
				Me.VoiceConEng(Me.chkCon24.Checked, Me.comboSoundConEng24.Text)
			End If
		End Sub

		' Token: 0x06000320 RID: 800 RVA: 0x0002EE34 File Offset: 0x0002D234
		Private Sub btnPlaySound_Click_1(sender As Object, e As EventArgs)
			Me.PlaySoundFirst()
		End Sub

		' Token: 0x06000321 RID: 801 RVA: 0x0002EE40 File Offset: 0x0002D240
		Private Sub chkFirstAll_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkFirstAll.Checked
			If checked Then
				Me.chkFirstAll.Checked = True
				Me.chkFirst1.Checked = True
				Me.chkFirst2.Checked = True
				Me.chkFirst3.Checked = True
				Me.chkFirst4.Checked = True
				Me.chkFirst5.Checked = True
				Me.chkFirst6.Checked = True
				Me.chkFirst7.Checked = True
				Me.chkFirst8.Checked = True
				Me.chkFirst9.Checked = True
				Me.chkFirst10.Checked = True
				Me.chkFirst11.Checked = True
				Me.chkFirst12.Checked = True
				Me.chkFirst13.Checked = True
				Me.chkFirst14.Checked = True
				Me.chkFirst15.Checked = True
				Me.chkFirst16.Checked = True
				Me.chkFirst17.Checked = True
				Me.chkFirst18.Checked = True
				Me.chkFirst19.Checked = True
				Me.chkFirst20.Checked = True
				Me.chkFirst21.Checked = True
				Me.chkFirst22.Checked = True
				Me.chkFirst23.Checked = True
				Me.chkFirst24.Checked = True
			Else
				Me.chkFirstAll.Checked = False
				Me.chkFirst1.Checked = False
				Me.chkFirst2.Checked = False
				Me.chkFirst3.Checked = False
				Me.chkFirst4.Checked = False
				Me.chkFirst5.Checked = False
				Me.chkFirst6.Checked = False
				Me.chkFirst7.Checked = False
				Me.chkFirst8.Checked = False
				Me.chkFirst9.Checked = False
				Me.chkFirst10.Checked = False
				Me.chkFirst11.Checked = False
				Me.chkFirst12.Checked = False
				Me.chkFirst13.Checked = False
				Me.chkFirst14.Checked = False
				Me.chkFirst15.Checked = False
				Me.chkFirst16.Checked = False
				Me.chkFirst17.Checked = False
				Me.chkFirst18.Checked = False
				Me.chkFirst19.Checked = False
				Me.chkFirst20.Checked = False
				Me.chkFirst21.Checked = False
				Me.chkFirst22.Checked = False
				Me.chkFirst23.Checked = False
				Me.chkFirst24.Checked = False
			End If
		End Sub

		' Token: 0x06000322 RID: 802 RVA: 0x0002F0F4 File Offset: 0x0002D4F4
		Private Sub chkTimeAll_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkTimeAll.Checked
			If checked Then
				Me.chkTimeAll.Checked = True
				Me.chkTime1.Checked = True
				Me.chkTime2.Checked = True
				Me.chkTime3.Checked = True
				Me.chkTime4.Checked = True
				Me.chkTime5.Checked = True
				Me.chkTime6.Checked = True
				Me.chkTime7.Checked = True
				Me.chkTime8.Checked = True
				Me.chkTime9.Checked = True
				Me.chkTime10.Checked = True
				Me.chkTime11.Checked = True
				Me.chkTime12.Checked = True
				Me.chkTime13.Checked = True
				Me.chkTime14.Checked = True
				Me.chkTime15.Checked = True
				Me.chkTime16.Checked = True
				Me.chkTime17.Checked = True
				Me.chkTime18.Checked = True
				Me.chkTime19.Checked = True
				Me.chkTime20.Checked = True
				Me.chkTime21.Checked = True
				Me.chkTime22.Checked = True
				Me.chkTime23.Checked = True
				Me.chkTime24.Checked = True
			Else
				Me.chkTimeAll.Checked = False
				Me.chkTime1.Checked = False
				Me.chkTime2.Checked = False
				Me.chkTime3.Checked = False
				Me.chkTime4.Checked = False
				Me.chkTime5.Checked = False
				Me.chkTime6.Checked = False
				Me.chkTime7.Checked = False
				Me.chkTime8.Checked = False
				Me.chkTime9.Checked = False
				Me.chkTime10.Checked = False
				Me.chkTime11.Checked = False
				Me.chkTime12.Checked = False
				Me.chkTime13.Checked = False
				Me.chkTime14.Checked = False
				Me.chkTime15.Checked = False
				Me.chkTime16.Checked = False
				Me.chkTime17.Checked = False
				Me.chkTime18.Checked = False
				Me.chkTime19.Checked = False
				Me.chkTime20.Checked = False
				Me.chkTime21.Checked = False
				Me.chkTime22.Checked = False
				Me.chkTime23.Checked = False
				Me.chkTime24.Checked = False
			End If
		End Sub

		' Token: 0x06000323 RID: 803 RVA: 0x0002F3A8 File Offset: 0x0002D7A8
		Private Sub chkConAll_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkConAll.Checked
			If checked Then
				Me.chkConAll.Checked = True
				Me.chkCon1.Checked = True
				Me.chkCon2.Checked = True
				Me.chkCon3.Checked = True
				Me.chkCon4.Checked = True
				Me.chkCon5.Checked = True
				Me.chkCon6.Checked = True
				Me.chkCon7.Checked = True
				Me.chkCon8.Checked = True
				Me.chkCon9.Checked = True
				Me.chkCon10.Checked = True
				Me.chkCon11.Checked = True
				Me.chkCon12.Checked = True
				Me.chkCon13.Checked = True
				Me.chkCon14.Checked = True
				Me.chkCon15.Checked = True
				Me.chkCon16.Checked = True
				Me.chkCon17.Checked = True
				Me.chkCon18.Checked = True
				Me.chkCon19.Checked = True
				Me.chkCon20.Checked = True
				Me.chkCon21.Checked = True
				Me.chkCon22.Checked = True
				Me.chkCon23.Checked = True
				Me.chkCon24.Checked = True
			Else
				Me.chkConAll.Checked = False
				Me.chkCon1.Checked = False
				Me.chkCon2.Checked = False
				Me.chkCon3.Checked = False
				Me.chkCon4.Checked = False
				Me.chkCon5.Checked = False
				Me.chkCon6.Checked = False
				Me.chkCon7.Checked = False
				Me.chkCon8.Checked = False
				Me.chkCon9.Checked = False
				Me.chkCon10.Checked = False
				Me.chkCon11.Checked = False
				Me.chkCon12.Checked = False
				Me.chkCon13.Checked = False
				Me.chkCon14.Checked = False
				Me.chkCon15.Checked = False
				Me.chkCon16.Checked = False
				Me.chkCon17.Checked = False
				Me.chkCon18.Checked = False
				Me.chkCon19.Checked = False
				Me.chkCon20.Checked = False
				Me.chkCon21.Checked = False
				Me.chkCon22.Checked = False
				Me.chkCon23.Checked = False
				Me.chkCon24.Checked = False
			End If
		End Sub

		' Token: 0x06000324 RID: 804 RVA: 0x0002F65C File Offset: 0x0002DA5C
		Private Sub chkLastAll_CheckedChanged(sender As Object, e As EventArgs)
			Dim checked As Boolean = Me.chkLastAll.Checked
			If checked Then
				Me.chkLastAll.Checked = True
				Me.chkLast1.Checked = True
				Me.chkLast2.Checked = True
				Me.chkLast3.Checked = True
				Me.chkLast4.Checked = True
				Me.chkLast5.Checked = True
				Me.chkLast6.Checked = True
				Me.chkLast7.Checked = True
				Me.chkLast8.Checked = True
				Me.chkLast9.Checked = True
				Me.chkLast10.Checked = True
				Me.chkLast11.Checked = True
				Me.chkLast12.Checked = True
				Me.chkLast13.Checked = True
				Me.chkLast14.Checked = True
				Me.chkLast15.Checked = True
				Me.chkLast16.Checked = True
				Me.chkLast17.Checked = True
				Me.chkLast18.Checked = True
				Me.chkLast19.Checked = True
				Me.chkLast20.Checked = True
				Me.chkLast21.Checked = True
				Me.chkLast22.Checked = True
				Me.chkLast23.Checked = True
				Me.chkLast24.Checked = True
			Else
				Me.chkLastAll.Checked = False
				Me.chkLast1.Checked = False
				Me.chkLast2.Checked = False
				Me.chkLast3.Checked = False
				Me.chkLast4.Checked = False
				Me.chkLast5.Checked = False
				Me.chkLast6.Checked = False
				Me.chkLast7.Checked = False
				Me.chkLast8.Checked = False
				Me.chkLast9.Checked = False
				Me.chkLast10.Checked = False
				Me.chkLast11.Checked = False
				Me.chkLast12.Checked = False
				Me.chkLast13.Checked = False
				Me.chkLast14.Checked = False
				Me.chkLast15.Checked = False
				Me.chkLast16.Checked = False
				Me.chkLast17.Checked = False
				Me.chkLast18.Checked = False
				Me.chkLast19.Checked = False
				Me.chkLast20.Checked = False
				Me.chkLast21.Checked = False
				Me.chkLast22.Checked = False
				Me.chkLast23.Checked = False
				Me.chkLast24.Checked = False
			End If
		End Sub

		' Token: 0x0400000D RID: 13
		Private Shared __ENCList As List(Of WeakReference) = New List(Of WeakReference)()

		' Token: 0x0400000F RID: 15
		<AccessedThroughProperty("Timer1")>
		Private _Timer1 As Global.System.Windows.Forms.Timer

		' Token: 0x04000010 RID: 16
		<AccessedThroughProperty("lblTimeShow")>
		Private _lblTimeShow As Label

		' Token: 0x04000011 RID: 17
		<AccessedThroughProperty("OpenFileDialog1")>
		Private _OpenFileDialog1 As OpenFileDialog

		' Token: 0x04000012 RID: 18
		<AccessedThroughProperty("btnSave")>
		Private _btnSave As Button

		' Token: 0x04000013 RID: 19
		<AccessedThroughProperty("btnEdit")>
		Private _btnEdit As Button

		' Token: 0x04000014 RID: 20
		<AccessedThroughProperty("btnExit")>
		Private _btnExit As Button

		' Token: 0x04000015 RID: 21
		<AccessedThroughProperty("Timer2")>
		Private _Timer2 As Global.System.Windows.Forms.Timer

		' Token: 0x04000016 RID: 22
		<AccessedThroughProperty("lblPath")>
		Private _lblPath As Label

		' Token: 0x04000017 RID: 23
		<AccessedThroughProperty("btnCancel")>
		Private _btnCancel As Button

		' Token: 0x04000018 RID: 24
		<AccessedThroughProperty("lblTopic2")>
		Private _lblTopic2 As Label

		' Token: 0x04000019 RID: 25
		<AccessedThroughProperty("lblP")>
		Private _lblP As Label

		' Token: 0x0400001A RID: 26
		<AccessedThroughProperty("btnReset")>
		Private _btnReset As Button

		' Token: 0x0400001B RID: 27
		<AccessedThroughProperty("lblCopyright")>
		Private _lblCopyright As Label

		' Token: 0x0400001C RID: 28
		<AccessedThroughProperty("lblTopic1")>
		Private _lblTopic1 As Label

		' Token: 0x0400001D RID: 29
		<AccessedThroughProperty("lblRemark")>
		Private _lblRemark As Label

		' Token: 0x0400001E RID: 30
		<AccessedThroughProperty("lblEdit")>
		Private _lblEdit As Label

		' Token: 0x0400001F RID: 31
		<AccessedThroughProperty("lblSave")>
		Private _lblSave As Label

		' Token: 0x04000020 RID: 32
		<AccessedThroughProperty("lblCancel")>
		Private _lblCancel As Label

		' Token: 0x04000021 RID: 33
		<AccessedThroughProperty("lblReset")>
		Private _lblReset As Label

		' Token: 0x04000022 RID: 34
		<AccessedThroughProperty("im05")>
		Private _im05 As Label

		' Token: 0x04000023 RID: 35
		<AccessedThroughProperty("PictureBox1")>
		Private _PictureBox1 As PictureBox

		' Token: 0x04000024 RID: 36
		<AccessedThroughProperty("listLangDisplay")>
		Private _listLangDisplay As ListBox

		' Token: 0x04000025 RID: 37
		<AccessedThroughProperty("lblLanguage")>
		Private _lblLanguage As Label

		' Token: 0x04000026 RID: 38
		<AccessedThroughProperty("lblCanUse")>
		Private _lblCanUse As Label

		' Token: 0x04000027 RID: 39
		<AccessedThroughProperty("lblCD")>
		Private _lblCD As Label

		' Token: 0x04000028 RID: 40
		<AccessedThroughProperty("lblPayment")>
		Private _lblPayment As Label

		' Token: 0x04000029 RID: 41
		<AccessedThroughProperty("btnPayment")>
		Private _btnPayment As Button

		' Token: 0x0400002A RID: 42
		<AccessedThroughProperty("lblDev")>
		Private _lblDev As Label

		' Token: 0x0400002B RID: 43
		<AccessedThroughProperty("lblWarning")>
		Private _lblWarning As Label

		' Token: 0x0400002C RID: 44
		<AccessedThroughProperty("PanelEachDay")>
		Private _PanelEachDay As Panel

		' Token: 0x0400002D RID: 45
		<AccessedThroughProperty("radioFri")>
		Private _radioFri As RadioButton

		' Token: 0x0400002E RID: 46
		<AccessedThroughProperty("radioThu")>
		Private _radioThu As RadioButton

		' Token: 0x0400002F RID: 47
		<AccessedThroughProperty("radioWed")>
		Private _radioWed As RadioButton

		' Token: 0x04000030 RID: 48
		<AccessedThroughProperty("radioTue")>
		Private _radioTue As RadioButton

		' Token: 0x04000031 RID: 49
		<AccessedThroughProperty("radioSat")>
		Private _radioSat As RadioButton

		' Token: 0x04000032 RID: 50
		<AccessedThroughProperty("radioSun")>
		Private _radioSun As RadioButton

		' Token: 0x04000033 RID: 51
		<AccessedThroughProperty("radioMon")>
		Private _radioMon As RadioButton

		' Token: 0x04000034 RID: 52
		<AccessedThroughProperty("lblToday")>
		Private _lblToday As Label

		' Token: 0x04000035 RID: 53
		<AccessedThroughProperty("radioAllDay")>
		Private _radioAllDay As RadioButton

		' Token: 0x04000036 RID: 54
		<AccessedThroughProperty("panelAllDay")>
		Private _panelAllDay As Panel

		' Token: 0x04000037 RID: 55
		<AccessedThroughProperty("radioEachDay")>
		Private _radioEachDay As RadioButton

		' Token: 0x04000038 RID: 56
		<AccessedThroughProperty("PanelTime")>
		Private _PanelTime As Panel

		' Token: 0x04000039 RID: 57
		<AccessedThroughProperty("lbl22")>
		Private _lbl22 As Label

		' Token: 0x0400003A RID: 58
		<AccessedThroughProperty("lbl23")>
		Private _lbl23 As Label

		' Token: 0x0400003B RID: 59
		<AccessedThroughProperty("lbl24")>
		Private _lbl24 As Label

		' Token: 0x0400003C RID: 60
		<AccessedThroughProperty("lbl17")>
		Private _lbl17 As Label

		' Token: 0x0400003D RID: 61
		<AccessedThroughProperty("lbl18")>
		Private _lbl18 As Label

		' Token: 0x0400003E RID: 62
		<AccessedThroughProperty("lbl19")>
		Private _lbl19 As Label

		' Token: 0x0400003F RID: 63
		<AccessedThroughProperty("lbl20")>
		Private _lbl20 As Label

		' Token: 0x04000040 RID: 64
		<AccessedThroughProperty("lbl21")>
		Private _lbl21 As Label

		' Token: 0x04000041 RID: 65
		<AccessedThroughProperty("chkFirst24")>
		Private _chkFirst24 As CheckBox

		' Token: 0x04000042 RID: 66
		<AccessedThroughProperty("chkLast24")>
		Private _chkLast24 As CheckBox

		' Token: 0x04000043 RID: 67
		<AccessedThroughProperty("chkTime24")>
		Private _chkTime24 As CheckBox

		' Token: 0x04000044 RID: 68
		<AccessedThroughProperty("comboSoundConEng24")>
		Private _comboSoundConEng24 As ComboBox

		' Token: 0x04000045 RID: 69
		<AccessedThroughProperty("comboSoundCon24")>
		Private _comboSoundCon24 As ComboBox

		' Token: 0x04000046 RID: 70
		<AccessedThroughProperty("chkCon24")>
		Private _chkCon24 As CheckBox

		' Token: 0x04000047 RID: 71
		<AccessedThroughProperty("btnPlay24")>
		Private _btnPlay24 As Button

		' Token: 0x04000048 RID: 72
		<AccessedThroughProperty("comboMin24")>
		Private _comboMin24 As ComboBox

		' Token: 0x04000049 RID: 73
		<AccessedThroughProperty("comboHour24")>
		Private _comboHour24 As ComboBox

		' Token: 0x0400004A RID: 74
		<AccessedThroughProperty("chkFirst23")>
		Private _chkFirst23 As CheckBox

		' Token: 0x0400004B RID: 75
		<AccessedThroughProperty("chkFirst22")>
		Private _chkFirst22 As CheckBox

		' Token: 0x0400004C RID: 76
		<AccessedThroughProperty("chkFirst21")>
		Private _chkFirst21 As CheckBox

		' Token: 0x0400004D RID: 77
		<AccessedThroughProperty("chkLast23")>
		Private _chkLast23 As CheckBox

		' Token: 0x0400004E RID: 78
		<AccessedThroughProperty("chkLast22")>
		Private _chkLast22 As CheckBox

		' Token: 0x0400004F RID: 79
		<AccessedThroughProperty("chkLast21")>
		Private _chkLast21 As CheckBox

		' Token: 0x04000050 RID: 80
		<AccessedThroughProperty("chkTime23")>
		Private _chkTime23 As CheckBox

		' Token: 0x04000051 RID: 81
		<AccessedThroughProperty("chkTime22")>
		Private _chkTime22 As CheckBox

		' Token: 0x04000052 RID: 82
		<AccessedThroughProperty("chkTime21")>
		Private _chkTime21 As CheckBox

		' Token: 0x04000053 RID: 83
		<AccessedThroughProperty("comboSoundConEng23")>
		Private _comboSoundConEng23 As ComboBox

		' Token: 0x04000054 RID: 84
		<AccessedThroughProperty("comboSoundConEng22")>
		Private _comboSoundConEng22 As ComboBox

		' Token: 0x04000055 RID: 85
		<AccessedThroughProperty("comboSoundConEng21")>
		Private _comboSoundConEng21 As ComboBox

		' Token: 0x04000056 RID: 86
		<AccessedThroughProperty("comboSoundCon23")>
		Private _comboSoundCon23 As ComboBox

		' Token: 0x04000057 RID: 87
		<AccessedThroughProperty("comboSoundCon22")>
		Private _comboSoundCon22 As ComboBox

		' Token: 0x04000058 RID: 88
		<AccessedThroughProperty("comboSoundCon21")>
		Private _comboSoundCon21 As ComboBox

		' Token: 0x04000059 RID: 89
		<AccessedThroughProperty("chkCon23")>
		Private _chkCon23 As CheckBox

		' Token: 0x0400005A RID: 90
		<AccessedThroughProperty("btnPlay23")>
		Private _btnPlay23 As Button

		' Token: 0x0400005B RID: 91
		<AccessedThroughProperty("comboMin23")>
		Private _comboMin23 As ComboBox

		' Token: 0x0400005C RID: 92
		<AccessedThroughProperty("comboHour23")>
		Private _comboHour23 As ComboBox

		' Token: 0x0400005D RID: 93
		<AccessedThroughProperty("chkCon22")>
		Private _chkCon22 As CheckBox

		' Token: 0x0400005E RID: 94
		<AccessedThroughProperty("btnPlay22")>
		Private _btnPlay22 As Button

		' Token: 0x0400005F RID: 95
		<AccessedThroughProperty("comboMin22")>
		Private _comboMin22 As ComboBox

		' Token: 0x04000060 RID: 96
		<AccessedThroughProperty("comboHour22")>
		Private _comboHour22 As ComboBox

		' Token: 0x04000061 RID: 97
		<AccessedThroughProperty("chkCon21")>
		Private _chkCon21 As CheckBox

		' Token: 0x04000062 RID: 98
		<AccessedThroughProperty("btnPlay21")>
		Private _btnPlay21 As Button

		' Token: 0x04000063 RID: 99
		<AccessedThroughProperty("comboMin21")>
		Private _comboMin21 As ComboBox

		' Token: 0x04000064 RID: 100
		<AccessedThroughProperty("comboHour21")>
		Private _comboHour21 As ComboBox

		' Token: 0x04000065 RID: 101
		<AccessedThroughProperty("chkFirst20")>
		Private _chkFirst20 As CheckBox

		' Token: 0x04000066 RID: 102
		<AccessedThroughProperty("chkFirst19")>
		Private _chkFirst19 As CheckBox

		' Token: 0x04000067 RID: 103
		<AccessedThroughProperty("chkFirst18")>
		Private _chkFirst18 As CheckBox

		' Token: 0x04000068 RID: 104
		<AccessedThroughProperty("chkFirst17")>
		Private _chkFirst17 As CheckBox

		' Token: 0x04000069 RID: 105
		<AccessedThroughProperty("chkLast20")>
		Private _chkLast20 As CheckBox

		' Token: 0x0400006A RID: 106
		<AccessedThroughProperty("chkLast19")>
		Private _chkLast19 As CheckBox

		' Token: 0x0400006B RID: 107
		<AccessedThroughProperty("chkLast18")>
		Private _chkLast18 As CheckBox

		' Token: 0x0400006C RID: 108
		<AccessedThroughProperty("chkLast17")>
		Private _chkLast17 As CheckBox

		' Token: 0x0400006D RID: 109
		<AccessedThroughProperty("chkTime20")>
		Private _chkTime20 As CheckBox

		' Token: 0x0400006E RID: 110
		<AccessedThroughProperty("chkTime19")>
		Private _chkTime19 As CheckBox

		' Token: 0x0400006F RID: 111
		<AccessedThroughProperty("chkTime18")>
		Private _chkTime18 As CheckBox

		' Token: 0x04000070 RID: 112
		<AccessedThroughProperty("chkTime17")>
		Private _chkTime17 As CheckBox

		' Token: 0x04000071 RID: 113
		<AccessedThroughProperty("comboSoundConEng20")>
		Private _comboSoundConEng20 As ComboBox

		' Token: 0x04000072 RID: 114
		<AccessedThroughProperty("comboSoundConEng19")>
		Private _comboSoundConEng19 As ComboBox

		' Token: 0x04000073 RID: 115
		<AccessedThroughProperty("comboSoundConEng18")>
		Private _comboSoundConEng18 As ComboBox

		' Token: 0x04000074 RID: 116
		<AccessedThroughProperty("comboSoundConEng17")>
		Private _comboSoundConEng17 As ComboBox

		' Token: 0x04000075 RID: 117
		<AccessedThroughProperty("comboSoundCon20")>
		Private _comboSoundCon20 As ComboBox

		' Token: 0x04000076 RID: 118
		<AccessedThroughProperty("comboSoundCon19")>
		Private _comboSoundCon19 As ComboBox

		' Token: 0x04000077 RID: 119
		<AccessedThroughProperty("comboSoundCon18")>
		Private _comboSoundCon18 As ComboBox

		' Token: 0x04000078 RID: 120
		<AccessedThroughProperty("comboSoundCon17")>
		Private _comboSoundCon17 As ComboBox

		' Token: 0x04000079 RID: 121
		<AccessedThroughProperty("chkCon20")>
		Private _chkCon20 As CheckBox

		' Token: 0x0400007A RID: 122
		<AccessedThroughProperty("btnPlay20")>
		Private _btnPlay20 As Button

		' Token: 0x0400007B RID: 123
		<AccessedThroughProperty("comboMin20")>
		Private _comboMin20 As ComboBox

		' Token: 0x0400007C RID: 124
		<AccessedThroughProperty("comboHour20")>
		Private _comboHour20 As ComboBox

		' Token: 0x0400007D RID: 125
		<AccessedThroughProperty("chkCon19")>
		Private _chkCon19 As CheckBox

		' Token: 0x0400007E RID: 126
		<AccessedThroughProperty("btnPlay19")>
		Private _btnPlay19 As Button

		' Token: 0x0400007F RID: 127
		<AccessedThroughProperty("comboMin19")>
		Private _comboMin19 As ComboBox

		' Token: 0x04000080 RID: 128
		<AccessedThroughProperty("comboHour19")>
		Private _comboHour19 As ComboBox

		' Token: 0x04000081 RID: 129
		<AccessedThroughProperty("chkCon18")>
		Private _chkCon18 As CheckBox

		' Token: 0x04000082 RID: 130
		<AccessedThroughProperty("btnPlay18")>
		Private _btnPlay18 As Button

		' Token: 0x04000083 RID: 131
		<AccessedThroughProperty("comboMin18")>
		Private _comboMin18 As ComboBox

		' Token: 0x04000084 RID: 132
		<AccessedThroughProperty("comboHour18")>
		Private _comboHour18 As ComboBox

		' Token: 0x04000085 RID: 133
		<AccessedThroughProperty("chkCon17")>
		Private _chkCon17 As CheckBox

		' Token: 0x04000086 RID: 134
		<AccessedThroughProperty("btnPlay17")>
		Private _btnPlay17 As Button

		' Token: 0x04000087 RID: 135
		<AccessedThroughProperty("comboMin17")>
		Private _comboMin17 As ComboBox

		' Token: 0x04000088 RID: 136
		<AccessedThroughProperty("comboHour17")>
		Private _comboHour17 As ComboBox

		' Token: 0x04000089 RID: 137
		<AccessedThroughProperty("lblEng")>
		Private _lblEng As Label

		' Token: 0x0400008A RID: 138
		<AccessedThroughProperty("lblThai")>
		Private _lblThai As Label

		' Token: 0x0400008B RID: 139
		<AccessedThroughProperty("PictureBox3")>
		Private _PictureBox3 As PictureBox

		' Token: 0x0400008C RID: 140
		<AccessedThroughProperty("PictureBox2")>
		Private _PictureBox2 As PictureBox

		' Token: 0x0400008D RID: 141
		<AccessedThroughProperty("lbl14")>
		Private _lbl14 As Label

		' Token: 0x0400008E RID: 142
		<AccessedThroughProperty("lbl15")>
		Private _lbl15 As Label

		' Token: 0x0400008F RID: 143
		<AccessedThroughProperty("lbl16")>
		Private _lbl16 As Label

		' Token: 0x04000090 RID: 144
		<AccessedThroughProperty("lbl09")>
		Private _lbl09 As Label

		' Token: 0x04000091 RID: 145
		<AccessedThroughProperty("lbl10")>
		Private _lbl10 As Label

		' Token: 0x04000092 RID: 146
		<AccessedThroughProperty("lbl11")>
		Private _lbl11 As Label

		' Token: 0x04000093 RID: 147
		<AccessedThroughProperty("lbl12")>
		Private _lbl12 As Label

		' Token: 0x04000094 RID: 148
		<AccessedThroughProperty("lbl13")>
		Private _lbl13 As Label

		' Token: 0x04000095 RID: 149
		<AccessedThroughProperty("lbl06")>
		Private _lbl06 As Label

		' Token: 0x04000096 RID: 150
		<AccessedThroughProperty("lbl07")>
		Private _lbl07 As Label

		' Token: 0x04000097 RID: 151
		<AccessedThroughProperty("lbl08")>
		Private _lbl08 As Label

		' Token: 0x04000098 RID: 152
		<AccessedThroughProperty("lbl05")>
		Private _lbl05 As Label

		' Token: 0x04000099 RID: 153
		<AccessedThroughProperty("lbl04")>
		Private _lbl04 As Label

		' Token: 0x0400009A RID: 154
		<AccessedThroughProperty("lbl03")>
		Private _lbl03 As Label

		' Token: 0x0400009B RID: 155
		<AccessedThroughProperty("lbl02")>
		Private _lbl02 As Label

		' Token: 0x0400009C RID: 156
		<AccessedThroughProperty("lbl01")>
		Private _lbl01 As Label

		' Token: 0x0400009D RID: 157
		<AccessedThroughProperty("chkFirst16")>
		Private _chkFirst16 As CheckBox

		' Token: 0x0400009E RID: 158
		<AccessedThroughProperty("chkLast16")>
		Private _chkLast16 As CheckBox

		' Token: 0x0400009F RID: 159
		<AccessedThroughProperty("chkTime16")>
		Private _chkTime16 As CheckBox

		' Token: 0x040000A0 RID: 160
		<AccessedThroughProperty("comboSoundConEng16")>
		Private _comboSoundConEng16 As ComboBox

		' Token: 0x040000A1 RID: 161
		<AccessedThroughProperty("comboSoundCon16")>
		Private _comboSoundCon16 As ComboBox

		' Token: 0x040000A2 RID: 162
		<AccessedThroughProperty("chkCon16")>
		Private _chkCon16 As CheckBox

		' Token: 0x040000A3 RID: 163
		<AccessedThroughProperty("btnPlay16")>
		Private _btnPlay16 As Button

		' Token: 0x040000A4 RID: 164
		<AccessedThroughProperty("comboMin16")>
		Private _comboMin16 As ComboBox

		' Token: 0x040000A5 RID: 165
		<AccessedThroughProperty("comboHour16")>
		Private _comboHour16 As ComboBox

		' Token: 0x040000A6 RID: 166
		<AccessedThroughProperty("chkFirst15")>
		Private _chkFirst15 As CheckBox

		' Token: 0x040000A7 RID: 167
		<AccessedThroughProperty("chkFirst14")>
		Private _chkFirst14 As CheckBox

		' Token: 0x040000A8 RID: 168
		<AccessedThroughProperty("chkFirst13")>
		Private _chkFirst13 As CheckBox

		' Token: 0x040000A9 RID: 169
		<AccessedThroughProperty("chkLast15")>
		Private _chkLast15 As CheckBox

		' Token: 0x040000AA RID: 170
		<AccessedThroughProperty("chkLast14")>
		Private _chkLast14 As CheckBox

		' Token: 0x040000AB RID: 171
		<AccessedThroughProperty("chkLast13")>
		Private _chkLast13 As CheckBox

		' Token: 0x040000AC RID: 172
		<AccessedThroughProperty("chkTime15")>
		Private _chkTime15 As CheckBox

		' Token: 0x040000AD RID: 173
		<AccessedThroughProperty("chkTime14")>
		Private _chkTime14 As CheckBox

		' Token: 0x040000AE RID: 174
		<AccessedThroughProperty("chkTime13")>
		Private _chkTime13 As CheckBox

		' Token: 0x040000AF RID: 175
		<AccessedThroughProperty("comboSoundConEng15")>
		Private _comboSoundConEng15 As ComboBox

		' Token: 0x040000B0 RID: 176
		<AccessedThroughProperty("comboSoundConEng14")>
		Private _comboSoundConEng14 As ComboBox

		' Token: 0x040000B1 RID: 177
		<AccessedThroughProperty("comboSoundConEng13")>
		Private _comboSoundConEng13 As ComboBox

		' Token: 0x040000B2 RID: 178
		<AccessedThroughProperty("comboSoundCon15")>
		Private _comboSoundCon15 As ComboBox

		' Token: 0x040000B3 RID: 179
		<AccessedThroughProperty("comboSoundCon14")>
		Private _comboSoundCon14 As ComboBox

		' Token: 0x040000B4 RID: 180
		<AccessedThroughProperty("comboSoundCon13")>
		Private _comboSoundCon13 As ComboBox

		' Token: 0x040000B5 RID: 181
		<AccessedThroughProperty("chkCon15")>
		Private _chkCon15 As CheckBox

		' Token: 0x040000B6 RID: 182
		<AccessedThroughProperty("btnPlay15")>
		Private _btnPlay15 As Button

		' Token: 0x040000B7 RID: 183
		<AccessedThroughProperty("comboMin15")>
		Private _comboMin15 As ComboBox

		' Token: 0x040000B8 RID: 184
		<AccessedThroughProperty("comboHour15")>
		Private _comboHour15 As ComboBox

		' Token: 0x040000B9 RID: 185
		<AccessedThroughProperty("chkCon14")>
		Private _chkCon14 As CheckBox

		' Token: 0x040000BA RID: 186
		<AccessedThroughProperty("btnPlay14")>
		Private _btnPlay14 As Button

		' Token: 0x040000BB RID: 187
		<AccessedThroughProperty("comboMin14")>
		Private _comboMin14 As ComboBox

		' Token: 0x040000BC RID: 188
		<AccessedThroughProperty("comboHour14")>
		Private _comboHour14 As ComboBox

		' Token: 0x040000BD RID: 189
		<AccessedThroughProperty("chkCon13")>
		Private _chkCon13 As CheckBox

		' Token: 0x040000BE RID: 190
		<AccessedThroughProperty("btnPlay13")>
		Private _btnPlay13 As Button

		' Token: 0x040000BF RID: 191
		<AccessedThroughProperty("comboMin13")>
		Private _comboMin13 As ComboBox

		' Token: 0x040000C0 RID: 192
		<AccessedThroughProperty("comboHour13")>
		Private _comboHour13 As ComboBox

		' Token: 0x040000C1 RID: 193
		<AccessedThroughProperty("chkFirst12")>
		Private _chkFirst12 As CheckBox

		' Token: 0x040000C2 RID: 194
		<AccessedThroughProperty("chkFirst11")>
		Private _chkFirst11 As CheckBox

		' Token: 0x040000C3 RID: 195
		<AccessedThroughProperty("chkFirst10")>
		Private _chkFirst10 As CheckBox

		' Token: 0x040000C4 RID: 196
		<AccessedThroughProperty("chkFirst9")>
		Private _chkFirst9 As CheckBox

		' Token: 0x040000C5 RID: 197
		<AccessedThroughProperty("chkFirst8")>
		Private _chkFirst8 As CheckBox

		' Token: 0x040000C6 RID: 198
		<AccessedThroughProperty("chkFirst7")>
		Private _chkFirst7 As CheckBox

		' Token: 0x040000C7 RID: 199
		<AccessedThroughProperty("chkFirst6")>
		Private _chkFirst6 As CheckBox

		' Token: 0x040000C8 RID: 200
		<AccessedThroughProperty("chkFirst5")>
		Private _chkFirst5 As CheckBox

		' Token: 0x040000C9 RID: 201
		<AccessedThroughProperty("chkFirst4")>
		Private _chkFirst4 As CheckBox

		' Token: 0x040000CA RID: 202
		<AccessedThroughProperty("chkFirst3")>
		Private _chkFirst3 As CheckBox

		' Token: 0x040000CB RID: 203
		<AccessedThroughProperty("chkFirst2")>
		Private _chkFirst2 As CheckBox

		' Token: 0x040000CC RID: 204
		<AccessedThroughProperty("chkFirst1")>
		Private _chkFirst1 As CheckBox

		' Token: 0x040000CD RID: 205
		<AccessedThroughProperty("chkLast12")>
		Private _chkLast12 As CheckBox

		' Token: 0x040000CE RID: 206
		<AccessedThroughProperty("chkLast11")>
		Private _chkLast11 As CheckBox

		' Token: 0x040000CF RID: 207
		<AccessedThroughProperty("chkLast10")>
		Private _chkLast10 As CheckBox

		' Token: 0x040000D0 RID: 208
		<AccessedThroughProperty("chkLast9")>
		Private _chkLast9 As CheckBox

		' Token: 0x040000D1 RID: 209
		<AccessedThroughProperty("chkLast8")>
		Private _chkLast8 As CheckBox

		' Token: 0x040000D2 RID: 210
		<AccessedThroughProperty("chkLast7")>
		Private _chkLast7 As CheckBox

		' Token: 0x040000D3 RID: 211
		<AccessedThroughProperty("chkLast6")>
		Private _chkLast6 As CheckBox

		' Token: 0x040000D4 RID: 212
		<AccessedThroughProperty("chkLast5")>
		Private _chkLast5 As CheckBox

		' Token: 0x040000D5 RID: 213
		<AccessedThroughProperty("chkLast4")>
		Private _chkLast4 As CheckBox

		' Token: 0x040000D6 RID: 214
		<AccessedThroughProperty("chkLast3")>
		Private _chkLast3 As CheckBox

		' Token: 0x040000D7 RID: 215
		<AccessedThroughProperty("chkLast2")>
		Private _chkLast2 As CheckBox

		' Token: 0x040000D8 RID: 216
		<AccessedThroughProperty("chkLast1")>
		Private _chkLast1 As CheckBox

		' Token: 0x040000D9 RID: 217
		<AccessedThroughProperty("lblSuguest")>
		Private _lblSuguest As Label

		' Token: 0x040000DA RID: 218
		<AccessedThroughProperty("lblReadCon")>
		Private _lblReadCon As Label

		' Token: 0x040000DB RID: 219
		<AccessedThroughProperty("PictureBox6")>
		Private _PictureBox6 As PictureBox

		' Token: 0x040000DC RID: 220
		<AccessedThroughProperty("lblReadTime")>
		Private _lblReadTime As Label

		' Token: 0x040000DD RID: 221
		<AccessedThroughProperty("chkTime12")>
		Private _chkTime12 As CheckBox

		' Token: 0x040000DE RID: 222
		<AccessedThroughProperty("chkTime11")>
		Private _chkTime11 As CheckBox

		' Token: 0x040000DF RID: 223
		<AccessedThroughProperty("chkTime10")>
		Private _chkTime10 As CheckBox

		' Token: 0x040000E0 RID: 224
		<AccessedThroughProperty("chkTime9")>
		Private _chkTime9 As CheckBox

		' Token: 0x040000E1 RID: 225
		<AccessedThroughProperty("chkTime8")>
		Private _chkTime8 As CheckBox

		' Token: 0x040000E2 RID: 226
		<AccessedThroughProperty("chkTime7")>
		Private _chkTime7 As CheckBox

		' Token: 0x040000E3 RID: 227
		<AccessedThroughProperty("chkTime6")>
		Private _chkTime6 As CheckBox

		' Token: 0x040000E4 RID: 228
		<AccessedThroughProperty("chkTime5")>
		Private _chkTime5 As CheckBox

		' Token: 0x040000E5 RID: 229
		<AccessedThroughProperty("chkTime4")>
		Private _chkTime4 As CheckBox

		' Token: 0x040000E6 RID: 230
		<AccessedThroughProperty("chkTime3")>
		Private _chkTime3 As CheckBox

		' Token: 0x040000E7 RID: 231
		<AccessedThroughProperty("chkTime2")>
		Private _chkTime2 As CheckBox

		' Token: 0x040000E8 RID: 232
		<AccessedThroughProperty("chkTime1")>
		Private _chkTime1 As CheckBox

		' Token: 0x040000E9 RID: 233
		<AccessedThroughProperty("comboSoundConEng12")>
		Private _comboSoundConEng12 As ComboBox

		' Token: 0x040000EA RID: 234
		<AccessedThroughProperty("comboSoundConEng11")>
		Private _comboSoundConEng11 As ComboBox

		' Token: 0x040000EB RID: 235
		<AccessedThroughProperty("comboSoundConEng10")>
		Private _comboSoundConEng10 As ComboBox

		' Token: 0x040000EC RID: 236
		<AccessedThroughProperty("comboSoundConEng9")>
		Private _comboSoundConEng9 As ComboBox

		' Token: 0x040000ED RID: 237
		<AccessedThroughProperty("comboSoundConEng8")>
		Private _comboSoundConEng8 As ComboBox

		' Token: 0x040000EE RID: 238
		<AccessedThroughProperty("comboSoundConEng7")>
		Private _comboSoundConEng7 As ComboBox

		' Token: 0x040000EF RID: 239
		<AccessedThroughProperty("comboSoundConEng6")>
		Private _comboSoundConEng6 As ComboBox

		' Token: 0x040000F0 RID: 240
		<AccessedThroughProperty("comboSoundConEng5")>
		Private _comboSoundConEng5 As ComboBox

		' Token: 0x040000F1 RID: 241
		<AccessedThroughProperty("comboSoundConEng4")>
		Private _comboSoundConEng4 As ComboBox

		' Token: 0x040000F2 RID: 242
		<AccessedThroughProperty("comboSoundConEng3")>
		Private _comboSoundConEng3 As ComboBox

		' Token: 0x040000F3 RID: 243
		<AccessedThroughProperty("comboSoundConEng2")>
		Private _comboSoundConEng2 As ComboBox

		' Token: 0x040000F4 RID: 244
		<AccessedThroughProperty("comboSoundConEng1")>
		Private _comboSoundConEng1 As ComboBox

		' Token: 0x040000F5 RID: 245
		<AccessedThroughProperty("comboSoundCon12")>
		Private _comboSoundCon12 As ComboBox

		' Token: 0x040000F6 RID: 246
		<AccessedThroughProperty("comboSoundCon11")>
		Private _comboSoundCon11 As ComboBox

		' Token: 0x040000F7 RID: 247
		<AccessedThroughProperty("comboSoundCon10")>
		Private _comboSoundCon10 As ComboBox

		' Token: 0x040000F8 RID: 248
		<AccessedThroughProperty("comboSoundCon9")>
		Private _comboSoundCon9 As ComboBox

		' Token: 0x040000F9 RID: 249
		<AccessedThroughProperty("comboSoundCon8")>
		Private _comboSoundCon8 As ComboBox

		' Token: 0x040000FA RID: 250
		<AccessedThroughProperty("comboSoundCon7")>
		Private _comboSoundCon7 As ComboBox

		' Token: 0x040000FB RID: 251
		<AccessedThroughProperty("comboSoundCon6")>
		Private _comboSoundCon6 As ComboBox

		' Token: 0x040000FC RID: 252
		<AccessedThroughProperty("comboSoundCon5")>
		Private _comboSoundCon5 As ComboBox

		' Token: 0x040000FD RID: 253
		<AccessedThroughProperty("comboSoundCon4")>
		Private _comboSoundCon4 As ComboBox

		' Token: 0x040000FE RID: 254
		<AccessedThroughProperty("comboSoundCon3")>
		Private _comboSoundCon3 As ComboBox

		' Token: 0x040000FF RID: 255
		<AccessedThroughProperty("comboSoundCon2")>
		Private _comboSoundCon2 As ComboBox

		' Token: 0x04000100 RID: 256
		<AccessedThroughProperty("comboSoundCon1")>
		Private _comboSoundCon1 As ComboBox

		' Token: 0x04000101 RID: 257
		<AccessedThroughProperty("chkCon12")>
		Private _chkCon12 As CheckBox

		' Token: 0x04000102 RID: 258
		<AccessedThroughProperty("btnPlay12")>
		Private _btnPlay12 As Button

		' Token: 0x04000103 RID: 259
		<AccessedThroughProperty("comboMin12")>
		Private _comboMin12 As ComboBox

		' Token: 0x04000104 RID: 260
		<AccessedThroughProperty("comboHour12")>
		Private _comboHour12 As ComboBox

		' Token: 0x04000105 RID: 261
		<AccessedThroughProperty("chkCon11")>
		Private _chkCon11 As CheckBox

		' Token: 0x04000106 RID: 262
		<AccessedThroughProperty("btnPlay11")>
		Private _btnPlay11 As Button

		' Token: 0x04000107 RID: 263
		<AccessedThroughProperty("comboMin11")>
		Private _comboMin11 As ComboBox

		' Token: 0x04000108 RID: 264
		<AccessedThroughProperty("comboHour11")>
		Private _comboHour11 As ComboBox

		' Token: 0x04000109 RID: 265
		<AccessedThroughProperty("chkCon10")>
		Private _chkCon10 As CheckBox

		' Token: 0x0400010A RID: 266
		<AccessedThroughProperty("btnPlay10")>
		Private _btnPlay10 As Button

		' Token: 0x0400010B RID: 267
		<AccessedThroughProperty("comboMin10")>
		Private _comboMin10 As ComboBox

		' Token: 0x0400010C RID: 268
		<AccessedThroughProperty("comboHour10")>
		Private _comboHour10 As ComboBox

		' Token: 0x0400010D RID: 269
		<AccessedThroughProperty("chkCon9")>
		Private _chkCon9 As CheckBox

		' Token: 0x0400010E RID: 270
		<AccessedThroughProperty("btnPlay9")>
		Private _btnPlay9 As Button

		' Token: 0x0400010F RID: 271
		<AccessedThroughProperty("comboMin9")>
		Private _comboMin9 As ComboBox

		' Token: 0x04000110 RID: 272
		<AccessedThroughProperty("comboHour9")>
		Private _comboHour9 As ComboBox

		' Token: 0x04000111 RID: 273
		<AccessedThroughProperty("chkCon8")>
		Private _chkCon8 As CheckBox

		' Token: 0x04000112 RID: 274
		<AccessedThroughProperty("btnPlay8")>
		Private _btnPlay8 As Button

		' Token: 0x04000113 RID: 275
		<AccessedThroughProperty("comboMin8")>
		Private _comboMin8 As ComboBox

		' Token: 0x04000114 RID: 276
		<AccessedThroughProperty("comboHour8")>
		Private _comboHour8 As ComboBox

		' Token: 0x04000115 RID: 277
		<AccessedThroughProperty("chkCon7")>
		Private _chkCon7 As CheckBox

		' Token: 0x04000116 RID: 278
		<AccessedThroughProperty("btnPlay7")>
		Private _btnPlay7 As Button

		' Token: 0x04000117 RID: 279
		<AccessedThroughProperty("comboMin7")>
		Private _comboMin7 As ComboBox

		' Token: 0x04000118 RID: 280
		<AccessedThroughProperty("comboHour7")>
		Private _comboHour7 As ComboBox

		' Token: 0x04000119 RID: 281
		<AccessedThroughProperty("chkCon6")>
		Private _chkCon6 As CheckBox

		' Token: 0x0400011A RID: 282
		<AccessedThroughProperty("btnPlay6")>
		Private _btnPlay6 As Button

		' Token: 0x0400011B RID: 283
		<AccessedThroughProperty("comboMin6")>
		Private _comboMin6 As ComboBox

		' Token: 0x0400011C RID: 284
		<AccessedThroughProperty("comboHour6")>
		Private _comboHour6 As ComboBox

		' Token: 0x0400011D RID: 285
		<AccessedThroughProperty("chkCon5")>
		Private _chkCon5 As CheckBox

		' Token: 0x0400011E RID: 286
		<AccessedThroughProperty("btnPlay5")>
		Private _btnPlay5 As Button

		' Token: 0x0400011F RID: 287
		<AccessedThroughProperty("comboMin5")>
		Private _comboMin5 As ComboBox

		' Token: 0x04000120 RID: 288
		<AccessedThroughProperty("comboHour5")>
		Private _comboHour5 As ComboBox

		' Token: 0x04000121 RID: 289
		<AccessedThroughProperty("chkCon4")>
		Private _chkCon4 As CheckBox

		' Token: 0x04000122 RID: 290
		<AccessedThroughProperty("btnPlay4")>
		Private _btnPlay4 As Button

		' Token: 0x04000123 RID: 291
		<AccessedThroughProperty("comboMin4")>
		Private _comboMin4 As ComboBox

		' Token: 0x04000124 RID: 292
		<AccessedThroughProperty("comboHour4")>
		Private _comboHour4 As ComboBox

		' Token: 0x04000125 RID: 293
		<AccessedThroughProperty("chkCon3")>
		Private _chkCon3 As CheckBox

		' Token: 0x04000126 RID: 294
		<AccessedThroughProperty("btnPlay3")>
		Private _btnPlay3 As Button

		' Token: 0x04000127 RID: 295
		<AccessedThroughProperty("comboMin3")>
		Private _comboMin3 As ComboBox

		' Token: 0x04000128 RID: 296
		<AccessedThroughProperty("comboHour3")>
		Private _comboHour3 As ComboBox

		' Token: 0x04000129 RID: 297
		<AccessedThroughProperty("chkCon2")>
		Private _chkCon2 As CheckBox

		' Token: 0x0400012A RID: 298
		<AccessedThroughProperty("btnPlay2")>
		Private _btnPlay2 As Button

		' Token: 0x0400012B RID: 299
		<AccessedThroughProperty("comboMin2")>
		Private _comboMin2 As ComboBox

		' Token: 0x0400012C RID: 300
		<AccessedThroughProperty("comboHour2")>
		Private _comboHour2 As ComboBox

		' Token: 0x0400012D RID: 301
		<AccessedThroughProperty("chkCon1")>
		Private _chkCon1 As CheckBox

		' Token: 0x0400012E RID: 302
		<AccessedThroughProperty("btnPlay1")>
		Private _btnPlay1 As Button

		' Token: 0x0400012F RID: 303
		<AccessedThroughProperty("comboMin1")>
		Private _comboMin1 As ComboBox

		' Token: 0x04000130 RID: 304
		<AccessedThroughProperty("comboHour1")>
		Private _comboHour1 As ComboBox

		' Token: 0x04000131 RID: 305
		<AccessedThroughProperty("PictureBox7")>
		Private _PictureBox7 As PictureBox

		' Token: 0x04000132 RID: 306
		<AccessedThroughProperty("panelSetting")>
		Private _panelSetting As Panel

		' Token: 0x04000133 RID: 307
		<AccessedThroughProperty("lblSetting")>
		Private _lblSetting As Label

		' Token: 0x04000134 RID: 308
		<AccessedThroughProperty("Label73")>
		Private _Label73 As Label

		' Token: 0x04000135 RID: 309
		<AccessedThroughProperty("comboMinShutdown")>
		Private _comboMinShutdown As ComboBox

		' Token: 0x04000136 RID: 310
		<AccessedThroughProperty("comboHourShutdown")>
		Private _comboHourShutdown As ComboBox

		' Token: 0x04000137 RID: 311
		<AccessedThroughProperty("ckShutDown")>
		Private _ckShutDown As CheckBox

		' Token: 0x04000138 RID: 312
		<AccessedThroughProperty("chkEng")>
		Private _chkEng As CheckBox

		' Token: 0x04000139 RID: 313
		<AccessedThroughProperty("btnPlaySound")>
		Private _btnPlaySound As Button

		' Token: 0x0400013A RID: 314
		<AccessedThroughProperty("lblAlarm")>
		Private _lblAlarm As Label

		' Token: 0x0400013B RID: 315
		<AccessedThroughProperty("listSoundBell")>
		Private _listSoundBell As ListBox

		' Token: 0x0400013C RID: 316
		<AccessedThroughProperty("chkThai")>
		Private _chkThai As CheckBox

		' Token: 0x0400013D RID: 317
		<AccessedThroughProperty("lblLang")>
		Private _lblLang As Label

		' Token: 0x0400013E RID: 318
		<AccessedThroughProperty("chkLastAll")>
		Private _chkLastAll As CheckBox

		' Token: 0x0400013F RID: 319
		<AccessedThroughProperty("chkConAll")>
		Private _chkConAll As CheckBox

		' Token: 0x04000140 RID: 320
		<AccessedThroughProperty("chkTimeAll")>
		Private _chkTimeAll As CheckBox

		' Token: 0x04000141 RID: 321
		<AccessedThroughProperty("chkFirstAll")>
		Private _chkFirstAll As CheckBox

		' Token: 0x04000142 RID: 322
		Private list1 As String
	End Class
End Namespace
