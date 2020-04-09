using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectCamera : MonoBehaviour
{
    public Vector2 minPos;
    public Vector2 maxPos;
    public Transform posTarget;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float xPos = Mathf.Clamp(posTarget.position.x, minPos.x, maxPos.x);
        float yPos = Mathf.Clamp(posTarget.position.y, minPos.y, maxPos.y);
        transform.position = new Vector3(xPos, yPos, transform.position.z);
    }
}
