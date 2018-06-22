using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserCore.BL
{
    public interface IParsData
    {
        string ImageUrl { get; set; }
        string WideoUrl { get; set; }
    }
    public class ParsData: IParsData
    {
        public string ImageUrl { get; set; }
        public string WideoUrl { get; set; }
    }
}
