using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Shmup
{
    public class BossStage : MonoBehaviour
    {
        public List<Enemy> enemySystems;
        public bool IsBossInvulnerable = true;


        public bool IsStageComplete()
        {
            return enemySystems.All(system => system == null || !(system.GetHealthNormalized() > 0));
        }
    }
}