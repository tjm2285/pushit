using UnityEngine;

public class ItemEmitter : MonoBehaviour
{

    public GameObject itemToSpawn;
    public int objectCount = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < objectCount; i++)
        {
            var newObj = GameObject.Instantiate(itemToSpawn);
            var zpos = (i % 10 == 0) ? transform.position.z : transform.position.z ;
            var xpos = (i % 10 == 0) ? transform.position.x : transform.position.x ;
            newObj.transform.position = new Vector3(xpos, transform.position.y+(i/2), zpos);
            newObj.transform.parent = transform;
        }
    }
}
