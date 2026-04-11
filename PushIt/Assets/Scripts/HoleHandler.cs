using System;
using UnityEngine;
using UnityEngine.Serialization;

public class HoleHandler : MonoBehaviour
{
    [FormerlySerializedAs("NormalShpereLayer")] public int NormalSphereLayer;
    public int FallingSphereLayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == NormalSphereLayer)
        {
            other.gameObject.layer = FallingSphereLayer;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == FallingSphereLayer)
        {
            other.gameObject.layer = NormalSphereLayer;
        }
    }
}
