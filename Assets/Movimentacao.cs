using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentacao : MonoBehaviour
{
    public Transform cam;
    Camera _camera;
   // public Transform particle;
    Transform player;
    Rigidbody rb;

    public float speed = 10f;
    float currentX = 0f;
    float currentY = 0f;
    [Space]
    [Header("Sensibilidades")]
    [SerializeField] float sensitivityX = 2f;
    [SerializeField] float sensitivityY = 1f;
    [SerializeField] float zoomSensitivity = 10f;
    float distance = 12f;

    float yAngleMin = 0f;
    float yAngleMax = 50f;

    CharacterController charController;

    // Start is called before the first frame update
    void Start()
    {
        _camera = cam.GetComponent<Camera>();
        charController = GetComponent<CharacterController>();
        LockCursor();
        player = transform;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Vector3 Move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // rb.velocity = Move;
        float horizInput = Input.GetAxis("Horizontal") * speed * 0.8f;
        float vertInput = Input.GetAxis("Vertical") * speed;
        Vector3 fowardMovement = player.forward * vertInput;
        Vector3 rightMovement = player.right * horizInput;
        charController.SimpleMove(fowardMovement + rightMovement);



        currentX += Input.GetAxis("Mouse X") * sensitivityX;
        currentY -= Input.GetAxis("Mouse Y") * sensitivityY;
        currentY = Mathf.Clamp(currentY, yAngleMin, yAngleMax);
        Quaternion rotation = Quaternion.Euler(0, currentX, 0);
        player.rotation = rotation;
        // rb.AddForce(Vector3.forward + Move * speed);

        _camera.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;
        _camera.fieldOfView = Mathf.Clamp(_camera.fieldOfView, 10f, 31f);

    }

    void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        cam.position = player.position + rotation * dir;
        cam.LookAt(player.position);
      //  particle.position = new Vector3( player.position.x +0.1f, player.position.y, player.position.z);
    }

    void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
