using System.Collections;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;

using System.Net.Sockets;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject swordArea;
    public SwordArea swordAreaClass;
    public GameObject swing;
    public float playerSpeed = 4f;
    public GameObject cam;
    public Weapon weapon;
    public GameObject swordStuff;

    public float maxHealth = 100f;
    public float health = 100f;
    public Healthbar healthBar;
    public GameObject healthBarObj;

    public TextMeshProUGUI healthText;
    public TextMeshProUGUI diedText;

    public GameObject shop;
    public OpenShop openShop;

    public Weapon slot1;
    public Weapon slot2;
    public Sprite sprite2;
    public Weapon slot3;
    public Sprite sprite3;

    public List<Weapon> weaponsRanking = new List<Weapon>();
    public List<Sprite> spritesRanking = new List<Sprite>();

    public GameObject stick;
    public GameObject gameSpawnerObj;
    public GameSpawner gameSpawner;
    public Sprite deadTexture;

    public int scrap;
    public TextMeshProUGUI scrapText;

    public bool spin = true;
    float rotationZ;

    public bool onCooldown = false;

    // Start is called before the first frame update
    void Start()
    {
        openShop = shop.GetComponent<OpenShop>();
        gameSpawner = gameSpawnerObj.GetComponent<GameSpawner>();
        swordAreaClass = swordArea.GetComponent<SwordArea>();
        weapon = weaponsRanking[0];
        healthBar = healthBarObj.GetComponent<Healthbar>();
        //Physics2D.IgnoreCollision(swordArea.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.setHealth(health);

        healthText.text = health.ToString();

        scrapText.text = scrap.ToString()+" Scrap";

        swordStuff.transform.position = gameObject.transform.position;
        if (spin)
        {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - swordStuff.transform.position;

            difference.Normalize();

            rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            swordStuff.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        }
        if (rotationZ <= 90 && rotationZ >= -90)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        Rigidbody2D rigid = gameObject.GetComponent<Rigidbody2D>();
        
        if (health <= 0f)
        {
            GetComponent<SpriteRenderer>().sprite = deadTexture;
            //diedText.enabled = true;
            StartCoroutine(Respawn());
        }
        if (Input.GetKey(KeyCode.D) && health>0 && !openShop.freezeMovement)
        {
            rigid.velocity = new Vector2(playerSpeed, rigid.velocity.y);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            /*if (rigid.velocity.y > 0f && rigid.velocity.x > 0f)
            {
                playerSpeed /= 2;
            }
            else
            {
                playerSpeed = 
            }*/
        }
        if (Input.GetKey(KeyCode.A) && health > 0 && !openShop.freezeMovement)
        {
            rigid.velocity = new Vector2(-1* playerSpeed, rigid.velocity.y);
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        if (Input.GetKey(KeyCode.S) && health > 0 && !openShop.freezeMovement)
        {
            rigid.velocity = new Vector2(rigid.velocity.x,-1* playerSpeed);
        }
        if (Input.GetKey(KeyCode.W) && health > 0 && !openShop.freezeMovement)
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
            if (!onCooldown)
            {
                StartCoroutine(startAttacks(weapon.delayBetweenAttacks));
            }
        }
        if (Input.GetKeyDown(KeyCode.Home))
        {
            maxHealth += 10000;
            health += 10000;
            scrap += 10000;
        }
    }
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Title");
    }
    public IEnumerator takeDamage()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.25f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    public void setWeapon(Weapon weapon2,Sprite sprite)
    {
        weapon = weapon2;
        stick.GetComponent<SpriteRenderer>().sprite = sprite;
        if (weapon2.weaponType == "melee")
        {
            spin = false;
            swordStuff.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            float oldRadius = swordArea.transform.localScale.x;
            swordArea.transform.localScale = new Vector3(weapon.range, weapon.range, weapon.range);
            swing.transform.localScale = new Vector3(weapon.range / 2, weapon.range / 2, weapon.range / 2);
            swordArea.transform.Translate(new Vector3((weapon.range - oldRadius) / 1.6f, 0, 0));
            //swing.transform.Translate(new Vector3((weapon.range - oldRadius) / 0.45f, 0, 0));
            Debug.Log($"oldRad = {oldRadius} | newRad = {weapon.range} | radDif = {weapon.range - oldRadius}");
            spin = true;
        }
        else if (weapon2.weaponType == "gun")
        {

        }
    }
    IEnumerator attackCooldownTimer(float cooldown)
    {
        onCooldown = true;
        yield return new WaitForSeconds(cooldown);
        onCooldown = false;
    }
    IEnumerator startAttacks(float attackCooldown)
    {
        StartCoroutine(attackCooldownTimer(weapon.attackDelay));
        for (int i = 0; i < weapon.shotsPerAttack; i++)
        {
            swordAreaClass.attack();
            yield return new WaitForSeconds(attackCooldown);
        }
    }
}
