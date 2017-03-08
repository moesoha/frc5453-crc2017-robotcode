using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPILib;
using WPILib.Commands;

namespace FRC2017c.Commands{
	public class NavCommand:Command{
		public NavCommand(){
			Requires(FRC2017c.navSys);
		}

		protected override void Initialize(){

		}
		
		protected override void Execute(){
			FRC2017c.navSys.getBoardYawAxis();
		}

		protected override bool IsFinished(){
			return false;
		}
		
		protected override void End(){

		}

		protected override void Interrupted(){

		}
	}
}
