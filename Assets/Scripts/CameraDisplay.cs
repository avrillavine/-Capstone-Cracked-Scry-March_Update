using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class CameraDisplay : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

		//Camera.main.cullingMask = 1 | 1 << 8;
		//Camera.main.forceIntoRenderTexture = true; 
		//Camera.main.cullingMask = 1 | 1 << 5;
		Camera.current.cullingMask = 1 | 1 << 5;
	}
}
