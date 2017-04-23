using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityTickUpdater : MonoBehaviour
{
    public static EntityTickUpdater Instance { get { return _instance; } }
    private static EntityTickUpdater _instance;

    public int CurrentTick { get; private set; }

    private List<IUpdateable> _activeEntities = new List<IUpdateable>();
    private List<IUpdateable> _addEntities = new List<IUpdateable>();
    private List<IUpdateable> _removeEntities = new List<IUpdateable>();

    private bool _updateEntities = false;

    private void Awake()
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
    }

    public void RegisterCompartment(IUpdateable updateable)
    {
        //Defense!
        if (_removeEntities.Contains(updateable))
        {
            Debug.LogError("Tried to register a compartment that is about to be deregistered!");
            return;
        }

        if (!_activeEntities.Contains(updateable) && !_addEntities.Contains(updateable))
        {
            _addEntities.Add(updateable);
        }
        else
        {
            Debug.LogError("Tried to register a compartment that is already registered!");
            return;
        }

        if (!_updateEntities)
        {
            _updateEntities = true;
            StartCoroutine(UpdateEntities());
        }
    }

    public void DeregisterCompartment(IUpdateable updateable)
    {
        //Defense!
        if (_addEntities.Contains(updateable))
        {
            Debug.LogError("Tried to deregister a compartment that is about to be registered!");
            return;
        }

        if (_activeEntities.Contains(updateable) && !_removeEntities.Contains(updateable))
        {
            _removeEntities.Add(updateable);
        }
        else
        {
            Debug.LogError("Tried to deregister a compartment that isn't registered!");
            return;
        }
    }

    private IEnumerator UpdateEntities()
    {
        while (_updateEntities)
        {
            yield return new WaitForSeconds(1f / Constants.TickRate.Default);

            _activeEntities.AddRange(_addEntities);
            _addEntities.Clear();

            //TODO - Potentially very expensive. Perhaps not use 3 lists?
            _activeEntities.RemoveAll(x => _removeEntities.Contains(x));
            _removeEntities.Clear();

            //Update Compartments
            foreach (var compartment in _activeEntities)
            {
                compartment.OnTick();
            }

            CurrentTick++;
        }
    }
}
