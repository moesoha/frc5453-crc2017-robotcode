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
			FRC2017c.powerSys.motorChassisSafety();
			WPILib.SmartDashboard.SmartDashboard.PutNumber("PDP Temperature",FRC2017c.powerSys.getTemperature());
			WPILib.SmartDashboard.SmartDashboard.PutNumber("PDP Total Current",FRC2017c.powerSys.getTotalCurrent());
			WPILib.SmartDashboard.SmartDashboard.PutNumber("[Current] Chassis Motor 0",FRC2017c.powerSys.getCurrent(RobotMap.pdpMotorOnChassis[0]));
			WPILib.SmartDashboard.SmartDashboard.PutNumber("[Current] Chassis Motor 1",FRC2017c.powerSys.getCurrent(RobotMap.pdpMotorOnChassis[1]));
			WPILib.SmartDashboard.SmartDashboard.PutNumber("[Current] Chassis Motor 2",FRC2017c.powerSys.getCurrent(RobotMap.pdpMotorOnChassis[2]));
			WPILib.SmartDashboard.SmartDashboard.PutNumber("[Current] Chassis Motor 3",FRC2017c.powerSys.getCurrent(RobotMap.pdpMotorOnChassis[3]));
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
