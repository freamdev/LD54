using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISliderManager : MonoBehaviour
{
    Slider slider;
    public Slider Slider => slider;

    [SerializeField] Image foreground;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void SetForegroundColor(Color color)
    {
        foreground.color = color;
    }
}
