using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    private float smoothTime = 0.2f;
    private float yOffset = 2;

    [SerializeField]
    private float leftLimit;
    [SerializeField]
    private float rightLimit;
    [SerializeField]
    private float bottomLimit;
    [SerializeField]
    private float topLimit;

    private Vector3 _velocity;

    private void LateUpdate()
    {
        if (target != null)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y + yOffset, transform.position.z);

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, smoothTime);

            transform.position = new Vector3(
                Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
                Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
                transform.position.z);
        }
        
    }
}
