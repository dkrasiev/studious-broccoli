using UnityEngine;

public class InputManager : MonoBehaviour
{
    public static PlayerInputActions playerInputActions;

    private void Awake()
    {
        if (playerInputActions == null)
        {
            playerInputActions = new();
            playerInputActions.Player.Enable();
        }
    }
}
