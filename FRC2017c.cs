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
		// init usb camera and mjpegServer and CameraServer
		UsbCamera usbCamera;
		MjpegServer mjpegServer;
		CameraServer camServer;

		public override void RobotInit(){
			System.Console.WriteLine("Hello, FRC2017!");
			System.Console.WriteLine("TrueMoe RobotCode 2017c");
			oi=new OI();
			chooser=new SendableChooser();

			usbCamera=new UsbCamera("USB Camera 0",0);
			//usbCamera.SetVideoMode(CSCore.PixelFormat.Mjpeg,320,240,15);
			mjpegServer=new MjpegServer("USB Camera 0 Server",1181);
			mjpegServer.Source=usbCamera;
			camServer=CameraServer.Instance;
			camServer.AddCamera(usbCamera);
		}

		public override void DisabledPeriodic(){
			Scheduler.Instance.Run();
		}

		public override void AutonomousInit(){
			/*
			 | 1 | 0 | 2 |
			 | 3 |   | 3 |
			 TEST=4
			 */
			const int mode=1;

			switch(mode){
				case 0:
					driveSys.arcadeDrive(0,-1,RobotMap.drivingSquaredInput);
					System.Threading.Thread.Sleep(750);
					driveSys.arcadeDrive(0,0,RobotMap.drivingSquaredInput);
					System.Threading.Thread.Sleep(20);
					break;
				case 1:
					driveSys.arcadeDrive(0,-1,RobotMap.drivingSquaredInput);
					System.Threading.Thread.Sleep(2000);
					driveSys.arcadeDrive(0,0,RobotMap.drivingSquaredInput);
					System.Threading.Thread.Sleep(20);
					driveSys.arcadeDrive(0,1,RobotMap.drivingSquaredInput);
					System.Threading.Thread.Sleep(2000);
					driveSys.arcadeDrive(0,0,RobotMap.drivingSquaredInput);
					System.Threading.Thread.Sleep(20);
					//driveSys.drivingMotorControlRaw("all",RobotMap.autonomousAutoGearSpeed);
					System.Threading.Thread.Sleep(400);
					driveSys.drivingMotorControlRaw("all",0);
					driveSys.turnToAngel(RobotMap.autonomousAutoGearAngel);
					System.Threading.Thread.Sleep(1500);
					driveSys.arcadeDrive(0,-1,RobotMap.drivingSquaredInput);
					System.Threading.Thread.Sleep(700);
					driveSys.drivingMotorControlRaw("all",0);
					System.Threading.Thread.Sleep(600);
					System.Threading.Thread.Sleep(1500);
					break;
				case 2:
					driveSys.drivingMotorControlRaw("all",RobotMap.autonomousAutoGearSpeed);
					System.Threading.Thread.Sleep(400);
					driveSys.drivingMotorControlRaw("all",0);
					driveSys.turnToAngel(-RobotMap.autonomousAutoGearAngel);
					driveSys.arcadeDrive(0,-1,RobotMap.drivingSquaredInput);
					System.Threading.Thread.Sleep(700);
					driveSys.drivingMotorControlRaw("all",0);
					System.Threading.Thread.Sleep(2500);
					driveSys.arcadeDrive(0,1,RobotMap.drivingSquaredInput);
					System.Threading.Thread.Sleep(600);
					driveSys.turnToAngel(0);
					driveSys.arcadeDrive(0,-1,RobotMap.drivingSquaredInput);
					System.Threading.Thread.Sleep(1200);
					driveSys.arcadeDrive(0,0,RobotMap.drivingSquaredInput);
					System.Threading.Thread.Sleep(20);
					break;
				case 3:
					driveSys.arcadeDrive(0,-1,RobotMap.drivingSquaredInput);
					System.Threading.Thread.Sleep(2000);
					driveSys.arcadeDrive(0,0,RobotMap.drivingSquaredInput);
					System.Threading.Thread.Sleep(20);
					break;
				case 4:
					driveSys.arcadeDrive(0,-1,RobotMap.drivingSquaredInput);
					System.Threading.Thread.Sleep(400);
					driveSys.arcadeDrive(0,0,RobotMap.drivingSquaredInput);
					System.Threading.Thread.Sleep(200);
					driveSys.arcadeDrive(0,-1,RobotMap.drivingSquaredInput);
					System.Threading.Thread.Sleep(400);
					driveSys.arcadeDrive(0,0,RobotMap.drivingSquaredInput);
					System.Threading.Thread.Sleep(200);
					driveSys.arcadeDrive(0,-1,RobotMap.drivingSquaredInput);
					System.Threading.Thread.Sleep(800);
					driveSys.arcadeDrive(0,0,RobotMap.drivingSquaredInput);
					System.Threading.Thread.Sleep(200);
					driveSys.arcadeDrive(0,-1,RobotMap.drivingSquaredInput);
					System.Threading.Thread.Sleep(400);
					driveSys.arcadeDrive(0,0,RobotMap.drivingSquaredInput);
					System.Threading.Thread.Sleep(200);
					break;
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
