using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CubeCreationEngine.Core
{
    public class StoneBlock : Block
    {
        public Vector2[,] woodBaseBlockUVs = {
        {new Vector2( 0, 0.875f ), new Vector2( 0.0625f, 0.875f),new Vector2( 0, 0.9375f ),new Vector2( 0.0625f, 0.9375f )}, /*STONE*/
        };
        public StoneBlock(Vector3 pos, GameObject p, Material c)
        {
            bType = BlockType.STONE;
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
