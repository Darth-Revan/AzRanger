﻿using AzRanger.Models;
using AzRanger.Models.ExchangeOnline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzRanger.Checks.Rules
{
    [RuleMeta("EXOSpamPolicy", ScopeEnum.EXO, MaturityLevel.Mature, "https://security.microsoft.com/antispam")]
    [CISM365("4.2", "", Level.L1, "v2.0")]
    [RuleInfo("Exchange Online Spam policy does not notify admins if a mail is blocked", "The increases the reaction time in case a user's account starts to send malicious mails.", 1, null, null, "Go to the Security Center and change or add the needed Anti-Spam Policy.")]
    class EXOSpamPolicy : BaseCheck
    {
        public override CheckResult Audit(Tenant tenant)
        {
            foreach(HostedOutboundSpamFilterPolicy policy in tenant.ExchangeOnlineSettings.HostedOutboundSpamFilterPolicy)
            {
                if (policy.BccSuspiciousOutboundMail & policy.NotifyOutboundSpam & policy.IsDefault)
                {
                    return CheckResult.NoFinding;
                }
            }
            return CheckResult.Finding;
        }
    }
}
