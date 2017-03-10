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
		SendableChooser chooser;
		// init usb camera and mjpegServer
		UsbCamera usbCamera;
		MjpegServer mjpegServer;

		public override void RobotInit(){
			System.Console.WriteLine("Hello, FRC2017!");
			System.Console.WriteLine("TrueMoe RobotCode 2017c");
			oi=new OI();
			chooser=new SendableChooser();
			

			usbCamera=new UsbCamera("USB Camera 0",0);
			mjpegServer=new MjpegServer("USB Camera 0 Server",1181);
			mjpegServer.Source=usbCamera;
		}

		public override void DisabledPeriodic(){
			Scheduler.Instance.Run();
		}

		public override void AutonomousInit(){
			if(false){

			}else{
				driveSys.arcadeDrive(0,-1,RobotMap.drivingSquaredInput);
				System.Threading.Thread.Sleep(2000);
				driveSys.arcadeDrive(0,1,RobotMap.drivingSquaredInput);
				System.Threading.Thread.Sleep(2000);
				driveSys.arcadeDrive(0,0,RobotMap.drivingSquaredInput);
				System.Threading.Thread.Sleep(20);
				
			}
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
			LiveWindow.Run();
		}
	}
}
