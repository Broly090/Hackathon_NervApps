using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptResponderComentario : MonoBehaviour
{
    //Cogemos los datos del mensaje al que vamos a responder
    public Text numColegiadoAnterior;
    public Text mensajeAnterior;

    //Parametros a rellenar del panel Responder

    public Text _miNumColegiado;
    public InputField _miRespuesta;

    public GameObject prefabRespuesta;
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

    public void RellenarDatos(string numColegiadoResponder, string comentarioAresponder, string _miNum)
    {
        BorrarTodo();
        mensajeInfo.SetActive(false);
        numColegiadoAnterior.text = "NumColegiado: " + numColegiadoResponder;
        if (comentarioAresponder.Length > 180)
            mensajeAnterior.text = comentarioAresponder.Substring(0, 180) + "...";
        else
            mensajeAnterior.text = comentarioAresponder;
        Debug.Log(_miNum);
        _miNumColegiado.text = _miNum;
    }

    public void EnviarRespuesta()
    {
        //Enviamos la respuesta al servidor
        //Magic para diferenciar una respuesta a un comentario (idea introducir delante del nombre una R)
        if (_miRespuesta.text != "")
        {
            GameObject respuesta = Instantiate(prefabRespuesta) as GameObject;
            respuesta.transform.SetParent(contenedorRespuestasComentario.transform);
            respuesta.GetComponent<RectTransform>().localScale = new Vector3(1f, 1f, 1f);
            //aqui llamare al script para rellenar los datos del prefabRespuesta
            respuesta.GetComponent<ScriptPrefabRepuesta>().RellenarPrefab(numColegiadoAnterior.text, mensajeAnterior.text, _miNumColegiado.text, _miRespuesta.text);
            CerrarVentana();
        }
        else
        {
            mensajeInfo.SetActive(true);
        }
    }

    public void CerrarVentana()
    {
        GameObject.FindWithTag("GameController").GetComponent<AppController>().AbrirPanelResponder(false);
    }

    public void BorrarTodo()
    {
        _miRespuesta.text = "";
    }
}
