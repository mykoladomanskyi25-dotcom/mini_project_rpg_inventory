namespace mini_project_rpg_inventory;

public class Weapon : Item
{
    public int AttackBonus { get; }
    public Weapon(string name, double weight, Rarity rarityLevel, int attackBonus) : base(name, weight, rarityLevel)
    {
        AttackBonus = attackBonus;
    }
    public override void Use(Hero hero)
    {
        int finalBonus = AttackBonus;
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
        
        hero.BasicAttack += finalBonus;
    }
}