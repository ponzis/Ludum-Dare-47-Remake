using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(AudioSource))]
public class WeaponsController : MonoBehaviour
{
    public WeaponsScript weapon;
    public AudioSource audioSource;

    private float _nextTime;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


}