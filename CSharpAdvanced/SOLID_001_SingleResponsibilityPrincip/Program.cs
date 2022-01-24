//// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


//Klassen werden unter dem Top 

//#nullable disable - File->Scope


//Contras:
// - Klasse EmployeeBad hat zuviele Aufgaben in verschiedenen Richtungen 


#region Anti-Beispiel

public class EmployeeBad
{
    //Datenstruktur -> Datensatz -> Poco? ViewModels? DTOS? 
    public int Id { get; set; }
    public string Name { get; set; }

    //Methode die einen Datensatz Richtung DB speichert -> Implementierung an der richtigen Stelle? 
    public void InsertEmployee(EmployeeBad employee)
    {
        // any Code
    }

    //Ausgabe -> Report 
    public void GenerateReport()
    {
        // any Code
    }
}
#endregion

#region Bessere Variante
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class EmployeeRepository
{
    public void InsertEmployee(Employee employee)
    {
        // any Code
    }
}

public class EmployeeReport
{
    public void GenerateReport()
    {
        // any Code
    }
}

#endregion





