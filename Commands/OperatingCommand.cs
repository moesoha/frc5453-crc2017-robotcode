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
			Requires(FRC2017c.operateSys);
		}

		protected override void Initialize(){
			System.Console.WriteLine("OperatingCommand Initialized.");
		}

		private void doGearUp(){
			if(FRC2017c.oi.readButton(RobotMap.joystickOperatingGearUpUp,"operate")){
				FRC2017c.operateSys.gearUp(1);
			}else if(FRC2017c.oi.readButton(RobotMap.joystickOperatingGearUpDown,"operate")){
				FRC2017c.operateSys.gearUp(-1);
			}else{
				FRC2017c.operateSys.gearUp(0);
			}
		}

		private void doGearIntake(){
			if(FRC2017c.oi.readButton(RobotMap.joystickOperatingGearIntakeIn,"operate")){
				FRC2017c.operateSys.gearIntake(1);
			}else if(FRC2017c.oi.readButton(RobotMap.joystickOperatingGearIntakeOut,"operate")){
				FRC2017c.operateSys.gearIntake(-1);
			}else{
				FRC2017c.operateSys.gearIntake(0);
			}
		}

		private void doClimb(){
			
		}

		protected override void Execute(){
			doGearIntake();
			doGearUp();
		}

		protected override bool IsFinished(){
			return false;
		}
		
		protected override void End(){
			System.Console.WriteLine("OperatingCommand is finished.");
			FRC2017c.operateSys.resetMotors();
		}

		protected override void Interrupted(){
			System.Console.WriteLine("OperatingCommand is interrupted.");
			End();
		}
	}
}
