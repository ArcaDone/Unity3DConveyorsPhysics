using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] Transform pointer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Laser();
    }

    void Laser()
    {
        int layerMask = 1 << 8;

        layerMask = ~layerMask;
        RaycastHit hit;
        if (Physics.Raycast(pointer.position, pointer.TransformDirection(Vector3.up), out hit, 5, layerMask) )
        {
            Debug.DrawRay(pointer.position, pointer.TransformDirection(Vector3.up) * hit.distance, Color.yellow);

        }
        else
        {
            Debug.DrawRay(pointer.position, pointer.TransformDirection(Vector3.up) * 5, Color.white);

        }
    }

}
