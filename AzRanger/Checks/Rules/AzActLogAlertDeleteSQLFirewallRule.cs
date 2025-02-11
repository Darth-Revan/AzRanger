﻿using AzRanger.Models;
using AzRanger.Models.AzMgmt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzRanger.Checks.Rules
{
    [RuleMeta("AzActLogAlertDeleteSQLFirewallRule", ScopeEnum.Azure, MaturityLevel.Mature, "https://portal.azure.com/#blade/Microsoft_Azure_Monitoring/AzureMonitoringBrowseBlade/alertsV2", ServiceEnum.StorageAccount)]
    [CISAZ("5.2.8", "", Level.L1, "v2.0")]
    [RuleInfo("No Activity Log Alert for 'Delete SQL Server Firewall Rule'", @"Unwanted changes for ""Delete SQL Server Firewall Rule"" can go unnoticed.", 0)]
    internal class AzActLogAlertDeleteSQLFirewallRule : BaseCheck
    {
        public override CheckResult Audit(Tenant tenant)
        {
            bool passed = true;
            string operationCondition = "microsoft.sql/servers/firewallrules/delete";

            foreach (Subscription sub in tenant.Subscriptions.Values)
            {
                List<string> scopes = new List<string>();
                foreach (ActivityLogAlert alert in sub.Resources.ActivityLogAlerts)
                {
                    if (alert.location == "Global" && alert.properties.enabled)
                    {
                        foreach (ActivityLogAlertAllof condition in alert.properties.condition.allOf)
                        {
                            if (condition.field == "operationName" && condition.equals.ToLower() == operationCondition)
                            {
                                foreach (String scope in alert.properties.scopes)
                                {
                                    if (!scopes.Contains(scope))
                                    {
                                        scopes.Add(scope);
                                    }
                                }
                            }
                        }
                    }
                }

                foreach (SQLServer resource in sub.Resources.SQLServers)
                {
                    bool isInscope = false;
                    foreach (String scope in scopes)
                    {
                        if (resource.id.Contains(scope))
                        {
                            isInscope = true;
                            break;
                        }
                    }
                    if (!isInscope)
                    {
                        this.AddAffectedEntity(resource);
                        passed = false;
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
