using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Globals
{
    static public class Sides
    {
        public const string LEFT = "left";
        public const string RIGHT = "right";
        public static string GetOpositeSide(string side)
        {
            return side == Globals.Sides.LEFT ? Globals.Sides.RIGHT : Globals.Sides.LEFT;
        }
    }
    public const int AMOUNT_OF_CELLS = 9;
}
