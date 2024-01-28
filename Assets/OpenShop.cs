using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class OpenShop : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject shop;
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public TextMeshProUGUI text;
    public GameObject gameSpawn;
    public bool freezeMovement = false;
    GameSpawner gameSpawner;
    void Start()
    {
        gameSpawner = gameSpawn.GetComponent<GameSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && gameSpawner.enemyCount <= 0)
        {
            shop.GetComponent<SpriteRenderer>().enabled = true;
            text.enabled = true;
            item1.GetComponent<SpriteRenderer>().enabled = true;
            item2.GetComponent<SpriteRenderer>().enabled = true;
            item3.GetComponent<SpriteRenderer>().enabled = true;
            freezeMovement= true;
        }
    }
}
