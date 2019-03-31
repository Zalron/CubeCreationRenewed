using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{

	public Material cubeMaterial;
	public Block[,,] chunkData;

	IEnumerator BuildChunk(int sizeX, int sizeY, int sizeZ)
	{
		chunkData = new Block[sizeX,sizeY,sizeZ];

        //create blocks
        for (int z = 0; z < sizeZ; z++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                for (int x = 0; x < sizeX; x++)
                {
                    Vector3 pos = new Vector3(x, y, z);
                    if (Random.Range(0, 100) < 50)
                        chunkData[x, y, z] = new GrassBlock(pos,this.gameObject, cubeMaterial);
                    else
                        chunkData[x, y, z] = new DirtBlock(pos, this.gameObject, cubeMaterial);
                }
            }
        }
		yield return null;
	}
    void DrawChunk()
    {
        if (!treesCreated)
        {
            for (int z = 0; z < World.chunkSize; z++)
            {
                for (int y = 0; y < World.chunkSize; y++)
                {
                    for (int x = 0; x < World.chunkSize; x++)
                    {
                        //BuildTrees(dirtBlockChunkData[x, y, z],x,y,z);
                    }
                }
            }
            treesCreated = true;
        }
        //Drawing soild and water blocks 
        for (int z = 0; z < World.chunkSize; z++)
        {
            for (int y = 0; y < World.chunkSize; y++)
            {
                for (int x = 0; x < World.chunkSize; x++)
                {
                    //dirtBlockChunkData[x, y, z].Draw();
                }
            }
        }
        CombineQuads(chunk.gameObject, cubeMaterial);
        // creating and adding a meshcollider component to the individual chunks
        MeshCollider collider = chunk.gameObject.AddComponent(typeof(MeshCollider)) as MeshCollider;
        collider.sharedMesh = chunk.transform.GetComponent<MeshFilter>().mesh;
        // creating water material but not adding in the collider 
        CombineQuads(fluid.gameObject, fluidMaterial);
    }

	// Use this for initialization
	void Start ()
    {
		StartCoroutine(BuildChunk(16,16,16));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CombineQuads()
	{
		//Combine all children meshes
		MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];
        int i = 0;
        while (i < meshFilters.Length)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            i++;
        }

        //Create a new mesh on the parent object
        MeshFilter mf = (MeshFilter) this.gameObject.AddComponent(typeof(MeshFilter));
        mf.mesh = new Mesh();

        //Add combined meshes on children as the parent's mesh
        mf.mesh.CombineMeshes(combine);

        //Create a renderer for the parent
		MeshRenderer renderer = this.gameObject.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
		renderer.material = cubeMaterial;

		//Delete all uncombined children
		foreach (Transform quad in this.transform)
        {
     		Destroy(quad.gameObject);
 		}

	}

}
