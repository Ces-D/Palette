using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models.ControllerModels
{
    public class BuildColorFromStringControllerModel
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

        ///<summary>
        /// The id of of the color whose values are being generated.
        /// This should only be populated if we are not generating a random color and should be provided so that
        /// the color item can be identified client side.
        ///</summary>
        public string ColorID { get; set; }
    }
}
