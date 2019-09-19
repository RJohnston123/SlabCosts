using System;
using System.Collections.Generic;
using System.Text;

namespace CMPS_285
{
    abstract class Attributes
    {
        public abstract string Name { get; }
        public abstract double UnitPriceGreen { get; set; } //depth found in Options.  need a method to change depth if certain options are selected. (if doing calculate concrete feature)
        public abstract double UnitPriceRed { get; set; }
        public abstract double UnitPriceYellow { get; set; }



        /// <summary>
        /// Give an Option name, and returns a list of corisponding attribute strings for the given optionName.
        /// </summary>
        /// <param name="optionName"></param>
        /// <returns></returns>
        public static List<string> GetAttributes(string optionName) //List<string> x = Attributes.GetAttributes(Constants.o_driveway);
        {
            string ON = optionName;

            if (ON.Equals(Constants.o_driveway) || ON.Equals(Constants.o_drivewayReplace))
            {
                List<string> availableAttributes = new List<string>(new string[] { //creates a list to return.
                    Constants.a_narrowDrive1, Constants.a_narrowDrive2, Constants.a_narrowDrive3,
                    Constants.a_Thick5Inches, Constants.a_Thick6Inches, Constants.a_6gWire, Constants.a_highwayMat,
                    Constants.a_4000_PSI, Constants.a_Fiber, Constants.a_exposedAggregate });
                return availableAttributes;
            }
            if (ON.Equals(Constants.o_patio) || ON.Equals(Constants.o_patioReplace) || ON.Equals(Constants.o_sidewalk)
                || ON.Equals(Constants.o_sidewalkReplace) || ON.Equals(Constants.o_poolDeck) || ON.Equals(Constants.o_poolDeckReplace))
            {
                List<string> availableAttributes = new List<string>(new string[] {
                    Constants.a_Thick5Inches, Constants.a_Thick6Inches, Constants.a_6gWire, Constants.a_highwayMat,
                    Constants.a_4000_PSI, Constants.a_Fiber, Constants.a_exposedAggregate });
                return availableAttributes;
            }
            if (ON.Equals(Constants.o_fillExcavation))
            {
                List<string> availableAttributes = new List<string>(new string[] {
                    Constants.a_fillRemoved1, Constants.a_fillRemoved2 });
                return availableAttributes;
            }
            if (ON.Equals(Constants.o_footing))
            {
                List<string> availableAttributes = new List<string>(new string[] {
                    Constants.a_12x8With_2numb5s, Constants.a_12x12With_4numb5s,
                    Constants.a_12x14With_4numb5s, Constants.a_12x16With_4numb5s });
                return availableAttributes;
            }
            else
            {
                List<string> no_availableAttributes = new List<string>(new string[] { "n/a" });
                return no_availableAttributes; //this should show up when there's no option selected, or options with 0 attributes.
            }
        }

        



        /*
        a_6gWire = "6g wire";
        a_highwayMat = "Highway-Mat";
        a_4000_PSI = "4000 PSI Mix";
        a_Fiber = "w/ Fiber Mesh";
        a_exposedAggregate = "Exposed Aggregate";
        a_narrowDrive1 = "Narrow: 1'-2.5'";
        a_narrowDrive2 = "Narrow: 2.5'-4'";
        a_narrowDrive3 = "Narrow: 4'-6'";
        a_fillRemoved1 = "4\"-6\"";
        a_fillRemoved2 = "6\"-8\"";
        a_5inchThick = "5\" thick";
        a_6inchThick = "6\" thick";
        a_12x12With_2numb5s = "12x12 w/ two #5s";
        a_12x16With_4numb5s = "12x16 w/ four #5s";
        a_12x18With_4numb5s = "12x18 w/ four #5s";
        a_12x20With_4numb5s = "12x20 w/ four #5s"; //16


        o_driveway
        o_drivewayReplace
        o_patio
        o_patioReplace
        o_sidewalk
        o_sidewalkReplace
        o_poolDeck
        o_poolDeckReplace

        o_concreteBustout
        o_fillExcavation
        o_garageCap
        o_woodDeckRemove

        //linear foot options
        o_curb
        o_curbReplace
        o_footing
        o_sawcut
        */
    }
}
