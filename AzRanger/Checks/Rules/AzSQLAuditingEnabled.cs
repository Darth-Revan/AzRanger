﻿using AzRanger.Models;
using AzRanger.Models.AzMgmt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzRanger.Checks.Rules
{
    [RuleMeta("AzSQLAuditingEnabled", ScopeEnum.Azure, MaturityLevel.Mature, "https://portal.azure.com/#blade/HubsExtension/BrowseResource/resourceType/Microsoft.Sql%2Fservers", ServiceEnum.SQLServer)]
    [CISAZ("4.1.1", "", Level.L1, "v2.0")]
    [RuleInfo("No SQLServer Auditing is enabled", "Irregular Database activities, anomalies and security violations might stay unnoticed.", 1, null, null, @"In the Azure Portal go to ""SQL Servers"" and click on ""Auditing"" for each instance.")]
    internal class AzSQLAuditingEnabled : BaseCheck
    {
        public override CheckResult Audit(Tenant tenant)
        {
            bool passed = true;
            
            foreach(Subscription sub in tenant.Subscriptions.Values)
            {
                if(sub.Resources.SQLServers == null)
                {
                    this.SetReason("You do not have SQLServers or the user cannot access them.");
                    return CheckResult.NotApplicable;
                }
                foreach(SQLServer server in sub.Resources.SQLServers)
                {
                    if (server.auditingSettings.properties.state == "Disabled")
                    {
                        passed = false;
                        this.AddAffectedEntity(server);
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
