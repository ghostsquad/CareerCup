namespace CareerCup.Test
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class WesContainsTests : ContainsTestBase
    {
        [TestInitialize]
        public void SetTheAlgorithm()
        {
            this.ContainsAlgorithm = new StringContains();
        }
    }
}
