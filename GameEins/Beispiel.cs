

namespace GameEins
{
    class Beispiel
    {
        public Beispiel()
        {

        }

        public void Testen()
        {
            var test = Task.Run(BspTest);
            var testZwei = Task.Run(TestZwei);
            test.Start();
            testZwei.Start();
        }
        void BspTest()
        {
            Thread.Sleep(500);
            Console.WriteLine("TEST TEST TEST");
        }
        void TestZwei()
        {
            Console.WriteLine("Test");
        }

    }
}