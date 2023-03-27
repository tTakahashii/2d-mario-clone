using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playerRb;
    [SerializeField] private Animator playerAnimator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Trap"))
        {
            playerRb.bodyType = RigidbodyType2D.Static;
            playerAnimator.SetTrigger("die");
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
