using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {

    public bool deleteMode = true;
    List<Ant> ants = new List<Ant>();
    Pixel[,] board = new Pixel[(int)GV.worldSize.x, (int)GV.worldSize.y];


	// Use this for initialization
	void Start () {
        GV.deleteMode = deleteMode;

        for (int i = 0; i < GV.numOfColors; i++)
            AddRandomColor();
        GV.activeColors.Add(Color.white);

        for(int x = 0; x < GV.worldSize.x; x++)
            for (int y = 0; y < GV.worldSize.y; y++)
                board[x, y] = null;

        Vector2 lastPos = new Vector2(GV.worldSize.x / 2, GV.worldSize.y / 2);
        for (int i = 0; i < GV.numOfColors; i++)
        {
            Vector2 startPos = new Vector2(Random.Range(0, (int)GV.worldSize.x), Random.Range(0, (int)GV.worldSize.y));
            //Vector2 offset = new Vector2(Random.Range(-1, (int)2), Random.Range(-1, (int)2));
            Ant ant = new Ant(GV.activeColors[i], startPos, this);
            ants.Add(ant);
            //lastPos = lastPos + offset;
        }
    }

    public Color GetColor(Vector2 v2)
    {
        if (board[(int)v2.x, (int)v2.y] == null)
        {
            return Color.white;
        }
        //Debug.Log("board " + v2 + " contains the color " + board[(int)v2.x, (int)v2.y].GetColor());
        return board[(int)v2.x, (int)v2.y].GetColor();
    }

    public void SetColor(Vector2 v2, Color color)
    {
        if (board[(int)v2.x, (int)v2.y] == null)
        {
            GameObject go = Instantiate(Resources.Load("Prefabs/pixel")) as GameObject;
            go.transform.position = new Vector3(v2.x, v2.y, 0);
            board[(int)v2.x, (int)v2.y] = go.GetComponent<Pixel>();
            
           // Debug.Log("color at " + v2 + " set to " + color);
        }
        board[(int)v2.x, (int)v2.y].ChangeColor(color);
    }

    public void RemoveTile(Vector2 v2)
    {
        Destroy(board[(int)v2.x, (int)v2.y].gameObject);
        board[(int)v2.x, (int)v2.y] = null;
    }

    // Update is called once per frame
    void Update () {
        foreach (Ant ant in ants)
            ant.Update();
	}

    public void AddRandomColor()
    {
        int count = 0;
        Color newColor = new Color();
        while(count < 9999)
        {
            newColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            if (GV.activeColors.Contains(newColor) || newColor == Color.white)
                count++;
            else
            {
                GV.activeColors.Add(newColor);
                break; //l eaves loop
            }
        }
    }
}
