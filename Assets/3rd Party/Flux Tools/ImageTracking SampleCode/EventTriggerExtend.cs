using UnityEngine;
using UnityEngine.Events;

public class EventTriggerExtend : MonoBehaviour
{
    public UnityEvent OnStarted;
    public UnityEvent OnRemoved;
    public UnityEvent OnClicked;

    void Start()
    {
        
    }
    private void OnEnable()
    {
        OnStarted.Invoke();
    }

    private void OnDisable()
    {
        OnRemoved.Invoke();
    }

    private void OnMouseDown()
    {
        OnClicked.Invoke();
    }
}