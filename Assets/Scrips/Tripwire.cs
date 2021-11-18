using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tripwire : MonoBehaviour
{
    public LineRenderer laserLineRenderer;
    public float laserWidth = 0.1f;
    public float range = 10f;

    void Start()
    {
        Vector3[] initLaserPositions = new Vector3[2] { Vector3.zero, Vector3.zero };
        laserLineRenderer.SetPositions(initLaserPositions);
    }

    void Update()
    {
        
            ShootLaserFromTargetPosition(transform.position, Vector3.up, range);
            //laserLineRenderer.enabled = true;
        
        
    }

    private void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, range))
        {
            Debug.DrawLine(this.transform.position, this.transform.forward, Color.red);
        }
    }

    void ShootLaserFromTargetPosition(Vector3 targetPosition, Vector3 direction, float length)
    {
        Ray ray = new Ray(targetPosition, direction);
        RaycastHit hit;
        Vector3 endPosition = targetPosition + (length * direction);

        if(Physics.Raycast(this.transform.position, this.transform.forward, out hit, range) && hit.transform.tag == "Enemy")
        {
            Debug.Log("Enemy hit!");
        }

        if (Physics.Raycast(ray, out hit, length))
        {
            endPosition = hit.point;
        }

        laserLineRenderer.SetPosition(0, targetPosition);
        laserLineRenderer.SetPosition(1, endPosition);
    }
}
