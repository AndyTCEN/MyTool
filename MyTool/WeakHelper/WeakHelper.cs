using System;
using System.Collections.Generic;
using System.Text;

namespace WeakHelper
{
    public class WeakHelper
    {
        public static string Path_Traversal(string errstr)
        {
            return errstr.Replace("/", "").Replace(@"\", "").Replace("..", "").Replace("'", "");
        }
    }
}
