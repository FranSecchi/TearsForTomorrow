using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class ShaderModifier : MonoBehaviour
{
    public static List<Material> materials = new List<Material>();
    // Start is called before the first frame update
    public static Shader past_shader;
    public static Shader present_shader;
    public static Shader future_shader;
    void Start()
    {
        past_shader = Shader.Find("Template/Past_Shader");
        present_shader = Shader.Find("Template/Present_Shader");
        future_shader = Shader.Find("Template/Futur_Shader");
        FindAllObjects();
        changeShader(Times.Present);
    }
    void FindAllObjects(){
        List<GameObject>Objects = FindObjectsOfType<GameObject>().ToList();
        foreach(GameObject obj in Objects){
            if(!obj.CompareTag("Ascensor")){
                Material mat;
                MeshRenderer mesh;
                if(obj.TryGetComponent(out mesh)){
                    mat = mesh.material;
                    if(!materials.Contains(mat))
                        materials.Add(mat);
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static void changeShader(Times time){
        Debug.Log(time.ToString());
        foreach(Material mat in materials){
            switch(time){
                case Times.Past:
                    mat.shader = past_shader;
                    break;
                case Times.Present:
                    mat.shader = present_shader;
                    break;
                case Times.Future:
                    mat.shader = future_shader;
                    break;
            }
        }
    }
}
