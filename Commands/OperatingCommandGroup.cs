using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPILib;
using WPILib.Commands;

namespace FRC2017c.Commands{
	public class OperatingCommandGroup : CommandGroup{
		public OperatingCommandGroup(){
			// Add Commands here:
			// e.g. AddSequential(new Command1());
			//      AddSequential(new Command2());
			// these will run in order.

			// To run multiple commands at the same time,
			// use AddParallel()
			// e.g. AddParallel(new Command1());
			//      AddSequential(new Command2());
			// Command1 and Command2 will run in parallel.

			// A command group will require all of the subsystems that each member
			// would require.
			// e.g. if Command1 requires chassis, and Command2 requires arm,
			// a CommandGroup containing them would require both the chassis and the
			// arm.

			AddParallel(new Commands.OperatingCommand());
			AddParallel(new Commands.OperatingGearUpAxisCommand());
			AddParallel(new Commands.OperatingSafeCommand());
		}
	}
}
