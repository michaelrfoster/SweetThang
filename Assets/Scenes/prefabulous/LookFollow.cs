using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookFollow : MonoBehaviour
{
    public GameObject foo;
    Vector3 stay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.zero;
        stay = foo.transform.position;
        stay.y = -0.5f;
        foo.transform.position = stay;
    }
}
