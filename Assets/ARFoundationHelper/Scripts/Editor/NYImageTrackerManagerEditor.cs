using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEditor;
using UnityEditor.XR.ARSubsystems;

[CustomEditor(typeof(NYImageTrackerManager))]
public class NYImageTrackerManagerEditor : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Update Library"))
        {
            GenerateLibFromSceneSetting();
        }

        if (GUILayout.Button("Create NY Image Tracker"))
        {
            GenerateNyImageTracker();
        }
    }

    public void GenerateLibFromSceneSetting()
    {
        NYImageTracker[] trackers = GameObject.FindObjectsOfType<NYImageTracker>();

        Transform[] objs = new Transform[trackers.Length];
        XRReferenceImageLibrary newLib = ScriptableObject.CreateInstance<XRReferenceImageLibrary>();

        string debugText = "Found " + trackers.Length + " Trackers in Scene:\n";
        for (int i = 0; i < trackers.Length; i++)
        {
            debugText += "  " + trackers[i].gameObject.name + "\n";
            objs[i] = trackers[i].transform;

            XRReferenceImageLibraryExtensions.Add(newLib);
            XRReferenceImageLibraryExtensions.SetName(newLib, i, trackers[i].name);
            XRReferenceImageLibraryExtensions.SetTexture(newLib, i, trackers[i].trackerImage, false);
            XRReferenceImageLibraryExtensions.SetSpecifySize(newLib, i, true);
            XRReferenceImageLibraryExtensions.SetSize(newLib, i, trackers[i].physicalSize);
        }

        string targetPath = Resources.Load<ARFoundationHelperSettings>("HelperSettings").GeneratedLibrarySavePath;
        AssetDatabase.CreateAsset(newLib, targetPath + "generated-lib.asset");

        ((NYImageTrackerManager)target).targetLib = newLib;
        ((NYImageTrackerManager)target).trackerObjs = objs;

        Debug.Log(debugText);
    }

    public void GenerateNyImageTracker()
    {
        GameObject nyImageTracker = new GameObject();
        nyImageTracker.AddComponent<NYImageTracker>();
        nyImageTracker.name = GetNameNyImageTrackerObj();
    }

    private string GetNameNyImageTrackerObj()
    {
        int nyImageTrackoutSceneCount = FindObjectsOfType<NYImageTracker>().Length;

        if(nyImageTrackoutSceneCount <= 9)
        {
            return $"NY-ImageTracker-0{nyImageTrackoutSceneCount}";
        }
        else
        {
            return $"NY-ImageTracker-{nyImageTrackoutSceneCount}";
        }
    }
}
