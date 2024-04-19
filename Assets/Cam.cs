using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public GameObject shop;
    public OpenShop openShop;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        openShop = shop.GetComponent<OpenShop>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!openShop.freezeMovement)
        {
            gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);
        }
        else
        {
            gameObject.transform.position = new Vector3(0, 0, - 10);
        }
    }
}
