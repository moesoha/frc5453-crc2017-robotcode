using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPILib;
using WPILib.Commands;
using FRC2017c;

namespace FRC2017c.Commands{
	public class AutonomousCommand:Command{
		int robotLocation=0;/* | -1 | 0 | 1 | */
		bool power=true;

		public AutonomousCommand(string where){
			power=true;
			switch(where){
				case "left":
					robotLocation=-1;
					break;
				case "right":
					robotLocation=1;
					break;
				default:
					robotLocation=0;
					break;
			}
		}


		protected override void Initialize(){
			System.Console.WriteLine("AutonomousCommand Initialized.");
		}

		protected override void Execute(){
			switch(robotLocation){
				case -1:
					System.Console.WriteLine("Initial Location set to LEFT");
					break;
				case 0:
					System.Console.WriteLine("Initial Location set to CENTER");
					FRC2017c.driveSys.arcadeDrive(0.4,0,RobotMap.drivingSquaredInput);
					System.Threading.Thread.Sleep(4000);
					break;
				case 1:
					System.Console.WriteLine("Initial Location set to RIGHT");
					break;
			}
		}

		protected override bool IsFinished(){
			return power;
		}
		
		protected override void End(){
			System.Console.WriteLine("AutonomousCommand is finished.");
		}
		
		protected override void Interrupted(){
			System.Console.WriteLine("AutonomousCommand is interrupted.");
		}
	}
}
