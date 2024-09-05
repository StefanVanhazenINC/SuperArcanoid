using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AspectrRationUtility : MonoBehaviour
{
    private Camera _camera;
    private float _lastwindowaspect;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
    }
    public void Update()
    {
        AspectRation();
    }

    private void AspectRation() 
    {

        float t_windowaspect = (float)Screen.width / (float)Screen.height;
        

        if (_lastwindowaspect != t_windowaspect) 
        {
            _lastwindowaspect = t_windowaspect;
            float t_targetaspect = 16.0f / 9.0f;


            float t_scaleheight = t_windowaspect / t_targetaspect;



            if (t_scaleheight < 1.0f)
            {
                Rect t_rect = _camera.rect;

                t_rect.width = 1.0f;
                t_rect.height = t_scaleheight;
                t_rect.x = 0;
                t_rect.y = (1.0f - t_scaleheight) / 2.0f;

                _camera.rect = t_rect;
            }
            else
            {
                float t_scalewidth = 1.0f / t_scaleheight;

                Rect t_rect = _camera.rect;

                t_rect.width = t_scalewidth;
                t_rect.height = 1.0f;
                t_rect.x = (1.0f - t_scalewidth) / 2.0f;
                t_rect.y = 0;

                _camera.rect = t_rect;
            }
        }
    }
}
