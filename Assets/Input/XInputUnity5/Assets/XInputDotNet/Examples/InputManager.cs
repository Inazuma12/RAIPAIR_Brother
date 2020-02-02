using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure; // Required in C#

[System.Serializable]
public class Joystick
{
    public PlayerIndex playerIndex;
    private GamePadState state;
    public GamePadState prevState;

    public GamePadState State
    {
        get
        {
            return state;
        }
        set
        {
            state = value;
        }
    }

    public  bool APressed
    {
        get
        {
            return State.Buttons.A == ButtonState.Pressed;
        }
    }

    public  bool XPressed
    {
        get
        {
            return prevState.Buttons.X == ButtonState.Released &&  State.Buttons.X == ButtonState.Pressed;
        }
    }

    public GamePadDPad GamePadDPad
    {
        get
        {
            return State.DPad;
        }
    }

    public bool Left
    {
        get
        {
            return GamePadDPad.Left == ButtonState.Pressed;
        }
    }

    public  bool Right
    {
        get
        {
            return GamePadDPad.Right == ButtonState.Pressed;
        }
    }

    public bool Up
    {
        get
        {
            return GamePadDPad.Up == ButtonState.Pressed;
        }
    }

    public  bool Down
    {
        get
        {
            return GamePadDPad.Down == ButtonState.Pressed;
        }
    }
}

public class InputManager : MonoBehaviour
{
    static InputManager instance;
    bool playerIndexSet = false;
    PlayerIndex playerIndex;
    GamePadState state;
    GamePadState prevState;

    public List<Joystick> joysticks = new List<Joystick>();


    public static InputManager Instance { get => instance; set => instance = value; }

    private void Awake()
    {
        instance = this;
        if (joysticks.Count < 2)
        {
            for (int i = 0; i < 4; ++i)
            {
                PlayerIndex testPlayerIndex = (PlayerIndex)i;
                GamePadState testState = GamePad.GetState(testPlayerIndex);
                if (testState.IsConnected)
                {
                    Debug.Log(string.Format("GamePad found {0}", testPlayerIndex));
                    Joystick joystick = new Joystick();
                    joystick.playerIndex = testPlayerIndex;
                    joysticks.Add(joystick);
                }
            }
        }
    }

    private void Update()
    {
     

      

        for (int i = 0; i < joysticks.Count; i++)
        {
            joysticks[i].prevState = joysticks[i].State;
            joysticks[i].State = GamePad.GetState(joysticks[i].playerIndex);
        }


    }

    public Joystick GetJoystick(int index)
    {
        if (index >= 0 && index < joysticks.Count)
        {
            return joysticks[index]; 
        }
        return null;
    }

    
}
