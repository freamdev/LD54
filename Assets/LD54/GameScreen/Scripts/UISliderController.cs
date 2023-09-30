using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISliderController : MonoBehaviour
{
    [SerializeField] Color color;
    UISliderManager sliderManager;

    // Start is called before the first frame update
    void Awake()
    {
        sliderManager = GetComponent<UISliderManager>();
        sliderManager.SetForegroundColor(color); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
