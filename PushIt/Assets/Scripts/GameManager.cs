using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public List<GameObject> levels;
    public TextMeshProUGUI scoreText;
    private int _currentLevel = 0;
    private Level _currentLevelObject;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentLevelObject = InitLevel(0);
    }

    private void SetScore(int score)
    {
        int currentScore = int.Parse(scoreText.text) + score;
        scoreText.text = currentScore.ToString();
    }

    private void TransitionToNexTLevel()
    {
        if (_currentLevel + 1 >= levels.Count)
        {
            return;
        }
        _currentLevelObject.LevelCompleteEvent -= TransitionToNexTLevel;
        _currentLevel++;
        _currentLevelObject = InitLevel(_currentLevel);
    }

    private Level InitLevel(int levelNumber)
    {
        Level levelObject = levels[levelNumber].GetComponent<Level>();
        levelObject.StartLevel();
        levelObject.LevelCompleteEvent += TransitionToNexTLevel;
        levelObject.UpdateScoreEvent += SetScore;
        
        return levelObject;
    }
}
