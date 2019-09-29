using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{
    public Transform pointPrefab;

    [Range(10, 100)]
    public int resolution = 10;
    Transform[] points;
    public GraphFunctionName function;
    public Light scaryLight;
    public Light scarierLight;
    static readonly GraphFunction[] functions = {
         SineFunction, Sine2DFunction, MultiSineFunction, Ripple, Bogo
    };
    const float pi = Mathf.PI;
    const float xOrigin = 0f;
    const float zOrigin = 0f;
    const float yOffset = -1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setFunction(GraphFunctionName functionName)
    {
        function = functionName;
    }
    // Update is called once per frame
    void Update()
    {
        float t = Time.time;
        GraphFunction f = functions[(int)function];
        if (function == GraphFunctionName.Bogo)
        {
            setScaryLight();
            CameraSpinScript.turbo();
        }
        for (int i = 0; i < points.Length; i++)
        {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            position.y = f(position.x, position.z, t) + yOffset;
            point.localPosition = position;
        }
    }

    void Awake()
    {
        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step;
        Vector3 position;
        points = new Transform[resolution * resolution];
        position.y = 0f;
        position.z = 0f;
        for (int i = 0, z = 0; z < resolution; z++)
        {
            position.z = (z + 0.5f) * step - 1f + zOrigin;
            for (int x = 0; x < resolution; x++, i++)
            {
                Transform point = Instantiate(pointPrefab);
                position.x = (x + 0.5f) * step - 1f + xOrigin;
                point.localPosition = position;
                point.localScale = scale;
                point.SetParent(transform, false);
                points[i] = point;
            }
        }
    }

    static float SineFunction(float x, float z, float t)
    {
        return Mathf.Sin(pi * (x + t));
    }

    static float MultiSineFunction(float x, float z, float t)
    {
        float y = Mathf.Sin(pi * (x + t));
        y += Mathf.Sin(2f * pi * (x + 2f * t)) / 2f;
        y *= 2f / 3f;
        return y;
    }

    static float Sine2DFunction(float x, float z, float t)
    {
        float y = Mathf.Sin(pi * (x + t));
        y += Mathf.Sin(pi * (z + t));
        y *= 0.5f;
        return y;
    }

    static float Ripple(float x, float z, float t)
    {
        float d = Mathf.Sqrt((x - xOrigin) * (x - xOrigin) + (z - zOrigin) * (z - zOrigin));
        float y = Mathf.Sin(pi * (4f * d - t));
        y /= 1f + 10f * d;
        return y;
    }

    private void setScaryLight()
    {
        scaryLight.color = Color.red;
        scarierLight.color = Color.red;
    }

    static float Bogo(float x, float z, float t)
    {
        return Random.Range(-1f, 1f);
    }
}
