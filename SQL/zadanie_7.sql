-- Zapytanie wykorzystuje rekurencyjne CTE, celem wyznaczenia hierarchi pracowników. Najpierw wypisywani są prawocwnicy, których szefem jest pracownik o najniższym ID. To zapytanie nie zwraca osoby, która jest najwyżej w hierarchi, dlatego że najwyższa osoba w hierarchi nie ma menadżera, a warunek zapisany w pierszej części CTE(ManagerID=1), mówi o tym, że wypisywanie hierarchi jest kończone na pracownikach, których szefem jest pracownik o ID=1;
WITH WorkerHierarchyRecursiveCTE AS
(
    SELECT EmployeeID, FirstName, LastName, Salary, HireDate, DepartmentID, ManagerID FROM Employees WHERE ManagerID=1
    UNION ALL

    SELECT Employees.EmployeeID, Employees.FirstName, Employees.LastName, Employees.Salary, Employees.HireDate, Employees.DepartmentID, Employees.ManagerID FROM Employees INNER JOIN WorkerHierarchyRecursiveCTE WHERE Employees.ManagerID = WorkerHierarchyRecursiveCTE.EmployeeID
)
SELECT *
FROM WorkerHierarchyRecursiveCTE;
