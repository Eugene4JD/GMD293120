using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Background
{
    public class PlanetMovementController : MonoBehaviour
    {
        [field: SerializeField] public int PlanetSpeed { get; set; }

        private void Update()
        {
            var temp = transform.position;
            temp.y -= PlanetSpeed * Time.deltaTime;
            transform.position = temp;
        }
    }
}