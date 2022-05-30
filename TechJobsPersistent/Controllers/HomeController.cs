using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechJobsPersistent.Models;
using TechJobsPersistent.ViewModels;
using TechJobsPersistent.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace TechJobsPersistent.Controllers
{
    public class HomeController : Controller
    {
        private JobDbContext context;

        public HomeController(JobDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Job> jobs = context.Jobs.Include(j => j.Employer).ToList();

            return View(jobs);
        }


        // pt 2 adding a job todo no.2
        [HttpGet("/Add")]
        public IActionResult AddJob()
        {
            //AddJobViewModel addJobViewModel = new AddJobViewModel(queryTheDatabase);
            AddJobViewModel addJobViewModel = new AddJobViewModel(context.Employers.ToList(), context.Skills.ToList());
            
            return View(addJobViewModel);
        }

        // pt 2 adding a job todo no.4
        [HttpPost]
        public IActionResult ProcessAddJobForm(AddJobViewModel theViewModel, string[] selectedSkills)
        {
            if (ModelState.IsValid)
            {
                
                string name = theViewModel.Name;
                Employer employer = context.Employers.Find(theViewModel.EmployerId);

                Job newJob = new Job
                {
                    Name = name,
                    Employer = employer
                };


                foreach (string skill in selectedSkills)
                {
                    JobSkill newJobSkill = new JobSkill
                    {
                        Job = newJob,
                        JobId = newJob.Id,
                        SkillId = Int32.Parse(skill)
                };
                    context.JobSkills.Add(newJobSkill);
                }
                
                //save job here
                context.Jobs.Add(newJob);
                context.SaveChanges();

                return Redirect("Index");
            }
            
            return View("AddJob", theViewModel);
        }

        public IActionResult Detail(int id)
        {
            Job theJob = context.Jobs
                .Include(j => j.Employer)
                .Single(j => j.Id == id);

            List<JobSkill> jobSkills = context.JobSkills
                .Where(js => js.JobId == id)
                .Include(js => js.Skill)
                .ToList();

            JobDetailViewModel viewModel = new JobDetailViewModel(theJob, jobSkills);
            return View(viewModel);
        }
    }
}
