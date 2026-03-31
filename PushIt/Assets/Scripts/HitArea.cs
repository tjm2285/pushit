using UnityEngine;

public class HitArea : MonoBehaviour
{ 
    public delegate void OnHitHandler(Collision collision);
    public event OnHitHandler OnHitEvent;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        OnHitEvent?.Invoke(collision);
    }
    
}
