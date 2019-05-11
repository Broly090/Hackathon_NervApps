using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptNewComentario : MonoBehaviour
{
    public Text _miNum;
    public InputField textComentario;

    public GameObject prefabComentario;
    public Transform contenedorRespuestasComentario;
    public GameObject mensajeInfo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void EnviamosComentarioHilo()
    {
        /*
         * Aqui llamaremos al script backend, para enviar el mensaje y añadirlo al hilo
         * 
         * */
         if(textComentario.text != "") { 
            GameObject respuesta = Instantiate(prefabComentario) as GameObject;
            respuesta.transform.SetParent(contenedorRespuestasComentario.transform);
            respuesta.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            //aqui llamare al script para rellenar los datos del prefabRespuesta
            respuesta.GetComponent<ScriptComentario>().RellenarDatosComentario(_miNum.text, textComentario.text);
            CerrarVentana();
        }
        else
        {
            mensajeInfo.SetActive(true);
        }


    }

    public void MisDatos(string num)
    {
        _miNum.text = num;
        BorrarTodoComentario();
        mensajeInfo.SetActive(false);

    }

    public void CerrarVentana()
    {
        GameObject.FindWithTag("GameController").GetComponent<AppController>().AbrirPanelComentar(false);
    }

    public void BorrarTodoComentario()
    {
        textComentario.text = "";
    }




}
