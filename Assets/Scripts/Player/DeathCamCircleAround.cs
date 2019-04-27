using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class DeathCamCircleAround : MonoBehaviour
{
	public GameObject deadRogue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		//deathcam.transform.position = deadRogue.transform.position;
		transform.position = deadRogue.transform.position;
		transform.LookAt(deadRogue.transform);
		transform.Translate(Vector3.right * Time.deltaTime);
		if(Input.GetKeyDown(KeyCode.K))
		{
			Cursor.visible = true;
			SceneManager.LoadScene(0);
		}
	}


}
