using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CubeCreationEngine.Core
{
    public class WoodBlock : Block
    {
        public Vector2[,] woodBlockUVs = {
        {new Vector2( 0.375f, 0.625f ), new Vector2( 0.4375f, 0.65f),new Vector2( 0.375f, 0.6875f ),new Vector2( 0.4375f, 0.6875f )} /*WOOD*/
        };
        public WoodBlock(Vector3 pos, GameObject p, Material c)
        {
            bType = BlockType.WOOD;
            parent = p;
            position = pos;
            cubeMaterial = c;
            isSolid = true;
            blockUVs = woodBlockUVs;
            health = BlockHealth.NOCRACK;
            currentHealth = blockHealthMax[(int)bType];
        }
    }
}

