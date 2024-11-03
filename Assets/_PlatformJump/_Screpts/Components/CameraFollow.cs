using UnityEngine;


public class CameraFollow : MonoBehaviour, IService
{
    [SerializeField] private Vector3 _offset = new Vector3(0, 0, -10); // Смещение камеры по оси Z
    [SerializeField] private float _smoothSpeed = 0.125f; // Скорость следования камеры

    private Transform _target; // Объект, за которым следует камера (игрок)

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void LateUpdate()
    {
        if (_target == null)
        {
            return;
        }

        Vector3 desiredPosition = _target.position + _offset; // Желаемая позиция камеры
        Vector3 smoothedPosition =
            Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed); // Плавное перемещение
        transform.position = smoothedPosition; // Устанавливаем позицию камеры
    }
}