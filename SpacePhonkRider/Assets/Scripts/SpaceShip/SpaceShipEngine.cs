namespace SpaceShip
{
    using System;
    using CustomInput;
    using UnityEngine;

    [RequireComponent(typeof(BaseInput))]
    public class SpaceShipEngine : MonoBehaviour
    {
        [SerializeField] private float speed = 3f;

        [SerializeField] private float min_X, max_X;

        [SerializeField] private float min_Y, max_Y;

        private BaseInput shipInput;

        void Awake()
        {
            if (GetComponent<PlayerInput>() != null)
                shipInput = GetComponent<PlayerInput>();
            if (GetComponent<EnemyAI>() != null)
                shipInput = GetComponent<EnemyAI>();
        }

        void Update()
        {
            if (shipInput.Horizontal > 0f)
            {
                var temp = transform.position;
                temp.x += speed * Time.deltaTime;

                if (temp.x > max_X)
                    temp.x = max_X;

                transform.position = temp;
            }
            else if (shipInput.Horizontal < 0f)
            {
                var temp = transform.position;
                temp.x -= speed * Time.deltaTime;

                if (temp.x < min_X)
                    temp.x = min_X;
                transform.position = temp;
            }

            if (shipInput.Vertical > 0f)
            {
                var temp = transform.position;
                temp.y += speed * Time.deltaTime;

                if (temp.y > max_Y)
                    temp.y = max_Y;

                transform.position = temp;
            }
            else if (shipInput.Vertical < 0f)
            {
                var temp = transform.position;
                temp.y -= speed * Time.deltaTime;

                if (temp.y < min_Y)
                    temp.y = min_Y;
                transform.position = temp;
            }
        }
    }
}