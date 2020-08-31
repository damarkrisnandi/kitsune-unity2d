using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject[] enemies;
    public bool isDeath;
    public GameObject deathAnimate;
    // Start is called before the first frame update
    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("enemy");
    }

    private void OnCollisionEnter2D(Collision2D col) {
        foreach (GameObject enemy in enemies)
        {
            if(enemy.name == col.collider.name)
            {
                // Destroy(item);
                player.SetActive(false);
                Instantiate(deathAnimate, transform.position, Quaternion.identity);
                break;
            }   
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
