using UnityEngine;

public class CompartmentCentreSelector : MonoBehaviour, ISelectable
{
    private CompartmentController _compartmentController;

    public void OnSelect()
    {
        if (_compartmentController == null)
            _compartmentController = transform.parent.GetComponent<CompartmentController>();

        _compartmentController.OnSelect();
    }
}
