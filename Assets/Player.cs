using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;
using UnityEditor.Experimental.GraphView;

public class Player : MonoBehaviour
{
    public GameObject swordArea;
    public SwordArea swordAreaClass;
    public float playerSpeed = 4f;
    public GameObject cam;
    public List<Weapon> weapons;
    public Weapon weapon;

    public Weapon gun1;
    public Weapon gun1_2;

    public Weapon melee1;

    // Start is called before the first frame update
    void Start()
    {
        weapons.Add(gun1);
        weapons.Add(gun1_2);
        weapons.Add(melee1);
        swordAreaClass = swordArea.GetComponent<SwordArea>();
        //Physics2D.IgnoreCollision(swordArea.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        difference.Normalize();

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
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
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigid.velocity = new Vector2(-1* playerSpeed, rigid.velocity.y);
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
