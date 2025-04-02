using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspilv2
{
    internal class Reservation
    {
        
            public string CustomerName { get; }
            public string CustomerEmail { get; }
            public string GameTitle { get; }

            public Reservation(string customerName, string customerEmail, string gameTitle)
            {
                CustomerName = customerName;
                CustomerEmail = customerEmail;
                GameTitle = gameTitle;
            }
        }

        class Request
        {
            public string CustomerName { get; }
            public string CustomerEmail { get; }
            public string GameTitle { get; }

            public Request(string customerName, string customerEmail, string gameTitle)
            {
                CustomerName = customerName;
                CustomerEmail = customerEmail;
                GameTitle = gameTitle;
            }
        }
}
