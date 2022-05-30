using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechJobsPersistent.Data;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsPersistent.Controllers
{
    // pt 2 controllers todo no.1 completed
    
    public class EmployerController : Controller
    {
        private JobDbContext context;

        public EmployerController(JobDbContext dbContext)
        {
            context = dbContext;
        }


        // GET: /<controller>/
        // pt 2 controllers todo no.2 completed
        public IActionResult Index()
        {
            List<Employer> employers = context.Employers.ToList();
            return View(employers);
        }

        // pt 2 controllers todo no.3 completed
        public IActionResult Add()
        {
            AddEmployerViewModel addEmployerViewModel = new AddEmployerViewModel();
            
            return View(addEmployerViewModel);
        }

        // pt 2 controllers todo no.4
        // i believe this needs to 'post'
        // validation completed
        [HttpPost]
        public IActionResult ProcessAddEmployerForm(AddEmployerViewModel addEmployerViewModel)
        {

            if (ModelState.IsValid)
            {
                Employer newEmployer = new Employer
                {
                    Name = addEmployerViewModel.Name,
                    Location = addEmployerViewModel.Location,
                };

                context.Employers.Add(newEmployer);
                context.SaveChanges();

                // i want to redirect to Employer/Index
                return Redirect("/Employer/Index");
            }
            

            //  i passed this
            // 
            return View("Add", addEmployerViewModel);

        }

        // pt 2 controllers todo no.5
        //  this is complete
        public IActionResult About(int id)
        {
            Employer theEmployer = context.Employers
                .Find(id);
            
            return View(theEmployer);
        }
    }
}
