using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float CameraSpeed = 2f;
    public Transform Target;

    void LateUpdate()
    {
        if (Target != null)
        {
            Vector3 newPos = new Vector3(Target.position.x, Target.position.y, -10f);
            transform.position = Vector3.Lerp(transform.position, newPos, CameraSpeed * Time.deltaTime);
        }
    }
}