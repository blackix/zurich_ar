using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UiController : MonoBehaviour
{
    /// <summary>
    /// screen to start with
    /// </summary>
    public string FirstRunScreenTitle;

    /// <summary>
    /// one shared common ui layer for all screens
    /// </summary>
    public Transform CommonUiLayer;

    /// <summary>
    /// all the screens
    /// </summary>
    public List<ApplicationScreen> Screens;

    private string _currentScreenTitle;

    private string _lastScreenTitle;

    void Start()
    {
        _currentScreenTitle = "";
        _lastScreenTitle = "";

        //make sure all are deactivated
        foreach (ApplicationScreen app in Screens)
        {
            app.SetActive(false);
        }

        //start Home at beginning
        if (FirstRunScreenTitle != "")
        {
            Switch(FirstRunScreenTitle);
        }
    }

    public void Switch(string title)
    {
        if (_currentScreenTitle == title) return;

        //deactivate old slide
        ApplicationScreen appPrev = GetApplicationScreen(_currentScreenTitle);
        if (appPrev != null)
        {
            appPrev.SetActive(false);
           
            if (CommonUiLayer != null)
                CommonUiLayer.gameObject.SetActive(false);

            _lastScreenTitle = _currentScreenTitle;
        }
        
        //bring new screen
        _currentScreenTitle = title;
        ApplicationScreen app = GetApplicationScreen(_currentScreenTitle);
        if (app != null)
        {
            app.SetActive(true);
            if (app.HasCommonUI && CommonUiLayer != null)
                CommonUiLayer.gameObject.SetActive(true);
        }
    }

    /// <summary>
    /// switch back to last screen. used after a screenshot
    /// </summary>
    public void SwitchToLastScreen()
    {
        Switch(_lastScreenTitle);
    }

    /// <summary>
    /// returns screen by the title
    /// </summary>
    /// <param name="title"></param>
    /// <returns></returns>
    private ApplicationScreen GetApplicationScreen(string title)
    {
        foreach(ApplicationScreen app in Screens)
        {
            if (app.ScreenTitle == title)
            {
                return app;
            }
        }
        return null;
    }
}

[System.Serializable]
public class ApplicationScreen
{
    public string ScreenTitle;
    //public ApplicationPhase AppPhase;
    public Transform[] ScreenUis;
    public bool HasCommonUI;
    public UnityEvent ScreenStarted;

    public void SetActive(bool activate)
    {
        foreach (Transform t in ScreenUis)
        {
            t.gameObject.SetActive(activate);
        }

        if (activate) ScreenStarted.Invoke();
    }
}