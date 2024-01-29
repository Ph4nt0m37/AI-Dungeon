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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            shop.GetComponent<SpriteRenderer>().enabled = false;
            text.enabled = false;
            item1.SetActive(false);
            item2.SetActive(false);
            item3.SetActive(false);
            freezeMovement = false;
        }
    }
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && gameSpawner.enemyCount <= 0)
        {
            shop.GetComponent<SpriteRenderer>().enabled = true;
            text.enabled = true;
            item1.SetActive(true);
            item2.SetActive(true);
            item3.SetActive(true);
            freezeMovement= true;
        }
    }
}
