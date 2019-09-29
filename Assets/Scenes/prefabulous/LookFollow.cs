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
        //transform.eulerAngles = new Vector3(foo.transform.eulerAngles.x, foo.transform.eulerAngles.y, foo.transform.eulerAngles.z);
        stay = transform.position;
        stay.y = -0.5f;
        transform.position = stay;
    }
}
