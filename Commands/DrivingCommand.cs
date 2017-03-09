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
			FRC2017c.driveSys.bindMotors();
		}

		// Called repeatedly when this Command is scheduled to run
		protected override void Execute(){
			FRC2017c.driveSys.arcadeDrive(-1*FRC2017c.oi.readAxis(RobotMap.joystickDrivingLeverX,"drive")*RobotMap.drivingSpeedConstant,FRC2017c.oi.readAxis(RobotMap.joystickDrivingLeverY,"drive")*RobotMap.drivingSpeedConstant,RobotMap.drivingSquaredInput);
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
