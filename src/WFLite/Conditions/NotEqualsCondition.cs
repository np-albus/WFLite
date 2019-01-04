﻿/*
 * NotEqualsCondition.cs
 *
 * Copyright (c) 2019 Tomoharu Araki
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using WFLite.Bases;
using WFLite.Interfaces;

namespace WFLite.Conditions
{
    public class NotEqualsCondition : Condition
    {
        public IVariable Value1
        {
            private get;
            set;
        }

        public IVariable Value2
        {
            private get;
            set;
        }

        protected override bool check()
        {
            return !Value1.GetValue().Equals(Value2.GetValue());
        }
    }
}
