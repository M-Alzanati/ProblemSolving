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
            var minItemCount = bundleItems.MinBy(e => e.Value).Value;

            for (var i = 0; i < minItemCount; i++)
            {
                if (BuildMyBundle(specsTree.Nodes, bundleItems) != -1)
                {
                    result++;
                }
                else
                {
                    break;
                }
            }

            return result;
        }

        public int BuildMyBundle(List<InventoryNode> bundleSpecs, Dictionary<string, int> bundleItems, int initialCount = 1)
        {
            var specsTree = new InventoryTree();

            foreach (var spec in bundleSpecs)
            {
                specsTree.AddItem(spec.Name, spec.Count, spec.ChildNodes);
            }

            var countedSpecs = 0;

            foreach (var specTreeNode in specsTree.Nodes)
            {
                if (bundleItems.ContainsKey(specTreeNode.Name) && bundleItems[specTreeNode.Name] <= 0) break;

                if (!specTreeNode.ChildNodes.Any() && bundleItems.ContainsKey(specTreeNode.Name))
                {
                    var newCount = bundleItems[specTreeNode.Name] - specTreeNode.Count * initialCount;
                    if (newCount < 0)
                    {
                        break;
                    }

                    bundleItems[specTreeNode.Name] = newCount ?? 0;
                    countedSpecs++;
                }
                else
                {
                    var tempResult = BuildMyBundle(specTreeNode.ChildNodes, bundleItems, specTreeNode.Count.Value);
                    if (tempResult != -1) countedSpecs++;
                }
            }

            return specsTree.Nodes.Count == countedSpecs ? countedSpecs : -1;
        }
    }
}
