using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPILib;
using WPILib.Commands;

namespace FRC2017c.Commands{
	public class DrivingStraightCommand : Command{
		double test;

		public DrivingStraightCommand(double testt){
			test=testt;
		}

		protected override void Initialize(){
		}

		protected override void Execute(){
			FRC2017c.driveSys.arcadeDrive(test,0,RobotMap.drivingSquaredInput);
		}
		
		protected override bool IsFinished(){
			return false;
		}

		protected override void End(){
			
		}
		
		protected override void Interrupted(){
			End();
		}
	}
}
