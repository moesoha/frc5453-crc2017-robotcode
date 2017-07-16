using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPILib;
using WPILib.Commands;
using FRC2017c;

namespace FRC2017c.Commands{
	public class AutonomousCommand:Command{
		int robotLocation=0; /* | -1 | 0 | 1 | */

		public AutonomousCommand(string where){
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

		private void amazingAutoTurn(double dest){
			double angleInit=FRC2017c.gyroSys.getAngle();
			FRC2017c.driveSys.drivingMotorsControlRaw("left",RobotMap.autonomousAutoGearTurningSpeed);
			double delta=(FRC2017c.gyroSys.getAngle()-angleInit);
			while(delta<dest){
				delta=(FRC2017c.gyroSys.getAngle()-angleInit);
				if(System.Math.Abs(dest-delta)<20){
					FRC2017c.driveSys.drivingMotorsControlRaw("left",RobotMap.autonomousAutoGearTurningSpeed*0.7);
				}else{
					FRC2017c.driveSys.drivingMotorsControlRaw("left",RobotMap.autonomousAutoGearTurningSpeed*0.46);
				}
			}
		}

		private void followThePi(){
			NetworkTables.NetworkTable nt=NetworkTables.NetworkTable.GetTable("Forgive/Vision");
			string turn;
			turn=nt.GetString("turn","great");
			while(turn!="great"){
				FRC2017c.driveSys.drivingMotorsControlRaw("turn",(RobotMap.autonomousAutoGearTurningSpeed)*((turn=="left") ? 1 : -1));
				turn=nt.GetString("turn","great");
			}
		}

		protected override void Execute(){
			FRC2017c.powerSys.motorChassisSafety();
			switch(robotLocation){
				case -1:
					System.Console.WriteLine("Initial Location set to LEFT");
					FRC2017c.driveSys.arcadeDrive(RobotMap.autonomousAutoGearStraightSpeed,0,RobotMap.drivingSquaredInput);
					System.Threading.Thread.Sleep(666);
					amazingAutoTurn(RobotMap.autonomousAutoGearAngle);
					followThePi();
					followThePi();
					break;
				case 0:
					System.Console.WriteLine("Initial Location set to CENTER");
					//FRC2017c.driveSys.arcadeDrive(RobotMap.autonomousAutoGearStraightSpeed,0,RobotMap.drivingSquaredInput);
					//System.Threading.Thread.Sleep(666);
					//FRC2017c.driveSys.arcadeDrive(RobotMap.autonomousAutoGearStraightSpeed*0.7,0,RobotMap.drivingSquaredInput);
					//System.Threading.Thread.Sleep(1333);
					//FRC2017c.driveSys.arcadeDrive(RobotMap.autonomousAutoGearStraightSpeed*0.3,0,RobotMap.drivingSquaredInput);
					//System.Threading.Thread.Sleep(1000);
					FRC2017c.operateSys.gearUp(-0.6);
					System.Threading.Thread.Sleep(1234);
					FRC2017c.operateSys.gearUp(0);
					FRC2017c.operateSys.gearIntake(-0.29);
					System.Threading.Thread.Sleep(6666);
					FRC2017c.operateSys.gearIntake(0);
					break;
				case 1:
					System.Console.WriteLine("Initial Location set to RIGHT");
					break;
			}
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
