# Pehelper

Initial commit of Dotnet Core MVC project.

Dotnet core CLI commands

``` dotnet core
dotnet clean
dotnet restore
dotnet run
```

## The dotnet command to choose release and runtime enviroment

``` dotnet core
dotnet publish --framework netcoreapp1.1 --runtime osx.10.11-x64
dotnet publish -c Release -r win10-x64
```

## Dotnet core publish command

``` dotnet core
dotnet publish -c release -r win7-x64 -o bin/release/win-x64
```