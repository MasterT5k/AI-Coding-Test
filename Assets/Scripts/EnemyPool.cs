using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public readonly static HashSet<Enemy> enemies = new HashSet<Enemy>();

    public static Enemy FindClosestEnemy(Vector3 pos)
    {
        Enemy result = null;
        float distance = float.PositiveInfinity;
        var enemy = enemies.GetEnumerator();

        while (enemy.MoveNext() == true)
        {
            float currentDistance = (enemy.Current.transform.position - pos).sqrMagnitude;
            //float currentDistance = Vector3.Distance(enemy.Current.transform.position, pos);
            if (currentDistance < distance)
            {
                result = enemy.Current;
                distance = currentDistance;
            }
        }
        return result;
    }
}
