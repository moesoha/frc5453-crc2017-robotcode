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

		public double getTemperature(){
			return pdp.GetTemperature();
		}

		public void liveWindowMode(bool switchOn){
			if(switchOn){
				pdp.StartLiveWindowMode();
			}else{
				pdp.StopLiveWindowMode();
			}
		}
	}
}
