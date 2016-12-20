using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pixel : MonoBehaviour  {

    public Color color;
    public SpriteRenderer sprite;

    public void ChangeColor(Color newColor)
    {
        color = newColor;
        sprite.color = color;
    }

    public Color GetColor()
    {
        return color;
    }
}
