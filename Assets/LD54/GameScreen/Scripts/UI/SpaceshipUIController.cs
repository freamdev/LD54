using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpaceshipUIController : MonoBehaviour
{
    [SerializeField] List<UISliderModel> sliderControllers;
    [SerializeField] GameObject installedModulesPanel;

    List<UIEquippedModuleButton> equippedModuleButtons;
    UISliderManager Get(PowerType type) => sliderControllers.First(f => f.PowerType == type).Controller.Manager;

    public void Initialize()
    {
        equippedModuleButtons = GameObject.FindObjectsOfType<UIEquippedModuleButton>()
            .OrderBy(o => o.transform.position.x)
            .ToList();
    }

    public void RefreshEquippedModuleUI(List<SpaceshipModuleBase> modules, Spaceship ship)
    {
        foreach(var module in equippedModuleButtons)
        {
            module.GetComponentInChildren<TextMeshProUGUI>().text = "empty";
            module.GetComponent<Button>().onClick.RemoveAllListeners();
        }

        foreach(var module in modules.Select((item, index) => (item, index)))
        {
            var equippedModule = equippedModuleButtons[module.index];
            equippedModule.GetComponentInChildren<TextMeshProUGUI>().text = module.item.ModuleName;
            equippedModule.GetComponent<Button>().onClick.AddListener(() =>
            {
                ship.RemoveModule(module.item);
            });
        }
    }

    public void UpdateSliderUI(PowerType type, float v)
    {
        Get(type).Slider.value = v;
    }
}

[System.Serializable] 
public class UISliderModel
{
    public PowerType PowerType;
    public UISliderController Controller;
}

public enum PowerType
{
    Power,
    Shield,
    Speed
}
