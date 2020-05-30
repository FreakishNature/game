using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit
{
    public enum GamingClass
    {
        ASSASIN, WARRIOR, TANK, ARCHER, MAGE 
    }

    int healthPoints = 100;
    int armor;
    int damage = 10;
    GamingClass gamingClass = GamingClass.WARRIOR;

    public bool IsAlive => HealthPoints > 0;

    public int Damage { get => damage; set => damage = value; }
    public int HealthPoints { get => healthPoints; set => healthPoints = value; }
    public GamingClass Class { get => gamingClass; set => gamingClass = value; }
}
