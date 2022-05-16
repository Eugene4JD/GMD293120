namespace Effects
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.Experimental.Rendering.Universal;

    [RequireComponent(typeof(Light2D))]
    public class WavyLightEffect : MonoBehaviour
    {
        [SerializeField] private float maxIntensity;
        [SerializeField] private float minIntensity;
        [SerializeField] private float intensityChangeSpeed;
        [SerializeField] private float timeFrameForIntensity;
        private bool onIntencityIncrease;
        private Light2D lightComponent;

        void Start()
        {
            if (gameObject.GetComponent<Light2D>() != null)
                lightComponent = gameObject.GetComponent<Light2D>();
            InitializeWavingEffect();
        }

        private void OnEnable()
        {
            InitializeWavingEffect();
        }

        private void InitializeWavingEffect()
        {
            if (lightComponent != null)
            {
                lightComponent.intensity = minIntensity;
                onIntencityIncrease = true;
                StartCoroutine(ChangeIntensity());
            }
        }

        IEnumerator ChangeIntensity()
        {
            while (gameObject.activeInHierarchy)
            {
                if (onIntencityIncrease)
                {
                    if (lightComponent.intensity + intensityChangeSpeed >= maxIntensity)
                    {
                        lightComponent.intensity = maxIntensity;
                        onIntencityIncrease = false;
                    }
                    else
                        lightComponent.intensity += intensityChangeSpeed;
                }
                else
                {
                    if (lightComponent.intensity - intensityChangeSpeed <= minIntensity)
                    {
                        lightComponent.intensity = minIntensity;
                        onIntencityIncrease = true;
                    }
                    else
                        lightComponent.intensity -= intensityChangeSpeed;
                }

                yield return new WaitForSeconds(timeFrameForIntensity);
            }
        }
    }
}