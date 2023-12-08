using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeAttach : MonoBehaviour
{
    private AudioSource audioSource;
    private TextMeshProUGUI text;

    private float startTime = 24f;
    private float minutes;
    private float seconds;
    private PlayerScript playerScript;
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
        audioSource = gameObject.transform.parent.GetComponent<AudioSource>();
        playerScript = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        startTime -= Time.deltaTime;
        UpdateTimeText();
    }

    private void UpdateTimeText()
    {
        minutes = Mathf.FloorToInt(startTime / 60);
        seconds = Mathf.FloorToInt(startTime % 60);
        text.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (text.text == "00:00")
        {
            text.text = "00:00";

            if(playerScript._change == true)
            {
                playerScript._change = false;

                audioSource.Play();
                gameObject.SetActive(false);
                Invoke(nameof(ReSpawn), 3);
            }

        }
    }

    private void ReSpawn()
    {
        playerScript.Play();
        Destroy(gameObject.GetComponent<TimeAttach>());
    }
}
