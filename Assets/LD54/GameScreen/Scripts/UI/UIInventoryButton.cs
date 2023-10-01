using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryButton : MonoBehaviour
{
    SpaceshipModuleBase spaceshipModule;

    public void Initialize(SpaceshipModuleBase module)
    {
        spaceshipModule = module;
        GetComponent<Button>().onClick.AddListener(() =>
        {
            var ship = FindObjectOfType<Spaceship>();
            ship.AddModule(Instantiate(spaceshipModule));
        });

        GetComponent<Image>().sprite = module.ModuleIcon;

        GetComponentInChildren<TextMeshProUGUI>()
            .text = spaceshipModule.ModuleName;
    }
    
}
