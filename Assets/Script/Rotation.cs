using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] Axis axis;
    public enum Axis
    {
        X,
        Y,
        Z
    }

    // Update is called once per frame
    void Update()
    {
        if (axis == Axis.X)
        {
            this.transform.RotateAround(this.transform.position, Vector3.right, Time.deltaTime * speed);

        } else if (axis == Axis.Y)
        {
            this.transform.RotateAround(this.transform.position, Vector3.up, Time.deltaTime * speed);

        }
        else if (axis == Axis.Z)
        {
            this.transform.RotateAround(this.transform.position, Vector3.forward, Time.deltaTime * speed);

        }

    }
}
