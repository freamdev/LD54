using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LD54/Data")]
public class GameData : ScriptableObject
{
    public List<SpaceshipModuleBase> spaceshipModules;
}

public static class DataProvider
{
    static GameData data;

    public static GameData Get()
    {
        if(data == null)
        {
            data = Resources.Load<GameData>("GameData");
        }

        return data;
    }
}
