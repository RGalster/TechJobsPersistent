using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

// pt 2 adding a job todo no.1 completed

namespace TechJobsPersistent.ViewModels
{
    public class AddJobViewModel
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public List<SelectListItem> AllEmployers { get; set; }
    }
}
