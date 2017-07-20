using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPILib;
using WPILib.Commands;
using FRC2017c;

namespace FRC2017c.Commands{
	public class OperatingCommand:Command{
		public OperatingCommand(){
			//Requires(FRC2017c.operateSys);
		}

		protected override void Initialize(){
			System.Console.WriteLine("OperatingCommand Initialized.");
			//(new OperatingCommandGroup()).Start();
		}

		protected override void Execute(){
		}

		protected override bool IsFinished(){
			return false;
		}
		
		protected override void End(){
			//(new OperatingCommandGroup()).Cancel();
			System.Console.WriteLine("OperatingCommand Ended.");
			FRC2017c.operateSys.resetMotors();
		}

		protected override void Interrupted(){
			End();
		}
	}
}
