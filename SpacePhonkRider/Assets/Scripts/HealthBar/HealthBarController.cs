namespace HealthBar
{
    using UnityEngine;
    using HealthControl;

    public class HealthBarController : MonoBehaviour
    {
        [field: SerializeField] public Sprite[] HeartStates { get; set; }

        [field: SerializeField] public GameObject HeroObject { get; set; }

        [field: SerializeField] public GameObject[] HealthHearts { get; set; }

        private int HeroHealth;

        private BaseHealthController HealthController;


        private void Start()
        {
            HealthController = HeroObject.GetComponent<BaseHealthController>();
            HealthController.OnHealthChanged += OnHealthChange;
        }

        private void OnHealthChange()
        {
            HeroHealth = HealthController.Health;
            ReRenderHearts();
        }

        private void ReRenderHearts()
        {
            var heroHealthIndex = HeroHealth;
            foreach (var t in HealthHearts)
            {
                if (heroHealthIndex - 2 >= 0)
                    t.GetComponent<HealthHeartController>().SetSprite(HeartStates[0]);
                else if (heroHealthIndex - 2 == -1)
                    t.GetComponent<HealthHeartController>().SetSprite(HeartStates[1]);
                else if (heroHealthIndex - 2 < -1)
                    t.GetComponent<HealthHeartController>().SetSprite(HeartStates[2]);
                heroHealthIndex -= 2;
            }
        }
    }
}