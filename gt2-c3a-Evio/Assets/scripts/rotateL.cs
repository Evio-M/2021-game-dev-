using UnityEngine;

public class rotateL : MonoBehaviour
{
 
    // Rotate the L piece
    void FixedUpdate()
    {
        transform.Rotate(0, -25*Time.deltaTime , 0);
    }
}
