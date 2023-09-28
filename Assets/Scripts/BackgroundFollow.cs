using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    public Transform target; // Ссылка на объект, за которым следит камера.
    public float smoothSpeed = 5f; // Скорость плавного следования камеры.

    private float offset; // Смещение между камерой и персонажем.

    void Start()
    {
        offset = transform.position.x - target.position.x; // Вычисляем начальное смещение.
    }

    void LateUpdate()
    {
        // Вычисляем желаемую позицию камеры.
        Vector3 desiredPosition = new Vector3(target.position.x + offset, transform.position.y, transform.position.z);

        // Плавно перемещаем камеру к желаемой позиции.
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}