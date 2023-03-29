using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] private Animator flagAnimator;
    [SerializeField] private AudioSource flagAudio;
    [SerializeField] private Component[] componentsToDisable;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        flagAnimator.SetTrigger("Finish");
        flagAudio.Play();

        if (collision.CompareTag("Player"))
        {
            foreach (Component component in componentsToDisable)
            {
                Destroy(component);
            }
        }
    }
}
