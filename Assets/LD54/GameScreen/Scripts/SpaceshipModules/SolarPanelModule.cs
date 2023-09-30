using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LD54/Solar panel module")]
public class SolarPanelModule : SpaceshipModuleBase
{
    public override void UpdateModule(Spaceship ship)
    {
        ship.GetAttribute(PowerType.Power).Effect(PowerDrain * Time.deltaTime);
    }
}
