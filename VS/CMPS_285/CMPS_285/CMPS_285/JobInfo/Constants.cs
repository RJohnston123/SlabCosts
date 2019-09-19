using System;
using System.Collections.Generic;
using System.Text;

namespace CMPS_285
{
    public class Constants //try to use this class to name every string that the user can see in the application.
    {
		//Error Messages
		public static string err_NumOutOfRange = "Please enter a value between -20 and 10,000.";
		public static string err_NoNum         = "Please enter a number.";


		//Options
		//square foot options
		public const string o_driveway = "Driveway";
        public const string o_drivewayReplace = "Driveway Replacement";
        public const string o_patio = "Patio";
        public const string o_patioReplace = "Patio Replacement";
        public const string o_sidewalk = "Sidewalk";
        public const string o_sidewalkReplace = "Sidewalk Replace";
        public const string o_poolDeck = "Pool Deck";
        public const string o_poolDeckReplace = "Pool Deck Replace";

        public const string o_concreteBustout = "Concrete Breakout";
        public const string o_fillExcavation = "Remove Fill"; //base option for 4"-6" and paid attribute for 6"-8"
        public const string o_garageCap = "Garage Cap"; //this is raising people's garage floor for people with old houses that had a stepdown to their garage and now it floods water. 
        public const string o_woodDeckRemove = "Wooden Deck Removal";

        //linear foot options
        public const string o_curb = "Curb";
        public const string o_curbReplace = "Curb Replacement";
/*new*/ public const string o_brickLedge = "Brick Ledge"; //TODO o_brickLedge, o_addFill, o_thickenedEdge are regestering as square foot options.
/*new*/ public const string o_addFill = "Add Fill (Yards)";
        public const string o_footing = "Footing"; //base option for 12"*12" with 4 different paid attributes to select from
/*new*/ public const string o_thickenedEdge = "Thick Edge to Capture Fill";
        public const string o_sawcut = "Sawcut";
        //end of Options

        public static readonly List<string> optionList = new List<string>(new string[] { /*Square foot options --> */ o_driveway, o_patio, o_sidewalk, o_poolDeck, o_drivewayReplace, o_patioReplace,
            o_sidewalkReplace, o_poolDeckReplace, o_concreteBustout, o_addFill, o_fillExcavation, o_garageCap, o_woodDeckRemove,
            /*Linear foot options --> */ o_curb, o_curbReplace, o_footing, o_thickenedEdge, o_sawcut, o_brickLedge});

		//Client Statuses
		public static readonly List<string> statusList = new List<string>(new string[] {"PENDING", "PAID", "FINISHED" });

		//Client Status Colors
		public const string statusPENDING  = "#c4a400";
		public const string statusPAID     = "#00c90d";
		public const string statusFINISHED = "Red";

		//Attributes
		public const string a_6gWire = "6g wire";
        public const string a_highwayMat = "Highway-Mat";
        public const string a_4000_PSI = "4000 PSI Mix";
        public const string a_Fiber = "w/ Fiber Mesh";
        public const string a_exposedAggregate = "Exposed Aggregate";
        public const string a_narrowDrive1 = "Narrow: 1'-2.5'";
        public const string a_narrowDrive2 = "Narrow: 2.5'-4'";
        public const string a_narrowDrive3 = "Narrow: 4'-6'";
        public const string a_fillRemoved1 = "4\"-6\" Removed";
        public const string a_fillRemoved2 = "6\"-8\" Removed";
        public const string a_Thick5Inches = "5\" thick";
        public const string a_Thick6Inches = "6\" thick";
        public const string a_12x8With_2numb5s = "12x12 w/ two #5s"; //ask if confused.  shown mesurments should show 4 inches more than calculated mesurments.
        public const string a_12x12With_4numb5s = "12x16 w/ four #5s";
        public const string a_12x14With_4numb5s = "12x18 w/ four #5s";
        public const string a_12x16With_4numb5s = "12x20 w/ four #5s";
        public const string a_thinSidewalk = "Sidewalk extra < 3.5 width.";  //Sam added

        public static readonly List<string> attributeList = new List<string>(new string[] { a_6gWire, a_highwayMat, a_4000_PSI, a_Fiber, a_exposedAggregate,
            a_fillRemoved1, a_fillRemoved2, a_narrowDrive1, a_narrowDrive2, a_narrowDrive3, a_Thick5Inches, a_Thick6Inches,
            a_12x8With_2numb5s, a_12x12With_4numb5s, a_12x14With_4numb5s, a_12x16With_4numb5s });
        //end of Attributes


        //Option Prices
        public const double M_DrivewayGreen = -0.0010682; //default slope
        public const double B_DrivewayGreen = 7.457;  //default Y intercept
        public const double Min_DrivewayGreen = 5.00; //default minimum price
        public const double M_DrivewayYellow = -0.00097727;
        public const double B_DrivewayYellow = 6.9977;
        public const double Min_DrivewayYellow = 4.75;
        public const double M_DrivewayRed = -0.0009772727;
        public const double B_DrivewayRed = 6.4977;
        public const double Min_DrivewayRed = 4.25;

        public const double M_DriveReplaceGreen = -0.001022727;
        public const double B_DriveReplaceGreen = 8.1023;
        public const double Min_DriveReplaceGreen = 5.75;
        public const double M_DriveReplaceYellow = -0.00095454545;
        public const double B_DriveReplaceYellow = 7.9454;
        public const double Min_DriveReplaceYellow = 5.75;
        public const double M_DriveReplaceRed = -0.000863636;
        public const double B_DriveReplaceRed = 7.4864;
        public const double Min_DriveReplaceRed = 5.50;

        public const double M_PatioGreen = -0.001;
        public const double B_PatioGreen = 7.75;
        public const double Min_PatioGreen = 6.25;
        public const double M_PatioYellow = -0.000821428;
        public const double B_PatioYellow = 7.2321;
        public const double Min_PatioYellow = 6.00;
        public const double M_PatioRed = -0.00085714;
        public const double B_PatioRed = 6.7857;
        public const double Min_PatioRed = 5.50;

        public const double M_PatioReplaceGreen = -0.0025;
        public const double B_PatioReplaceGreen = 10.75;
        public const double Min_PatioReplaceGreen = 9.00;
        public const double M_PatioReplaceYellow = -0.0025;
        public const double B_PatioReplaceYellow = 10.25;
        public const double Min_PatioReplaceYellow = 8.50;
        public const double M_PatioReplaceRed = -0.001333333;
        public const double B_PatioReplaceRed = 9.4333;
        public const double Min_PatioReplaceRed = 8.50;
        
        public const double M_PooldeckGreen = -0.000958333;
        public const double B_PooldeckGreen = 8.2458;
        public const double Min_PooldeckGreen = 7.00;
        public const double M_PooldeckYellow = -0.00095833;
        public const double B_PooldeckYellow = 7.7458;
        public const double Min_PooldeckYellow = 6.50;
        public const double M_PooldeckRed = -0.00095833;
        public const double B_PooldeckRed = 7.2458;
        public const double Min_PooldeckRed = 6.00;
        
        public const double M_PooldeckReplaceGreen = -0.0025;
        public const double B_PooldeckReplaceGreen = 11.25;
        public const double Min_PooldeckReplaceGreen = 9.50;
        public const double M_PooldeckReplaceYellow = -0.0025;
        public const double B_PooldeckReplaceYellow = 10.75;
        public const double Min_PooldeckReplaceYellow = 9.00;
        public const double M_PooldeckReplaceRed = -0.0025;
        public const double B_PooldeckReplaceRed = 10.25;
        public const double Min_PooldeckReplaceRed = 8.50;
        // ^ double checked everything with excel sheet 572 times.
        // prices uneffected by jobSize below
        public const double cost_sidewalkGreen = 8.75;  //assumed greater than 3.5 feet wide.  Attribute will increase this if less than 3.5'.
        public const double cost_sidewalkYellow = 8.25;
        public const double cost_sidewalkRed = 7.75;
        public const double cost_sidewalkReplaceGreen = 11.00;
        public const double cost_sidewalkReplaceYellow = 10.50;
        public const double cost_sidewalkReplaceRed = 10.00;

        public const double cost_garageCapGreen = 7.00;
        public const double cost_garageCapYellow = 6.50;
        public const double cost_garageCapRed = 6.00;

        public const double cost_curb = 20.00;
        public const double cost_curbReplace = 24.00;

        public const double cost_addFill = 50.00; //TODO add to Prices class
        public const double cost_footing = 9.00; //base 12x8 with two #3 rods
        public const double cost_concreteBreakout = 3.00;
        public const double cost_sawcut = 7.00;
        public const double cost_removeFill = 0.40; //4"-6" base removal
        public const double cost_WoodDeckRemoval = 2.75;
        public const double cost_brickLedge = 7.00; //TODO add as constructor/class, OptionString and OptionStringList
        public const double cost_thickenedEdge = 5.00; //TODO add as constructor
        // end of Option Prices


        // Attribute Prices
        public const double cost_6gWire = 0.50; //default price charges for each attribute
        public const double cost_highwayMat = 0.90;
        public const double cost_4000PSI = 0.20;
        public const double cost_fiber = 0.50;
        public const double cost_exposedAggregate = 2.50;
        public const double cost_narrowDrive1 = 3.75;
        public const double cost_narrowDrive2 = 1.50;
        public const double cost_narrowDrive3 = 0.75;
        public const double cost_fillRemoved1 = 0.40; //4"-6"
        public const double cost_fillRemoved2 = 0.75; //6"-8"
        public const double cost_thick5Inches = 0.60;
        public const double cost_thick6Inches = 1.20;
        public const double cost_12x8With_2numb5s = 1.00;
        public const double cost_12x12With_4numb5s = 4.00;
        public const double cost_12x14With_4numb5s = 5.00;
        public const double cost_12x16With_4numb5s = 6.00;
        public const double cost_thinSidewalk = 0.50;  //Sam added
        // end of Attribute Prices




    }
}
