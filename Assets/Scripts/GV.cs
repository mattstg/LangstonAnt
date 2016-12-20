using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GV : MonoBehaviour {

    public enum Cardinal { North, East, South, West }

    public static readonly int numOfColors = 50;
    public static readonly Vector2 worldSize = new Vector2(1024, 576) * .5f;
    public static List<Color> activeColors = new List<Color>();
    public static bool deleteMode = true;

    public static Cardinal AddCardinal(Cardinal c1, Cardinal c2)
    {
        int cardinalIntResult = (int)c1 + (int)c2;
        cardinalIntResult = cardinalIntResult % 4;
        return (Cardinal)cardinalIntResult;
    }

    public static Vector2 GetV2FromCardinal(Cardinal cardinal)
    {
        switch (cardinal)
        {
            case Cardinal.East:
                return new Vector2(1, 0);
            case Cardinal.North:
                return new Vector2(0, 1);
            case Cardinal.South:
                return new Vector2(0, -1);
            case Cardinal.West:
                return new Vector2(-1, 0);
            default:
                Debug.LogError("missing switch " + cardinal);
                return new Vector2(0, 0);
        }
    }
}
