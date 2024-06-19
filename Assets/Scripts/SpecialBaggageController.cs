using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBaggageController : BaggageController
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "LuggageSpot")
        {
            GarageReturn(luggageData.gameManagerController._baggageSpawnPositions);
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Limit")
        {
            GarageReturn(luggageData.gameManagerController._baggageSpawnPositions);
            GetComponent<BoxCollider>().isTrigger = false;
        }
    }
}