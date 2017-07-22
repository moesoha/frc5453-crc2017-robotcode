using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPILib;
using WPILib.Commands;
using FRC2017c;
using FRC2017c.Commands;
using NetworkTables;
using WPILib.SmartDashboard;

namespace FRC2017c.Subsystems{
	public class CommunicationSubsystem:Subsystem{

		public CommunicationSubsystem(){
			System.Console.WriteLine("Init communication subsystem.");
		}

		protected override void InitDefaultCommand(){
			
		}

		public void updatePDP(){
			FRC2017c.powerSys.updateTable();
		}

		public void updateAHRS(){
			FRC2017c.gyroSys.updateTable();
		}

		public void updateMotors(){
			FRC2017c.driveSys.updateTables();
			FRC2017c.operateSys.updateTables();
		}

		public void updateSmartDashboard(){
			WPILib.SmartDashboard.SmartDashboard.PutString("CV turn",NetworkTables.NetworkTable.GetTable("Forgiving/Vision").GetString("turn","null"));
			WPILib.SmartDashboard.SmartDashboard.PutNumber("CV angle",NetworkTables.NetworkTable.GetTable("Forgiving/Vision").GetNumber("angle",0.0));
			WPILib.SmartDashboard.SmartDashboard.PutNumber("CV area0",NetworkTables.NetworkTable.GetTable("Forgiving/Vision").GetNumber("area0",0.0));
			WPILib.SmartDashboard.SmartDashboard.PutNumber("CV area1",NetworkTables.NetworkTable.GetTable("Forgiving/Vision").GetNumber("area1",0.0));
			WPILib.SmartDashboard.SmartDashboard.PutNumber("PDP Temperature",FRC2017c.powerSys.getTemperature());
			WPILib.SmartDashboard.SmartDashboard.PutNumber("PDP Total Current",FRC2017c.powerSys.getTotalCurrent());
			WPILib.SmartDashboard.SmartDashboard.PutNumber("Climb Motor 4",FRC2017c.powerSys.getCurrent(4));
			WPILib.SmartDashboard.SmartDashboard.PutNumber("Intake Motor 11",FRC2017c.powerSys.getCurrent(11));
			WPILib.SmartDashboard.SmartDashboard.PutNumber("Heading",FRC2017c.gyroSys.getHeading());
			for(int i=0;i<4;i++){
				WPILib.SmartDashboard.SmartDashboard.PutNumber("Chassis Motor Group "+i.ToString(),FRC2017c.powerSys.getCurrent(RobotMap.pdpMotorOnChassis[i]));
			}
		}

		public void updateAll(){
			updateAHRS();
			updatePDP();
			updateMotors();
			updateSmartDashboard();
		}
	}
}
