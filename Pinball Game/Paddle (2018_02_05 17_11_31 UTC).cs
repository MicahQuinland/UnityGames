using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour 
{

    public float moveSpeed = 30;
	public AudioClip paddleSound;

		
	void Update () 
    {
        float moveInput = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        transform.position += new Vector3(moveInput, 0, 0);

        float max = 14.0f;
        if (transform.position.x <= -max || transform.position.x >= max)
        {
            float xPos = Mathf.Clamp(transform.position.x, -max, max); //Clamp between min -5 and max 5
            transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
        }
				if (PinballGame.SP.score % 300 == 0 && PinballGame.SP.score > 0){
						if (moveSpeed >= 15){
						moveSpeed = moveSpeed - 2;
						}
						if (PinballGame.SP.score <= 1200){
						transform.localScale -= new Vector3 (.3f,0,0);
						}
				}
	} 

    void OnCollisionExit(Collision collisionInfo) 
    {
        // Add X velocity..otherwise the ball would only go up & down
		GetComponent<AudioSource>().PlayOneShot (paddleSound);
        Rigidbody rigid = collisionInfo.rigidbody;
        float xDistance = rigid.position.x - transform.position.x;
        rigid.velocity = new Vector3(rigid.velocity.x + xDistance/2, rigid.velocity.y, rigid.velocity.z);
    }
}
