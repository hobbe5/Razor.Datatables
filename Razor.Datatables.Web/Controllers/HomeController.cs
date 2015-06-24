using Razor.Datatables.Data;
using Razor.Datatables.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Razor.Datatables.Web.Controllers
{
    public class HomeController : Controller
    {
        private AdventureWorks2012Entities _entities;
        private IPersonRepository _personData;

        public HomeController()
        {
            _entities = new AdventureWorks2012Entities();
            _personData = new PersonRepository(_entities);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Datatable()
        {            
            return View(new SearchModel());
        }

        [HttpPost]
        public ActionResult Datatable(SearchModel model)
        {
            if (string.IsNullOrWhiteSpace(model.SearchName) == false)
            {
                var people = _personData.GetPersonByName(model.SearchName);
                if (people.Any())
                {
                    var json = from p in people
                               select new[] {
                                   p.rowguid.ToString(),
                                   p.FirstName + " " + p.MiddleName + " " + p.LastName,
                                   model.Admin ? p.PersonCreditCards.Any().ToString() : "false"
                               };
                    model.JsonResults = new JavaScriptSerializer().Serialize(json);
                }
            }
            return View(model);
        }

        public ActionResult Edit(Guid id)
        {
            var person = _personData.GetPersonById(id);
            return View(person);
        }

        [HttpPost]
        public ActionResult Edit(Razor.Datatables.Data.Person person, string Action)
        {
            switch (Action)
            {
                case "Cancel":
                    return RedirectToAction("Datatable");                    
            }
            return View(person);
        }

        [HttpGet]
        public ActionResult AddCreditCard()
        {
            return PartialView("~/Views/Home/EditorTemplates/PersonCreditCard.cshtml", new PersonCreditCard { ModifiedDate = DateTime.Now });
        }
    }
}