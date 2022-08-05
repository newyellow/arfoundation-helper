using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimationOnOffTracking : NYImageTrackerEventHandler
{
    public Animator targetAnim;

    public string onFoundAnimName;
    public string onLostAnimName;

    public override void OnTrackingFound()
    {
        targetAnim.Play(onFoundAnimName);
    }

    public override void OnTrackingLost()
    {
        targetAnim.Play(onLostAnimName);
    }
}
