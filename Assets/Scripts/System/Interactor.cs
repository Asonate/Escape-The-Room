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
        if (!(PlayerData.currentlyInMenu || PlayerData.currentlyInPuzzle) && PlayerData.allowMenu)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Interact();
            }
        }
    }

    private void Interact()
    {
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out RaycastHit hit, 5))
        {
            InteractionObject target = hit.transform.GetComponent<InteractionObject>();
            if (target)
            {
                target.Execute();
            }
        }
        
    }
}
