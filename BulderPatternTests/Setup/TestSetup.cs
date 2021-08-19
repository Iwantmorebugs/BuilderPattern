using BuilderPattern;
using BuilderPattern.Items;

namespace BulderPatternTests.Setup
{
    public class TestSetup
    {
        protected const int DefaultShippingChost = 10;
        protected const int FreeShippingChost = 0;
        protected Customer Customer1;
        protected Customer Customer2;

        protected CustomerBasketBuilder CustomerBasketBuilder;
        protected Item ItemWithPrice10;
        protected Item ItemWithPrice30;
        protected Item PremiumItemWithPrice100;

        public TestSetup()
        {
            CustomerBasketBuilder = new CustomerBasketBuilder();
            ItemWithPrice10 = new Item("Lightbulb", 10);
            ItemWithPrice30 = new Item("BasicDesk", 30);
            PremiumItemWithPrice100 = new PremiumItem("PremiumChair", 100);
            Customer1 = new Customer("Pepito", "Benito", "Santa Fe");
            Customer2 = new Customer("Sebastian", "Elnarco", "Ushuaia");
        }
    }
}