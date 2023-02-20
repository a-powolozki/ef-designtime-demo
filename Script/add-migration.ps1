# check if dotnet ef tools installed
$packageName = "dotnet-ef"
if( (dotnet tool list --global |? { $_.Split(' ')[0].Trim() -eq $packageName }).Length -eq 0) {
    # not installed, must install
    dotnet tool install --global $packageName
}

& dotnet ef migrations add InitialMigration -p .\EF-Script-Eval\EF-Script-Eval.csproj -s .\DesignTimeLib\DesignTimeLib.csproj -o .\Db\Migrations