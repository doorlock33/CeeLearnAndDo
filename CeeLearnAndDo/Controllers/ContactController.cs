using CeeLearnAndDo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CeeLearnAndDo.Controllers
{
    public class ContactController : Controller
    {
        ApplicationDbContext context;

        public ContactController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Contact
        public ActionResult Index()
        {
            return View(context.Contacts.ToList());
        }

        public ActionResult Create()
        {
            return View(new Contact());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Contact model)
        {
            if(ModelState.IsValid)
            {
                context.Contacts.Add(model);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}