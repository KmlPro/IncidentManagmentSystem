# Modularny monolit na przykładzie Systemu Zarządzania Bezpieczeństwem

Przykład od rozpoznania problemu w organizacji do propozycji rozwiązania systemowego. 
 
## Istniejący problem w organizacji:
![](../master/docs/istniejacy_problem.PNG)

Obecnie wszystkie zgłoszenia sytuacji nie pożądanych w organizacji zgłaszane są za pomocą wiadomości email. Wszystkie takie zgłoszenia są później wysyłane do kierownika działu bezpieczeństwa, który zapisuje zgłoszenia we własnym arkuszu Excel. Po zapisaniu zgłoszenia decyduje o tym, czy jest to potencjalne zagrożenie, którym zespół bezpieczeństwa ma się zająć czy nie. 
Po przekazaniu wniosku do zespołu bezpieczeństwa, weryfikatorzy starają się ustalić, czy incydent miał miejsce. W tym celu kontaktują się za pomocą maili z osobami, które mogłyby potwierdzić zajście takiego incydentu. Czasami muszą sprawdzić aktywność osoby podejrzanej w systemach organizacji. 
Po zakończeniu prac nad wnioskiem weryfikatorzy przekazują swoje wnioski i rekomendacje do kierownika (zwane wynikami weryfikacji). Kierownik decyduje, czy je akceptuje, czy się z nimi nie zgadza. 
Po zakończeniu prac nad wnioskiem, jeżeli rekomendacją jest zwolnienie pracownika lub nałożenie kary finansowej, Kierownik przekazuje taki fakt do działu kadr.

<b>Rozwiązanie jednak nie jest idealne, ponieważ: </b>

a)	duża część zgłoszeń jest mało precyzyjna lub informacje przekazane przez osobę zgłaszającą są bardzo zdawkowe, przez co kierownik musi albo delegować osobę do tego, żeby uzyskała od zgłaszającego doprecyzowanie danego zgłoszenia lub sam musi je doprecyzować. Kierownika docelowo interesują tylko wnioski, które zawierają komplet informacji do podjęcia decyzji.

b)	Weryfikatorzy bardzo często pozyskują informację za pomocą swoich kont mailowych. Czasem kilka osób prowadzi różne konwersację mające znaleźć dowody w sprawie. Ciężko jednak później zbiera się cały materiał dowodowy z różnych skrzynek mailowych.

c)	Czasem na podstawie działania użytkownika w danym systemie, można stwierdzić co w nim wykonywał i połączyć to działanie z potencjalnym naruszeniem. Obecnie jednak każdy z systemów trzeba weryfikować ręcznie, i w każdym systemie robi się to w inny sposób

d)	Brak centralnego miejsca, w którym można by rejestrować wszystkie wnioski, aby kierownicy i weryfikatorzy mieli jedno wspólne miejsce do pracy. Dodatkowo, arkusz excel może w każdym momencie zostać skasowany przez pomyłkę.  

e)	Brak centralnego miejsca, w którym wyrywkowo można by weryfikować aktywności użytkownika w celu wychwytywania potencjalnie niepożądanych sytuacji w firmie 

## Rozwiązanie problemu: 

Do rozwiązania problemów organizacji będzie potrzebny system, który będzie pojedynczym miejscem składowania i obsługi wniosków o weryfikację incydentów. Dodatkowo, dodamy funkcjonalności związane z możliwością podglądu logów aktywności w systemach organizacji w jednym miejscu. 
Aby rozwiązać problem weryfikacji nie kompletnych wniosków przez Kierownika, dodamy nową rolę w organizacji Młodszy weryfikator, która będzie odpowiedzialna za weryfikowanie kompletności wniosków i uzyskiwanie ewentualnych dodatkowych informacji o incydencie. 
Spróbujemy także zautomatyzować proces komunikacji z działem kadr (tak, aby po ustaleniu wyników weryfikacji i akceptacji ich przez kierownika przesyłać stosowne powiadomienie do działu kadr).
System zostanie podzielony na kilka modułów:

- <b>Zgłoszenie incydentu</b> – zgłaszanie wniosków do działu bezpieczeństwa, komunikacja z działem bezpieczeństwa w celu doprecyzowania wniosku

![](../master/docs/zgloszenie_incydentu.PNG)

- <b>Wstępna weryfikacja wniosku</b> – wstępna analiza wniosku przez Młodszego Weryfikatora oraz przekazanie wniosku do Weryfikatorów

![](../master/docs/weryfikacja incydentu.PNG)

- <b>Weryfikacja incydentu</b> – obsługa wniosku przez Weryfikatorów

![](../master/docs/weryfikacja incydentu.PNG) 

- <b>Obsługa wyników weryfikacji</b> – akceptacja wyników przez Kierownika oraz przekazanie informacji do działu Kadr

![](../master/docs/obsluga_weryfikacji.PNG) 

- <b>Analiza logów aktywności użytkownika</b> – weryfikacja aktywności użytkownika w systemach organizacji

![](../master/docs/analiza_logow.PNG)  
