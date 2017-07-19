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
		// init Spark
		Spark motorGearUp;
		Spark motorGearIntake;
		Spark motorClimb;
		bool tableInited=false;

		public void bindMotors(){
			motorClimb=new Spark(RobotMap.motorClimb);
			motorGearIntake=new Spark(RobotMap.motorGearIntake);
			motorGearUp=new Spark(RobotMap.motorGearUp);
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
			SetDefaultCommand(new OperatingCommand());
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
