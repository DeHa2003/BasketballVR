using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerShit : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if(collision.gameObject.CompareTag("Ball2") || collision.gameObject.CompareTag("Ball3"))
        {
            audioSource.Play();
        }
    }
}
