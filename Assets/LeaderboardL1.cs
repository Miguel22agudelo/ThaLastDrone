using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class LeaderboardL1 : MonoBehaviour 
{
	public Text[] puntajes;			//Array para la cantidad de puntajes que se mostraran en pantalla (y puedo definir a gusto en el inspector el tamaño del aray)
	int[] scorePuntajes;			//Array de los puntajes que se muestran en cada posición
	string[] nombreJugador;			//Array del nombre del jugador que logró un pantaje

	void Start () 
	{
		scorePuntajes = new int[puntajes.Length];
		nombreJugador = new string[puntajes.Length];

		for (int i = 0; i < puntajes.Length; i++) 
		{
			//Se cargan los nombres de cada jugador y sus puntajes logrados, en la posicion de i para que correspondan los nombres y puntajes respectivamente
			nombreJugador [i] = PlayerPrefs.GetString ("nombreJugador" + i);
			scorePuntajes [i] = PlayerPrefs.GetInt ("scorePuntajes" + i);
		}
		MostrarPuntajes (); //LLama el método MostrarPuntaje
	}

	void SetearPuntajes ()
	{
		//Este método setea o guarda los nombres y puntajes de los jugadores en la posición de i para que correspondan
		for (int i = 0; i < puntajes.Length; i++) 
		{
			PlayerPrefs.SetString ("nombreJugador" + i, nombreJugador[i]);
			PlayerPrefs.SetInt ("scorePuntajes" + i, scorePuntajes[i]);
		}
	}

	public void OrganizarPuntajes (string userName, int value)
	{
		//Este método organizará los puntajes
		for (int i = 0; i < puntajes.Length; i++) 
		{
			if (value > scorePuntajes[i]) //Si el puntaje a ubicar es mayor que alguno de los que ya hay en la tabla
			{
				for (int j = puntajes.Length - 1; j > i; j--)
					/* j = puntajes.Length - 1; como sabemos Length es la longitud completa del array, por lo que Length - 1 sería la penúltima posición
					   la cual es la que nos importa, ya que cuando sobreescribimos un score en la tabla necesitamos desechar la última posición para siempre
					   mostrar un número determinado de posiciones, porque si no desechamos esa última posicion tendríamos un desbordamiento en el tañamo
					   del array. Entonces j se ubica en la penúltima posición para comparar los valores de los score, y si el score de i es mayor, se sobreescribirá
					   en la posicion de j y j pasará al puesto de abajo */
				{
					scorePuntajes[j] = scorePuntajes[j - 1];//El valor que hay en la posición j tomará el valor de la posición anterior a j
					nombreJugador[j] = nombreJugador[j -1 ];/* Hacemos los mismo con el nombre para que coincida el nombre con el score logrado
															   tras mover los puestos en la tabla */
				}
				scorePuntajes[i] = value; //Si el puntaje de value es mayor que el que hay en la posición i del scorePuntajes, esta posición tomará el valor de value
				nombreJugador[i] = userName; //Exactamente lo mismo para el nombre del jugador

				MostrarPuntajes (); //LLama al método para que muestre en tiempo real la ubicación del jugador en la tabla
				SetearPuntajes (); //Guardamos los puntajes ya actualizados
				break;
			}
		}
	}

	void MostrarPuntajes ()
	{
		for (int i = 0; i < scorePuntajes.Length; i++) 
		{
			//Convertimos el score que es de tipo int a string para que se pueda mostrar en la tabla
			puntajes [i].text = nombreJugador [i] + "       " + scorePuntajes [i].ToString ();
		}
	}
}