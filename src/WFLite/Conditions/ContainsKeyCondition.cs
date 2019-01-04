﻿/*
 * ContainsKeyCondition.cs
 *
 * Copyright (c) 2019 Tomoharu Araki
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System;
using System.Collections.Generic;
using WFLite.Bases;
using WFLite.Interfaces;

namespace WFLite.Conditions
{
    public class ContainsKeyCondition : Condition
    {
        public IVariable Dictionary
        {
            private get;
            set;
        }

        public IVariable Key
        {
            private get;
            set;
        }

        protected override bool check()
        {
            var dictionary = Dictionary.GetValue() as IDictionary<string, object>;

            return dictionary.ContainsKey(Convert.ToString(Key.GetValue()));
        }
    }
}
