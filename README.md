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
    - [0. Repository Klonen](#0-repository-klonen)
    - [1. Datenbank erstellen](#1-datenbank-erstellen)
    - [2. WebApi Starten](#2-webapi-starten)
    - [3. Website Starten](#3-website-starten)
    - [4. WPF Applikation Starten](#4-wpf-applikation-starten)
  - [Benutzermanual JetStreamServiceApp](#benutzermanual-jetstreamserviceapp)

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

### 0. Repository Klonen

Klonen Sie das Repository über den folgenden Link über Github Desktop (oder Terminal) zu sich auf Ihren lokalen Rechner.

```
https://github.com/iliakalygin/PA-M322.git
```

### 1. Datenbank erstellen

Zuerst soll man die Datenbank SkiServiceManagement auf dem ```localhost``` oder ```localhost/SQLEXPRESS``` Server erstellen, indem man die Datei ```query.sql``` in SQL Server Management Studio ausführt.

### 2. WebApi Starten

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

### 3. Website Starten

Um die website zu starten öffnen Sie die ```index.html``` Datei die sich im Website Ordner befindet.
 
Sie gelangen nun auf die Homepage von Jetstream-Service. Gehen Sie auf die Anmelde Seite um sich für einen Service anzumelden.

### 4. WPF Applikation Starten

## Benutzermanual JetStreamServiceApp
