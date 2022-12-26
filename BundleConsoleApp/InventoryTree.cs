namespace BundleConsoleApp
{
    public class InventoryTree
    {
        public readonly List<InventoryNode> Nodes;

        public InventoryTree()
        {
            Nodes = new List<InventoryNode>();
        }

        public void AddItem(string name, int? count, List<InventoryNode> childNodes = null)
        {
            Nodes.Add(new InventoryNode
            {
                Count = count,
                Name = name,
                ChildNodes = childNodes
            });
        }
    }
}
