using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public GameObject swordArea;
    public SwordArea swordAreaClass;
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        swordAreaClass = swordArea.GetComponent<SwordArea>();
    }

    // Update is called once per frame
    void Update()
    {
        //float hypotenuse = Vector3.Distance(cam.transform.position, Input.mousePosition);
        float xDistance = cam.transform.position.x - Input.mousePosition.x;
        float yDistance = cam.transform.position.y-Input.mousePosition.y;
        //gameObject.transform.rotation = Quaternion.LookRotation(xDistance,yDistance);
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
            swordAreaClass.attack();
        }
    }
}
