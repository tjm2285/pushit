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

    private int currentZonesCompelete = 0;
    
    public delegate void LevelCompleteHandler();
    public event LevelCompleteHandler LevelCompleteEvent;
    
    void Start()
    {
        
    }
    public void StartLevel()
    {
        Debug.Log("StartLevel");
        entry.SetActive(false);
        foreach (var zone in collectionZones)
        {
            zone.GetComponent<CollectionZone>().ZoneFilledEvent += CheckIfExitCanOpen;
        }
       
        levelCamera.SetActive(true);
    }

    private void CheckIfExitCanOpen()
    {
        currentZonesCompelete++;
        if (currentZonesCompelete >= collectionZones.Count)
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
