namespace mini_project_rpg_inventory;

public class Inventory<T> : IEnumerable<T> where T : Item
{
    private List<T> items = new List<T>();
    public double MaxWeight { get; private set; }
    public double CurrentWeight { get; private set; }

    public Inventory(double maxWeight)
    {
        MaxWeight = maxWeight;
        CurrentWeight = 0;
    }

    public void SortByRarity()
    {
        items.Sort();
    }
    
    public void AddItem(T item)
    {
        if (CurrentWeight + item.Weight <= MaxWeight)
        {
            items.Add(item);
            CurrentWeight += item.Weight;
        }
        else
        {
            Console.WriteLine("Cannot add item. Inventory weight limit exceeded.");
        }
    }

    public void RemoveItem(T item)
    {
        if (items.Remove(item))
        {
            CurrentWeight -= item.Weight;
        }
        else
        {
            Console.WriteLine("Cannot remove item. Inventory weight limit exceeded.");
        }
    }
    public T GetByName(string name)
    {
        foreach (var item in items)
        {
            if (item.Name.Equals(name.Trim()))
            {
                return item;
            }
        }
        return null;
    }
    public IEnumerator<T> GetEnumerator()
    {
        return items.GetEnumerator();
    }


    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}