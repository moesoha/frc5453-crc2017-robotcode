using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPILib;
using WPILib.Commands;
using FRC2017c;

namespace FRC2017c.Commands{
	public class DrivingCommand:Command{

		public DrivingCommand(){
			Requires(FRC2017c.driveSys);
		}
		
		protected override void Initialize(){
			System.Console.WriteLine("DrivingCommand Initialized.");
		}

		// Called repeatedly when this Command is scheduled to run
		protected override void Execute(){
			double speed;

			speed=RobotMap.drivingSpeedConstant[0];
			for(int i=1;i<RobotMap.joystickDrivingSpeedControl.Length;i++){
				speed=(FRC2017c.oi.readButton(RobotMap.joystickDrivingSpeedControl[i],"drive")) ? (speed+RobotMap.drivingSpeedConstant[i]) : speed;
			}
			
			FRC2017c.driveSys.tankDrive(1*(FRC2017c.oi.readAxis(RobotMap.joystickDrivingLeverL,"drive")*speed),-1*(FRC2017c.oi.readAxis(RobotMap.joystickDrivingLeverR,"drive")*speed),RobotMap.drivingSquaredInput);
		}

		protected override bool IsFinished(){
			return false;
		}
		
		protected override void End(){
			System.Console.WriteLine("DrivingCommand is finished.");
			FRC2017c.driveSys.resetMotors();
		}
		
		protected override void Interrupted(){
			System.Console.WriteLine("DrivingCommand is interrupted.");
			End();
		}
	}
}
