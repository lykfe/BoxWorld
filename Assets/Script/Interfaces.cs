using UnityEngine;
using System.Collections;

public interface IDamageble<T>
{
    bool TakeDamage(T damageAmount);
}


