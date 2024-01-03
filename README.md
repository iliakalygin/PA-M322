# Praxisarbeit Modul 322 - WPF Applikation für JetStreamService Ski Management

## Inhalt
- [Praxisarbeit Modul 322 - WPF Applikation für JetStreamService Ski Management](#praxisarbeit-modul-322---wpf-applikation-für-jetstreamservice-ski-management)
  - [Inhalt](#inhalt)
  - [Projekt-Übersicht](#projekt-übersicht)
  - [Funktionalitäten](#funktionalitäten)
  - [Technologien](#technologien)
  - [Installation und Konfiguration](#installation-und-konfiguration)
    - [Voraussetzungen](#voraussetzungen)
    - [Verwendete NuGet Pakete](#verwendete-nuget-pakete)
    - [1. Repository Klonen](#1-repository-klonen)
    - [2. Datenbank erstellen](#2-datenbank-erstellen)
    - [3. WebApi Starten](#3-webapi-starten)
    - [4. Website Starten](#4-website-starten)
    - [5. WPF Applikation Starten](#5-wpf-applikation-starten)
  - [Benutzermanual JetStreamServiceApp](#benutzermanual-jetstreamserviceapp)
    - [1. Login](#1-login)
    - [2. Daten Anzeigen und Aktualisieren](#2-daten-anzeigen-und-aktualisieren)
    - [3. Daten Bearbeiten](#3-daten-bearbeiten)
    - [4. Daten Löschen](#4-daten-löschen)

## Projekt-Übersicht

Dieses Repository beinhaltet den Quellcode für die WPF-Applikation des JetStreamService Ski Management-Systems. Die Anwendung, entwickelt im Rahmen des Moduls 322 zu Lernzwecken, ist in C# geschrieben und nutzt eine .NET Core Web API, um effizient mit einer SQL-Datenbank zu interagieren. Sie wurde speziell für die Verwaltung von Skiserviceaufträgen konzipiert und ermöglicht es Administratoren, Aufträge zu verwalten. Dies umfasst das Anzeigen, Bearbeiten und Löschen von Auftragsdaten.

## Funktionalitäten

- **Auftragsverwaltung:** Ermöglicht Administratoren das Anzeigen aller eingereichten Aufträge. Aufträge können nach verschiedenen Kriterien wie Datum, Kundenname oder Status gefiltert werden.
- **Bearbeitungsfunktion:** Bietet die Möglichkeit, bestehende Aufträge zu bearbeiten. Dies umfasst das Ändern von Kundendaten, Auftragsstatus und geplanten Servicezeiten.
- **Löschfunktion:** Ermöglicht das sichere Löschen von Aufträgen aus der Datenbank, wobei Integrität und Datenschutz gewährleistet bleiben.
- **Robuste API-Interaktion:** Die Anwendung kommuniziert mit einer .NET Core Web API, die robuste und sichere Endpunkte für das Datenmanagement bietet.
- **Benutzerfreundliche Schnittstelle:** Die WPF-basierte Benutzeroberfläche ist intuitiv und für eine einfache Navigation konzipiert, um eine effiziente Auftragsverwaltung zu gewährleisten.

## Technologien

- **C# und WPF:** Die Hauptanwendung ist in C# geschrieben und verwendet WPF für eine reichhaltige und responsive Benutzeroberfläche.
- **.NET Core Web API:** Eine leistungsfähige und skalierbare Backend-API, die für die Verarbeitung von Datenbankanfragen verantwortlich ist.
- **Entity Framework Core:** ORM-Tool, das für die Interaktion mit der SQL-Datenbank verwendet wird.
- **JWT-basierte Authentifizierung:** Sicherstellt, dass nur berechtigte Benutzer Zugang zu den Adminfunktionen der Anwendung haben.
- **SQL-Datenbank:** Speichert alle Daten in Bezug auf Aufträge, Kunden und Servicehistorie.

---

## Installation und Konfiguration

### Voraussetzungen

- Windows 10/11
- Github Desktop (oder auch im Terminal)
- Visual Studio 2022
- SQL Server Management Studio 19
- Ein Moderner Web-Browser (Chrome, Firefox, Opera, Edge, etc.)

### Verwendete NuGet Pakete

- Newtonsoft.Json v13.0.3
- Microsoft.Extensions.Configuration v7.0.0
- Microsoft.Extensions.Configuration.FileExtensions v7.0.0

### 1. Repository Klonen

Klonen Sie das Repository über den folgenden Link über Github Desktop (oder Terminal) zu sich auf Ihren lokalen Rechner.

```
https://github.com/iliakalygin/PA-M322.git
```

### 2. Datenbank erstellen

Zuerst soll man die Datenbank SkiServiceManagement auf dem ```localhost``` oder ```localhost/SQLEXPRESS``` Server erstellen, indem man die Datei ```query.sql``` in SQL Server Management Studio ausführt.

### 3. WebApi Starten

1. Navigieren Sie in den Ordner WebApi und öffnenen Sie die Solution.
2. Um die Web Api erfolgreich starten zu können, muss man zuerst sicherstellen, ob der korrekte Connectionstring in der Datei ```appsettings.json``` vorhanden ist. Falls sie localhost nutzen, muss nichts verändert werden. Hier die jweiligen Connectionstrings je nach Server:
    
   - localhost (default):
```
Server=.;Database=SkiServiceManagement;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true
```
   - localhost\SQLEXPRESS:
```
Server=.\\SQLEXPRESS;Database=SkiServiceManagement;Trusted_Connection=True; TrustServerCertificate=True;MultipleActiveResultSets=true
```
     
4. Jetzt kann die Web Api im ```http``` modus (ganz Wichtig!!) gestartet werden.

![image](https://github.com/iliakalygin/PA-M295/assets/58369822/f17bd223-e293-4a56-8560-d5fa05131a10)

### 4. Website Starten

Um die website zu starten öffnen Sie die ```index.html``` Datei die sich im Website Ordner befindet.
 
Sie gelangen nun auf die Homepage von Jetstream-Service. Gehen Sie auf die Anmelde Seite um sich für einen Service anzumelden.

### 5. WPF Applikation Starten

Um jetzt die Aufträge in der JetsteamSerice App zu verwalten, öffnen Sie einfach die Solution im Ordner ```JetsreamsericeApp```.

Um die Applikation zu starten Klicken Sie F5, Ctrl+F5, oder auf den grünen Start Button in der oberen Leiste.

## Benutzermanual JetStreamServiceApp

### 1. Login

Als erstes nach dem Starten der JetStreamSerice App, kommt man auf die Login Seite, damit nur Authorisierte Mitarbeiter Zugang zu den Daten haben, und sie demensprechen Mutieren können.

Der Default login lautet:

Username:

```
admin
```

Password:

```
admin
```

Weitere Mitarbeiter-Logins können aus der Datenbank ausgelesen werden.

### 2. Daten Anzeigen und Aktualisieren

Nach einem erfolgreichem Login, werden die Daten aus der Datenbank über die API abgerufen. Falls man neue Afträge über die Webseite JetStreamServce hinzugefügt hat und sie jetzt sehen will, klickt man einfach auf den grauen Aktulisieren Button in der Unteren Leiste. Die Daten werden anschliessen neu geladen.

### 3. Daten Bearbeiten

Um Aufträge Bearbeiten zu können, wählt man in der Liste einen Auftrag aus, und klickt auf den blauen Button Bearbeiten. Der Gesamte Auftrag wird anschlissend in einem bearbeitungs Modus angezeigt. Alle Felder ausser OrderID und CreateDate können bearbeitet werden.

### 4. Daten Löschen

Wenn man einen Auftrag aus der Datenbank löschen will, geht man vor wie beim Bearbeiten eines Auftrages, ausser man klickt auf den roten Löschen Button. Man wird anschliessend aufgefordert mit OK zu bestätigen, ob man den Auftrag wirlich löschen will.
