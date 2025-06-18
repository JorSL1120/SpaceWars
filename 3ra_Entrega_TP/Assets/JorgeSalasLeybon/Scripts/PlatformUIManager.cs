using System.Runtime.InteropServices;
using UnityEngine;

public class PlatformUIManager : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern int IsMobileDevice();

    public GameObject mobileUI;
    public GameObject desktopUI;

    void Start()
    {
#if UNITY_WEBGL && !UNITY_EDITOR
        bool isMobile = IsMobileDevice() == 1;
#else
        bool isMobile = Application.isMobilePlatform;
#endif

        mobileUI.SetActive(isMobile);
        desktopUI.SetActive(!isMobile);
    }
}
