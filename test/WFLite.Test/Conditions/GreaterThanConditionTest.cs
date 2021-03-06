﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WFLite.Conditions;
using WFLite.Interfaces;
using WFLite.Variables;

namespace WFLite.Test.Conditions
{
    [TestClass]
    public class GreaterThanConditionTest
    {
        [TestMethod]
        public void Test___Method_Check___Greater()
        {
            var testee = new GreaterThanCondition()
            {
                Value1 = new AnyVariable() { Value = 20 },
                Value2 = new AnyVariable() { Value = 10 }
            };

            Assert.IsTrue(testee.Check());
        }

        [TestMethod]
        public void Test___Method_Check___Equals()
        {
            var testee = new GreaterThanCondition()
            {
                Value1 = new AnyVariable() { Value = 20 },
                Value2 = new AnyVariable() { Value = 20 }
            };

            Assert.IsFalse(testee.Check());
        }

        [TestMethod]
        public void Test___Method_Check___Less()
        {
            var testee = new GreaterThanCondition()
            {
                Value1 = new AnyVariable() { Value = 10 },
                Value2 = new AnyVariable() { Value = 20 }
            };

            Assert.IsFalse(testee.Check());
        }


        [TestMethod]
        public void Test___Method_Check___Greater___Generic()
        {
            var testee = new GreaterThanCondition<int>()
            {
                Value1 = new AnyVariable<int>() { Value = 20 },
                Value2 = new AnyVariable<int>() { Value = 10 }
            };

            Assert.IsTrue(testee.Check());
        }

        [TestMethod]
        public void Test___Method_Check___Equals___Generic()
        {
            var testee = new GreaterThanCondition<int>()
            {
                Value1 = new AnyVariable<int>() { Value = 20 },
                Value2 = new AnyVariable<int>() { Value = 20 }
            };

            Assert.IsFalse(testee.Check());
        }

        [TestMethod]
        public void Test___Method_Check___Less___Generic()
        {
            var testee = new GreaterThanCondition<int>()
            {
                Value1 = new AnyVariable<int>() { Value = 10 },
                Value2 = new AnyVariable<int>() { Value = 20 }
            };

            Assert.IsFalse(testee.Check());
        }
    }
}
