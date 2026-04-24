namespace mini_project_rpg_inventory;

public class Potion : Item
{
    public int HealAmount { get; }
    public Potion(string name, double weight, Rarity rarityLevel, int healAmount) : base(name, weight, rarityLevel)
    {
        HealAmount = healAmount;
    }

    public override void Use(Hero hero)
    {
        int finalHeal = HealAmount;
        switch (RarityLevel)
        {
            case Rarity.Common:
                finalHeal = 20;
                break;
            case Rarity.Rare:
                finalHeal = 50;
                break;
            case Rarity.Epic:
                finalHeal *= 2;
                break;
            case Rarity.Legendary:
                finalHeal = hero.MaxHealth;
                break;
        }
        
        hero.CurrentHealth += finalHeal;
        if (hero.CurrentHealth > hero.MaxHealth)
        {
            hero.CurrentHealth = hero.MaxHealth;
        }
    }
}