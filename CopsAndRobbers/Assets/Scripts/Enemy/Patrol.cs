/* 
 *  Copyright (C) 2021 Deranged Senators
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *  
 *      http:www.apache.org/licenses/LICENSE-2.0
 *  
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed;
    public float waitTime;
    public float startWaitTime;

    public Transform[] moveSpots;
    private int randomSpot;

    public Animator animator;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;

    Vector2 movement;
    

    void Start() 
    {
        //random number in the start function, random between elements in the array
        randomSpot = Random.Range(0,moveSpots.Length);

    }

    void Update() 
    {
        //gets character to move towards location, random position in the array, speed
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        //checking if character has reached destination, makes character wait and move to another random location
        //checks distance between character and destination
        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f) 
        {
            //checks if time for character to move to another destination
            if (waitTime <= 0)
            {
                //random spot generation
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else 
            {
                waitTime -= Time.deltaTime;
            }
        }
        //uses animations for when the character moves
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

    }

    void FixedUpdate() 
    {
        //character animation movement 
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
