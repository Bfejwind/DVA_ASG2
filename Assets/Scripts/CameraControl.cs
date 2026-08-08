using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float _distanceFromTarget = 0f;

    private float sensitivity = 1000f;
    private float yaw = 0f;
    private float pitch = 0f;
    private void Start()
    {
        Vector3 angles = transform.eulerAngles;

        yaw = angles.y;
        pitch = angles.x;

        if (pitch > 180f)
            pitch -= 360f;
    }
    private void Update()
    {
        HandleInput();
        Quaternion yawRotation = Quaternion.Euler(pitch, yaw, 0);
        RotateCamera(yawRotation);
    }
    public void HandleInput()
    {
        Vector2 inputDelta = Vector2.zero;
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            inputDelta = touch.deltaPosition;
        }
        else if (Input.GetMouseButton(1))
        {
            inputDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        }
        yaw += inputDelta.x * sensitivity * Time.deltaTime;
        pitch -= inputDelta.y * sensitivity * Time.deltaTime;
    }
    public void RotateCamera(Quaternion rotation)
    {
        Vector3 positionOffset = rotation * new Vector3(0,0, -_distanceFromTarget);
        transform.position = target.position + positionOffset;
        transform.rotation = rotation;
    }
}
