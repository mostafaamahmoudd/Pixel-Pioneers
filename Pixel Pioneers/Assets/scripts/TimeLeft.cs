using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimeLeft : MonoBehaviour
{
    private Text time1;
    [SerializeField] private float timer = 10f;

    [SerializeField] private Animator playerAnim;
    [SerializeField] private Rigidbody2D playerRB;
    [SerializeField] private AudioSource deathSoundEffect;

    public bool timeUp = false;

    void Start()
    {
        time1 = GetComponent<Text>();
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            time1.text = "Time Left : " + Mathf.Round(timer);
        }
        else
        {
            Die();
            timer = 10;
        }
    }

    public void Die()
    {
        deathSoundEffect.Play();
        playerAnim.SetTrigger("death");
        playerRB.bodyType = RigidbodyType2D.Static;
        Invoke("RestartLevel", 0.5f);
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
