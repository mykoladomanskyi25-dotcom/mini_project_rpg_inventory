namespace mini_project_rpg_inventory;

public class Armor : Item
{
    public int DefenseBonus { get; set; }

    public Armor(string name, double weight, Rarity rarityLevel, int defenseBonus) : base(name,
        weight, rarityLevel)
    {
        DefenseBonus = defenseBonus;
    }
    
    public override void Use(Hero hero)
    {
        int finalBonus = DefenseBonus;
        switch (RarityLevel)
        {
            case Rarity.Common:
                finalBonus = 5;
                break;
            case Rarity.Rare:
                finalBonus = 10;
                break;
            case Rarity.Epic:
                finalBonus *= 2;
                break;
            case Rarity.Legendary:
                finalBonus *= 3;
                break;
        }
        
        hero.BasicDefense += finalBonus;
    }
}