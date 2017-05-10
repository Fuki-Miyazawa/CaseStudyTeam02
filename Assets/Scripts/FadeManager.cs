using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FadeManager : MonoBehaviour {

    private static FadeManager instance;
    private static int SceneIndex;
    private static int SceneMax;

    private FadeManager()
    {
        Debug.Log("Create FadeManager instance");
    }

    public static FadeManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject("FadeManager");
                DontDestroyOnLoad(obj);
                instance = obj.AddComponent<FadeManager>();
            }

            return instance;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
