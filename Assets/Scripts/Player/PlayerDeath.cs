using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private AudioSource playerSouce;
    [SerializeField] private AudioClip[] deathClips;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Death Trigger"))
        {
            playerRb.bodyType = RigidbodyType2D.Static;
            playerAnimator.SetTrigger("die");

            foreach (AudioClip deathClip in deathClips)
            {
                playerSouce.PlayOneShot(deathClip);
            }          
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Death Trigger"))
        {
            playerRb.bodyType = RigidbodyType2D.Static;
            playerAnimator.SetTrigger("die");

            foreach (AudioClip deathClip in deathClips)
            {
                playerSouce.PlayOneShot(deathClip);
            }
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
