' Developer Express Code Central Example:
' GridView - A simple Batch Editing implementation
' 
' This example illustrates a simple implementation of a new ASPxGridView Batch
' Editing Mode functionality available starting with version 13.2:
' ASP.NET
' WebForms & MVC: GridView Batch Edit (What's new in 13.2)
' (https://community.devexpress.com/blogs/aspnet/archive/2013/12/16/asp-net-webforms-amp-mvc-gridview-batch-edit-what-39-s-new-in-13-2.aspx)
' This
' example is a standalone DB-independent solution of the online Batch Editing
' (http://demos.devexpress.com/MVCxGridViewDemos/Editing/BatchEditing) demo. Refer
' to the demo's Description for more information.
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E5046

' Note: For instructions on enabling IIS6 or IIS7 classic mode, 
' visit http://go.microsoft.com/?LinkId=9394802

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Shared Sub RegisterGlobalFilters(ByVal filters As GlobalFilterCollection)
        filters.Add(New HandleErrorAttribute())
    End Sub

    Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")
        routes.IgnoreRoute("{resource}.ashx/{*pathInfo}")

        ' MapRoute takes the following parameters, in order:
        ' (1) Route name
        ' (2) URL with parameters
        ' (3) Parameter defaults
        routes.MapRoute( _
            "Default", _
            "{controller}/{action}/{id}", _
            New With {.controller = "Home", .action = "Index", .id = UrlParameter.Optional} _
        )

    End Sub
    Sub Application_Start()
        AreaRegistration.RegisterAllAreas()
   
		RegisterGlobalFilters(GlobalFilters.Filters)
		RegisterRoutes(RouteTable.Routes)
		
		ModelBinders.Binders.DefaultBinder = new DevExpress.Web.Mvc.DevExpressEditorsBinder()
    End Sub
End Class