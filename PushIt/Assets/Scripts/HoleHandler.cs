using System;
using UnityEngine;

public class HoleHandler : MonoBehaviour
{
    public int NormalShpereLayer, FallingSphereLayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == NormalShpereLayer)
        {
            other.gameObject.layer = FallingSphereLayer;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == FallingSphereLayer)
        {
            other.gameObject.layer = NormalShpereLayer;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
