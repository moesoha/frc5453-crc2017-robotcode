using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPILib;
using WPILib.Commands;
using FRC2017c;
using FRC2017c.Commands;

namespace FRC2017c.Subsystems{
	public class DrivingSubsystem:Subsystem{
		// init VictorSP
		VictorSP motorFrontLeft;
		VictorSP motorFrontRight;
		VictorSP motorRearLeft;
		VictorSP motorRearRight;
		// init RobotDrive
		RobotDrive drive;

		public DrivingSubsystem(){
			System.Console.WriteLine("Init driving subsystem.");
		}

		protected override void InitDefaultCommand(){
			SetDefaultCommand(new DrivingCommand());
			motorFrontLeft=new VictorSP(RobotMap.motorFrontLeft);
			motorFrontRight=new VictorSP(RobotMap.motorFrontRight);
			motorRearLeft=new VictorSP(RobotMap.motorRearLeft);
			motorRearRight=new VictorSP(RobotMap.motorRearRight);

			drive=new RobotDrive(motorFrontLeft,motorRearLeft,motorFrontRight,motorRearRight);
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
				default:
					Console.WriteLine("no method for "+where);
					break;
			}
		}

		public void arcadeDrive(double x,double y,bool squared){
			drive.ArcadeDrive(y,x,squared);
		}
	}
}
