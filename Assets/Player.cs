using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;
using UnityEditor.Experimental.GraphView;
using System.Net.Sockets;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject swordArea;
    public SwordArea swordAreaClass;
    public float playerSpeed = 4f;
    public GameObject cam;
    public Weapon weapon;
    public GameObject swordStuff;

    public int health = 100;
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

    public GameObject stick;
    public GameObject gameSpawnerObj;
    public GameSpawner gameSpawner;
    public Sprite deadTexture;

    public int scrap;
    public TextMeshProUGUI scrapText;

    // Start is called before the first frame update
    void Start()
    {
        openShop = shop.GetComponent<OpenShop>();
        gameSpawner = gameSpawnerObj.GetComponent<GameSpawner>();
        swordAreaClass = swordArea.GetComponent<SwordArea>();
        weapon = slot1;
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
            swordAreaClass.attack();
        }
    }
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("SampleScene");
    }
    public void setWeapon(Weapon weapon2)
    {
        weapon = weapon2;
        if (weapon2==slot2)
        {
            stick.GetComponent<SpriteRenderer>().sprite = sprite2;
        }
        if (weapon2 == slot3)
        {
            stick.GetComponent<SpriteRenderer>().sprite = sprite3;
        }
    }
}
