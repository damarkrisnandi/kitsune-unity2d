using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player; public Vector3 offset;
    public Transform LeftAndBottomBound;
    public Transform RightAndTopBound;
    public SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float width = sr.bounds.size.x;
        float height = sr.bounds.size.y;
        
        // Left Constraint
        transform.position = new Vector3 (player.position.x + offset.x, player.position.y + offset.y, offset.z);
        if (transform.position.x - (width * 0.5f) < LeftAndBottomBound.position.x) {
            float x = LeftAndBottomBound.position.x - (transform.position.x - (width * 0.5f));
            transform.position = new Vector3 (player.position.x + offset.x + x, player.position.y + offset.y, offset.z);
        }

        // Bottom Constraint
        if (transform.position.y - (height * 0.5f) < LeftAndBottomBound.position.y) {
            float y = LeftAndBottomBound.position.y - (transform.position.y - (height * 0.5f));
            transform.position = new Vector3 (player.position.x + offset.x, player.position.y + offset.y + y, offset.z);
        }

        // Right Constraint
        if (transform.position.x + (width * 0.5f) > RightAndTopBound.position.x) {
            float x1 = (width * 0.5f) - (RightAndTopBound.position.x - transform.position.x);
            transform.position = new Vector3 (player.position.x + offset.x - x1, player.position.y + offset.y, offset.z);
        }
        
        
    }
}
