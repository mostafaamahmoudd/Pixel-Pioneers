using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.CanvasScaler;

public class MysteryBlock : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefabs; // will be an array for the multi type of collictables ...
    //[SerializeField] private bool canSpawn = true;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Instantiate(enemyPrefabs, transform.position, Quaternion.identity); // spawnning collictables
            Destroy(gameObject);
        }
    }

}
