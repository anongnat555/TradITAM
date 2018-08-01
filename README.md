# IT Asset Management System
IT Asset Management (ITAM) is a software for IT Asset Information Management in enterprise. These software will include IT Asset, Employee and Supplier information which users can retrieve, insert and update information. 

## Features
####1. Retrieval
Software can retrieve all detail of Asset, Staff and Supplier Data. 
####2. Insertion
Software can add all detail of Asset, Staff and Supplier Data.
####3. Updating
Software can update all detail of Asset, Staff and Supplier Data.

## Development Strategy
<p align="center">
  <img src="https://ekiy5aot90-flywheel.netdna-ssl.com/wp-content/uploads/2013/07/segue-blog-key-phases-software-development-projects-1.png"width="380" height="300"/>
</p>
This Project is work on Software Development Life Cycle (SDLC) which can be divide into 5 Phases. <br/>
1. Project Planning <br/>
2. Requirement Collection and Analysis <br/>
3. Design <br/>
4. Implementation <br/>
5. Testing

## Requirements
- Requirement Analysis
- Context Diagram
- Data Flow Diagram Lv.0
- Entity Relationship Diagram

Document Link: http://intern.gitlab.com/intern/TDInventory/blob/dev/Document/TradITAM_RequirementAnalysis.pdf

## MVVM Design Pattern
<p align="center">
  <img src="https://www.codeproject.com/KB/WPF/MVVMQuickTutorial/MVVM.jpg" width="380" height="300"/>
</p>
Read More: https://www.codeproject.com/Articles/81484/A-Practical-Quick-start-Tutorial-on-MVVM-in-WPF

## Development Manual
####1. Download Visual Studio (.NET Framework 4.6.1): 
Link: https://visualstudio.microsoft.com/downloads/

####2. Download Microsoft SQL Server Management Studio: 
Link: https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-2017

####3. Create Database:
1. Open Microsoft SQL Server Management Studio and create database name "TraditionAsset"
2. Execute SQL Script (TradAsset.sql) 
Link:  http://intern.gitlab.com/intern/TDInventory/blob/dev/Script/TradAsset.sql

####4. Install Package in Visual Studio
###### NuGet Package: 
1. install Entity Framework Version 6.2.0: 
`PM> Install-Package EntityFramework -Version 6.2.0`
2. install Material Design In XAML Toolkit: 
`PM> Install-Package MaterialDesignThemes`

###### Material Design:
1. Getting Started: http://materialdesigninxaml.net
2. Github & DEMO: https://github.com/MaterialDesignInXAML/MaterialDesignInXamlToolkit

## Limitation
Document Link: http://intern.gitlab.com/intern/TDInventory/blob/dev/Document/TradITAM_DevelopmentLimitation.pdf
