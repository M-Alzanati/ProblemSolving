namespace BundleConsoleApp.Test
{
    public class Tests
    {
        private InventoryBundle _inventoryBundle;

        [SetUp]
        public void Init()
        {
            _inventoryBundle = new InventoryBundle();
        }

        [TestCase(50, 60, 60, 35)]
        public void When_Build_Bike_Should_With_35Tube_Return_17(int seatCount, int pedalsCount, int frameCount, int tubeCount)
        {
            // Arrange
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
                {"Seat", seatCount},
                {"Pedals", pedalsCount},
                {"Frame", frameCount},
                {"Tube", tubeCount}
            };

            // Act
            var actual = _inventoryBundle.BuildBundles(specs, bundleItems);

            // Assert
            Assert.That(actual, Is.EqualTo(17));
        }

        [TestCase(50)]
        public void When_Build_Bike_Should_With_Only50Seat_Return_50(int seatCount)
        {
            // Arrange
            var specs = new List<InventoryNode>
            {
                new ()
                {
                    Name = "Seat",
                    Count = 1
                }
            };

            var bundleItems = new Dictionary<string, int>
            {
                {"Seat", seatCount}
            };

            // Act
            var actual = _inventoryBundle.BuildBundles(specs, bundleItems);

            // Assert
            Assert.That(actual, Is.EqualTo(50));
        }

        [TestCase(50, 20, 60, 35)]
        public void When_Build_Bike_Should_With_20Tube_Return_10(int seatCount, int pedalsCount, int frameCount, int tubeCount)
        {
            // Arrange
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
                {"Seat", seatCount},
                {"Pedals", pedalsCount},
                {"Frame", frameCount},
                {"Tube", tubeCount}
            };

            // Act
            var actual = _inventoryBundle.BuildBundles(specs, bundleItems);

            // Assert
            Assert.That(actual, Is.EqualTo(10));
        }

        [TestCase(50, 20, 60, 35, 1)]
        public void When_Build_MoreComplexBike__With_Only_One_Crank_Should_Return_1(int seatCount, int pedalsCount, int frameCount, int tubeCount, int crankCount)
        {
            // Arrange
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
                            ChildNodes = new List<InventoryNode>
                            {
                                new ()
                                {
                                    Name = "Crank",
                                    Count = 1,
                                }
                            }
                        }
                    }
                }
            };

            var bundleItems = new Dictionary<string, int>
            {
                {"Seat", seatCount},
                {"Pedals", pedalsCount},
                {"Frame", frameCount},
                {"Tube", tubeCount},
                {"Crank", crankCount}
            };

            // Act
            var actual = _inventoryBundle.BuildBundles(specs, bundleItems);

            // Assert
            Assert.That(actual, Is.EqualTo(1));
        }
    }
}