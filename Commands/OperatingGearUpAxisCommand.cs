using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPILib;
using WPILib.Commands;

namespace FRC2017c.Commands{
	public class OperatingGearUpAxisCommand : Command{
		public OperatingGearUpAxisCommand(){
			//Requires(FRC2017c.operateSys);
		}
		
		protected override void Initialize(){
		}

		protected override void Execute(){
			double modulu=0.0;
			if(!FRC2017c.operateSys.busyGearUp && !FRC2017c.operateSys.holdGearIntake){
				modulu=FRC2017c.oi.readAxis(RobotMap.joystickOperatingGearUpLever,"operate");
				modulu=(System.Math.Abs(modulu)>0.01) ? (-modulu) : 0;
				FRC2017c.operateSys.mdlGearUp=modulu;
				FRC2017c.operateSys.gearUp(modulu);
			}
		}

		protected override bool IsFinished(){
			return false;
		}
		
		protected override void End(){
		}
		
		protected override void Interrupted(){
			End();
		}
	}
}
