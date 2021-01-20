using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObjsOnLost : NYImageTrackerEventHandler
{
    public override void OnTrackingFound()
    {
        base.OnTrackingFound();
    }

    public override void OnTrackingLost()
    {
        base.OnTrackingLost();
    }
}
