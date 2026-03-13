using UnityEngine;

public class Floor : MonoBehaviour
{
    
    public delegate void OnFloorEnterHandler();
    public event OnFloorEnterHandler OnFloorEnterEvent;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.name == "shovel"||other.name == "body")
        {
            OnOnFloorEnterEvent();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
       
    }

    protected virtual void OnOnFloorEnterEvent()
    {
        OnFloorEnterEvent?.Invoke();
    }
}
