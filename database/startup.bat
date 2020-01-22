set user="company-manager"
set password="Superpuperduperpassword123"
set server="company-manager.database.windows.net"
set database="CompanyManagerDB"
set currentPath=%~dp0

sqlcmd -S %server% -d %database% -U %user% -P %password% -i drop_tables.sql

sqlcmd -S %server% -d %database% -U %user% -P %password% -i tables\Permissions.sql
sqlcmd -S %server% -d %database% -U %user% -P %password% -i tables\Roles.sql
sqlcmd -S %server% -d %database% -U %user% -P %password% -i tables\Users.sql
sqlcmd -S %server% -d %database% -U %user% -P %password% -i tables\Enterprises.sql
sqlcmd -S %server% -d %database% -U %user% -P %password% -i tables\Employees.sql
sqlcmd -S %server% -d %database% -U %user% -P %password% -i tables\Purchases.sql
sqlcmd -S %server% -d %database% -U %user% -P %password% -i tables\WorkAreas.sql

pause