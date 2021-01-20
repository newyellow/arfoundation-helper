using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NYImageTracker : MonoBehaviour
{
    public Texture2D trackerImage;
    public Vector2 physicalSize = new Vector2(1.0f, 1.0f);

    public bool hideTrackerWhenPlay = true;

    public Transform referenceGrouper;

    Vector3 _originPos;
    Quaternion _originRot;
    Vector3 _originScale;

    Vector3 _grouperPosLocal;
    Quaternion _grouperRotDiff;

    public void Start()
    {
        if(hideTrackerWhenPlay)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }

        _originPos = transform.position;
        _originRot = transform.rotation;
        _originScale = transform.localScale;

        if (referenceGrouper != null)
        {
            _grouperPosLocal = transform.InverseTransformPoint(referenceGrouper.position);
            _grouperRotDiff = referenceGrouper.rotation * Quaternion.Inverse(transform.rotation);
        }
    }

    public void UpdateTransform (Vector3 newPosition, Quaternion newRotation)
    {
        transform.position = newPosition;
        transform.rotation = newRotation;

        if (referenceGrouper != null)
        {
            Vector3 posDiff = transform.position - _originPos;
            Quaternion rotDiff = transform.rotation * Quaternion.Inverse(_originRot);

            referenceGrouper.position = transform.TransformPoint(_grouperPosLocal);
            referenceGrouper.rotation = transform.rotation * _grouperRotDiff;
        }
    }

    public void OnTrackingFound ()
    {
        Debug.Log("origin size: " + _originScale + "  img: " + transform.localScale);

        if(gameObject.GetComponent<NYImageTrackerEventHandler>())
        {
            gameObject.GetComponent<NYImageTrackerEventHandler>().OnTrackingFound();
        }
    }

    public void OnTrackingLost ()
    {
        if(gameObject.GetComponent<NYImageTrackerEventHandler>())
        {
            gameObject.GetComponent<NYImageTrackerEventHandler>().OnTrackingLost();
        }

    }
}
