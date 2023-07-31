using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private Text appleText;
    [SerializeField] private AudioSource collectSoundEffect;
    [SerializeField] private AudioSource healSoundEffect;


    private int apples = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            apples++;
            appleText.text = "Apples : " + apples;
        }
        else if (collision.gameObject.CompareTag("Health"))
        {
            healSoundEffect.Play();
        }
    }
}
