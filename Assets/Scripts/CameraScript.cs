using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] Transform player;
    [Range(0.1f, 100f)]
    [SerializeField] float rotationSpeed;
    [Range(0, 360)]
    [SerializeField] float rotationAngle =0;
    
    
    private Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.position;
    }

    public void Follow()
    {
        transform.position = RotatePoinAroundPivot(player.position + offset, player.position, rotationAngle);
        transform.LookAt(player.position);
    }

    public void rotate(float delta)
    {
        rotationAngle += delta * rotationSpeed * Time.deltaTime;
    }

    public Vector3 GetDirection(Vector3 dir)
    {
        return  transform.TransformDirection(dir);
    }

    public Vector3 RotatePoinAroundPivot(Vector3 point, Vector3 pivot, float angle)
    {
        return Quaternion.Euler(0, angle, 0) * (point - pivot) + pivot;
    }
}