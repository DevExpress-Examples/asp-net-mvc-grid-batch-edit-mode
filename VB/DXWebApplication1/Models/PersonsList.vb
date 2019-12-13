Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace DXWebApplication1.Models
	Public Class PersonsList
		Public Shared Function GetPersons() As List(Of Person)
			If HttpContext.Current.Session("Persons") Is Nothing Then
				Dim list As New List(Of Person)()

				list.Add(New Person() With {.PersonID = 1, .FirstName = "David", .MiddleName = "Jordan", .LastName = "Adler", .Age = 26, .Status = 1})
				list.Add(New Person() With {.PersonID = 2, .FirstName = "Michael", .MiddleName = "Christopher", .LastName = "Alcamo", .Age = 32, .Status = 2})
				list.Add(New Person() With {.PersonID = 3, .FirstName = "Amy", .MiddleName = "Gabrielle", .LastName = "Altmann", .Age = 25, .Status = 1})
				list.Add(New Person() With {.PersonID = 4, .FirstName = "Meredith", .MiddleName = "Margot", .LastName = "Berman", .Age = 36, .Status = 2})
				list.Add(New Person() With {.PersonID = 5, .FirstName = "Margot", .MiddleName = "Sydney", .LastName = "Atlas", .Age = 28, .Status = 1})
				list.Add(New Person() With {.PersonID = 6, .FirstName = "Eric", .MiddleName = "Zachary", .LastName = "Berkowitz", .Age = 31, .Status = 2})
				list.Add(New Person() With {.PersonID = 7, .FirstName = "Kyle", .MiddleName = "Adler", .LastName = "Bernardo", .Age = 29, .Status = 2})
				list.Add(New Person() With {.PersonID = 8, .FirstName = "Liz", .MiddleName = "Altmann", .LastName = "Bice", .Age = 32, .Status = 1})

				HttpContext.Current.Session("Persons") = list
			End If
			Return CType(HttpContext.Current.Session("Persons"), List(Of Person))
		End Function

		Public Shared Sub AddPerson(ByVal person As Person)
			Dim list As List(Of Person) = GetPersons()
			person.PersonID = list.Count + 1

			list.Add(person)
		End Sub

		Public Shared Sub UpdatePerson(ByVal personInfo As Person)
			Dim editedPerson As Person = GetPersons().Where(Function(m) m.PersonID = personInfo.PersonID).First()

			editedPerson.FirstName = personInfo.FirstName
			editedPerson.MiddleName = personInfo.MiddleName
			editedPerson.LastName = personInfo.LastName
			editedPerson.Age = personInfo.Age
			editedPerson.Status = personInfo.Status
		End Sub

		Public Shared Sub DeletePerson(ByVal personId As Integer)
			Dim list As List(Of Person) = GetPersons()
			Dim deletedPerson As Person = list.Where(Function(m) m.PersonID = personId).First()
			If deletedPerson IsNot Nothing Then
				list.Remove(deletedPerson)
			End If
		End Sub
	End Class
End Namespace