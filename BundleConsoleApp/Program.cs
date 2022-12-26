using BundleConsoleApp;

var specs = new List<InventoryNode>
{
    new ()
    {
        Name = "Seat",
        Count = 1,
    },
    new ()
    {
        Name = "Pedals",
        Count = 2,
    },
    new ()
    {
        Name = "Wheels",
        Count = 2,
        ChildNodes = new List<InventoryNode>
        {
            new ()
            {
                Name = "Frame",
                Count = 1,
            },
            new ()
            {
                Name = "Tube",
                Count = 1,
            }
        }
    }
};

var bundleItems = new Dictionary<string, int>
{
    {"Seat", 50},
    {"Pedals", 60},
    {"Frame", 60},
    {"Tube", 35}
};

var buildBundle = new InventoryBundle().BuildBundles(specs, bundleItems);
Console.WriteLine(buildBundle);
Console.ReadKey();