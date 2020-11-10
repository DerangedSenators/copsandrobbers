using UnityEngine;


namespace Me.DerangedSenators.CopsAndRobbers
{
    public class Enemy : MonoBehaviour
    {
        public float maxHealth = 100f;
        float currentHealth;

        /// <summary>
        /// Enemy will have a given health in the beginning.
        /// </summary>
        private void Start()
        {
            currentHealth = maxHealth;
        }

        /// <summary>
        /// Health reduces by 20 on every call to this method.
        /// </summary>
        /// <param name="damage"></param>
        public void TakeDamage(float damage)
        {
            currentHealth -= damage;
            if (currentHealth <= 0f)
            {
                Die();
            }
        }

        /// <summary>
        /// This object is destroyed once health is 0.
        /// </summary>
        private void Die()
        {
            Destroy(gameObject);
        }
    }
}