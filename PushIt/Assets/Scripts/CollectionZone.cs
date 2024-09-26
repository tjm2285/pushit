using System.ComponentModel;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class CollectionZone : MonoBehaviour
{
    [SerializeField]
    private int _scoreGoal = 10;

    [SerializeField]
    private TextMeshPro _scoreText;

    private int _score = 0;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        var hitObject = collision.gameObject.GetComponent<Item>();
        if (hitObject!=null)
        {
            Debug.Log(collision.gameObject.name);
            _score += hitObject.value;
            _scoreText.text = string.Format("{0}/{1}", _score, _scoreGoal);
            GameObject.Destroy(collision.gameObject);
        }
    }
}
