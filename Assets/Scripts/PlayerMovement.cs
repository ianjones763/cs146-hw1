using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	// This is a reference to the Rigidbody component called "rb"
	public Rigidbody rb;
    public CharacterController c;

	public float forwardForce;	// Forward movement speed
	public float sidewaysForce;  // Sideways movement speed
    public float upwardsForce;   // Jumping

    private bool onGround = true;

	// We marked this as "Fixed"Update because we
	// are using it to mess with physics.
	void FixedUpdate ()
	{
        rb.freezeRotation = true;
        // Add a forward force
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

		if (Input.GetKey("d"))	// If the player is pressing the "d" key
        {
			// Add a force to the right
			rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}

		if (Input.GetKey("a"))  // If the player is pressing the "a" key
		{
			// Add a force to the left
			rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
		}

        if (Input.GetKey("w"))
        {
            if (onGround)
            {
                rb.AddForce(0, upwardsForce * Time.deltaTime, 0, ForceMode.VelocityChange);
                onGround = false;
            }
        }

		if (rb.position.y < -1f)
		{
			FindObjectOfType<GameManager>().EndGame();
		}
	}

    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.CompareTag("Ground")) 
        {
            onGround = true;
        }
    }
}
