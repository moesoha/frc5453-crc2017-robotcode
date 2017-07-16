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
		
		private void doGearUpButton(){
			
		}

		private void doGearUpAxis(double axis){
			if(System.Math.Abs(axis)>0.01){
				FRC2017c.operateSys.gearUp(-1*axis);
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
			double axis=FRC2017c.oi.readAxis(RobotMap.joystickOperatingClimbLever,"operate");
			if(axis<-0.01){
				FRC2017c.operateSys.climb(System.Math.Abs(axis));
			}else{
				FRC2017c.operateSys.climb(0);
			}
		}

		protected override void Execute(){
			doGearIntake();

			if(FRC2017c.oi.readButton(RobotMap.joystickOperatingGearUpUp,"operate")){
				FRC2017c.operateSys.gearUp(1);
			}else if(FRC2017c.oi.readButton(RobotMap.joystickOperatingGearUpDown,"operate")){
				FRC2017c.operateSys.gearUp(-1);
			}else{
				doGearUpAxis(FRC2017c.oi.readAxis(RobotMap.joystickOperatingGearUpLever,"operate"));
			}

			doClimb();
			//System.Console.WriteLine(FRC2017c.operateSys.gearUpGetPosition());
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
