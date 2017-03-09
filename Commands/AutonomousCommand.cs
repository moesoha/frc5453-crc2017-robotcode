using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPILib;
using WPILib.Commands;

namespace FRC2017c.Commands{
	public class AutonomousCommand:Command{
		public AutonomousCommand(){
			Requires(FRC2017c.driveSys);
		}

		protected override void Initialize(){
			System.Console.WriteLine("AutonomousCommand Initialized.");
		}

		protected override void Execute(){
			FRC2017c.driveSys.arcadeDrive(0.8,0,true);
		}

		protected override bool IsFinished(){
			return true;
		}
		
		protected override void End(){
			System.Console.WriteLine("AutonomousCommand is finished.");
		}
		
		protected override void Interrupted(){
			System.Console.WriteLine("AutonomousCommand is interrupted.");
		}
	}
}
