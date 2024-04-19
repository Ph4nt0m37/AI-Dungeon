using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    GameObject player;
    Player playerClass;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerClass = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = transform.right * playerClass.weapon.velocity;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject != player && collision.gameObject.GetComponent<Enemy>() != null)
        {
            StartCoroutine(collision.gameObject.GetComponent<Enemy>().takeDamage(playerClass.weapon.damage,gameObject));
            gameObject.SetActive(false);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
