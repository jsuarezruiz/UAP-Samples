namespace CalculatorAppService
{
    using System;
    using Windows.Foundation.Collections;
    using Windows.ApplicationModel.Background;
    using Windows.ApplicationModel.AppService;

    public sealed class CalculatorTask : IBackgroundTask
    {
        private BackgroundTaskDeferral _serviceDeferral;
        private AppServiceConnection _connection;

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            _serviceDeferral = taskInstance.GetDeferral();

            taskInstance.Canceled += OnTaskCanceled;

            var details = taskInstance.TriggerDetails as AppServiceTriggerDetails;
            if (details != null) _connection = details.AppServiceConnection;

            _connection.RequestReceived += OnRequestReceived;
        }

        private void OnTaskCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
        {
            if (_serviceDeferral != null)
            {
                _serviceDeferral.Complete();
                _serviceDeferral = null;
            }
        }

        private async void OnRequestReceived(AppServiceConnection sender, AppServiceRequestReceivedEventArgs args)
        {
            var messageDeferral = args.GetDeferral();

            try
            {
                var input = args.Request.Message;
                int value1 = (int)input["value1"];
                int value2 = (int)input["value2"];
                string operation = input["operation"].ToString();

                var result = new ValueSet();
                switch (operation)
                {
                        case "Add":
                        result.Add("result", Calculator.Add(value1, value2));
                        break;
                        case "Substract":
                        result.Add("result", Calculator.Subtract(value1, value2));
                        break;
                        case "Multiply":
                        result.Add("result", Calculator.Multiply(value1, value2));
                        break;
                }

                await args.Request.SendResponseAsync(result);
            }
            finally
            {
                messageDeferral.Complete();
            }
        }
    }
}
