using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Controller : MonoBehaviour
{
    private enum Modes { _default, white, speed }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Modes mode;

        if (collision.gameObject.name == "Mushroom")
        {
            mode = Modes._default;
        } 
        else if (collision.gameObject.name == "Flower")
        {
            mode = Modes.white;
        }
        else
        {
            mode = Modes.speed;
        }
    }
}
