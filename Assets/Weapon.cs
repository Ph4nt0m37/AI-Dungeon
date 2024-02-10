using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Weapon")]
public class Weapon : ScriptableObject
{
    public int damage;
    public int weight;
    public int shotsPerAttack = 1;
    public float delayBetweenAttacks = 0;
    public int accuracy;
    public int velocity;
    public float range;
    public int count;
    public float attackDelay;
    public int aoe;
    public string weaponType = "melee";
    public string specialAbility = "none";
}
