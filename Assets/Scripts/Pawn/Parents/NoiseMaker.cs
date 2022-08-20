using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseMaker : MonoBehaviour
{
    public float volumeDistance;
<<<<<<< HEAD
    public float noise;
=======
    private  float noise;
>>>>>>> main
    public KeyCode moveForewardKey = KeyCode.W;
    public KeyCode moveBackwardKey = KeyCode.S;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        noise = Mathf.Clamp01(noise);
        if (Input.GetKey(moveForewardKey) || Input.GetKey(moveBackwardKey))
        {
            noise = volumeDistance;
            Debug.Log("making noise");
        }
        else 
        {
            noise--;
            volumeDistance = 5;
            return;
        }
        

    }
    public void MakingNoise()
    {

    }
}
