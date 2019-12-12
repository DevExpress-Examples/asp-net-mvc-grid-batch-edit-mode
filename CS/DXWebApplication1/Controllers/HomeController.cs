using DevExpress.Web.Mvc;
using DXWebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DXWebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index() {
            return View(PersonsList.GetPersons());
        }

        public ActionResult GridViewPartial() {
            return PartialView(PersonsList.GetPersons());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult BatchEditingUpdateModelPerson(MVCxGridViewBatchUpdateValues<Person, int> batchValues) {
            foreach(var person in batchValues.Update) {
                if(batchValues.IsValid(person))
                    PersonsList.UpdatePerson(person);
                else
                    batchValues.SetErrorText(person, "Correct validation errors");
            }

            foreach(var person in batchValues.Insert) {
                if(batchValues.IsValid(person))
                    PersonsList.AddPerson(person);
                else
                    batchValues.SetErrorText(person, "Correct validation errors");
            }

            foreach (var personID in batchValues.DeleteKeys) {
                PersonsList.DeletePerson(personID);
            }
            return PartialView("GridViewPartial", PersonsList.GetPersons());
        }

    }
}