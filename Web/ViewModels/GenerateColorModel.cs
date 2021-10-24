using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class GenerateColorModel
    {
        /// <summary>
        /// string value for any of the three color types
        /// </summary>
        public string ColorValue { get; set; }
        /// <summary>
        /// One of the three supported colorTypes
        /// <![CDATA["rgb","hex","hsv"]]>
        /// </summary>
        public string ColorType { get; set; }
    }
}
