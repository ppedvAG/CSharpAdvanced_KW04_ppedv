// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


#region BadCode
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class BadReportGenerator
{
    public string ReportType { get; set; } = string.Empty;

    public void GenreateReport(Employee em)
    {
        if(ReportType == "CR")
        {
            //Report -> CrystalReports Lib
        }
        else if(ReportType == "PDF")
        {
            //Report PDF
        }
    }
}
#endregion


#region variante 1

public abstract class EmployeeGenerator
{
    public abstract void GenreateReport(Employee em);
}

public class PDFGenerator : EmployeeGenerator
{

    //Member für Optionale Einstellungen 
    //z.b CompressRate
    //Watermark 
    //Certificates

    public override void GenreateReport(Employee em)
    {
       // Eine MEthode
    }
}

public class CRGenerator : EmployeeGenerator
{

    //Member für Optionale Einstellungen 
    //Templates 
    //Alles was Crystal Reports noch anbietet, kann man hier mit verwenden
    public override void GenreateReport(Employee em)
    {
        // Eine MEthode
    }
}
#endregion