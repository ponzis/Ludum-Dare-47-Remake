using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CassetManager : MonoBehaviour
{
    // Start is called before the first frame update


    public WeaponsController[] Cassets;


    public GameObject[] CassetCash;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") || Input.GetKey(KeyCode.Alpha1)) Trigger(Cassets[0]);
        if (Input.GetButton("Fire2") || Input.GetKey(KeyCode.Alpha2)) Trigger(Cassets[1]);
        if (Input.GetButton("Fire3") || Input.GetKey(KeyCode.Alpha3)) Trigger(Cassets[2]);
    }

    void Trigger(WeaponsController controller)
    {
        if (controller)
        {
            controller.Activate();
        }
    }
}
