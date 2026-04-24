namespace mini_project_rpg_inventory;

public abstract class Item
{
    public string Name { get; set; }
    public double Weight { get; set; }
    public Rarity RarityLevel { get; set; }
    
    
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
}