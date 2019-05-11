using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class CollectionPrefs
{

    /*
     * ICollection <int> numFrasesBiblioteca;
	List <int> numFrases = new List <int> ();

    */
    // LLAMADA PARA RECOGER LOS HILOS QUE ESTAMOS SIGUIENDO (REFRESCAR)
    //Siguiendo = CollectionPrefs.GetInts("Siguiendo");


    // LLAMADA PARA AÑADIR UN HILO A SEGUIR
    // CollectionPrefs.SetInts ("Siguiendo", numFrases);


    public static void Delete (string key)
    {
        // Borramos la colección antigua en PlayerPrefs
        int count = PlayerPrefs.GetInt(key + ".Count", 0);

        for (int i = 0; i < count; i++)
        {
            PlayerPrefs.DeleteKey(key + "[" + i + "]");
        }

    }



    public static void SetInt (int key, ICollection <int> collection)
    {
        collection.Add(key);
    }


    public static void SetInts (string key, ICollection <int> collection)
    {
        Delete(key);

        // Creamos una nueva colección en PlayerPrefs
        PlayerPrefs.SetInt(key + ".Count", collection.Count);

        for (int i = 0; i < collection.Count; i++)
        {
            PlayerPrefs.SetInt(key + "[" + i + "]", collection.ElementAt(i));
        }
    }


    public static ICollection <int> GetInts (string key)
    {
        int count = PlayerPrefs.GetInt(key + ".Count", 0);
        int[] array = new int[count];

        for (int i = 0; i < count; i++)
        {
            array[i] = PlayerPrefs.GetInt(key + "[" + i + "]");
        }

        return array;

    }

}
