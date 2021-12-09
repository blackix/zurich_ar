using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchContentSimple : MonoBehaviour
{
    public Transform VecchioObject;
    public Transform NuovoObject;

    public enum ActiveScene
    {
        NUOVO,
        VECCHIO
    }
    private ActiveScene activeScene;

    void Start()
    {
        SetOldScene();
    }

    public void SetNewScene()
    {
        if (activeScene == ActiveScene.NUOVO) return;

        activeScene = ActiveScene.NUOVO;

        NuovoObject.gameObject.SetActive(true);
        VecchioObject.gameObject.SetActive(false);
    }
    public void SetOldScene()
    {
        if (activeScene == ActiveScene.VECCHIO) return;

        activeScene = ActiveScene.VECCHIO;

        NuovoObject.gameObject.SetActive(false);
        VecchioObject.gameObject.SetActive(true);
    }

    //on click the 3d object requires only box collider
    private void OnMouseDown()
    {
        if (activeScene == ActiveScene.VECCHIO)
        {
            SetNewScene();
        }
        else if (activeScene == ActiveScene.NUOVO)
        {
            SetOldScene();
        }

    }
}
