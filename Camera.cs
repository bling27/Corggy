using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public bool enable = true;
    public float smooth = 0.5f;
    public Vector3 minval, maxval;
    void FixedUpdate()
    {
        Follow();
    }
    void Follow()
    {
        if (enable)
        {
            Vector3 targetPosition = target.position + offset;
            Vector3 bounds = new Vector3(
                Mathf.Clamp(targetPosition.x, minval.x, maxval.x),
                Mathf.Clamp(targetPosition.y, minval.y, maxval.y),
                Mathf.Clamp(targetPosition.z, minval.z, maxval.z));
            Vector3 smoothpos = Vector3.Lerp(transform.position, bounds, smooth * Time.fixedDeltaTime);

            transform.position = smoothpos;
        }
    }
}
