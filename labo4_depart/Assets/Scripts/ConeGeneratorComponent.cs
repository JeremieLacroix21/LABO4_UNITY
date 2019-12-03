using UnityEngine;

public class ConeGeneratorComponent : MonoBehaviour
{

    public Vector2 coneDimension; // x = rayon de la base du cône, y = hauteur du cône
    public int nFaces; // le nombre de facettes du cône

    Mesh mesh;  // Le maillage qui sera généré par notre script

    Vector3[] vertices;  // Contiendra l'ensemble des sommets utilisés lors de la création des triangles composant la primitive.
                         // Un même sommet peut être utilisé dans la définition de plusieurs triangles.

    Vector3 origin;// L'origine du vecteur est fixée de manière à ce que le centre de rotation du triangle 
                   // soit centré au point (0, 0, 0) de l'espace virtuel

    void Awake()
    {
        origin = new Vector3(0, coneDimension.y / 2, 0);
        GénérerMaillage();
        GénérerEnveloppeCollision();
    }

    private void GénérerMaillage()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.name = "Cone";
        vertices = GénérerSommets();
        mesh.vertices = vertices;
        mesh.triangles = GénérerListeTriangle();
        mesh.uv = GénérerCoordonnéesTexture();
        mesh.RecalculateNormals();
        CalculerTangentes();
        mesh.tangents = CalculerTangentes();
    }

    private void GénérerEnveloppeCollision()
    {
        MeshCollider enveloppe = GetComponent<MeshCollider>();
        enveloppe.sharedMesh = mesh;
    }

    private Vector3[] GénérerSommets()
    {
        // Génère les différents sommets de la primitive utilisés tant pour la structure que pour l'application du matériau.

        // à completer
    }


    private int[] GénérerListeTriangle()
    {
        // Génère un tableau contenant la définition de chacun des triangles composant la primitive. 
        // Chaque triangle est défini par trois valeurs,chacune de ces valeurs étant un indice du tableau Sommets.

        // à completer
    }

    private Vector2[] GénérerCoordonnéesTexture()
    {
        // Génère un tableau contenant les coordonnées permettant l'application de la texture sur la primitive.
        Vector2[] coordonnéesTexture = new Vector2[vertices.Length];
        float variationTexture = 1f / (2 * nFaces);
        coordonnéesTexture[0] = new Vector2(0.49f, 0.49f);
        float posX = 0;
        for (int i = 1; i <= nFaces; ++i)
        {
            coordonnéesTexture[i] = new Vector2(posX, 0);
            posX = posX + variationTexture < 0.49f ? posX + variationTexture : 0.49f;
        }
        coordonnéesTexture[nFaces + 1] = coordonnéesTexture[1];
        posX = 0.5f + variationTexture;
        coordonnéesTexture[nFaces + 2] = new Vector2(posX, 0);
        for (int i = nFaces + 3; i <= 2 * nFaces + 3; ++i)
        {
            coordonnéesTexture[i] = new Vector2(posX, 0);
            posX = posX + variationTexture < 1 ? posX + variationTexture : 1f;
        }
        return coordonnéesTexture;
    }

    private Vector4[] CalculerTangentes()
    {
        // Génère un tableau contenant les tangentes à chacun des sommets, ce qui permet l'utilisation de la texture en relief (bump map) sur la primitive.
        Vector4[] tangentes = new Vector4[vertices.Length];
        Vector4 tangenteDeBase = new Vector4(1f, 0f, 0f, -1f);
        for (int i = 0; i < tangentes.Length; ++i)
        {
            tangentes[i] = tangenteDeBase;
        }
        return tangentes;
    }
}
