using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldActivate : MonoBehaviour
{
    public GameObject playerShield; 
    // Start is called before the first frame update
    void Start()
    {
        playerShield.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
