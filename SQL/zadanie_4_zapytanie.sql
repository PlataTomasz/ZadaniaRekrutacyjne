--To zapytanie wypisze wszystkie dane dotyczące projektu, wraz z liczbą pracowników, którzy są do niego przypisani. Liczba pracowników przypisana do danego projektu znajduje się w kolumnie z aliasem EmployeeCountInProject. Klauzula LEFT JOIN, sprawia, że nawet jeśli jakiś projekt nie ma przypisanych do siebie pracowników, to i tak zostanie wypisany, a wartość w kolumnie EmployeeCountInProject dla tego projektu będzie równa 0.

-- W danych o projektach można zobaczyć, że niektóre projekty są już zakończone(endDate nie ma wartości NULL) i być może powinny nie być uzwględniane, jednak założyłem, że powinny zostać uwzględnienione, gdyż pomimo zakończenia projektu pracownicy mogą prowadzić jego konserwację(maintenence).

SELECT *, COUNT(EmployeeProjects.EmployeeID) as EmployeeCountInProject FROM Projects LEFT JOIN EmployeeProjects ON EmployeeProjects.ProjectID=Projects.ProjectID GROUP BY EmployeeProjects.ProjectID ORDER BY ProjectID;
