using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 10;
    public UIManager ui;
    public float bumpForce = 3.0f;
    public bool hasHit = false; //Here to prevent Double Hits

    void Start()
    {
        ui = FindObjectOfType<UIManager>();
        if (ui == null) Debug.LogError("[EnemyDamage] No UIManager found in scene!");
    }
    
    //Commenting out OTE, enemies have colliders that aren't triggers
    /*
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log($"[EnemyDamage] OnTriggerEnter. This: {gameObject.name}, Other: {other.name}, Tag: {other.tag}");
        if (other.CompareTag("Player"))
        {
            Debug.Log($"[EnemyDamage] OnTriggerEnter. This: {gameObject.name}, Other: {other.name}, Tag: {other.tag}");
            if (ui == null) Debug.LogError("[EnemyDamage] UIManager null, can't apply damage");
            else
            {
                ui.TakeDamage(damage);
                Debug.Log("Player hit! -" + damage + " HP");
            }
        }
    }
    */

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !hasHit)
        {
            hasHit = true;
            Invoke("readyUp", 0.2f);
            Debug.Log($"[EnemyDamage] OnCollisionEnter with {collision.gameObject.name} Tag:{collision.gameObject.tag}");
            if (ui == null) Debug.LogError("[EnemyDamage] UIManager null, can't apply damage");
            else
            {
                ui.TakeDamage(damage);
                Debug.Log("Player hit! -" + damage + " HP");
                Vector3 myCenter = transform.position;
                Vector3 contactPoint = collision.GetContact(0).point;

                myCenter.y = contactPoint.y;
                Vector3 forceVector = (contactPoint - myCenter).normalized;
                if (forceVector.magnitude < 0.05f)
                {
                    //Random values between -0.5f and 0.5f
                    forceVector.x = (Random.value - 0.5f);
                    forceVector.z = (Random.value - 0.5f);
                    forceVector = forceVector.normalized;
                    Debug.LogWarning($"Force Vector corrected to [{forceVector.x}, {forceVector.y}, {forceVector.z}] !");
                }

                //Tells the object in script what other object hit that in-script object
                //GameObject.ball = collision.gameObject;

                Rigidbody rb = collision.rigidbody;
                rb.AddForce(forceVector * bumpForce, ForceMode.Impulse);

            }
        }
    }

    private void readyUp()
    {
        hasHit = false;
    }


}