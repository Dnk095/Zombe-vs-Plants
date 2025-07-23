using UnityEngine;

public class CameraMover : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotateSpeed;
    [SerializeField] private float _zoomSpeed;
    [SerializeField] private float _maxZoom;
    [SerializeField] private float _minZoom;

    private void Update()
    {
        if (_inputReader.VerticalDirection != 0)
            Move();

        if (_inputReader.HorizontalDirection != 0)
            Rotate();

        if (_inputReader.VerticalZoom != 0)
            Zoom();

    }

    private void Zoom()
    {
        Vector3 direction = new(0f, -_inputReader.VerticalZoom, 0f);

        if (transform.position.y <= _maxZoom && transform.position.y >= _minZoom)
        {
            transform.Translate(_zoomSpeed * Time.deltaTime * direction);

            if (transform.position.y > _maxZoom)
                transform.position = new Vector3(transform.position.x, _maxZoom, transform.position.z);
            else if (transform.position.y < _minZoom)
                transform.position = new Vector3(transform.position.x, _minZoom, transform.position.z);
        }
    }

    private void Move()
    {
        Vector3 direction = new(0f, 0f, _inputReader.VerticalDirection);

        transform.Translate(_speed * direction * Time.fixedDeltaTime);
    }

    private void Rotate()
    {
        transform.Rotate(_inputReader.HorizontalDirection * _rotateSpeed * Time.fixedDeltaTime * Vector3.up);
    }
}