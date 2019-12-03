using UnityEngine;

public class PlaneGeneratorComponent : MonoBehaviour
{
    public const int NbTrianglesParTuile = 2;
    public const int NbSommetsParTriangle = 3;

    public Vector2 extent;    // Étendue de la surface dans l'espace. Bref, sa largeur (x) et sa hauteur (y).

    public Vector2 frame; // Structure de la surface. Bref, le nombre de colonnes (x) et le nombre de lignes (y).

    public bool repeatTexture;

    Mesh mesh;
    Vector3 origin;      // L'origine du vecteur est fixée de manière à ce que le centre de la surface 
                         // (croisement des axes de rotation) soit situé au point (0, 0, 0) de l'espace virtuel.
    Vector3[] vertices;     // Contiendra les différents sommets (vertices) de la surface

    Vector2 DeltaTexture { get; set; }  // Variations horizontale et verticale dans les coordonnées de texture

    void Awake()
    {
        CalculerDonnéesInitiales();
        GénérerMaillage();
        GénérerEnveloppeCollision();
    }

    private void CalculerDonnéesInitiales()
    {
        origin = new Vector3(-extent.x / 2, -extent.y / 2, 0);
    }

    private void GénérerEnveloppeCollision()
    {
        MeshCollider enveloppe = GetComponent<MeshCollider>();
        enveloppe.sharedMesh = mesh;
    }

    private void GénérerMaillage()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.name = "Surface";
        vertices = GénérerSommets();
        mesh.vertices = vertices;
        mesh.triangles = GénérerListeTriangles();
        mesh.uv = GénérerCoordonnéesTexture();
        mesh.RecalculateNormals();
        mesh.tangents = CalculerTangentes(); ;
    }

    private Vector3[] GénérerSommets()
    {
        // Génère les différents sommets de la primitive utilisés tant pour la structure que pour l'application du matériau.

        // à compléter
    }

    protected int[] GénérerListeTriangles()
    {
        // Génère un tableau contenant la définition de chacun des triangles composant la primitive. 
        // Chaque triangle est défini par trois valeurs,chacune de ces valeurs étant un indice du tableau Sommets.

        // à compléter
    }

    protected Vector2[] GénérerCoordonnéesTexture()
    {
        // Génère un tableau contenant les coordonnées permettant l'application de la texture sur la primitive.

        // à compléter
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
