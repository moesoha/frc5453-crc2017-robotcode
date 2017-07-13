using WPILib;
using WPILib.Buttons;

namespace FRC2017c{
	public class OI{
		// init Joysticks
		Joystick driving;
		Joystick operating;

		public OI(){
			driving=new Joystick(RobotMap.joystickDriving);
			operating=new Joystick(RobotMap.joystickOperating);
		}
		
		public double readAxis(int port,string which){
			switch(which){
				case "drive":
					return driving.GetRawAxis(port);
					break;
				case "operate":
					return operating.GetRawAxis(port);
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
				case "operate":
					return operating.GetRawButton(port);
					break;
				default:
					System.Console.WriteLine("no method for "+which);
					return false;
					break;
			}
		}
	}
}
