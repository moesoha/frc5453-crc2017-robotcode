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

		}

		protected override void Execute(){

		}

		protected override bool IsFinished(){
			return false;
		}
		
		protected override void End(){

		}
		
		protected override void Interrupted(){

		}
	}
}
