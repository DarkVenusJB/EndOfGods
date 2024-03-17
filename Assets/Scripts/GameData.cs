using UnityEngine;

[CreateAssetMenu]
public class GameData : ScriptableObject
{ 
    [SerializeField] private int _towerHP;
    [SerializeField] private int _enemyHP;
    [SerializeField] private int _enemyOnTheLevel;

    private int _coins;
    private int _waveNumber;
   

    public int towerHP
    {
        get { return _towerHP; }
    }

    public int enemyHP
    {
        get { return _enemyHP; }
    }


    //Используются для получения и изменения данных в различных компонентах
    public int coins   
    {
        get 
        {
            if (_coins<0)
            {
                return 0;
            }
            else
                return _coins; 
        }

        set 
        {
                _coins = value;
        }

    }

    public int waveNumber
    {
        get { return _waveNumber; }

        set { _waveNumber = value; }
    }

    public int enemyOnTheLevel
    {
        get { return _enemyOnTheLevel; }
        set { _enemyOnTheLevel = value; }
    }

}

