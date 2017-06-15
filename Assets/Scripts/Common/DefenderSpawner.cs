using System;
using UnityEngine;

namespace Common
{
    public class DefenderSpawner : MonoBehaviour
    {
        public Camera Camera;
        
        private GameObject _parent;

        private void Start()
        {
            _parent = GameObject.Find("Defenders");
            if (!_parent)
            {
                _parent = new GameObject("Defenders");
            }
        }

        private void OnMouseDown()
        {
            var position = WorldGridPosition(Input.mousePosition);
            var activeButton = DefenderSelectButton.SelectedDefender;
            if (!activeButton) return;
            var defender = activeButton.GetComponent<DefenderSelectButton>().DefenderPrefab;
            Instantiate(defender, position, Quaternion.identity, _parent.transform);
        }

        private Vector3 WorldGridPosition(Vector3 mousePosition)
        {
            Vector2 worldPoint = Camera.ScreenToWorldPoint(mousePosition);
            worldPoint = new Vector2(
                Mathf.RoundToInt(worldPoint.x),
                Mathf.RoundToInt(worldPoint.y)
            );
            return worldPoint;
        }
    }
}