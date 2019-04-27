using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleOutline : MonoBehaviour
{
	public GameObject outline;
	private void Start()
	{
		outline.SetActive(false);
	}
	// Start is called before the first frame update
	private void OnTriggerEnter(Collider other)
	{
		outline.SetActive(true);
	}
	private void OnTriggerStay(Collider other)
	{
		outline.SetActive(true);
	}
	private void OnTriggerExit(Collider other)
	{
		outline.SetActive(false);
	}
}
