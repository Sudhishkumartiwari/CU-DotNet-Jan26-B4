
namespace CargoManifest
{

    class Item
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public string Category { get; set; }

        public Item(string name, double weight, string category)
        {
            Name = name;
            Weight = weight;
            Category = category;
        }

        public override string ToString()
            => $"{Name} {Weight} {Category}";
    }

    class Container
    {
        public string ContainerID { get; set; }
        public List<Item> Items = new List<Item>();

        public Container(string id, List<Item> items)
        {
            ContainerID = id;
            Items = items;
        }
    }

    class CargoManage
    {
        List<List<Container>> cargo  = new List<List<Container>>();

        public CargoManage(List<List<Container>> cargo)
        {
            this.cargo = cargo;
        }

        public List<string> FindHeavyContainer(double weight)
            => cargo.SelectMany(a => a).Where(x => x.Items.Sum(a => a.Weight) > weight)
            .Select(s => s.ContainerID)
            .ToList();

        public Dictionary<string, int> GetItemsByCategory()
            => cargo.SelectMany(a => a).SelectMany(x => x.Items)
                .GroupBy(a => a.Category)
                .ToDictionary(x => x.Key, x => x.Count());

        public List<Item> FlattenAndSortShipment()
            => cargo.SelectMany(x => x).
                SelectMany(a => a.Items)
                .Distinct()
                .OrderBy(x => x.Category)
                .ThenByDescending(x => x.Weight)
                .ToList();

    }
    internal class Program
    {
        static void Main(string[] args)
        {

            var cargoBay = new List<List<Container>>
            {
                // ROW 0: High-Value Tech Row
                new List<Container>
                {
                    new Container("C001", new List<Item>
                    {
                        new Item("Laptop", 2.5, "Tech"),
                        new Item("Monitor", 5.0, "Tech"),
                        new Item("Smartphone", 0.5, "Tech")
                    }),
                    new Container("C104", new List<Item>
                    {
                        new Item("Server Rack", 45.0, "Tech"), // Heavy Item
                        new Item("Cables", 1.2, "Tech")
                    })
                },

                // ROW 1: Mixed Consumer Goods
                new List<Container>
                {
                    new Container("C002", new List<Item>
                    {
                        new Item("Apple", 0.2, "Food"),
                        new Item("Banana", 0.2, "Food"),
                        new Item("Milk", 1.0, "Food")
                    }),
                    new Container("C003", new List<Item>
                    {
                        new Item("Table", 15.0, "Furniture"),
                        new Item("Chair", 7.5, "Furniture")
                    })
                },

                // ROW 2: Fragile & Perishables (Includes an Empty Container)
                new List<Container>
                {
                    new Container("C205", new List<Item>
                    {
                        new Item("Vase", 3.0, "Decor"),
                        new Item("Mirror", 12.0, "Decor")
                    }),
                    new Container("C206", new List<Item>()) // EDGE CASE: Container with no items
                },

                // ROW 3: EDGE CASE - Empty Row
                new List<Container>() // A row that exists but has no containers
            };


            CargoManage cargoManage = new CargoManage(cargoBay);

            Console.WriteLine("Containers that are heavier than threshold :-");
            Console.WriteLine(string.Join("\n", cargoManage.FindHeavyContainer(10)));
            Console.WriteLine();

            Console.WriteLine("Categorizing items by category :-");
            var itemsByCategory = cargoManage
                .GetItemsByCategory()
                .Select(a=> new string($"{a.Key} category has a count of {a.Value}"));
            Console.WriteLine(string.Join('\n',itemsByCategory));
            Console.WriteLine();

            Console.WriteLine("All items in sorted manner :-");
            Console.WriteLine(string.Join('\n',cargoManage.FlattenAndSortShipment()));
            Console.WriteLine();   
        }
    }
}