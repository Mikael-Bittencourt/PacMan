using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour
{
    public Transform[] waypoints;
    int cur = 0;

    public float speed = 0.3f;

    public GameObject DeathMenu;

  void FixedUpdate () {
    // Waypoint not reached yet? then move closer
    
        Vector2 p = Vector2.MoveTowards(transform.position,waypoints[cur].position,speed);

        GetComponent<Rigidbody2D>().MovePosition(p);

    
    // Waypoint reached, select next one
    if (transform.position == waypoints[cur].position)
    {
      cur =+ 1;
    }

    if(cur == waypoints.Length)
    {
      cur = 0;
    }

    //Animation
    Vector2 dir = waypoints[cur].position - transform.position;
    GetComponent<Animator>().SetFloat("DirX", dir.x);
    GetComponent<Animator>().SetFloat("DirY", dir.y);
    
  }  
    
 

     
  
    

    void OnTriggerEnter2D(Collider2D co) {
    if (co.name == "Pacman")
    {
        if( co.GetComponent<pac_move>().eat == false)
        {
           Destroy(co.gameObject);
           DeathMenu.SetActive(true);
        }

        if( co.GetComponent<pac_move>().eat == true)
        {
           transform.position = waypoints[0].position;
           cur= 0;
          
        }
    }
    }


    
}

