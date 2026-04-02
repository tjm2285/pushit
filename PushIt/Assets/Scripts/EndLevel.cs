using System.Collections.Generic;
using Unity.Cinemachine;
using Unity.Multiplayer.PlayMode;
using UnityEngine;

public class EndLevel : Level
{
    private static readonly int DoDrive = Animator.StringToHash("Drive");
    //private int _currentZonesComplete = 0;
    
    public delegate void LevelCompleteHandler();
    public event LevelCompleteHandler LevelCompleteEvent;
    public Animator _leftAnimator;
    public ParticleSystem _leftParticleSystem;
    public ParticleSystem _rightParticleSystem;
    
    
    void Start()
    {
        //_currentZonesComplete = 0;
    }
    public override void StartLevel()
    {
        entry.SetActive(false);
       /* foreach (var zone in collectionZones)
        {
            zone.GetComponent<CollectionZone>().ZoneFilledEvent += CheckIfExitCanOpen;
        }*/

        floor.GetComponent<Floor>().OnFloorEnterEvent += CarEnteredLevel;
    }

    protected override void CarEnteredLevel()
    {
        floor.GetComponent<Floor>().OnFloorEnterEvent -= CarEnteredLevel;
        levelCamera.GetComponent<CinemachineCamera>().Priority = 100;
       /* foreach (var zone in collectionZones)
        {
            zone.GetComponent<CollectionZone>().EnableCollectionZone();
        }*/
       _leftParticleSystem.Play();
       _rightParticleSystem.Play();
       //_leftAnimator.SetTrigger(DoDrive);
    }

    private void CheckIfExitCanOpen()
    {
       /* _currentZonesComplete++;
        if (_currentZonesComplete >= collectionZones.Count)
        {
            OpenExit();
        }*/
    }
    private void OpenExit()
    {
        LevelCompleteEvent?.Invoke();
        exit.SetActive(false);
        //levelCamera.SetActive(false);
        levelCamera.GetComponent<CinemachineCamera>().Priority = 0;
    } 
}
