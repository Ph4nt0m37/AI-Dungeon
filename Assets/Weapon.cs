using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Weapon")]
public class Weapon : ScriptableObject
{
    public int damage;
    public int shotsPerSecond;
    public int modeOfFire;
    public int accuracy;
    public int velocity;
    public int weight;
    public int range;
    public int count;
    public float attackDelay;
    public int aoe;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
