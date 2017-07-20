using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPILib;
using WPILib.Commands;

namespace FRC2017c.Commands{
	public class OperatingClimbCommand : Command{
		public OperatingClimbCommand(){
			Requires(FRC2017c.operateSys);
		}
		
		protected override void Initialize(){
		}
		
		protected override void Execute(){
			double axis=FRC2017c.oi.readAxis(RobotMap.joystickOperatingClimbLever,"operate");
			if(axis<-0.01){
				FRC2017c.operateSys.climb(System.Math.Abs(axis));
			}else{
				FRC2017c.operateSys.climb(0);
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
