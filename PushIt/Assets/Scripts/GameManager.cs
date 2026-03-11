using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public List<GameObject> levels;
    private int currentLevel = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("GameManagerSTART");
        levels[0].GetComponent<Level>().StartLevel();
        levels[0].GetComponent<Level>().LevelCompleteEvent += TransitionToNexTLevel;
    }

    private void TransitionToNexTLevel()
    {
        levels[currentLevel].GetComponent<Level>().LevelCompleteEvent -= TransitionToNexTLevel;
        currentLevel++;
        levels[currentLevel].GetComponent<Level>().StartLevel();
    }
    
}
