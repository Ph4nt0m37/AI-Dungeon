using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float acceleration = 0;
    public float maxAcceleration = 0;
    public float minAcceleration = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += Vector3.right * acceleration * Time.deltaTime;
        if (Input.GetKey(KeyCode.D))
        {
            if (acceleration < 10f)
            {
                acceleration += 0.02f;
            }
        }
        else
        {
            if (acceleration > 0)
            {
                acceleration -= 0.02f;

            }
        }
    }
}
