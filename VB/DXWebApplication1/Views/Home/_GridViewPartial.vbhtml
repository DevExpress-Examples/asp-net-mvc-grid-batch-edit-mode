@Code
    Dim grid As GridViewExtension = Html.DevExpress().GridView( _
        Sub(settings)
                settings.Name = "GridView"
                settings.CallbackRouteValues = New With {.Controller = "Home", .Action = "GridViewPartial"}
                settings.SettingsEditing.BatchUpdateRouteValues = New With {.Controller = "Home", .Action = "BatchUpdatePartial"}
                settings.SettingsEditing.Mode = GridViewEditingMode.Batch
                settings.CellEditorInitialize = Sub(s, e)
                                                        Dim editor As ASPxEdit = CType(e.Editor, ASPxEdit)
                                                        editor.ValidationSettings.Display = Display.Dynamic
                                                                                         
                                                End Sub
                settings.CommandColumn.Visible = True
                settings.CommandColumn.ShowDeleteButton = True
                settings.CommandColumn.ShowNewButtonInHeader = True

                settings.KeyFieldName = "ID"

                settings.Columns.Add("C1")
                settings.Columns.Add( _
                    Sub(column)
                            column.FieldName = "C2"
                            column.ColumnType = MVCxGridViewColumnType.SpinEdit
                    End Sub)
                settings.Columns.Add("C3")
                settings.Columns.Add( _
                    Sub(column)
                            column.FieldName = "C4"
                            column.ColumnType = MVCxGridViewColumnType.CheckBox
                    End Sub)
                settings.Columns.Add( _
                    Sub(column)
                            column.FieldName = "C5"
                            column.ColumnType = MVCxGridViewColumnType.DateEdit
                    End Sub)
        End Sub)
End Code
@grid.Bind(Model).GetHtml()
