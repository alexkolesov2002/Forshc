using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forshc
{
    public static class Myperem
    {
        public static List<Chest> ListBigChest = BaseConnect.BaseModel.Chest.ToList();
        public static List<Chest> ListLittleChest = new List<Chest>();
    }
}
