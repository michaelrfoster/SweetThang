using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSpinScript : MonoBehaviour
{
    [Range(0,15)]
    public static float SPEED = .2f;
    const float RADIUS = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time;
        transform.rotation = Quaternion.Euler(0, 180f * SPEED / Mathf.PI * t + 180f, 0);
        transform.localPosition = new Vector3(RADIUS * Mathf.Sin(SPEED * t), 0, RADIUS * Mathf.Cos(SPEED * t));
    }

    public static void setSpeed(float speed)
    {
        SPEED = speed;
    }
}
