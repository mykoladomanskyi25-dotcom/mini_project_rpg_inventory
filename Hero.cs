namespace mini_project_rpg_inventory;

public class Hero
{
    public string Name { get; set; }
    public int CurrentHealth { get; set; }
    public int MaxHealth { get; set; }
    public int BasicAttack { get; set; }
    public int BasicDefense { get; set; }
    public Inventory<Item> Backpack { get; set; }
    
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