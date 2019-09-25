using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] GameObject onHit;
    Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

    }

    void Shoot()
    {
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out RaycastHit hit, 25))
        {
            GameObject hitFX = Instantiate(onHit, hit.point, Quaternion.LookRotation(hit.normal), gameObject.transform);
            Destroy(hitFX, 1);
            ClickableObject target = hit.transform.GetComponent<ClickableObject>();
            if (target)
            {
                target.LoadRiddle();
            }
        }
    }
}
