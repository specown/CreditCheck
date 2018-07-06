using CreditCheck.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CreditCheck.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public ActionResult index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult index(CreditFormModel model)
        {
            string displayedCard = "None";

            if(ModelState.IsValid)
            {
                int yearsOld = calculateYears(model.dob);

                if(model.income > 30000 && yearsOld >= 18)
                {
                    displayedCard = "Barclay";
                    addVisitorInformation(model.fname, model.lname, model.income, yearsOld, displayedCard);
                    return RedirectToAction("index", "Barclay");
                    

                }

                if(model.income <= 30000 && yearsOld >= 18)
                {
                    displayedCard = "Vanquis";
                    addVisitorInformation(model.fname, model.lname, model.income, yearsOld, displayedCard);
                    return RedirectToAction("index", "Vanquis");
                }

                if (yearsOld < 18)
                {
                    addVisitorInformation(model.fname, model.lname, model.income, yearsOld, displayedCard);
                    return RedirectToAction("index", "None");
                }
            }
            return View();
        }
      
        private void addVisitorInformation(string fname, string lname, int income, int yearsOld, string displayedCard)
        {
            customerInfoContext db = new customerInfoContext();

            Visitor vis = new Visitor();
            vis.FirstName = fname;
            vis.LastName = lname;
            vis.Income = income;
            vis.YearsOld = yearsOld;
            vis.DisplayedCard = displayedCard;

            db.Visitors.Add(vis);
            try
            {
                 db.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }
           
        }

        private int calculateYears(string dob)
        {
            int years;
            DateTime parsedDob = DateTime.Parse(dob);
            DateTime today = DateTime.Today;

            TimeSpan span = today - parsedDob;
            if(span.TotalDays < 0){
                years = 0;
            }

            else{
                DateTime zeroTime = new DateTime(1, 1, 1);
                years = (zeroTime + span).Year - 1;
            }
            
            return years;
        }
    }
}