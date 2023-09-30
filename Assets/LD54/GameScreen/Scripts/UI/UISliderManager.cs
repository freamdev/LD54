using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UISliderManager : MonoBehaviour
{
    Slider slider;
    public Slider Slider => slider;

    [SerializeField] Image foreground;
    [SerializeField] TextMeshProUGUI sliderName;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void SetForegroundColor(Color color)
    {
        foreground.color = color;
    }

    public void SetSliderName(string name)
    {
        sliderName.text = name;
    }
}
