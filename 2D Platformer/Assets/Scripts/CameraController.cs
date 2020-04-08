using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
    public Transform target;
    public Transform farBg, middleBg;
    public float minHeight;
    public float maxHeight;
    private Vector2 lastPosition;
    public bool stopFollowingPlayer;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        //float clampedY = Mathf.Clamp(transform.position.y, minHeight, maxHeight);
        //transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);

        if(!stopFollowingPlayer){
            //This will make sure the camera is clamped to the character and will obey the set height constraints for the camera.
            transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);

            //float amountToMoveX = transform.position.x - lastXPosition;

            //This will get the amount of frames to move while parallaxing by taking the x pos and subtracting it from it's last known pos and does the same for y
            Vector2 amountToMove = new Vector2(transform.position.x - lastPosition.x, transform.position.y - lastPosition.y);

            //This tells the far background to move a certain amount of frames with the camera using the previous vector 2 variable.
            farBg.position += new Vector3(amountToMove.x, amountToMove.y, 0f);

            //This tells the middle background to move a certain amount of frames with the camera using the previous vector 2 variable.
            middleBg.position += new Vector3(amountToMove.x , amountToMove.y, 0f) * .5f;

        //lastXPosition = transform.position.x;
        
        lastPosition = transform.position;
     }
    }
}
