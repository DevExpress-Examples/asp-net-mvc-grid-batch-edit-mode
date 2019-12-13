@Code
    Dim grid = Html.DevExpress().GridView(Sub(settings)
                                              settings.Name = "grid"

                                              settings.KeyFieldName = "PersonID"
                                              settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "GridViewPartial"}

                                              settings.SettingsEditing.Mode = GridViewEditingMode.Batch
                                              settings.SettingsEditing.BatchUpdateRouteValues = New With {.Controller = "Home", .Action = "BatchEditingUpdateModelPerson"}

                                              settings.CommandColumn.Visible = True
                                              settings.CommandColumn.ShowNewButtonInHeader = True
                                              settings.CommandColumn.ShowEditButton = True
                                              settings.CommandColumn.ShowDeleteButton = True

                                              settings.Columns.Add("FirstName")
                                              settings.Columns.Add("MiddleName")
                                              settings.Columns.Add("LastName")

                                              settings.Columns.Add(Sub(c)
                                                                       c.FieldName = "Age"
                                                                       c.ColumnType = MVCxGridViewColumnType.SpinEdit
                                                                       c.Width = 50
                                                                   End Sub)

                                              settings.Columns.Add(Sub(c)
                                                                       c.FieldName = "Status"
                                                                       c.ColumnType = MVCxGridViewColumnType.ComboBox
                                                                       c.EditorProperties().ComboBox(Sub(cb)
                                                                                                         cb.Items.Add("Active", 1)
                                                                                                         cb.Items.Add("Disabled", 2)
                                                                                                     End Sub)

                                                                       c.Width = 90
                                                                   End Sub)

                                              settings.CellEditorInitialize = Sub(s, e)
                                                                                  Dim editor As ASPxEdit = CType(e.Editor, ASPxEdit)
                                                                                  editor.ValidationSettings.Display = Display.Dynamic
                                                                              End Sub

                                              settings.SettingsBehavior.AllowFocusedRow = True
                                              settings.SettingsPager.Visible = True
                                          End Sub)

    If ViewData("EditError") IsNot Nothing Then
        grid.SetEditErrorText(ViewData("EditError").ToString())
    End If
End Code

@grid.Bind(Model).GetHtml()


