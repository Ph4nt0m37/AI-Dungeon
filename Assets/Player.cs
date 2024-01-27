using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float acceleration = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position += Vector3.right * acceleration * Time.deltaTime;
            if (acceleration < 2f)
            {
                acceleration += 0.03f;
            }
        }
    }
}
