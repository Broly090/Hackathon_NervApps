using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptComentario : MonoBehaviour
{
    public Text _numColegiado;
    public Text _comentario;
    string _numero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RellenarDatosComentario(string num, string comentario)
    {
        _numColegiado.text = num;
        _comentario.text = comentario;
    }

    public void AbrirPanelResponder()
    {
        _numero = GameObject.FindWithTag("GameController").GetComponent<AppController>().MiNumeroColegiado();
        bool abrir = true;
        GameObject.FindWithTag("GameController").GetComponent<AppController>().AbrirPanelResponder(abrir);
        GameObject.FindWithTag("responderComentario").GetComponent<ScriptResponderComentario>().RellenarDatos(_numColegiado.text, _comentario.text, _numero);
    }
}
