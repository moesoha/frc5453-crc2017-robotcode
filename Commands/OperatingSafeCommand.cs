using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPILib;
using WPILib.Commands;

namespace FRC2017c.Commands{
	public class OperatingSafeCommand : Command{
		public OperatingSafeCommand(){
			//Requires(FRC2017c.operateSys);
		}
		
		protected override void Initialize(){
		}
		
		protected override void Execute(){
			if(FRC2017c.powerSys.getCurrent(RobotMap.pdpMotorGearUp)>RobotMap.stallMotorGearUpSmall){
				System.Console.WriteLine("GearUp Motor Current Danger!");
				FRC2017c.operateSys.holdGearUp=true;
				if(FRC2017c.operateSys.mdlGearUp<=0){
					FRC2017c.operateSys.gearUp(0.9);
					System.Threading.Thread.Sleep(450);
				}else{
					FRC2017c.operateSys.gearUp(-1);
					System.Threading.Thread.Sleep(660);
				}
				FRC2017c.operateSys.gearUp(0);
				System.Threading.Thread.Sleep(100);
				FRC2017c.operateSys.holdGearUp=false;
				System.Console.WriteLine("GearUp Motor Reset.");
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
