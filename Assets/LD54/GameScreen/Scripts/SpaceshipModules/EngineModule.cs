using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LD54/Engine panel module")]

public class EngineModule : SpaceshipModuleBase
{
    public float SpeedIncrease;

    public override void InstallModule(Spaceship ship)
    {
        base.InstallModule(ship);
        Debug.Log(SpeedIncrease);
        ship.GetAttribute(PowerType.Speed).Effect(SpeedIncrease);
    }

    public override void RemoveModule(Spaceship ship)
    {
        base.RemoveModule(ship);
        ship.GetAttribute(PowerType.Speed).Effect(-SpeedIncrease);
    }

    public override void UpdateModule(Spaceship ship)
    {
        ship.GetAttribute(PowerType.Power).Effect(PowerDrain * Time.deltaTime);
    }
} 