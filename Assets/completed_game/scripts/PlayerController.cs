using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 0;
    public TextMeshProUGUI CountText;
    public GameObject winTextObject;
    public AudioSource tick;
    //public Material[] material;
    //Renderer rend;

    private Rigidbody rb;
    private int count;
    private float movementX;
    private float movementY;

    // Start is called before the first frame update
    void Start()
    {
        //rend = GetComponent<Renderer>();
        //rend.enabled = true;
        tick = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        count = 0;

        SetCountText();

        // Set the text property of the Win Text UI to an empty string, making the 'You Win' (game over message) blank
        winTextObject.SetActive(false);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            //int i = Random.Range(0, 4);
            //rend.sharedMaterial = material[i];
            tick.Play();
            other.gameObject.SetActive(false);
            count = count + 10;

            // Run the 'SetCountText()' function (see below)
            SetCountText();

        }
        
    }

    

    void SetCountText()
    {
        CountText.text = "Count: " + count.ToString();

        if (count >= 740)
        {
            // Set the text value of your 'winText'
            winTextObject.SetActive(true);
        }
    }

}
