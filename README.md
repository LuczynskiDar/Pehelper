# Pehelper

Dotnet Core MVC project, excercise MVC approach with the real task.

>The purpose of creating Pehelper was to support mass item upload to the Creo
s Windchill, to save engineering time. The app supports .xls or .xls file. 

## How Pehelper is built

PE Helper, is a web app, built using Dotnet Core 2.1 and MVC frameworks. Also I used a [NPOI](https://github.com/dotnetcore/NPOI) library on the back-end, to read posted Excel files. PE Helper, an engineering tool, extracts components’ index from an Excel file, serializes, separates each of them using semicolon and finally splits into desired groups and displayed as rows.

- Startup screen

![Startup screen](https://github.com/LuczynskiDar/Pehelper/blob/nocookie/Img/pehelper_clean.PNG) 

- Choose and upload a file

![upload a file](https://github.com/LuczynskiDar/Pehelper/blob/nocookie/Img/pehelper_uploaded.PNG)

- Choose the column by the column index and show the results by pushing run button

![run colun index](https://github.com/LuczynskiDar/Pehelper/blob/nocookie/Img/pehelper_number.PNG)

- Choose the column by the column name and show the results by pushing run button

![run column name](https://github.com/LuczynskiDar/Pehelper/blob/nocookie/Img/pehelper_run_column.PNG)

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