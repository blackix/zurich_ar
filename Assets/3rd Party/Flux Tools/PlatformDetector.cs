using UnityEngine;
using UnityEngine.Events;

public class PlatformDetector : MonoBehaviour
{
    public UnityEvent OnPlatformAndroidDetected;
    public UnityEvent OnPlatformIphoneDetected;
    public UnityEvent OnPlatformIpadDetected;
    public UnityEvent OnPlatformPcDetected;

    void Start()
    {
        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXPlayer)
        {
#if UNITY_IOS

            bool deviceIsIphoneX = UnityEngine.iOS.Device.generation.ToString().Contains("iPhone");
            if (deviceIsIphoneX)
            {
                // Do something for iPhone X
                OnPlatformIphoneDetected.Invoke();
            }

            bool deviceIsIpad = UnityEngine.iOS.Device.generation.ToString().Contains("iPad");
            if (deviceIsIpad)
            {
                // Do something for iPad
                OnPlatformIpadDetected.Invoke();
            }

            /*doesnt work
            var identifier = SystemInfo.deviceModel;
            if (identifier.StartsWith("iPhone"))
            {
                // iPhone logic
                OnPlatformIphoneDetected.Invoke();
            }
            else if (identifier.StartsWith("iPad"))
            {
                // iPad logic
                OnPlatformIpadDetected.Invoke();
            }
            else
            {
                // Mac logic?
            }
            */
#endif            
        }

        if (Application.platform == RuntimePlatform.Android)
        {
            OnPlatformAndroidDetected.Invoke();
        }

        if (Application.platform == RuntimePlatform.WindowsPlayer ||
            Application.platform == RuntimePlatform.WindowsEditor )
        {
            OnPlatformPcDetected.Invoke();
        }
    }
}