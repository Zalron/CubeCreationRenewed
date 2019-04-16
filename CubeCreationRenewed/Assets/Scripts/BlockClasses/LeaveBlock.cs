using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeCreationEngine.Core
{
    public class LeaveBlock : Block
    {
        public Vector2[,] leaveBlockUVs = {
            {new Vector2( 0.0625f, 0.375f ), new Vector2( 0.125f, 0.375f),new Vector2( 0.0625f, 0.4375f ),new Vector2( 0.125f, 0.4375f )} /*LEAVES*/
        };
        public LeaveBlock(Vector3 pos, GameObject p, Material c)
        {
            bType = BlockType.LEAVES;
            parent = p;
            position = pos;
            cubeMaterial = c;
            isSolid = true;
            blockUVs = leaveBlockUVs;
            health = BlockHealth.CRACK1;
            currentHealth = blockHealthMax[(int)bType];
        }
    }
}
