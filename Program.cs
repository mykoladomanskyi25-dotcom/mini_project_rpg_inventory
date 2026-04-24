namespace mini_project_rpg_inventory;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; // щоб не виводило знаків питання
        Hero arthur = new Hero("Arthur", 100, 100, 20, 10, 50.0);
        Weapon sword = new Weapon("Excalibur", 5.0, Item.Rarity.Legendary, 50);
        Armor armor = new Armor("Dragon Scale Armor", 10.0, Item.Rarity.Epic, 30);
        Potion healthPotion = new Potion("Health Potion", 0.5, Item.Rarity.Rare, 50);
        
        arthur.Backpack.AddItem(sword);
        arthur.Backpack.AddItem(armor);
        arthur.Backpack.AddItem(healthPotion);

        while (true)
        {
            Console.WriteLine("\n=== Меню ===");
            Console.WriteLine("1. Показати інвентар героя");
            Console.WriteLine("2. Додати предмет до інвентаря");
            Console.WriteLine("3. Використати предмет за назвою");
            Console.WriteLine("4. Відсортувати інвентар за рідкістю");
            Console.WriteLine("5. Показати характеристики героя");
            Console.WriteLine("0. Вихід");
            Console.Write("> Оберіть дію: ");
            
            string choice = Console.ReadLine();
            
            switch (choice)
            {
                case "1":
                    foreach (var item in arthur.Backpack)
                    {
                        Console.WriteLine($" [{item.RarityLevel}] {item.Name} (вага: {item.Weight})");
                    }
                    break;
                case "2":
                    Console.WriteLine("\n--- Що ви хочете знайти/додати? ---");
                    Console.WriteLine("1. Сталевий Меч (Вага: 4.0, Атака: +15, Rare)");
                    Console.WriteLine("2. Шкіряна Куртка (Вага: 3.0, Захист: +5, Common)");
                    Console.WriteLine("3. Велике Зілля (Вага: 1.0, Лікування: +50, Epic)");
                    Console.Write("> Оберіть предмет: ");
    
                    string itemChoice = Console.ReadLine();
                    
                    switch (itemChoice)
                    {
                        case "1":
                            arthur.Backpack.AddItem(new Weapon("Сталевий Меч", 4.0, Item.Rarity.Rare, 15));
                            Console.WriteLine("Сталевий Меч додано до рюкзака!");
                            break;
                        case "2":
                            arthur.Backpack.AddItem(new Armor("Шкіряна Куртка", 3.0, Item.Rarity.Common, 5));
                            Console.WriteLine("Шкіряну Куртку додано до рюкзака!");
                            break;
                        case "3":
                            arthur.Backpack.AddItem(new Potion("Велике Зілля", 1.0, Item.Rarity.Epic, 50));
                            Console.WriteLine("Велике Зілля додано до рюкзака!");
                            break;
                        default:
                            Console.WriteLine("Такого предмета немає.");
                            break;
                    }
                    break;
                case "3":
                    Console.Write("Введіть назву предмета для використання: ");
                    string input = Console.ReadLine();
                    Item foundItem = arthur.Backpack.GetByName(input);

                    if (foundItem != null)
                    {
                        foundItem.Use(arthur);
                        Console.WriteLine($"Ви використали {foundItem.Name}!");
                        
                        if(foundItem is Potion)
                        {
                            arthur.Backpack.RemoveItem(foundItem);
                            Console.WriteLine($"{foundItem.Name} порожнє і видаляється з рюкзака.");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Предмет з назвою '{input}' не знайдено в інвентарі.");
                    }
                    break;
                    
                case "4":
                    arthur.Backpack.SortByRarity();
                    Console.WriteLine($"=== Відсортований інвентар героя {arthur.Name} ===");
                    foreach (var item in arthur.Backpack)
                    {
                        Console.WriteLine($"- [{item.RarityLevel}] {item.Name} (вага: {item.Weight})");
                    }
                    Console.WriteLine($"Зайнята вага: {arthur.Backpack.CurrentWeight} / {arthur.Backpack.MaxWeight}");
                    break;
                case "5":
                    Console.WriteLine($"=== Характеристики героя {arthur.Name} ===");
                    Console.WriteLine($"Здоров'я: {arthur.CurrentHealth} / {arthur.MaxHealth}");
                    Console.WriteLine($"Атака: {arthur.BasicAttack}");
                    Console.WriteLine($"Захист: {arthur.BasicDefense}");
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }
        
    }
}