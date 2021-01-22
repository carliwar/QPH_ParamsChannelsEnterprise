USE AdministrationSwitch
GO
EXEC sp_rename 'Channel.AuthotizationNumber', 'AuthorizationNumber', 'COLUMN'
GO
EXEC sp_rename 'EnterpriseCredentials.CredenTialsUserID', 'CredentialsUserID', 'COLUMN'
GO
ALTER TABLE [ChannelNonBillableProducts] 
ALTER COLUMN ChannelID BIGINT NOT NULL
GO
-- MANY TO MANY
ALTER TABLE [ChannelEnterprise] Add CONSTRAINT FK_ChannelEnterprise_Channel FOREIGN KEY(IDChannel) REFERENCES Channel(IDChannel)
GO
ALTER TABLE [ChannelEnterprise] Add CONSTRAINT FK_ChannelEnterprise_Enterprise FOREIGN KEY(IDEnterprise) REFERENCES Enterprise(IDEnterprise)
GO
-- ONE TO MANY
ALTER TABLE [FinancialSizing] ADD CONSTRAINT FK_FinancialSizing_BusinessLine FOREIGN KEY(Dimension1ID) REFERENCES BusinessLine(IDBusinessLine)
GO
ALTER TABLE [FinancialSizing] ADD CONSTRAINT FK_FinancialSizing_SubBusinessLine FOREIGN KEY(Dimension2ID) REFERENCES SubBusinessLine(IDSubBusinessLine)
GO
ALTER TABLE [FinancialSizing] ADD CONSTRAINT FK_FinancialSizing_FinancialDimension FOREIGN KEY(Dimension3ID) REFERENCES FinancialDimension(IDFinancialDimension)
GO
-- MANY TO MANY
ALTER TABLE [EnterpriseCredentials] ADD CONSTRAINT FK_EnterpriseCredentials_Enterprise FOREIGN KEY(EnterpriseID) REFERENCES Enterprise(IDEnterprise)
GO
ALTER TABLE [EnterpriseCredentials] ADD CONSTRAINT FK_EnterpriseCredentials_CredentialsUser FOREIGN KEY(CredentialsUserID) REFERENCES CredentialsUser(IDCredentialsUser)
GO
ALTER TABLE [EnterpriseCredentials] ADD CONSTRAINT FK_EnterpriseCredentials_CredentialsServer FOREIGN KEY(CredentialsServerID) REFERENCES CredentialsServer(IDCredentialsServer)
GO
--
ALTER TABLE [ChannelNonBillableProducts] ADD CONSTRAINT FK_ChannelNonBillableProducts_NonBillableProducts FOREIGN KEY(NonBillableProductID) REFERENCES NonBillableProducts(IDNonBillableProducts)
GO
ALTER TABLE [ChannelNonBillableProducts] ADD CONSTRAINT FK_ChannelNonBillableProducts_Channel FOREIGN KEY(ChannelID) REFERENCES Channel(IDChannel)
GO
--
ALTER TABLE [Channel] ADD CONSTRAINT FK_ChannelFinancialSizing_FinancialSizing FOREIGN KEY (FinancialSizingID) REFERENCES FinancialSizing(IDFinancialSizing)
GO
ALTER TABLE [NonBillableProducts] ADD [Name] VARCHAR(200)
ALTER TABLE [NonBillableProducts] ADD [Description] VARCHAR(500)
GO
sp_rename 'Channel.ListaPrecioContado', 'PaymentMadeAccount'
GO
ALTER VIEW [dbo].[vwInformationCredentialsEnterprise] AS  
SELECT EC.[IDEnterpriseCredentials]  
      ,EC.[EnterpriseID]  
      ,E.[Establecimiento]  
      ,E.[RazonSocial]  
      ,E.[RUC]  
      ,EC.[CredentialsUserID]  
   ,CU.[Username]  
   ,CU.Password as PasswordUser  
      ,EC.[CredentialsServerID]  
   ,CS.[Username] AS UsernameServer  
      ,CS.[Password] AS PasswordServer  
      ,CS.[Servername]  
      ,CS.[Databasename]  
      ,EC.[Status]  
  FROM [dbo].[EnterpriseCredentials] EC  
  LEFT JOIN [dbo].[Enterprise] E ON E.IDEnterprise = EC.[EnterpriseID]  
  LEFT JOIN [dbo].[CredentialsUser] CU ON CU.[IDCredentialsUser] = EC.[CredentialsUserID]  
  LEFT JOIN [dbo].[CredentialsServer] CS ON CS.[IDCredentialsServer] = EC.[CredentialsServerID]  
  WHERE EC.[Status] = 1 AND CU.[Status] =1 AND E.[Status] = 1 AND CS.[Status] = 1  
GO

ALTER VIEW [dbo].[vwChannelEnterprise] AS  
SELECT   
CE.IDChannelEnterprise  
,CE.[IDChannel]  
      ,C.[Fecha]  
      ,C.[Segmento]  
   ,C.[Code]  
   ,C.IdentificatorChannelSAP  
   ,C.[IdentificatorChannelCreditNoteSAP]  
      ,C.[Description]  
      ,C.[AuthorizationNumber]  
      ,C.[ProductItemGroupCode]  
      ,C.[Declarable]  
   ,C.IVACode  
   ,C.[PaymentReceivedRequired]  
   ,C.[CodeCreditCard]  
      ,C.[PuntoEmision]  
      ,C.[Ambiente]  
      ,C.[Iva]  
      ,C.[CodigoProducto]  
      ,C.[NombreProducto]  
      ,C.[CategoriaCliente]  
      ,C.[CuentaContable]  
   ,C.BalanceAccount  
   ,C.[FinancialSizingID]  
      ,FS.[NombreDimension1]  
      ,FS.[Dimension1]  
      ,FS.[NombreDimension2]  
      ,FS.[Dimension2]  
      ,FS.[NombreDimension3]  
      ,FS.[CodeDimension3]  
      ,FS.[Dimension3]  
      ,C.[GrupoCredito]  
      ,C.[DocumentoElectronico]  
      ,C.[Relacionado]  
      --,C.[VendedorSeccion]  
   ,C.CodigoMotivoNotaCredito  
      ,C.[PaymentMadeAccount]
      ,C.[ListaPrecioCredito]  
      ,C.[LimiteCredito]  
      ,C.[Uge]  
      ,C.[Bodega]  
      ,C.[TipoFormaPago]  
      ,C.[StatusChannel]  
      ,C.[EnlaceInvoice]  
   ,C.[EnlaceCreditNote]  
   ,C.[EnlaceCotization]  
   ,CE.[IDEnterprise]  
      ,E.[Establecimiento]  
      ,E.[RazonSocial]  
      ,E.[RUC]  
      ,E.[DireccionMatriz]  
      ,E.[TributaImpuesto]  
      ,E.[Contribuyente]  
      ,E.[Ciudad]  
      ,E.[Telefono]  
      ,CE.[Status]  
   ,C.[LimitStartDateTransactions]  
      ,C.[LimitFinishDateTransactions]  
   ,ICE.[CredentialsUserID]  
      ,ICE.[Username]  
   ,ICE.PasswordUser  
      ,ICE.[CredentialsServerID]  
      ,ICE.[UsernameServer]  
      ,ICE.[PasswordServer]  
      ,ICE.[Servername]  
      ,ICE.[Databasename]  
FROM [dbo].[ChannelEnterprise] CE   
LEFT JOIN [dbo].[Channel] C  
ON C.IDChannel = CE.IDChannel  
LEFT JOIN [dbo].[Enterprise] E   
ON E.IDEnterprise = CE.IDEnterprise  
LEFT JOIN [dbo].[vwInformationCredentialsEnterprise]  ICE  
ON ICE.[EnterpriseID] = CE.[IDEnterprise] AND ICE.Status = 1  
LEFT JOIN [dbo].[vwFinancialSizing] FS ON FS.[IDFinancialSizing] = C.[FinancialSizingID] AND FS.[Status] = 1  
WHERE CE.Status = 1 