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
		// init Spark
		Spark motorFrontLeft;
		Spark motorFrontRight;
		Spark motorRearLeft;
		Spark motorRearRight;

		// init RobotDrive
		RobotDrive drive;

		public void bindMotors(){
			motorFrontLeft=new Spark(RobotMap.motorFrontLeft);
			motorFrontRight=new Spark(RobotMap.motorFrontRight);
			motorRearLeft=new Spark(RobotMap.motorRearLeft);
			motorRearRight=new Spark(RobotMap.motorRearRight);
			drive=new RobotDrive(motorFrontLeft,motorRearLeft,motorFrontRight,motorRearRight);
			motorFrontLeft.SafetyEnabled=false;
			motorFrontRight.SafetyEnabled=false;
			motorRearLeft.SafetyEnabled=false;
			motorRearRight.SafetyEnabled=false;
			drive.SafetyEnabled=false;
		}

		public DrivingSubsystem(){
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
					motorFrontLeft.SetSpeed(-value);
					motorRearLeft.SetSpeed(-value);
					motorFrontRight.SetSpeed(value);
					motorRearRight.SetSpeed(value);
					break;
				default:
					Console.WriteLine("no method for "+where);
					break;
			}
		}

		public void arcadeDrive(double x,double y,bool squared){
			drive.ArcadeDrive(y,x,squared);
		}

		public void tankDrive(double l,double r,bool squaredInputs){
			drive.TankDrive(l,r,squaredInputs);
		}
	}
}
