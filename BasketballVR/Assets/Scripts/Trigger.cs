using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public AudioSource audioSource;
    public PlayerScript playerScript;
    public TextMeshProUGUI text;
    public GameObject effect;
    private int coins;

    private bool first = true;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball2"))
        {
            if(playerScript._change == true)
            {
                if (first)
                {
                    effect.SetActive(true);
                    playerScript._change = false;
                    first = false;

                    coins = int.Parse(text.text);
                    coins += 2;
                    text.text = coins.ToString();

                    audioSource.Play();
                    Invoke(nameof(ReSpawn), 8);
                }
            }
        }

        if (other.gameObject.CompareTag("Ball3"))
        {
            if (playerScript._change == true)
            {
                if (first)
                {
                    first = false;

                    coins = int.Parse(text.text);
                    coins += 3;
                    text.text = coins.ToString();

                    audioSource.Play();
                    Invoke(nameof(ReSpawn), 8);
                }
            }
        }
    }

    private void ReSpawn()
    {
        playerScript.Play();
        effect.SetActive(false);
        first = true;
    }
}
