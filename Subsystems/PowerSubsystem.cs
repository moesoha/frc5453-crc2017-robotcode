using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPILib;
using WPILib.Commands;
using FRC2017c;
using FRC2017c.Commands;

namespace FRC2017c.Subsystems{
	public class PowerSubsystem:Subsystem{
		PowerDistributionPanel pdp;

		public PowerSubsystem(){
			System.Console.WriteLine("Init power subsystem.");
		}

		protected override void InitDefaultCommand(){
			SetDefaultCommand(new PowerCommand());
			pdp=new PowerDistributionPanel();
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
		
		public double getTemperature(){
			return pdp.GetTemperature();
		}
		
		public double getTotalCurrent(){
			return pdp.GetTotalCurrent();
		}
		
		public void stallDetectionDelay(int pdpPort,double maxCurrent){
			while(this.getCurrent(pdpPort)<maxCurrent){
				continue;
			}
			return;
		}
	}
}
