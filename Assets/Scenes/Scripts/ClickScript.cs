using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickScript : MonoBehaviour
{
    public Text UIText;
    // Start is called before the first frame update
    void Start()
    {
        var inc = int.Parse(UIText.text) + 1;
        UIText.text = inc.ToString();
        Debug.Log(UIText.text);
    }



    public void increment()
    {
        Debug.Log("Yo you suck boy");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
