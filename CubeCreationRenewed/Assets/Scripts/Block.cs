using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace CubeCreationEngine.Core
{
    public class Block
    {

        enum Cubeside { BOTTOM, TOP, LEFT, RIGHT, FRONT, BACK };
        public enum BlockType {
            GRASS,
            DIRT,
            WATER,
            STONE,
            AIR,
            LEAVES,
            WOOD,
            WOODBASE,
            SAND,
            GOLD,
            BEDROCK,
            REDSTONE,
            DIAMOND
        };
        public enum BlockHealth
        {
            NOCRACK,
            CRACK1,
            CRACK2,
            CRACK3,
            CRACK4,
            CRACK5,
            CRACK6,
            CRACK7,
            CRACK8
        };
        public BlockType bType;
        public bool isSolid;
        public Chunk owner; // the chunk that the block belongs to
        public GameObject parent;
        public Vector3 position;
        public Material cubeMaterial;
        public Material fluidMaterial;
        public BlockHealth health; // set to the maxium health for each block which is set at SetType to NoCrack and adds with every punch 
        public int currentHealth; // the current health of the block
        public int[] blockHealthMax = { 3, 3, 8, 4, 1, 2, 2, 2, 4, -1, 4, 4, 0};
        public Vector2[,] blockUVs = {
        {new Vector2( 0.125f, 0.9375f ), new Vector2( 0.1875f, 0.9375f), new Vector2( 0.125f, 1.0f ), new Vector2( 0.1875f, 1.0f )}, // Top
		{new Vector2( 0.125f, 0.9375f ), new Vector2( 0.1875f, 0.9375f), new Vector2( 0.125f, 1.0f ), new Vector2( 0.1875f, 1.0f )}, // Side
		{new Vector2( 0.125f, 0.9375f ), new Vector2( 0.1875f, 0.9375f), new Vector2( 0.125f, 1.0f ), new Vector2( 0.1875f, 1.0f )}  // Bottom
        };
        
        public Block() { }

        public Block(BlockType b, Vector3 pos, GameObject p, Material c)
        {
            bType = b;
            parent = p;
            position = pos;
            cubeMaterial = c;
            if (bType == BlockType.AIR)
            {
                isSolid = false;
            }
            else
            {
                isSolid = true;
            }
            if (bType == BlockType.WATER)
            {
                parent = owner.fluid.gameObject;
            }
            else
            {
                parent = owner.chunk.gameObject;
            }
            health = BlockHealth.NOCRACK;
            currentHealth = blockHealthMax[(int)bType];
        }
        public void SetType(BlockType b)
        {
            bType = b;
            //if (bType == BlockType.AIR || bType == BlockType.WATER)
            //{
            //    isSolid = false;
            //}
            //else
            //{
            //    isSolid = true;
            //}
            if (bType == BlockType.WATER)
            {
                parent = owner.fluid.gameObject;
            }
            else
            {
                parent = owner.chunk.gameObject;
            }
            health = BlockHealth.NOCRACK;
            currentHealth = blockHealthMax[(int)bType];
        }
        public void Reset()
        {
            health = BlockHealth.NOCRACK;
            currentHealth = blockHealthMax[(int)bType];
            owner.Redraw();
        }
        public bool BuildBlock(BlockType b) // builds a block in the space you are pointing at from the variable set on the player object
        {
            SetType(b);
            if (b == BlockType.WATER)
            {
                owner.mb.StartCoroutine(owner.mb.Flow(this, BlockType.WATER, blockHealthMax[(int)BlockType.WATER], 10));
            }
            else if (b == BlockType.SAND)
            {
                owner.mb.StartCoroutine(owner.mb.Drop(this, BlockType.SAND, 20));
            }
            else
            {
                SetType(b);
                owner.Redraw();
            }
            return true;
        }
        public bool HitBlock() // checking if the block is indistructable and taking away the health of the block until it is destroyed
        {
            if (currentHealth == -1)
            {
                return false;
            }
            currentHealth--;
            health++; // updating
            if (currentHealth == (blockHealthMax[(int)bType] - 1) && World.doesBlocksHeal == true)
            {
                owner.mb.StartCoroutine(owner.mb.HealBlock(position));
            }
            if (currentHealth <= 0)
            {
                bType = BlockType.AIR;
                isSolid = false;
                health = BlockHealth.NOCRACK;
                owner.Redraw();
                owner.UpdateChunk();
                return true;
            }
            owner.Redraw();
            return false;
        }
        void CreateQuad(Cubeside side) // the function to create the cubes
        {
            // creates the mesh component on the object
            Mesh mesh = new Mesh();
            mesh.name = "ScriptedMesh" + side.ToString();
            // initialises all of the quad variables
            Vector3[] vertices = new Vector3[4];
            Vector3[] normals = new Vector3[4];
            Vector2[] uvs = new Vector2[4];
            int[] triangles = new int[6];
            //all possible UVs
            Vector2 uv00;
            Vector2 uv10;
            Vector2 uv01;
            Vector2 uv11;
            // assigning the textures from the atlas
            if (side == Cubeside.TOP)
            {
                uv00 = blockUVs[0, 0];
                uv10 = blockUVs[0, 1];
                uv01 = blockUVs[0, 2];
                uv11 = blockUVs[0, 3];
            }
            else if (side == Cubeside.BOTTOM)
            {
                uv00 = blockUVs[2, 0];
                uv10 = blockUVs[2, 1];
                uv01 = blockUVs[2, 2];
                uv11 = blockUVs[2, 3];
            }
            else
            {
                uv00 = blockUVs[1, 0];
                uv10 = blockUVs[1, 1];
                uv01 = blockUVs[1, 2];
                uv11 = blockUVs[1, 3];
            }

            //all possible vertices 
            Vector3 p0 = new Vector3(-0.5f, -0.5f, 0.5f);
            Vector3 p1 = new Vector3(0.5f, -0.5f, 0.5f);
            Vector3 p2 = new Vector3(0.5f, -0.5f, -0.5f);
            Vector3 p3 = new Vector3(-0.5f, -0.5f, -0.5f);
            Vector3 p4 = new Vector3(-0.5f, 0.5f, 0.5f);
            Vector3 p5 = new Vector3(0.5f, 0.5f, 0.5f);
            Vector3 p6 = new Vector3(0.5f, 0.5f, -0.5f);
            Vector3 p7 = new Vector3(-0.5f, 0.5f, -0.5f);

            switch (side)
            {
                case Cubeside.BOTTOM:
                    vertices = new Vector3[] { p0, p1, p2, p3 };
                    normals = new Vector3[] { Vector3.down, Vector3.down, Vector3.down, Vector3.down };
                    uvs = new Vector2[] { uv11, uv01, uv00, uv10 };
                    triangles = new int[] { 3, 1, 0, 3, 2, 1 };
                    break;
                case Cubeside.TOP:
                    vertices = new Vector3[] { p7, p6, p5, p4 };
                    normals = new Vector3[] { Vector3.up, Vector3.up, Vector3.up, Vector3.up };
                    uvs = new Vector2[] { uv11, uv01, uv00, uv10 };
                    triangles = new int[] { 3, 1, 0, 3, 2, 1 };
                    break;
                case Cubeside.LEFT:
                    vertices = new Vector3[] { p7, p4, p0, p3 };
                    normals = new Vector3[] { Vector3.left, Vector3.left, Vector3.left, Vector3.left };
                    uvs = new Vector2[] { uv11, uv01, uv00, uv10 };
                    triangles = new int[] { 3, 1, 0, 3, 2, 1 };
                    break;
                case Cubeside.RIGHT:
                    vertices = new Vector3[] { p5, p6, p2, p1 };
                    normals = new Vector3[] { Vector3.right, Vector3.right, Vector3.right, Vector3.right };
                    uvs = new Vector2[] { uv11, uv01, uv00, uv10 };
                    triangles = new int[] { 3, 1, 0, 3, 2, 1 };
                    break;
                case Cubeside.FRONT:
                    vertices = new Vector3[] { p4, p5, p1, p0 };
                    normals = new Vector3[] { Vector3.forward, Vector3.forward, Vector3.forward, Vector3.forward };
                    uvs = new Vector2[] { uv11, uv01, uv00, uv10 };
                    triangles = new int[] { 3, 1, 0, 3, 2, 1 };
                    break;
                case Cubeside.BACK:
                    vertices = new Vector3[] { p6, p7, p3, p2 };
                    normals = new Vector3[] { Vector3.back, Vector3.back, Vector3.back, Vector3.back };
                    uvs = new Vector2[] { uv11, uv01, uv00, uv10 };
                    triangles = new int[] { 3, 1, 0, 3, 2, 1 };
                    break;
            }

            mesh.vertices = vertices;
            mesh.normals = normals;
            mesh.uv = uvs;
            mesh.triangles = triangles;

            mesh.RecalculateBounds();

            GameObject quad = new GameObject("Quad");
            quad.transform.position = position;
            quad.transform.parent = parent.transform;

            MeshFilter meshFilter = (MeshFilter)quad.AddComponent(typeof(MeshFilter));
            meshFilter.mesh = mesh;

        }
        int ConvertBlockIndexToLocal(int i) // converts the block index from other chunk into a index for this chunk
        {
            if (i <= -1)
            {
                i = World.chunkSize - 1;
            }
            else if (i >= World.chunkSize)
            {
                i = i - World.chunkSize;
            }
            return i;
        }
        public Block GetBlock(int x, int y, int z) // most of the code from HasSolidNeighbour but HasSolidNeighbour calls this function
        {
            Block[,,] chunks;
            if (x < 0 || x >= World.chunkSize || y < 0 || y >= World.chunkSize || z < 0 || z >= World.chunkSize) // checking for solid neighbour in other chunks
            {
                int newX = x, newY = y, newZ = z;
                if (x < 0 || x >= World.chunkSize)
                {
                    newX = (x - (int)position.x) * World.chunkSize;
                }
                if (y < 0 || y >= World.chunkSize)
                {
                    newY = (y - (int)position.y) * World.chunkSize;
                }
                if (z < 0 || z >= World.chunkSize)
                {
                    newZ = (z - (int)position.z) * World.chunkSize;
                }
                Vector3 neighbourChunkPos = this.parent.transform.position + new Vector3((x - (int)position.x) * World.chunkSize, (y - (int)position.y) * World.chunkSize, (z - (int)position.z) * World.chunkSize);
                string nName = World.BuildChunkName(neighbourChunkPos);
                x = ConvertBlockIndexToLocal(x);
                y = ConvertBlockIndexToLocal(y);
                z = ConvertBlockIndexToLocal(z);
                Chunk nChunk;
                if (World.chunks.TryGetValue(nName, out nChunk))
                {
                    chunks = nChunk.chunkData;
                }
                else
                {
                    return null;
                }
            }
            // checking for solid neighbour in this chunk
            else
            {
                chunks = owner.chunkData;
            }
            return chunks[x, y, z];
        }
        public bool HasSolidNeighbour(int x, int y, int z)
        {
            Block[,,] chunks = parent.GetComponent<Chunk>().chunkData;
            try
            {
                return chunks[x, y, z].isSolid;
            }
            catch (System.IndexOutOfRangeException) { }

            return false;
        }

        public void Draw()
        {
            if (bType == BlockType.AIR) return;

            if (!HasSolidNeighbour((int)position.x, (int)position.y, (int)position.z + 1))
            {
                CreateQuad(Cubeside.FRONT);
            }
            if (!HasSolidNeighbour((int)position.x, (int)position.y, (int)position.z - 1))
            {
                CreateQuad(Cubeside.BACK);
            }
            if (!HasSolidNeighbour((int)position.x, (int)position.y + 1, (int)position.z))
            {
                CreateQuad(Cubeside.TOP);
            }
            if (!HasSolidNeighbour((int)position.x, (int)position.y - 1, (int)position.z))
            {
                CreateQuad(Cubeside.BOTTOM);
            }
            if (!HasSolidNeighbour((int)position.x - 1, (int)position.y, (int)position.z))
            {
                CreateQuad(Cubeside.LEFT);
            }
            if (!HasSolidNeighbour((int)position.x + 1, (int)position.y, (int)position.z))
            {
                CreateQuad(Cubeside.RIGHT);
            }
        }
    }
}
