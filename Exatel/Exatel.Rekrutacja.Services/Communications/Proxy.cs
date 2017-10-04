using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exatel.Communications
{
    public class Proxy<Channel> : System.ServiceModel.ClientBase<Channel>, System.IDisposable where Channel : class
    {
        public Proxy()
        {
        }




        public Proxy(System.String endpointName) : base(endpointName)
        {
        }




        public void Invoke
        (
            System.Action<Channel> operation
        )
        {
            try
            {
                operation
                (
                    base.Channel
                );
            }
            catch (System.Exception exception)
            {
                OnErrorsChanged(exception);
            }
        }




        public Result Invoke<Result>
        (
            System.Func<Channel, Result> operation
        )
        {
            try
            {
                return operation
                (
                    base.Channel
                );
            }
            catch (System.Exception exception)
            {
                OnErrorsChanged(exception); return default(Result);
            }
        }




        public void Dispose()
        {
            try
            {
                if (this.Channel != null)
                {
                    if
                    (
                        State != System.ServiceModel.CommunicationState.Faulted
                    )
                    {
                        Close();
                    }
                    else
                    {
                        Abort();
                    }
                }
            }
            catch
            {
                Abort(); throw;
            }


            return;
        }




        private void OnErrorsChanged
        (
            System.Exception exception
        )
        {
        }
    }
}
