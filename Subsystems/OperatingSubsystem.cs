using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPILib;
using WPILib.Commands;
using FRC2017c;
using FRC2017c.Commands;

namespace FRC2017c.Subsystems{
	public class OperatingSubsystem:Subsystem{
		// init VictorSP
		//VictorSP motorBallReady;
		//VictorSP motorBallShoot;
		VictorSP motorRobotClimbLeft;
		VictorSP motorRobotClimbRight;

		public void bindMotors(){
			//motorBallReady=new VictorSP(RobotMap.motorBallReady);
			//motorBallShoot=new VictorSP(RobotMap.motorBallShoot);
			motorRobotClimbLeft=new VictorSP(RobotMap.motorRobotClimbLeft);
			motorRobotClimbRight=new VictorSP(RobotMap.motorRobotClimbRight);
			//motorBallReady.SafetyEnabled=false;
			//motorBallShoot.SafetyEnabled=false;
			motorRobotClimbLeft.SafetyEnabled=false;
			motorRobotClimbRight.SafetyEnabled=false;
		}

		public OperatingSubsystem(){

		}

		protected override void InitDefaultCommand(){
			SetDefaultCommand(new OperatingCommand());
			System.Console.WriteLine("Init operating subsystem.");
			bindMotors();
		}

		public void resetMotors(){
			//motorBallShoot.StopMotor();
			//motorBallReady.StopMotor();
			motorRobotClimbLeft.StopMotor();
			motorRobotClimbRight.StopMotor();
		}
		/*
		public void readyBall(int clockwise,double value){
			if((value<=1.0) && (value>=-1.0)){
				motorBallReady.SetSpeed(value*clockwise);
			}else{
				Console.WriteLine("INVALID value: "+value.ToString());
			}
		}
		
		public void shootBall(double value){
			if((value<=1.0) && (value>=-1.0)){
				motorBallShoot.SetSpeed(-value);
			}else{
				Console.WriteLine("INVALID value: "+value.ToString());
			}
		}
		*/
		public void robotClimb(double value){
			if((value<=1.0) && (value>=-1.0)){
				motorRobotClimbLeft.SetSpeed(-value);
				motorRobotClimbRight.SetSpeed(-value);
			}else{
				Console.WriteLine("INVALID value: "+value.ToString());
			}
		}
	}
}
