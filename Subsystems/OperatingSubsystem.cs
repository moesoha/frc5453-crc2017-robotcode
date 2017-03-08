using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPILib;
using WPILib.Commands;

namespace FRC2017c.Subsystems{
	public class OperatingSubsystem:Subsystem{
		// init VictorSP
		VictorSP motorBallReady;
		VictorSP motorBallShoot;
		VictorSP motorRobotClimb;

		public OperatingSubsystem(){
			motorBallReady=new VictorSP(RobotMap.motorBallReady);
			motorBallShoot=new VictorSP(RobotMap.motorBallShoot);
			motorRobotClimb=new VictorSP(RobotMap.motorRobotClimb);
		}

		protected override void InitDefaultCommand(){
			// Set the default command for a subsystem here.
			//SetDefaultCommand(new MySpecialCommand());
		}

		public void resetMotors(){
			motorBallShoot.StopMotor();
			motorBallReady.StopMotor();
			motorRobotClimb.StopMotor();
		}

		public void readyBall(int clockwise,double value){
			if((value<=1.0) && (value>=-1.0)){
				motorBallReady.SetSpeed(value*clockwise);
			}else{
				Console.WriteLine("INVALID value: "+value.ToString());
			}
		}
		
		public void shootBall(double value){
			if((value<=1.0) && (value>=-1.0)){
				motorBallShoot.SetSpeed(value);
			}else{
				Console.WriteLine("INVALID value: "+value.ToString());
			}
		}

		public void robotClimb(double value){
			if((value<=1.0) && (value>=-1.0)){
				motorRobotClimb.SetSpeed(value);
			}else{
				Console.WriteLine("INVALID value: "+value.ToString());
			}
		}
	}
}
