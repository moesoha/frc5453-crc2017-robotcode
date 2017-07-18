using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPILib;
using WPILib.Commands;
using FRC2017c;

namespace FRC2017c.Commands{
	public class PowerCommand:Command{
		private double[] max=new double[]{0,0,0,0};

		public PowerCommand(){
			Requires(FRC2017c.powerSys);
		}

		protected override void Initialize(){
			System.Console.WriteLine("PowerCommand Initialized.");
		}

		protected override void Execute(){
			WPILib.SmartDashboard.SmartDashboard.PutNumber("PDP Temperature",FRC2017c.powerSys.getTemperature());
			WPILib.SmartDashboard.SmartDashboard.PutNumber("PDP Total Current",FRC2017c.powerSys.getTotalCurrent());
			WPILib.SmartDashboard.SmartDashboard.PutNumber("Takein Motor 11",FRC2017c.powerSys.getCurrent(11));
			for(int i=0;i<4;i++){
				max[i]=max[i]<FRC2017c.powerSys.getCurrent(RobotMap.pdpMotorOnChassis[i]) ? FRC2017c.powerSys.getCurrent(RobotMap.pdpMotorOnChassis[i]) : max[i];
				WPILib.SmartDashboard.SmartDashboard.PutNumber("[Current Max] Chassis Motor "+i.ToString(),max[i]);
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
