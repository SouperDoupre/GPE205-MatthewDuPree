using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    public float lookSpeed;
    public abstract void Start();
    public abstract void Move(Vector3 direction, float speed);
    public abstract void Rotate(float lookSpeed);    
}
