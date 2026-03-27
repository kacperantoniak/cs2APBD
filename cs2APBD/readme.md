System wypożyczalni sprzętu dla uczelni


Opis


Pozwala na rejestrację sprzętu (laptopy, projektory, kamery), zarządzanie użytkownikami (studenci, pracownicy), wypożyczenia,
zwroty z naliczaniem kar oraz generowanie raportów.

Decyzje projektowe


Podzieliłem kod na trzy warstwy:

Domain – modele domenowe, tylko dane, bez logiki biznesowej
Repos – repozytoria odpowiedzialne za przechowywanie danych
Service – logika biznesowa i orkiestracja operacji

Utworzyłem generyczną klasę bazową:

Zamiast pisać te same metody Add, GetById, GetAll w każdym repozytorium, zrobiłem generyczną klasę bazową.

Status wyporzyczenia jako enum:

Wymusza poprawne wartości oraz eliminuje literówki.


Uruchamianie

cmd:
dotnet build
dotnet run