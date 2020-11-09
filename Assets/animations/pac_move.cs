using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pac_move : MonoBehaviour
{
      public float moveSpeed = 5f;

      public Rigidbody2D rb;

      Vector2 movement;

      private Animator animator;

      public bool eat = false;

      public int score;

      public Text scoretext;

      public GameObject Cherry;

      public GameObject WinMenu;

      private SpriteRenderer spriterenderer;

      public Color color;

      public Color regularColor;


    private void Start()
    {
        animator = GetComponent<Animator>();
        score = 0;
        Time.timeScale = 1f;
        spriterenderer = GetComponent<SpriteRenderer>();
        regularColor = spriterenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        AnimateMovement();
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        scoretext.text = ("score: " + score);
        if(score == 500)
        {
           Cherry.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void AnimateMovement()
    {
        if (movement.x > 0f)
        {
            animator.Play("Pacman_Right");
        }
        else if (movement.x < 0f)
        {
            animator.Play("Pacman_Left");
        }
        else if (movement.y < 0f)
        {
            animator.Play("Pacman_Down");
        }
        else if (movement.y > 0f)
        {
            animator.Play("Pacman_Up");
        }
    }

  void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag("Power ball")) 
    {
       StartCoroutine(Eat());
    }

    if(other.CompareTag("ball"))
    {
      score += 10;
      FindObjectOfType<AudioManager>().Play("pacman_chomp");
    }

    if(other.CompareTag("Cherry"))
    {
        score += 50;
        FindObjectOfType<AudioManager>().Play("cherry");
        Cherry.SetActive (false);
        
    }

    if(other.CompareTag("Ghost"))
    {
        score += 100;
        FindObjectOfType<AudioManager>().Play("pacman died");
    }

    if(score >= 2500)
        {
          WinMenu.SetActive(true);
          Time.timeScale = 0f;
        }


    }

    IEnumerator Eat ()
    {
        eat = true;
        spriterenderer.color = color;
        yield return new WaitForSeconds(10f);
        spriterenderer.color = regularColor;
        eat = false;
        
    }


    
}
