using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPILib;
using WPILib.Commands;
using FRC2017c;
using FRC2017c.Commands;


namespace FRC2017c.Subsystems{
	public class GyroSubsystem:Subsystem{
		WPILib.Extras.NavX.AHRS ahrs;

		double angle;
		bool tableInited=false;

		public GyroSubsystem(){
			System.Console.WriteLine("Init gyro subsystem.");
			ahrs=new WPILib.Extras.NavX.AHRS(SPI.Port.MXP);
			ahrs.Reset();
			angle=ahrs.GetAngle();
			System.Console.WriteLine("NaiveX Version: "+ahrs.GetFirmwareVersion());
		}
		
		private void initTable(){
			if(!tableInited){
				ahrs.InitTable(NetworkTables.NetworkTable.GetTable("Robot/AHRS"));
				tableInited=true;
			}
		}

		protected override void InitDefaultCommand(){
			//SetDefaultCommand(new GyroCommand());
		}

		public void updateTable(){
			initTable();
			ahrs.UpdateTable();
		}

		public double getAngle(){
			return ahrs.GetAngle();
		}

		public double getHeading(){
			return ahrs.GetFusedHeading();
		}
		
		public double getYaw(){
			return ahrs.GetYaw();
		}
		
		public double getDisplacementX(){
			return ahrs.GetDisplacementX();
		}
		
		public double getDisplacementY(){
			return ahrs.GetDisplacementY();
		}
		
		public double getDisplacementZ(){
			return ahrs.GetDisplacementZ();
		}
		
		public void resetDisplacement(){
			ahrs.ResetDisplacement();
		}
		
		public double getDisplacement(){
			return System.Math.Sqrt(System.Math.Pow(ahrs.GetDisplacementX(),2)+System.Math.Pow(ahrs.GetDisplacementY(),2)+System.Math.Pow(ahrs.GetDisplacementZ(),2));
		}

		public void reset(){
			ahrs.Reset();
		}
	}
}
