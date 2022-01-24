// See https://aka.ms/new-console-template for more information
using EventAndEventHandlerSample;

Console.WriteLine("Hello, World!");

MyApp2 app2 = new MyApp2();
app2.InitEvents();
app2.Start();



public class MyApp
{
    private ProcessBusinessLogicComponent _processBusinessLogic;


    public MyApp()
    {
        _processBusinessLogic.ChangedPercentValue += _processBusinessLogic_ChangedPercentValue;
        _processBusinessLogic.ResultCompleted += _processBusinessLogic_ResultCompleted;
    }


   

    private void _processBusinessLogic_ResultCompleted(string msg)
    {
        throw new NotImplementedException();
    }

    private void _processBusinessLogic_ChangedPercentValue(int n)
    {
        Console.WriteLine(n);
    }
}

public class MyApp2
{
    private ProcessBusinessLogic2Component processBusinessLogic2;

    public MyApp2()
    {
        processBusinessLogic2 = new ProcessBusinessLogic2Component();
    }

    public void InitEvents()
    {
        //Beispiel ohne Parameter nach aussen ->EventArgs.Empty
        processBusinessLogic2.ProcessCompleted += ProcessBusinessLogic2_ProcessCompleted;
        processBusinessLogic2.PercentChanged += ProcessBusinessLogic2_PercentChanged;


        //Parameter werden via EvetnsArgs verwendet 
        processBusinessLogic2.ProcessCompletedWithArgument += ProcessBusinessLogic2_ProcessCompletedWithArgument;
    }

    private void ProcessBusinessLogic2_ProcessCompletedWithArgument(object? sender, EventArgs e)
    {
        MyEventArg myEventArg = (MyEventArg)e;

        Console.WriteLine("Fertig um " + myEventArg.Uhrzeit.ToString());
    }

    private void ProcessBusinessLogic2_PercentChanged(object? sender, EventArgs e)
    {
        
    }

    private void ProcessBusinessLogic2_ProcessCompleted(object? sender, EventArgs e)
    {
        Console.WriteLine("fertig");
    }

    public void Start()
    {
        processBusinessLogic2.StartProcess();
        processBusinessLogic2.StartProcess2();
    }
}