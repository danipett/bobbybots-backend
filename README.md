# Update 2019-06-28
*Daniel Pettersson*

### Resultat och hur långt jag hunnit
#### Följande delar är gjorda och fungerande:
* Databasen skapas om det behövs och seedas med värden från JSON-filen.
* Följande Mutations finns:
 * Skapa robot
 * Ta bort en namngiven robot
 * Det går att "uppdatera" en namngiven robot så att den får favoritflagg.
* Följande Queries finns:
 * Fråga efter en namngiven robot
 * Fråga efter alla robotar
* Alla fall där "namngiven" används är oberoende av stora/små bokstäver
#### Följande delar kvarstår:
* Sortera Queries på namn eller poäng
* Se till att favoriter alltid hamnar högst upp i söklistan
* Filtrera efter kategorier
* Skapa en Mutation som gör att det går att uppdatera alla egenskaper en robot har och inte bara markera den som favorit.
* Skapa en Dockerfile
#### Det största problemet just nu:
* Uppdateringsfunktionaliteten är där jag sitter fast för tillfället och blir inte så mycket klokare av felmeddelandet som GraphiQL-skickar när jag testar och det blir fel.
* Tänkte släppa det och eventuellt göra klart alla Queries imorgon (2019-06-29) om det inte är så att det jag blivit klar med hittills ändå säger allt ni vill veta. :) I annat fall kommer jag nog att göra klart dem under helgen oavsett för jag vill veta hur det blir när det är klart!

*Vänliga hälsningar*

*Daniel*


# Bobbybots
*by Bobby Digital Studios*

Backend assignment: Create a web API server for some super duper mega special robots.

### Instructions

The app should use [.NET-Core](https://docs.microsoft.com/en-us/dotnet/core/) as a framework with [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/) as ORM and [GraphQL for .NET](https://github.com/graphql-dotnet/graphql-dotnet) as Controller.

Any SQL-based database could be used, but we suggest SQLite for portability

Fork this repository. When you're done, send us a link to your fork.

#### Functionality
* On application start, if the database is empty seed it with the JSON data from the URL provided.
* Create mutations and subsciptions for adding, removing and updating bots. Updating should include flagging bots as favourites.
* Create query/queries to do a case insensitive seach by name.
* By quering you should be able to 
  * sort the result by `name` or `score`, favourites should always be in the begining of the result.
  * filter by categories
* Create a Dockerfile to run the application
