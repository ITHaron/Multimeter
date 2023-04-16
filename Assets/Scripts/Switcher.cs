using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class Switcher : MonoBehaviour
{
    [SerializeField] private UnityEvent<float> _OnRotation;
    [SerializeField] private int position = 0;
    [SerializeField] private List<float> position_list;

    //[SerializeField] private float rotation_speed = 1;
    private void Start()
    {
        if (position_list.Count == 0)
            position_list = new List<float> { 0F };
        else
            position_list.Sort();
    }


    void OnMouseOver()
    {
        if(Input.GetAxis("Mouse ScrollWheel")!=0)
        {
            SwitherRotation(Input.GetAxis("Mouse ScrollWheel"));
        }
    }
    
    private void SwitherRotation(float direction)
    {
        position += direction > 0 ? 1 : -1;

        if (position >= position_list.Count)
            position = 0;

        if (position < 0)
            position = position_list.Count - 1;


        transform.rotation *= Quaternion.Euler(0f, 0f, position_list[position] - transform.eulerAngles.y);
        _OnRotation.Invoke(position);

        //Вращение без заданных позиций
        //transform.rotation *= Quaternion.Euler(0f, 0f, angle * rotation_speed);
        //_OnRotation.Invoke(transform.eulerAngles.y);
    }
}
