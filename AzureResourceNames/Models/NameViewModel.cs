using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AzureResourceNames.Models
{
    public class NameViewModel
    {
        [Description("Organization")]
        [Required]
        public string SelectedOrganization { get; set; }

        public List<SelectListItem> Organizations { get; set; }

        [Description("Environment")]
        [Required]
        public string SelectedEnvironment { get; set; }

        public List<SelectListItem> Environments { get; set; }

        [Description("Environment Number")]
        [Required]
        [Range(1, 99)]
        public int EnvironmentNumber { get; set; }

        [Description("Azure Region")]
        [Required]
        public string SelectedRegion { get; set; }

        public List<SelectListItem> Regions { get; set; }

        [Description("Portfolio Name")]
        [Required]
        public string SelectedPortfolio { get; set; }

        public List<SelectListItem> Portfolios { get; set; }

        [Description("App Name (Short)")]
        [Required]
        [MinLength(3)]
        [MaxLength(8)]
        public string AppNameShort { get; set; }

        [Description("App Name (Long)")]
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        public string AppNameLong { get; set; }

        [Description("Resource Type")]
        [Required]
        public string SelectedResourceType { get; set; }

        public List<SelectListItem> ResourceTypes { get; set; }

        [Description("Resource Names")]
        public IEnumerable<string> ResourceNames { get; set; }

        public NameViewModel()
        {

        }
    }
}
