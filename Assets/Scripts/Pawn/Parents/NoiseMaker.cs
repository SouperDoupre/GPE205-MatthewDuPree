using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseMaker : MonoBehaviour
{
    public float volumeDistance;
    private  float noise;
    public KeyCode moveForewardKey = KeyCode.W;
    public KeyCode moveBackwardKey = KeyCode.S;
    // Start is called before the first frame update
    void Start()
    {
        noise = 0;
    }

    // Update is called once per frame
    void Update()
    {
        noise = Mathf.Clamp01(noise);
       if(Input.GetKey(moveForewardKey) || Input.GetKey(moveBackwardKey))
        {
            noise = volumeDistance;
            Debug.Log("making noise");
        }
        else
        {
            noise--;
        }
    }
}
