using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CubeCreationEngine.Core
{
    public class WoodBaseBlock : Block
    {
        public Vector2[,] woodBaseBlockUVs = {
            {new Vector2( 0.375f, 0.625f ), new Vector2( 0.4375f, 0.65f),new Vector2( 0.375f, 0.6875f ),new Vector2( 0.4375f, 0.6875f )} /*WOOD*/
        };
        public WoodBaseBlock(Vector3 pos, GameObject p, Material c)
        {
            bType = BlockType.WOODBASE;
            parent = p;
            position = pos;
            cubeMaterial = c;
            isSolid = true;
            blockUVs = woodBaseBlockUVs;
            health = BlockHealth.NOCRACK;
            currentHealth = blockHealthMax[(int)bType];
        }
    }
}
