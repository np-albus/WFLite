﻿/*
 * WhileActivity.cs
 *
 * Copyright (c) 2019 Tomoharu Araki
 *
 * This software is released under the MIT License.
 * http://opensource.org/licenses/mit-license.php
 */

using System.Threading.Tasks;
using WFLite.Bases;
using WFLite.Enums;
using WFLite.Extensions;
using WFLite.Interfaces;

namespace WFLite.Activities
{
    public class WhileActivity : Activity
    {
        private IActivity _current;

        public ICondition Condition
        {
            private get;
            set;
        }

        public IActivity Activity
        {
            private get;
            set;
        }

        protected override void initialize()
        {
        }

        protected override async Task start()
        {
            if (!Condition.Check())
            {
                Status = ActivityStatus.Completed;

                return;
            }

            _current = Activity;

            while (Condition.Check())
            {
                _current.Reset();

                var task = _current.Start();
                
                Status = _current.Status;

                await task;

                if (_current.Status.IsStopped())
                {
                    break;
                }
            }

            Status = _current.Status;
        }

        protected override void stop()
        {
            if (_current != null)
            {
                _current.Stop();

                Status = _current.Status;
            }
            else
            {
                Status = ActivityStatus.Stopped;
            }
        }

        protected override void reset()
        {
            if (_current != null)
            {
                _current.Reset();
                _current = null;
            }

            Status = Activity.Status;
        }
    }
}
