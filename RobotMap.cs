using WPILib;

namespace FRC2017c{
	public class RobotMap{
		/*
			  - Motor Definition
			  ========FRONT========
			  Left23        Right01
			  ========REAR=========
		*/
		public static int motorFrontLeft=3;
		public static int motorRearLeft=2;
		public static int motorFrontRight=1;
		public static int motorRearRight=0;

		public static int motorGearUp=8;
		public static int motorGearIntake=9;
		public static int motorClimb=7;

		/* Driving Definition */
		public static bool drivingSquaredInput=true;

		/* Constant Definition */
		public static double[] drivingSpeedConstant=new double[]{0.6,-0.2,+0.4};
		public static double gearUpSpeedConstant=0.5;
		public static double gearIntakeSpeedConstant=0.7;
		public static double robotClimbSpeedConstant=0.2;

		/* Joystick Port Definition */
		public static int joystickDriving=0;
		public static int joystickOperating=1;
		/* Joystick Axis Binding Definition */
		public static int joystickDrivingLeverL=1;
		public static int joystickDrivingLeverR=3;
		public static int[] joystickDrivingSpeedControl=new int[]{0,7,5};
		public static int joystickOperatingGearUpUp=5;
		public static int joystickOperatingGearUpDown=7;
		public static int joystickOperatingGearIntakeIn=6;
		public static int joystickOperatingGearIntakeOut=8;

		/* Awesome Autonomous */
		public static double autonomousAutoGearAngel=28;
		public static double autonomousAutoGearSpeed=0.7;
	}
}
