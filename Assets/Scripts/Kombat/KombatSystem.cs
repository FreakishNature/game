using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KombatSystem : MonoBehaviour
{
    Field field;
    public float BATTLE_SPEED = 0.03f;
    bool isRunning = true;

    void Start()
    {
        field = new Field();
        field.Setup(
            new Tactic(new Tactic.CharacterData[]{
                new Tactic.CharacterData("1","1"),
                new Tactic.CharacterData("2","4"),
                new Tactic.CharacterData("4","7"),
                new Tactic.CharacterData("5","8")
             }),
             new Tactic(new Tactic.CharacterData[]{
                new Tactic.CharacterData("4","1"),
                new Tactic.CharacterData("5","4"),
                new Tactic.CharacterData("1","7"),
                new Tactic.CharacterData("6","5")
             })
        );

        StartCoroutine(InvokeAttack());

    }


    IEnumerator InvokeAttack()
    {
        while (isRunning)
        {
            foreach(string side in field.Sides.Keys)
            {
                foreach (string key in field.Sides[side].Cells.Keys)
                {
                    field.Sides[side].Cells[key].DealDmg();
                    yield return new WaitForSeconds(BATTLE_SPEED);
                }

            }
        }
    }

    public string[] SelectTarget()
    {
        string selected = "right_4";
        return selected.Split('_');
    }

    public void SendDmg(string fromSide, string cell, int dmg)
    {
        string opponentSide = Globals.Sides.GetOpositeSide(fromSide);
        field.Sides[opponentSide].TakeDmg(cell,dmg);  
    }

    public void ShowWinner(string side)
    {
        Debug.Log(Globals.Sides.GetOpositeSide(side) + " side won");
        isRunning = false;
        StopCoroutine(InvokeAttack());
    }

}
