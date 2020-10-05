using System.Collections;
using Unity.Collections;
using UnityEngine;

public abstract class WeaponsScript : ScriptableObject
{
    public string Name;
    public Sprite Icon;
    public AudioClip Audio;
    
    public float spawnDelay = 2f;

    public float Tempo;
    public bool Player;

    [ReadOnly]
    public bool locked = false;
    
    public abstract IEnumerator Activate(Transform transform, float nextTime);
}