using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CMPS_285
{
    public class InfoBridge
    {

        private static SQLiteConnection database;
        public DatabasePrices Prices { get; set; }
         

        public InfoBridge(int pricesId) {
            CreateDatabase(pricesId);
        }

        // takes in the user's Option and returns the corresponding constructor.
        public static object OptionStringToObject(string input)
        {
            if (input.Equals(Constants.o_driveway)) { Driveway x = new Driveway(); return x; }
            if (input.Equals(Constants.o_drivewayReplace)) { DrivewayReplace x = new DrivewayReplace(); return x; }
            if (input.Equals(Constants.o_patio)) { Patio x = new Patio(); return x; }
            if (input.Equals(Constants.o_patioReplace)) { PatioReplace x = new PatioReplace(); return x; }
            if (input.Equals(Constants.o_sidewalk)) { Sidewalk x = new Sidewalk(); return x; }
            if (input.Equals(Constants.o_sidewalkReplace)) { SidewalkReplace x = new SidewalkReplace(); return x; }
            if (input.Equals(Constants.o_poolDeck)) { PoolDeck x = new PoolDeck(); return x; }
            if (input.Equals(Constants.o_poolDeckReplace)) { PoolDeckReplace x = new PoolDeckReplace(); return x; }
            if (input.Equals(Constants.o_concreteBustout)) { ConcreteBustout x = new ConcreteBustout(); return x; }
            if (input.Equals(Constants.o_fillExcavation)) { FillExcavation x = new FillExcavation(); return x; }
            if (input.Equals(Constants.o_garageCap)) { GarageCap x = new GarageCap(); return x; }
            if (input.Equals(Constants.o_woodDeckRemove)) { WoodDeckRemove x = new WoodDeckRemove(); return x; }
            if (input.Equals(Constants.o_curb)) { Curb x = new Curb(); return x; }
            if (input.Equals(Constants.o_curbReplace)) { CurbReplace x = new CurbReplace(); return x; }
            if (input.Equals(Constants.o_footing)) { Footing x = new Footing(); return x; }
            if (input.Equals(Constants.o_sawcut)) { Sawcut x = new Sawcut(); return x; }

            //TODO make error report if no option found
            return null;
        }
        // takes in the user's Attribute and returns the corresponding constructor.
        public static object AttributeStringToObject(string input)
        {
            if (input.Equals(Constants.a_12x12With_4numb5s)) { Footing12x12 x = new Footing12x12(); return x; }
            if (input.Equals(Constants.a_Fiber)) { Fiber x = new Fiber(); return x; }
            if (input.Equals(Constants.a_12x14With_4numb5s)) { Footing12x14 x = new Footing12x14(); return x; }
            if (input.Equals(Constants.a_12x16With_4numb5s)) { Footing12x16 x = new Footing12x16(); return x; }
            if (input.Equals(Constants.a_12x8With_2numb5s)) { Footing12x8 x = new Footing12x8(); return x; }
            if (input.Equals(Constants.a_highwayMat)) { HighwayMat x = new HighwayMat(); return x; }
            if (input.Equals(Constants.a_4000_PSI)) { Mix4000PSI x = new Mix4000PSI(); return x; }
            if (input.Equals(Constants.a_narrowDrive1)) { NarrowDrive1 x = new NarrowDrive1(); return x; }
            if (input.Equals(Constants.a_narrowDrive2)) { NarrowDrive2 x = new NarrowDrive2(); return x; }
            if (input.Equals(Constants.a_narrowDrive3)) { NarrowDrive3 x = new NarrowDrive3(); return x; }
            if (input.Equals(Constants.a_fillRemoved1)) { RemoveFill1 x = new RemoveFill1(); return x; }
            if (input.Equals(Constants.a_fillRemoved2)) { RemoveFill2 x = new RemoveFill2(); return x; }
            if (input.Equals(Constants.a_6gWire)) { SixGaugeWire x = new SixGaugeWire(); return x; }
            if (input.Equals(Constants.a_Thick5Inches)) { Thickness5Inches x = new Thickness5Inches(); return x; }
            if (input.Equals(Constants.a_Thick6Inches)) { Thickness6Inches x = new Thickness6Inches(); return x; }
            if (input.Equals(Constants.a_exposedAggregate)) { ExposedAggregate x = new ExposedAggregate(); return x; }

            //TODO make error report if no option found 
            return null;
        }


        //TODO GetAttributePrice is found in the Prices class and should be moved here to replace this method that only takes one value.
        // No need to keep this unless you want to get the price from the object instead of the string name or use for testing.
        public static double GetAttributePrice(object theClass, double unitQuantity)
        {
            if (theClass is Driveway driveway)//1
            { double jobTotal; jobTotal = driveway.UnitPriceMedium * unitQuantity; return jobTotal; }
            if (theClass is Sidewalk sidewalk)//2
            { double jobTotal; jobTotal = sidewalk.UnitPriceMedium * unitQuantity; return jobTotal; }
            if (theClass is Curb curb)//3
            { double jobTotal; jobTotal = curb.UnitPriceMedium * unitQuantity; return jobTotal; }
            if (theClass is CurbReplace curbReplace)//4
            { double jobTotal; jobTotal = curbReplace.UnitPriceMedium * unitQuantity; return jobTotal; }

            if (theClass is Patio patio)//5
            { double jobTotal; jobTotal = patio.UnitPriceMedium * unitQuantity; return jobTotal; }
            if (theClass is PatioReplace patioReplacement)//6
            { double jobTotal; jobTotal = patioReplacement.UnitPriceMedium * unitQuantity; return jobTotal; }
            if (theClass is Sawcut sawcut)//7
            { double jobTotal; jobTotal = sawcut.UnitPriceMedium * unitQuantity; return jobTotal; }
            if (theClass is FillExcavation fillExcavation)//8
            { double jobTotal; jobTotal = fillExcavation.UnitPriceMedium * unitQuantity; return jobTotal; }
            if (theClass is SidewalkReplace sidewalkReplace)//9
            { double jobTotal; jobTotal = sidewalkReplace.UnitPriceMedium * unitQuantity; return jobTotal; }
            if (theClass is GarageCap garageCap)//10
            { double jobTotal; jobTotal = garageCap.UnitPriceMedium * unitQuantity; return jobTotal; }
            if (theClass is WoodDeckRemove woodDeckRemove)//11
            { double jobTotal; jobTotal = woodDeckRemove.UnitPriceMedium * unitQuantity; return jobTotal; }
            if (theClass is Footing footing)//12
            { double jobTotal; jobTotal = footing.UnitPriceMedium * unitQuantity; return jobTotal; }
            if (theClass is DrivewayReplace drivewayReplace)//13
            { double jobTotal; jobTotal = drivewayReplace.UnitPriceMedium * unitQuantity; return jobTotal; }
            if (theClass is ConcreteBustout concreteBustout)//14
            { double jobTotal; jobTotal = concreteBustout.UnitPriceMedium * unitQuantity; return jobTotal; }
            if (theClass is PoolDeck poolDeck)//15
            { double jobTotal; jobTotal = poolDeck.UnitPriceMedium * unitQuantity; return jobTotal; }
            if (theClass is PoolDeckReplace poolDeckReplace)//16
            { double jobTotal; jobTotal = poolDeckReplace.UnitPriceMedium * unitQuantity; return jobTotal; }
            //TODO Make error report
            return 0;
        }

        //TODO this has 1 reference somewhere but it's an outdated method now.  Use GetOptionPrice
        public static double GetPrice(object theClass, double unitQuantity)//TODO set price based on job size
        {

            if (theClass is Driveway driveway)//1
               { double jobTotal; jobTotal = driveway.UnitPriceMedium * unitQuantity; return jobTotal; }
            if (theClass is Sidewalk sidewalk)//2
            {double jobTotal; jobTotal = sidewalk.UnitPriceMedium * unitQuantity; return jobTotal;}
            if (theClass is Curb curb)//3
            { double jobTotal; jobTotal = curb.UnitPriceMedium * unitQuantity; return jobTotal;}
            if (theClass is CurbReplace curbReplace)//4
            {double jobTotal; jobTotal = curbReplace.UnitPriceMedium * unitQuantity; return jobTotal;}

            if (theClass is Patio patio)//5
            { double jobTotal; jobTotal = patio.UnitPriceMedium * unitQuantity; return jobTotal;}
            if (theClass is PatioReplace patioReplacement)//6
            { double jobTotal;jobTotal = patioReplacement.UnitPriceMedium * unitQuantity; return jobTotal;}
            if (theClass is Sawcut sawcut)//7
            {double jobTotal; jobTotal = sawcut.UnitPriceMedium * unitQuantity; return jobTotal;}
            if (theClass is FillExcavation fillExcavation)//8
            {double jobTotal;jobTotal = fillExcavation.UnitPriceMedium * unitQuantity;return jobTotal;}
            if (theClass is SidewalkReplace sidewalkReplace)//9
            { double jobTotal;jobTotal = sidewalkReplace.UnitPriceMedium * unitQuantity; return jobTotal; }
            if (theClass is GarageCap garageCap)//10
            {double jobTotal; jobTotal = garageCap.UnitPriceMedium * unitQuantity; return jobTotal;}
            if (theClass is WoodDeckRemove woodDeckRemove)//11
            { double jobTotal; jobTotal = woodDeckRemove.UnitPriceMedium * unitQuantity; return jobTotal;}
            if (theClass is Footing footing)//12
            { double jobTotal; jobTotal = footing.UnitPriceMedium * unitQuantity; return jobTotal;}
            if (theClass is DrivewayReplace drivewayReplace)//13
            {double jobTotal; jobTotal = drivewayReplace.UnitPriceMedium * unitQuantity; return jobTotal;}
            if (theClass is ConcreteBustout concreteBustout)//14
            { double jobTotal; jobTotal = concreteBustout.UnitPriceMedium * unitQuantity; return jobTotal;}
            if (theClass is PoolDeck poolDeck)//15
            { double jobTotal; jobTotal = poolDeck.UnitPriceMedium * unitQuantity; return jobTotal;}
            if (theClass is PoolDeckReplace poolDeckReplace)//16
            {double jobTotal;jobTotal = poolDeckReplace.UnitPriceMedium * unitQuantity;return jobTotal;}
            
            return 0;
        }


        public static bool PickerChecker(string stringToCheck)
        {
            if (stringToCheck.Equals(Constants.o_curb) || stringToCheck.Equals(Constants.o_curbReplace) || stringToCheck.Equals(Constants.o_footing) ||
                stringToCheck.Equals(Constants.o_sawcut))
            {
                return false;
            }
            else
            {
               return true;
            }
        }



        public double GetOptionPrice(string optionConst, double length, double width, double jobSize, double colorValue) //also uses public double color
        {
            string OC = optionConst;
            double m, x, b, y, units, minUnitPrice, color;
            x = jobSize; //used to find slope, y=mx+b
            units = length * width;
            color = colorValue; //TODO double color = (static variable that comes from the slider)


            if (OC.Equals(Constants.o_driveway))
            {
                if (color > 0.66)
                { //green
                    m = Prices.M_DrivewayGreen;
                    b = Prices.B_DrivewayGreen; 
                    y = m * x + b;
                    minUnitPrice = Prices.MIN_DrivewayGreen;
                    if (y < minUnitPrice) { y = minUnitPrice; }
                    return (y * units);
                }
                else if (color > 0.33)
                { //yellow
                    m = Prices.M_DrivewayYellow;
                    b = Prices.B_DrivewayYellow;
                    y = m * x + b;
                    minUnitPrice = Prices.MIN_DrivewayYellow;
                    if (y < minUnitPrice) { y = minUnitPrice; }
                    return (y * units);
                }
                else
                { //red
                    m = Prices.M_DrivewayRed;
                    b = Prices.B_DrivewayRed;
                    y = m * x + b;
                    minUnitPrice = Prices.MIN_DrivewayRed;
                    if (y < minUnitPrice) { y = minUnitPrice; }
                    return (y * units);
                }
            }
            if (OC.Equals(Constants.o_drivewayReplace))
            {
                if (color > 0.66)
                { //green
                    m = Prices.M_DriveReplaceGreen;
                    b = Prices.B_DriveReplaceGreen;
                    y = m * x + b;
                    minUnitPrice = Prices.MIN_DriveReplaceGreen;
                    if (y < minUnitPrice) { y = minUnitPrice; }
                    return (y * units);
                }
                else if (color > 0.33)
                { //yellow
                    m = Prices.M_DriveReplaceYellow;
                    b = Prices.B_DriveReplaceYellow;
                    y = m * x + b;
                    minUnitPrice = Prices.MIN_DriveReplaceYellow;
                    if (y < minUnitPrice) { y = minUnitPrice; }
                    return (y * units);
                }
                else
                { //red
                    m = Prices.M_DriveReplaceRed;
                    b = Prices.B_DriveReplaceRed;
                    y = m * x + b;
                    minUnitPrice = Prices.MIN_DriveReplaceRed;
                    if (y < minUnitPrice) { y = minUnitPrice; }
                    return (y * units);
                }
            }

            if (OC.Equals(Constants.o_patio))
            {
                if (color > 0.66)
                { //green
                    m = Prices.M_PatioGreen;
                    b = Prices.B_PatioGreen;
                    y = m * x + b;
                    minUnitPrice = Prices.MIN_PatioGreen;
                    if (y < minUnitPrice) { y = minUnitPrice; }
                    return (y * units);
                }
                else if (color > 0.33)
                { //yellow
                    m = Prices.M_PatioYellow;
                    b = Prices.B_PatioYellow;
                    y = m * x + b;
                    minUnitPrice = Prices.MIN_PatioYellow;
                    if (y < minUnitPrice) { y = minUnitPrice; }
                    return (y * units);
                }
                else
                { //red
                    m = Prices.M_PatioRed;
                    b = Prices.B_PatioRed;
                    y = m * x + b;
                    minUnitPrice = Prices.MIN_PatioRed;
                    if (y < minUnitPrice) { y = minUnitPrice; }
                    return (y * units);
                }
            }

            if (OC.Equals(Constants.o_patioReplace))
            {
                if (color > 0.66)
                { //green
                    m = Prices.M_PatioReplaceGreen;
                    b = Prices.B_PatioReplaceGreen;
                    y = m * x + b;
                    minUnitPrice = Prices.MIN_PatioReplaceGreen;
                    if (y < minUnitPrice) { y = minUnitPrice; }
                    return (y * units);
                }
                else if (color > 0.33)
                { //yellow
                    m = Prices.M_PatioReplaceYellow;
                    b = Prices.B_PatioReplaceYellow;
                    y = m * x + b;
                    minUnitPrice = Prices.MIN_PatioReplaceYellow;
                    if (y < minUnitPrice) { y = minUnitPrice; }
                    return (y * units);
                }
                else
                { //red
                    m = Prices.M_PatioReplaceRed;
                    b = Prices.B_PatioReplaceRed;
                    y = m * x + b;
                    minUnitPrice = Prices.MIN_PatioReplaceRed;
                    if (y < minUnitPrice) { y = minUnitPrice; }
                    return (y * units);
                }
            }

            if (OC.Equals(Constants.o_poolDeck))
            {
                if (color > 0.66)
                { //green
                    m = Prices.M_PooldeckGreen;
                    b = Prices.B_PooldeckGreen;
                    y = m * x + b;
                    minUnitPrice = Prices.MIN_PooldeckGreen;
                    if (y < minUnitPrice) { y = minUnitPrice; }
                    return (y * units);
                }
                else if (color > 0.33)
                { //yellow
                    m = Prices.M_PooldeckYellow;
                    b = Prices.B_PooldeckYellow;
                    y = m * x + b;
                    minUnitPrice = Prices.MIN_PooldeckYellow;
                    if (y < minUnitPrice) { y = minUnitPrice; }
                    return (y * units);
                }
                else
                { //red
                    m = Prices.M_PooldeckRed;
                    b = Prices.B_PooldeckRed;
                    y = m * x + b;
                    minUnitPrice = Prices.MIN_PooldeckRed;
                    if (y < minUnitPrice) { y = minUnitPrice; }
                    return (y * units);
                }
            }

            if (OC.Equals(Constants.o_poolDeckReplace))
            {
                if (color > 0.66)
                { //green/expensive
                    m = Prices.M_PooldeckReplaceGreen;
                    b = Prices.B_PooldeckReplaceGreen;
                    y = m * x + b;
                    minUnitPrice = Prices.MIN_PooldeckReplaceGreen;
                    if (y < minUnitPrice) { y = minUnitPrice; }
                    return (y * units);
                }
                else if (color > 0.33)
                { //yellow
                    m = Prices.M_PooldeckReplaceYellow;
                    b = Prices.B_PooldeckReplaceYellow;
                    y = m * x + b;
                    minUnitPrice = Prices.MIN_PooldeckReplaceYellow;
                    if (y < minUnitPrice) { y = minUnitPrice; }
                    return (y * units);
                }
                else
                { //color >= 0 //red/cheap
                    m = Prices.M_PooldeckReplaceRed;
                    b = Prices.B_PooldeckReplaceRed;
                    y = m * x + b;
                    minUnitPrice = Prices.MIN_PooldeckReplaceRed;
                    if (y < minUnitPrice) { y = minUnitPrice; }
                    return (y * units);
                }
            }

            if (OC.Equals(Constants.o_sidewalk))
            {
                if (color > 0.66)
                { //green
                    if (width > 3.5)
                    {
                        y = Prices.Cost_SidewalkGreen;
                        return (y * units);
                    }
                    else
                    {
                        y = Prices.Cost_SidewalkGreen;  //+ smallSidewalk attribute price.  TODO CAM once attributes are in the database.
                        return (y * units);
                    }

                }
                else if (color > 0.33)
                { //yellow
                    if (width > 3.5)
                    {
                        y = Prices.Cost_SidewalkYellow;
                        return (y * units);
                    }
                    else
                    {
                        y = Prices.Cost_SidewalkYellow;
                        return (y * units); //database price + smallSidewalk attribute price.   TODO CAM
                    }

                }
                else
                { //red
                    if (width > 3.5)
                    {
                        y = Prices.Cost_SidewalkRed;
                        return (y * units);
                    }
                    else
                    {
                        y = Prices.Cost_SidewalkRed;
                        return (y * units); //database price + smallSidewalk attribute price.    TODO CAM
                    }
                }
            }

            //End Sidewalk

            //Start SidewalkReplace
            if (OC.Equals(Constants.o_sidewalkReplace))
            {
                if (color > 0.66)
                { //green
                    if (width > 3.5)
                    {
                        y = Prices.Cost_SidewalkReplaceGreen;
                        return (y * units);
                    }
                    else
                    {
                        y = Prices.Cost_SidewalkReplaceGreen + Prices.Cost_ThinSidewalk;  //+ smallSidewalk attribute price.  TODO CAM once attributes are in the database.
                        return (y * units);
                    }

                }
                else if (color > 0.33)
                { //yellow
                    if (width > 3.5)
                    {
                        y = Prices.Cost_SidewalkReplaceYellow;
                        return (y * units);
                    }
                    else
                    {
                        y = Prices.Cost_SidewalkReplaceYellow + Prices.Cost_ThinSidewalk;
                        return (y * units); //database price + smallSidewalk attribute price.        TODO CAM
                    }

                }
                else
                { //red
                    if (width > 3.5)
                    {
                        y = Prices.Cost_SidewalkReplaceRed;
                        return (y * units);
                    }
                    else
                    {
                        y = Prices.Cost_SidewalkReplaceRed + Prices.Cost_ThinSidewalk;
                        return (y * units); //database price + smallSidewalk attribute price.         TODO CAM
                    }

                }
            }

            //End SidewalkReplace

            //Start GarageCap
            if (OC.Equals(Constants.o_garageCap))
            {
                if (color > 0.66)
                { //green
                    if (width > 3.5)
                    {
                        y = Prices.Cost_GarageCapGreen;
                        return (y * units);
                    }
                    else
                    {
                        y = Prices.Cost_GarageCapGreen + Prices.Cost_ThinSidewalk;  //+ smallSidewalk attribute price.  TODO CAM once attributes are in the database.  ???????
                        return (y * units);
                    }

                }
                else if (color > 0.33)
                { //yellow
                    if (width > 3.5)
                    {
                        y = Prices.Cost_GarageCapYellow;
                        return (y * units);
                    }
                    else
                    {
                        y = Prices.Cost_GarageCapYellow + Prices.Cost_ThinSidewalk;
                        return (y * units); //database price + smallSidewalk attribute price.        TODO CAM ???????
                    }

                }
                else
                { //red
                    if (width > 3.5)
                    {
                        y = Prices.Cost_GarageCapRed;
                        return (y * units);
                    }
                    else
                    {
                        y = Prices.Cost_GarageCapRed + Prices.Cost_ThinSidewalk;
                        return (y * units); //database price + smallSidewalk attribute price.         TODO CAM    ???????
                    }

                }
            }

            //End GarageCap

            //Start Curb
            if (OC.Equals(Constants.o_curb))
            {
                y = Prices.Cost_Curb;
                return (y * length);
            }

            //End Curb

            //Start CurbReplace
            if (OC.Equals(Constants.o_curbReplace))
            {
                y = Prices.Cost_CurbReplace;
                return (y * length);
            }

            //End CurbReplace
            
            //Start AddFill
            if (OC.Equals(Constants.o_addFill))
            {
                y = Prices.Cost_AddFill;
                return (y * length);    // this only returns the price from the database, I couldn't find it in the spreadsheet
            }

            //End AddFill

            //Start Footing
            if (OC.Equals(Constants.o_footing))
            {
                y = Prices.Cost_Footing;
                return (y * length);
            }

            //End Footing

            //Start ConcreteBreakout
            if (OC.Equals(Constants.o_concreteBustout))
            {
                y = Prices.Cost_ConcreteBreakout;
                return (y * units);   // units = length * width                 units * y(is this UnitPrice?) Per the Spreadsheet
            }

            //End ConcreteBreakout

            //Start Sawcut
            if (OC.Equals(Constants.o_sawcut))
            {
                y = Prices.Cost_Sawcut;
                return (y * length);
            }

            //End Sawcut

            //Start RemoveFill
            if (OC.Equals(Constants.o_fillExcavation))
            {
                y = Prices.Cost_RemoveFill;
                return (y * length);
            }

            //End RemoveFill

            //Start WoodDeckRemoval
            if (OC.Equals(Constants.o_woodDeckRemove))
            {
                y = Prices.Cost_WoodDeckRemoval;
                return (y * units);   // units = length * width                 units * y(is this UnitPrice?) Per the Spreadsheet
            }

            //End WoodDeckRemoval

            //Start BrickLedge
            if (OC.Equals(Constants.o_brickLedge))
            {
                y = Prices.Cost_BrickLedge;
                return (y * length);
            }

            //End BrickLedge

            //Start ThickenedEdge
            if (OC.Equals(Constants.o_thickenedEdge))
            {
                y = Prices.Cost_ThickenedEdge;
                return (y * length);
            }

            //End ThickenedEdge


            //TODO make other options that don't have slope also.

            return -99999.0000000; //give a crazy error if the option name isn't found.
        }


        public double GetAttributePrice(string attributeConst, double length, double width, double jobSize) //also uses public double color
        {
            string AC = attributeConst;
            double y, units;
            units = length * width;

            if (AC.Equals(Constants.a_6gWire))
            {
                y = Prices.Cost_6gWire;
                return (y * units);
            }
            if (AC.Equals(Constants.a_highwayMat))
            {
                y = Prices.Cost_HighwayMat;
                return (y * units);
            }
            if (AC.Equals(Constants.a_4000_PSI))
            {
                y = Prices.Cost_4000PSI;
                return (y * units);
            }
            if (AC.Equals(Constants.a_Fiber))
            {
                y = Prices.Cost_Fiber;
                return (y * units);
            }
            if (AC.Equals(Constants.a_exposedAggregate))
            {
                y = Prices.Cost_ExposedAggregate;
                return (y * units);
            }
            if (AC.Equals(Constants.a_narrowDrive1))
            {
                y = Prices.Cost_NarrowDrive1;
                return (y * units);
            }
            if (AC.Equals(Constants.a_narrowDrive2))
            {
                y = Prices.Cost_NarrowDrive2;
                return (y * units);
            }
            if (AC.Equals(Constants.a_narrowDrive3))
            {
                y = Prices.Cost_NarrowDrive3;
                return (y * units);
            }
            if (AC.Equals(Constants.a_fillRemoved1))
            {
                y = Prices.Cost_FillRemoved1;
                return (y * units);
            }
            if (AC.Equals(Constants.a_fillRemoved2))
            {
                y = Prices.Cost_FillRemoved2;
                return (y * units);
            }
            if (AC.Equals(Constants.a_Thick5Inches))
            {
                y = Prices.Cost_Thick5Inches;
                return (y * units);
            }
            if (AC.Equals(Constants.a_Thick6Inches))
            {
                y = Prices.Cost_Thick6Inches;
                return (y * units);
            }
            if (AC.Equals(Constants.a_12x8With_2numb5s))
            {
                y = Prices.Cost_12x8With_2numb5s;//12x8
                return (y * length);
            }
            if (AC.Equals(Constants.a_12x12With_4numb5s))
            {
                y = Prices.Cost_12x12With_4numb5s;//12x12
                return (y * length);
            }
            if (AC.Equals(Constants.a_12x14With_4numb5s))
            {
                y = Prices.Cost_12x14With_4numb5s;//12x14
                return (y * length);
            }
            if (AC.Equals(Constants.a_12x16With_4numb5s))
            {
                y = Prices.Cost_12x16With_4numb5s;//12x16
                return (y * length);
            }

            //a_thinSidewalk is auto calculated by user input width TODO

            return -77777.0000000; //give a crazy error if the attribute name isn't found.
        }



        public void CreateDatabase(int databaseID)
        {
            database =
        DependencyService.Get<IDatabaseConnection>().
        DbConnection();

            Prices = database.Table<DatabasePrices>().FirstOrDefault(database => database.Id == databaseID);

        }

    }
}














