namespace mini_project_rpg_inventory;

public class Hero
{
    public string Name { get; }
    public int CurrentHealth { get; set; }
    public int MaxHealth { get; }
    public int BasicAttack { get; set; }
    public int BasicDefense { get; set; }
    public Inventory<Item> Backpack { get; }
    
    public Hero(string name, int currentHealth, int maxhealth, int basicAttack, int basicDefense, double maxWeight)
    {
        Name = name;
        CurrentHealth = currentHealth;
        MaxHealth = maxhealth;
        BasicAttack = basicAttack;
        BasicDefense = basicDefense;
        Backpack = new Inventory<Item>(maxWeight);
    }
}