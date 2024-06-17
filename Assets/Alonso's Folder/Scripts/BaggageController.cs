using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaggageController : MonoBehaviour
{
    [SerializeField] private GameManagerController GameManager;

    // Start is called before the first frame update
    void Start()
    {

    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Floor")
        {
            GarageReturn(GameManager._baggageSpawnPositions);
        }
    }
    public void GarageReturn(Transform[] positions)
    {
        int RndPos = Random.Range(0, positions.Length);
        transform.position = positions[RndPos].position;
    }
}