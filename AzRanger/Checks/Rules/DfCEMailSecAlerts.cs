using AzRanger.Models;
using AzRanger.Models.AzMgmt;
using System;
using System.Linq;

namespace AzRanger.Checks.Rules
{
    class DfCEMailSecAlerts : BaseCheck
    {
        public override CheckResult Audit(Tenant tenant)
        {
            bool passed = true;
            
            foreach(Subscription sub in tenant.Subscriptions.Values)
            {
                if (sub.SecurityContact == null || sub.SecurityContact.Count == 0)
                {
                    this.AddAffectedEntity(sub);
                    passed = false;
                    continue;
                }

                if (sub.SecurityContact.Any(x => x.properties.notificationsByRole.state != "On"))
                {
                    this.AddAffectedEntity(sub);
                    passed = false;
                    continue;
                }

                if (sub.SecurityContact.Any(x => !x.properties.notificationsByRole.roles.Contains("Owner")))
                {
                    this.AddAffectedEntity(sub);
                    passed = false;
                    continue;
                }
            }

            return passed ? CheckResult.NoFinding : CheckResult.Finding;
        }
    }
}
