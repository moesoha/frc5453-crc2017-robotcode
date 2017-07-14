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
		VictorSP[] motor;

		// init RobotDrive
		RobotDrive drive;

		public void bindMotors(){
			motor=new VictorSP[]{
				new VictorSP(RobotMap.motorOnChassis[0]),
				new VictorSP(RobotMap.motorOnChassis[1]),
				new VictorSP(RobotMap.motorOnChassis[2]),
				new VictorSP(RobotMap.motorOnChassis[3])
			};

			drive=new RobotDrive(motor[0],motor[1],motor[2],motor[3]);
			for(int i=0;i<motor.Length;i++){
				motor[i].SafetyEnabled=false;
			}
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
			for(int i=0;i<motor.Length;i++){
				motor[i].StopMotor();
			}
			drive.StopMotor();
		}

		public void resetMotor(int serialNumber){
			motor[serialNumber].StopMotor();
		}

		public void drivingMotorsControlRaw(string where,double value){
			switch(where){
				case "left":
					motor[0].SetSpeed(value);
					motor[1].SetSpeed(value);
					break;
				case "right":
					motor[2].SetSpeed(value);
					motor[3].SetSpeed(value);
					break;
				case "turn":
					motor[0].SetSpeed(value);
					motor[1].SetSpeed(value);
					motor[2].SetSpeed(value);
					motor[3].SetSpeed(value);
					break;
				case "all":
					motor[0].SetSpeed(-value);
					motor[1].SetSpeed(-value);
					motor[2].SetSpeed(value);
					motor[3].SetSpeed(value);
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
