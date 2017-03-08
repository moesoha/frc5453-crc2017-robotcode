using System;
using System.Collections.Generic;
using System.Linq;
using WPILib;
using WPILib.Commands;
using CSCore;
using WPILib.LiveWindow;
using WPILib.SmartDashboard;
using FRC2017c.Subsystems;
using FRC2017c.Commands;

namespace FRC2017c{
	public class FRC2017c:IterativeRobot{
		public static readonly DrivingSubsystem driveSys=new DrivingSubsystem();
		public static readonly OperatingSubsystem operateSys=new OperatingSubsystem();
		public static OI oi;
		Command autoCmd;
		SendableChooser chooser;
		// init usb camera and mjpegServer
		UsbCamera usbCamera;
		MjpegServer mjpegServer;

		public override void RobotInit(){
			Console.WriteLine("Hello, FRC2017!");
			Console.WriteLine("TrueMoe RobotCode 2017c");
			oi=new OI();
			autoCmd=new AutonomousCommand();
			chooser=new SendableChooser();
			chooser.AddDefault("Default Auto",new AutonomousCommand());
			SmartDashboard.PutData("Chooser",chooser);

			usbCamera=new UsbCamera("USB Camera 0",0);
			mjpegServer=new MjpegServer("USB Camera 0 Server",1181);
			mjpegServer.Source=usbCamera;
		}

		public override void DisabledPeriodic(){
			Scheduler.Instance.Run();
		}

		public override void AutonomousInit(){
			autoCmd=(Command)chooser.GetSelected();

			/*
            string autoSelected = SmartDashboard.GetString("Auto Selector", "Default");
            switch(autoSelected)
            {
            case "My Auto":
                autonomousCommand = new MyAutoCommand();
                break;
            case "Default Auto"
            default:
                autonomousCommand = new ExampleCommand();
                break;
            }
            */
			// schedule the autonomous command (example)
			if(autoCmd!=null)autoCmd.Start();
		}

		public override void AutonomousPeriodic(){
			Scheduler.Instance.Run();
		}

		public override void TeleopInit(){
			if(autoCmd!=null)autoCmd.Cancel();
		}
		
		public override void DisabledInit(){

		}

		public override void TeleopPeriodic(){
			Scheduler.Instance.Run();
		}

		public override void TestPeriodic(){
			LiveWindow.Run();
		}
	}
}
