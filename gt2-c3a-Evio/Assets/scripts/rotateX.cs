using UnityEngine;

public class rotateX : MonoBehaviour
{
    
    // rotates the "x" form thing
    void FixedUpdate()
    {
        transform.Rotate(0,50 *Time.deltaTime,0);
    }
}
