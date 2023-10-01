using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LD54/Engine panel module")]

public class EngineModule : SpaceshipModuleBase
{
    public float SpeedIncrease;
    public float VelocityIncrease;

    public override void InstallModule(Spaceship ship)
    {
        base.InstallModule(ship);
        ship.GetAttribute(PowerType.Speed).EffectMax(SpeedIncrease);
    }

    public override void RemoveModule(Spaceship ship)
    {
        base.RemoveModule(ship);
        ship.GetAttribute(PowerType.Speed).EffectMax(-SpeedIncrease);

    }

    public override void UpdateModule(Spaceship ship)
    {
        var energy = ship.GetAttribute(PowerType.Power).Value;
        if (energy > -PowerDrain)
        {
            ship.GetAttribute(PowerType.Speed).Effect(VelocityIncrease * Time.deltaTime);
        }
        else
        {
            ship.GetAttribute(PowerType.Speed).Effect(-VelocityIncrease * Time.deltaTime * 10);
        }
        ship.GetAttribute(PowerType.Power).Effect(PowerDrain * Time.deltaTime);
    }
}