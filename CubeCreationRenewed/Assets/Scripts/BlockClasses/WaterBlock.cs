using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CubeCreationEngine.Core
{
    public class WaterBlock : Block
    {
        public Vector2[,] WaterBlockUVs = {
            {new Vector2( 0.875f, 0.125f ), new Vector2( 0.9375f, 0.125f),new Vector2( 0.875f, 0.1875f ),new Vector2( 0.9375f, 0.1875f )}, /*WATER*/
        };
        public WaterBlock(Vector3 pos, GameObject p, Material f)
        {
            bType = BlockType.WATER;
            parent = p;
            position = pos;
            cubeMaterial = f;
            isSolid = false;
            blockUVs = WaterBlockUVs;
            health = BlockHealth.NOCRACK;
            currentHealth = blockHealthMax[(int)bType];


        }
    }
}
