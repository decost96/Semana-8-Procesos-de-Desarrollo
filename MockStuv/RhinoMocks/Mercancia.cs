using System;

namespace RhinoMocks
{
    internal class Mercancia
    {
        public Mercancia()
        {
        }

        public int Peso { get; internal set; }
        public bool SeEnvio { get; internal set; }
        public bool NoEnvio { get; internal set; }

        internal void Enviar(ITransporte transporte)
        {
            if (transporte.PorcentajeCarga() >= 0.5)
            {
                transporte.Cargar(Peso);
                this.SeEnvio = true;
            }
            else
            {
                this.NoEnvio = true;
            }
        }
    }
}