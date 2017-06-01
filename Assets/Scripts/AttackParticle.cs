using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackParticle : MonoBehaviour
{

    public ParticleSystem partilce;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!partilce.IsAlive())
        {
            Destroy(gameObject);
        }

    }
}
