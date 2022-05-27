using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forshc
{
    
    class VModel
    {
        public List<Chest> chest;

        public VModel()
        {
            chest = load();
        }
        public List<Chest> load()
        {
            List<Chest> ch = BaseConnect.BaseModel.Chest.ToList();

            return ch;
        }
    }
}
