[system.reflection.assembly]::LoadWithPartialName("MySql.Data") 
write-host "Create coonection to db1"

# Connect to MySQL database
$cn = New-Object -TypeName MySql.Data.MySqlClient.MySqlConnection
$cn.ConnectionString = "SERVER=50.116.86.24;PORT=3306;DATABASE=telef840_lrn;UID=telef840_lrn;PWD=zStEPTrVR_bh"
$cn.Open()
write-host "Running backup script against db1"
# Run Update Script MySQL 
$cm = New-Object -TypeName MySql.Data.MySqlClient.MySqlCommand
$sql = Get-Content "CreateDataBase.sql"
write-host $sql
$cm.Connection = $cn
$cm.CommandText = $sql
$cm.ExecuteReader()
write-host "Closing Connection"
$cn.Close()