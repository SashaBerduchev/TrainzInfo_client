using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainzInfo_client.HttpPost
{
    class StationsShadule
    {
        public string Station { get; set; }
        
        public string UzFilia { get; set; }
        
        public DateTime TimeOfArrive { get; set; }
        
        public DateTime TimeOfDepet { get; set; }
        
        public string TrainInfo { get; set; }
        
        public string ImgTrain { get; set; }
    }
}
