using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NYImageTracker : MonoBehaviour
{
    public Texture2D trackerImage;
    public Vector2 physicalSize = new Vector2(1.0f, 1.0f);
    public float editScaler = 1.0f;
    float _playScaler = 1.0f;

    public bool hideTrackerWhenPlay = true;
    public bool hideChildrensWhenLostTarget = false;

    public Transform referenceGrouper;

    Vector3 _originPos;
    Quaternion _originRot;
    Vector3 _originScale;

    Vector3 _grouperPosLocal;
    Quaternion _grouperRotDiff;
    Vector3 _grouperOriginScale;

    // for Editor use
    [HideInInspector] public Texture2D _lastTexture;
    [HideInInspector] public Vector2 _lastTrackerSize = new Vector2(1.0f, 1.0f);
    [HideInInspector] public float _sizeRatio = 1.0f;
    [HideInInspector] public int inspectorCounter = -1; // check if it first time selected
    [HideInInspector] public float _lastEditScaler = 1.0f;

    public void Start()
    {
        if(hideTrackerWhenPlay)
        {
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }

        if (hideChildrensWhenLostTarget)
        {
            gameObject.AddComponent<NYImageTrackerEventHandler>();
            gameObject.GetComponent<NYImageTrackerEventHandler>().HideChildrensWhenLostTarget(hideChildrensWhenLostTarget);
        }

        // grab reference data before scale
        _originPos = transform.position;
        _originRot = transform.rotation;
        _originScale = transform.localScale;


        if (referenceGrouper != null)
        {
            _grouperPosLocal = transform.InverseTransformPoint(referenceGrouper.position);
            _grouperRotDiff = referenceGrouper.rotation * Quaternion.Inverse(transform.rotation);
            _grouperOriginScale = referenceGrouper.localScale;
        }

        // scale after
        _playScaler = 1.0f / editScaler;

        if (_playScaler != 1.0f)
        {
            transform.localScale = Vector3.one * _playScaler;
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
            referenceGrouper.localScale = _grouperOriginScale * _playScaler;
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
