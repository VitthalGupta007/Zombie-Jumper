using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveforce = 10f;
    [SerializeField]
    private float jumpforce = 11f;

    private float movementx;
    [SerializeField]
    private Rigidbody2D mybody;
    private SpriteRenderer sr;
    private Animator anmi;

    private string Walk_Animation = "Walk";
    private bool isGrounded;
    private string Ground_tag = "Ground";
    private string Enemy_tag = "Enemy";
    private object collision;

    private void Awake()
    {
        // mybody.AddForce(new Vector2(2, 2));
        mybody = GetComponent<Rigidbody2D>();
        anmi = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        PlayerMoveKeybord();
        AnimatePlayer();

        Playerjump();
    }

    private void FixedUpdate()
    {
        Playerjump();
    }

    void PlayerMoveKeybord()
    {

        movementx = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementx, 0f, 0f) * Time.deltaTime * moveforce;

    }

    void AnimatePlayer()
    {

        if (movementx > 0)
        {
            anmi.SetBool(Walk_Animation, true);
            sr.flipX = false;
        }
        else if (movementx < 0)
        {
            anmi.SetBool(Walk_Animation, true);
            sr.flipX = true;
        }
        else
        {
            anmi.SetBool(Walk_Animation, false);
        }

    }

    void Playerjump()
    {

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            // Debug.Log("Jump Pressed");
            mybody.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag(Ground_tag))
            isGrounded = true;
        // Debug.Log("We landed on ground");


        if (collision.gameObject.CompareTag(Enemy_tag))
            Destroy(gameObject);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Enemy_tag))
            Destroy(gameObject);
    }

} //class
