using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public abstract class SpaceshipModuleBase : ScriptableObject
{
    public string ModuleName;
    public Sprite ModuleIcon;
    public GameObject ModuleModel;
    public float PowerDrain;

    public virtual void InstallModule(Spaceship ship)
    {
    }

    public virtual void RemoveModule(Spaceship ship)
    {
    }

    public abstract void UpdateModule(Spaceship ship);
}
