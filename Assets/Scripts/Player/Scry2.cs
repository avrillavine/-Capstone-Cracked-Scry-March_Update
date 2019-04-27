using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scry2 : MonoBehaviour
{
	public bool _isInView;
	//Timer Values
	public float maxMyValue = 1.1f;
	public float minMyValue = 0;
	public float myValue = 1.1f; // the total
	float _changePerSecond; // modify the total, every second
	public float _timeToChange = 4.0f; // the total time myValue will take to go from max to min

	//Timer Values
	public float vMax = 1.1f;
	public float vMin = 0;
	public float value = 0f; // the total
	float _timePerSecond; // modify the total, every second
	public float _rate = 4.0f; // the total time myValue will take to go from max to min
	public bool _startMaterializing;
	public bool trapInSight;
	public bool _trapInProcess;
	public bool _effectInProcess;
	bool isTrap;
	public bool _startDissolving;
	//public bool enemyInSight = false;
	//public bool _reveal = false;
	// Update is called once per frame

	private GameObject[] _tagged;

	void Start()
	{
		CheckTags("Trap");
		CheckTags("Enemy");
	}
	void Update()
    {
		//Based off code from here https://gamedev.stackexchange.com/questions/121749/how-do-i-change-a-value-gradually-over-time
		//The whole idea is that the flags for keeping objects visible and enemies invisible is set to false 
		//Until the player sets off the flag
		// modify at a constant rate, keep within bounds

		if (Input.GetKeyDown(KeyCode.H) || Input.GetButtonDown("Btn 0"))
		{
			//IsTagInFront("Trap", "Shader Graphs/Transparent", "Shader Graphs/Reveal");
			//if (trapInSight)
			//	_startMaterializing = true;
			//else
			//	_startMaterializing = false;
			IsTagInFront("Trap");
			if (_isInView)
				_startMaterializing = true;
			else
				_startMaterializing = false;

			IsTagInFront("Enemy");
			if (_isInView)
				_startDissolving = true;
			else
				_startDissolving = false;
			
		}

		if(Input.GetKeyDown(KeyCode.G))
		{
			//Testing to establish if shader is in process
			//_startMaterializing = true;
			//CallObjectByTag("Trap", "Shader Graphs/Transparent", "Shader Graphs/Reveal", _startMaterializing);
		}
		Reveal();
		//CheckState();
		Vanish();

	}
	

	void CheckTags(string _tag)
	{
		GameObject[] _tagArray= GameObject.FindGameObjectsWithTag(_tag);
		int numOfObjs = _tagArray.Length;
		if(numOfObjs == 1)
		{
			Debug.Log("There is " + numOfObjs + " " + _tag + " in this scene.");
		}
		if(numOfObjs > 1)
		{
			if(_tag.EndsWith("y"))
			{
				Debug.Log("There are " + numOfObjs + " " + _tag.Replace("y","ie") + "s in this scene.");
			}
			else
			{
				Debug.Log("There are " + numOfObjs + " " + _tag + "'s in this scene.");
			}
			
		}
		if(numOfObjs == 0)
		{
			Debug.Log(_tag + " does not exist in scene.");
		}
	}

	//void CallObjectByTag(string _tag, string _currentShader, string _replacementShader, bool _flag)
	//{
	//	_tagged = GameObject.FindGameObjectsWithTag(_tag);
	//	CheckState(_flag); 
	//	foreach (GameObject g in _tagged)
	//	{
	//		//Material mat = g.GetComponent<Renderer>().material;
	//		Renderer rend = g.GetComponent<Renderer>();
	//		Shader _current = Shader.Find(_currentShader);
	//		Shader _replace = Shader.Find(_replacementShader);
	//		Vector3 _targetPos = g.transform.position;
	//		Vector3 directionToTarget = transform.position - _targetPos;
	//		float angle = Vector3.Angle(transform.forward, directionToTarget);
	//		float distance = directionToTarget.magnitude;

	//		if (Mathf.Abs(angle) > 90 && distance < 10)
	//		{
	//			Debug.Log(g.name + " is in front of me");
	//			Debug.Log(g.name + "'s shader is " + rend.material.shader);
	//			if(!_effectInProcess)
	//			rend.material.shader = _replace;
	//			else
	//			{
	//				Debug.Log("Effect still in progress");
	//			}
	//			_isInView = true;

	//		}
	//		else
	//		{
	//			Debug.Log(g.name + " is out of my view");
	//			if (_effectInProcess)
	//			{
	//				Debug.Log("amount is " + myValue);
	//			}
	//			else
	//			{
	//				rend.material.shader = _current;
	//			}

	//			//Debug.Log("Target is out of view");
	//			_isInView = false;

	//		}
	//	}
	//}
	bool Reveal()
	{
		myValue = Mathf.Clamp(myValue + _changePerSecond * Time.deltaTime, minMyValue, maxMyValue);
		Shader.SetGlobalFloat("_amount", myValue);
		//If player sets boolean to true, start making the object reappear 
		if (_startMaterializing)
		{
			_changePerSecond = (minMyValue - maxMyValue) / _timeToChange;
		}
		else
		{
			_changePerSecond = (minMyValue + maxMyValue) / _timeToChange;
		}
		if (myValue == minMyValue)
		{
			_startMaterializing = false;
		}
		return _startMaterializing;
	}
	bool Vanish()
	{
		value = Mathf.Clamp(value + _timePerSecond * Time.deltaTime, vMin, vMax);
		Shader.SetGlobalFloat("_value", value);
		//If player sets boolean to true, start making the object reappear 
		if (_startDissolving)
		{
			_timePerSecond = (vMin + vMax) / _rate;
		}
		else
		{
			_timePerSecond = (vMin - vMax) / _rate;
		}
		if (value == vMax)
		{
			_startDissolving = false;
		}
		return _startDissolving;
	}
	//bool IsTagInFront(string _tag, string _currentShader, string _replacementShader/*, bool _isInView*/)
	//{
	//	//	GameObject _gameObject = GameObject.FindWithTag(_tag);/*GameObject.FindGameObjectWithTag(_tag);*/
	//	//	int _objectCount = GameObject.FindGameObjectsWithTag(_tag).Length;
	//	GameObject[] _tagged = GameObject.FindGameObjectsWithTag(_tag);

	//	foreach (GameObject g in _tagged)
	//	{
	//		//Material mat = g.GetComponent<Renderer>().material;
	//		Renderer rend = g.GetComponent<Renderer>();
	//		Shader _current = Shader.Find(_currentShader);
	//		Shader _replace = Shader.Find(_replacementShader);
	//		Vector3 _targetPos = g.transform.position;
	//		Vector3 directionToTarget = transform.position - _targetPos;
	//		float angle = Vector3.Angle(transform.forward, directionToTarget);
	//		float distance = directionToTarget.magnitude;

	//		if (Mathf.Abs(angle) > 90 && distance < 10)
	//		{
	//			Debug.Log(g.name + " is in front of me");
	//			Debug.Log(g.name + "'s shader is " + rend.material.shader);
	//			rend.material.shader = _replace;
	//			_isInView = true;
				
	//		}
	//		else
	//		{
	//			Debug.Log(g.name + " is out of my view");
	//			if(_effectInProcess)
	//			{
	//				Debug.Log("amount is " + myValue);
	//			}
	//			else
	//			{
	//				rend.material.shader = _current;
	//			}
				
	//			//Debug.Log("Target is out of view");
	//			_isInView = false;

	//		}
	//	}

	//	return _isInView;
	//}
	bool IsTagInFront(string _tag)
	{
		GameObject _gameObject = GameObject.FindGameObjectWithTag(_tag);
		Vector3 _targetPos = _gameObject.transform.position;
	//	Debug.Log("targetPos: " + _targetPos);
		
		Vector3 directionToTarget = transform.position - _targetPos;
	//	Debug.Log("direction to target = " + directionToTarget);

		float angle = Vector3.Angle(transform.forward, directionToTarget);
	//	Debug.Log("angle = " + directionToTarget);

		float distance = directionToTarget.magnitude;
	//	Debug.Log("direction to target = " + directionToTarget);
		if (Mathf.Abs(angle) > 90 && distance < 20)//original (Mathf.Abs(angle) > 90 && distance < 10)
		{
			Debug.Log("target is in front of me");
			_isInView = true;
		}
		else
		{
			Debug.Log("Target is out of view");
			_isInView = false;
		}
		return _isInView;
	}
	bool CheckState(bool _tagType) //isEnemy or isTrap
	{
		if(_tagType)
		{
			_effectInProcess = true;
		}
		else
		{
			_effectInProcess = false;
		}

		return _effectInProcess;
	}
}
