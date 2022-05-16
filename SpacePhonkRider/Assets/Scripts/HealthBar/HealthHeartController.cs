namespace HealthBar
{
    using UnityEngine;

    public class HealthHeartController : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;

        private void Start()
        {
            spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        }

        public void SetSprite(Sprite sprite)
        { 
            spriteRenderer.sprite = sprite;
        }
    }
}