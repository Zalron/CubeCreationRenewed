using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeCreationEngine.Core
{
    public class GoldBlock : Block
    {
        public Vector2[,] goldBlockUVs = {
            {new Vector2( 0, 0.8125f ), new Vector2( 0.0625f, 0.8125f),new Vector2( 0, 0.875f ),new Vector2( 0.0625f, 0.0875f )}, /*GOLD*/
        };
        public GoldBlock(Vector3 pos, GameObject p, Material c)
        {
            bType = BlockType.GOLD;
            parent = p;
            position = pos;
            cubeMaterial = c;
            isSolid = true;
            blockUVs = goldBlockUVs;
            health = BlockHealth.NOCRACK;
            currentHealth = blockHealthMax[(int)bType];
        }
    }
}
