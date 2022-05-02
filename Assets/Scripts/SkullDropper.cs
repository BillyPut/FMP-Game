using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullDropper : MonoBehaviour
{
    public float dropTimer = 2f;
    public GameObject skullPrefab;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        dropTimer -= Time.deltaTime;

        if (dropTimer <= 0)
        {
            Helper.MakeBullet(skullPrefab, transform.position.x, transform.position.y - 0.5f, 0, 0);
            dropTimer = 5;
        }
    }
}
