using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using System.Globalization;
using LitJson;
using System;

public class LoadJsonCategorias : MonoBehaviour {



	IEnumerator Start(){
		//Load JSON data from a URL
		string url = "http://158.69.197.37:8080/api/appliances/categories";
		WWW www = new WWW(url);

		//Load the data and yield (wait) till it's ready before we continue executing the rest of this method.
		yield return www;
		if (www.error == null){
			//Sucessfully loaded the JSON string
			Debug.Log("Categorias" + www.data);

			//Process books found in JSON file
			ProcessCategorias(www.data);
		}else{
			Debug.Log("ERROR: " + www.error);
		}

	}

	private void ProcessCategorias(string jsonString){
		
		JsonData jsonOfertas = JsonMapper.ToObject (jsonString);
		Categoria categoria;

		for (int i = 0; i < jsonOfertas ["result"].Count; i++) {	
			categoria = new Categoria();
		//	categoria.id = Convert.ToInt16(jsonOfertas["result"][i]["id"].ToString());
			categoria.name = jsonOfertas["result"][i]["name"].ToString();
			for (int ii = 0; ii < jsonOfertas ["result"].Count; ii++) {
				Subcategoria subcat = new Subcategoria ();
				//subcat.id = Convert.ToInt16(jsonOfertas["result"][ii]["id"].ToString());
				subcat.name = jsonOfertas["result"][ii]["name"].ToString();
				for (int iii = 0; iii < jsonOfertas ["result"].Count; iii++) {
					Appliance appliance = new Appliance ();
					appliance.id = Convert.ToInt16(jsonOfertas["result"][iii]["id"].ToString());
					appliance.name = jsonOfertas["result"][iii]["name"].ToString();
					Debug.Log (subcat.name);
				}
			}
		}
	}
		

}
