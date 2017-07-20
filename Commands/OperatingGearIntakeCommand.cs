using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPILib;
using WPILib.Commands;

namespace FRC2017c.Commands{
	public class OperatingGearIntakeCommand : Command{
		double modulu=0.0;
		public OperatingGearIntakeCommand(double mdl){
			modulu=mdl;
			//Requires(FRC2017c.operateSys);
		}
		
		protected override void Initialize(){
			if(modulu!=0.0){
				FRC2017c.operateSys.busyGearIntake=true;
			}else{
				FRC2017c.operateSys.busyGearIntake=false;
			}
		}
		
		protected override void Execute(){
			FRC2017c.operateSys.mdlGearIntake=modulu;
			FRC2017c.operateSys.gearIntake(modulu);
		}
		
		protected override bool IsFinished(){
			return true;
		}
		
		protected override void End(){
			FRC2017c.operateSys.busyGearUp=false;
		}
		
		protected override void Interrupted(){
			End();
		}
	}
}
