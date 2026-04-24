namespace mini_project_rpg_inventory;

public abstract class Item : IComparable<Item>
{
    public string Name { get; }
    public double Weight { get; }
    public Rarity RarityLevel { get; }
    
    
    public Item(string name, double weight, Rarity rarityLevel)
    {
        Name = name;
        Weight = weight;
        RarityLevel = rarityLevel;
        
    }
    
    public enum Rarity
    {
        Common,
        Rare,
        Epic,
        Legendary
    }
    
    public abstract void Use(Hero hero);

    public int CompareTo(Item other)
    {
        if (other == null) return 1;
        
        int rarityComparison = RarityLevel.CompareTo(other.RarityLevel);
        if (rarityComparison != 0)
        {
            return rarityComparison;
        }
        
        return Name.CompareTo(other.Name); // сортування по алфавіту
    }
}