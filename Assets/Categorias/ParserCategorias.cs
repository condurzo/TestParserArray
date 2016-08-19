using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using LitJson;
using System;

public class ParserCategorias : MonoBehaviour {
	
	public List<string> Urls=new List<string>();
	private List<string> jsontxts=new List<string>();
	private List<JsonData> jsondatas= new List<JsonData>();

	public static ParserCategorias instance;

	void Awake(){
		//cargamos todos los json y los guardamos para no tener que ir cambiando
		StartCoroutine ("GetJsons");
	}


	IEnumerator GetJsons(){
		for(int i=0;i<Urls.Count;i++){
			WWW www = new WWW(Urls[i]);
			yield return www;
			jsontxts.Add(www.text);
			int first = jsontxts[i].IndexOf ('>');
			int last=jsontxts[i].LastIndexOf('<');
			string sub = "";
			if ((first >= 0) && (last >= 0)) {
				sub = jsontxts[i].Substring (first + 1, (last - first) - 1);
			} else {
				sub=jsontxts[i];
			}
			JsonData jsondata = JsonMapper.ToObject (sub);
			jsondatas.Add(jsondata);
		}
	}



//	public string GetCrosswordId(int num){
//		return jsondatas[0] ["result"][num]["id"].ToString();
//	}
//
//	public Categoria GetCrossword(int num){
//		Categoria cat = new Categoria();
//		cat.id = jsondatas[0] ["result"][num]["id"].ToString();
//		cat.name = jsondatas[0] ["result"] [num] ["name"].ToString ();
//
//		List<Subcategoria> subcategoria = new List<Subcategoria> ();
//		for (int j = 0; j < jsondatas[0] ["result"] [num] ["subcategoria"].Count; j++) {
//			Subcategoria subcat = new Subcategoria ();
//			subcat.id=jsondatas[0] ["result"] [num] ["subcategoria"][j]["id"].ToString ();
//			subcat.name=jsondatas[0] ["result"] [num] ["subcategoria"][j]["name"].ToString ();
//			subcategoria.Add(subcat);
//			Debug.Log ("ENTRE");
//		}
//		cat.subcategoria = subcategoria.ToArray ();
//		return cat;
//	}



	public List<Categoria> GetAllCategorias(){
		List<Categoria> categoria =new List<Categoria>();
		for (int i = 0; i < jsondatas[0] ["result"].Count; i++) {
			Categoria cat = new Categoria ();
			cat.id = jsondatas[0] ["result"] [i] ["id"].ToString ();
			cat.name = jsondatas[0] ["result"] [i] ["name"].ToString ();

			List<Subcategoria> subcategoria = new List<Subcategoria> ();
			for (int j = 0; j < jsondatas[0] ["result"] [i] ["subcategories"].Count; j++) {
				Subcategoria subcat = new Subcategoria ();
				subcat.id=jsondatas[0] ["result"] [i] ["subcategories"][j]["id"].ToString ();
				subcat.name=jsondatas[0] ["result"] [i] ["subcategories"][j]["name"].ToString ();
				subcategoria.Add(subcat);
				Debug.Log (subcat.name);
			}
			cat.subcategoria = subcategoria.ToArray();
			categoria.Add (cat);
		}
		//categoria.Sort ((IComparer<Categoria>)new CrosswordSort ());

		return categoria;
	}
}




