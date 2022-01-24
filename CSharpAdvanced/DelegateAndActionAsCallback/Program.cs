// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

ClassWithMethode classWithMethods = new ClassWithMethode();


MessageDelegate delegateParam = new MessageDelegate(classWithMethods.FinishMessage);

classWithMethods.StartWorkflow(12, 12, delegateParam);







public delegate void MessageDelegate(string msg);

public class ClassWithMethode
{
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