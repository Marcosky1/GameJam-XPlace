using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerController : MonoBehaviour
{
    [SerializeField] private Transform[] BaggageSpawnPositions;
    private BaggageController[] baggageControllers;

    //PUBLIC GETTERS
    public Transform[] _baggageSpawnPositions { get { return BaggageSpawnPositions; } private set { } }
}