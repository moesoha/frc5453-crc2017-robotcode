using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPILib;
using WPILib.Commands;
using FRC2017c;

namespace FRC2017c.Commands{
	public class GyroCommand:Command{
		public GyroCommand(){
			Requires(FRC2017c.gyroSys);
		}

		protected override void Initialize(){
			System.Console.WriteLine("GyroCommand Initialized.");
		}

		protected override void Execute(){
			WPILib.SmartDashboard.SmartDashboard.PutNumber("Angle",FRC2017c.gyroSys.getAngle());
		}

		protected override bool IsFinished(){
			return false;
		}
		
		protected override void End(){
			System.Console.WriteLine("GyroCommand is finished.");
		}

		protected override void Interrupted(){
			System.Console.WriteLine("GyroCommand is interrupted.");
			End();
		}
	}
}
