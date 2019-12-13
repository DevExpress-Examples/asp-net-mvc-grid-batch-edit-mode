Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.DataAnnotations
Imports System.Linq
Imports System.Web

Namespace DXWebApplication1.Models
	Public Class Person
		Public Sub New()
		End Sub
		Private privatePersonID As Integer
		<Key> _
		Public Property PersonID() As Integer
			Get
				Return privatePersonID
			End Get
			Set(ByVal value As Integer)
				privatePersonID = value
			End Set
		End Property

		Private privateFirstName As String
		<Required(ErrorMessage := "Field is required")> _
		Public Property FirstName() As String
			Get
				Return privateFirstName
			End Get
			Set(ByVal value As String)
				privateFirstName = value
			End Set
		End Property
		Private privateMiddleName As String
		<Required(ErrorMessage := "Field is required")> _
		Public Property MiddleName() As String
			Get
				Return privateMiddleName
			End Get
			Set(ByVal value As String)
				privateMiddleName = value
			End Set
		End Property
		Private privateLastName As String
		<Required(ErrorMessage := "Field is required")> _
		Public Property LastName() As String
			Get
				Return privateLastName
			End Get
			Set(ByVal value As String)
				privateLastName = value
			End Set
		End Property

		Private privateAge As Integer
		Public Property Age() As Integer
			Get
				Return privateAge
			End Get
			Set(ByVal value As Integer)
				privateAge = value
			End Set
		End Property
		Private privateStatus As Integer
		Public Property Status() As Integer
			Get
				Return privateStatus
			End Get
			Set(ByVal value As Integer)
				privateStatus = value
			End Set
		End Property
	End Class
End Namespace