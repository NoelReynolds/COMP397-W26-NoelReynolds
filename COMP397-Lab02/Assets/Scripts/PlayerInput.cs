using UnityEngine;
using UnityEngine.InputSystem;
using KBCore.Refs;

//[RequireComponent(typeof(CharacterController))]

public class PlayerInput : MonoBehaviour
{
    private InputAction move;
    private InputAction look;
    [SerializeField] private float maxSpeed = 10.0f;
    [SerializeField] private float gravity = -30.0f;
    private Vector3 velocity;
    [SerializeField] private float rotationSpeed = 60.0f;
    [SerializeField] private float mouseSensitivity = 5.0f;
    [SerializeField, Self] private CharacterController controller;
    [SerializeField, Child] private Camera cam;

    //public CharacterController character;

    private void OnValidate()
    {
        this.ValidateRefs();
    }

    void Start()
    {
        move = InputSystem.actions.FindAction("Player/Move");
        look = InputSystem.actions.FindAction("Player/Look");
        /*controller = GetComponent<CharacterController>();
        if (controller != null)
        {
            controller = gameObject.AddComponent<CharacterController>();
        }*/
    }

    void Update()
    {
        Vector2 readMove = move.ReadValue<Vector2>();
        //Debug.Log(readMove);

        /*if (Input.GetKeyDown(KeyCode.W))
        {
            Vector2 moveUp = new Vector2(0, 1);
        }*/

        Vector2 readLook = look.ReadValue<Vector2>();

        Vector3 movement = transform.right * readMove.x + transform.forward * readMove.y;
        //controller.Move(movement * maxSpeed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        movement *= maxSpeed * Time.deltaTime;
        movement += velocity;
        controller.SimpleMove(movement);

        transform.Rotate(Vector3.up, readLook.x * rotationSpeed * Time.deltaTime);

        mouseSensitivity = mouseSensitivity * readLook.y;
        mouseSensitivity = Mathf.Clamp(mouseSensitivity, -90f, 90f);
        cam.gameObject.transform.localRotation = Quaternion.Euler(mouseSensitivity * readLook.y, 0, 0);
    }
}
