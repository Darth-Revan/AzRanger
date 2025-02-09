﻿using AzRanger.Models;
using AzRanger.Models.AzMgmt;

namespace AzRanger.Checks.Rules
{
    [RuleMeta("AzStorAcSoftDelete", ScopeEnum.Azure, MaturityLevel.Mature, "https://portal.azure.com/#blade/HubsExtension/BrowseResource/resourceType/Microsoft.Storage%2FStorageAccounts", ServiceEnum.StorageAccount)]
    [CISAZ("3.11", "", Level.L1, "v2.0")]
    [RuleInfo("Storage Accounts without soft delete", "This can lead to unwanted data loss, if someone accidentally deletes data.", 1, null, "When soft delete is disabled, data cannot be recovered if they are accidentally deleted.", @"Enable ""Soft Delete"" for all Storage Accounts.")]
    internal class AzStorAcSoftDelete : BaseCheck
    {
        public override CheckResult Audit(Tenant tenant)
        {
            bool passed = true;
            
            foreach(Subscription sub in tenant.Subscriptions.Values)
            {
                foreach(StorageAccount account in sub.Resources.StorageAccounts)
                {  
                    if(account.Default.properties.deleteRetentionPolicy.enabled == false || 
                        account.Default.properties.containerDeleteRetentionPolicy.enabled == false ||
                        account.Default.properties.deleteRetentionPolicy.days == 0 ||
                        account.Default.properties.containerDeleteRetentionPolicy.days == 0
                        )
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
