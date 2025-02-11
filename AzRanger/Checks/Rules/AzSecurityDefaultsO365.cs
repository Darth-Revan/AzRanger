﻿using AzRanger.Models;

namespace AzRanger.Checks.Rules
{
    [RuleMeta("AzSecurityDefaultsO365", ScopeEnum.AAD, MaturityLevel.Mature, "https://entra.microsoft.com/#view/Microsoft_AAD_IAM/TenantOverview.ReactView")]
    [CISM365("1.1.1", "", Level.L1, "v2.0")]
    [RuleInfo("Security Defaults should be disabled.", "Security Defaults prevents you from using more advanced security features.", 0, null, null, "Disable Security Defaults and use more advance security features.")]
    class AzSecurityDefaultsO365 : BaseCheck
    {
        public override CheckResult Audit(Tenant tenant)
        {
            if (tenant.TenantSettings.TenantSkuInfo.aadPremium)
            {
                this.SetReason("Not applicable because Tenant has Premium License");
                return CheckResult.NotApplicable;
            }
            if (tenant.TenantSettings.SecurityDefaults.securityDefaultsEnabled == false)
            {
                return CheckResult.NoFinding;
            }
            return CheckResult.Finding;
        }
    }
}
