using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlighting : MonoBehaviour
{
    private Color m_MouseOverColor = new Color(0.77F, 0.77F, 0.69F);
    private Color m_OriginalColor;
    private MeshRenderer m_Renderer;

    void Start()
    {
        m_Renderer = GetComponent<MeshRenderer>();
        m_OriginalColor = m_Renderer.material.color;
    }

    void OnMouseEnter()
    {
        m_Renderer.material.color = m_MouseOverColor;
        
    }

    void OnMouseExit()
    {
        m_Renderer.material.color = m_OriginalColor;
    }
}