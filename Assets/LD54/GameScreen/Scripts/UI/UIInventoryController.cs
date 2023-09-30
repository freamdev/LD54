using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class UIInventoryController : MonoBehaviour
{
    [SerializeField] UIInventoryButton buttonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        var modules = DataProvider.Get().spaceshipModules;
        foreach(var module in modules)
        {
            var newInstance = Instantiate(buttonPrefab, transform);
            newInstance.Initialize(module);
        }
    }
}
