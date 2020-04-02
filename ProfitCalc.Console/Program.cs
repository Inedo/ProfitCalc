using Newtonsoft.Json;
using ProfitCalc.BLL;
using SimpleInjector;

namespace ProfitCalc.Console
{
    class Program
    {

        static readonly Container container;

        static Program()
        {
            container = new Container();
            container.Register<AccountingCalculator>();
            container.Verify();
        }

        static void Main(string[] args)
        {
            decimal? revenue = null;
            decimal? expenses = null;

            if (args.Length == 2)
            {
                decimal r, e;
                revenue = decimal.TryParse(args[0], out r) ? (decimal?)r : null;
                expenses = decimal.TryParse(args[1], out e) ? (decimal?)e : null;
            }
            
            if (revenue == null || expenses == null)
            {
                revenue = PromptDecimal("Enter revenue: ");
                expenses = PromptDecimal("Enter expenses: ");
            }

            decimal profit = container.GetInstance<AccountingCalculator>().CalculateNet(revenue.Value, expenses.Value);

            System.Console.WriteLine("Profit: " + profit.ToString("C2"));
            System.Console.WriteLine("Profit JSON: " + JsonConvert.SerializeObject(profit));
        }

        static decimal PromptDecimal(string prompt)
        {
            while (true)
            {
                System.Console.Write(prompt);
                string input = System.Console.ReadLine();
                decimal d;
                if (decimal.TryParse(input, out d))
                    return d;
                else
                    System.Console.WriteLine("Please enter a valid decimal value.");
            }
        }
    }
}
