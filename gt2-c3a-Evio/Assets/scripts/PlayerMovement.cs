using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
       public Rigidbody rb;

    //just fized update since tahts what i remmember using 
    void FixedUpdate()
    {   //x , y , z 
        if (Input.GetKey("d")){//move to the right
            rb.AddForce(1000*Time.deltaTime ,0, 0);
        }
        if (Input.GetKey("a")){//move to the left
            rb.AddForce(-1000 * Time.deltaTime , 0 , 0);
        }
         if (Input.GetKey("w")){//move forward
            rb.AddForce(0, 0 , 1000 * Time.deltaTime);
        }
         if (Input.GetKey("s")){//move back
            rb.AddForce(0, 0 , -1000 * Time.deltaTime);
        }
    }
}
