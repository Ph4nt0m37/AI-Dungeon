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
    // Start is called before the first frame update
    void Start()
    {
        //Physics2D.IgnoreCollision(walls.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        swing = swingArc.GetComponent<Swing>();
    }

    // Update is called once per frame
    void Update()
    {
        //gameObject.transform.position = new Vector3(player.transform.position.x + 0.41f, player.transform.position.y, player.transform.position.z);
    }
    public void attack()
    {
        swing.swing();
        try
        {
            foreach (GameObject obj in touching)
            {
                obj.gameObject.GetComponent<Enemy>().health -= player.GetComponent<Player>().weapon.damage;
            }
        }
        catch {}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != player && collision.gameObject.GetComponent<Enemy>() != null)
        {
            touching.Add(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject != player && collision.gameObject.GetComponent<Enemy>() != null)
        {
            touching.Remove(collision.gameObject);
        }
    }
}
