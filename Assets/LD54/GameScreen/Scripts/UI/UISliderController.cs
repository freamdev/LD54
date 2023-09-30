using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISliderController : MonoBehaviour
{
    [SerializeField] Color color;
    [SerializeField] string barName;
    UISliderManager sliderManager;

    public UISliderManager Manager => sliderManager;

    // Start is called before the first frame update
    void Awake()
    {
        sliderManager = GetComponent<UISliderManager>();
        sliderManager.SetForegroundColor(color); 
        sliderManager.SetSliderName(barName);
    }
}
