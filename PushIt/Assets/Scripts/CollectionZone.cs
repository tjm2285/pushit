using System.ComponentModel;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CollectionZone : MonoBehaviour
{
    [SerializeField]
    private int _scoreGoal = 10;

    [SerializeField]
    private TextMeshPro _scoreText;
    
    public delegate void ZoneFilledHandler();
    public event ZoneFilledHandler ZoneFilledEvent;

    private int _score = 0;
   
    private void OnCollisionEnter(Collision collision)
    {
        var hitObject = collision.gameObject.GetComponent<Item>();
        if (hitObject!=null)
        {
           // Debug.Log(collision.gameObject.name);
            _score += hitObject.value;
            _scoreText.text = string.Format("{0}/{1}", _score, _scoreGoal);
            
            if(_score>=_scoreGoal)
            {
                ZoneFilled();
            }
            
            GameObject.Destroy(collision.gameObject);
        }
    }

    private void ZoneFilled()
    {
        _scoreText.color = Color.springGreen;
        ZoneFilledEvent?.Invoke();
    }
}
