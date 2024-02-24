namespace app4;
public class MyList<T>
{
    private List<T> items;

    public MyList()
    {
        items = new List<T>();
    }

    public void Add(T element)
    {
        items.Add(element);
    }

    public T Remove(int index)
    {
        if (index >= 0 && index < items.Count)
        {
            T removedItem = items[index];
            items.RemoveAt(index);
            return removedItem;
        }
        else
        {
            throw new IndexOutOfRangeException("Index is out of range.");
        }
    }

    public bool Contains(T element)
    {
        return items.Contains(element);
    }

    public void Clear()
    {
        items.Clear();
    }

    public void InsertAt(T element, int index)
    {
        if (index >= 0 && index <= items.Count)
        {
            items.Insert(index, element);
        }
        else
        {
            throw new IndexOutOfRangeException("Index is out of range.");
        }
    }

    public void DeleteAt(int index)
    {
        if (index >= 0 && index < items.Count)
        {
            items.RemoveAt(index);
        }
        else
        {
            throw new IndexOutOfRangeException("Index is out of range.");
        }
    }

    public T Find(int index)
    {
        if (index >= 0 && index < items.Count)
        {
            return items[index];
        }
        else
        {
            throw new IndexOutOfRangeException("Index is out of range.");
        }
    }
}
