using System;
using UnityEngine;

public class FirstCamera : MonoBehaviour
{
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }

    private const RotationAxes Axes = RotationAxes.MouseXAndY;
    public float MaximumY = 60F;
    public float MinimumY = -60F;
    private float _rotationY;
    public float SensitivityX = 50F;
    public float SensitivityY = 50F;

    private void Update()
    {
        switch (Axes)
        {
            case RotationAxes.MouseXAndY:
            {
                var rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * SensitivityX;

                _rotationY += Input.GetAxis("Mouse Y") * SensitivityY;
                _rotationY = Mathf.Clamp(_rotationY, MinimumY, MaximumY);

                transform.localEulerAngles = new Vector3(-_rotationY, rotationX, 0);
                break;
            }
            default:
                throw new ArgumentOutOfRangeException();
        }

        Vector3 now;
        now.y = now.x = 0;
        now.z = 1;
        if (Input.GetKey("up"))
            transform.Translate(now * Time.deltaTime);
        if (Input.GetKey("down"))
            transform.Translate(-now * Time.deltaTime);
        if (Input.GetKey("right"))
            transform.Translate(Vector3.right * Time.deltaTime);
        if (Input.GetKey("left"))
            transform.Translate(-Vector3.right * Time.deltaTime);
    }
}