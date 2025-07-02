-- Na początku zapytanie tworzy CTE, które zawiera ID działu i średnie wynagrodzenie w tym dziale. Następnie zapytanie SQL wypisuje wymagane dane. Inner join został wykorzystany celem znalezienia nazwy działu na podstawie jego ID. Ostatnim etapem jest odfiltrowanie, by wyświetlić tylko pracowników którzy należą do pewnego działu i ich wynagrodzenie jest większe od średniej w tym dziale.

WITH AvgDepartmentSalary AS (
    SELECT DepartmentID, AVG(Salary) as AvgSalary FROM Employees GROUP BY DepartmentID
)
SELECT EmployeeID, FirstName, LastName, DepartmentName, Salary FROM Employees, AvgDepartmentSalary INNER JOIN Departments ON Departments.DepartmentID=Employees.DepartmentID WHERE Salary > AvgDepartmentSalary.AvgSalary AND Employees.DepartmentID=AvgDepartmentSalary.DepartmentID;
