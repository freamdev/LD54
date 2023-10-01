using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    Spaceship ship;


    private void Awake()
    {
        ship = FindObjectOfType<Spaceship>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        ship.ShieldCollidedWithAsteroid();
    }
}
