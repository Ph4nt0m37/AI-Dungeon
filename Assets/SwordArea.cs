using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwordArea : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> touching2 = new List<GameObject>();
    public GameObject walls;

    public GameObject swingArc;
    public Swing swing;

    public GameObject weapon;
    public SwingWeapon swingWeapon;

    public GameObject shop;
    public OpenShop openShop;

    public bool isEnabled = false;

    public float cooldown = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //Physics2D.IgnoreCollision(walls.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        swing = swingArc.GetComponent<Swing>();
        swingWeapon = weapon.GetComponent<SwingWeapon>();
        openShop = shop.GetComponent<OpenShop>();
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.position = new Vector3(player.transform.position.x + 0.41f, player.transform.position.y, player.transform.position.z);
    }
    public void attack()
    {
        if (cooldown <= 0)
        {
            swing.swing();
            try
            {
                foreach (GameObject obj in touching2)
                {
                    StartCoroutine(dealDamage(player.GetComponent<Player>().weapon.damage,obj));
                }
                cooldown = player.GetComponent<Player>().weapon.attackDelay;
                Debug.Log(cooldown);
                StartCoroutine(decreaseCooldown(cooldown));
            }
            catch { }
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != player && collision.gameObject.GetComponent<Enemy>() != null)
        {
            touching2.Add(collision.gameObject);
        }
       //GetComponent<CircleCollider2D>().enabled = false;
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject != player && collision.gameObject.GetComponent<Enemy>() != null)
        {
            touching2.Remove(collision.gameObject);
        }
        //GetComponent<CircleCollider2D>().enabled = true;
    }

    IEnumerator decreaseCooldown(float cooldown2)
    {
        yield return new WaitForSeconds(cooldown2);
        cooldown = 0f;
    }

    IEnumerator dealDamage(float damage, GameObject obj)
    {
        obj.gameObject.GetComponent<Enemy>().health -= player.GetComponent<Player>().weapon.damage;
        if (obj != null)
        {
            obj.GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(0.25f);
            try
            {
                obj.GetComponent<SpriteRenderer>().color = Color.white;
            }catch{

            }
        }
    }
}
