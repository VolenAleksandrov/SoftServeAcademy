using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManager.Data
{
    public class Data
    {
        private static HRManagerContext context;
        public static HRManagerContext Context => context ?? (context = new HRManagerContext());
    }
}