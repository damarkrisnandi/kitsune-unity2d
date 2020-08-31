using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpposumScript : MonoBehaviour
{
    ///<summary></summary>
    public Transform player;
    private float speed = 0.003f;
    private bool o_FacingLeft = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x >= transform.position.x) {
            // move to right
            if (o_FacingLeft) {
                transform.localScale = new Vector3(-1f, 1f, 1f);
                o_FacingLeft = false;
            } 
            transform.position += new Vector3(speed, 0, 0);
        } else if (player.position.x <= transform.position.x) {
            // move to left
            if (!o_FacingLeft) {
                transform.localScale = new Vector3(1f, 1f, 1f);
                o_FacingLeft = true;
            }
            
            transform.position -= new Vector3(speed, 0, 0);
        }
    }

    private void Flip(){
		// Switch the way the player is labelled as facing.
		o_FacingLeft = !o_FacingLeft;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
