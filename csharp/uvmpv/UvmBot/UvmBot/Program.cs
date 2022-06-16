namespace UvmBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bot uvm = new();
            uvm.name = "Uvm";
            uvm.Greetings();
        }
    }
}