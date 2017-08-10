using UnityEngine;

public class CameraSizeToVelocity2D : MonoBehaviour
{
    public Rigidbody2D target;
    [SerializeField]
    private float minCam;
    [SerializeField]
    private float maxCam;
    private float playerVel;
    private float smooth = 0.5f;
    private Camera cam;

    void Start()
    {
    	cam = Camera.main;
    }

    void Update()
    {
    	if (target != null)
        {
		//clamp the size of the camera to desired min and max values, use rigidbodys velocity vectors X value for horizontal movement, Y value for vertical movement
		float cameraSizeInput = Mathf.Clamp(Mathf.Abs(target.velocity.x), minCam, maxCam);
				
		//use SmoothDamp to smoothly transition between the values
                float cameraSizeChanger = Mathf.SmoothDamp(cam.orthographicSize, cameraSizeInput, ref playerVel, smooth);

		//assign the value to the camera
               	cam.orthographicSize = cameraSizeChanger;
        }
     }
}
