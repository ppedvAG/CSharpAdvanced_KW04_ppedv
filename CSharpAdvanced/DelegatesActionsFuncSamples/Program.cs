// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

ClassWithMethoden classWithMethoden = new ClassWithMethoden();

#region Delegate Beispiele
//klassischer Methodenaufruf 

classWithMethoden.AddNumber(12);

//Methodenaufruf via Delegate
ChangeNumber changeNumberDelegate = new ChangeNumber(classWithMethoden.AddNumber);
int result = changeNumberDelegate(12);
ChangeNumber changeSubNumberDelegate = new ChangeNumber(classWithMethoden.SubNumber);
int resultB = changeNumberDelegate += classWithMethoden.SubNumber;

int result2 = changeNumberDelegate(12);

Console.WriteLine(result2);

AlertDelegate alertDelegate = new AlertDelegate(classWithMethoden.WriteLogToDb);
alertDelegate += classWithMethoden.WriteLogToLogFile;
alertDelegate("Bug in Programm.cs");
#endregion


#region Action  
Action meinActionDelegate = new Action(classWithMethoden.MethodeA);

//Action Delegate speichert den Funktionszeiger von classWithMethoden.WriteLogToDb
Action<string> logAction = new Action<string>(classWithMethoden.WriteLogToDb);
Action<string, string> otherAction = new Action<string, string>(classWithMethoden.MethodeB);
otherAction("Halli", "Hallo");
//Aufruf wie bei Delegates
logAction("Schreibe einen Eintrag in den Log");


#endregion


#region Func
Func<int, float, float> func = new Func<int, float, float>(classWithMethoden.AddFloatNumber);
float floatResult = func(10, 1.44f);
#endregion



//Delegates sind Datentypen 

// Delegates in Verbindung mit Methoden verwendet, die die selbe Signatur vorweisen, wie bei Delegates
delegate int ChangeNumber(int number);

delegate void AlertDelegate(string msg);

//Beispiel Methoden mit folgenden Aufbau sind valide -> int Methodennamen(int Parameter) 

public class ClassWithMethoden
{
    public int AddNumber(int number) //Jede Methode hat einen 'Funktionszeiger' und gibt die Startadresse für die jeweilige Methode an
    {
        return number + 2;
    }

    public int SubNumber(int number)
    {
        return number - 2;
    }


    public float AddFloatNumber(int number, float number2) //Jede Methode hat einen 'Funktionszeiger' und gibt die Startadresse für die jeweilige Methode an
    {
        return number + 2;
    }

    public float SubFloatNumber(int number, float number2)
    {
        return number - 2;
    }


    public void WriteLogToDb(string msg)
    {

    }

    public void WriteLogToLogFile(string msg)
    {

    }


    public void MethodeA()
    {

    }

    public void MethodeB(string firstname, string lastname)
    {

    }
}