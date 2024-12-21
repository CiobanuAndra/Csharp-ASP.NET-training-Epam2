namespace Reflection.Tests
{
    public class ForTestingClass
    {
        public const int StaticIntField = 10;

        private int intField;

        public ForTestingClass()
        {
            this.intField = -1;
        }

        public ForTestingClass(int intValue)
        {
            this.intField = intValue;
        }

        public int IntValue
        {
            get
            {
                return this.intField;
            }

            set
            {
                this.intField = value < 0 ? 0 : value;
            }
        }
    }
}
