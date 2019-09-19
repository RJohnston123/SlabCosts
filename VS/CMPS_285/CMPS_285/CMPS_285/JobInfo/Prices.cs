using System;
using System.Collections.Generic;
using System.Text;

namespace CMPS_285.JobInfo
{
    class Prices
    {
        /* 
         * //can move this to InfoBridge if a shortcut is wanted to calculate everything at once.  Would need to override according to how many attributes are being used.
         * 
        public static double GetFullPrice(string optionConst, string attributeConst, double length, double width, double jobSize)
        {
            double optionPrice, attributePrice;
            optionPrice = Options.GetOptionPrice(optionConst, length, width, jobSize); //TODO remove "Options." when the method is moved here.
            attributePrice = GetAttributePrice(attributeConst, length, width);
            return (optionPrice + attributePrice);
        }*/



        //move this to infoBridge if you want.
        public static double GetAttributePrice(string attributeConst, double length, double width)
        {
            string AC = attributeConst;
            double area = length * width; //every attribute either returns length, or area.

            if (AC.Equals(Constants.a_6gWire))
            {
                return (area * Constants.cost_6gWire); //TODO this is for testing. Everything that says cost_ needs to be from the database to check if a new value exists.
            }
            if (AC.Equals(Constants.a_highwayMat)) {
                return (area * Constants.cost_highwayMat);
            }
            if (AC.Equals(Constants.a_4000_PSI))
            {
                return (area * Constants.cost_4000PSI);
            }
            if (AC.Equals(Constants.a_Fiber))
            {
                return (area * Constants.cost_fiber);
            }
            if (AC.Equals(Constants.a_exposedAggregate))
            {
                return (area * Constants.cost_exposedAggregate);
            }
            if (AC.Equals(Constants.a_narrowDrive1))
            {
                return (area * Constants.cost_narrowDrive1);
            }
            if (AC.Equals(Constants.a_narrowDrive2))
            {
                return (area * Constants.cost_narrowDrive2);
            }
            if (AC.Equals(Constants.a_narrowDrive3))
            {
                return (area * Constants.cost_narrowDrive3);
            }
            if (AC.Equals(Constants.a_fillRemoved1))
            {
                return (area * Constants.cost_fillRemoved1);
            }
            if (AC.Equals(Constants.a_fillRemoved2))
            {
                return (area * Constants.cost_fillRemoved2);
            }
            if (AC.Equals(Constants.a_Thick5Inches))
            {
                return (area * Constants.cost_thick5Inches);
            }
            if (AC.Equals(Constants.a_Thick6Inches))
            {
                return (area * Constants.cost_thick6Inches);
            }
            if (AC.Equals(Constants.a_12x8With_2numb5s)) //linear foot (length * const)
            {
                return (length * Constants.cost_12x8With_2numb5s);
            }
            if (AC.Equals(Constants.a_12x12With_4numb5s)) //linear foot
            {
                return (length * Constants.cost_12x12With_4numb5s);
            }
            if (AC.Equals(Constants.a_12x14With_4numb5s)) //linear foot
            {
                return (length * Constants.cost_12x14With_4numb5s);
            }
            if (AC.Equals(Constants.a_12x16With_4numb5s)) //linear foot
            {
                return (length * Constants.cost_12x16With_4numb5s);
            }

            return 99999.00000; //this can only be called if a new attribute is created, or an attribute changes its name.
        }





    }
}
