<?php 

$db = new \PDO("dblib:host=.\SQLExpress;dbname=schoolofnet", "sf", "schoolofnet");

$query = "Select * from products";
$stmt = $db->prepare($query);
$stmt->execute();
$list = $stmt->fetchAll(\PDO::FETCH_ASSOC);
var_dump($list);

/*
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.products
	(
	id int NOT NULL IDENTITY (1, 1),
	name varchar(50) NOT NULL,
	descr varchar(50) NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.products ADD CONSTRAINT
	PK_products PRIMARY KEY CLUSTERED 
	(
	id
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.products SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.products', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.products', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.products', 'Object', 'CONTROL') as Contr_Per 
*/