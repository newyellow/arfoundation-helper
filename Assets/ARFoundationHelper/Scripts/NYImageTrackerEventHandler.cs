using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NYImageTracker))]
public class NYImageTrackerEventHandler : MonoBehaviour
{
    private bool hideChildrensWhenLostTarget = false;

    private void Start()
    {
        HideChildrensEffect(true);
    }

    public virtual void OnTrackingFound()
    {
        Debug.Log("tracker [" + gameObject.name + "] Found!");
        HideChildrensEffect(false);
    }

    public virtual void OnTrackingLost ()
    {
        Debug.Log("tracker [" + gameObject.name + "] Lost!");
        HideChildrensEffect(true);
    }

    public void HideChildrensWhenLostTarget(bool hideChildrensWhenLostTarget)
    {
        this.hideChildrensWhenLostTarget = hideChildrensWhenLostTarget;
    }

    private void HideChildrensEffect(bool hide)
    {
        if (hideChildrensWhenLostTarget)
        {
            for (int index = 0; index < transform.childCount; index++)
            {
                transform.GetChild(index).gameObject.SetActive(!hide);

            }
        }
    }
}
