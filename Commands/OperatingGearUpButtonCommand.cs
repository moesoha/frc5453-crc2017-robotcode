using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPILib;
using WPILib.Commands;

namespace FRC2017c.Commands{
	public class OperatingGearUpButtonCommand : Command{
		double modulu=0.0;
		public OperatingGearUpButtonCommand(double mdl){
			modulu=mdl;
			//Requires(FRC2017c.operateSys);
		}
		
		protected override void Initialize(){
			if(modulu!=0){
				FRC2017c.operateSys.busyGearUp=true;
			}else{
				FRC2017c.operateSys.busyGearUp=false;
			}
		}
		
		protected override void Execute(){
			FRC2017c.operateSys.mdlGearUp=modulu;
			if(!FRC2017c.operateSys.holdGearUp){
				FRC2017c.operateSys.gearUp(modulu);
			}
		}
		
		protected override bool IsFinished(){
			return true;
		}
		
		protected override void End(){
		}
		
		protected override void Interrupted(){
			End();
		}
	}
}
