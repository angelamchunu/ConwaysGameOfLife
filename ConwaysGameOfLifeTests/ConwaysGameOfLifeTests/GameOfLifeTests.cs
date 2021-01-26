using ConwaysGameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConwaysGameOfLifeTests
{
    
        [TestClass]
        public class GameOfLifeTest
        {
            ConwaysGameOfLifeSimulation life;

            [TestInitialize]
            public void testInit()
            {
                life = new ConwaysGameOfLifeSimulation();
            }

            [TestMethod]
            public void DoesLiveCellDieIfUnderPopulated()
            {
                var newGenGrid = life.GenerateNextGeneration(generateGrid(), 5, 5);
                Assert.AreEqual(newGenGrid[0, 0], 0);
            }

            [TestMethod]
            public void DoesLiveCellDieIfOverPopulated()
            {
                var newGenGrid = life.GenerateNextGeneration(generateGrid(), 5, 5);
                Assert.AreEqual(newGenGrid[2, 1], 0);
            }

            [TestMethod]
            public void DoesLiveCellLiveInNormalConditions()
            {
                var newGenGrid = life.GenerateNextGeneration(generateGrid(), 5, 5);
                Assert.AreEqual(newGenGrid[1, 1], 1);
            }

            [TestMethod]

            public void DoesCellGetResurrected()
            {
                var newGenGrid = life.GenerateNextGeneration(generateGrid(), 5, 5);
                Assert.AreEqual(newGenGrid[1, 2], 1);
            }


            private int[,] generateGrid()
            {
                int[,] grid = {
            {0,0,0,0,0},
            {1,1,0,0,1},
            {0,1,0,1,1},
            {1,0,1,1,1},
            {0,0,1,0,0},
            };
                return grid;
            }
        }
    }

