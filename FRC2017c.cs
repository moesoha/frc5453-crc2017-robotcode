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
		public static readonly DrivingSubsystem driveSys=new DrivingSubsystem();
		public static readonly OperatingSubsystem operateSys=new OperatingSubsystem();
		public static readonly PowerSubsystem powerSys=new PowerSubsystem();
		public static OI oi;
		Command autonomousCommand;
		WPILib.SmartDashboard.SendableChooser chooser;
		// init usb camera and mjpegServer and CameraServer
		UsbCamera usbCamera;
		MjpegServer mjpegServer;
		CameraServer camServer;

		public override void RobotInit(){
			System.Console.WriteLine("Hello, FRC2017!");
			System.Console.WriteLine("TrueMoe RobotCode 2017c");
			oi=new OI();
			chooser=new WPILib.SmartDashboard.SendableChooser();
			camServer=CameraServer.Instance;
			
			chooser.AddDefault("Center",new AutonomousCommand("center"));
			chooser.AddObject("Left",new AutonomousCommand("left"));
			chooser.AddObject("Right",new AutonomousCommand("right"));
			WPILib.SmartDashboard.SmartDashboard.PutData("Autonomous Mode",chooser);
			WPILib.SmartDashboard.SmartDashboard.PutString("Team","5453");

			usbCamera=new UsbCamera("USB Camera 0",0);
			usbCamera.SetVideoMode(CSCore.PixelFormat.Mjpeg,640,480,12);
			mjpegServer=new MjpegServer("USB Camera 0 Server",1181);
			mjpegServer.Source=usbCamera;
			camServer.AddCamera(usbCamera);
		}

		public override void DisabledPeriodic(){
			Scheduler.Instance.Run();
		}

		public override void AutonomousInit(){
			autonomousCommand=(Command)chooser.GetSelected();
			autonomousCommand.Start();
		}

		public override void AutonomousPeriodic(){
			Scheduler.Instance.Run();
		}

		public override void TeleopInit(){
			
		}
		
		public override void DisabledInit(){

		}

		public override void TeleopPeriodic(){
			Scheduler.Instance.Run();
		}

		public override void TestPeriodic(){
			WPILib.LiveWindow.LiveWindow.Run();
		}
	}
}
