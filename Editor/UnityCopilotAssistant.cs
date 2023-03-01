using UnityEngine;
using UnityEditor;

public class UnityCopilotAssistant : MonoBehaviour
{
    [MenuItem("CONTEXT/Object/Go to Unity Copilot")]
    static void GoToUnityCopilot(MenuCommand command)
    {
        string component = command.context.GetType().Name;
        Application.OpenURL("https://unitycopilot.com/search?q=" + component + "#results");
    }
}
using UnityEngine;




public class MouseLook : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float jumpForce = 100.0f;
    public float lookSpeed = 10.0f;
    public float lookXLimit = 60.0f;

    private float _rotX;
    private float _rotY;
    private Rigidbody _rigidBody;

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);
        transform.position += moveDirection * (moveSpeed * Time.deltaTime);

        _rotX -= Input.GetAxis("Mouse Y") * lookSpeed;
        _rotX = Mathf.Clamp(_rotX, -lookXLimit, lookXLimit);

        _rotY += Input.GetAxis("Mouse X") * lookSpeed;

        transform.localRotation = Quaternion.Euler(_rotX, _rotY, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidBody.AddForce(new Vector2(0, jumpForce), ForceMode.Impulse);
        }
    }
}

public class MoveWithCamera : MonoBehaviour
{
    public Transform cameraTransform; // reference to the camera's transform
    public float speed = 1.0f; // the speed at which the object moves

    void Update()
    {
        // get the camera's forward and right vectors
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        // ignore the camera's vertical movement
        forward.y = 0.0f;
        right.y = 0.0f;

        // get the horizontal and vertical input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // calculate the movement direction based on the camera's rotation and the input
        Vector3 direction = (forward * vertical + right * horizontal).normalized;

        // move the object in the calculated direction
        transform.position += direction * speed * Time.deltaTime;
    }
}
