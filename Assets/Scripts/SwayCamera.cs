using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwayCamera : MonoBehaviour {

    public float maxLife;
    private Vector3 savePos;
    private Vector2 lowRange;
    private Vector2 maxRange;

    public Vector2 power;
    private float life;

	// Use this for initialization
	void Start () {
        life = 0;

    }
	
	// Update is called once per frame
	void Update () {
        if(life < 0.0f)
        {
            ResetSway();
        }

        if(life > 0.0f)
        {
            Sway();
        }
    }

    public void SwayStart()
    {
        savePos = transform.position;
        lowRange.x = savePos.x - power.x;
        lowRange.y = savePos.y - power.y;
        maxRange.x = savePos.x + power.x;
        maxRange.y = savePos.y + power.y;

        life = maxLife;
    }

    private void Sway()
    {
        life -= Time.deltaTime;

        float xVal, yVal;
        xVal = Random.Range(lowRange.x,maxRange.x);
        yVal = Random.Range(lowRange.y, maxRange.y);

        transform.position = new Vector3(xVal,yVal,transform.position.z);
    }

    private void ResetSway()
    {
    }
}
