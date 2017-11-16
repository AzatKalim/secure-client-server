using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SecureServer
{
    class Service:IContract
    {
        // Реализация контракта - IContract.
        public void Say(string input)
        {
            Console.WriteLine("Сообщение получено, Тело содержит:  {0}", input);
        }
    }
}
