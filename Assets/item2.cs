using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class item2 : MonoBehaviour
{
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (player.scrap >= 3)
            {
                StartCoroutine(setColor(Color.green));
                if (player.health + (player.health / 2)+5 < player.maxHealth)
                {
                    player.health += (player.health / 2)+5;
                    player.scrap -= 3;
                }
                else
                {
                    if (player.health!=player.maxHealth)
                    {
                        player.health = player.maxHealth;
                    }
                    else
                    {
                        StartCoroutine(setColor(Color.red));
                    }
                }
            }
            else
            {
                StartCoroutine(setColor(Color.red));
            }
        }
    }
    IEnumerator setColor(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.10f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
