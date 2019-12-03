using UnityEngine;

public class CubeGeneratorComponent : MonoBehaviour
{
    public Vector3 cubeDimension;

    Mesh mesh; // Le maillage qui sera généré par notre script

    Vector3[] vertices; // Contiendra l'ensemble des sommets utilisés lors de la création des triangles composant la primitive.
                        // Un même sommet peut être utilisé dans la définition de plusieurs triangles.

    Vector3 origin; // L'origine du vecteur est fixée de manière à ce que le centre de rotation du triangle 
                    // soit centré au point (0, 0, 0) de l'espace virtuel
    void Awake()
    {
        origin = new Vector3(-cubeDimension.x / 2, -cubeDimension.y / 2, -cubeDimension.z / 2);
        GénérerMaillage();
        GénérerEnveloppeCollision();
    }

    private void GénérerMaillage()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.name = "Cube 24 sommets";
        vertices = GénérerSommets();
        mesh.vertices = vertices;
        mesh.triangles = GénérerListeTriangle(); ;
        mesh.uv = GénérerCoordonnéesTexture();
        mesh.RecalculateNormals();
        mesh.tangents = CalculerTangentes();
    }

    private void GénérerEnveloppeCollision()
    {
        BoxCollider enveloppe = GetComponent<BoxCollider>();
        enveloppe.size = cubeDimension;
    }

    private Vector3[] GénérerSommets()
    {
        // On défini chacun des sommets qui sera utilisé pour définir les triangles (polygones) de la primitive.
        // On défini les 8 points de base et on crée le tableau de sommets en les combinant

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

        // à completer
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
