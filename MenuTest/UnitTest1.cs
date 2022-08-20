using ConsoleApp2.Hauptmenu;

namespace MenuTest
{
    [TestClass]
    public class GameMenuTest
    {
        [TestMethod]
        public void GameMenuKeySelectIndex()
        {
            //Arrange
            string[] str = { "Eins", "Zwei", "Drei" };
            Menu menu = new Menu("Titel",  str);

            //Act
            int selectedIndex = menu.Run();
            Console.ReadKey(true);
            //ConsoleKey.UpArrow;

            //Assert
            Assert.AreEqual(menu._selectedIndex, 1);
        }
    }
}