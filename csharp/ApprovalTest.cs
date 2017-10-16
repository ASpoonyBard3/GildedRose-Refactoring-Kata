﻿using ApprovalTests;
using ApprovalTests.Reporters;
using NUnit; 
using System;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace csharp
{
    [TestFixture]
    [UseReporter()]
    public class ApprovalTest
    {
        [Test]
        public void ThirtyDays()
        {
            StringBuilder fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Console.SetIn(new StringReader("a\n"));

            Program.Main(new string[] { });
            var output = fakeoutput.ToString();
            Approvals.Verify(output);
        }
    }
}
