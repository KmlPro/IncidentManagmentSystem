#!/bin/bash
echo 'Start creating Read Context'
dotnet ef dbcontext scaffold "Server=localhost;Database=IncidentReportDb;User Id=sa;Password=<YourStrong@Passw0rd>;"  Microsoft.EntityFrameworkCore.SqlServer -c "IncidentReportReadDbContext" -f --output-dir=DbEntities --context-dir "./"
echo 'Read Context created sucesfully'
