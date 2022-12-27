namespace BundleConsoleApp
{
    public  class InventoryBundle
    {
        public int BuildBundles(List<InventoryNode> bundleSpecs, Dictionary<string, int> bundleItems)
        {
            var result = 0;
            var specsTree = new InventoryTree();

            foreach (var spec in bundleSpecs)
            {
                specsTree.AddItem(spec.Name, spec.Count, spec.ChildNodes);
            }

            if (!specsTree.Nodes.Any()) return result;
            var minItemCount = bundleItems.MinBy(e => e.Value).Value;   // Minimum count of bundles

            for (var i = 0; i < minItemCount; i++)
            {
                if (BuildMyBundle(specsTree.Nodes, bundleItems) != -1)  // Check if we have more items to build valid specs tree
                {
                    result++;
                }
                else
                {
                    break;  // No more available items
                }
            }

            return result;
        }

        public int BuildMyBundle(List<InventoryNode> bundleSpecs, Dictionary<string, int> bundleItems, int initialCount = 1)
        {
            var specsTree = new InventoryTree();

            foreach (var spec in bundleSpecs)
            {
                specsTree.AddItem(spec.Name, spec.Count, spec.ChildNodes);  // Build specs tree
            }

            var countedSpecs = 0;   // Counted specs should match how many items we have in specs tree

            foreach (var specTreeNode in specsTree.Nodes)
            {
                if (bundleItems.ContainsKey(specTreeNode.Name) && bundleItems[specTreeNode.Name] <= 0) break;   // Means that we don't have more items for this specific specs

                if (!specTreeNode.ChildNodes.Any() && bundleItems.ContainsKey(specTreeNode.Name))
                {
                    var newCount = bundleItems[specTreeNode.Name] - specTreeNode.Count * initialCount;  // Get new count
                    if (newCount < 0)
                    {
                        break;  // We don't have more items
                    }

                    bundleItems[specTreeNode.Name] = newCount ?? 0;
                    countedSpecs++;
                }
                else
                {
                    var tempResult = BuildMyBundle(specTreeNode.ChildNodes, bundleItems, specTreeNode.Count.Value); // Recursive call if we have child nodes
                    if (tempResult != -1) countedSpecs++;
                }
            }

            return specsTree.Nodes.Count == countedSpecs ? countedSpecs : -1;   // If counted specs not equal specs tree nodes return -1
        }
    }
}
