using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwordArea : MonoBehaviour
{
    public GameObject player;
    public List<GameObject> touching = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(player.transform.position.x + 0.41f, player.transform.position.y, player.transform.position.z);
    }
    public void attack()
    {
        try
        {
            foreach (GameObject obj in touching)
            {
                Destroy(obj);
            }
        }
        catch {}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        {
            if (collision.gameObject != player)
            {
                touching.Add(collision.gameObject);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        {
            if (collision.gameObject != player)
            {
                touching.Remove(collision.gameObject);
            }
        }
    }

}
