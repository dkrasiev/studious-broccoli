using System;
using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{
    [SerializeField] public KeyCode JumpKey = KeyCode.Space;
    [SerializeField] public KeyCode PickupWeaponKey = KeyCode.E;
    [SerializeField] public KeyCode ShootKey = KeyCode.Mouse0;
    [SerializeField] public KeyCode DropWeaponKey = KeyCode.G;
    public float HorizonalAxis { get; private set; }
    public float VerticalAxis { get; private set; }
    public Boolean IsMoving => HorizonalAxis == 0f && VerticalAxis == 0f;
    public Vector3 InputDirection => new Vector3(HorizonalAxis, 0, -VerticalAxis).normalized;
    public UnityEvent PickupWeaponKeyPressed;
    public UnityEvent JumpKeyPressed;
    public UnityEvent ShootKeyPressed;
    public UnityEvent DropWeaponKeyPressed;

    public static InputManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("Another InputManager detected!");
    }

    private void Update()
    {
        HorizonalAxis = Input.GetAxisRaw("Horizontal");
        VerticalAxis = Input.GetAxisRaw("Vertical");

        if (Input.GetKeyDown(JumpKey))
            JumpKeyPressed.Invoke();

        if (Input.GetKeyDown(PickupWeaponKey))
            PickupWeaponKeyPressed.Invoke();

        if (Input.GetKeyDown(ShootKey))
            ShootKeyPressed.Invoke();
    }
}
