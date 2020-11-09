using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pacdot : MonoBehaviour
{

    public GameObject Cherry;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            ScoreText.scoreValue += 10;
            Destroy(gameObject);
        }

        if(ScoreText.scoreValue == 2680)
        {
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
        }
            
    }
    
    private void Update()
    {
       if(ScoreText.scoreValue >=500)
        {
           Cherry.SetActive(true);
        }
    }

    
}

