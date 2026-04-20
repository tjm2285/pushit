using System.Collections;
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
    public CollectionZone _collectionZone;
    public GameObject _car;
    public AudioSource _carHorn;
    public AudioSource _applause;
    void Start()
    {
        //_currentZonesComplete = 0;
    }
    public override void StartLevel()
    {
        entry.SetActive(false);
        floor.GetComponent<Floor>().OnFloorEnterEvent += CarEnteredLevel;
    }

    protected override void CarEnteredLevel()
    {
        floor.GetComponent<Floor>().OnFloorEnterEvent -= CarEnteredLevel;
        levelCamera.GetComponent<CinemachineCamera>().Priority = 100;
       StartCoroutine(WaitForCamera());
    }
    IEnumerator WaitForCamera()
    {
      SetLayerAllChildren(_car.transform, LayerMask.NameToLayer("NormalSphere"));
      _car.GetComponent<CarController>().IsCarActive = false;
        yield return new WaitForSeconds(2);
        _leftParticleSystem.Play();
        _rightParticleSystem.Play();
        _applause.Play();
        StartCoroutine(WaitForConfetti());
    }
    IEnumerator WaitForConfetti()
    {
        yield return new WaitForSeconds(1);
       _leftAnimator.SetTrigger(DoDrive);
       _collectionZone.EnableCollectionZone();
       _carHorn.Play();
       yield return new WaitForSeconds(8);
       _collectionZone.AnimateDoorsClosed();
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

    private void SetLayerAllChildren(Transform root, int layer)
    {
        var children = root.GetComponentsInChildren<Transform>(includeInactive: true);
        foreach (var child in children)
        {
            child.gameObject.layer = layer;
        }
    }
}
