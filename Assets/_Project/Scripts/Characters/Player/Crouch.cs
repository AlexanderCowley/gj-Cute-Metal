using UnityEngine;

public class Crouch : MonoBehaviour
{
    CharacterController _controller;
    bool _isCrouched = false;
    float _standingHieght;
    Vector3 _standingCenter;

    void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _standingHieght = _controller.height;
        _standingCenter = _controller.center;
    }
    void CrouchOnInput()
    {
        _controller.height = 1f;
        _controller.center = new Vector3(0f, -0.5f, 0f);
        transform.localScale = new Vector3(1f, .75f, 1f);
    }

    void StandUpOnInput()
    {
        _controller.height = _standingHieght;
        _controller.center = _standingCenter;
        transform.localScale = Vector3.one;
        transform.localPosition = new Vector3(transform.localPosition.x, .5f, transform.localPosition.z);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            _isCrouched = !_isCrouched;

        if (_isCrouched)
            CrouchOnInput();

        if (!_isCrouched)
            StandUpOnInput();
    }
}