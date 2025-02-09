﻿using AzRanger.Models;
using AzRanger.Models.AzMgmt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzRanger.Checks.Rules
{
    [RuleMeta("AzStorAcMinTLS12", Scope.Azure, MaturityLevel.Mature, "https://portal.azure.com/#blade/HubsExtension/BrowseResource/resourceType/Microsoft.Storage%2FStorageAccounts", Service.StorageAccount)]
    [CISAZ("3.12", "Ensure the 'Minimum TLS version' is set to 'Version 1.2'", Level.L1, "v1.4")]
    [RuleInfo("This Storage Accounts allows access with TL1.0 or TLS.1.1.", "There exists theoretical attacks for TLS1.2.", 1, null, null, "Enable TLS1.2 for the here shown Sotrage Accounts.")]
    internal class AzStorAcMinTLS12 : BaseCheck
    {
        public override CheckResult Audit(Tenant tenant)
        {
            bool passed = true;
            
            foreach(Subscription sub in tenant.Subscriptions.Values)
            {
                foreach(StorageAccount account in sub.Resources.StorageAccounts)
                {
                    if(account.properties.minimumTlsVersion != "TLS1_2")
                    {
                        passed = false;
                        this.AddAffectedEntity(account);
                    }
                }
            }
            if (passed)
            {
                return CheckResult.NoFinding;
            }
            return CheckResult.Finding;
        }
    }
}
