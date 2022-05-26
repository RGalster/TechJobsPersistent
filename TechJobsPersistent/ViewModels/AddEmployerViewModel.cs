using System.ComponentModel.DataAnnotations;

namespace TechJobsPersistent.ViewModels
{
    public class AddEmployerViewModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }
    }
}

// I'm looking at the AddJobSkillViewModel and saying to myself "self, this view should have all the same functionality as AddJobSkillViewModel"

//public class AddJobSkillViewModel
//{
//    [Required(ErrorMessage = "Job is required")]
//    public int JobId { get; set; }

//    [Required(ErrorMessage = "Skill is required")]
//    public int SkillId { get; set; }

//    public Job Job { get; set; }

//    public List<SelectListItem> Skills { get; set; }

//    public AddJobSkillViewModel(Job theJob, List<Skill> possibleSkills)
//    {
//        Skills = new List<SelectListItem>();

//        foreach (var skill in possibleSkills)
//        {
//            Skills.Add(new SelectListItem
//            {
//                Value = skill.Id.ToString(),
//                Text = skill.Name
//            });
//        }

//        Job = theJob;
//    }

//    public AddJobSkillViewModel()
//    {
//    }
//}