using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private int points;
    private Rigidbody2D rb2d;
    public  TextMeshProUGUI text;
    public GameObject tetherPoint;
    private Transform tetherPosition;
    [SerializeField] private  float distanceFromShip;
    // Use this for initialization
    void Start()
    {
        tetherPosition = tetherPoint.GetComponent<Transform>();
        points = 0;
        text.text = points.ToString();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
        Debug.Log(Vector3.Distance(this.gameObject.transform.position, tetherPosition.position));
        if (Vector3.Distance(this.gameObject.transform.position, tetherPosition.position) > distanceFromShip)
        {

            rb2d.velocity = (tetherPosition.position - this.gameObject.transform.position).normalized * 8f;

        }
    }

    public void AddPoints()
    {
        points += 10;
        text.text = points.ToString();

    }

    public void DetractPoints(int p)
    {
        points -= p;
        text.text = points.ToString();
    }
}
