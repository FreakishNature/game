using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field
{
    
    Dictionary<string, Side> sides = new Dictionary<string, Side>()
    {
        { "left", new Side() },
        { "right", new Side() }
    };

    public Dictionary<string, Side> Sides { get => sides; set => sides = value; }

    public void Setup(Tactic left, Tactic right)
    {
        foreach (string side in Sides.Keys)
        {
            Sides[side].Setup(side, left);
        }
    }

}
