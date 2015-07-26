using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarketChain.Data;

namespace SuperMarketChain.Client
{
    class ConsoleClient
    {
        static void Main()
        {
            var context = new SupermarketChainContext();

            var productCount = context.Products.Count();
            Console.WriteLine(productCount);
        }
    }
}
