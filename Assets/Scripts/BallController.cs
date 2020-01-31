using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    public AudioClip pickupSound;

    private Rigidbody rb;
    private int count;

    AudioSource audio;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText ();
        winText.text = "";
        audio = GetComponent<AudioSource>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Pick Up"))
        {
            other.gameObject.SetActive (false);
            audio.PlayOneShot(pickupSound);
            count = count + 1;
            SetCountText ();
        }
    }

    void SetCountText ()
    {
        countText.text = "Count: " + count.ToString ();
        if (count >= 8)
        {
            winText.text = "You Win!";
        }
    }
}
