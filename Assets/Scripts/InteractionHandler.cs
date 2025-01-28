using System.Collections.Generic;
using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    private PlayerController _playerController;
    private Camera _camera;
    private List<GameObject> _itemPool = new List<GameObject>();
    private GameObject _itemPrefab;
    private Transform _pickupParent;

    public float pickupDistance = 5f;

    void Start()
    {
        _camera = Camera.main;
        _playerController = GetComponent<PlayerController>();
        _pickupParent = new GameObject("PickupParent").transform;
        _pickupParent.parent = transform;
        _pickupParent.position = transform.position;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckObject();
        }
    }

    void CheckObject()
    {
        var joystick = _playerController.fixedJoystick;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out RaycastHit hit, pickupDistance) && joystick.Vertical == 0 && joystick.Horizontal == 0)
        {
            if (hit.collider.CompareTag("Pickupable"))
            {
                _itemPrefab = hit.collider.gameObject;
                
                ChangeStateItem(_itemPrefab, true, false, _pickupParent.position, _pickupParent);
                
                _itemPool.Add(_itemPrefab);
            }
            else if (hit.collider.CompareTag("Pickup") && _itemPool.Count > 0)
            {
                ChangeStateItem(_itemPool[^1], false, true, hit.transform.position, hit.transform);
                
                _itemPool.Remove(_itemPool[^1]);
            }
        }
    }

    private void ChangeStateItem(GameObject item, bool isKinematic, bool enabledCollider, Vector3 position, Transform parent)
    {
        item.GetComponent<Rigidbody>().isKinematic = isKinematic;
        item.GetComponent<Collider>().enabled = enabledCollider;
        item.transform.position = position;
        item.transform.parent = parent;
    }
}