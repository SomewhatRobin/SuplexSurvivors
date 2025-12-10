using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage = 10;
    UIManager ui;

    void Start()
    {
        ui = FindObjectOfType<UIManager>();
        if (ui == null) Debug.LogError("[EnemyDamage] No UIManager found in scene!");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"[EnemyDamage] OnTriggerEnter. This: {gameObject.name}, Other: {other.name}, Tag: {other.tag}");
        if (other.CompareTag("Player"))
        {
            if (ui == null) Debug.LogError("[EnemyDamage] UIManager null, can't apply damage");
            else
            {
                ui.TakeDamage(damage);
                Debug.Log("Player hit! -" + damage + " HP");
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"[EnemyDamage] OnCollisionEnter with {collision.gameObject.name} Tag:{collision.gameObject.tag}");
    }
}