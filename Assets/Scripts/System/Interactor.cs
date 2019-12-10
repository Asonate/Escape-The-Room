using System;
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
        if (!PlayerData.currentlyInMenu)
        {
            if (Input.GetButtonDown("Fire2"))
            {
                Scout();
            }

            if (Input.GetButtonDown("Fire1"))
            {
                Interact();
            }
        }
    }

    void Scout()
    {
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out RaycastHit hit, 15))
        {
            GameObject hitObj = hit.transform.gameObject;
            GameObject hitFX = Instantiate(onHit, hit.point, Quaternion.LookRotation(hit.normal), gameObject.transform);
            ClickableObject target = hit.transform.GetComponent<ClickableObject>();
            if (target)
            {
                hitFX.GetComponent<ParticleSystem>().startColor = target.GetColor();
                target.Highlight();
            }
            else
            {
                hitFX.GetComponent<ParticleSystem>().startColor = Color.black;
            }
            Destroy(hitFX, 1f);
        }
    }

    private void Interact()
    {
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out RaycastHit hit, 5))
        {
            DirectionUpdater direction = hit.transform.GetComponent<DirectionUpdater>();
            if (direction)
            {
                direction.Execute();
            }
            ClickableObject target = hit.transform.GetComponent<ClickableObject>();
            if (target)
            {
                target.Execute();
            }
        }
        
    }
}
