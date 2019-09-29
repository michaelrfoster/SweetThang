using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpicyWallScript : MonoBehaviour
{
    public Transform cube;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        makeSpicyWall();
    }
    private void makeSpicyWall()
    {
        float chance;
        Vector3 position;

        for (int i = 0; i < 99; i++)
        {
            transform.Rotate(new Vector3(0, UnityEngine.Random.Range(0f, 360f), 0));
            chance = UnityEngine.Random.Range(0f, 1f);
            if (chance < .75f)
            {
                Transform wallcube = Instantiate(cube);
                position = 3.5f * transform.forward;
                position.y = UnityEngine.Random.Range(0, 1.5f);
                wallcube.localPosition = position;
                wallcube.localScale = Vector3.one * UnityEngine.Random.Range(0.3f, 0.5f);
                wallcube.LookAt(Vector3.zero, Vector3.up);
                Vector3 rotation = wallcube.localEulerAngles;
                rotation.x = 0;
                wallcube.localEulerAngles = rotation;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
