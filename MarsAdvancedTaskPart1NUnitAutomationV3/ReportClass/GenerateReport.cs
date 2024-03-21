using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MarsAdvancedTaskPart1NUnitAutomation.Utilities;

namespace MarsAdvancedTaskPart1NUnitAutomation.ReportClass
{
    public class GenerateReport : CommonDriver
    {

        public ExtentReports? extent;
        public ExtentTest? test;
        public ScreenShotCapture? screenShotCapture;

        public void CreateTest()
        {
            test = extent?.CreateTest(TestContext.CurrentContext.Test.Name);
        }
        public void GenerateExtentReport(string localPath)
        {
            var path = Assembly.GetCallingAssembly().Location;
            var actualPath = path.Substring(0, path.LastIndexOf("bin"));
            var projectPath = new Uri(actualPath).LocalPath;
            Directory.CreateDirectory(projectPath.ToString() + "Reports");
            var reportPath = projectPath + localPath;
            var htmlReporter = new ExtentSparkReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "LocalHost");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("UserName", "MarsTester");
        }

        public void UpdateTest()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            screenShotCapture = new ScreenShotCapture();
            string stacktrace = string.Empty;

            if (string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace))
            {
                stacktrace = "";
            }
            else
            {
                stacktrace = string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            }
            Status logstatus;

            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    DateTime time = DateTime.Now;
                    String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
                    String screenShotPath = screenShotCapture.Capture(driver, fileName);
                    test?.Log(Status.Fail, "Fail");
                    test?.Log(Status.Fail, "Snapshot below: " + test.AddScreenCaptureFromPath(@"Screenshots\\" + fileName));
                    break;
                default:
                    logstatus = Status.Pass;
                    time = DateTime.Now;
                    fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";
                    screenShotPath = screenShotCapture.Capture(driver, fileName);
                    test?.Log(Status.Pass, "Pass");
                    test?.Log(Status.Pass, "Snapshot below: " + test.AddScreenCaptureFromPath(@"Screenshots\\" + fileName));

                    break;
            }
            test?.Log(logstatus, "Test ended with " + logstatus + stacktrace);
           // extent?.Flush();
        }
        public void ExtentReportsCleanup()
        {
            extent?.Flush();
        }

    }
}
