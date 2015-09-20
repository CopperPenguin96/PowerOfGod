using System;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Popups;

namespace Power_of_God
{
    public class MsgBox
    {
        private readonly string _thisTitle;
        private readonly string _thisMessage;
        public MsgBox(string title, string message)
        {
            _thisTitle = title;
            _thisMessage = message;
        }
        public Task ShowDialog()
        {
            CoreDispatcher dispatcher = Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher;
            Func<object, Task<bool>> action = null;
            action = async o =>
            {
                try
                {
                    if (dispatcher.HasThreadAccess)
                        await new MessageDialog(_thisMessage, _thisTitle).ShowAsync();
                    else
                    {
                        await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => action(o));
                    }
                    return true;
                }
                catch (UnauthorizedAccessException)
                {
                    if (action != null)
                    {
                        await Task.Delay(500).ContinueWith(async t => await action(o));
                    }
                }
                return false;
            };
            return action(null);
        }
    }
}
