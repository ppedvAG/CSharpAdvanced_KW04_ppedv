// See https://aka.ms/new-console-template for more information
#nullable disable

ICar car = new MockCar();
ICar car1 = new Car(); // nach 5 Tagen fertig
ICarService service = new CarService();
service.Repair(car);
service.Repair(car1);   



ICarV2 carV2 = new CarV2();
service.Repair(carV2);








#region BadCode

public class BadCar //Programmierer A -> 5 Tage
{ 

    public string Brand { get; set; }

    public string Model { get; set; }   
}


public class BadCarService//Programmierer B -> 3 Tage (An Tag 5 oder 6 beginnt eigentlich seine Arbeit) 
{
    public void Repair(BadCar car) //Feste Kopplung 
    {
        //repariere Auto 
    }
}
#endregion

#region Bessere Variante 
//Contract First -> wäre eine Idee (Teamarbeit) 


#region Tag1 im Projekt -> Contract First 
public interface ICar
{
    string Brand { get; set; }

    string Model { get; set; }
}

public interface ICarV2  : ICar
{
    public string Farbe { get; set; }   
    public bool HatAnhängerKupplung { get; set; }
}

public interface ICarService
{
    public void Repair(ICar car); //Der Beginn einer Losen Kopplung 
    //public void Repair(ICarV2 car);
}
#endregion

public class Car : ICar //Programmierer A -> 5 Tage
{
    public string Brand { get; set; }
    public string Model { get; set; }
}

public class CarService : ICarService //Programmeirer B - > 3 Tage
{
    public void Repair(ICar car)
    {
        //Repariere Auto


    }

    //public void Repair(ICarV2 car)
    //{
        
    //}
}

public class MockCar : ICar
{
    public string Brand { get; set; } = "VW";
    public string Model { get; set; } = "Polo";
}


public class CarV2 : ICarV2
{
    public string Farbe { get; set; }
    public bool HatAnhängerKupplung { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
}

#endregion