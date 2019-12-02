using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapUpdater : MonoBehaviour
{
    [SerializeField] Image[] maps;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(FindObjectOfType<SceneInformation>().sceneIndex)
        {
            case 1:
                if(FindObjectOfType<Interactor>().gameObject.transform.position.y >= 0)
                {

                }
                break;
            case 2:
                break;
        }
    }
}
