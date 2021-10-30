1. Prerequisites:
- Angular CLI v12.x.x
- Node v 14.x.x

Backend:
 *Run the BoardGamesRentalService solution and load all dependencies for the ISS to run to access the API.
 *In the startup.cs in services.AddDbContext change the connection string for your prefered database location.
 *In Package Manager Console add initial migration and run update-database for the database to be created. 

FrontEnd: 
 *Run npm install in the GamesRental.View\BoardGamesRental folder to load all the necessary packages.

------------------------------------------------------------------------------------------------------------------------------
Dodałbym testy jednostkowe,globalną obsługę wyjątków oraz wyodrębniłbym connection string do osobnego serwisu.
 
Na pewno zmieniłbym ładowanie tabeli na asynchroniczne oraz wypełnianie danych dla tabeli po stronie serwera (podczas modułów LBD związanych z angularem używałem tabel z Angular Materials. Paczkę Datatables którą wykorzystałem w projekcie użyłem po raz pierwszy przez co miałem trochę kłopotów z jej zaimplementowaniem i konfiguracją). 

Poprawiłbym też stronę wizualną projektu. Aktualnie wszędzie wyświetlają się tabele. Na przykład zamiast tabeli z wszystkimi grami wyświetlałbym, dla gier, po kilka elementów z paginacją w formie np. mat-card z możliwością przejścia do bardziej szczegółowego opisu. Zadbałbym również o responsywność całej aplikacji na ten moment aplikacja wyświetla się właściwie tylko na desktopie.
Dodałbym walidację formularzy po stronie klienta.

