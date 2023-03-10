using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainzInfo_client.HttpPost
{
    public class NewsInfoes
    {
        public int id { get; set; }
        public string NameNews { get; set; }
        public string BaseNewsInfo { get; set; }
        public string NewsInfoAll { get; set; }
        public DateTime DateTime { get; set; }
        public string Imgsrc { get; set; }
        public byte[] NewsImage { get; set; }
        public string ImageMimeTypeOfData { get; set; }
        public string user { get; set; }
    }
}
