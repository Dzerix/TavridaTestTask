SELECT 
    cb.Name AS CompanyBranchName,
    c.Name AS CompanyName,
    c.BinarySign AS CompanyGroup,
    CASE
        WHEN c.BinarySign = 0
            THEN STUFF((SELECT ', ' + cb1.Name 
                        FROM dbo.CompaniesBranches cb1 
                        WHERE cb1.CompanyId = c.Id 
                        FOR XML PATH ('')), 1,2, '')
        ELSE STUFF((SELECT ', ' + cb2.Name 
                    FROM dbo.CompaniesBranches cb2 
                    FOR XML PATH ('')), 1, 2, '')
    END AS RelatedBranches
FROM dbo.CompaniesBranches cb
JOIN dbo.Companies c ON cb.CompanyId = c.Id;