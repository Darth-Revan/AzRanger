using AzRanger.Models;
using AzRanger.Models.AzMgmt;
using System.Linq;

namespace AzRanger.Checks.Rules
{
    class DfCEAdditionalMailAlert : BaseCheck
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

                if (sub.SecurityContact.Any(x => x.properties.emails.Length == 0))
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
