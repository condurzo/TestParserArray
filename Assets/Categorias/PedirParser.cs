using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class PedirParser : MonoBehaviour {

	public List<Categoria> ListaCategoria = new List<Categoria> ();
	public Text nombre;

	void Start () {
		Invoke ("Nombres", 3);

	}


	void Nombres(){
		ListaCategoria = ParserCategorias.instance.GetAllCategorias ();
		for (int i = 0; i < ListaCategoria.Count; i++) {
			nombre.text = ListaCategoria [i].name;
		}
	}
}
