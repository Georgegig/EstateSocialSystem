# Estate Social System

This document describes the **final project assignment** for the **ASP.NET MVC** course at Telerik Academy.

## Project Description

The project is designed to be a form of a social network connecting users through their estates and their numerous characteristics .

The application should has:
* **public part** (accessible without authentication)
* **private part** (available for registered users)
* **administrative part** (available for administrators only)

### Public Part(guests)

The public part of the project consist of an index page (or main home page) where the guests can easily browse the top 15 estates and appliances.
There are also controls allowing the guests to browse through all estates and all appliances and reviewing them without being able to comment or rate.

### Private Part (Users only)

The private consist of controls visible only to the registered users. Different users (defined by their roles) have different control over the application models and thus they are only able to perform actions that are specific to their user role.

### Administration Part

System administrators have access to all major models. They can easily add, delete and update the information of those models. This functionality is implemented via KendoUI Grid.

## General Requirements

The Web application uses the following technologies, frameworks and development techniques:
* Use **ASP.NET MVC** and **Visual Studio 2015** with Update 1
* Has at least **15 controllers**
* Has at least **40 actions**
* Uses **Razor** template engine for generating the UI
* Has  **2 sections** and at least **10 partial views**
* Uses **MS SQL Server** as database back-end
	* Uses **Entity Framework 6** to access the database
* Uses at least **3 areas** in your project (e.g. for administration)
* Has **tables with data** with **server-side paging and sorting** for every model entity

	