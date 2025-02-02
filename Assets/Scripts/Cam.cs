using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    public Vector2 minPos;
    public Vector2 maxPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += (target.position + offset - transform.position) / 1.5f;

        Vector3 newPosition = transform.position;

        newPosition.x = Mathf.Clamp(newPosition.x, target.position.x + minPos.x + offset.x, target.position.x + maxPos.x + offset.x);
        newPosition.y = Mathf.Clamp(newPosition.y, target.position.y + minPos.y + offset.y, target.position.y + maxPos.y + offset.y);

        transform.position = newPosition;
    }
}
