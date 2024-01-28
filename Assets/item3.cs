using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item3 : MonoBehaviour
{
    Player player;
    public Healthbar healthBar;
    public GameObject healthBarObj;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        healthBar = healthBarObj.GetComponent<Healthbar>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (player.scrap >= 10)
            {
                StartCoroutine(setColor(Color.green));
                player.maxHealth += 10;
                player.scrap -= 10;
                healthBar.setMaxHealth(player.maxHealth);
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
