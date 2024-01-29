using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public void setHealth(float health)
    {
        gameObject.GetComponent<Slider>().value = health;
    }
    public void setMaxHealth(float max)
    {
        gameObject.GetComponent<Slider>().maxValue = max;
    }
}
