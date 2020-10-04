using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cassette : MonoBehaviour
{
    public Image image;
    public Text text;



    public void SetItem(WeaponsController item)
    {
        image.sprite = item.Icon;
        image.color = Color.blue;
        text.text = item.Name;
    }
}
