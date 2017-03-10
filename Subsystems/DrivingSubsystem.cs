using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPILib;
using WPILib.Commands;
using FRC2017c;
using FRC2017c.Commands;
using WPILib.Extras;

namespace FRC2017c.Subsystems{
	public class DrivingSubsystem:Subsystem{
		// init VictorSP
		VictorSP motorFrontLeft;
		VictorSP motorFrontRight;
		VictorSP motorRearLeft;
		VictorSP motorRearRight;
		// init RobotDrive
		RobotDrive drive;
		WPILib.Extras.NavX.AHRS ahrs;

		double angel;

		public void bindMotors(){
			motorFrontLeft=new VictorSP(RobotMap.motorFrontLeft);
			motorFrontRight=new VictorSP(RobotMap.motorFrontRight);
			motorRearLeft=new VictorSP(RobotMap.motorRearLeft);
			motorRearRight=new VictorSP(RobotMap.motorRearRight);
			drive=new RobotDrive(motorFrontLeft,motorRearLeft,motorFrontRight,motorRearRight);
			motorFrontLeft.SafetyEnabled=false;
			motorFrontRight.SafetyEnabled=false;
			motorRearLeft.SafetyEnabled=false;
			motorRearRight.SafetyEnabled=false;
			drive.SafetyEnabled=false;
		}

		public DrivingSubsystem(){
			ahrs=new WPILib.Extras.NavX.AHRS(SPI.Port.MXP);
			angel=ahrs.GetAngle();
			System.Console.WriteLine("Init driving subsystem.");
		}

		protected override void InitDefaultCommand(){
			SetDefaultCommand(new DrivingCommand());
			bindMotors();
		}

		public void resetMotors(){
			motorFrontLeft.StopMotor();
			motorFrontRight.StopMotor();
			motorRearLeft.StopMotor();
			motorRearRight.StopMotor();
			drive.StopMotor();
		}

		public void drivingMotorControlRaw(string where,double value){
			switch(where){
				case "left":
					motorFrontLeft.SetSpeed(value);
					motorRearLeft.SetSpeed(value);
					break;
				case "right":
					motorFrontRight.SetSpeed(value);
					motorRearRight.SetSpeed(value);
					break;
				case "turn":
					motorFrontLeft.SetSpeed(value);
					motorRearLeft.SetSpeed(value);
					motorFrontRight.SetSpeed(value);
					motorRearRight.SetSpeed(value);
					break;
				case "all":
					motorFrontLeft.SetSpeed(value);
					motorRearLeft.SetSpeed(value);
					motorFrontRight.SetSpeed(-value);
					motorRearRight.SetSpeed(-value);
					break;
				default:
					Console.WriteLine("no method for "+where);
					break;
			}
		}

		public void arcadeDrive(double x,double y,bool squared){
			drive.ArcadeDrive(y,x,squared);
		}

		public void turnToAngel(double targetAngel){
			double nowAngelAdj;
			double speed;
			while(System.Math.Abs(ahrs.GetAngleAdjustment()-targetAngel)>=5){
				speed=0.2;
				nowAngelAdj=ahrs.GetAngleAdjustment();
				if(System.Math.Abs(nowAngelAdj-targetAngel)>10){
					speed=0.6;
				}else if(System.Math.Abs(nowAngelAdj-targetAngel)>7){
					speed=0.4;
				}else{
					speed=0.2;
				}

				if(nowAngelAdj>targetAngel){
					drivingMotorControlRaw("turn",speed);
				}else{
					drivingMotorControlRaw("turn",-speed);
				}

				System.Threading.Thread.Sleep(10);
			}
			drivingMotorControlRaw("all",0);
		}
	}
}
