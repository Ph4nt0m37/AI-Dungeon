using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> touching = new List<GameObject>();

    public int damage = 8;
    public float speed = 3f;
    public int health = 100;

    public GameObject gameSpawnerObj;
    public GameSpawner gameSpawner;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gameSpawnerObj = GameObject.Find("GameSpawner");
        gameSpawner = gameSpawnerObj.GetComponent<GameSpawner>();
        health = 100 * gameSpawner.difficulty;
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
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            touching.Add(collision.gameObject);
            StartCoroutine(dealDamage(damage*gameSpawner.difficulty));
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            touching.Remove(collision.gameObject);
        }
    }

    IEnumerator dealDamage(int damage)
    {
        if (touching.Contains(player))
        {
            player.GetComponent<Player>().health -= damage;
            player.GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(0.25f);
            player.GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(0.5f);
            StartCoroutine(dealDamage(damage));
        }
    }
}
