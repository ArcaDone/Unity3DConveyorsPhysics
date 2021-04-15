using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NastroTr : MonoBehaviour
{

    [SerializeField] float speed = 2f;
    [SerializeField] float meshSpeed = 0.2f;

    Rigidbody rb;
    Material material;
    Vector2 uvOffset = Vector2.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        material = GetComponent<MeshRenderer>().material;
        if (transform.localScale.x == 0.0f) return;
        float scaleRatio = transform.localScale.z / transform.localScale.x;
        material.SetTextureScale("_MainTex", new Vector2(1, scaleRatio));
    }

    private void FixedUpdate()
    {
        Vector3 pos = rb.position;
        rb.position += transform.TransformDirection(Vector3.up) * speed * Time.fixedDeltaTime;
        rb.MovePosition(pos);

        uvOffset += new Vector2(0, meshSpeed * Time.fixedDeltaTime);
        if (uvOffset.y > 1.0f)
        {
            uvOffset.y -= (float) System.Math.Truncate(uvOffset.y);
        }

        material.SetTextureOffset("_MainTex", -uvOffset);
    }
}
