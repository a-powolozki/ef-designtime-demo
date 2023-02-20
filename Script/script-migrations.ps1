param([string]$outputPath)

# check if dotnet ef tools installed
$packageName = "dotnet-ef"
if( (dotnet tool list --global |? { $_.Split(' ')[0].Trim() -eq $packageName }).Length -eq 0) {
    # not installed, must install
    dotnet tool install --global $packageName
}

$params = "-p=.\EF-Script-Eval\EF-Script-Eval.csproj", "-s=.\DesignTimeLib\DesignTimeLib.csproj", "-i", "--no-transactions"  

if([string]::IsNullOrWhiteSpace($outputPath) -eq $false) {
    $params += "-o=$outputPath"
}

& "dotnet" ef migrations script $params

