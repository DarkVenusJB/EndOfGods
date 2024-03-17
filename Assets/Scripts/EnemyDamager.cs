using UnityEngine;

public class EnemyDamager : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private GameData gameData;

    private void OnTriggerEnter(Collider other)
    {
        bool isPlayer = other.gameObject.TryGetComponent<HealthSystem>(out var gate);

        if (isPlayer)
        {
            gate.TakeDamage(damage);
            gameData.enemyOnTheLevel--;

            if (gameData.enemyOnTheLevel <= 0)
                GameUI.instance.FinishLevel();

            Destroy(this.gameObject);
        }
           
    }

}
