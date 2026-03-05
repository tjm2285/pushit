using System.Collections.Generic;
using Unity.Multiplayer.PlayMode;
using UnityEngine;

public class Level : MonoBehaviour
{
    public GameObject entry;
    public GameObject exit;
    public List<GameObject> collectionZones;


    private int currentZonesCompelete = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartLevel();
    }
    public void StartLevel()
    {
        entry.SetActive(false);
        foreach (var zone in collectionZones)
        {
            zone.GetComponent<CollectionZone>().ZoneFilledEvent += CheckIfExitCanOpen;
        }
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
        exit.SetActive(false);
    } 
}
