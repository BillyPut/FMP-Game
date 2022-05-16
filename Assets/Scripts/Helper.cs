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
        float rayLength = 0.3f;
        float x = obj.transform.position.x - 0.05f;
        float y = obj.transform.position.y;

        float rayLength2 = 0.3f;
        float x2 = obj.transform.position.x - 0.7f;
        float y2 = obj.transform.position.y;

        float rayLength3 = 0.3f;
        float x3 = obj.transform.position.x + 0.7f;
        float y3 = obj.transform.position.y;

        int layerMask = LayerMask.GetMask("platform");

        //print("lm=" + layerMask);

        //cast a ray downward of length 1
        RaycastHit2D hit = Physics2D.Raycast(new Vector3(x, y, obj.transform.position.z), -Vector2.up, rayLength, layerMask);
        RaycastHit2D hit2 = Physics2D.Raycast(new Vector3(x2, y2, obj.transform.position.z), -Vector2.up, rayLength2, layerMask);
        RaycastHit2D hit3 = Physics2D.Raycast(new Vector3(x3, y3, obj.transform.position.z), -Vector2.up, rayLength3, layerMask);

        Color hitColor = Color.white;


        if (hit.collider != null || hit2.collider != null || hit3.collider != null)
        {


           //if (hit.collider.tag == "Platform")
            {

                
                hitColor = Color.green;
                Debug.DrawRay(new Vector3(x, y, obj.transform.position.z), -Vector2.up * rayLength, hitColor);
                Debug.DrawRay(new Vector3(x2, y2, obj.transform.position.z), -Vector2.up * rayLength2, hitColor);
                Debug.DrawRay(new Vector3(x3, y3, obj.transform.position.z), -Vector2.up * rayLength3, hitColor);
                return true;

            }

        }

        Debug.DrawRay(new Vector3(x, y, obj.transform.position.z), -Vector2.up * rayLength, hitColor);
        return false;

    }



    public static void MakeBullet(GameObject prefab, float xpos, float ypos, float xvel, float yvel)
    {
        // instantiate the object at xpos,ypos
        GameObject instance = Instantiate(prefab, new Vector3(xpos, ypos, 0), Quaternion.identity);

        // set the velocity of the instantiated object
        Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(xvel, yvel, 0);

        // set the direction of the instance based on the x velocity
        FlipSprite(instance, xvel < 0 ? Left : Right);
    }



}
