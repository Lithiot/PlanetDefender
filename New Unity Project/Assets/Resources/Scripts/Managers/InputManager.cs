using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TouchState
{
    Idle, Pressed, Ended
}

public class InputManager : GenericSingleton<InputManager>
{
    public TouchState inputState = TouchState.Idle;

    public override void Awake()
    {
        base.Awake();
    }

    private void Update()
    {
        if (!GameManager.instance.isGameOver)
        {
            /* 
            if (Input.GetKey(KeyCode.Space))
            else if (Input.GetKeyUp(KeyCode.Space))
                inputState = TouchState.Ended;
            else
                inputState = TouchState.Idle;
            */
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);

                switch (touch.phase)
                {
                    case TouchPhase.Moved:
                        inputState = TouchState.Pressed;
                        break;
                    case TouchPhase.Stationary:
                        inputState = TouchState.Pressed;
                        break;
                    case TouchPhase.Ended:
                        inputState = TouchState.Ended;
                        break;
                    case TouchPhase.Canceled:
                        inputState = TouchState.Ended;
                        break;
                    default:
                        inputState = TouchState.Idle;
                        break;
                }
            }
            else
                inputState = TouchState.Idle;
        }
        else
            inputState = TouchState.Idle;

    }
}
