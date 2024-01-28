using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public GameObject player;
    public float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        Vector3 movePosition = transform.position;

        movePosition.x = Mathf.MoveTowards(transform.position.x, player.transform.position.x, speed * Time.deltaTime);
        movePosition.y = Mathf.MoveTowards(transform.position.y, player.transform.position.y, speed * Time.deltaTime);

        rigid.MovePosition(movePosition);
        rigid.velocity = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        Vector2 difference = player.transform.position - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        if (rotationZ <= 90 && rotationZ >= -90)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }
}
