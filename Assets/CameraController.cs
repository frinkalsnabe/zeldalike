using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public Transform player;
    public SpriteRenderer backgroundSprite;

    private const float cameraZ = -10;

    private bool isProperlyInitialized = false;

    private float bgRightBound;
    private float bgLeftBound;
    private float bgTopBound;
    private float bgBottomBound;

    private float camWidth;
    private float camHeight;

	// Use this for initialization
	void Start () {
        isProperlyInitialized = InitializeBackgroundBounds() && InitializeCameraVariables();
	}
	
	// Update is called once per frame
	void Update () {
	    // Every frame, try to snap the camera onto the player. If out of bounds, reset to a position that is not out of bounds
        if(player != null && isProperlyInitialized)
        {
            transform.position = new Vector3(player.position.x, player.position.y, cameraZ);

            // Snap back if we need to
            // Snap right bound
            if (transform.position.x + camWidth * 0.5f > bgRightBound)
            {
                transform.position = new Vector3(bgRightBound - camWidth * 0.5f, transform.position.y, transform.position.z);
            }
            // Snap left bound
            if (transform.position.x - camWidth * 0.5f < bgLeftBound)
            {
                transform.position = new Vector3(bgLeftBound + camWidth * 0.5f, transform.position.y, transform.position.z);
            }
            // Snap top bound
            if (transform.position.y + camHeight * 0.5f > bgTopBound)
            {
                transform.position = new Vector3(transform.position.x, bgTopBound - camHeight * 0.5f, transform.position.z);
            }
            // Snap bottom bound
            if (transform.position.y - camHeight * 0.5f < bgBottomBound)
            {
                transform.position = new Vector3(transform.position.x, bgBottomBound + camHeight * 0.5f, transform.position.z);
            }
        }
	}

    bool InitializeBackgroundBounds()
    {
        if(backgroundSprite != null)
        {
            bgRightBound = backgroundSprite.bounds.size.x * 0.5f- backgroundSprite.bounds.center.x;
            bgLeftBound = backgroundSprite.bounds.center.x * 0.5f - backgroundSprite.bounds.size.x;
            bgTopBound = backgroundSprite.bounds.size.y * 0.5f - backgroundSprite.bounds.center.y;
            bgBottomBound = backgroundSprite.bounds.center.y *0.5f - backgroundSprite.bounds.size.y;

            return true;
        }
        return false;
    }

    bool InitializeCameraVariables()
    {
        Camera cam;
        if( (cam = GetComponent<Camera>()) != null)
        {
            camHeight = cam.orthographicSize * 2.0f;    // cam.orthrographicSize is half the height of the camera's vertical boundary plane
            camWidth = camHeight * Screen.width / Screen.height;

            return true;
        }
        return false;
    }
}
