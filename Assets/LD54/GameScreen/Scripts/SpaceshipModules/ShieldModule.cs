using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LD54/Shield panel module")]
public class ShieldModule : SpaceshipModuleBase
{
    [SerializeField] float rechargeRate;

    public override void UpdateModule(Spaceship ship)
    {
        var cost = PowerDrain * Time.deltaTime;
        if (ship.GetAttribute(PowerType.Power).Value > -cost)
        {
            ship.GetAttribute(PowerType.Shield).Effect(rechargeRate * Time.deltaTime);
            ship.GetAttribute(PowerType.Power).Effect(cost);
        }
    }
}
