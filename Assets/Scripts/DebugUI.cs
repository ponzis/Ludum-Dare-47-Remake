using Attributes;
using UnityEditor;
using UnityEngine;
using Utils;

[ExecuteInEditMode]
public class DebugUI : MonoBehaviour
{
    [Label] public string BuildVersion;

    public Rect Rect;

    [Header("Debug")] public bool ShowVersion = true;

    public void Awake()
    {
#if UNITY_EDITOR
        BuildVersion = UpdateBuildVersion();
#endif
    }

    private string UpdateBuildVersion()
    {
        var buildVersion = Git.BuildVersion;
        return buildVersion;
    }

    void OnGUI()
    {
        if (!ShowVersion) return;
        GUI.Label(Rect, BuildVersion);
    }

    void OnDrawGizmos()
    {
        if (!ShowVersion) return;
#if UNITY_EDITOR
        Handles.color = Color.white;
        Handles.Label(Vector3.zero, BuildVersion);
#endif
    }
}