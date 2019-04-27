using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Attack : MonoBehaviour
{
	public float chargeDamage;
	public float chargeRate;
	public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
		chargeDamage = 0;
		chargeRate = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.J))
		{
			chargeDamage += chargeRate * Time.deltaTime;
			if(chargeDamage == 1.0f)
			{
				chargeDamage += 0;
			}
		}

		text.text = chargeDamage.ToString();
	}
}
