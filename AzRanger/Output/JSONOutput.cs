﻿using AzRanger.Checks;
using AzRanger.Models;
using AzRanger.Models.Generic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace AzRanger.Output
{
    public static class JSONOutput
    {
        public static void Print(Auditor auditor, string outPath)
        {
            

            if(outPath == null | outPath.Length == 0)
            {
                outPath = ".";
            }
            String outFile = Path.Combine(outPath,  "/report.json");
            using (StreamWriter file = File.CreateText(outFile))
            {
                var json = createJSON(auditor);                
                file.Write(json);
            }
        }

        public static String createJSON(Auditor auditor)
        {
            List<ResultJSONItem> NoFindingList = new List<ResultJSONItem>();
            List<ResultJSONItem> ErrorList = new List<ResultJSONItem>();
            List<ResultJSONItem> FindingList = new List<ResultJSONItem>();
            List<ResultJSONItem> NotApplicable = new List<ResultJSONItem>();

            foreach (BaseCheck check in auditor.Finding)
            {
                ResultJSONItem item = new ResultJSONItem();
                RuleInfoAttribute ruleInfo = (RuleInfoAttribute)Attribute.GetCustomAttribute(check.GetType(), typeof(RuleInfoAttribute));
                RuleMetaAttribute ruleMeta = (RuleMetaAttribute)Attribute.GetCustomAttribute(check.GetType(), typeof(RuleMetaAttribute));
                CISM365Attribute cisM365Rule = (CISM365Attribute)Attribute.GetCustomAttribute(check.GetType(), typeof(CISM365Attribute));
                CISAZAttribute cisAzRule = (CISAZAttribute)Attribute.GetCustomAttribute(check.GetType(), typeof(CISAZAttribute));

                if (ruleInfo != null)
                {
                    item.ShortDescription = ruleInfo.ShortDescription;
                    item.ReferenceLink = ruleInfo.ReferenceLink;
                    item.Risk = ruleInfo.Risk;
                    item.RiskScore = ruleInfo.RiskScore;
                    item.Solution = ruleInfo.Solution;
                    item.LongDescription = ruleInfo.LongDescription;
                }

                if (ruleMeta != null)
                {
                    item.ShortName = ruleMeta.ShortName;
                    item.PortalUrl = ruleMeta.PortalUrl;
                    item.Service = ruleMeta.Service.ToString();
                    item.Scope = ruleMeta.Scope.ToString();
                    item.MaturityLevel = ruleMeta.MaturityLevel.ToString();
                }

                if (cisM365Rule != null)
                {
                    item.Version = cisM365Rule.Version;
                    item.Section = cisM365Rule.Section;
                    item.Level = cisM365Rule.Level.ToString();
                    item.CISDocument = "CIS M365";
                }

                if (cisAzRule != null)
                {
                    item.Version = cisAzRule.Version;
                    item.Section = cisAzRule.Section;
                    item.Level = cisAzRule.Level.ToString();
                    item.CISDocument = "CIS Azure";
                }

                if (check.RawData != null)
                {
                    item.RawData = check.RawData;
                }

                if (check.GetAffectedEntity().Count > 0)
                {
                    List<AffectedItem> affectedItems = new List<AffectedItem>();
                    foreach (IReporting entity in check.GetAffectedEntity())
                    {
                        affectedItems.Add(entity.GetAffectedItem());
                    }
                    item.AffectedItems = affectedItems;
                }
                FindingList.Add(item);
            }

            foreach (BaseCheck check in auditor.NoFinding)
            {
                ResultJSONItem item = new ResultJSONItem();
                RuleInfoAttribute ruleInfo = (RuleInfoAttribute)Attribute.GetCustomAttribute(check.GetType(), typeof(RuleInfoAttribute));
                RuleMetaAttribute ruleMeta = (RuleMetaAttribute)Attribute.GetCustomAttribute(check.GetType(), typeof(RuleMetaAttribute));
                CISM365Attribute cisM365Rule = (CISM365Attribute)Attribute.GetCustomAttribute(check.GetType(), typeof(CISM365Attribute));
                CISAZAttribute cisAzRule = (CISAZAttribute)Attribute.GetCustomAttribute(check.GetType(), typeof(CISAZAttribute));

                if (ruleInfo != null)
                {
                    item.ShortDescription = ruleInfo.ShortDescription;
                    item.ReferenceLink = ruleInfo.ReferenceLink;
                    item.Risk = ruleInfo.Risk;
                    item.RiskScore = ruleInfo.RiskScore;
                    item.Solution = ruleInfo.Solution;
                    item.LongDescription = ruleInfo.LongDescription;
                }

                if (ruleMeta != null)
                {
                    item.ShortName = ruleMeta.ShortName;
                    item.PortalUrl = ruleMeta.PortalUrl;
                    item.Service = ruleMeta.Service.ToString();
                    item.Scope = ruleMeta.Scope.ToString();
                    item.MaturityLevel = ruleMeta.MaturityLevel.ToString();
                }

                if (cisM365Rule != null)
                {
                    item.Version = cisM365Rule.Version;
                    item.Section = cisM365Rule.Section;
                    item.Level = cisM365Rule.Level.ToString();
                    item.CISDocument = "CIS M365";
                }

                if (cisAzRule != null)
                {
                    item.Version = cisAzRule.Version;
                    item.Section = cisAzRule.Section;
                    item.Level = cisAzRule.Level.ToString();
                    item.CISDocument = "CIS Azure";
                }
                NoFindingList.Add(item);
            }

            foreach (BaseCheck check in auditor.Error)
            {
                ResultJSONItem item = new ResultJSONItem();
                RuleInfoAttribute ruleInfo = (RuleInfoAttribute)Attribute.GetCustomAttribute(check.GetType(), typeof(RuleInfoAttribute));
                RuleMetaAttribute ruleMeta = (RuleMetaAttribute)Attribute.GetCustomAttribute(check.GetType(), typeof(RuleMetaAttribute));
                CISM365Attribute cisM365Rule = (CISM365Attribute)Attribute.GetCustomAttribute(check.GetType(), typeof(CISM365Attribute));
                CISAZAttribute cisAzRule = (CISAZAttribute)Attribute.GetCustomAttribute(check.GetType(), typeof(CISAZAttribute));

                if (ruleInfo != null)
                {
                    item.ShortDescription = ruleInfo.ShortDescription;
                    item.ReferenceLink = ruleInfo.ReferenceLink;
                    item.Risk = ruleInfo.Risk;
                    item.RiskScore = ruleInfo.RiskScore;
                    item.Solution = ruleInfo.Solution;
                    item.LongDescription = ruleInfo.LongDescription;
                }

                if (ruleMeta != null)
                {
                    item.ShortName = ruleMeta.ShortName;
                    item.PortalUrl = ruleMeta.PortalUrl;
                    item.Service = ruleMeta.Service.ToString();
                    item.Scope = ruleMeta.Scope.ToString();
                    item.MaturityLevel = ruleMeta.MaturityLevel.ToString();
                }

                if (cisM365Rule != null)
                {
                    item.Version = cisM365Rule.Version;
                    item.Section = cisM365Rule.Section;
                    item.Level = cisM365Rule.Level.ToString();
                    item.CISDocument = "CIS M365";
                }

                if (cisAzRule != null)
                {
                    item.Version = cisAzRule.Version;
                    item.Section = cisAzRule.Section;
                    item.Level = cisAzRule.Level.ToString();
                    item.CISDocument = "CIS Azure";
                }
                ErrorList.Add(item);
            }

            foreach (BaseCheck check in auditor.NotApplicable)
            {
                ResultJSONItem item = new ResultJSONItem();
                RuleInfoAttribute ruleInfo = (RuleInfoAttribute)Attribute.GetCustomAttribute(check.GetType(), typeof(RuleInfoAttribute));
                RuleMetaAttribute ruleMeta = (RuleMetaAttribute)Attribute.GetCustomAttribute(check.GetType(), typeof(RuleMetaAttribute));
                CISM365Attribute cisM365Rule = (CISM365Attribute)Attribute.GetCustomAttribute(check.GetType(), typeof(CISM365Attribute));
                CISAZAttribute cisAzRule = (CISAZAttribute)Attribute.GetCustomAttribute(check.GetType(), typeof(CISAZAttribute));

                if (ruleInfo != null)
                {
                    item.ShortDescription = ruleInfo.ShortDescription;
                    item.ReferenceLink = ruleInfo.ReferenceLink;
                    item.Risk = ruleInfo.Risk;
                    item.RiskScore = ruleInfo.RiskScore;
                    item.Solution = ruleInfo.Solution;
                    item.LongDescription = ruleInfo.LongDescription;
                }

                if (ruleMeta != null)
                {
                    item.ShortName = ruleMeta.ShortName;
                    item.PortalUrl = ruleMeta.PortalUrl;
                    item.Service = ruleMeta.Service.ToString();
                    item.Scope = ruleMeta.Scope.ToString();
                    item.MaturityLevel = ruleMeta.MaturityLevel.ToString();
                }

                if (cisM365Rule != null)
                {
                    item.Version = cisM365Rule.Version;
                    item.Section = cisM365Rule.Section;
                    item.Level = cisM365Rule.Level.ToString();
                    item.CISDocument = "CIS M365";
                }

                if (cisAzRule != null)
                {
                    item.Version = cisAzRule.Version;
                    item.Section = cisAzRule.Section;
                    item.Level = cisAzRule.Level.ToString();
                    item.CISDocument = "CIS Azure";
                }

                NotApplicable.Add(item);
            }

            ResultJSONList FinalList = new ResultJSONList();
            FinalList.Finding = FindingList.OrderBy(x => x.RiskScore).ToList(); ;
            FinalList.NoFinding = NoFindingList.OrderBy(x => x.RiskScore).ToList();
            FinalList.Error = ErrorList.OrderBy(x => x.RiskScore).ToList();
            FinalList.NotApplicable = NotApplicable.OrderBy(x => x.RiskScore).ToList();

            var options = new JsonSerializerOptions
            {
                MaxDepth = 16,
                IncludeFields = true,
                WriteIndented = true
            };

            return JsonSerializer.Serialize(FinalList, options);
        }
    }
}
