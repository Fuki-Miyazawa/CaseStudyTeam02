using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance;

    private static Vector3 TouchOldPosition;

    private InputManager()
    {
        Debug.Log("Create SoundManager instance");
    }

    public static InputManager Instance
    {
        get
        {
            if (instance == null)
            {
                GameObject obj = new GameObject("InputManager");
                DontDestroyOnLoad(obj);
                instance = obj.AddComponent<InputManager>();
            }

            return instance;
        }
    }

    //Android,iphoneの場合はタッチを検出する
    //エディタの場合は左クリックとして判定する

    private static bool isTouch;
    private static bool isTouchTrigger;
    private static bool isTouchRelease;
    private static bool isTouchMove;

    private static Touch touch;

    void Start()
    {
        isTouch = false;
        isTouchTrigger = false;
        isTouchRelease = false;
        isTouchMove = false;

        touch = Input.GetTouch(0);
    }

    void Update()
    {
        UpdateTouch();
    }

    private void UpdateTouch()
    {
        isTouch = false;
        isTouchTrigger = false;
        isTouchRelease = false;
        isTouchMove = false;

        //こちらはエディタの処理
        if (Application.isEditor)
        {
            if(Input.GetMouseButton(0))
            {
                isTouch = true;
            }
            if (Input.GetMouseButtonDown(0))
            {
                isTouchTrigger = true;
            }

            if (Input.GetMouseButtonUp(0))
            {
                isTouchRelease = true;
            }
        }

        //こちらはモバイル系の処理
        else if (Application.isMobilePlatform)
        {
            if (Input.touchCount > 0)
            {
                //タッチしている
                isTouch = true;
                touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {
                    //タッチ開始
                    isTouchTrigger = true;
                }

                else if (touch.phase == TouchPhase.Moved)
                {
                    //ドラッグ
                }

                else if (touch.phase == TouchPhase.Ended)
                {
                    //タッチ終了
                    isTouchRelease = true;
                }
            }
        }
    }

    //タッチ/クリックされているかを判定する。
    public static bool GetTouchPress()
    {
        return isTouch;
    }

    //タッチ/クリックされた瞬間かを判定する。
    public static bool GetTouchTrigger()
    {
        return isTouchTrigger;
    }

    //タッチ/クリックを離した瞬間かを判定する。
    public static bool GetTouchRelease()
    {
        return isTouchRelease;
    }

    public static Vector3 GetTouchPosition()
    {
        Vector3 screenPos = Input.mousePosition;

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);

        return worldPos;
    }

    public static float GetTouchMoveHorizonal()
    {
        if (Application.isEditor)
        {
            return Input.GetAxis("Mouse X");
        }

        else
        {
            touch = Input.GetTouch(0);

            Vector3 vec = touch.position;

            vec.z = 10f;

            vec = Camera.main.ScreenToWorldPoint(vec);

            Vector3 old = vec;

            vec = vec - TouchOldPosition;

            TouchOldPosition = old;

            return vec.x;
        }
    }

    public static float GetTouchMoveVertical()
    {
        if (Application.isEditor)
        {
            return Input.GetAxis("Mouse Y");
        }

        else
        {
            touch = Input.GetTouch(0);

            Vector3 vec = touch.position;

            vec.z = 10f;

            vec = Camera.main.ScreenToWorldPoint(vec);

            Vector3 old = vec;

            vec = vec - TouchOldPosition;

            TouchOldPosition = old;

            return vec.y;
        }
    }
}
