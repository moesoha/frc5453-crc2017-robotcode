using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPILib;
using WPILib.Commands;
using FRC2017c;

namespace FRC2017c.Commands{
	public class PowerCommand:Command{

		public PowerCommand(){
			Requires(FRC2017c.powerSys);
		}

		protected override void Initialize(){
			System.Console.WriteLine("PowerCommand Initialized.");
		}

		protected override void Execute(){
			FRC2017c.powerSys.updateTable();
			WPILib.SmartDashboard.SmartDashboard.PutNumber("PDP Temperature",FRC2017c.powerSys.getTemperature());
			WPILib.SmartDashboard.SmartDashboard.PutNumber("PDP Total Current",FRC2017c.powerSys.getTotalCurrent());
			WPILib.SmartDashboard.SmartDashboard.PutNumber("Climb Motor 4",FRC2017c.powerSys.getCurrent(4));
			WPILib.SmartDashboard.SmartDashboard.PutNumber("Intake Motor 11",FRC2017c.powerSys.getCurrent(11));
			for(int i=0;i<4;i++){
				WPILib.SmartDashboard.SmartDashboard.PutNumber("Chassis Motor Group "+i.ToString(),FRC2017c.powerSys.getCurrent(RobotMap.pdpMotorOnChassis[i]));
			}
		}

		protected override bool IsFinished(){
			return false;
		}
		
		protected override void End(){
			System.Console.WriteLine("PowerCommand is finished.");
		}

		protected override void Interrupted(){
			System.Console.WriteLine("PowerCommand is interrupted.");
			End();
		}
	}
}
