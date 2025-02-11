﻿using AzRanger.Models;
using AzRanger.Models.AzMgmt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzRanger.Checks.Rules
{
    [RuleMeta("AzKeyVLogging", ScopeEnum.Azure, MaturityLevel.Mature, "https://portal.azure.com/#blade/HubsExtension/BrowseResource/resourceType/Microsoft.KeyVault%2Fvaults", ServiceEnum.KeyVault)]
    [CISAZ("5.1.5", "", Level.L1, "v2.0")]
    [RuleInfo("Key Vault without active logging", "Without active logging and monitoring, incidence or unauthorized access to the Key Vault can go unnoticed.", 1)]
    internal class AzKeyVLogging : BaseCheck
    {
        public override CheckResult Audit(Tenant tenant)
        {
            bool passed = true;
            
            foreach(Subscription sub in tenant.Subscriptions.Values)
            {
                foreach(KeyVault vault in sub.Resources.KeyVaults)
                {
                    bool passedSettings = false;
                    foreach(DiagnosticSettings diagnosticSettings in vault.DiagnosticSettings)
                    {
                        foreach(DiagnosticSettingsLog log in diagnosticSettings.properties.logs)
                        {
                            if(log.category == "AuditEvent" && log.retentionPolicy.enabled && log.retentionPolicy.days < 0)
                            {
                                passedSettings = true;
                            }
                        }
                    }
                    if(passedSettings == false)
                    {
                        passed = false;
                        this.AddAffectedEntity(vault);
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
