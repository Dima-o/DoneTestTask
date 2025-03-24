using UnityEngine;
using UnityEngine.InputSystem;

public class Input : MonoBehaviour
{
    public bool click;

    public void OnClick(InputValue value)
    {
        click = value.isPressed;
    }
}
