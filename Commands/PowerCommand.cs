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
			FRC2017c.powerSys.liveWindowMode(true);
		}
		
		private void motorChassisSafety(){
			for(int i=0;i<RobotMap.pdpMotorOnChassis.Length;i++){
				if(FRC2017c.powerSys.getCurrent(RobotMap.pdpMotorOnChassis[i])>RobotMap.pdpMotorOnChassisCriticalCurrent){
					FRC2017c.driveSys.resetMotor(i);
				}
			}
		}

		protected override void Execute(){
			WPILib.SmartDashboard.SmartDashboard.PutNumber("PDP Temperature",FRC2017c.powerSys.getTemperature());
		}

		protected override bool IsFinished(){
			return false;
		}
		
		protected override void End(){
			System.Console.WriteLine("PowerCommand is finished.");
			FRC2017c.powerSys.liveWindowMode(false);
		}

		protected override void Interrupted(){
			System.Console.WriteLine("PowerCommand is interrupted.");
			End();
		}
	}
}
