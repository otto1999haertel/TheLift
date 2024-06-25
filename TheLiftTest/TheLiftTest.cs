using TheLift;

namespace TheLiftTest
{
    public class Tests
    {
        TheLiftChallenge lift;
        [SetUp]
        public void Setup()
        {
            lift = new TheLiftChallenge();
        }

        [Test]
        public void TestUp()
        {
            int[][] queues =
            {
            new int[0], // G
            new int[0], // 1
            new int[]{5,5,5}, // 2
            new int[0], // 3
            new int[0], // 4
            new int[0], // 5
            new int[0], // 6
        };
            var result = lift.TheLift(queues, 5);
            Assert.AreEqual(new[] { 0, 2, 5, 0 }, result);
        }

        [Test]
        public void TestDown()
        {
            int[][] queues =
            {
            new int[0], // G
            new int[0], // 1
            new int[]{1,1}, // 2
            new int[0], // 3
            new int[0], // 4
            new int[0], // 5
            new int[0], // 6
        };
            var result = lift.TheLift(queues, 5);
            Assert.AreEqual(new[] { 0, 2, 1, 0 }, result);
        }

        [Test]
        public void TestUpAndUp()
        {
            int[][] queues =
            {
            new int[0], // G
            new int[]{3}, // 1
            new int[]{4}, // 2
            new int[0], // 3
            new int[]{5}, // 4
            new int[0], // 5
            new int[0], // 6
        };
            var result = lift.TheLift(queues, 5);
            Assert.AreEqual(new[] { 0, 1, 2, 3, 4, 5, 0 }, result);
        }

        [Test]
        public void TestDownAndDown()
        {
            int[][] queues =
            {
            new int[0], // G
            new int[]{0}, // 1
            new int[0], // 2
            new int[0], // 3
            new int[]{2}, // 4
            new int[]{3}, // 5
            new int[0], // 6
        };
            var result = lift.TheLift(queues, 5);
            Assert.AreEqual(new[] { 0, 5, 4, 3, 2, 1, 0 }, result);
        }

        [Test]
        public void TestUpAndDown()
        {
            int[][] queues =
            {
            new int[0], // G
            new int[]{0}, // 1
            new int[0], // 2
            new int[]{6,1}, // 3
            new int[]{2}, // 4
            new int[]{3,6}, // 5
            new int[0], // 6
            };
            var result = lift.TheLift(queues, 5);
            Assert.AreEqual(new[] { 0, 3, 6, 5, 4, 3, 2, 1, 0, 5, 6, 0 }, result);
        }

        [Test]
        public void NegativeNumberTest()
        {
            int[][] queues =
           {
                new int[0],
                new int []{0},
                new int []{-1},
           };
            var result = lift.TheLift(queues, 5);
            Assert.AreEqual(new[] { 0, 1, 0 }, result);
        }

        [Test]
        public void PositiveOneDirectionTest()
        {
            int[][] queues =
          {
                new int[]{1,2,3},
                new int [0],
                new int [0],
                new int [0],
          };
            var result = lift.TheLift(queues, 5);
            Assert.AreEqual(new[] { 0, 1, 2, 3, 0 }, result);
        }

        [Test]
        public void NegativeOneDirectionTest()
        {
            int[][] queues =
         {
                new int[0],
                new int []{0},
                new int [0],
                new int []{2,1},
          };
            var result = lift.TheLift(queues, 5);
            Assert.AreEqual(new[] { 0, 3, 2, 1, 0 }, result);
        }

        [Test]
        public void TestReturnToGroundFloor()
        {
            int[][] queues =
            {
        new int[0], // G
        new int[0], // 1
        new int[]{3}, // 2
        new int[]{0}, // 3
        new int[0], // 4
        new int[0], // 5
        new int[0], // 6
            };
            var result = lift.TheLift(queues, 5);
            Assert.AreEqual(new[] { 0, 2, 3, 0 }, result); // After dropping off all passengers, lift returns to ground floor
        }

        [Test]
        public void TestNoPassengersEnter()
        {
            int[][] queues =
            {
        new int[0], // G
        new int[]{-1}, // 1
        new int[]{-1}, // 2
        new int[]{-1}, // 3
        new int[]{-1}, // 4
        new int[]{-1}, // 5
        new int[]{-1}, // 6
    };
            var result = lift.TheLift(queues, 5);
            Assert.AreEqual(new[] { 0 }, result);
        }

        [Test]
        public void TestEmptyBuilding()
        {
            int[][] queues =
            {
        new int[0], // G
        new int[0], // 1
        new int[0], // 2
        new int[0], // 3
        new int[0], // 4
        new int[0], // 5
        new int[0], // 6
    };
            var result = lift.TheLift(queues, 5);
            Assert.AreEqual(new[] { 0 }, result);
        }

        [Test]
        public void TestMaxCapacity()
        {
            int[][] queues =
            {
        new int[0], // G
        new int[0], // 1
        new int[]{3, 3, 3, 3, 3, 3}, // 2
        new int[0], // 3
        new int[0], // 4
        new int[0], // 5
        new int[0], // 6
    };
            var result = lift.TheLift(queues, 5); // Capacity is 5
            Assert.AreEqual(new[] { 0, 2, 3, 2, 3, 0 }, result); // Only first 5 passengers can enter
        }

        [Test]
        //[Ignore("Failed in Endless loop")]
        public void TestNoPassengerWantsToMove()
        {
            int[][] queues =
            {
        new int[]{0}, // G
        new int[]{1}, // 1
        new int[]{2}, // 2
        new int[]{3}, // 3
        new int[]{4}, // 4
        new int[]{5}, // 5
        new int[]{6}, // 6
    };
            var result = lift.TheLift(queues, 5); // Capacity is 5
            Assert.AreEqual(new[] { 0 }, result);
        }

        [Test]
        public void TestUpAndDownMaxCpacity()
        {
            int[][] queues =
            {
                new int[]{}, // G
                new int[]{4}, // 1
                new int[]{4,4,5,6}, // 2
                new int[]{6}, // 3
                new int[]{}, // 4
                new int[]{}, // 5
                new int[]{}, // 6
            };
            var result = lift.TheLift(queues, 5); // Capacity is 5
            Assert.AreEqual(new[] { 0, 1, 2, 4, 5, 6, 3, 6, 0 }, result);
        }

        [Test]
        public void TestDownAndUpMaxCapacity()
        {
            int[][] queues =
           {
                new int[]{}, // G
                new int[]{}, // 1
                new int[]{}, // 2
                new int[]{}, // 3
                new int[]{}, // 4
                new int[]{3,4,3,2}, // 5
                new int[]{5,5}, // 6
            };
            var result = lift.TheLift(queues, 5); // Capacity is 5
            Assert.AreEqual(new[] { 0, 6, 5, 3, 4, 5, 3, 2, 0 }, result);
        }
    }
}