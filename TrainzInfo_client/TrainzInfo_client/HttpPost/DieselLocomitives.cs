using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainzInfo_client.HttpPost
{
    class DieselLocomitives
    {
        public int id { get; set; }
        
        public string Name { get; set; }
        public int MaxSpeed { get; set; }
        public int SectionCount { get; set; }
        public int DiseslPower { get; set; }
        
        public string Imgsrc { get; set; }
    }
}
