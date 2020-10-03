using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FPSCounter : MonoBehaviour
{
    public float frequency = 0.5f;
    private int _fps;
    
    public Rect boxRect;
    public GUIStyle style = new GUIStyle();
    
    private void Start()
    {
        StartCoroutine(FPS());
    }
    
    private IEnumerator FPS()
    {
        while (true)
        {
            int lastFrameCount = Time.frameCount;
            float lastTime = Time.realtimeSinceStartup;
            yield return new WaitForSeconds(frequency);
            float timeSpan = Time.realtimeSinceStartup - lastTime;
            int frameCount = Time.frameCount - lastFrameCount;
            _fps = Mathf.RoundToInt(frameCount / timeSpan);
        }
    }
    
    private void OnGUI()
    {
        GUI.Box(boxRect, "");
        GUI.Label(boxRect, " " + _fps + "fps", style);
    }
}
