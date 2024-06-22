using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SceneManager", menuName = "ScriptableObjects/SceneManager", order = 0)]

public class SceneManagerController : ScriptableObject
{
    public void SceneToGo(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void P1Victory()
    {
        SceneManager.LoadScene("Player1Victory");
    }
    public void P2Victory()
    {
        SceneManager.LoadScene("Player2Victory");
    }
}