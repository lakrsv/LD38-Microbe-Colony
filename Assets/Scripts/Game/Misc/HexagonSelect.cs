using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonSelect : MonoBehaviour
{
    public static HexagonSelect Instance { get { return _instance; } }
    private static HexagonSelect _instance;

    private PulseAnimation _pulseAnimation;

    private void Start()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Debug.LogError("Only one instance of HexagonSelect is allowed!");
            Destroy(gameObject);
            return;
        }

        _pulseAnimation = GetComponent<PulseAnimation>();
        gameObject.SetActive(false);
    }

    public void Activate(Vector2 position)
    {
        gameObject.SetActive(true);

        gameObject.transform.position = position;
        _pulseAnimation.PlayAnimation();
    }
    public void Deactivate()
    {
        _pulseAnimation.StopAnimation();

        gameObject.SetActive(false);
    }
}
