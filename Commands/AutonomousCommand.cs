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
			double speed=RobotMap.autonomousAutoGearTurningSpeed;
			double delta=(FRC2017c.gyroSys.getAngle()-angleInit);
			while(System.Math.Abs(delta)<System.Math.Abs(dest)){
				FRC2017c.driveSys.drivingMotorsControlRaw("turn",speed);
				if(System.Math.Abs(dest-delta)<3){
					FRC2017c.driveSys.resetMotors();
					break;
				}else if(System.Math.Abs(dest-delta)<13){
					speed=RobotMap.autonomousAutoGearTurningSpeed*0.7;
				}else{
					speed=RobotMap.autonomousAutoGearTurningSpeed*0.86;
				}
				delta=(FRC2017c.gyroSys.getAngle()-angleInit);
			}
		}

		private void followThePi(){
			NetworkTables.NetworkTable nt=NetworkTables.NetworkTable.GetTable("Forgiving/Vision");
			string turn;
			turn=nt.GetString("turn","null");
			while(turn!="great"){
				if(turn!="null"){
					FRC2017c.driveSys.drivingMotorsControlRaw("turn",(RobotMap.autonomousAutoGearTurningSpeed)*((turn=="left") ? 1 : -1));
				}
				turn=nt.GetString("turn","null");
			}
		}

		protected override void Execute(){
			NetworkTables.NetworkTable.GetTable("Forgiving/Vision").PutString("turn","null");
			FRC2017c.powerSys.motorChassisSafety();
			
			switch(robotLocation){
				case -1:
					System.Console.WriteLine("Initial Location set to LEFT");
					
					FRC2017c.driveSys.arcadeDrive(RobotMap.autonomousAutoGearStraightSpeed,0,RobotMap.drivingSquaredInput);
					System.Threading.Thread.Sleep(800);
					FRC2017c.driveSys.arcadeDrive(0,0,RobotMap.drivingSquaredInput);
					FRC2017c.operateSys.gearUp(-1);
					FRC2017c.powerSys.stallDetectionDelay(RobotMap.pdpMotorGearUp,RobotMap.stallMotorGearUp);
					System.Console.WriteLine("Stalled!");
					FRC2017c.operateSys.gearUp(0);
					FRC2017c.operateSys.gearUp(1);
					System.Threading.Thread.Sleep(566);
					FRC2017c.operateSys.gearUp(0);
					amazingAutoTurn(RobotMap.autonomousAutoGearAngle);
					//followThePi();
					//followThePi();
					break;
				case 0:
					System.Console.WriteLine("Initial Location set to CENTER");
					
					//FRC2017c.operateSys.gearUp(-1);
					//FRC2017c.powerSys.stallDetectionDelay(RobotMap.pdpMotorGearUp,RobotMap.stallMotorGearUp);
					//System.Console.WriteLine("Stalled!");
					//FRC2017c.operateSys.gearUp(0);
					//FRC2017c.operateSys.gearUp(1);
					FRC2017c.driveSys.arcadeDrive(RobotMap.autonomousAutoGearStraightSpeed,0,RobotMap.drivingSquaredInput);
					//System.Threading.Thread.Sleep(566);
					//FRC2017c.operateSys.gearUp(0);

					System.Threading.Thread.Sleep(1000);
					FRC2017c.driveSys.arcadeDrive(RobotMap.autonomousAutoGearStraightSpeed*0.7,0,RobotMap.drivingSquaredInput);
					System.Threading.Thread.Sleep(1000);
					FRC2017c.driveSys.arcadeDrive(0,0,RobotMap.drivingSquaredInput);
					FRC2017c.operateSys.gearUp(1);
					FRC2017c.powerSys.stallDetectionDelay(RobotMap.pdpMotorGearUp,RobotMap.stallMotorGearUp);
					System.Console.WriteLine("Stalled!");
					FRC2017c.operateSys.gearUp(-0.8);
					FRC2017c.driveSys.arcadeDrive(RobotMap.autonomousAutoGearStraightSpeed*0.64,0,RobotMap.drivingSquaredInput);
					System.Threading.Thread.Sleep(888);
					FRC2017c.operateSys.gearUp(0);
					System.Threading.Thread.Sleep(1000);
					FRC2017c.driveSys.arcadeDrive(0,0,RobotMap.drivingSquaredInput);
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
