using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootWire : MonoBehaviour
{
    public float range = 10f;
    public int ammo = 2;

    public GameObject full, half, empty;
    public Camera mainCam;
    public GameObject tripwireObj;

    private void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, range))
        {
            Debug.DrawLine(mainCam.transform.position, mainCam.transform.forward * range, Color.red);
        }
    }
    private void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            if (ammo > 0)
                Fire();
            else
                Debug.Log("Out of wires");
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F");
            returnWire();
        }
    }
    void Fire()
    {
        RaycastHit hit;
        

        if(Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, range) && hit.transform.tag == "Wall")
        {

            GameObject wireClone = Instantiate(tripwireObj, hit.point, Quaternion.LookRotation(Vector3.Cross(transform.up, hit.normal)));
            ammo--;

        }

        if(ammo == 1)
        {
            full.SetActive(false);
            half.SetActive(true);
        }

        if (ammo == 0)
        {
            half.SetActive(false);
            empty.SetActive(true);
        }
    }

    void returnWire()
    {
        RaycastHit hit;

        if (Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out hit, range) && hit.transform.tag == "Wire" && ammo < 2)
        {

            Destroy(hit.transform.gameObject);
            ammo++;

            if (ammo == 1)
            {
                empty.SetActive(false);
                half.SetActive(true);
            }

            if (ammo == 2)
            {
                half.SetActive(false);
                full.SetActive(true);
            }

        }
    }
}
