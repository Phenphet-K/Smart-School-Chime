Imports System
Imports System.CodeDom.Compiler
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Globalization
Imports System.Resources
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic
Imports Microsoft.VisualBasic.CompilerServices

Namespace SchoolTellingTime.My.Resources
	''' <summary>
	'''   A strongly-typed resource class, for looking up localized strings, etc.
	''' </summary>
	' Token: 0x0200000B RID: 11
	<HideModuleName()>
	<CompilerGenerated()>
	<DebuggerNonUserCode()>
	<GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")>
	Friend NotInheritable Module Resources
		''' <summary>
		'''   Returns the cached ResourceManager instance used by this class.
		''' </summary>
		' Token: 0x1700013E RID: 318
		' (get) Token: 0x06000325 RID: 805 RVA: 0x00002570 File Offset: 0x00000970
		<EditorBrowsable(EditorBrowsableState.Advanced)>
		Friend ReadOnly Property ResourceManager As ResourceManager
			Get
				Dim flag As Boolean = Object.ReferenceEquals(Resources.resourceMan, Nothing)
				If flag Then
					Dim temp As ResourceManager = New ResourceManager("SchoolTellingTime.Resources", GetType(Resources).Assembly)
					Resources.resourceMan = temp
				End If
				Return Resources.resourceMan
			End Get
		End Property

		' Token: 0x1700013F RID: 319
		' (get) Token: 0x06000326 RID: 806 RVA: 0x000025B8 File Offset: 0x000009B8
		' (set) Token: 0x06000327 RID: 807 RVA: 0x000025D0 File Offset: 0x000009D0
		<EditorBrowsable(EditorBrowsableState.Advanced)>
		Friend Property Culture As CultureInfo
			Get
				Return Resources.resourceCulture
			End Get
			Set(value As CultureInfo)
				Resources.resourceCulture = value
			End Set
		End Property

		' Token: 0x04000143 RID: 323
		Private resourceMan As ResourceManager

		' Token: 0x04000144 RID: 324
		Private resourceCulture As CultureInfo
	End Module
End Namespace
