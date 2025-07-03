# Aplikacja do zarządzania notatkami

## Użytkownik może
- Przeglądać wszystkie utworzone notatki
- Tworzyć nowe notatki
- Edytować istniejące notatki
- Usuwać wybrane notatki

## Działanie
Po uruchomieniu aplikacji, użytkownik widzi listę notatek, która domyślnie jest pusta. Po lewej stronie widoczny jest panel z którego dostępne są dwie opcje: Przejrzenie istniejących notatek i dodanie nowej notatki. Z poziomu widoku wszystkich notatek użytkownik może usuwać notatki, poprzez kliknięcie w czerwony przycisk z napisem "Usuń" oraz edytować notatki po kliknięciu przycisku "Edytuj". Edycja notatek przenosi użytkownika na nową podstronę, na której dostępny jest formularz edycyjny. Po zapisaniu zmian w polach dotyczacych notatki, użytkownik zostaje przeniesiony z powrotem na stronę przeglądu wszystkich notatek. Podobny formularz wyświetlany jest w przypadku wybrania opcji dodania nowej notatki przez użytkownika. Te komponenty wspierają walidację i ostrzegą użytkownika, jeśli w nowej notatce nie uzupełniono wymaganego pola.


## Detale techniczne
Wykorzystywany jest silnik bazodanowy **SQLite**, celem zapisywania danych w nieulotny sposób.
