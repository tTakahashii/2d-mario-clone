using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private CameraShake camShake;
    [SerializeField] private float xMinMax = 0.25f, yMinMax = 0.25f, shakeDuration = 0.25f, shakePerSecond = 40f;
    [SerializeField] private Transform beginningOfTheLevel;
    [SerializeField] private BoxCollider2D playerCollider;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private AudioSource playerSouce;
    [SerializeField] private AudioClip[] deathClips;

    private bool isDead = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Death Trigger") && !isDead)
        {
            playerRb.bodyType = RigidbodyType2D.Static;
            playerAnimator.SetTrigger("die");
            GameManager.MusicManager.StopMusic();

            foreach (AudioClip deathClip in deathClips)
            {
                playerSouce.PlayOneShot(deathClip);
            }

            playerCollider.enabled = false;
            isDead = true;
            StartCoroutine(camShake.Shake(xMinMax, yMinMax, shakeDuration, shakePerSecond));
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Death Trigger") && !isDead)
        {
            playerRb.bodyType = RigidbodyType2D.Static;
            playerAnimator.SetTrigger("die");
            GameManager.MusicManager.StopMusic();

            foreach (AudioClip deathClip in deathClips)
            {
                playerSouce.PlayOneShot(deathClip);
            }

            playerCollider.enabled = false;
            isDead = true;
            StartCoroutine(camShake.Shake(0.25f, 0.25f, 0.25f, 25f));
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
