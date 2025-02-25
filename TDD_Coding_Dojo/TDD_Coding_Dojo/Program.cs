namespace TDD_Coding_Dojo
{
     static class Program
    {
        static void Main(string[] args)
        {
            SauceShopping shop = new SauceShopping();
            int ketchup = 50;
            int mustard = 25;
            int mayonnaise = 1;

            shop.Purchase(ketchup, mustard, mayonnaise);
        }
    }
}
