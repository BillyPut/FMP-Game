using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Globals;

public class Helper : MonoBehaviour
{

    


    public static void FlipSprite(GameObject obj, int dir)
    {
        if (dir == Left)
        {
            obj.transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            obj.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }


    }



    public static int GetObjectDir(GameObject obj)
    {
        float ang = obj.transform.eulerAngles.y;
        if (ang == 180)
        {
            return Left;
        }
        else
        {
            return Right;
        }
    }



    public static void SetVelocity(float xvelo, float yvelo, GameObject obj)
    {
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(xvelo, yvelo, 0);
    }


    public static bool DoRayCollisionCheck(GameObject obj)
    {
        float rayLength = 0.5f;
        float x = obj.transform.position.x - 0.05f;
        float y = obj.transform.position.y;

        int layerMask = LayerMask.GetMask("platform");

        //print("lm=" + layerMask);

        //cast a ray downward of length 1
        RaycastHit2D hit = Physics2D.Raycast(new Vector3(x, y, obj.transform.position.z), -Vector2.up, rayLength, layerMask);

        Color hitColor = Color.white;


        if (hit.collider != null)
        {


           //if (hit.collider.tag == "Platform")
            {

                
                hitColor = Color.green;
                Debug.DrawRay(new Vector3(x, y, obj.transform.position.z), -Vector2.up * rayLength, hitColor);
                return true;

            }

        }

        Debug.DrawRay(new Vector3(x, y, obj.transform.position.z), -Vector2.up * rayLength, hitColor);
        return false;

    }


}
