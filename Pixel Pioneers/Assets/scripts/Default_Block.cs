using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Default_Block : MonoBehaviour
{
    public bool SmallMode = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && !SmallMode)
        {
            // give coins
            Debug.Log("coins ++");
            Destroy(gameObject);
        }
        else
        {
            // bounce
        }
    }
}
