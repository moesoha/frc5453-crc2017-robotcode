using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPILib;
using WPILib.Commands;
using WPILib.Extras.NavX;
using FRC2017c;
using FRC2017c.Commands;

namespace FRC2017c.Subsystems{
	public class NavSubsystem:Subsystem{
		AHRS ahrs;
		AHRS.BoardYawAxis ahrsBoardYawAxis;
		AHRS.BoardAxis ahrsAxes;
		Array axes;
		double x,y,z;

		public NavSubsystem(){
			System.Console.WriteLine("Init nav subsystem.");
			try{
				ahrs=new AHRS(SPI.Port.MXP);
			}catch(InvalidCastException err){
				System.Console.WriteLine(err.ToString());
				DriverStation.ReportError("navX Error: "+err.Message,true);
			}
		}

		protected override void InitDefaultCommand(){
			SetDefaultCommand(new NavCommand());
		}

		public void getAngel(){
			
			double angel=ahrs.GetAngle();
			System.Console.Write("-"+angel+"-");
		}
	}
}
