using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwordArea : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> touching = new List<GameObject>();
    public GameObject walls;

    public GameObject swingArc;
    public Swing swing;

    public GameObject weapon;
    public SwingWeapon swingWeapon;

    public float cooldown = 0f;
    // Start is called before the first frame update
    void Start()
    {
        //Physics2D.IgnoreCollision(walls.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        swing = swingArc.GetComponent<Swing>();
        swingWeapon = weapon.GetComponent<SwingWeapon>();
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
                foreach (GameObject obj in touching)
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
            touching.Add(collision.gameObject);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject != player && collision.gameObject.GetComponent<Enemy>() != null)
        {
            touching.Remove(collision.gameObject);
        }
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
