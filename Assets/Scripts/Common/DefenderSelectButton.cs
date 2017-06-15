using UnityEngine;

namespace Common
{
    public class DefenderSelectButton : MonoBehaviour
    {
        public static GameObject SelectedDefender;
        public GameObject DefenderPrefab;

        private void OnMouseDown()
        {
            if (SelectedDefender)
            {
                SetSelectedDefenderSpriteColor(Color.black);
            }

            SelectedDefender = gameObject;
            SetSelectedDefenderSpriteColor(Color.white);
        }

        private static void SetSelectedDefenderSpriteColor(Color color)
        {
            SelectedDefender.transform
                .GetComponentInChildren<SpriteRenderer>()
                .color = color;
        }
    }
}