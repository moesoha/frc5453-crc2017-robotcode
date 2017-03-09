using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPILib;
using WPILib.Commands;

namespace FRC2017c.Commands{
	public class OperatingCommand:Command{
		OI oi;

		public OperatingCommand(){
			Requires(FRC2017c.operateSys);
			//Requires(FRC2017c.driveSys);
			oi=new OI();
		}
		
		private void doBallReady(){
			if(oi.readAxis(RobotMap.joystickDrivingBallReadyClockwise,"drive")>0.02){
				FRC2017c.operateSys.readyBall(1,oi.readAxis(RobotMap.joystickDrivingBallReadyClockwise,"drive")*RobotMap.ballReadySpeedConstant);
			}else if(oi.readAxis(RobotMap.joystickDrivingBallReadyCounterClockwise,"drive")>0.02){
				FRC2017c.operateSys.readyBall(-1,oi.readAxis(RobotMap.joystickDrivingBallReadyCounterClockwise,"drive")*RobotMap.ballReadySpeedConstant);
			}else{
				FRC2017c.operateSys.readyBall(-1,0.0);
			}
		}

		private void doBallShoot(){
			if(oi.readButton(RobotMap.joystickDrivingBallShoot,"drive")){
				FRC2017c.operateSys.shootBall((double)(RobotMap.ballShootSpeedConstant*1.0));
			}else{
				FRC2017c.operateSys.shootBall(0.0);
			}
		}

		private void doRobotClimb(){
			if(oi.readButton(RobotMap.joystickDrivingRobotClimb,"drive")){
				FRC2017c.operateSys.robotClimb((double)(RobotMap.robotClimbSpeedConstant*1.0));
			}else{
				FRC2017c.operateSys.robotClimb(0.0);
			}
		}

		private void doMotorReset(){
			if(oi.readButton(RobotMap.joystickDrivingStopAll,"drive")){
				FRC2017c.operateSys.resetMotors();
				FRC2017c.driveSys.resetMotors();
			}
		}

		protected override void Initialize(){
			System.Console.WriteLine("OperatingCommand Initialized.");
		}

		protected override void Execute(){
			doBallReady();
			doBallShoot();
			//doRobotClimb();
			doMotorReset();
		}

		protected override bool IsFinished(){
			return false;
		}
		
		protected override void End(){
			System.Console.WriteLine("OperatingCommand is finished.");
		}

		protected override void Interrupted(){
			System.Console.WriteLine("OperatingCommand is interrupted.");
		}
	}
}
