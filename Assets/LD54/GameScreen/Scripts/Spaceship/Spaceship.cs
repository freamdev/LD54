using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Spaceship : MonoBehaviour
{
    int MAX_MODULE_COUNT = 5;
    const float DISTANCE_TO_TRAVEL = 6000;

    [SerializeField] MeshRenderer starfield;
    Material starMaterial;

    [SerializeField] SpaceshipUIController uiController;
    [SerializeField] List<SpacehipAttribute> spaceshipAttributes;
    [SerializeField] List<SpaceshipModuleBase> modules;
    [SerializeField] Slider distanceSlider;
    [SerializeField] GameObject shieldBubble;

    float distanceTravelled;
    float timePassed;

    [SerializeField] TextMeshProUGUI winText;

    public float DistanceTravelledNormalized => distanceTravelled / DISTANCE_TO_TRAVEL;

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

    private void OnCollisionEnter(Collision collision)
    {
        print("UFF");
        RemoveModule(modules.First());
        MAX_MODULE_COUNT--;
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

        shieldBubble.GetComponent<MeshRenderer>().material.SetFloat("_ShieldPower", Mathf.Lerp(2f, 8f, 1 - GetAttribute(PowerType.Shield).Normalized));

        if (GetAttribute(PowerType.Shield).Normalized >= .1f)
        {
            shieldBubble.GetComponent<Collider>().enabled = true;
            shieldBubble.GetComponent<MeshRenderer>().enabled = true;
        }

        var offset = starMaterial.mainTextureOffset;
        offset.x += (GetAttribute(PowerType.Speed).Normalized + 0.1f) * Time.deltaTime;
        starMaterial.mainTextureOffset = offset;

        distanceTravelled += Time.deltaTime * (GetAttribute(PowerType.Speed).Value + 0.1f);

        distanceSlider.value = DistanceTravelledNormalized;

        if (distanceSlider.value >= 1)
        {
            winText.transform.rotation = Quaternion.identity;
            winText.text = "Aim reached in: " + timePassed + " seconds";
        }
        else
        {
            timePassed += Time.deltaTime;
        }
    }

    internal void ShieldCollidedWithAsteroid()
    {
        GetAttribute(PowerType.Shield).Effect(-12);
        if (GetAttribute(PowerType.Shield).Normalized == 0)
        {
            shieldBubble.GetComponent<Collider>().enabled = false;
            shieldBubble.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
