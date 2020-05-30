using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Cell
{
    Unit unit = null;
    string side;                         
    GameObject character;
    GameObject prefab;
    GameObject cell;
    KombatSystem kombatSystem;

    // just for debugging
    int index;
    public Cell(GameObject cell,string side,int i)
    {
        this.cell = cell;
        this.side = side;
        index = i;
    }


    public bool DealDmg()
    {
        if(kombatSystem == null)
        {
            kombatSystem = (KombatSystem)UnityEngine.Object.FindObjectOfType(typeof(KombatSystem));
        }

        // Assasin is able to select target to attack, that's why we use SelectTarget
        // SelectTarget returns array [0] = side [1] = index;
        if(unit != null && unit.IsAlive)
        {
            kombatSystem.SendDmg(side, unit.Class == Unit.GamingClass.ASSASIN ?
                kombatSystem.SelectTarget()[1] : "1",
                unit.Damage
            );
            return true;
        }

        return false;
    }

    public bool TakeDmg(int dmg)
    {
        if (unit != null && unit.IsAlive)
        {
            unit.HealthPoints -= dmg;

            Debug.Log($"{side}_{index} = ${unit.HealthPoints}");

            if (!unit.IsAlive)
            {
                UnitDelete();
            }
            return true;
        }
        return false;
    }

    public void setUnit(string prefabPath)
    {
        unit = new Unit();
        prefab = Resources.Load("Characters/" + prefabPath) as GameObject;
        
        character = UnityEngine.Object.Instantiate(prefab, Vector3.zero, Quaternion.identity) as GameObject;
  
        character.transform.parent = cell.transform;
        character.transform.localPosition = new Vector3(0,0,-2);
        character.transform.localScale = new Vector3(2, 2, 1);
    }

    public void mirror()
    {
        if (character)
        {
            character.transform.localRotation = new Quaternion(0,90,0,0);
        }
    }
    public void UnitDelete()
    {
        unit = null;
        UnityEngine.Object.Destroy(character);
    }
}
