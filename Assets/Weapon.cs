using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Weapon")]
public class Weapon : ScriptableObject
{
    public int damage;
    public int weight;
    public int shotsPerSecond;
    public int modeOfFire;
    public int accuracy;
    public int velocity;
    public int range;
    public int count;
    public float attackDelay;
    public int aoe;
    public string weaponType;
}
