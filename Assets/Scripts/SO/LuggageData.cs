using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LuggageData", menuName = "ScriptableObjects/LuggageData", order = 2)]
public class LuggageData : ScriptableObject
{
    public GameManagerController gameManagerController;
    public UIManagerController uiManagerController;
}