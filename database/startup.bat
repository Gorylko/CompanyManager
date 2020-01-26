set user="companymanageradmin"
set password="CompManPass876654312"
set server="companymanagerdb.database.windows.net"
set database="CompanyManager"
set currentPath=%~dp0


sqlcmd -S %server% -d %database% -U %user% -P %password% -i drop_sp.sql
sqlcmd -S %server% -d %database% -U %user% -P %password% -i drop_tables.sql

sqlcmd -S %server% -d %database% -U %user% -P %password% -i tables\Users.sql
sqlcmd -S %server% -d %database% -U %user% -P %password% -i tables\UserInformation.sql
sqlcmd -S %server% -d %database% -U %user% -P %password% -i tables\Permissions.sql
sqlcmd -S %server% -d %database% -U %user% -P %password% -i tables\Roles.sql
sqlcmd -S %server% -d %database% -U %user% -P %password% -i tables\Enterprises.sql
sqlcmd -S %server% -d %database% -U %user% -P %password% -i tables\Employees.sql
sqlcmd -S %server% -d %database% -U %user% -P %password% -i tables\Purchases.sql
sqlcmd -S %server% -d %database% -U %user% -P %password% -i tables\WorkAreas.sql
sqlcmd -S %server% -d %database% -U %user% -P %password% -i tables\RolesToPermissions.sql
sqlcmd -S %server% -d %database% -U %user% -P %password% -i tables\UsersToEnterprises.sql

sqlcmd -S %server% -d %database% -U %user% -P %password% -i sp\select\employee\sp_select_employees_by_enterprise_id.sql
sqlcmd -S %server% -d %database% -U %user% -P %password% -i sp\select\enterprise\sp_select_enterprise_by_id.sql
sqlcmd -S %server% -d %database% -U %user% -P %password% -i sp\select\purchase\sp_select_purchases_by_enterprise_id.sql
sqlcmd -S %server% -d %database% -U %user% -P %password% -i sp\select\work_area\sp_select_areas_by_enterprise_id.sql
sqlcmd -S %server% -d %database% -U %user% -P %password% -i sp\select\user\sp_select_salt_by_user_login.sql
sqlcmd -S %server% -d %database% -U %user% -P %password% -i sp\select\user\sp_select_user_by_id.sql

pause