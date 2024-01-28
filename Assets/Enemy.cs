using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
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

    public Player playerClass;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gameSpawnerObj = GameObject.Find("GameSpawner");
        playerClass = player.GetComponent<Player>();
        gameSpawner = gameSpawnerObj.GetComponent<GameSpawner>();
        health = 100 * (int) gameSpawner.difficulty;
        //Physics2D.IgnoreCollision(GetComponent<PolygonCollider2D>(), playerNo.GetComponent<TilemapCollider2D>(),false);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            gameSpawner.enemyCount--;
            playerClass.scrap += 1;
        }
        Rigidbody2D rigid = GetComponent<Rigidbody2D>();
        Vector3 movePosition = transform.position;

        movePosition.x = Mathf.MoveTowards(transform.position.x, player.transform.position.x, speed);
        movePosition.y = Mathf.MoveTowards(transform.position.y, player.transform.position.y, speed);

        rigid.MovePosition(movePosition);
        rigid.velocity = Vector3.MoveTowards(transform.position, player.transform.position, speed);
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
        if (Vector3.Distance(transform.position,player.transform.position) < 5.3)
        {
            if (!touching.Contains(player))
            {
                touching.Add(player);
                StartCoroutine(dealDamage(damage * (int) gameSpawner.difficulty));
            }
        }
        else
        {
            touching.Remove(player);
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
