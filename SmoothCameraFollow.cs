using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
    #region Variables

    private Vector3 _offset;
    [SerializeField] private Transform target;
    [SerializeField] private float smoothTime;
    private Vector3 _currentVelocity = Vector3.zero;
    [SerializeField] private float rotationSpeed = 5f;
    private float mouseX;
    private float mouseY;

    #endregion

    #region Unity callbacks

    private void Awake() => _offset = transform.position - target.position;

    private void LateUpdate()
    {
        // Follow target
        Vector3 targetPosition = target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);

        // Rotate camera around the target based on mouse horizontal movement
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;

        // Clamp vertical rotation to limit camera flipping
        mouseY = Mathf.Clamp(mouseY, -90f, 90f);

        Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0f);
        transform.position = target.position + rotation * _offset;
        transform.LookAt(target.position);
    }

    #endregion
}