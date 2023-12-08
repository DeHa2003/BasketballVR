using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public PlayerScript playerScript;
    public AudioSource autSource;
    public AudioSource polSource;

    private bool first = true;

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (playerScript._change == true)
            {
                if (first)
                {
                    first = false;

                    playerScript._change = false;
                    autSource.Play();
                    Invoke(nameof(ReSpawn), 2);
                }
            }
        }

        if (collision.gameObject.CompareTag("Pol"))
        {
            float a = gameObject.GetComponent<Rigidbody>().velocity.magnitude;
            polSource.volume = a / 10;
            if(a / 10 >= 1)
            {
                polSource.volume = 1;
            }
            polSource.Play();

        }
    }

    private void ReSpawn()
    {
        playerScript.Play();
        first = true;
    }
}
