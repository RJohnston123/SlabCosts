using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace CMPS_285
{
    public class JobOptions
    {

        public static string o_patio = "Patio";
        public static string o_sidewalk = "Sidewalk";
        public static string o_driveway = "Driveway";
        public static string o_footing = "Footing";

        public List<string> JobOptionsList = new List<string>();
        
        public List<string> onGen()
        {
            JobOptionsList.Add(o_patio);
            JobOptionsList.Add(o_sidewalk);
            JobOptionsList.Add(o_driveway);
            JobOptionsList.Add(o_footing);

            return JobOptionsList;
        }

        



        //the alternative way to do this is to make every item an object that contains a string and a double that has a method GetPrice & GetName.       
        //All prices are under the assumption that the job size is 1000 at square feet.

        /* If we have time to finish the green/yellow/red price options, it would probably be easier on everything else if all
         * of the options were array doubles, with green option being option[0], yellow being option[1], and red being option[2].  This
         * allows us to always load option[color] and only change the value of int color to 0, 1 or 2.  */

        /*                                      ### Options ###                                                                      */

        //Options calculated by square foot.
        private static double o_drivewayCost = 6.00; //yellow/default option, driveway 
//used as the label for the option.
        private static double o_patioCost = 6.25; //TODO autocalculate based on total size of job. (--$.50 for every 200 squ ft smaller the job)
        private static double o_sidewalkCost = 8.25;
        private static double o_sidewalkReplace = 10.50;

        //Options calculated by linear foot.
        private static double o_curb = 24.50; //yellow option curb
        private static double o_footingCost = 9.00;
        private static double o_sawCut = 7.00;

        //Options calculated by simple units.
        private static double o_fill = 100.00;


        /*                                      ### Options getters/setters ###                                                        */
        //public static double optionName { get => optionName; set => optionName = value; } //TODO getters needed for everything.
        //TODO






        /*                                      ### Attributes(likely to move to another class) ###                                     */

        //Attributes calculated by square foot.
        private static double a_6gaugeWire = 0.50;//adds $0.50 for every square foot of driveway, patio or sidewalk.
        private static string a_6gaugeWireName = "6-gauge wire upgrade";
        private static double a_6inchesThick = 1.20; //        for every square foot of driveway, patio or sidewalk.
        
        
        //Attributes calculated by linear foot.
        private static double a_12x12 = 0.00;  //default footing size.  //for o_footing only
        private static double a_12x16 = 4.00; //upgraded footing size.  //for o_footing only

        //Attributes calculated by simple units likely don't exist.




        /*                                      ### Attributes getters/setters ###                                                       */
        //TODO getters

        
        //TODO move this to a math class later when we figure out where we need it.
        public static double CalcSquFoot(double length, double width)//for figuring price
        {
            return (length * width);
        }
        public static double CalcSquFoot(double length, double width, double hight)//for figuring concrete to order
        {
            return (length * width * hight);
        }


    }
}
