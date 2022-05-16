namespace CustomInput
{
    using System;
    using UnityEngine;

    public class PlayerInput : BaseInput
    {
        public event Action OnFire = delegate { };
        public event Action OnPause = delegate { };

        private bool PauseButtonPressed;

        void Update()
        {
            Horizontal = Input.GetAxisRaw("Horizontal");
            Vertical = Input.GetAxisRaw("Vertical");
            FireWeapons = Input.GetButtonDown("Fire1");
            if (FireWeapons && Time.timeScale != 0)
                OnFire();
            PauseButtonPressed = Input.GetButtonDown("ExitButton");
            if (PauseButtonPressed)
            {
                OnPause();
            }
        }
    }
}