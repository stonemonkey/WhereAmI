﻿using System;
using Caliburn.Micro;

namespace WhereAmI.Results
{
    public class OpenChildResult<TChild> : ResultBase, IResult
         where TChild : IScreen
    {
        private readonly Func<TChild> _locateChild;
        private Func<ActionExecutionContext, IConductor> _locateParent;

        private Action<TChild> _configureChildAction;

        public OpenChildResult()
        {
            _locateChild = IoC.Get<TChild>;
        }

        public OpenChildResult(TChild child)
        {
            _locateChild = () => child;
        }

        public OpenChildResult<TChild> In(IConductor parent)
        {
            _locateParent = ctx => parent;
            return this;
        }

        public OpenChildResult<TChild> In<TParent>()
        {
            _locateParent = ctx => (IConductor)IoC.Get<TParent>();
            return this;
        }

        public OpenChildResult<TChild> Configure(Action<TChild> action)
        {
            _configureChildAction = action;
            return this;
        }

        public override void Execute(ActionExecutionContext context)
        {
            var child = _locateChild();

            if (_configureChildAction != null)
                _configureChildAction(child);

            if (_locateParent == null)
                _locateParent = ctx => (IConductor)ctx.Target;

            var parent = _locateParent(context);

            parent.ActivateItem(child);

            //if (Completed != null)
            //    Completed(this, new ResultCompletionEventArgs());
        }

        //public event EventHandler<ResultCompletionEventArgs> Completed;
    }
}