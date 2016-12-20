using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant {

    GV.Cardinal faceDir = GV.Cardinal.North;
    Vector2 pos;
    Board board;
    Color color;
    Dictionary<Color, bool> rules = new Dictionary<Color, bool>();

    public Ant(Color _color, Vector2 _pos, Board _board)
    {
        color = _color;
        pos = _pos;
        board = _board;
        for (int i = 0; i < GV.activeColors.Count; i++)
        {
            bool b = (Random.Range(0, 1) > .5f);
            rules.Add(GV.activeColors[i], b);
        }
        rules[Color.white] = !rules[color];
        //PrintRuleSet();
    }

    public void Update()
    {
        Color tileColor = board.GetColor(pos);
        bool turnRight = rules[tileColor];
        //Debug.Log("Ant detects tile color " + tileColor + " at pos " + pos + " currently facing " + faceDir);
        if(turnRight)
        {
           // Debug.Log("turnRight");
            faceDir = GV.AddCardinal(faceDir, GV.Cardinal.East); 
        }
        else
        {
           // Debug.Log("turnLeft");
            faceDir = GV.AddCardinal(faceDir, GV.Cardinal.West);
        }

        if (GV.deleteMode)
        {
            if (board.GetColor(pos) != Color.white)
                board.RemoveTile(pos);
            else
                board.SetColor(pos, color);
        }
        else
        {
            if (board.GetColor(pos) == color)
                board.RemoveTile(pos);
            else
                board.SetColor(pos, color);
        }

        Vector2 moveDir = GV.GetV2FromCardinal(faceDir);
        //Debug.Log("move dir calculated to be: " + moveDir + " resulting in facedir " + faceDir);
        pos = moveDir + pos;
       // Debug.Log("ant new pos: " + pos);

        if (pos.x < 0)
            pos.x = GV.worldSize.x - 1;
        if (pos.x >= GV.worldSize.x)
            pos.x = 0;
        if (pos.y < 0)
            pos.y = GV.worldSize.y - 1;
        if (pos.y >= GV.worldSize.y)
            pos.y = 0;

        
    }

    public void PrintRuleSet()
    {
        string totalRuleset = "";
        foreach (KeyValuePair<Color, bool> kv in rules)
            totalRuleset += " <" + kv.Key + "," + kv.Value + ">,";
        Debug.Log("ruleSet for color " + color + ":" + totalRuleset);
    }
}
