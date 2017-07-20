using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPILib;
using WPILib.Commands;

namespace FRC2017c.Commands{
	public class OperatingCommandGroup : CommandGroup{
		public OperatingCommandGroup(){
			Requires(FRC2017c.operateSys);
			AddParallel(new Commands.OperatingCommand());
			AddParallel(new Commands.OperatingGearUpAxisCommand());
			AddParallel(new Commands.OperatingClimbCommand());
			AddParallel(new Commands.OperatingSafeCommand());
		}
	}
}
