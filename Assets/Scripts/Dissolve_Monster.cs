using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SkeletonScript))]
public class Dissolve_Monster : MonoBehaviour
{
	SkeletonScript _ss;
	//Timer Values
	public float _maxVal = 1.1f;
	public float _minVal= 0;
	public float _val = 0f; // the total
	float _timePerSecond; // modify the total, every second
	public float _duration = 15; // the total time myValue will take to go from max to min
	public bool _startDissolving = false;
	// Start is called before the first frame update
	void Start()
    {
		_ss = GetComponent<SkeletonScript>();
	}

    // Update is called once per frame
    void Update()
    {
		//if(!_ss.isDead)
		//{

		//}
		_val = Mathf.Clamp(_val + _timePerSecond * Time.deltaTime, _minVal, _maxVal);
		Shader.SetGlobalFloat("_value", _val);
		//If player sets boolean to true, start making the object reappear 
		if (_startDissolving)
		{
			_timePerSecond = (_minVal + _maxVal) / _duration;
		}
		else
		{
			//Monsters take a bit of time to reappear
			_timePerSecond = (_minVal - _maxVal) / _duration / 5;
		}
		if (_val == _maxVal)
		{
			_startDissolving = false;
		}


	}
}
