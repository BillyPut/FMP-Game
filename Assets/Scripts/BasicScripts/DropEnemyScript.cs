using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropEnemyScript : MonoBehaviour
{
    public GameObject holder1;
    public GameObject holder2;
    public bool dropGate; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(holder1);
            Destroy(holder2);
            dropGate = true;
        }
    }
}
