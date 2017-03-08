using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPILib;
using WPILib.Commands;

namespace FRC2017c.Commands{
	public class DrivingCommand:Command{
		OI oi;

		public DrivingCommand(){
			Requires(FRC2017c.driveSys);
			oi=new OI();
		}
		
		protected override void Initialize(){
			System.Console.WriteLine("DrivingCommand Initialized.");
		}

		// Called repeatedly when this Command is scheduled to run
		protected override void Execute(){
			FRC2017c.driveSys.arcadeDrive(-1*oi.readAxis(RobotMap.joystickDrivingLeverX,"drive")*RobotMap.drivingSpeedConstant,oi.readAxis(RobotMap.joystickDrivingLeverY,"drive")*RobotMap.drivingSpeedConstant,RobotMap.drivingSquaredInput);
		}

		protected override bool IsFinished(){
			return false;
		}
		
		protected override void End(){
			System.Console.WriteLine("DrivingCommand is finished.");
		}

		// Called when another command which requires one or more of the same
		// subsystems is scheduled to run
		protected override void Interrupted(){

		}
	}
}
