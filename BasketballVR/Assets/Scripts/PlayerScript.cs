using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
using Vector3 = UnityEngine.Vector3;

public class PlayerScript : MonoBehaviour
{
    public SteamVR_Action_Vector2 action;
    public GameObject ball;
    public float speed = 2;

    private Hand hand;
    private float sec = 0;
    public bool komand = false;   //komand = false - (A); komand = true - (B)

    [Header("BasketBall")]
    public Transform spawnKomandA;
    public Transform spawnKomandB;

    public GameObject textTimeA;
    public GameObject textTimeB;

    public TextMeshProUGUI schetA;
    public TextMeshProUGUI schetB;

    public GameObject kolcoA;
    public GameObject kolcoB;

    [Header("Стрелки")]
    public GameObject goA;
    public GameObject goB;

    public AudioSource audioSource;

    public bool _change = true;

    //public bool _change = true;

    private void Start()
    {
        Play();
    }
    // Update is called once per frame
    void Update()
    {
        if (action != null)
        {
            Vector3 vector = Player.instance.hmdTransform.TransformDirection(new Vector3(action.axis.x, 0, action.axis.y));
            transform.position += Vector3.ProjectOnPlane(vector * Time.deltaTime * speed, Vector3.up);
        }
        Beg();
    }

    private void Beg()
    {
        if (ball.GetComponent<Throwable>().attached)
        {
            hand = ball.transform.parent.GetComponent<Hand>();
        }
    }

    public void Play()
    {
        _change = true;

        if(hand != null)
        {
            hand.DetachObject(ball, ball.GetComponent<Throwable>().restoreOriginalParent);

        }

        //Inverse komand
        komand = !komand;

        //Ball transform
        ball.transform.position = new Vector3(0, 0.5f, 0);
        ball.GetComponent<Rigidbody>().isKinematic = true;
        ball.GetComponent<Rigidbody>().isKinematic = false;

        //Komand A
        if (komand == false)
        {
            //Spawn Player
            gameObject.transform.position = spawnKomandA.transform.position;

            //Time
            textTimeA.SetActive(true);
            textTimeA.AddComponent<TimeAttach>();
            textTimeB.SetActive(false);
            Destroy(textTimeB.GetComponent<TimeAttach>());

            //Trigger ochki
            kolcoA.SetActive(false);
            kolcoB.SetActive(true);

            //Naprav
            goB.SetActive(true);
            goA.SetActive(false);
        }
        //Komand B
        else if(komand == true)
        {
            //Spawn Player
            gameObject.transform.position = spawnKomandB.transform.position;


            textTimeB.SetActive(true);
            textTimeB.AddComponent<TimeAttach>();
            textTimeA.SetActive(false);
            Destroy(textTimeA.GetComponent<TimeAttach>());

            //Trigger ochki
            kolcoA.SetActive(true);
            kolcoB.SetActive(false);

            //Naprav
            goA.SetActive(true);
            goB.SetActive(false);
        }
    }
}
