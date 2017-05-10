using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GolemGauge : MonoBehaviour {

    public Slider slider;

	// Use this for initialization
	void Start () {
        ResetValue();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddValue(float value)
    {
        slider.value += value;
    }

    public void ResetValue()
    {
        slider.value = 0;
    }
}
