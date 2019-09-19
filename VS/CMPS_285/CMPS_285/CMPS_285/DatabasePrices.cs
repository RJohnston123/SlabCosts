using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CMPS_285
{
    public class DatabasePrices : INotifyPropertyChanged
    {
        private int _id;
        [PrimaryKey, AutoIncrement]
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                this._id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        //Start Driveway
        double m_drivewayGreen;
        double b_drivewayGreen;
        double min_drivewayGreen;

        double m_drivewayYellow;
        double b_drivewayYellow;
        double min_drivewayYellow;
        
        double m_drivewayRed;
        double b_drivewayRed;
        double min_drivewayRed;

        public double M_DrivewayGreen { get { return m_drivewayGreen; } set { m_drivewayGreen = value; OnPropertyChanged("M_DrivewayGreen"); } }
        public double B_DrivewayGreen { get { return b_drivewayGreen; } set { b_drivewayGreen = value; OnPropertyChanged("B_DrivewayGreen"); } }
        public double MIN_DrivewayGreen { get { return min_drivewayGreen; } set { min_drivewayGreen = value; OnPropertyChanged("MIN_DrivewayGreen"); } }

        public double M_DrivewayYellow { get { return m_drivewayYellow; } set { m_drivewayYellow = value; OnPropertyChanged("M_DrivewayYellow"); } }
        public double B_DrivewayYellow { get { return b_drivewayYellow; } set { b_drivewayYellow = value; OnPropertyChanged("B_DrivewayYellow"); } }
        public double MIN_DrivewayYellow { get { return min_drivewayYellow; } set { min_drivewayYellow = value; OnPropertyChanged("MIN_DrivewayYellow"); } }
        
        public double M_DrivewayRed { get { return m_drivewayRed; } set { m_drivewayRed = value; OnPropertyChanged("M_DrivewayRed"); } }
        public double B_DrivewayRed { get { return b_drivewayRed; } set { b_drivewayRed = value; OnPropertyChanged("B_DrivewayRed"); } }
        public double MIN_DrivewayRed { get { return min_drivewayRed; } set { min_drivewayRed = value; OnPropertyChanged("MIN_DrivewayRed"); } }

        //End Driveway

        //Start DriveReplace
        double m_drivereplaceGreen;
        double b_drivereplaceGreen;
        double min_drivereplaceGreen;

        double m_drivereplaceYellow;
        double b_drivereplaceYellow;
        double min_drivereplaceYellow;

        double m_drivereplaceRed;
        double b_drivereplaceRed;
        double min_drivereplaceRed;

        public double M_DriveReplaceGreen { get { return m_drivereplaceGreen; } set { m_drivereplaceGreen = value; OnPropertyChanged("M_DriveReplaceGreen"); } }
        public double B_DriveReplaceGreen { get { return b_drivereplaceGreen; } set { b_drivereplaceGreen = value; OnPropertyChanged("B_DriveReplaceGreen"); } }
        public double MIN_DriveReplaceGreen { get { return min_drivereplaceGreen; } set { min_drivereplaceGreen = value; OnPropertyChanged("MIN_DriveReplaceGreen"); } }

        public double M_DriveReplaceYellow { get { return m_drivereplaceYellow; } set { m_drivereplaceYellow = value; OnPropertyChanged("M_DriveReplaceYellow"); } }
        public double B_DriveReplaceYellow { get { return b_drivereplaceYellow; } set { b_drivereplaceYellow = value; OnPropertyChanged("B_DriveReplaceYellow"); } }
        public double MIN_DriveReplaceYellow { get { return min_drivereplaceYellow; } set { min_drivereplaceYellow = value; OnPropertyChanged("MIN_DriveReplaceYellow"); } }

        public double M_DriveReplaceRed { get { return m_drivereplaceRed; } set { m_drivereplaceRed = value; OnPropertyChanged("M_DriveReplaceRed"); } }
        public double B_DriveReplaceRed { get { return b_drivereplaceRed; } set { b_drivereplaceRed = value; OnPropertyChanged("B_DriveReplaceRed"); } }
        public double MIN_DriveReplaceRed { get { return min_drivereplaceRed; } set { min_drivereplaceRed = value; OnPropertyChanged("MIN_DriveReplaceRed"); } }




        //End DriveReplace

        //Start Patio
        double m_patioGreen;
        double b_patioGreen;
        double min_patioGreen;

        double m_patioYellow;
        double b_patioYellow;
        double min_patioYellow;

        double m_patioRed;
        double b_patioRed;
        double min_patioRed;

        public double M_PatioGreen { get { return m_patioGreen; } set { m_patioGreen = value; OnPropertyChanged("M_PatioGreen"); } }
        public double B_PatioGreen { get { return b_patioGreen; } set { b_patioGreen = value; OnPropertyChanged("B_PatioGreen"); } }
        public double MIN_PatioGreen { get { return min_patioGreen; } set { min_patioGreen = value; OnPropertyChanged("MIN_PatioGreen"); } }

        public double M_PatioYellow { get { return m_patioYellow; } set { m_patioYellow = value; OnPropertyChanged("M_PatioYellow"); } }
        public double B_PatioYellow { get { return b_patioYellow; } set { b_patioYellow = value; OnPropertyChanged("B_PatioYellow"); } }
        public double MIN_PatioYellow { get { return min_patioYellow; } set { min_patioYellow = value; OnPropertyChanged("MIN_PatioYellow"); } }

        public double M_PatioRed { get { return m_patioRed; } set { m_patioRed = value; OnPropertyChanged("M_PatioRed"); } }
        public double B_PatioRed { get { return b_patioRed; } set { b_patioRed = value; OnPropertyChanged("B_PatioRed"); } }
        public double MIN_PatioRed { get { return min_patioRed; } set { min_patioRed = value; OnPropertyChanged("MIN_PatioRed"); } }

        //End Patio

        //Start PatioReplace
        double m_patioreplaceGreen;
        double b_patioreplaceGreen;
        double min_patioreplaceGreen;

        double m_patioreplaceYellow;
        double b_patioreplaceYellow;
        double min_patioreplaceYellow;

        double m_patioreplaceRed;
        double b_patioreplaceRed;
        double min_patioreplaceRed;

        public double M_PatioReplaceGreen { get { return m_patioreplaceGreen; } set { m_patioreplaceGreen = value; OnPropertyChanged("M_PatioReplaceGreen"); } }
        public double B_PatioReplaceGreen { get { return b_patioreplaceGreen; } set { b_patioreplaceGreen = value; OnPropertyChanged("B_PatioReplaceGreen"); } }
        public double MIN_PatioReplaceGreen { get { return min_patioreplaceGreen; } set { min_patioreplaceGreen = value; OnPropertyChanged("MIN_PatioReplaceGreen"); } }

        public double M_PatioReplaceYellow { get { return m_patioreplaceYellow; } set { m_patioreplaceYellow = value; OnPropertyChanged("M_PatioReplaceYellow"); } }
        public double B_PatioReplaceYellow { get { return b_patioreplaceYellow; } set { b_patioreplaceYellow = value; OnPropertyChanged("B_PatioReplaceYellow"); } }
        public double MIN_PatioReplaceYellow { get { return min_patioreplaceYellow; } set { min_patioreplaceYellow = value; OnPropertyChanged("MIN_PatioReplaceYellow"); } }

        public double M_PatioReplaceRed { get { return m_patioreplaceRed; } set { m_patioreplaceRed = value; OnPropertyChanged("M_PatioReplaceRed"); } }
        public double B_PatioReplaceRed { get { return b_patioreplaceRed; } set { b_patioreplaceRed = value; OnPropertyChanged("B_PatioReplaceRed"); } }
        public double MIN_PatioReplaceRed { get { return min_patioreplaceRed; } set { min_patioreplaceRed = value; OnPropertyChanged("MIN_PatioReplaceRed"); } }

        //End PatioReplace

        //Start Pooldeck
        double m_pooldeckGreen;
        double b_pooldeckGreen;
        double min_pooldeckGreen;

        double m_pooldeckYellow;
        double b_pooldeckYellow;
        double min_pooldeckYellow;

        double m_pooldeckRed;
        double b_pooldeckRed;
        double min_pooldeckRed;

        public double M_PooldeckGreen { get { return m_pooldeckGreen; } set { m_pooldeckGreen = value; OnPropertyChanged("M_PooldeckGreen"); } }
        public double B_PooldeckGreen { get { return b_pooldeckGreen; } set { b_pooldeckGreen = value; OnPropertyChanged("B_PooldeckGreen"); } }
        public double MIN_PooldeckGreen { get { return min_pooldeckGreen; } set { min_pooldeckGreen = value; OnPropertyChanged("MIN_PooldeckGreen"); } }

        public double M_PooldeckYellow { get { return m_pooldeckYellow; } set { m_pooldeckYellow = value; OnPropertyChanged("M_PooldeckYellow"); } }
        public double B_PooldeckYellow { get { return b_pooldeckYellow; } set { b_pooldeckYellow = value; OnPropertyChanged("B_PooldeckYellow"); } }
        public double MIN_PooldeckYellow { get { return min_pooldeckYellow; } set { min_pooldeckYellow = value; OnPropertyChanged("MIN_PooldeckYellow"); } }

        public double M_PooldeckRed { get { return m_pooldeckRed; } set { m_pooldeckRed = value; OnPropertyChanged("M_PooldeckRed"); } }
        public double B_PooldeckRed { get { return b_pooldeckRed; } set { b_pooldeckRed = value; OnPropertyChanged("B_PooldeckRed"); } }
        public double MIN_PooldeckRed { get { return min_pooldeckRed; } set { min_pooldeckRed = value; OnPropertyChanged("MIN_PooldeckRed"); } }

        //End Pooldeck

        //Start PooldeckReplace
        double m_pooldeckreplaceGreen;
        double b_pooldeckreplaceGreen;
        double min_pooldeckreplaceGreen;

        double m_pooldeckreplaceYellow;
        double b_pooldeckreplaceYellow;
        double min_pooldeckreplaceYellow;

        double m_pooldeckreplaceRed;
        double b_pooldeckreplaceRed;
        double min_pooldeckreplaceRed;

        public double M_PooldeckReplaceGreen { get { return m_pooldeckreplaceGreen; } set { m_pooldeckreplaceGreen = value; OnPropertyChanged("M_PooldeckReplaceGreen"); } }
        public double B_PooldeckReplaceGreen { get { return b_pooldeckreplaceGreen; } set { b_pooldeckreplaceGreen = value; OnPropertyChanged("B_PooldeckReplaceGreen"); } }
        public double MIN_PooldeckReplaceGreen { get { return min_pooldeckreplaceGreen; } set { min_pooldeckreplaceGreen = value; OnPropertyChanged("MIN_PooldeckReplaceGreen"); } }

        public double M_PooldeckReplaceYellow { get { return m_pooldeckreplaceYellow; } set { m_pooldeckreplaceYellow = value; OnPropertyChanged("M_PooldeckReplaceYellow"); } }
        public double B_PooldeckReplaceYellow { get { return b_pooldeckreplaceYellow; } set { b_pooldeckreplaceYellow = value; OnPropertyChanged("B_PooldeckReplaceYellow"); } }
        public double MIN_PooldeckReplaceYellow { get { return min_pooldeckreplaceYellow; } set { min_pooldeckreplaceYellow = value; OnPropertyChanged("MIN_PooldeckReplaceYellow"); } }

        public double M_PooldeckReplaceRed { get { return m_pooldeckreplaceRed; } set { m_pooldeckreplaceRed = value; OnPropertyChanged("M_PooldeckReplaceRed"); } }
        public double B_PooldeckReplaceRed { get { return b_pooldeckreplaceRed; } set { b_pooldeckreplaceRed = value; OnPropertyChanged("B_PooldeckReplaceRed"); } }
        public double MIN_PooldeckReplaceRed { get { return min_pooldeckreplaceRed; } set { min_pooldeckreplaceRed = value; OnPropertyChanged("MIN_PooldeckReplaceRed"); } }

        //End PooldeckReplace

        //Start sidewalk
        double cost_sidewalkGreen;
        double cost_sidewalkYellow;
        double cost_sidewalkRed;

        public double Cost_SidewalkGreen { get { return cost_sidewalkGreen; } set { cost_sidewalkGreen = value; OnPropertyChanged("Cost_SidewalkGreen"); } }
        public double Cost_SidewalkYellow { get { return cost_sidewalkYellow; } set { cost_sidewalkYellow = value; OnPropertyChanged("Cost_SidewalkYellow"); } }
        public double Cost_SidewalkRed { get { return cost_sidewalkRed; } set { cost_sidewalkRed = value; OnPropertyChanged("Cost_SidewalkRed"); } }

        //End sidewalk

        //Start sidewalkReplace
        double cost_sidewalkReplaceGreen;
        double cost_sidewalkReplaceYellow;
        double cost_sidewalkReplaceRed;

        public double Cost_SidewalkReplaceGreen { get { return cost_sidewalkReplaceGreen; } set { cost_sidewalkReplaceGreen = value; OnPropertyChanged("Cost_SidewalkReplaceGreen"); } }
        public double Cost_SidewalkReplaceYellow { get { return cost_sidewalkReplaceYellow; } set { cost_sidewalkReplaceYellow = value; OnPropertyChanged("Cost_SidewalkReplaceYellow"); } }
        public double Cost_SidewalkReplaceRed { get { return cost_sidewalkReplaceRed; } set { cost_sidewalkReplaceRed = value; OnPropertyChanged("Cost_SidewalkReplaceRed"); } }

        //End sidewalkReplace

        //Start garageCap
        double cost_garageCapGreen;
        double cost_garageCapYellow;
        double cost_garageCapRed;

        public double Cost_GarageCapGreen { get { return cost_garageCapGreen; } set { cost_garageCapGreen = value; OnPropertyChanged("Cost_GarageCapGreen"); } }
        public double Cost_GarageCapYellow { get { return cost_garageCapYellow; } set { cost_garageCapYellow = value; OnPropertyChanged("Cost_GarageCapYellow"); } }
        public double Cost_GarageCapRed { get { return cost_garageCapRed; } set { cost_garageCapRed = value; OnPropertyChanged("Cost_GarageCapRed"); } }

        //End garageCap


        //Start curb
        double cost_curb;

        public double Cost_Curb { get { return cost_curb; } set { cost_curb = value; OnPropertyChanged("Cost_Curb"); } }

        //End curb

        //Start curbReplace
        double cost_curbReplace;

        public double Cost_CurbReplace { get { return cost_curbReplace; } set { cost_curbReplace = value; OnPropertyChanged("Cost_CurbReplace"); } }

        //End curnReplace

        //Start addFill
        double cost_addFill;

        public double Cost_AddFill { get { return cost_addFill; } set { cost_addFill = value; OnPropertyChanged("Cost_AddFill"); } }

        //End addFill

        //Start footing
        double cost_footing;

        public double Cost_Footing { get { return cost_footing; } set { cost_footing = value; OnPropertyChanged("Cost_Footing"); } }

        //End footing

        //Start concreteBreakout
        double cost_concreteBreakout;

        public double Cost_ConcreteBreakout { get { return cost_concreteBreakout; } set { cost_concreteBreakout = value; OnPropertyChanged("Cost_ConcreteBreakout"); } }

        //End concreteBreakout

        //Start sawcut
        double cost_sawcut;

        public double Cost_Sawcut { get { return cost_sawcut; } set { cost_sawcut = value; OnPropertyChanged("Cost_Sawcut"); } }

        //End sawcut

        //Start removeFill
        double cost_removeFill;

        public double Cost_RemoveFill { get { return cost_removeFill; } set { cost_removeFill = value; OnPropertyChanged("Cost_RemoveFill"); } }

        //End removeFill

        //Start WoodDeckRemoval
        double cost_WoodDeckRemoval;

        public double Cost_WoodDeckRemoval { get { return cost_WoodDeckRemoval; } set { cost_WoodDeckRemoval = value; OnPropertyChanged("Cost_WoodDeckRemoval"); } }

        //End WoodDeckRemoval

        //Start brickLedge
        double cost_brickLedge;

        public double Cost_BrickLedge { get { return cost_brickLedge; } set { cost_brickLedge = value; OnPropertyChanged("Cost_BrickLedge"); } }

        //End brickLedge

        //Start thickenedEdge
        double cost_thickenedEdge;

        public double Cost_ThickenedEdge { get { return cost_thickenedEdge; } set { cost_thickenedEdge = value; OnPropertyChanged("Cost_ThickenedEdge"); } }

        //End thickenedEdge

        //Start 6gwire
        double cost_6gWire;

        public double Cost_6gWire { get { return cost_6gWire; } set { cost_6gWire = value; OnPropertyChanged("Cost_6gWire"); } }

        //End 6gwire

        //Start highwayMat
        double cost_highwayMat;

        public double Cost_HighwayMat { get { return cost_highwayMat; } set { cost_highwayMat = value; OnPropertyChanged("Cost_HighwayMat"); } }

        //End highwayMat

        //Start 4000PSI
        double cost_4000PSI;

        public double Cost_4000PSI { get { return cost_4000PSI; } set { cost_4000PSI = value; OnPropertyChanged("Cost_4000PSI"); } }

        //End 4000PSI

        //Start fiber
        double cost_fiber;

        public double Cost_Fiber { get { return cost_fiber; } set { cost_fiber = value; OnPropertyChanged("Cost_Fiber"); } }

        //End fiber

        //Start exposedAggregate
        double cost_exposedAggregate;

        public double Cost_ExposedAggregate { get { return cost_exposedAggregate; } set { cost_exposedAggregate = value; OnPropertyChanged("Cost_ExposedAggregate"); } }

        //End exposedAggregate

        //Start narrowDrive1
        double cost_narrowDrive1;

        public double Cost_NarrowDrive1 { get { return cost_narrowDrive1; } set { cost_narrowDrive1 = value; OnPropertyChanged("Cost_NarrowDrive1"); } }

        //End narrowDrive1

        //Start narrowDrive2
        double cost_narrowDrive2;

        public double Cost_NarrowDrive2 { get { return cost_narrowDrive2; } set { cost_narrowDrive2 = value; OnPropertyChanged("Cost_NarrowDrive2"); } }

        //End narrowDrive2

        //Start narrowDrive3
        double cost_narrowDrive3;

        public double Cost_NarrowDrive3 { get { return cost_narrowDrive3; } set { cost_narrowDrive3 = value; OnPropertyChanged("Cost_NarrowDrive3"); } }

        //End narrowDrive3

        //Start fillRemoved1
        double cost_fillRemoved1;

        public double Cost_FillRemoved1 { get { return cost_fillRemoved1; } set { cost_fillRemoved1 = value; OnPropertyChanged("Cost_FillRemoved1"); } }

        //End fillRemoved1

        //Start fillRemoved2
        double cost_fillRemoved2;

        public double Cost_FillRemoved2 { get { return cost_fillRemoved2; } set { cost_fillRemoved2 = value; OnPropertyChanged("Cost_FillRemoved2"); } }

        //End fillRemoved2

        //Start thick5Inches
        double cost_thick5Inches;

        public double Cost_Thick5Inches { get { return cost_thick5Inches; } set { cost_thick5Inches = value; OnPropertyChanged("Cost_Thick5Inches"); } }

        //End thick5Inches

        //Start thick6Inches
        double cost_thick6Inches;

        public double Cost_Thick6Inches { get { return cost_thick6Inches; } set { cost_thick6Inches = value; OnPropertyChanged("Cost_Thick6Inches"); } }

        //End thick6Inches

        //Start 12x8With_2numb5s
        double cost_12x8With_2numb5s;

        public double Cost_12x8With_2numb5s { get { return cost_12x8With_2numb5s; } set { cost_12x8With_2numb5s = value; OnPropertyChanged("Cost_12x8With_2numb5s"); } }

        //End 12x8With_2numb5s

        //Start 12x12With_4numb5s
        double cost_12x12With_4numb5s;

        public double Cost_12x12With_4numb5s { get { return cost_12x12With_4numb5s; } set { cost_12x12With_4numb5s = value; OnPropertyChanged("Cost_12x12With_4numb5s"); } }

        //End 12x12With_4numb5s

        //Start 12x14With_4numb5s
        double cost_12x14With_4numb5s;

        public double Cost_12x14With_4numb5s { get { return cost_12x14With_4numb5s; } set { cost_12x14With_4numb5s = value; OnPropertyChanged("Cost_12x14With_4numb5s"); } }

        //End 12x14With_4numb5s

        //Start 12x16With_4numb5s
        double cost_12x16With_4numb5s;

        public double Cost_12x16With_4numb5s { get { return cost_12x16With_4numb5s; } set { cost_12x16With_4numb5s = value; OnPropertyChanged("Cost_12x16With_4numb5s"); } }

        //End 12x16With_4numb5s //cost_12x16With_4numb5s

        //Start ThinSidewalk
        double cost_thinSidewalk;

        public double Cost_ThinSidewalk { get { return cost_thinSidewalk; } set { cost_thinSidewalk = value; OnPropertyChanged("Cost_ThinSidewalk"); } }

        //End ThinSidewalk





        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
