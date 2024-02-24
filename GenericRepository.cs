namespace app4;
public class GenericRepository<T> : IRepository<T> where T : class
{
    private List<T> items;

    public GenericRepository()
    {
        items = new List<T>();
    }

    public void Add(T item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        items.Add(item);
    }

    public void Remove(T item)
    {
        if (item == null)
            throw new ArgumentNullException(nameof(item));

        items.Remove(item);
    }

    public void Save()
    {
        Console.WriteLine("Changes saved.");
    }

    public IEnumerable<T> GetAll()
    {
        return items.ToList();
    }

    public T GetById(int id)
    {
        return items.FirstOrDefault(item => (item as Entity)?.Id == id);
    }
}
