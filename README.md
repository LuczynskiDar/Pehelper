# Pehelper

>Dotnet Core MVC project, excercise MVC approach with the real task.

The purpose of creating Pehelper was to support mass item upload to WPLM.
Upload the .xls or .xls file. All the WISE esport files must be saved first.
Then the file can be uploaded. Otherwise it won't work

## Dotnet core CLI commands

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

## Git reset clocal repository

``` git reset
git fetch origin
git reset --hard origin/master
```
