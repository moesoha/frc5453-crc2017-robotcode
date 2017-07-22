using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPILib;
using WPILib.Commands;
using FRC2017c;

namespace FRC2017c.Commands{
	public class AutonomousCommand:Command{
		int robotLocation=0; /* | -1 | 0 | 1 | */
		NetworkTables.NetworkTable nt;

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

		private Task<bool> amazingAutoTurn(double dest,double lOr,double tolerance){
			return Task.Run(()=>{
				FRC2017c.gyroSys.reset();
				double angleInit=FRC2017c.gyroSys.getAngle();
				double speed=RobotMap.autonomousAutoGearTurningSpeed;
				double delta=(FRC2017c.gyroSys.getAngle()-angleInit);
				while(((System.Math.Abs(dest)-System.Math.Abs(delta))>tolerance) && (!IsTimedOut())){
					double FlOr=(((System.Math.Abs(dest)-System.Math.Abs(delta))>0)?1:-1)*lOr;
					FRC2017c.driveSys.drivingMotorsControlRaw("turn",RobotMap.autonomousAutoGearTurningSpeed*0.7*FlOr);
					delta=(FRC2017c.gyroSys.getAngle()-angleInit);
				}
				System.Console.WriteLine("turn ok!");
				FRC2017c.driveSys.resetMotors();
				return true;
			});
		}

		private void followThePi(){
			string turn;
			turn=nt.GetString("turn","null");
			while((turn!="great") && (!IsTimedOut())){
				if(turn!="null"){
					FRC2017c.driveSys.drivingMotorsControlRaw("turn",(RobotMap.autonomousAutoGearTurningSpeed*0.4)*((turn=="right") ? 1 : -1));
				}
				turn=nt.GetString("turn","null");
			}
		}

		protected override async void Execute(){
			nt=NetworkTables.NetworkTable.GetTable("Forgiving/Vision");
			nt.PutString("turn","null");
			nt.PutNumber("angle",0.0);

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
					await amazingAutoTurn(RobotMap.autonomousAutoGearAngle,1,2);
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
					//FRC2017c.driveSys.arcadeDrive(RobotMap.autonomousAutoGearStraightSpeed,0,RobotMap.drivingSquaredInput);
					//System.Threading.Thread.Sleep(566);
					//FRC2017c.operateSys.gearUp(0);

					//System.Threading.Thread.Sleep(1000);
					FRC2017c.driveSys.arcadeDrive(RobotMap.autonomousAutoGearStraightSpeed*0.7,0,RobotMap.drivingSquaredInput);
					System.Threading.Thread.Sleep(1000);
					FRC2017c.driveSys.arcadeDrive(0,0,RobotMap.drivingSquaredInput);
					FRC2017c.operateSys.gearUp(1);
					FRC2017c.powerSys.stallDetectionDelay(RobotMap.pdpMotorGearUp,RobotMap.stallMotorGearUp);
					System.Console.WriteLine("Stalled!");
					FRC2017c.operateSys.gearUp(-1);
					FRC2017c.driveSys.arcadeDrive(RobotMap.autonomousAutoGearStraightSpeed*0.64,0,RobotMap.drivingSquaredInput);
					System.Threading.Thread.Sleep(800);
					FRC2017c.operateSys.gearUp(0);
					System.Threading.Thread.Sleep(860);
					FRC2017c.driveSys.arcadeDrive(0,0,RobotMap.drivingSquaredInput);
					System.Threading.Thread.Sleep(300);
					FRC2017c.operateSys.gearUp(-1);
					System.Threading.Thread.Sleep(400);
					FRC2017c.operateSys.gearUp(0);
					FRC2017c.operateSys.gearIntake(-0.29);
					System.Threading.Thread.Sleep(6666);
					FRC2017c.operateSys.gearIntake(0);
					break;
				case 1:
					System.Console.WriteLine("Initial Location set to RIGHT");
					
					/*FRC2017c.driveSys.arcadeDrive(RobotMap.autonomousAutoGearStraightSpeed,0,RobotMap.drivingSquaredInput);
					System.Threading.Thread.Sleep(640);
					FRC2017c.driveSys.arcadeDrive(0,0,RobotMap.drivingSquaredInput);
					FRC2017c.operateSys.gearUp(-1);
					FRC2017c.powerSys.stallDetectionDelay(RobotMap.pdpMotorGearUp,RobotMap.stallMotorGearUp);
					System.Console.WriteLine("Stalled!");
					FRC2017c.operateSys.gearUp(0);
					FRC2017c.operateSys.gearUp(1);
					System.Threading.Thread.Sleep(566);
					FRC2017c.operateSys.gearUp(0);
					*/
					nt.PutString("turn","null");
					nt.PutNumber("angle",0.0);
					/*
					amazingAutoTurn(RobotMap.autonomousAutoGearAngle,-1);
					FRC2017c.driveSys.arcadeDrive(RobotMap.autonomousAutoGearStraightSpeed*0.7,0,RobotMap.drivingSquaredInput);
					System.Threading.Thread.Sleep(300);
					FRC2017c.driveSys.arcadeDrive(0,0,RobotMap.drivingSquaredInput);*/
					System.Threading.Thread.Sleep(1200);
					double angle=nt.GetNumber("angle",0.0);
					await amazingAutoTurn(System.Math.Abs(angle),0.66*((nt.GetString("turn","null")=="right") ? 1 : -1),2.4);
					System.Threading.Thread.Sleep(400);
					nt.PutString("turn","null");
					nt.PutNumber("angle",0.0);
					System.Threading.Thread.Sleep(800);
					angle=nt.GetNumber("angle",0.0);
					await amazingAutoTurn(System.Math.Abs(angle),0.58*((nt.GetString("turn","null")=="right") ? 1 : -1),1.6);

					/*amazingAutoTurn(System.Math.Abs(nt.GetNumber("angle",0.0)),0.6*((nt.GetString("turn","null")=="right") ? 1 : -1));
					System.Threading.Thread.Sleep(800);
					FRC2017c.driveSys.drivingMotorsControlRaw("turn",speed*FlOr);
					FRC2017c.operateSys.gearUp(1);
					FRC2017c.powerSys.stallDetectionDelay(RobotMap.pdpMotorGearUp,RobotMap.stallMotorGearUp);
					System.Console.WriteLine("Stalled!");
					FRC2017c.operateSys.gearUp(0);
					FRC2017c.operateSys.gearUp(-1);
					System.Threading.Thread.Sleep(600);
					FRC2017c.operateSys.gearUp(0);*/
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
