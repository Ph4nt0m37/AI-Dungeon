using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> touching = new List<GameObject>();

    public Weapon weapon;

    public float strength = 8f;
    public float speed = 3f;
    public int health = 100;

    public GameObject gameSpawnerObj;
    public GameObject swordArea;
    public GameSpawner gameSpawner;
    public SwordArea swordAreaClass;

    public Player playerClass;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        gameSpawnerObj = GameObject.Find("GameSpawner");
        swordArea = GameObject.Find("SwordArea");
        playerClass = player.GetComponent<Player>();
        gameSpawner = gameSpawnerObj.GetComponent<GameSpawner>();
        swordAreaClass = swordArea.GetComponent<SwordArea>();
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
            //swordAreaClass.touching2.Remove(gameObject);
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
        if (weapon.weaponType == "gun")
        {

        }
        if (weapon.weaponType == "melee")
        {
            if (Vector3.Distance(transform.position, player.transform.position) < weapon.range)
            {
                if (!touching.Contains(player))
                {
                    touching.Add(player);
                    StartCoroutine(dealDamage(Mathf.RoundToInt(weapon.damage * gameSpawner.difficulty * strength)));
                }
            }
            else
            {
                touching.Remove(player);
            }
        }
    }

    IEnumerator dealDamage(float damage)
    {
        if (touching.Contains(player))
        {
            player.GetComponent<Player>().health -= damage;
            StartCoroutine(player.GetComponent<Player>().takeDamage());
            yield return new WaitForSeconds(weapon.attackDelay);
            StartCoroutine(dealDamage(damage));
        }
    }
    public IEnumerator takeDamage(int damage, GameObject bullet)
    {
        health -= damage;
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.25f);
        try
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
        catch
        {}
        if (bullet!=null) { 
            Destroy(bullet);
        }
    }
}
