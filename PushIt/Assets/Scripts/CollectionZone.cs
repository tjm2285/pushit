using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CollectionZone : MonoBehaviour
{
    private static readonly int IsClosed = Animator.StringToHash("IsClosed");
    private static readonly int IsOpen = Animator.StringToHash("IsOpen");

    [SerializeField]
    private int _scoreGoal = 10;

    [SerializeField]
    private TextMeshPro _scoreText;
    
    
    public HitArea _hitArea;
    public Animator _leftAnimator;
    public Animator _rightAnimator;
    public delegate void ZoneFilledHandler();
    public event ZoneFilledHandler ZoneFilledEvent;

    private int _score = 0;
    private bool _isFilled = false;
    private bool _isZoneActive = false;

    private void Start()
    {
        _scoreText.text = string.Format("{0}/{1}", _score, _scoreGoal);
    }

    public void EnableCollectionZone()
    {
        Debug.Log("EnableCollectionZone");
        _score = 0;
        _isFilled = false;
        _scoreText.color = Color.white;
        _isZoneActive = true;
        _hitArea.OnHitEvent += ProcessCollision;
        _leftAnimator.SetTrigger(IsOpen);
        _rightAnimator.SetTrigger(IsOpen);
        
    }

    private void ProcessCollision(Collision collision)
    {
        var hitObject = collision.gameObject.GetComponent<Item>();
        if (hitObject!=null)
        {
            if (_isZoneActive)
            {
                _score += hitObject.value;
                _scoreText.text = string.Format("{0}/{1}", _score, _scoreGoal);

                if (_score >= _scoreGoal)
                {
                    ZoneFilled();
                }
            }
            // GameObject.Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       /* if (_isFilled) return;
       
        
        var hitObject = collision.gameObject.GetComponent<Item>();
        if (hitObject!=null)
        {
            if (_isZoneActive)
            {
                // Debug.Log(collision.gameObject.name);
                _score += hitObject.value;
                _scoreText.text = string.Format("{0}/{1}", _score, _scoreGoal);

                if (_score >= _scoreGoal)
                {
                    ZoneFilled();
                }
            }
           // GameObject.Destroy(collision.gameObject);
        }*/
    }

    private void ZoneFilled()
    {
        if (_isFilled) return;
        _isFilled = true;
        _scoreText.color = Color.springGreen;
        _leftAnimator.SetTrigger(IsClosed);
        _rightAnimator.SetTrigger(IsClosed);
        ZoneFilledEvent?.Invoke();
    }
}
