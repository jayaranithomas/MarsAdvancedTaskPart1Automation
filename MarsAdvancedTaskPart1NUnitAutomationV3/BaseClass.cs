using MarsAdvancedTaskPart1NUnitAutomation.ReportClass;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation
{
    [SetUpFixture]
    public class BaseClass
    {
        public static GenerateReport? generateReport;

        [OneTimeSetUp]
        public static void ReportSetUp()
        {
            generateReport = new GenerateReport();
            generateReport?.GenerateExtentReport(@"Reports\ExtentReport.html");
        }
        [OneTimeTearDown]
        public static void ReportCleanUp()
        {
            generateReport?.ExtentReportsCleanup();
        }
    }
}
