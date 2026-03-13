using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public List<GameObject> levels;
    private int _currentLevel = 0;
    private Level _currentLevelObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("GameManagerSTART");
        _currentLevelObject = levels[0].GetComponent<Level>();
        _currentLevelObject.StartLevel();
        _currentLevelObject.LevelCompleteEvent += TransitionToNexTLevel;
    }

    private void TransitionToNexTLevel()
    {
        Debug.Log(_currentLevel);
        _currentLevelObject.LevelCompleteEvent -= TransitionToNexTLevel;
        _currentLevel++;
        _currentLevelObject = levels[_currentLevel].GetComponent<Level>();
        _currentLevelObject.StartLevel();
        _currentLevelObject.LevelCompleteEvent += TransitionToNexTLevel;
        Debug.Log(_currentLevel);
    }
    
}
