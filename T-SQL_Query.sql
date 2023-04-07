select
cb.Name as CompanyBranchName,
c.Name as CompanyBranchName,
c.BinarySign as CompanyGroup,
case
when c.BinarySign = 0
	then (select STRING_AGG(cb.Name, ', ') from dbo.CompaniesBranches cb where cb.CompanyId = c.Id)
when c.BinarySign = 1
	then (select STRING_AGG(cb.Name, ', ') from dbo.CompaniesBranches cb)
end as RelatedBranches
from dbo."CompaniesBranches" cb
join dbo."Companies" c on cb."CompanyId" = c."Id";