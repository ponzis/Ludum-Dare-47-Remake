using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HealthIndicator : MonoBehaviour
{


    public float LeftStop = 36.5f;
    public float RightRot = -36.5f;

    private float RotationRange =>  Mathf.Abs(LeftStop) + Mathf.Abs(RightRot);

    public RectTransform _needle;

    public float Health {
        set
        {
            var l = value * RotationRange - RotationRange/2;
            var rot = Mathf.Clamp(l, RightRot, LeftStop);
            _needle.rotation = Quaternion.AngleAxis(rot, Vector3.forward);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
