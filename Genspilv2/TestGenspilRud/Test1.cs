using Genspilv2.Rud;

namespace TestGenspilRud
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var game = new Game(State.Ny, 19.19);
            var game2 = new Game(State.God, 19.19);
            var game3 = new Game(State.Brugt, 19.19);
            var game4 = new Game(State.MegetBrugt, 19.19);
            Assert.IsTrue(game.GetPrice() == 19.19 * 0.9);
            Assert.IsTrue(game2.GetPrice() == 19.19 * 0.8);
            Assert.IsTrue(game3.GetPrice() == 19.19 * 0.6);
            Assert.IsTrue(game4.GetPrice() == 19.19 * 0.4);
        }
    }
}
