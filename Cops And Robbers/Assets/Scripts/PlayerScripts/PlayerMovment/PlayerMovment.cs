using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Me.DerangedSenators.CopsAndRobbers
{
    public class PlayerMovment : MonoBehaviour
    {

        public float speed = 5f;

        public Rigidbody2D rb;



        Vector2 movment;

        void Update()
        {
            movment.x = Input.GetAxisRaw("Horizontal");
            movment.y = Input.GetAxisRaw("Vertical");
        }



        void FixedUpdate()
        {
            rb.MovePosition(rb.position + movment * speed * Time.fixedDeltaTime);
        }
    }

}
