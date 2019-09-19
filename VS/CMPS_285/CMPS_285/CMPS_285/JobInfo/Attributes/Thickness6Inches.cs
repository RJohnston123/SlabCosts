using System;
using System.Collections.Generic;
using System.Text;

namespace CMPS_285//.JobInfo.Attributes
{
    class Thickness6Inches  : Attributes
    {
        private string _name;
        private double _unitPriceGreen;
        private double _unitPriceYellow;
        private double _unitPriceRed;

        public Thickness6Inches()
        {
            _name = Constants.a_Thick6Inches;
            _unitPriceGreen = 1;
            _unitPriceYellow = 1;
            _unitPriceRed = 1;
        }

        public override string Name
        {
            get { return _name; }
            //set { _name = value; }
        }

        public override double UnitPriceGreen
        {
            get { return _unitPriceGreen; }
            set { _unitPriceGreen = value; }
        }

        public override double UnitPriceYellow
        {
            get { return _unitPriceYellow; }
            set { _unitPriceYellow = value; }
        }

        public override double UnitPriceRed
        {
            get { return _unitPriceRed; }
            set { _unitPriceRed = value; }
        }
    }
}
