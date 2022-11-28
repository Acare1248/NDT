dotnet ef dbcontext scaffold "Server=10.0.0.51;User=ndtuser;Password=NDTuser@1234;Database=ndt_db" Pomelo.EntityFrameworkCore.MySql ^
--context-dir Models --output-dir Models --context ndt_dbContext --force ^
--table [ndt_db].[tbComputerList]
cmd /k