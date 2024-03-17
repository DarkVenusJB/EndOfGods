using UnityEngine;

public class EnemyHealthSystem : HealthSystem
{
    [SerializeField] private int priceForDestroy;

    private int hp;

    private void Awake()
    {
        hp = gameData.enemyHP;
    }
    public override void TakeDamage(int amount)
    {
        hp -= amount;

        if (hp <= 0)
            Die();
    }

    private void Die()
    {
        gameData.coins += priceForDestroy;
        gameData.enemyOnTheLevel--;

        if(gameData.enemyOnTheLevel<=0)
            GameUI.instance.FinishLevel();

        GameUI.instance.SetInformationPanel();
        Destroy(gameObject);
    }
}
