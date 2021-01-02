using UnityEngine;

[ExecuteInEditMode]
public class HealthIndicator : MonoBehaviour
{

    public PlayerController player;
    public float LeftStop = 36.5f;
    public float RightRot = -36.5f;
    
    
    
    private float RotationRange =>  Mathf.Abs(LeftStop) + Mathf.Abs(RightRot);

    public RectTransform _needle;

    private void UpdateIndicator(float value)
    {
        var l = value * RotationRange - RotationRange/2;
        var rot = Mathf.Clamp(l, RightRot, LeftStop);
        _needle.rotation = Quaternion.AngleAxis(rot, Vector3.forward);
    }
    
    // Update is called once per frame
    void Update()
    {
        UpdateIndicator(player.HealthPercent);
    }
}
