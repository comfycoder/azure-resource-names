using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AzureResourceNames.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using AzureResourceNames.Services;

namespace AzureResourceNames.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAzureNameService _azureNameService;

        public List<SelectListItem> Organizations { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "MM", Text = "My Mockups" },
            new SelectListItem { Value = "CC", Text = "Comfy Coder" }
        };

        public List<SelectListItem> Environments { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "T", Text = "Test" },
            new SelectListItem { Value = "D", Text = "Development" },
            new SelectListItem { Value = "M", Text = "Demo" },
            new SelectListItem { Value = "X", Text = "PreProd" },
            new SelectListItem { Value = "P", Text = "Prod" },
            new SelectListItem { Value = "NP", Text = "Shared NonProd" },
            new SelectListItem { Value = "PR", Text = "Shared Prod" }
        };

        public List<SelectListItem> Regions { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "NC1", Text = "North Central US" },
            new SelectListItem { Value = "EA1", Text = "East US" },
            new SelectListItem { Value = "EA2", Text = "East US 2" },
            new SelectListItem { Value = "SC1", Text = "South Central US" }
        };

        public List<SelectListItem> Portfolios { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "", Text = "-- Select Portfolio --" },
            new SelectListItem { Value = "Demos", Text = "Demos" },
            new SelectListItem { Value = "POC", Text = "ProofOfConcepts" }
        };

        public List<SelectListItem> ResourceTypes { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "ALL", Text = "All Resources" },
            new SelectListItem { Value = "SP", Text = "Service Principal" },
            new SelectListItem { Value = "RG", Text = "Resource Group" },
            new SelectListItem { Value = "ASP", Text = "Application Service Plan" },
            new SelectListItem { Value = "AS", Text = "Application Service" },
            new SelectListItem { Value = "FA", Text = "Function App" },
            new SelectListItem { Value = "AIS", Text = "Application Insights" },
            new SelectListItem { Value = "SQLSVR", Text = "SQL Server" },
            new SelectListItem { Value = "SQLDB", Text = "SQL Database" },
            new SelectListItem { Value = "KV", Text = "Key Vault" },
            new SelectListItem { Value = "SA", Text = "Storage Account" },
            new SelectListItem { Value = "BV", Text = "Backup Vault" },
            new SelectListItem { Value = "AA", Text = "Automation Account" },
            new SelectListItem { Value = "COS", Text = "Cosmos DB" },
            new SelectListItem { Value = "CCV", Text = "Computer Vision" },
            new SelectListItem { Value = "CFA", Text = "Cognitive Face" },
            new SelectListItem { Value = "CST", Text = "Cognitive Speech to Text" },
            new SelectListItem { Value = "CTS", Text = "Cognitive Text to Speech" },
            new SelectListItem { Value = "CTR", Text = "Cognitive Speech Translation" }
        };

        public HomeController(IAzureNameService azureNameService)
        {
            _azureNameService = azureNameService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var viewModel = new NameViewModel
            {
                SelectedOrganization = "MM",
                Organizations = Organizations,
                SelectedEnvironment = "D",
                Environments = Environments,
                EnvironmentNumber = 1,
                SelectedRegion = "NC1",
                Regions = Regions,
                SelectedPortfolio = "POC",
                Portfolios = Portfolios,
                SelectedResourceType = "ALL",
                ResourceTypes = ResourceTypes,
                AppNameShort = "MyApp",
                AppNameLong = "MyApplicationName"
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(NameViewModel viewModel)
        {
            viewModel.Organizations = Organizations;
            viewModel.Environments = Environments;
            viewModel.Regions = Regions;
            viewModel.Portfolios = Portfolios;
            viewModel.ResourceTypes = ResourceTypes;

            viewModel.ResourceNames = _azureNameService.GetResourceNames(viewModel);

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
