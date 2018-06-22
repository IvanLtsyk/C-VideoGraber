using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParserCore.BL.coursehunters
{
    class CourseHunterParseEventArg: EventArgs
    {
        public CourseHunterParseEventArg( object arg)
        {
            mainArgs = arg;
        }

        public object mainArgs { get; private set; }
    }
}
