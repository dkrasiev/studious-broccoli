using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] private KeyCode PickupWeaponKey = KeyCode.E;
    public float HorizonalAxis { get; private set; }
    public float VerticalAxis { get; private set; }
    public Boolean IsMoving => HorizonalAxis == 0f && VerticalAxis == 0f;
    public Vector3 InputDirection => new Vector3(HorizonalAxis, 0, -VerticalAxis).normalized;
    public bool PickupWeaponKeyPressed => Input.GetKeyDown(PickupWeaponKey);

    public static InputManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Another InputManager detected!");
        }
    }

    private void Update()
    {
        HorizonalAxis = Input.GetAxisRaw("Horizontal");
        VerticalAxis = Input.GetAxisRaw("Vertical");
    }
}
