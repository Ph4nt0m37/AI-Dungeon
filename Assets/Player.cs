using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;
using UnityEditor.Experimental.GraphView;
using System.Net.Sockets;

public class Player : MonoBehaviour
{
    public GameObject swordArea;
    public SwordArea swordAreaClass;
    public float playerSpeed = 4f;
    public GameObject cam;
    public List<Weapon> weapons;
    public Weapon weapon;
    public GameObject swordStuff;

    public Weapon slot1;
    public Weapon slot2;

    public Weapon slot3;

    // Start is called before the first frame update
    void Start()
    {
        weapons.Add(slot1);
        weapons.Add(slot2);
        weapons.Add(slot3);
        swordAreaClass = swordArea.GetComponent<SwordArea>();
        weapon = weapons[0];
        //Physics2D.IgnoreCollision(swordArea.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        swordStuff.transform.position = gameObject.transform.position;

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - swordStuff.transform.position;

        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        swordStuff.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        if (rotationZ <= 90 && rotationZ >= -90)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        Rigidbody2D rigid = gameObject.GetComponent<Rigidbody2D>();
        
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (weapons.IndexOf(weapon)+1 < 3) {
                weapon = weapons[weapons.IndexOf(weapon) + 1];
            }
            else
            {
                weapon = weapons[0];
            }
        }
        else
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0f)
            {
                if (weapons.IndexOf(weapon) - 1 > -1)
                {
                    weapon = weapons[weapons.IndexOf(weapon) - 1];
                }
                else
                {
                    weapon = weapons[2];
                }
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigid.velocity = new Vector2(playerSpeed, rigid.velocity.y);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigid.velocity = new Vector2(-1* playerSpeed, rigid.velocity.y);
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigid.velocity = new Vector2(rigid.velocity.x,-1* playerSpeed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, playerSpeed);
        }

        if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            rigid.velocity = new Vector2(rigid.velocity.x, 0);
        }
        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            rigid.velocity = new Vector2(0,rigid.velocity.y);
        }

        if (Input.GetMouseButtonDown(0))
        {
            swordAreaClass.attack();
        }
    }
}
