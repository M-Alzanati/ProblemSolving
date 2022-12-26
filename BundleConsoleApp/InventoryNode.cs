namespace BundleConsoleApp
{
    public class InventoryNode
    {
        public string Name { set; get; }

        public int? Count { set; get; }

        public List<InventoryNode> ChildNodes { set; get; } = new ();
    }
}
