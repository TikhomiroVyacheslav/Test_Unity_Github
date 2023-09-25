using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Ссылка на объект, за которым следит камера.
    public float smoothSpeed = 5f; // Скорость плавного следования камеры.

    private Vector3 offset; // Смещение между камерой и персонажем.

    void Start()
    {
        offset = transform.position - target.position; // Вычисляем начальное смещение.
    }

    void LateUpdate()
    {
        // Вычисляем желаемую позицию камеры.
        Vector3 desiredPosition = target.position + offset;

        // Плавно перемещаем камеру к желаемой позиции.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}










