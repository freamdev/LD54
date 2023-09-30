using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    const int MAX_MODULE_COUNT = 5;
    const float DISTANCE_TO_TRAVEL = 100;

    [SerializeField] MeshRenderer starfield;
    Material starMaterial;

    [SerializeField] SpaceshipUIController uiController;
    [SerializeField] List<SpacehipAttribute> spaceshipAttributes;
    [SerializeField] List<SpaceshipModuleBase> modules;

    float distanceTravelled;

    public SpacehipAttribute GetAttribute(PowerType type) => spaceshipAttributes.First(f => f.PowerType == type);

    public void AddModule(SpaceshipModuleBase module)
    {
        if (modules.Count < MAX_MODULE_COUNT)
        {
            modules.Add(module);
            module.InstallModule(this);
            uiController.RefreshEquippedModuleUI(modules, this);
        }
    }

    public void RemoveModule(SpaceshipModuleBase module)
    {
        modules.Remove(module);
        module.RemoveModule(this);
        uiController.RefreshEquippedModuleUI(modules, this);
    }


    private void Awake()
    {
        starMaterial = starfield.material;
        uiController.Initialize();
        uiController.RefreshEquippedModuleUI(modules, this);
        distanceTravelled = 0;
        foreach (var spaceshipAttribute in spaceshipAttributes)
        {
            spaceshipAttribute.Initialize();
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        foreach (var module in modules)
        {
            module.UpdateModule(this);
        }

        foreach (var attribute in spaceshipAttributes)
        {
            uiController.UpdateSliderUI(attribute.PowerType, attribute.Normalized);
        }

        var offset = starMaterial.mainTextureOffset;
        offset.x += GetAttribute(PowerType.Speed).Normalized * Time.deltaTime;
        starMaterial.mainTextureOffset = offset;
    }
}
