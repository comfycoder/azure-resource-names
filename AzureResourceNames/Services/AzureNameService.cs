using AzureResourceNames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureResourceNames.Services
{
    public class AzureNameService : IAzureNameService
    {
        public IEnumerable<string> GetResourceNames(NameViewModel viewModel)
        {
            var resourceNames = new List<string>();

            if (viewModel.SelectedResourceType == "ALL")
            {
                foreach (var item in viewModel.ResourceTypes)
                {
                    var resourceType = item.Value;

                    var results = GetResourceName(viewModel, resourceType);

                    resourceNames.AddRange(results);
                }
            }
            else
            {
                var resourceType = viewModel.SelectedResourceType;

                var results = GetResourceName(viewModel, resourceType);

                resourceNames.AddRange(results);
            }

            return resourceNames;
        }

        private string GetEnvironmentName(string environmentCode)
        {
            var name = "Test";

            switch (environmentCode)
            {
                case "T":
                    name = "Test";
                    break;

                case "D":
                    name = "Dvlp";
                    break;

                case "M":
                    name = "Demo";
                    break;

                case "X":
                    name = "PreProd";
                    break;

                case "P":
                    name = "Prod";
                    break;

                case "NP":
                    name = "SharedNonProd";
                    break;

                case "PR":
                    name = "SharedProd";
                    break;
            }

            return name;
        }

        public IEnumerable<string> GetResourceName(NameViewModel viewModel, string resourceType)
        {
            var resourceNames = new List<string>();

            var organization = viewModel.SelectedOrganization;
            var environmentCode = viewModel.SelectedEnvironment;
            var environmentNumber = viewModel.EnvironmentNumber;
            var environmentSuffix = environmentCode.Length > 1 ? $"{environmentNumber}" : $"0{environmentNumber}";
            var environment = $"{environmentCode}{environmentSuffix}";
            var environmentName = GetEnvironmentName(environmentCode);
            var region = viewModel.SelectedRegion;
            var portfolio = viewModel.SelectedPortfolio;
            var appNameShort = viewModel.AppNameShort;
            var appNameLong = viewModel.AppNameLong;

            switch (resourceType)
            {
                case "SP":
                    var servicePrincipalName = $"SP-{appNameLong}-{environmentCode}";
                    resourceNames.Add(servicePrincipalName);
                    servicePrincipalName = $"SP-AA-{appNameLong}-{environmentCode}";
                    resourceNames.Add(servicePrincipalName);
                    servicePrincipalName = $"SP-RM-{portfolio}-{environmentCode}";
                    resourceNames.Add(servicePrincipalName);
                    break;

                case "RG":
                    var resourceGroupName = $"RG-{organization}-{region}-{environment}-{portfolio}-{appNameShort}";
                    resourceNames.Add(resourceGroupName);
                    break;

                case "ASP":
                    var appServicePlanName = $"ASP-{organization}-{appNameShort}-{region}-{environment}";
                    resourceNames.Add(appServicePlanName);
                    break;

                case "AS":
                    var appServiceName = $"AS-{organization}-{appNameShort}-{region}-{environment}";
                    resourceNames.Add(appServiceName);
                    appServiceName = $"AS-{organization}-{appNameShort}-{region}-{environment}-WEB";
                    resourceNames.Add(appServiceName);
                    appServiceName = $"AS-{organization}-{appNameShort}-{region}-{environment}-API";
                    resourceNames.Add(appServiceName);
                    break;

                case "FA":
                    var functionAppName = $"FA-{organization}-{appNameShort}-{region}-{environment}";
                    resourceNames.Add(functionAppName);
                    break;

                case "AIS":
                    var appInsightsName = $"AIS-{organization}-{appNameShort}-{region}-{environment}";
                    resourceNames.Add(appInsightsName);
                    appInsightsName = $"AIS-{organization}-{appNameShort}-{region}-{environment}-WEB";
                    resourceNames.Add(appInsightsName);
                    appInsightsName = $"AIS-{organization}-{appNameShort}-{region}-{environment}-API";
                    resourceNames.Add(appInsightsName);
                    appInsightsName = $"AIS-{organization}-{appNameShort}-{region}-{environment}-FUNC";
                    resourceNames.Add(appInsightsName);
                    break;

                case "SQLSVR":
                    var sqlServerName = $"SQL-{organization}-{appNameShort}-{region}-{environment}";
                    resourceNames.Add(sqlServerName);
                    break;

                case "SQLDB":
                    var sqlDatabaseName = $"{appNameLong}_{environmentName}";
                    resourceNames.Add(sqlDatabaseName);
                    break;

                case "KV":
                    var keyVaultName = $"KV-{organization}-{appNameShort}-{region}-{environment}";
                    resourceNames.Add(keyVaultName.ToLower());
                    break;

                case "SA":
                    var storageAccountName = $"sa{organization}{appNameShort}{region}{environment}";
                    resourceNames.Add(storageAccountName.ToLower());
                    break;

                case "BV":
                    var backupVaultName = $"BV-{organization}-{appNameShort}-{region}-{environment}-L";
                    resourceNames.Add(backupVaultName.ToLower());
                    backupVaultName = $"BV-{organization}-{appNameShort}-{region}-{environment}-G";
                    resourceNames.Add(backupVaultName.ToLower());
                    break;

                case "AA":
                    var automationAccountName = $"AA-{organization}-{appNameLong}-{region}-{environment}-{portfolio}";
                    resourceNames.Add(automationAccountName);
                    break;
            }

            return resourceNames;
        }
    }
}
