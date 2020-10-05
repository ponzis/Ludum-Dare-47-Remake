using UnityEngine;


public abstract class SpawnSystem : ScriptableObject
{
    public abstract void Spawn(Vector3 position);

    public abstract void DrawGizmos(Vector3 position);
}