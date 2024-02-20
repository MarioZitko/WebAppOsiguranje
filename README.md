# ASP.NET MVC .NET 4.7.2 Web Aplikacija za Upravljanje Partnerima Osiguravajućeg Društva

Ova aplikacija omogućuje korisniku upravljanje partnerima osiguravajućeg društva. Aplikacija je razvijena koristeći ASP.NET MVC .NET 4.7.2 (Full-Framework) u C#/HTML/JS/T-SQL programskim jezicima.

## Funkcionalnosti

Aplikacija prikazuje tri stranice:

1. Lista svih partnera
2. Forma za unos novog partnera
3. Forma za unos broja police partnera sa iznosom police

### Lista svih partnera

Ova stranica prikazuje sve podatke o partneru po stupcima, sortirana je po datumu zapisa od najnovijeg prema najstarijem partneru. Za FirstName i LastName prikazuje jedan stupac FullName koji spaja prethodna dva podatka. Klikom na redak se podiže modalni prozor koji prikazuje sve detalje odabranog partnera.

### Forma za unos novog partnera

Ova stranica prikazuje formu sa svim podacima partnera. Validira sve podatke na pokušaj spremanja, sprečava neispravan unos. Omogućava siguran unos novog partnera klikom na gumb na dnu forme. Nakon uspješnog spremanja preusmjerava korisnika na listu u kojoj se na vrhu vidi novouneseni partner.

## Instalacija

1. Klonirajte repozitorij
2. Otvorite projekt u Visual Studio
3. Podesite string za spajanje na bazu u `Web.config`
4. Pokrenite aplikaciju

## Korištenje

Nakon pokretanja aplikacije, možete pregledavati listu partnera, dodavati nove partnere i unositi broj police partnera sa iznosom police.

## Licenca

Ovaj projekt je licenciran pod MIT licencom.
