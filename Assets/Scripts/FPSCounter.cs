using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class FPSCounter : MonoBehaviour
{
    public float frequency = 0.5f;
    
    private float _accum = 0f;
    private int _frames = 0;

    private Text _fpsCounter;
    
    void Awake()
    {
        _fpsCounter = GetComponent<Text>();
    }

    private void  Start()
    {
        StartCoroutine(FPS());
    }

    void Update()
    {
        _accum += Time.timeScale / Time.deltaTime;
        ++_frames;
    }
    
    private IEnumerator FPS()
    {
        while (true)
        {
            var fps =Mathf.Max(Mathf.Round(_accum/_frames), 0);
            _fpsCounter.text = FormatFPS((int)fps);
            _accum = 0f;
            _frames = 0;
            yield return new WaitForSeconds(frequency);
        }
    }

    private string FormatFPS(int fps)
    {
        return $"{fps}fps";
    }
}
