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
    public GameObject floor;

    private int _currentZonesComplete = 0;
    
    public delegate void LevelCompleteHandler();
    public event LevelCompleteHandler LevelCompleteEvent;
    
    void Start()
    {
        _currentZonesComplete = 0;
    }
    public virtual void StartLevel()
    {
        if(entry)entry.SetActive(false);
        foreach (var zone in collectionZones)
        {
            zone.GetComponent<CollectionZone>().ZoneFilledEvent += CheckIfExitCanOpen;
        }

        floor.GetComponent<Floor>().OnFloorEnterEvent += CarEnteredLevel;
    }

    protected virtual void CarEnteredLevel()
    {
        floor.GetComponent<Floor>().OnFloorEnterEvent -= CarEnteredLevel;
        levelCamera.GetComponent<CinemachineCamera>().Priority = 100;
        foreach (var zone in collectionZones)
        {
            zone.GetComponent<CollectionZone>().EnableCollectionZone();
        }
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
        
        levelCamera.GetComponent<CinemachineCamera>().Priority = 0;
    } 
}
