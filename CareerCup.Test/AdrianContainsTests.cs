using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerCup;

namespace CareerCup.Test
{
    [TestClass]
    public class AdrianContainsTests: ContainsTestBase
    {
        public AdrianContainsTests()
        {
            this.ContainsAlgorithm = new AdrianStringContains();

        }
    }
}
