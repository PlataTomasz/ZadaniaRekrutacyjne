-- Podstawowe zapytanie zwraca imiona i nazwiska wszystkich pracowników. Następnie z wykorzystaniem podzapytania ci pracownicy są filtrowani i zostają tylko ci, których wynagrodzenie przekracza średnie wynagrodzenie wszystkich pracowników.
SELECT FirstName, LastName FROM Employees WHERE Salary > (
    SELECT AVG(Salary) FROM Employees
);
