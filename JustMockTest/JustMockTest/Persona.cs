using System;
using System.Collections.Generic;

namespace JustMockTest
{
    internal class Persona
    {
        List<string> entradas = new List<string>();
        //public int Entradas { get; set; }
        public bool ObtuvoEntradas { get; internal set; }

        internal void CompraEntradas(Cine cine, int cantidadEntradas, string pelicula)
        {
            var butacasLibres = cine.ButacasLibres(pelicula);
            if (butacasLibres = cantidadEntradas)
            {
                entradas = cine.Descargar(pelicula, cantidadEntradas); 
            }
            else
            {
                entradas = cine.Descargar(pelicula, ;
            }
        }
    }
}