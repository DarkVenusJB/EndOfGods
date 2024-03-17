using UnityEngine;

public class TowerHealthSystem : HealthSystem
{
    private int hp;

    private void Awake()
    {
        hp = gameData.towerHP;
    }
    public override void TakeDamage(int amount)
    {
        hp -= amount;

        if (hp <= 0)
            Destroy(gameObject);

    }
}
