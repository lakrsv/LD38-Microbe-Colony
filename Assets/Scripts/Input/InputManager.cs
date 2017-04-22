using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            var hit = Physics2D.Raycast(touchPosition, Vector2.zero);
            var collider = hit.collider;

            if (collider != null)
            {
                var selectable = hit.collider.GetComponent<ISelectable>();
                if (selectable != null)
                {
                    selectable.OnSelect();
                }
            }
        }
    }
}
