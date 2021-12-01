using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tripwire : MonoBehaviour
{
    private LineRenderer laser;


    public float laserWidth = 0.2f;
    public float range = 10f;

    void Start()
    {
        laser = this.gameObject.AddComponent<LineRenderer>();
        laser.startWidth = laserWidth;
        laser.endWidth = laserWidth;

        Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };

        CheckLaser();
    }

    void Update()
    {

        
        
    }

    private void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, range))
        {
            Debug.DrawLine(this.transform.position, this.transform.forward, Color.red);
            
        }
    }

    void CheckLaser()
    {
        RaycastHit hit;
        Physics.Raycast(this.transform.position, this.transform.forward, out hit, range);

        laser.SetPosition(0, this.transform.position);

        if (hit.transform.tag == "Wall")
        {
            SetEndpoint(hit);
        }
        
    }

    void SetEndpoint(RaycastHit hit)
    {
        laser.SetPosition(1, hit.normal);
    }
}
