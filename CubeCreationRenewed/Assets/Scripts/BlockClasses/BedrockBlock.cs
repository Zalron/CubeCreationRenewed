using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CubeCreationEngine.Core
{
    public class BedrockBlock : Block
    {
        public Vector2[,] bedrockBlockUVs = {
        {new Vector2( 0.3125f, 0.8125f ), new Vector2( 0.375f, 0.8125f),new Vector2( 0.3125f, 0.875f ),new Vector2( 0.375f, 0.875f )}, /*BEDROCK*/
        };
        public BedrockBlock(Vector3 pos, GameObject p, Material c)
        {
            bType = BlockType.BEDROCK;
            parent = p;
            position = pos;
            cubeMaterial = c;
            isSolid = true;
            blockUVs = bedrockBlockUVs;
            health = BlockHealth.NOCRACK;
            currentHealth = blockHealthMax[(int)bType];
        }
    }
}
