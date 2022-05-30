using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using TechJobsPersistent.Models;

// pt 2 adding a job todo no.1 completed

namespace TechJobsPersistent.ViewModels
{
    public class AddJobViewModel
    {
        
        //maybe add validation here for name
        //maybe don't worry about validation for employer since there will always be one selected by default

        public string Name { get; set; }
        public int EmployerId { get; set; }
        public List<SelectListItem> AllEmployers { get; set; }
        public List<Skill> Skills { get; set; }

        //added property Skills and added to the constructor
        public AddJobViewModel(List<Employer> employers, List<Skill> theSkills)
        {
            AllEmployers = new List<SelectListItem>();
            Skills = theSkills;

            foreach (Employer employer in employers)
            {
                AllEmployers.Add(new SelectListItem
                {
                    Text = employer.Name,
                    Value = employer.Id.ToString(),
                });
                

                //add its name property to the selectListItem list
                //and its id
                //once props have been filled out, add SelectListItem obj to a new List<SelectListItem>
            }
            //use the arg to translate each Employer object from the database
            //into SelectListItem objects so i can render them in the AddJob form
        }

        public AddJobViewModel()
        {
        }
    }
}
