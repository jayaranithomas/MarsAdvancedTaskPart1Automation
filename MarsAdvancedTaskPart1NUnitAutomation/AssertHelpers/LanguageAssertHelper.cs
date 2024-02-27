using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsAdvancedTaskPart1NUnitAutomation.AssertHelpers
{
    
    public class LanguageAssertHelper
    {
        public void assertDeleteAllLanguageRecords(String expected, String actual)
        {

            Assert.That(actual.Equals(expected), "The language record has not been deleted successfully");

        }
        public void assertAddNewLanguage(String expected, String actual)
        {

            Assert.That(actual.Equals(expected), "The language record has not been added successfully");

        }
        public void assertAddNewLanguageRecordWithAllNullData(String expected, String actual)
        {

            Assert.That(actual.Equals(expected), "The language record has not been added successfully");

        }
        public void assertAddNewLanguageRecordWithLevelNotSelected(String expected, String actual)
        {

            Assert.That(actual.Equals(expected), "The language record has not been added successfully");

        }
        public void assertAddNewLanguageRecordWithValidLevelAndEmptyTextBox(String expected, String actual)
        {

            Assert.That(actual.Equals(expected), "The language record has not been added successfully");

        }
        public void assertAddAlreadyExistingLanguageRecord(String expected, String actual)
        {

            Assert.That(actual.Equals(expected), "The language record has been added successfully");

        }
    }
}
