using WPILib;
using WPILib.Buttons;

namespace FRC2017c{
	public class OI{
		// init Joysticks
		Joystick driving;
		Joystick operating;

		// init JoystickButtons
		JoystickButton operatingButtonGearUpUp;
		JoystickButton operatingButtonGearUpDown;
		JoystickButton operatingButtonGearIntakeIn;
		JoystickButton operatingButtonGearIntakeOut;

		public OI(){
			driving=new Joystick(RobotMap.joystickDriving);
			operating=new Joystick(RobotMap.joystickOperating);

			operatingButtonGearUpUp=new JoystickButton(operating,RobotMap.joystickOperatingGearUpUp);
			operatingButtonGearUpDown=new JoystickButton(operating,RobotMap.joystickOperatingGearUpDown);
			operatingButtonGearIntakeIn=new JoystickButton(operating,RobotMap.joystickOperatingGearIntakeIn);
			operatingButtonGearIntakeOut=new JoystickButton(operating,RobotMap.joystickOperatingGearIntakeOut);

			(new JoystickButton(driving,1)).ToggleWhenPressed(new Commands.DrivingStraightCommand(0.36));
			(new JoystickButton(driving,3)).ToggleWhenPressed(new Commands.DrivingStraightCommand(-0.36));


			operatingButtonGearUpUp.WhenPressed(new Commands.OperatingGearUpButtonCommand(1));
			operatingButtonGearUpUp.WhenReleased(new Commands.OperatingGearUpButtonCommand(0));
			operatingButtonGearUpDown.WhenPressed(new Commands.OperatingGearUpButtonCommand(-1));
			operatingButtonGearUpDown.WhenReleased(new Commands.OperatingGearUpButtonCommand(0));
			operatingButtonGearIntakeIn.WhenPressed(new Commands.OperatingGearIntakeCommand(1));
			operatingButtonGearIntakeIn.WhenReleased(new Commands.OperatingGearIntakeCommand(0));
			operatingButtonGearIntakeOut.WhenPressed(new Commands.OperatingGearIntakeCommand(-0.78));
			operatingButtonGearIntakeOut.WhenReleased(new Commands.OperatingGearIntakeCommand(0));
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
