// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


IRepository<Employee> repository1 = new UnflexibelRepository<Employee>();


//
IReadCommand<Employee> readRepo = new BetterRepository<Employee>();




//Allgemein ist OK -> geht aber noch besser :-) 


public class Employee
{
    public int Id { get; set; }

    public string Name { get; set; }

}
public interface IRepository<T>
{
    T GetById(int id);
    List<T> GetAll();

    void Update (T entity);
    void Insert (T entity);
    void Delete (T entity); 
}

public class UnflexibelRepository<T> : IRepository<T>
{
    public void Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public List<T> GetAll()
    {
        throw new NotImplementedException();
    }

    public T GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Insert(T entity)
    {
        throw new NotImplementedException();
    }

    public void Update(T entity)
    {
        throw new NotImplementedException();
    }
}


//Bessere Variante -> Interfaces nach Funktionalitäten aufteilen 
public interface IInsertCommand<T>
{
    void Insert(T item);
}

public interface IUpdateCommand<T>
{
    void Update(T item);
}

public interface IDeleteCommand<T>
{
    void Delete(T item);
}

public interface IReadCommand<T>
{
    T GetById(int id);
    List<T> GetAll();
}


public class BetterRepository<T> : IReadCommand<T>, IUpdateCommand<T>, IInsertCommand<T>, IDeleteCommand<T>
{
    public void Delete(T item)
    {
        throw new NotImplementedException();
    }

    public List<T> GetAll()
    {
        throw new NotImplementedException();
    }

    public T GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Insert(T item)
    {
        throw new NotImplementedException();
    }

    public void Update(T item)
    {
        throw new NotImplementedException();
    }
}