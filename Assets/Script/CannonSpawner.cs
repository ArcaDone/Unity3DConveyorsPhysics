using UnityEngine;

public class CannonSpawner : MonoBehaviour
{
    public Transform FirePoint;

    public GameObject _bullet;
    public Transform Target;

    public ParticleSystem fireParticle;
    //private LineRenderer lineRenderer;


    public bool coroutineStarted;
    bool isShooting;

    private void Start()
    {
        //lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        Laser();
    }

    void Shoot()
    {
        GameObject bullet = (GameObject)Instantiate(_bullet, FirePoint.position, FirePoint.rotation);
        ParticleSystem particle = (ParticleSystem)Instantiate(fireParticle, FirePoint.position, FirePoint.rotation);
        bullet.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(-1000f,300f,0), ForceMode.Impulse);
        Destroy(particle.gameObject, 2f);
        Destroy(bullet, 5f);
    }

    void Laser()
    {
        int layerMask = 1 << 8;

        layerMask = ~layerMask;
        RaycastHit hit;
        if (Physics.Raycast(FirePoint.position, FirePoint.TransformDirection(Vector3.up), out hit, 5, layerMask))
        {
            Debug.DrawRay(FirePoint.position, FirePoint.TransformDirection(Vector3.up) * hit.distance, Color.yellow);
            Target = hit.transform;
            if (!isShooting)
            {
                isShooting = true;
                Shoot();
                //LaserBeam(hit.transform);
            }

        }
        else
        {
            Debug.DrawRay(FirePoint.position, FirePoint.TransformDirection(Vector3.up) * 5, Color.white);
            Target = null;
            isShooting = false;
        }
    }

    /*
    void LaserBeam(Transform target)
    {

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;

        }

        lineRenderer.SetPosition(0, FirePoint.position);
        lineRenderer.SetPosition(1, target.position);

    }
    */

}
