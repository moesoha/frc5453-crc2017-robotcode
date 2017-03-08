using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WPILib;
using WPILib.Commands;
using WPILib.Extras.NavX;

namespace FRC2017c.Subsystems{
	public class NavSubsystem:Subsystem{
		AHRS.BoardYawAxis ahrsBoardYawAxis;
		AHRS.BoardAxis ahrsAxes;
		Array axes;
		double x,y,z;

		protected override void InitDefaultCommand(){
			
		}

		public void getBoardYawAxis(){
			ahrsBoardYawAxis=new AHRS.BoardYawAxis();
			ahrsAxes=ahrsBoardYawAxis.BoardAxis;
			x=(double)AHRS.BoardAxis.KBoardAxisX;
			y=(double)AHRS.BoardAxis.KBoardAxisY;
			z=(double)AHRS.BoardAxis.KBoardAxisZ;
			
			System.Console.WriteLine(x+" "+y+" "+z);
		}
	}
}
