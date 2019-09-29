using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public Slider sidler;
    public Graph giraffe;
    public Text ampCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        giraffe.amplitude = sidler.value;
        ampCount.text = "A = " + sidler.value.ToString();
    }
}
