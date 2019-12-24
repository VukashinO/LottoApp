# LottoApp

lottoAppSedc

## About the project

This is Lotto - application and user can log in and register, can create tickets for specific round, wich is determined by the Admin,

one ticket has seven different numbers, the winning combination gives the admin when the round is created. 

Prize is calculated if user have minimum 4 correct guesses.

## Idea

LottoApp idea come from one of the workshops in SEDC-Academy. 

The goal was to create a database with users and user tickets

and join them with foreign keys.

After that i come with idea to connect the Backend with Front end framework and i made it with Aurelia.

## Features

The main goal is to render the data with table and for that i made general component that i will reuse across the pages,

admin can check the winning tickets, the prize for the ticket, the prize and the loss for that round in total.

The Round is generated with 7 random number from 1 to 37. User can enter application, after successfully register meaning user

need's to be 18 years old, enter email and password wich is hashed and also he needs to enter 1 special character 1 big letter

and min 8 characters.User starts with 1000 euros and min prize for ticket cost 50 euros. If he win prize the prize, user gets his

money updated. The Admin closes the round and open another round, so the user can only play for 1 round.

## Set Up

The project can be downloaded with gitclone the URL and the last version on the project is on the branch presentation

for the Front-End part u will need to write in the command prompt au run --watch and for the Back-End u need to build the project

the first page leads you to Swagger.

## Built with

This project is made with ASP.NET WEB APi 2, Aurelia, Microsoft SQL Server

for the back end i used MVC-pattern or Onion architecture, for the front end MVV 

GitHub
