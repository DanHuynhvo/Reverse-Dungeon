using UnityEngine;

public interface IAttack
{

    float Range { get; }

    void Attack (Transform targer);

}
