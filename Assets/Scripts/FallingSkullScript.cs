using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSkullScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 120 * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Platform" || other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }

}
