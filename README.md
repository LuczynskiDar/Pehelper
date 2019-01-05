# Pehelper

Dotnet Core MVC project, excercise MVC approach with the real task.

>The purpose of creating Pehelper was to support mass item upload to the Creo
s Windchill.
Upload the .xls or .xls file. All the corporate ERP export files must be saved first.

## How Pehelper is built

PE Helper, is a web app, built using Dotnet Core 2.1 and MVC frameworks. Also I used a NPOI library on the back-end,to read posted Excel files. PE Helper, an engineering tool, extracts components’ index from an Excel file serializes, separates each of them using semicolon and finally splits into desired groups. The purpose of this project was to be used, was to reduce effort large quantity of data in the Windchill

---

### The Command snippets, which I keep for myself to remember

#### Dotnet core CLI commands

``` dotnet core
dotnet clean
dotnet restore
dotnet run
```

#### The dotnet command to choose release and runtime enviroment

``` dotnet core
dotnet publish --framework netcoreapp1.1 --runtime osx.10.11-x64
dotnet publish -c Release -r win10-x64
```

#### Dotnet core publish command

``` dotnet core
dotnet publish -c release -r win7-x64 -o bin/release/win-x64
```

#### Git reset clocal repository

``` git reset
git fetch origin
git reset --hard origin/master
```