﻿using AzRanger.Models.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzRanger.AzScanner
{
    class TeamsScanner : IScannerModule
    {
        private const String TeamsClientConfiguration = "/Skype.Policy/configurations/TeamsClientConfiguration";
        private const String TenantFederationSettings = "/Skype.Policy/configurations/TenantFederationSettings/configuration/global";

        public TeamsScanner(Scanner scanner)
        {
            this.Scanner = scanner;
            this.BaseAdresse = "https://api.interfaces.records.teams.microsoft.com";
            this.Scope = new string[] { "48ac35b8-9aa8-4d74-927d-1f4a14a0b239/user_impersonation", "offline_access", "openid", "profile" };
            this.client = Helper.GetDefaultClient(additionalHeaders, this.Scanner.Proxy);
        }

        public Task<TeamsClientConfiguration> GetTeamsClientConfiguration()
        {
            return Get<TeamsClientConfiguration>(TeamsClientConfiguration);
        }

        public Task<TenantFederationSettings> GetTenantFederationSettings()
        {
            return Get<TenantFederationSettings>(TenantFederationSettings);
        }

        internal override String ManipulateResponse(String response, string endPoint)
        {
            if (response.StartsWith("["))
            {
                String newRespons = response.Substring(1, response.Length - 2);
                return newRespons;
            }
            return response;
            
        }

    }
}
