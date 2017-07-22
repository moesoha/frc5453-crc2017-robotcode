using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPILib;
using WPILib.Commands;
using FRC2017c;
using FRC2017c.Commands;

namespace FRC2017c.Subsystems{
	public class PowerSubsystem:Subsystem{
		PowerDistributionPanel pdp;
		bool tableInited=false;

		public PowerSubsystem(){
			System.Console.WriteLine("Init power subsystem.");
			pdp=new PowerDistributionPanel();
		}

		private void initTable(){
			if(!tableInited){
				pdp.InitTable(NetworkTables.NetworkTable.GetTable("Robot/PDP"));
				tableInited=true;
			}
		}

		protected override void InitDefaultCommand(){
		}

		public void updateTable(){
			initTable();
			pdp.UpdateTable();
		}

		public double getCurrent(int channel){
			return pdp.GetCurrent(channel);
		}

		public void motorChassisSafety(){
			for(int i=0;i<RobotMap.pdpMotorOnChassis.Length;i++){
				if(this.getCurrent(RobotMap.pdpMotorOnChassis[i])>RobotMap.pdpMotorOnChassisCriticalCurrent){
					FRC2017c.driveSys.resetMotor(i);
				}
			}
		}
		
		public void motorClimbSafety(){
			if(this.getCurrent(RobotMap.pdpMotorClimb)>RobotMap.stallMotorClimb){
				FRC2017c.operateSys.climb(0);
			}
		}
		
		public double getTemperature(){
			return pdp.GetTemperature();
		}
		
		public double getTotalCurrent(){
			return pdp.GetTotalCurrent();
		}
		
		public Task<bool> stallDetectionDelay(int pdpPort,double maxCurrent){
			return Task.Run(()=>{
				while(this.getCurrent(pdpPort)<maxCurrent){
					continue;
				}
				return true;
			});
		}
	}
}
