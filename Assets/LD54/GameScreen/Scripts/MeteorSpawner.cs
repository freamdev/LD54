using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    [SerializeField] GameObject meteorPrefab;
    [SerializeField] GameObject meteorText;

    Spaceship ship;

    // Start is called before the first frame update
    void Start()
    {
        ship = FindObjectOfType<Spaceship>();
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            if ((ship.DistanceTravelledNormalized > .15f && ship.DistanceTravelledNormalized < .36f) ||
                (ship.DistanceTravelledNormalized > .67f && ship.DistanceTravelledNormalized < .85f))
            {
                meteorText.transform.rotation = Quaternion.identity;
                var instance = Instantiate(meteorPrefab);
                instance.transform.position = Random.onUnitSphere * 9;
                var dir = ship.transform.position - instance.transform.position;
                instance.GetComponent<Rigidbody>().AddForce(dir.normalized * 3, ForceMode.Impulse);
            }
            else
            {
                meteorText.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
        }
    }
}
