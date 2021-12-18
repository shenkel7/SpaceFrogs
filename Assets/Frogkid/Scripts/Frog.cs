using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FROGKID
{

    public class Frog : MonoBehaviour
    {
        Rigidbody2D body;

        float horizontal;
        float vertical;

        public float runSpeed = 20.0f;

        [SerializeField]
        SeekMinigame seekMinigame;

        void Start()
        {
            body = GetComponent<Rigidbody2D>();
            body.freezeRotation = true;
        }

        void Update()
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
        }

        private void FixedUpdate()
        {
            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Planet planet = collision.gameObject.GetComponent<Planet>();
            if (planet != null)
            {
                if (planet.getIsHome())
                {
                    seekMinigame.doWin();
                } else
                {
                    seekMinigame.doLose();
                }
            }
                
        }

    }

}