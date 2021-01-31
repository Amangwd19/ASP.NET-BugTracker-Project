using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using BLL;

namespace BugTracker.Controllers
{
    public class ManageRoleController : Controller
    {
        // GET: ManageRole
        public ActionResult Index()
        {
            List<string> managers = new List<string>();
            managers.Add("gerbera");
            managers.Add("gerbera");
            managers.Add("gerbera");
            managers.Add("gerbe");
            this.ViewData["managers"] = managers;


            // List<Product> PP = new List<Product>();


            //  flowers = BuisnessManager.GetAllProducts();
            //  this.ViewData["flowers"] = flowers;

            List<Manager> allManagers = BusinessManager.GetAllManagers();
            this.ViewData["managers"] = allManagers;
            return View();
        }

        public ActionResult Details(int id)
        {
            Manager theManager = BusinessManager.GetManager(id);
            return View(theManager);

        }


        public ActionResult InsertM()
        {
            return View();
        }


        [HttpPost]
        public ActionResult InsertM(int Id, string MName, string Email,
                                string Role)
        {
            Manager newManager = new Manager
            {
                Id = Id,
                MName = MName,
                Email = Email,
                Role = Role,
                //Quantity = quantity,
                //ImageUrl = imageurl
            };

            bool status = BusinessManager.InsertM(newManager);
            if (status)
            {
                this.RedirectToAction("index", "managers");
            }
            return View();
        }



        public ActionResult UpdateM(int Id)
        {
            Manager existingManager = BusinessManager.GetManager(Id);
            return View(existingManager);
        }

        [HttpPost]
        public ActionResult UpdateM(Manager modifiedManager)
        {
            TryValidateModel(modifiedManager);
            if (ModelState.IsValid)
            {
                bool status = BusinessManager.UpdateM(modifiedManager);
                if (status)
                {
                    return this.RedirectToAction("index", "managers");
                }
            }
            return View();
        }

    }
}