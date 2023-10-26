using UniRx;
using UniRx.Diagnostics;
using UnityEngine;

using Logger = UniRx.Diagnostics.Logger;

namespace Unit5
{
    public class LoggerSample:MonoBehaviour
    {
        private readonly Logger _logger = new Logger(nameof(LoggerSample));

        private void Start()
        {
            UniRx.Diagnostics.ObservableLogger.Listener.LogToUnityDebug();
            
            /*UniRx.Diagnostics.ObservableLogger.Listener
                .Where(x=>x.LogType==LogType.Error||x.LogType==LogType.Exception)
                .BatchFrame()*/
            

        }
        
       // private void 
    }
}