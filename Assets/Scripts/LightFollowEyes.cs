﻿using UnityEngine;

[RequireComponent(typeof(GazePointDataComponent), typeof(UserPresenceComponent), typeof(Light))]
public class LightFollowEyes : MonoBehaviour
{
    private GazePointDataComponent _gazePointDataComponent;
    private UserPresenceComponent _userPresenceComponent;
    private Light _lightComponent;


    // Exponential smoothing parameters, alpha must be between 0 and 1.
    [Range(0.1f, 1.0f)]
    public float alpha = 0.3f;
    public float speed = 10f;
    public float shakeReduction = .01f;
    private Vector2 _historicPoint;
    private bool _hasHistoricPoint;

    void Start()
    {
        _gazePointDataComponent = GetComponent<GazePointDataComponent>();
        _userPresenceComponent = GetComponent<UserPresenceComponent>();
        _lightComponent = GetComponent<Light>();
       
    }

    void Update()
    {
        if (InputManager.tobiLight)
        {
            var lastGazePoint = _gazePointDataComponent.LastGazePoint;

            if (_userPresenceComponent.IsValid && _userPresenceComponent.IsUserPresent && lastGazePoint.IsValid)
            {
                var gazePointInScreenSpace = lastGazePoint.Screen;
                var smoothedGazePoint = Smoothify(gazePointInScreenSpace);

                var gazePointInWorldSpace = Camera.main.ScreenToWorldPoint(
                new Vector3(smoothedGazePoint.x, smoothedGazePoint.y, Camera.main.nearClipPlane));
                // Debug.Log("gazePoint in WorldSpace x is " + gazePointInWorldSpace.x);
                //  Debug.Log("gazePoint in WorldSpace y is " + gazePointInWorldSpace.y);
                // var gazePointInWorldSpace = Camera.main.ScreenToWorldPoint(
                //  new Vector3(gazePointInScreenSpace.x, gazePointInScreenSpace.y, Camera.main.nearClipPlane));
                // transform.position = gazePointInWorldSpace;
                float step = speed * Time.deltaTime;
                if (Vector3.Distance(transform.position, gazePointInWorldSpace) > shakeReduction)
                {
                    transform.position = Vector3.MoveTowards(transform.position, gazePointInWorldSpace, step);
                }

                _lightComponent.enabled = true;

            }
            else
            {
                _lightComponent.enabled = false;
                _hasHistoricPoint = false;
            }
        }
        else
        {
            Vector2 smoothedMousePosition = Smoothify(Input.mousePosition);
            Vector3 mouseLight = Camera.main.ScreenToWorldPoint(new Vector3(smoothedMousePosition.x,smoothedMousePosition.y,Camera.main.nearClipPlane));
            float step = speed * Time.deltaTime;
            
            if(Vector3.Distance(transform.position,mouseLight) > shakeReduction)
            {
                transform.position = Vector3.MoveTowards(transform.position, mouseLight, step);
            }
            _lightComponent.enabled = true;
        }
    }

    private Vector2 Smoothify(Vector2 point)
    {
        if (!_hasHistoricPoint)
        {
            _historicPoint = point;
            _hasHistoricPoint = true;
        }

        var smoothedPoint = new Vector2(point.x * alpha + _historicPoint.x * (1.0f - alpha),
            point.y * alpha + _historicPoint.y * (1.0f - alpha));

        _historicPoint = smoothedPoint;

        return smoothedPoint;
    }
}
