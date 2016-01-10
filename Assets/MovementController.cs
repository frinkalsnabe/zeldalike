using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

    public float moveSpeed = 1.0f;

    public SpriteRenderer backgroundSprite;

    private float backgroundWidth;
    private float backgroundHeight;
    private Vector3 backgroundCenter;

	// Use this for initialization
	void Start () {
        backgroundWidth = backgroundSprite.bounds.size.x;
        backgroundHeight = backgroundSprite.bounds.size.y;
        backgroundCenter = backgroundSprite.bounds.center;
	}
	
	// Update is called once per frame
	void Update () {
        float hAxis;
	    if( (hAxis = Input.GetAxis("Horizontal")) != 0.0f )
        {
            if (hAxis > 0)
            {
                if (transform.position.x - backgroundCenter.x < backgroundWidth * 0.5f)
                {
                    transform.position += Vector3.right * hAxis * moveSpeed * Time.deltaTime;
                }
            }
            else // hAxis < 0
            {
                if (transform.position.x - backgroundCenter.x > -1.0f * backgroundWidth * 0.5f)
                {
                    transform.position += Vector3.right * hAxis * moveSpeed * Time.deltaTime;
                }
            }
        }

        float vAxis;
        if ((vAxis = Input.GetAxis("Vertical")) != 0.0f)
        {
            if (vAxis > 0)
            {
                if (transform.position.y - backgroundCenter.y < backgroundHeight * 0.5f)
                {
                    transform.position += Vector3.up * vAxis * moveSpeed * Time.deltaTime;
                }
            }
            else // vAxis < 0
            {
                if (transform.position.y - backgroundCenter.y > -1.0f * backgroundHeight * 0.5f)
                {
                    transform.position += Vector3.up * vAxis * moveSpeed * Time.deltaTime;
                }
            }
        }
    }
}
