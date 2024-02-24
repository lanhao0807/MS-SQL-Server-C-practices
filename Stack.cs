namespace app4;
public class MyStack<T>
{
    private List<T> items;

    public MyStack()
    {
        items = new List<T>();
    }

    public int Count()
    {
        return items.Count;
    }

    public T Pop()
    {
        if (items.Count > 0)
        {
            T poppedItem = items[items.Count - 1];
            items.RemoveAt(items.Count - 1);
            return poppedItem;
        }
        else
        {
            throw new InvalidOperationException("The stack is empty. Cannot pop.");
        }
    }

    public void Push(T item)
    {
        items.Add(item);
    }
}
