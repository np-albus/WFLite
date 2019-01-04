﻿/*
 * TrueCondition.cs
 *
 * Copyright (c) 2019 Tomoharu Araki
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System;
using WFLite.Bases;
using WFLite.Interfaces;
using WFLite.Variables;

namespace WFLite.Conditions
{
    public class TrueCondition : Condition
    {
        public IVariable Value
        {
            private get;
            set;
        }

        public TrueCondition()
        {
            if (Value == null)
            {
                Value = new AnyVariable() { Value = true };
            }
        }

        protected override bool check()
        {
            return Convert.ToBoolean(Value.GetValue());
        }
    }
}
