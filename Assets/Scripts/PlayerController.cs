using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    private Rigidbody2D body2D;
    private int count;
	// Use this for initialization
	void Start ()
    {
        body2D = GetComponent<Rigidbody2D>();
        count = 0;
        winText.text = "";
        SetCountText();
    }

    // Update is called once per frame
    void Update ()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        if (Input.GetKeyDown("space"))
            body2D.AddForce(movement * speed * 50);
        else
            body2D.AddForce(movement * speed);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            count++;
            other.gameObject.SetActive(false);
            SetCountText();
        }
    }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
            winText.text = "You win!";
    }


}
