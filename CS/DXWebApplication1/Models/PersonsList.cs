using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DXWebApplication1.Models {
    public class PersonsList {
        public static List<Person> GetPersons() {
            if(HttpContext.Current.Session["Persons"] == null) {
                List<Person> list = new List<Person>();

                list.Add(new Person() { PersonID = 1, FirstName = "David", MiddleName = "Jordan", LastName = "Adler", Age = 26, Status = 1 });
                list.Add(new Person() { PersonID = 2, FirstName = "Michael", MiddleName = "Christopher", LastName = "Alcamo", Age = 32, Status = 2 });
                list.Add(new Person() { PersonID = 3, FirstName = "Amy", MiddleName = "Gabrielle", LastName = "Altmann", Age = 25, Status = 1 });
                list.Add(new Person() { PersonID = 4, FirstName = "Meredith", MiddleName = "Margot", LastName = "Berman", Age = 36, Status = 2 });
                list.Add(new Person() { PersonID = 5, FirstName = "Margot", MiddleName = "Sydney", LastName = "Atlas", Age = 28, Status = 1 });
                list.Add(new Person() { PersonID = 6, FirstName = "Eric", MiddleName = "Zachary", LastName = "Berkowitz", Age = 31, Status = 2 });
                list.Add(new Person() { PersonID = 7, FirstName = "Kyle", MiddleName = "Adler", LastName = "Bernardo", Age = 29, Status = 2 });
                list.Add(new Person() { PersonID = 8, FirstName = "Liz", MiddleName = "Altmann", LastName = "Bice", Age = 32, Status = 1 });

                HttpContext.Current.Session["Persons"] = list;
            }
            return (List<Person>)HttpContext.Current.Session["Persons"];
        }

        public static void AddPerson(Person person) {
            List<Person> list = GetPersons();
            person.PersonID = list.Count + 1;

            list.Add(person);
        }

        public static void UpdatePerson(Person personInfo) {
            Person editedPerson = GetPersons().Where(m => m.PersonID == personInfo.PersonID).First();

            editedPerson.FirstName = personInfo.FirstName;
            editedPerson.MiddleName = personInfo.MiddleName;
            editedPerson.LastName = personInfo.LastName;
            editedPerson.Age = personInfo.Age;
            editedPerson.Status = personInfo.Status;
        }

        public static void DeletePerson(int personId) {
            List<Person> list = GetPersons();
            Person deletedPerson = list.Where(m => m.PersonID == personId).First();
            if(deletedPerson != null) {
                list.Remove(deletedPerson);
            }
        }
    }
}