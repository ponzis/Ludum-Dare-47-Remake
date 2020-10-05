using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class Cassette : MonoBehaviour
{
    public Image image;
    public Text text;
    private WeaponsScript _controller;

    public Color color = Color.black;
    
    private AudioSource _audioSource;

    public Transform playerPos;
    
    private float _nextTime;
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
    
    public void SetItem(WeaponsScript item)
    {

        image.sprite = item.Icon;
        text.text = item.Name;
        _audioSource.clip = item.Audio;
        _controller = item;
        
    }

    public void Trigger()
    {
        if (!_controller.locked && Time.time > _nextTime)
        {
            StartCoroutine(TriggerCoroutine());
            _nextTime = Time.time + _controller.spawnDelay;
            StartCoroutine(_controller.Activate(playerPos, _nextTime));
            if (_audioSource.enabled)
            {
                _audioSource.Play();
            }
        }
    }
    
    private IEnumerator TriggerCoroutine()
    {
        image.color = color;
        yield return new WaitForSeconds(_controller.spawnDelay);
        image.color = Color.white;
    }
}
