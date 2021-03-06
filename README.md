# Modularny monolit na przykładzie Systemu Zarządzania Bezpieczeństwem

Przykład od rozpoznania problemu w organizacji do propozycji rozwiązania systemowego. 

## Spis treści:

1. [Istniejący problem w organizacji](#companyProblem)
2. [Rozwiązanie problemu](#problemsolution)
3. [Architektura rozwiązania](#architecture)
    1. [Diagramy C4](#C4Diagrams)    
         1.1 [Kontekst](#C4Context)         
         1.2 [Kontenery](#C4Containers)         
         1.3 [Komponenty - IncidentManagmentSystem.Api](#C4ComponentsApi)         
         1.4 [Komponenty - Silnik bazodanowy](#C4ComponentsDB)
    2. [Moduł](#module) 
4. [Konfiguracja Continuous Integration](#ci)
5. [Roadmap](#roadmap)
 
## 1. Istniejący problem w organizacji: <a name="companyProblem"></a>
![](../master/docs/istniejacy_problem.PNG)

Proces obsługi zgłoszeń sytuacji niepożądanych w organizacji odbywa się za pomocą wiadomości email kierowanej do działu bezpieczeństwa. Kierownik działu prowadzi rejestr zgłoszeń w arkuszu Excel oraz decyduje o ocenie zagrożenia i przeprowadzeniu postępowania przez dział. 

Po wstępnej weryfikacji zasadności, Kierownik przekazuje zgłoszenie do weryfikatorów, których zadaniem jest potwierdzenie wystąpienia incydentu oraz ustalenie jego przebiegu. Postępowanie opiera się na kontakcie z innymi pracownikami przez wiadomości email, pozyskanie od nich informacji oraz w niektórych przypadkach weryfikacji aktywności osoby podejrzanej w systemach organizacji. Zakończeniem postępowania weryfikatora jest przekazanie wyników weryfikacji i rekomendacji do Kierownika, który decyduje o ich akceptacji. Jeśli rekomendacją jest zwolnienie pracownika lub nałożenie kary finansowej, po zakończeniu postępowania Kierownik przekazuje informacje o konsekwencjach do działu kadr.   

<b>Istniejące rozwiązanie generuje następujące ryzyka dla organizacji i poprawności przebiegu procesu: </b>

a)	Konieczność doprecyzowania zgłoszeń przez kierownika lub delegowanego pracownika – ze względu na często występujący brak precyzyjnych informacji od zgłaszających. Kierownik potrzebuje wniosków z postępowania zawierających komplet informacji niezbędnych do podjęcia decyzji, pozyskiwanie dodatkowych informacji zabiera mu istotny czas pracy.  

b)	Głównym narzędziem pracy Weryfikatorów jest pozyskiwanie informacji za pomocą kont mailowych. Postępowanie w jednej sprawie może być prowadzone przez kilku pracowników, co utrudnia i wydłuża proces gromadzenia materiału dowodowego oraz przedstawienia kompletnych wniosków dla kierownika. Brak wspólnego dostępu do zgromadzonych materiałów dowodowych. 

c)	Istotnym dowodem w postępowaniach jest weryfikacja działania pracowników w systemach. Obecnie, brak jest spójnej procedury weryfikacji aktywności użytkowników – każdy system weryfikowany jest ręcznie, w odmienny sposób. Powoduje to wydłużenie weryfikacji oraz ryzyko pominięcia materiału dowodowego. 

d)	Brak centralnego rejestru prowadzonych postępowań. Arkusz excel jest tylko w posiadaniu kierownika – występuje ryzyko utraty bazy danych spraw lub jej niekompletności w wyniku pomyłki lub awarii sprzętu. Brak rejestru konsekwencji oraz możliwości szybkiej weryfikacji analogicznych incydentów przez Weryfikatorów. 

e)	Brak systemu umożliwiającego wprowadzenie w organizacji automatycznych reguł kontrolnych lub prowadzenia wyrywkowej weryfikacji aktywności użytkowników. Każde postępowanie wynika ze zgłoszenia, nie jest inicjowane przez zespół bezpieczeństwa ze względu na samodzielnie pozyskane informacje i prowadzone kontrole. 

## 2. Rozwiązanie problemu: <a name="problemsolution"></a>

Wdrożenie systemu będącego centralnym rejestrem spraw zgłaszanych i prowadzonych przez dział bezpieczeństwa oraz umożliwiającego szybki podgląd logów aktywności użytkowników we wszystkich systemach w organizacji. 

a)	<b>Zgłoszenie Incydentu</b> – rejestracja niepożądanego incydentu, komunikacja z działem bezpieczeństwa w celu doprecyzowania informacji.

b)	<b>Wstępna weryfikacja wniosku</b> – wprowadzenie roli Młodszego weryfikatora odpowiedzialnego za weryfikację kompletności wniosków, uzyskanie wstępnych informacji o incydencie i przekazanie ich do właściwego postępowania prowadzonego przez Weryfikatorów. 

c)	<b>Weryfikacja incydentu</b> – prowadzenie postępowania oraz dokumentacja materiału dowodowego przez Weryfikatorów. 

d)	<b>Obsługa wyników weryfikacji</b> – akceptacja wyników przez Kierownika oraz zautomatyzowane przekazanie informacji do działu Kadr. 

e)	<b>Analiza logów aktywności użytkownika</b> – zautomatyzowana weryfikacja aktywności użytkowników w systemach organizacji. 

Schematy działania poszczególnych modułów zostały zaprezentowane poniżej w kolejności prezentacji w dokumentacji.

![](../master/docs/zgloszenie_incydentu.PNG)

![](../master/docs/wstepna_weryfikacja.PNG)

![](../master/docs/weryfikacja_incydentu.PNG) 

![](../master/docs/obsluga_weryfikacji.PNG) 

![](../master/docs/analiza_logow.PNG)  


## 3.Architektura rozwiązania: <a name="architecture"></a>

W procesie rozpoznawania problemu zdefiniowano granice, które zostaną odzwierciedlone jako niezależne moduły. Jako, że ilość użytkowników ogranicza się do pracowników firmy, a przewidywana ilość zgłoszeń incydentów od kilku do kilkunastu dziennie, zdecydowano się na wybór architektury Modularny Monolit. 

### 1.Diagramy C4  <a name="C4Diagrams"></a>

#### 1.1 Kontekst <a name="C4Context"></a>

![](../master/docs/C4Diagrams/Context.bmp)  

#### 1.2 Kontenery <a name="C4Containers"></a>

![](../master/docs/C4Diagrams/Container-IMS.bmp)  

#### 1.3 Komponenty - IncidentManagmentSystem.Api <a name="C4ComponentsApi"></a>

![](../master/docs/C4Diagrams/Component-IMS-Api.bmp)  

#### 1.4 Komponenty - Silnik bazodanowy <a name="C4ComponentsDB"></a>

![](../master/docs/C4Diagrams/Component-DB.bmp)  

### 2. Moduł <a name="module"></a>

![](../master/docs/modul_code.png) 
![](../master/docs/Module_circles.png)  

1. Zestaw kontrolerów do wykonywania przypadków użycia (Controllers) oraz do pobierania danych (ODataControllers)
2. Konfiguracja modułu tj. komunikacja z bazą danych, migracje, konfiguracja DI (Infrastructure), Read Modele do kontrolerów OData (ReadModels).
3. Implementacja przypadków użycia (UseCase), obsługa zdarzeń domenowych (Domain Event Handlers) oraz obsługa zdarzeń integracyjnych (Integration Event Handlers).
4. Reguły domenowe (Domain Rules), reprezentacje biznesowe (Aggregates, Entities), zdarzenia domenowe (Domain Events), definicja Repozytoriów (Repositories) oraz typy proste opakowane w klasy (Value Objects)


### 4. Konfiguracja Continuous Integration  <a name="ci"></a>
Do ciągłej integracji używane są narzędzia:

- GitHub - repozytorium kodu
- Azure DevOps - konfiguracja kroków CI oraz ich wykonanie
- Docker Hub - repozytorium obrazów

Po każdym pushu na branchu master odpalany jest proces CI. 

#### 4.1 Opis procesu
![](../master/docs/CI-IMS.png)  

1. Pobranie najnowszej wersji kodu z brancha
2. Budowanie obrazu dockerowego (kroki w Dockerfile)
  - budowanie solucji  
  - wykonanie testów jednostkowych oraz integracyjnych
    
3. Publikowanie obrazu w Docker Hub

Po każdym wykonaniu pipeline jest możliwość sprawdzenia rezultatu testów. Jeżeli pojawią się błędy w testach, to obraz nie zostanie opublikowany w Docker Hub.

![](../master/docs/test-results.PNG)  

Kroki w Azure DevOps

![](../master/docs/job-steps.PNG)  

### 5. Roadmap <a name="roadmap"></a>

#### ETAP 1:


Funkcjonalności:

| Nazwa | Status |
|---|---|
| Event storrming z ekspertem domenowym | Zakończony |
| Propozycja rozwiązania problemu (podział na Bounded Context) | Zakończony |
| Koncept architektury | Zakończony |
| Funkcjonalność tworzenia wniosku, początek modułu (IncidentReport) | Zakończony |
| Odebranie utworzonego wniosku i przekazanie do wstępnej weryfikacji, początek modułu (InitialIncidentVerification) | W trakcie |
| Przekazanie wniosku do kierownika | |
| Przypisanie wnisoku do weryfikatorów | |
| Przesłanie wniosku do weryfikacji, początek modułu (IncidentVerification) | | 
| Ustalenie wyników weryfikacji| | 
| Przekazanie wyników weryfikacji do kierownika, początek modułu (VerificationResult) | | 
| Akceptacja wyników weryfikacji | | 
| Odrzucenie wyników weryfikacji | | 

Zadania techniczne:
| Nazwa | Status |
|---|---|
| Continuous integration - wersja podstawowa | Zakończony |
| Continuous delivery - wersja podstawowa | |
| Utrzymywanie schematu bazodanowego za pomocą migracji | |
| Przetłumaczenie Readme na język angielski  | |


#### ETAP 2:
TO DO
