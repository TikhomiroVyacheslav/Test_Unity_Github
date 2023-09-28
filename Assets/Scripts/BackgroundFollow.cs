using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    public Transform target; // ������ �� ������, �� ������� ������ ������.
    public float smoothSpeed = 5f; // �������� �������� ���������� ������.

    private float offset; // �������� ����� ������� � ����������.

    void Start()
    {
        offset = transform.position.x - target.position.x; // ��������� ��������� ��������.
    }

    void LateUpdate()
    {
        // ��������� �������� ������� ������.
        Vector3 desiredPosition = new Vector3(target.position.x + offset, transform.position.y, transform.position.z);

        // ������ ���������� ������ � �������� �������.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}