using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class CassetteManager : MonoBehaviour
{
    // Start is called before the first frame update
    public WeaponsScript[] Cassettes;


    public Cassette[] CasseteCash;
    
    private void Start()
    {
        for (int i = 0; i < Cassettes.Length; i++)
        {
            var cassette = Cassettes[i];
            CasseteCash[i].SetItem(cassette);
        }
    }
    


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") || Input.GetKey(KeyCode.Alpha1)) Trigger(CasseteCash[0]);
        if (Input.GetButton("Fire2") || Input.GetKey(KeyCode.Alpha2)) Trigger(CasseteCash[1]);
        if (Input.GetButton("Fire3") || Input.GetKey(KeyCode.Alpha3)) Trigger(CasseteCash[2]);
    }

    void Trigger(Cassette controller)
    {
        if (controller)
        {
            controller.Trigger();
        }
    }
}
