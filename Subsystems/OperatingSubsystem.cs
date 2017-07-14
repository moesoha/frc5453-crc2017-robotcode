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
		VictorSP motorGearUp;
		VictorSP motorGearIntake;
		VictorSP motorClimb;

		public void bindMotors(){
			motorClimb=new VictorSP(RobotMap.motorClimb);
			motorGearIntake=new VictorSP(RobotMap.motorGearIntake);
			motorGearUp=new VictorSP(RobotMap.motorGearUp);
			motorClimb.SafetyEnabled=false;
			motorGearIntake.SafetyEnabled=false;
			motorGearUp.SafetyEnabled=false;
		}

		public OperatingSubsystem(){
			System.Console.WriteLine("Init operating subsystem.");
		}

		protected override void InitDefaultCommand(){
			SetDefaultCommand(new OperatingCommand());
			System.Console.WriteLine("Init operating subsystem.");
			bindMotors();
		}

		public void resetMotors(){
			motorGearUp.StopMotor();
			motorGearIntake.StopMotor();
			motorClimb.StopMotor();
		}
		
		public void gearUp(int a){
			motorGearUp.SetSpeed(1*a*RobotMap.gearUpSpeedConstant);
		}
		
		public void gearIntake(int a){
			motorGearIntake.SetSpeed(1*a*RobotMap.gearIntakeSpeedConstant);
		}

		public void climb(double a){
			motorClimb.SetSpeed(1*a*RobotMap.robotClimbSpeedConstant);
		}

		public double gearUpGetPosition(){
			return motorGearUp.GetPosition();
		}
	}
}
