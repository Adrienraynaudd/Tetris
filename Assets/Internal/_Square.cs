using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Square : MonoBehaviour
{
    public SquareColor color = SquareColor.TRANSPARENT;
    private Color actualColor {
        get {
            return getColor();
        }
    }
    private new SpriteRenderer renderer = null;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(renderer){
            renderer.color = actualColor;
        }
    }

    private Color getColor(){
        switch(color){
            case SquareColor.BACKGROUND:
            return new Color(0.00f,0.17f,0.24f,0.70f); //#001724
            case SquareColor.DEEP_BLUE:
            return new Color(0.15f,0.67f,0.60f);
            case SquareColor.GREEN:
            return new Color(0.08f,0.78f,0.40f);
            case SquareColor.ORANGE:
            return new Color(0.78f,0.54f,0.08f);
            case SquareColor.PURPLE:
            return new Color(0.38f,0.32f,0.8f);
            case SquareColor.YELLOW:
            return new Color(0.8f,0.73f,0.17f);
            case SquareColor.RED:
            return new Color(0.69f,0.16f,0.09f);
            case SquareColor.PINK:
            return new Color(0.8f,0.17f,0.8f);
            case SquareColor.TRANSPARENT:
            default:
            return new Color(0.0f,0.0f,0.0f,0.0f);
        }
    }
}
