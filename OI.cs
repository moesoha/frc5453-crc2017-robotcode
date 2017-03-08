using WPILib;
using WPILib.Buttons;

namespace FRC2017c{
	public class OI{
		// init Joysticks
		Joystick driving;

		public OI(){
			driving=new Joystick(RobotMap.joystickDriving);
		}
		
		public double readAxis(int port,string which){
			switch(which){
				case "drive":
					return driving.GetRawAxis(port);
					break;
				default:
					System.Console.WriteLine("no method for "+which);
					return 0.0;
					break;
			}
		}

		public bool readButton(int port,string which){
			switch(which){
				case "drive":
					return driving.GetRawButton(port);
					break;
				default:
					System.Console.WriteLine("no method for "+which);
					return false;
					break;
			}
		}
	}
}
