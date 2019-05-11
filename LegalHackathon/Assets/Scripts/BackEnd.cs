using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Text;

public class BackEnd : MonoBehaviour
{

    private string _tema, _hilo, url, conversacion;
    private int _numConvers;
    private TextAsset conversacionText;

    // Start is called before the first frame update
    void Start()
    {
        RecogerHilo("Penal", "Art.245.2CP", 1);


    }

    // Update is called once per frame
    void Update()
    {
        
    }



    /*
     * 
     * Función encargada de completar la URL y lanzar Corrutina
     * 
     * 
     * */
    public void RecogerHilo (string tema, string hilo, int numConvers)
    {
        // Asigno variables
        _tema = tema;
        _hilo = hilo;
        _numConvers = numConvers;

        //url = "http://46.183.118.202:6969/Legalhackathon/" + tema + "/" + hilo + ".txt";
        url = "http://nerv.legalhackathon.es/" + _tema + "/" + _hilo + "/" +_numConvers+".txt";

        

        StartCoroutine(CorrutinaRecogerHilo());

    }


    /*
     * 
     * Función encargada de recoger hilos (conversaciones) desde servidor
     * 
     * 
     * */
    IEnumerator CorrutinaRecogerHilo ()
    {
        using (var www = new WWW(url))
        {
            yield return www;

            conversacion = System.Text.Encoding.UTF7.GetString(www.bytes);

        }

        Debug.Log(conversacion);

        EnviarHilo(_tema, _hilo, _numConvers);
    }


    /*
  * 
  * Función encargada de completar la URL y lanzar Corrutina
  * 
  * 
  * */
    public void EnviarHilo(string tema, string hilo, int numConvers)
    {
        _numConvers = numConvers;

        //url = "http://46.183.118.202:6969/Legalhackathon/" + tema + "/" + hilo + ".txt";
        //url = "http://46.183.118.202:6969/Legalhackathon/" + tema + "/write.php";


        // ESTE VA
        //url = "http://nerv.legalhackathon.es/"+_tema+"/"+_hilo+"/write.php";
        url = "http://nerv.legalhackathon.es/write.php";

        conversacion += "\n Éscúpeme en la boocaaaáaaa";
        Debug.Log(url);
        StartCoroutine(CorrutinaEnviarHilo());

    }



    /*
     * 
     * Función encargada de enviar hilos (conversaciones) al servidor
     * 
     * 
     * */
    IEnumerator CorrutinaEnviarHilo()
    {
        Debug.Log(conversacion);
        /*
        WWWForm form = new WWWForm();



        form.AddField("fileContent", conversacion);
        form.AddField("fileName", hilo + ".txt");
        */

        Debug.Log(_hilo);

        // ESTE VA
        //WWW www = new WWW(url+"?txt="+ conversacion+"&file="+_numConvers+".txt");

        WWW www = new WWW(url + "?txt=" + conversacion + "&file=" + _numConvers + ".txt&tema=" +_tema+ "&hilo="+_hilo);

        yield return www;


        /*
        //UnityWebRequest www = new UnityWebRequest(url, conversacion);
        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            www.uploadHandler = new UploadHandlerRaw(System.Text.Encoding.UTF8.GetBytes(conversacion));
            yield return www.SendWebRequest();

            if (www.isNetworkError)
            {
                Debug.Log("Error" + www.error);
            }
            else if (www.isDone)
            {
                Debug.Log("Bien" + www.error);
            }

        }*/

        /*
        using (var www = new UnityEngine.Networking.UnityWebRequest(url, conversacion))
        {
            yield return www;

            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.Log("Error" + www.error);
            }
            else
            {
                Debug.Log(www);
            }
        }*/




    }




}
