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
			Requires(FRC2017c.operateSys);
		}
		
		protected override void Initialize(){
			FRC2017c.operateSys.busyGearUp=true;
		}
		
		protected override void Execute(){
			FRC2017c.operateSys.mdlGearUp=modulu;
			FRC2017c.operateSys.gearUp(modulu);
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
