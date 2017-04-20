using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SumControlVeryfication;

namespace SumControlTests
{
    [TestFixture]
    public class VerificationTest
    {
        const string path = @"C:\Repository\verificationSumControl\file.xml";

        [Test]
        public void ShouldCalculateSumControl()
        {
            var result = SumControl.Process(path);
            Assert.AreEqual(1, result);
        }
    }
}
