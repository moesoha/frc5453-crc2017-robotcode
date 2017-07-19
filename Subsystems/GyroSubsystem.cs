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

		public GyroSubsystem(){
			System.Console.WriteLine("Init gyro subsystem.");
			ahrs=new WPILib.Extras.NavX.AHRS(SPI.Port.MXP);
			ahrs.Reset();
			ahrs.InitTable(NetworkTables.NetworkTable.GetTable("Robot/AHRS"));
			angle=ahrs.GetAngle();
		}

		protected override void InitDefaultCommand(){
			//SetDefaultCommand(new GyroCommand());
		}

		public void updateTable(){
			ahrs.UpdateTable();
		}

		public double getAngle(){
			return ahrs.GetAngle();
		}
	}
}
