using System;
using System.Collections.Generic;
using System.Text;

namespace CMPS_285
{
    abstract class Options
    {
        public abstract string Name { get; } //common datafields here.
        public abstract double Length { get; set; }
        public abstract double Width { get; set; }
        public abstract double Depth { get; set; }

        public abstract double UnitPriceSmall { get; set; }
        public abstract double UnitPriceMedium { get; set; }
        public abstract double UnitPriceLarge { get; set; }

        public abstract double JobSizeSmall { get; set; }
        public abstract double JobSizeMedium { get; set; }
        public abstract double JobSizeLarge { get; set; }

        public abstract bool IsSquareFoot { get; }
    }
}