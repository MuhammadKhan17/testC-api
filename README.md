# testC-api
-this was a first attempt at creating a C# api using dotnet 6.0
-you can run this by using the standard .net6.0 run command
-The database contains a list of games with each game having specfic atributes 
  -the Id is a long vairiable that stores a value that represents each game
  -the board variable represents the board that the game is being played on and it takes the form of a string "F,F,F,F,F,F,F,F,F". The F on the board represents an empty    slot, this becomes T when that slot is taken. Their are a total of 9 spots on the baord that can be changed.
  -Players is a string that holds the names of the 2 players.
  -position is a an integer value that is meant to show which position the player wants to edit.
  -Player1Moves is a string that can keep track of the moves that player 1 makes (i.e. if the string is "1,10" then the player has taken slots 1 and 10). same occurs        with player2.
  -turn keeps track of which player just went.

-in order to use this api, first you must install http-repl 
-using "dotnet tool install -g Microsoft.dotnet-httprepl"
-after installing run the following command replacing yourHostNumber with the number of your host
-httprepl https://localhost:yourHostNumber/api/todoitems
-create games in the api using the post command:
  -post -h Content-Type=application/json -c "{"Players":"test3, test4","Player1Moves":"","Player2Moves":"","board":"F,F,F,F,F,F,F,F,F"}"

-put command can edit details of any individual game, but it will edit the whole game and all information must be entered.
-patch command should in theory allow for specfic values of a game to be edited, however I didn't quite get that working, if successful I whould have used that to make the turn system.
-delete allows a user to remove elements from the list of games
-get will return a list of all games in the database.

much of what was achieved was done through a webapi tutorial:
https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.httppatchattribute?view=aspnetcore-6.0

if given the oppurtnity, I will be working on this project later, adding more end points and fixing old ones.

Question: What is the appropriate OAuth 2/OIDC grant to use for a web application using a SPA (Single
Page Application) and why.
As far as I understand PKCE is the ideal type for single page applications. This allows for clients to create a seceret for each authorization request and getting an access token. This allows for added security even if the authorization code is intercepted.


  
  
