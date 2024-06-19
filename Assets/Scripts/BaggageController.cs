using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaggageController : MonoBehaviour
{
    [SerializeField] protected LuggageData luggageData;

    [SerializeField] protected string Player;
    [SerializeField] private int ScoreToGive;
    public string _player { get { return Player; } private set { } }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "LuggageSpot")
        {
            luggageData.uiManagerController.UpdateScores(Player, 1);
            GarageReturn(luggageData.gameManagerController._baggageSpawnPositions);
            Player = null;
        }
        if (collision.transform.tag == "Floor")
        {
            GarageReturn(luggageData.gameManagerController._baggageSpawnPositions);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Limit")
        {
            GarageReturn(luggageData.gameManagerController._baggageSpawnPositions);
            GetComponent<BoxCollider>().isTrigger = false;
        }
    }
    public void GarageReturn(Transform[] positions)
    {
        int RndPos = Random.Range(0, positions.Length);
        transform.position = positions[RndPos].position;
    }
    public void SetPlayerValue(string paleur)
    {
        Player = paleur;
    }
    public void SetPlayer(string victim)
    {
        Player = victim;
    }
}