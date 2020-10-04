using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cassette : MonoBehaviour
{
    public Image image;
    public Text text;
    private WeaponsController _controller;

    public Color color = Color.black;
    
    private bool locked;
    
    public void SetItem(WeaponsController item)
    {
        image.sprite = item.Icon;
        text.text = item.Name;
        _controller = item;
    }

    public void Trigger()
    {
        if (!locked)
        {
            StartCoroutine(TriggerCoroutine());
        }
    }

    private IEnumerator TriggerCoroutine()
    {
        if (_controller.Activate())
        {
            image.color = color;
            locked = true;
            yield return new WaitForSeconds(_controller.spawnDelay);
            locked = false;
            image.color = Color.white;
        }
    }
}
