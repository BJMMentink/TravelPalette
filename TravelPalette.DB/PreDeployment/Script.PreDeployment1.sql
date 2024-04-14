/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
drop table if exists tblListItem
drop table if exists tblLocationTag
drop table if exists tblLocation
drop table if exists tblSchedule
drop table if exists tblTag
drop table if exists tblAddress
drop table if exists tblUser
drop table if exists tblUserList
drop table if exists tblLocation