using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the Coin on the x-axis by 45 degrees per second
        transform.Rotate(45 * Time.deltaTime, 0, 0);

    }
}
