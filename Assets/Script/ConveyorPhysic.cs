using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorPhysic : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] ConveyorType conveyorType;
    [SerializeField] float meshSpeed = 2f;

    Rigidbody m_Rigidbody;
    Material material;
    Vector2 uvOffset = Vector2.zero;

    public enum ConveyorType
    {
        Roll,
        Plane,
        LongTape
    }

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        material = GetComponent<MeshRenderer>().material;
        // dynamically sets the "tiling" of the material texture based on transform stretching
        // important for the scroll speed to look correct
        if (transform.localScale.x == 0.0f) return;
        float scaleRatio = transform.localScale.z / transform.localScale.x;
        material.SetTextureScale("_MainTex", new Vector2(1, scaleRatio));        
    }

    private void FixedUpdate()
    {
        Vector3 pos = m_Rigidbody.position;
        if (conveyorType == ConveyorType.Roll)
        {
            m_Rigidbody.position += transform.position * speed * Time.fixedDeltaTime;
        }
        else if (conveyorType == ConveyorType.Plane)
        {
            m_Rigidbody.position += transform.TransformDirection(Vector3.up) * speed * Time.fixedDeltaTime;
        }
        else if (conveyorType == ConveyorType.LongTape)
        {
            m_Rigidbody.position += transform.TransformDirection(Vector3.left) * speed * Time.fixedDeltaTime;
        }

        m_Rigidbody.MovePosition(pos);



        if (conveyorType == ConveyorType.LongTape)
        {
            // scroll the texture
            uvOffset += new Vector2(0, (meshSpeed / 100) * Time.fixedDeltaTime);
        }
        else
        {
            // scroll the texture
            uvOffset += new Vector2(0, meshSpeed * Time.fixedDeltaTime);
        }

        if (uvOffset.y > 1.0f)
        {
            // keep the "V" value between 0 and 1 using Math.Truncate. same idea as using frac() in the shader code
            uvOffset.y -= (float)System.Math.Truncate(uvOffset.y);
        }
        material.SetTextureOffset("_MainTex", -uvOffset);
       
    }
}
