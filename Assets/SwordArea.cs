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
