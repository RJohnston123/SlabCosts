using System;
using System.Collections.Generic;
using System.Text;

namespace CMPS_285
{
    class PatioReplace : Options
    {
        private readonly string _name;
        private double _length;
        private double _width; //TODO make public getter and setter.
        private double _depth;

        private double _unitPriceSmall;
        private double _unitPriceMedium;
        private double _unitPriceLarge;
        private double _jobSizeSmall;
        private double _jobSizeMedium;
        private double _jobSizeLarge;

        private readonly bool _isSquareFoot;

        public PatioReplace(/*TODO double databasePrices*/) //Driveway varName = new Driveway();
        {
            _name = Constants.o_patioReplace; //TODO, get name from the constants class.
            _length = 0; //stays the same for all types
            _width = 0; //stays the same for all types
            _depth = 0;
            //TODO get database info for unitPrice and jobSize_range
            _unitPriceSmall = 1; //small job price
            _unitPriceMedium = 11; //TODO get database info
            _unitPriceLarge = 1; //large job price
            _jobSizeSmall = 200; //minium job size with maximum unit price
            _jobSizeMedium = 700; //TODO get database info
            _jobSizeLarge = 2200; //maximum job size where price no longer decreases as size increases

            _isSquareFoot = true;
        }

        public override string Name //these variable names connect to the abstract/super class and must be named the same.
        {
            get { return _name; }
            //never give ability to change Option name
        }
        public override double Width
        {
            get { return _width; }
            set { _width = value; } //setter only for square foot options
        }
        public override double Length
        {
            get { return _length; }
            set { _length = value; }
        }
        public override double Depth
        {
            get { return _depth; }
            set { _depth = value; }
        }
        public override double UnitPriceSmall
        {
            get { return _unitPriceSmall; }
            set { _unitPriceSmall = value; }
        }
        public override double UnitPriceMedium
        {
            get { return _unitPriceMedium; }
            set { _unitPriceMedium = value; }
        }
        public override double UnitPriceLarge
        {
            get { return _unitPriceLarge; }
            set { _unitPriceLarge = value; }
        }
        public override double JobSizeSmall
        {
            get { return _jobSizeSmall; }
            set { _jobSizeSmall = value; }
        }
        public override double JobSizeMedium
        {
            get { return _jobSizeMedium; }
            set { _jobSizeMedium = value; }
        }
        public override double JobSizeLarge
        {
            get { return _jobSizeLarge; }
            set { _jobSizeLarge = value; }
        }
        public override bool IsSquareFoot
        {
            get { return _isSquareFoot; }
            //never give ability to change Option type
        }

    }
}
