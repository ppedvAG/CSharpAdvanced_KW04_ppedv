// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

ClassWithMethode classWithMethods = new ClassWithMethode();


MessageDelegate delegateParam = new MessageDelegate(classWithMethods.FinishMessage);

classWithMethods.StartWorkflow(12, 12, delegateParam);

//Variante, wenn Action-Delage anstatt klassisches Delegate 
Action<string> actionMessageDelegate = new Action<string>(classWithMethods.FinishMessage);
classWithMethods.StartWorkflow(11, 33, actionMessageDelegate);





public delegate void MessageDelegate(string msg);

public class ClassWithMethode
{

    public void StartWorkflow(int param1, int param2, Action<string> messageDelegate)
    {
        //Call SQLServer 
        //Asynchronität 
        //Threadings

        //Hier muss uns expliziet gesagt werden, wir sind fertig
        //Hier müssen wir mithilfe eines Delegates signalisieren, dass wir mit StartWorkflow fertig sind. 
        messageDelegate("bin fertig");
    }

    public void StartWorkflow(int param1, int param2, MessageDelegate messageDelegate)
    {
        //Hier wird etwas komplexes berechnet 



        //und ganz am Ende
        messageDelegate("sind fertig");
    }

    public void FinishMessage(string msg)
    {
        Console.WriteLine(msg);
    }
}