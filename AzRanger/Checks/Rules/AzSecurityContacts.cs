﻿using AzRanger.Models;
using AzRanger.Models.AzMgmt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzRanger.Checks.Rules
{
    [RuleMeta("AzSecurityContacts", Scope.Azure, MaturityLevel.Mature, "https://portal.azure.com/?l=en.en-us#view/Microsoft_Azure_Policy/PolicyMenuBlade/~/Overview")]
    [CISAZ("2.13", "Ensure 'Additional email addresses' is Configured with a Security Contact Email", Level.L1, "v1.4")]
    [RuleInfo("Subscribion without security contact", "In case of an incident, this could increase the time span to identify the legitimate owner or responsible person for a subscription.", 2)]
    internal class AzSecurityContacts : BaseCheck
    {
        public override CheckResult Audit(Tenant tenant)
        {
            bool passed = true;
            foreach(Subscription sub in tenant.Subscriptions.Values)
            {
                if (sub.SecurityContact == null)
                {
                    passed = false;
                    this.AddAffectedEntity(sub);
                }
                else
                {

                        if (sub.SecurityContact.properties.emails == "")
                        {
                            passed = false;
                            this.AddAffectedEntity(sub);
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
