Imports Microsoft.VisualBasic
Imports DevExpress.Web.Mvc
Imports DXWebApplication1.Models
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc

Namespace DXWebApplication1.Controllers
	Public Class HomeController
		Inherits Controller
		' GET: Home
		Public Function Index() As ActionResult
			Return View(PersonsList.GetPersons())
		End Function

		Public Function GridViewPartial() As ActionResult
			Return PartialView(PersonsList.GetPersons())
		End Function

		<HttpPost, ValidateInput(False)> _
		Public Function BatchEditingUpdateModelPerson(ByVal batchValues As MVCxGridViewBatchUpdateValues(Of Person, Integer)) As ActionResult
			For Each person In batchValues.Update
				If batchValues.IsValid(person) Then
					PersonsList.UpdatePerson(person)
				Else
					batchValues.SetErrorText(person, "Correct validation errors")
				End If
			Next person

			For Each person In batchValues.Insert
				If batchValues.IsValid(person) Then
					PersonsList.AddPerson(person)
				Else
					batchValues.SetErrorText(person, "Correct validation errors")
				End If
			Next person

			For Each personID In batchValues.DeleteKeys
				PersonsList.DeletePerson(personID)
			Next personID
			Return PartialView("GridViewPartial", PersonsList.GetPersons())
		End Function

	End Class
End Namespace