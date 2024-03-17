using UnityEngine;

public class GateHealthSystem : HealthSystem
{
    [SerializeField] private float maxHp;

    public float MaxHP
    {
        get { return maxHp; }
        set { maxHp = value; }
    }

    public override void TakeDamage(int amount)
    {
        MaxHP -= amount;
        GameUI.instance.SetInformationPanel();

        if (MaxHP <= 0)
            GameUI.instance.GameOver();

    }
}
