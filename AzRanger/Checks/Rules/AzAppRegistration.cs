﻿using AzRanger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzRanger.Checks.Rules
{
    [RuleMeta("AzAppRegistration", ScopeEnum.AAD, MaturityLevel.Mature, "https://entra.microsoft.com/#view/Microsoft_AAD_UsersAndTenants/UserManagementMenuBlade/~/UserSettings/menuId/UserSettings")]
    [CISM365("2.2", "", Level.L2, "v2.0")]
    [CISAZ("1.14", "", Level.L2, "v2.0")]
    [RuleInfo("Users are allowed to register own applications", "Allowing user to register their own applications allows an attacker to persist access or to register an internal malicious applications.", 7, "https://www.cloud-architekt.net/detection-and-mitigation-consent-grant-attacks-azuread/", null, @"Go to <a href=""https://portal.azure.com/#blade/Microsoft_AAD_IAM/UsersManagementMenuBlade/UserSettings"">https://portal.azure.com/#blade/Microsoft_AAD_IAM/UsersManagementMenuBlade/UserSettings</a> and switch the button ""Users can register applications"" to ""No"".")]
    class AzAppRegistration : BaseCheck
    {
        public override CheckResult Audit(Tenant tenant)
        {
            if(tenant.TenantSettings.DirectoryProperties.usersCanRegisterApps == false)
            {
                return CheckResult.NoFinding;
            }
            return CheckResult.Finding;
        }
    }
}
