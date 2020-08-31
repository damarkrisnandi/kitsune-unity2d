using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItems : MonoBehaviour
{
    public GameObject[] items;
    public GameObject[] cherries;
    public bool thisEffectStop = false;
    public int diamonds = 0;
    public int cherry = 0;
    // Start is called before the first frame update
    void Start()
    {
        items = GameObject.FindGameObjectsWithTag("gem");
        cherries = GameObject.FindGameObjectsWithTag("cherry");
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D col) {
        diamonds = pickItem(col, items, diamonds);

        cherry = pickItem(col, cherries, cherry);
    }

    private int pickItem(Collision2D col, GameObject[] objs, int count) {
        foreach (GameObject obj in objs)
        {
            if(obj.name == col.collider.name)
            {
                // Destroy(item);
                obj.SetActive(false);
                count++;
                break;
            }   
        }
        return count;
    }
}
