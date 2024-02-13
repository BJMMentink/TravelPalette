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
:r .\DefaultData\Addresses.sql
:r .\DefaultData\ListItems.sql
:r .\DefaultData\Locations.sql
:r .\DefaultData\Schedules.sql
:r .\DefaultData\Tags.sql
:r .\DefaultData\UserLists.sql
:r .\DefaultData\Users.sql