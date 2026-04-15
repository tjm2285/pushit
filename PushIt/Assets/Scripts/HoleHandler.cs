using System;
using UnityEngine;
using UnityEngine.Serialization;

public class HoleHandler : MonoBehaviour
{
    [FormerlySerializedAs("NormalShpereLayer")] public int NormalSphereLayer;
    public int FallingSphereLayer;

    private void OnTriggerEnter(Collider other)
    {
        Transform t = other.gameObject.transform;;
        if (other.gameObject.name == "tractor-shovel" || other.gameObject.name == "shovel" || other.gameObject.name == "body")
        {
            t = other.gameObject.transform.parent.transform.parent.transform;
        }
        
        if (other.gameObject.layer == NormalSphereLayer)
        {
            //other.gameObject.layer = FallingSphereLayer;
            SetLayerAllChildren(t, FallingSphereLayer);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == FallingSphereLayer)
        {
            other.gameObject.layer = NormalSphereLayer;
            SetLayerAllChildren(other.gameObject.transform, NormalSphereLayer);
        }
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
