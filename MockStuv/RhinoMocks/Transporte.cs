using System;

namespace RhinoMocks
{
    public class Transporte : ITransporte
    {
        public Transporte()
        {
        }

        public int Capacidad { get; internal set; }
        public int CargaActual { get; private set; }

        public double PorcentajeCarga()
        {
            return  CargaActual/ Convert.ToDouble(Capacidad);
        }

        internal void Cargar(int peso)
        {
             CargaActual += peso;
        }

        double ITransporte.Cargar(int peso)
        {
            throw new NotImplementedException();
        }
    }
}