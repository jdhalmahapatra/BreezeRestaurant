using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Breeze.Web
{
    public class StaticDetails
    {
        public static string ProductAPIBase { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
