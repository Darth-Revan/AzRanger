# CIS Controls

## CIS Azure Foundations Benchmark 2.0.0

| Control | Service | Implemented? | Implemented in Check |
| ------- | ------- | ------------ | -------------------- |
| 1.1.1 | Entra ID | &check; | AzSecurityDefaultsO365 |
| 1.1.2 | Entra ID | &check; | UserAllAdminsHaveMFA |
| 1.1.3 | Entra ID | &check; | UserAllUserHaveMFA |
| 1.1.4 | Entra ID | &cross; | - |
| 1.2.1 | Entra ID | &cross; | - |
| 1.3 | Entra ID | &check; | UserAllowCreationOfAzureTenants |
| 1.4 | Entra ID | &cross; | - |
| 1.5 | Entra ID | &cross; | - |
| 1.6 | Entra ID | &check; | UserPasswordResetRequires2Methods |
| 1.7 | Entra ID | &check; | UserPasswordBadPasswordList |
| 1.8 | Entra ID | &check; | UserReconfirmAuthenticationInformation |
| 1.9 | Entra ID | &check; | UserNotifyUserOnPasswordReset |
| 1.10 | Entra ID | &check; | UserNotifyAdminOnPasswordReset |
| 1.11 | Entra ID | &check; | UserConsent |
| 1.12 | Entra ID | &cross; | - |
| 1.13 | Entra ID | &check; | UserCanAddGalleryApps |
| 1.14 | Entra ID | &check; | AzAppRegistration |
| 1.15 | Entra ID | &check; | AzGuestRestrictions |
| 1.16 | Entra ID | &check; | AzGuestInvite |
| 1.17 | Entra ID | &check; | UserRestrictAccessToAdminPortal |
| 1.18 | Entra ID | &check; | AzRestrictUserAccessGroupFeature |
| 1.19 | Entra ID | &check; | GroupAllowUserToCreateSecGroups |
| 1.20 | Entra ID | &check; | GroupAllowsSelfService |
| 1.21 | Entra ID | &check; | GroupM365GroupManagement |
| 1.22 | Entra ID | &check; | UserRequireMFADevJoin |
| 1.23 | Entra ID | &cross; | - |
| 1.24 | Entra ID | &cross; | - |
| 1.25 | Entra ID | &check; | AzSubscriptionPolicy |
| 2.1.1 | Defender | &cross; | - |
| 2.1.2 | Defender | &cross; | - |
| 2.1.3 | Defender | &cross; | - |
| 2.1.4 | Defender | &cross; | - |
| 2.1.5 | Defender | &cross; | - |
| 2.1.6 | Defender | &cross; | - |
| 2.1.7 | Defender | &cross; | - |
| 2.1.8 | Defender | &cross; | - |
| 2.1.9 | Defender | &cross; | - |
| 2.1.10 | Defender | &cross; | - |
| 2.1.11 | Defender | &cross; | - |
| 2.1.12 | Defender | &cross; | - |
| 2.1.13 | Defender | &cross; | - |
| 2.1.14 | Defender | &check; | AzASCDefaultPolicy |
| 2.1.15 | Defender | &check; | AzAutoprovisioning |
| 2.1.16 | Defender | &cross; | - |
| 2.1.17 | Defender | &cross; | - |
| 2.1.18 | Defender | &check; | DfCEMailSecAlerts |
| 2.1.19 | Defender | &check; | DfCEAdditionalMailAlert |
| 2.1.20 | Defender | &check; | DfCEAdditionalMailAlertSeverity |
| 2.1.21 | Defender | &cross; | - |
| 2.1.22 | Defender | &cross; | - |
| 2.2.1 | Defender | &cross; | - |
| 3.1 | Storage Account | &check; | AzStorAcSecureTransfer |
| 3.2 | Storage Account | &check; | AzStorAcInfraEncrypt |
| 3.3 | Storage Account | &check; | AzStorAcKeyRotationReminder |
| 3.4 | Storage Account | &check; | AzStorAcKeyLastRotation |
| 3.5 | Storage Account | &cross; | - |
| 3.6 | Storage Account | &cross; | - |
| 3.7 | Storage Account | &check; | AzStorAcContainerPublicAccess |
| 3.8 | Storage Account | &check; | AzStorAcNetworkAccess |
| 3.9 | Storage Account | &check; | AzStorAcAllowTrustedServices |
| 3.10 | Storage Account | &cross; | - |
| 3.11 | Storage Account | &check; | AzStorAcSoftDelete |
| 3.12 | Storage Account | &check; | AzStorAcCustomKeys |
| 3.13 | Storage Account | &cross; | - |
| 3.14 | Storage Account | &cross; | - |
| 3.15 | Storage Account | &check; | AzStorAcMinTLSVersion |
| 4.1.1 | SQL Server | &check; | AzSQLAuditingEnabled |
| 4.1.2 | SQL Server | &check; | AzSQLServerInboundTraffic |
| 4.1.3 | SQL Server | &cross; | - |
| 4.1.4 | SQL Server | &check; | AzSQLServerAzADAdmin |
| 4.1.5 | SQL Server | &cross; | - |
| 4.1.6 | SQL Server | &check; | AzSQLAuditingRetention |
| 4.2.1 | Defender for SQL Server | &cross; | - |
| 4.2.2 | Defender for SQL Server | &cross; | - |
| 4.2.3 | Defender for SQL Server | &cross; | - |
| 4.2.4 | Defender for SQL Server | &cross; | - |
| 4.2.5 | Defender for SQL Server | &cross; | - |
| 4.3.1 | PostgreSQL | &cross; | - |
| 4.3.2 | PostgreSQL | &check; | AzPSQLLogCheckpoints |
| 4.3.3 | PostgreSQL | &check; | AzPSQLLogConnections |
| 4.3.4 | PostgreSQL | &check; | AzPSQLLogDisconnections |
| 4.3.5 | PostgreSQL | &check; | AzPSQLLogConnectionThrottling |
| 4.3.6 | PostgreSQL | &cross; | - |
| 4.3.7 | PostgreSQL | &cross; | - |
| 4.3.8 | PostgreSQL | &cross; | - |
| 4.4.1 | MySQL | &cross; | - |
| 4.4.2 | MySQL | &cross; | - |
| 4.4.3 | MySQL | &cross; | - |
| 4.4.4 | MySQL | &cross; | - |
| 4.5.1 | Cosmos DB | &cross; | - |
| 4.5.2 | Cosmos DB | &cross; | - |
| 4.5.3 | Cosmos DB | &cross; | - |
| 5.1.1 | Diagnostic Settings | &cross; | - |
| 5.1.2 | Diagnostic Settings | &cross; | - |
| 5.1.3 | Diagnostic Settings | &cross; | - |
| 5.1.4 | Diagnostic Settings | &cross; | - |
| 5.1.5 | Diagnostic Settings | &check; | AzKeyVLogging |
| 5.1.6 | Diagnostic Settings | &cross; | - |
| 5.1.7 | Diagnostic Settings | &cross; | - |
| 5.2.1 | Log Alerts | &check; | AzActLogAlertCreatePolicyAssignment |
| 5.2.2 | Log Alerts | &check; | AzActLogAlertDeletePolicyAssignment |
| 5.2.3 | Log Alerts | &check; | AzActLogAlertChangeNetworkSecGrp |
| 5.2.4 | Log Alerts | &check; | AzActLogAlertDeleteNetworkSecGrp |
| 5.2.5 | Log Alerts | &check; | AzActLogAlertCreateOrUpdateSecuritySolution |
| 5.2.6 | Log Alerts | &check; | AzActLogAlertDeleteSecuritySolution |
| 5.2.7 | Log Alerts | &check; | AzActLogAlertChangeSQLServerFWRule |
| 5.2.8 | Log Alerts | &check; | AzActLogAlertDeleteSQLFirewallRule |
| 5.2.9 | Log Alerts | &check; | AzActLogAlertCreateOrUpdatePublicIPAddressRule |
| 5.2.10 | Log Alerts | &check; | AzActLogAlertDeletePublicIPAddressRule |
| 5.3.1 | Application Insights | &cross; | - |
| 5.4 | Azure Monitor | &cross; | - |
| 5.5 | Azure Monitor | &cross; | - |
| 6.1 | Networking | &check; | AzActNSGRDPLimitiation |
| 6.2 | Networking | &check; | AzActNSGSSHLimitiation |
| 6.3 | Networking | &cross; | - |
| 6.4 | Networking | &cross; | - |
| 6.5 | Networking | &cross; | - |
| 6.6 | Networking | &cross; | - |
| 6.7 | Networking | &cross; | - |
| 7.1 | Virtual Machines | &cross; | - |
| 7.2 | Virtual Machines | &check; | AzVirtMManagedDiskUsage |
| 7.3 | Virtual Machines | &cross; | - |
| 7.4 | Virtual Machines | &cross; | - |
| 7.5 | Virtual Machines | &cross; | - |
| 7.6 | Virtual Machines | &cross; | - |
| 7.7 | Virtual Machines | &cross; | - |
| 8.1 | Key Vault | &check; | AzKeyVKeyExpirationRBAC |
| 8.2 | Key Vault | &check; | AzKeyVKeyExpirationNonRBAC |
| 8.3 | Key Vault | &check; | AzKeyVSecretExpirationRBAC |
| 8.4 | Key Vault | &check; | AzKeyVSecretExpirationNonRBAC |
| 8.5 | Key Vault | &check; | AzKeyVSoftDelete |
| 8.6 | Key Vault | &cross; | - |
| 8.7 | Key Vault | &cross; | - |
| 8.8 | Key Vault | &cross; | - |
| 9.1 | App Service | &cross; | - |
| 9.2 | App Service | &cross; | - |
| 9.3 | App Service | &cross; | - |
| 9.4 | App Service | &cross; | - |
| 9.5 | App Service | &cross; | - |
| 9.6 | App Service | &cross; | - |
| 9.7 | App Service | &cross; | - |
| 9.8 | App Service | &cross; | - |
| 9.9 | App Service | &cross; | - |
| 9.10 | App Service | &cross; | - |
| 9.11 | App Service | &cross; | - |
| 10.1 | Resource Locks | &cross; | - |
