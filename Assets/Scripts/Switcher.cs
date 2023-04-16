using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Switcher : MonoBehaviour
{
    [SerializeField] private UnityEvent<float> _OnRotation;
    [SerializeField] private float rotation_speed = 1;

    void OnMouseOver()
    {
        if(Input.GetAxis("Mouse ScrollWheel")!=0)
        {
            SwitherRotation(Input.GetAxis("Mouse ScrollWheel"));
        }
    }
    
    private void SwitherRotation(float angle)
    {
        transform.rotation *= Quaternion.Euler(0f, 0f, angle * rotation_speed);
        _OnRotation.Invoke(transform.eulerAngles.y);
    }
}
