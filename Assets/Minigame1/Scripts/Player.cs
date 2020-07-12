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
    private Vector2 storeVelocity;
    private float storeAngularVel;
    private Animator animator;
    public  TextMeshProUGUI text;
    public GameObject tetherPoint;
    private Transform tetherPosition;
    [SerializeField] private  float distanceFromShip;
    // Use this for initialization
    void Awake()
    {
        animator = GetComponent<Animator>();
        tetherPosition = tetherPoint.GetComponent<Transform>();
        points = 0;
        text.text = points.ToString();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (GameState.isPlaying)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            rb2d.AddForce(movement * speed);
            if (Input.GetKeyDown("e"))
            {
                rb2d.AddTorque(-5.0f);
            }
            if (Input.GetKeyDown("q"))
            {
                rb2d.AddTorque(5.0f);
            }
            if (Vector3.Distance(this.gameObject.transform.position, tetherPosition.position) > distanceFromShip)
            {

                rb2d.velocity = (tetherPosition.position - this.gameObject.transform.position).normalized * 2f;

            }
        }
        else
        {
            rb2d.velocity = Vector2.zero; 
            rb2d.angularVelocity = 0f;
        }
    }

    public void AddPoints()
    {
        animator.SetTrigger("IsFix");
        points += 10;
        text.text = points.ToString();

    }

    public void DetractPoints(int p)
    {
        if (p == 15)
        {
            animator.SetTrigger("Ishit");
        }
        points -= p;
        text.text = points.ToString();
    }

    public void StoreMomentum()
    {
        storeVelocity = rb2d.velocity;
        storeAngularVel = rb2d.angularVelocity;
    }
    public void LoadMomentum()
    {
        rb2d.velocity = storeVelocity;
        rb2d.angularVelocity = storeAngularVel;
    }
}
