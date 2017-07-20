﻿using WPILib;
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

			operatingButtonGearUpUp.WhileHeld(new Commands.OperatingGearUpButtonCommand(1));
			operatingButtonGearUpDown.WhileHeld(new Commands.OperatingGearUpButtonCommand(-1));
			operatingButtonGearIntakeIn.WhileHeld(new Commands.OperatingGearIntakeCommand(1));
			operatingButtonGearIntakeOut.WhileHeld(new Commands.OperatingGearIntakeCommand(-0.78));
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
