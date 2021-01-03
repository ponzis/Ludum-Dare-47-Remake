using Attributes;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
using Utils;

[ExecuteInEditMode]
public class DebugUI : MonoBehaviour
{
    [Label] public string BuildVersion;

    public Rect Rect;
    public Font TextFont;
    public int TextSize = 5;
    public Color TextColor = Color.white;
    
    [Header("Debug")] public bool ShowVersion = true;

    public void Awake()
    {
#if UNITY_EDITOR
        BuildVersion = UpdateBuildVersion();
#endif
    }

    private string UpdateBuildVersion()
    {
        var buildVersion = $"{Git.Branch}: {Git.BuildVersion}";
        
        return buildVersion;
    }

    void OnGUI()
    {
        if (!ShowVersion) return;

        var style = new GUIStyle(GUI.skin.label)
        {
            font = TextFont, 
            fontSize = TextSize,
            normal = new GUIStyleState
            {
                textColor = TextColor
            }
        };

        GUI.Label(Rect, BuildVersion, style);
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