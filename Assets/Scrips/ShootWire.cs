using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWire : MonoBehaviour
{
    public float range = 10f;

    public Camera mainCam;
    public GameObject tripwireObj;

    private void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, range))
        {
            Debug.DrawLine(mainCam.transform.position, mainCam.transform.forward, Color.red);
        }
    }
    private void Update()
    {
        

        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }
    void Fire()
    {
        RaycastHit hit;

        if(Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, range) && hit.transform.tag == "Wall")
        {
            Vector3 temp = Vector3.Cross(transform.up, hit.normal);

            GameObject clone = Instantiate(tripwireObj, hit.point, Quaternion.LookRotation(temp)); // What to make Quaternion?
        }
    }
}
