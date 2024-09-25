CREATE VIEW [dbo].[EmployeeInfo]
	AS 
select 
[e].[Id] as EmployeeId, 
coalesce(e.[EmployeeName], ([p].[FirstName] + [p].[LastName])) as EmployeeFullName,
case when len(isnull(a.[State], '')) > 0 then (a.[ZipCode] + '_' + a.[State] + ', ' + [a].[City] + '-' + [a].[Street]) 
else (a.[ZipCode] + ', ' + [a].[City] + '-' + [a].[Street]) end as EmployeeFullAddress,  
([e].[CompanyName] + '(' + [e].[Position] + ')') as EmployeeCompanyInfo
from dbo.Employee as e
inner join dbo.[Address] as a on e.AddressId = a.Id
inner join dbo.Person as p on e.PersonId = p.Id;
