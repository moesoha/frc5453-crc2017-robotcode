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
		bool tableInited=false;
		public bool busyGearIntake=false,busyGearUp=false;
		public bool holdGearIntake=false,holdGearUp=false;
		public double mdlGearIntake=0.0,mdlGearUp=0.0;

		public void bindMotors(){
			motorClimb=new VictorSP(RobotMap.motorClimb);
			motorGearIntake=new VictorSP(RobotMap.motorGearIntake);
			motorGearUp=new VictorSP(RobotMap.motorGearUp);
			motorClimb.SafetyEnabled=false;
			motorGearIntake.SafetyEnabled=false;
			motorGearUp.SafetyEnabled=false;
			initTables();
		}

		private void initTables(){
			if(!tableInited){
				motorClimb.InitTable(NetworkTables.NetworkTable.GetTable("Robot/Motor/Climb"));
				motorGearIntake.InitTable(NetworkTables.NetworkTable.GetTable("Robot/Motor/GearIntake"));
				motorGearUp.InitTable(NetworkTables.NetworkTable.GetTable("Robot/Motor/GearUp"));
				tableInited=true;
			}
		}

		public void updateTables(){
			motorClimb.UpdateTable();
			motorGearIntake.UpdateTable();
			motorGearUp.UpdateTable();
		}

		public OperatingSubsystem(){
			System.Console.WriteLine("Init operating subsystem.");
		}

		protected override void InitDefaultCommand(){
			SetDefaultCommand(new OperatingCommandGroup());
			System.Console.WriteLine("Init operating subsystem w/command.");
			bindMotors();
		}

		public void resetMotors(){
			motorGearUp.StopMotor();
			motorGearIntake.StopMotor();
			motorClimb.StopMotor();
		}
		
		public void gearUp(double a){
			motorGearUp.SetSpeed(1*a*RobotMap.gearUpSpeedConstant);
		}
		
		public void gearIntake(double a){
			motorGearIntake.SetSpeed(((a>0)?1:-1)*((System.Math.Abs(a)>1)?1:System.Math.Abs(a))*RobotMap.gearIntakeSpeedConstant);
		}

		public void climb(double a){
			motorClimb.SetSpeed(1*a*RobotMap.robotClimbSpeedConstant);
		}

		public double gearUpGetPosition(){
			return motorGearUp.GetPosition();
		}
	}
}
