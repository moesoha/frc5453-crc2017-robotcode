using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPILib;
using WPILib.Commands;
using FRC2017c;

namespace FRC2017c.Commands{
	public class AutonomousCommand:Command{
		public AutonomousCommand(){

		}

		protected override void Initialize(){
			System.Console.WriteLine("AutonomousCommand Initialized.");
		}

		protected override void Execute(){
			FRC2017c.driveSys.arcadeDrive(0,-1*RobotMap.drivingSpeedConstant,RobotMap.drivingSquaredInput);
		}

		protected override bool IsFinished(){
			return true;
		}
		
		protected override void End(){
			System.Console.WriteLine("AutonomousCommand is finished.");
		}
		
		protected override void Interrupted(){
			System.Console.WriteLine("AutonomousCommand is interrupted.");
		}
	}
}
