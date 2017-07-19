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
			WPILib.SmartDashboard.SmartDashboard.PutString("CV rtn 0",NetworkTables.NetworkTable.GetTable("Forgiving/Vision").GetString("turn","null"));
			WPILib.SmartDashboard.SmartDashboard.PutNumber("PDP Temperature",FRC2017c.powerSys.getTemperature());
			WPILib.SmartDashboard.SmartDashboard.PutNumber("PDP Total Current",FRC2017c.powerSys.getTotalCurrent());
			WPILib.SmartDashboard.SmartDashboard.PutNumber("Climb Motor 4",FRC2017c.powerSys.getCurrent(4));
			WPILib.SmartDashboard.SmartDashboard.PutNumber("Intake Motor 11",FRC2017c.powerSys.getCurrent(11));
			WPILib.SmartDashboard.SmartDashboard.PutNumber("Angle",FRC2017c.gyroSys.getAngle());
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
