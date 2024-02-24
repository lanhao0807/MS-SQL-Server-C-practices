namespace app4;

class Program 
{
    static void Main()
    {
        MyStack<int> intStack = new MyStack<int>();

        intStack.Push(1);
        intStack.Push(2);
        intStack.Push(3);

        Console.WriteLine($"Stack Count: {intStack.Count()}");
        Console.WriteLine($"Popped Item: {intStack.Pop()}");
        Console.WriteLine($"Popped Item: {intStack.Pop()}");
        Console.WriteLine($"Stack Count: {intStack.Count()}");

        // =========================================================================

        MyList<int> intList = new MyList<int>();
        intList.Add(1);
        intList.Add(2);
        intList.Add(3);
        Console.WriteLine($"Contains 2: {intList.Contains(2)}");

        // =========================================================================

        IRepository<Entity> repository = new GenericRepository<Entity>();

        repository.Add(new Entity { Id = 1, /* other properties */ });
        repository.Add(new Entity { Id = 2, /* other properties */ });
        repository.Add(new Entity { Id = 3, /* other properties */ });

        Console.WriteLine("All items:");
        foreach (var item in repository.GetAll())
        {
            Console.WriteLine($"Id: {(item as Entity)?.Id}");
        }

        Console.WriteLine("Removing item with Id = 2");
        repository.Remove(repository.GetById(2));

        Console.WriteLine("All items after removal:");
        foreach (var item in repository.GetAll())
        {
            Console.WriteLine($"Id: {(item as Entity)?.Id}");
        }

        Console.WriteLine("Saving changes...");
        repository.Save();
    }    
}
