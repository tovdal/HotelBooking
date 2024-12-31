using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Utilities.Helpers
{

    public static class ListHelper
    {
        public static bool CheckIfListIsEmpty<T>(List<T> list)
        {
            if (list.Count == 0)
            {
                Console.ReadKey();
                return true;
            }
            return false;
        }
    }

}
