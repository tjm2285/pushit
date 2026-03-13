using System.Collections.Generic;
using Unity.Cinemachine;
using Unity.Multiplayer.PlayMode;
using UnityEngine;

public class Level : MonoBehaviour
{
    public GameObject entry;
    public GameObject exit;
    public List<GameObject> collectionZones;
    public GameObject levelCamera;

    private int _currentZonesComplete = 0;
    
    public delegate void LevelCompleteHandler();
    public event LevelCompleteHandler LevelCompleteEvent;
    
    void Start()
    {
        _currentZonesComplete = 0;
    }
    public void StartLevel()
    {
        Debug.Log("StartLevel  - " +levelCamera.transform.parent.name);
        entry.SetActive(false);
        foreach (var zone in collectionZones)
        {
            zone.GetComponent<CollectionZone>().ZoneFilledEvent += CheckIfExitCanOpen;
        }
       
        levelCamera.SetActive(true);
    }

    private void CheckIfExitCanOpen()
    {
        _currentZonesComplete++;
        if (_currentZonesComplete >= collectionZones.Count)
        {
            OpenExit();
        }
    }
    private void OpenExit()
    {
        LevelCompleteEvent?.Invoke();
        exit.SetActive(false);
        levelCamera.SetActive(false);
    } 
}
