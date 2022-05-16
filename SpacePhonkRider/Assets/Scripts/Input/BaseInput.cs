namespace CustomInput
{
    using UnityEngine;

    public abstract class BaseInput : MonoBehaviour
    {
        public float Horizontal { get; set; }
        public float Vertical { get; set; }
        public bool FireWeapons { get; set; }
    }
}