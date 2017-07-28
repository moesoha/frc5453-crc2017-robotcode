using System;
using System.Collections.Generic;
using System.Linq;
using WPILib;
using WPILib.Commands;
using CSCore;
using FRC2017c.Subsystems;
using FRC2017c.Commands;

namespace FRC2017c{
	public class FRC2017c:IterativeRobot{
		public static readonly PowerSubsystem powerSys=new PowerSubsystem();
		public static readonly DrivingSubsystem driveSys=new DrivingSubsystem();
		public static readonly OperatingSubsystem operateSys=new OperatingSubsystem();
		public static readonly GyroSubsystem gyroSys=new GyroSubsystem();
		public static readonly CommunicationSubsystem commSys=new CommunicationSubsystem();
		public static OI oi;
		public static NetworkTables.NetworkTable nt;
		public string mode;
		Command autonomousCommand;
		WPILib.SmartDashboard.SendableChooser chooser;
		// CameraServices
		UsbCamera usbCamera;
		CameraServer camServer;

		public override void RobotInit(){
			System.Console.WriteLine("Hello, FRC2017!");
			System.Console.WriteLine("TrueMoe RobotCode 2017c");
			oi=new OI();
			FRC2017c.gyroSys.reset();
			chooser=new WPILib.SmartDashboard.SendableChooser();
			camServer=CameraServer.Instance;
			nt=NetworkTables.NetworkTable.GetTable("Forgiving/Vision");
			
			chooser.AddDefault("Center",new AutonomousCommand("center"));
			chooser.AddObject("turn Right",new AutonomousCommand("left"));
			chooser.AddObject("turn Left",new AutonomousCommand("right"));
			WPILib.SmartDashboard.SmartDashboard.PutData("Autonomous Mode",chooser);
			WPILib.SmartDashboard.SmartDashboard.PutString("Team","5453");
			WPILib.SmartDashboard.SmartDashboard.PutNumber("AutonomousRushing1Delay",900);
			FRC2017c.gyroSys.resetDisplacement();

			usbCamera=new UsbCamera("USB Camera 0",0);
			usbCamera.SetFPS(12);
			camServer.StartAutomaticCapture(usbCamera);
		}
		
		public override void DisabledInit(){
			mode="disabled";
		}

		public override void DisabledPeriodic(){
			Scheduler.Instance.Run();
			FRC2017c.commSys.updateAll();
		}

		public override void AutonomousInit(){
			autonomousCommand=(Command)chooser.GetSelected();
			autonomousCommand.Start();
		}

		public override void AutonomousPeriodic(){
			Scheduler.Instance.Run();
			FRC2017c.commSys.updateAll();
		}

		public override void TeleopInit(){
			FRC2017c.gyroSys.resetDisplacement();
		}

		public override void TeleopPeriodic(){
			Scheduler.Instance.Run();
			//System.Console.WriteLine(gyroSys.getDisplacement().ToString()+"    X: "+gyroSys.getDisplacementX().ToString()+"  Y: "+gyroSys.getDisplacementY().ToString()+"  Z:"+gyroSys.getDisplacementZ().ToString());
			FRC2017c.commSys.updateAll();
		}

		public override void TestPeriodic(){
			WPILib.LiveWindow.LiveWindow.Run();
			FRC2017c.commSys.updateAll();
		}
	}
}
