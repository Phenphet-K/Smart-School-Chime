Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Linq
Imports System.Runtime.CompilerServices
Imports System.Xml.Linq

Namespace SchoolTellingTime.My
	' Token: 0x02000008 RID: 8
	<EditorBrowsable(EditorBrowsableState.Never)>
	<CompilerGenerated()>
	<DebuggerNonUserCode()>
	Friend NotInheritable Class InternalXmlHelper
		' Token: 0x0600001F RID: 31 RVA: 0x00002050 File Offset: 0x00000450
		<EditorBrowsable(EditorBrowsableState.Never)>
		Private Sub New()
		End Sub

		' Token: 0x17000008 RID: 8
		' (get) Token: 0x06000020 RID: 32 RVA: 0x0000205C File Offset: 0x0000045C
		' (set) Token: 0x06000021 RID: 33 RVA: 0x000020BC File Offset: 0x000004BC
		Public Shared Property Value(source As IEnumerable(Of XElement)) As String
			Get
				Try
					Dim enumerator As IEnumerator(Of XElement) = source.GetEnumerator()
					If enumerator.MoveNext() Then
						Dim item As XElement = enumerator.Current
						Return item.Value
					End If
				Finally
					Dim enumerator As IEnumerator(Of XElement)
					Dim flag As Boolean = enumerator IsNot Nothing
					If flag Then
						enumerator.Dispose()
					End If
				End Try
				Return Nothing
			End Get
			Set(value As String)
				Try
					Dim enumerator As IEnumerator(Of XElement) = source.GetEnumerator()
					If enumerator.MoveNext() Then
						Dim item As XElement = enumerator.Current
						item.Value = value
					End If
				Finally
					Dim enumerator As IEnumerator(Of XElement)
					Dim flag As Boolean = enumerator IsNot Nothing
					If flag Then
						enumerator.Dispose()
					End If
				End Try
			End Set
		End Property

		' Token: 0x17000009 RID: 9
		' (get) Token: 0x06000022 RID: 34 RVA: 0x0000211C File Offset: 0x0000051C
		' (set) Token: 0x06000023 RID: 35 RVA: 0x00002184 File Offset: 0x00000584
		Public Shared Property AttributeValue(source As IEnumerable(Of XElement), name As XName) As String
			Get
				Try
					Dim enumerator As IEnumerator(Of XElement) = source.GetEnumerator()
					If enumerator.MoveNext() Then
						Dim item As XElement = enumerator.Current
						Return CStr(item.Attribute(name))
					End If
				Finally
					Dim enumerator As IEnumerator(Of XElement)
					Dim flag As Boolean = enumerator IsNot Nothing
					If flag Then
						enumerator.Dispose()
					End If
				End Try
				Return Nothing
			End Get
			Set(value As String)
				Try
					Dim enumerator As IEnumerator(Of XElement) = source.GetEnumerator()
					If enumerator.MoveNext() Then
						Dim item As XElement = enumerator.Current
						item.SetAttributeValue(name, value)
					End If
				Finally
					Dim enumerator As IEnumerator(Of XElement)
					Dim flag As Boolean = enumerator IsNot Nothing
					If flag Then
						enumerator.Dispose()
					End If
				End Try
			End Set
		End Property

		' Token: 0x1700000A RID: 10
		' (get) Token: 0x06000024 RID: 36 RVA: 0x000021E4 File Offset: 0x000005E4
		' (set) Token: 0x06000025 RID: 37 RVA: 0x00002204 File Offset: 0x00000604
		Public Shared Property AttributeValue(source As XElement, name As XName) As String
			Get
				Return CStr(source.Attribute(name))
			End Get
			Set(value As String)
				source.SetAttributeValue(name, value)
			End Set
		End Property

		' Token: 0x06000026 RID: 38 RVA: 0x00002214 File Offset: 0x00000614
		<EditorBrowsable(EditorBrowsableState.Never)>
		Public Shared Function CreateAttribute(name As XName, value As Object) As XAttribute
			Dim flag As Boolean = value Is Nothing
			Dim CreateAttribute As XAttribute
			If flag Then
				CreateAttribute = Nothing
			Else
				CreateAttribute = New XAttribute(name, RuntimeHelpers.GetObjectValue(value))
			End If
			Return CreateAttribute
		End Function

		' Token: 0x06000027 RID: 39 RVA: 0x00002240 File Offset: 0x00000640
		<EditorBrowsable(EditorBrowsableState.Never)>
		Public Shared Function CreateNamespaceAttribute(name As XName, ns As XNamespace) As XAttribute
			Dim a As XAttribute = New XAttribute(name, ns.NamespaceName)
			a.AddAnnotation(ns)
			Return a
		End Function

		' Token: 0x06000028 RID: 40 RVA: 0x00002268 File Offset: 0x00000668
		<EditorBrowsable(EditorBrowsableState.Never)>
		Public Shared Function RemoveNamespaceAttributes(inScopePrefixes As String(), inScopeNs As XNamespace(), attributes As List(Of XAttribute), obj As Object) As Object
			Dim flag As Boolean = obj IsNot Nothing
			If flag Then
				Dim elem As XElement = TryCast(obj, XElement)
				flag = elem IsNot Nothing
				If flag Then
					Return InternalXmlHelper.RemoveNamespaceAttributes(inScopePrefixes, inScopeNs, attributes, elem)
				End If
				Dim elems As IEnumerable = TryCast(obj, IEnumerable)
				flag = elems IsNot Nothing
				If flag Then
					Return InternalXmlHelper.RemoveNamespaceAttributes(inScopePrefixes, inScopeNs, attributes, elems)
				End If
			End If
			Return obj
		End Function

		' Token: 0x06000029 RID: 41 RVA: 0x000022C8 File Offset: 0x000006C8
		<EditorBrowsable(EditorBrowsableState.Never)>
		Public Shared Function RemoveNamespaceAttributes(inScopePrefixes As String(), inScopeNs As XNamespace(), attributes As List(Of XAttribute), obj As IEnumerable) As IEnumerable
			Dim flag As Boolean = obj IsNot Nothing
			Dim RemoveNamespaceAttributes As IEnumerable
			If flag Then
				Dim elems As IEnumerable(Of XElement) = TryCast(obj, IEnumerable(Of XElement))
				flag = elems IsNot Nothing
				If flag Then
					RemoveNamespaceAttributes = elems.[Select](AddressOf New InternalXmlHelper.RemoveNamespaceAttributesClosure(inScopePrefixes, inScopeNs, attributes).ProcessXElement)
				Else
					RemoveNamespaceAttributes = obj.Cast().[Select](AddressOf New InternalXmlHelper.RemoveNamespaceAttributesClosure(inScopePrefixes, inScopeNs, attributes).ProcessObject)
				End If
			Else
				RemoveNamespaceAttributes = obj
			End If
			Return RemoveNamespaceAttributes
		End Function

		' Token: 0x0600002A RID: 42 RVA: 0x0000233C File Offset: 0x0000073C
		<EditorBrowsable(EditorBrowsableState.Never)>
		Public Shared Function RemoveNamespaceAttributes(inScopePrefixes As String(), inScopeNs As XNamespace(), attributes As List(Of XAttribute), e As XElement) As XElement
			Dim flag As Boolean = e IsNot Nothing
			If flag Then
				Dim nextA As XAttribute
				Dim a As XAttribute = e.FirstAttribute
				While a IsNot Nothing
					nextA = a.NextAttribute
					flag = a.IsNamespaceDeclaration
					If flag Then
						Dim ns As XNamespace = a.Annotation(Of XNamespace)()
						Dim prefix As String = a.Name.LocalName
						flag = ns IsNot Nothing
						If flag Then
							Dim flag2 As Boolean = inScopePrefixes IsNot Nothing AndAlso inScopeNs IsNot Nothing
							If flag2 Then
								Dim lastIndex As Integer = inScopePrefixes.Length - 1
								Dim num As Integer = 0
								Dim num2 As Integer = lastIndex
								Dim i As Integer = num
								Dim currentInScopeNs As XNamespace
								While True
									Dim num3 As Integer = i
									Dim num4 As Integer = num2
									If num3 > num4 Then
										GoTo IL_00BF
									End If
									Dim currentInScopePrefix As String = inScopePrefixes(i)
									currentInScopeNs = inScopeNs(i)
									flag2 = prefix.Equals(currentInScopePrefix)
									If flag2 Then
										Exit For
									End If
									i += 1
								End While
								flag = ns Is currentInScopeNs
								If flag Then
									a.Remove()
								End If
								a = Nothing
							End If
							IL_00BF:
							flag2 = a IsNot Nothing
							If flag2 Then
								flag = attributes IsNot Nothing
								Dim flag3 As Boolean
								If flag Then
									Dim lastIndex2 As Integer = attributes.Count - 1
									Dim num5 As Integer = 0
									Dim num6 As Integer = lastIndex2
									Dim j As Integer = num5
									Dim currentInScopeNs2 As XNamespace
									While True
										Dim num7 As Integer = j
										Dim num4 As Integer = num6
										If num7 > num4 Then
											GoTo IL_015C
										End If
										Dim currentA As XAttribute = attributes(j)
										Dim currentInScopePrefix2 As String = currentA.Name.LocalName
										currentInScopeNs2 = currentA.Annotation(Of XNamespace)()
										flag2 = currentInScopeNs2 IsNot Nothing
										If flag2 Then
											flag = prefix.Equals(currentInScopePrefix2)
											If flag Then
												Exit For
											End If
										End If
										j += 1
									End While
									flag3 = ns Is currentInScopeNs2
									If flag3 Then
										a.Remove()
									End If
									a = Nothing
								End If
								IL_015C:
								flag3 = a IsNot Nothing
								If flag3 Then
									a.Remove()
									attributes.Add(a)
								End If
							End If
						End If
					End If
					a = nextA
				End While
			End If
			Return e
		End Function

		' Token: 0x02000009 RID: 9
		<CompilerGenerated()>
		<DebuggerNonUserCode()>
		<EditorBrowsable(EditorBrowsableState.Never)>
		Private NotInheritable Class RemoveNamespaceAttributesClosure
			' Token: 0x0600002B RID: 43 RVA: 0x000024E0 File Offset: 0x000008E0
			<EditorBrowsable(EditorBrowsableState.Never)>
			Friend Sub New(inScopePrefixes As String(), inScopeNs As XNamespace(), attributes As List(Of XAttribute))
				Me.m_inScopePrefixes = inScopePrefixes
				Me.m_inScopeNs = inScopeNs
				Me.m_attributes = attributes
			End Sub

			' Token: 0x0600002C RID: 44 RVA: 0x00002500 File Offset: 0x00000900
			<EditorBrowsable(EditorBrowsableState.Never)>
			Friend Function ProcessXElement(elem As XElement) As XElement
				Return InternalXmlHelper.RemoveNamespaceAttributes(Me.m_inScopePrefixes, Me.m_inScopeNs, Me.m_attributes, elem)
			End Function

			' Token: 0x0600002D RID: 45 RVA: 0x0000252C File Offset: 0x0000092C
			<EditorBrowsable(EditorBrowsableState.Never)>
			Friend Function ProcessObject(obj As Object) As Object
				Dim elem As XElement = TryCast(obj, XElement)
				Dim flag As Boolean = elem IsNot Nothing
				Dim ProcessObject As Object
				If flag Then
					ProcessObject = InternalXmlHelper.RemoveNamespaceAttributes(Me.m_inScopePrefixes, Me.m_inScopeNs, Me.m_attributes, elem)
				Else
					ProcessObject = obj
				End If
				Return ProcessObject
			End Function

			' Token: 0x0400000A RID: 10
			Private m_inScopePrefixes As String()

			' Token: 0x0400000B RID: 11
			Private m_inScopeNs As XNamespace()

			' Token: 0x0400000C RID: 12
			Private m_attributes As List(Of XAttribute)
		End Class
	End Class
End Namespace
