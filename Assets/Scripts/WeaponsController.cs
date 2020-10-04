﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(AudioSource))]
public abstract class WeaponsController : MonoBehaviour
{
    
    public String Name;
    public Sprite Icon;
    public GameObject bullet;


    protected AudioSource _audioSource;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public abstract void Activate();
    
}