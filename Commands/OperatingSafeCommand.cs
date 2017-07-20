using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPILib;
using WPILib.Commands;

namespace FRC2017c.Commands{
	public class OperatingSafeCommand : Command{
		public OperatingSafeCommand(){
			//Requires(FRC2017c.operateSys);
		}
		
		protected override void Initialize(){
		}
		
		protected override void Execute(){
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
