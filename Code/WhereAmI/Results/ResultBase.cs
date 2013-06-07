using System;
using Caliburn.Micro;

namespace WhereAmI.Results
{
    public abstract class ResultBase : IResult
    {
        public event EventHandler<ResultCompletionEventArgs> Completed = delegate { };

        protected virtual void OnCompleted()
        {
            OnCompleted(new ResultCompletionEventArgs());
        }

        protected virtual void OnError(Exception error)
        {
            OnCompleted(new ResultCompletionEventArgs
            {
                Error = error
            });
        }

        protected virtual void OnCancelled()
        {
            OnCompleted(new ResultCompletionEventArgs
            {
                WasCancelled = true
            });
        }

        protected virtual void OnCompleted(ResultCompletionEventArgs e)
        {
            Caliburn.Micro.Execute.OnUIThread(() => Completed(this, e));
        }

        public abstract void Execute(ActionExecutionContext context);
    }
}