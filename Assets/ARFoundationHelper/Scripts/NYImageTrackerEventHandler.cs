using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NYImageTracker))]
public class NYImageTrackerEventHandler : MonoBehaviour
{
    public virtual void OnTrackingFound ()
    {
        Debug.Log("tracker [" + gameObject.name + "] Found!");
    }

    public virtual void OnTrackingLost ()
    {
        Debug.Log("tracker [" + gameObject.name + "] Lost!");
    }
}
