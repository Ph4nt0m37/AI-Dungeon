using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject swordArea;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position += Vector3.right * 5f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position += Vector3.left * 5f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position += Vector3.down * 5f * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.position += Vector3.up * 5f * Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0))
        {
               
        }
    }
}
