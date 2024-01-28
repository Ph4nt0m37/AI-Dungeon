using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item1 : MonoBehaviour
{
    // Start is called before the first frame update
    Player player;
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
        if (Input.GetMouseButtonDown(0)) {
            if (player.scrap >= 15)
            {
                StartCoroutine(setColor(Color.green));
                if (player.weapon == player.slot1)
                {
                    player.setWeapon(player.slot2);
                    player.scrap -= 15;
                }
                else if (player.weapon == player.slot2)
                {
                    player.setWeapon(player.slot3);
                    player.scrap -= 15;
                }
                else
                {
                    StartCoroutine(setColor(Color.red));
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
