using Unity.VisualScripting.FullSerializer;
using UnityEngine;

[System.Serializable]
public class SpacehipAttribute
{
    [SerializeField] PowerType powerType;
    [SerializeField] float maxValue;
    [SerializeField] float regenValue;
    [SerializeField] bool startCharged;

    float value;
    public PowerType PowerType => powerType;
    public float Normalized => value / maxValue;
    public float Value => value;


    public void Initialize()
    {
        value = startCharged ? maxValue : 0;
    }

    public void Effect(float v)
    {
        value = Mathf.Max(0, Mathf.Min(value + v, maxValue));
    }

    public void EffectMax(float v)
    {
        maxValue = Mathf.Max(0, maxValue + v);
    }
}
