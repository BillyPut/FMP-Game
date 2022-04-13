using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBarrierScript : MonoBehaviour
{
    public GameObject Player;
    public float xTeleport;
    public float yTeleport;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.transform.position = new Vector3(xTeleport, yTeleport, -0.1f);
        }
    }

}
