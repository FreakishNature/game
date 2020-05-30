using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEngine;

public class Side
{
    string side;
    Dictionary<string,Cell> cells = new Dictionary<string, Cell>();

    public Dictionary<string, Cell> Cells { get => cells; set => cells = value; }

    public void TakeDmg(string cell,int dmg)
    {
        int index = int.Parse(cell);
        // in cycle attacks first available cell, if it does not have unit will return false
        // and cycle will continue until it will find cell with unit or will iterate over every cell
        do
        {
            if(index > Globals.AMOUNT_OF_CELLS)
            {
                ((KombatSystem)UnityEngine.Object.FindObjectOfType(typeof(KombatSystem))).ShowWinner(side);
                break;
            }

        } while (!cells[$"{side}_{index++}"].TakeDmg(dmg));

    }

    public void Setup(string side,Tactic tactic)
    {
        this.side = side;
        for(int i = 1; i <= Globals.AMOUNT_OF_CELLS; i++)
        {
            Cells[$"{side}_{i}"] = new Cell(
                GameObject.FindGameObjectWithTag($"{side}_{i}"),
                side,
                i
            );
        }

        foreach (Tactic.CharacterData cd in tactic.CharacterDatas) {

            Cells[$"{side}_{cd.Position}"].setUnit(cd.Prefab);

            if (side == Globals.Sides.RIGHT)
            {
                Cells[$"{side}_{cd.Position}"].mirror();
            }
        }
    }
}
