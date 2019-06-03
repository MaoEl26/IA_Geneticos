using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GE_Employees
{

    public class AlgoritmoGenetico
    {
        private List<Tipo> tipos = new List<Tipo>();
        public int tipo;
        public int cruces;
        public int tamannoPoblacion;
        public float probabilidadMutacion;
        public float probabilidadCruzada;
        public float finalFitness = -1;

        private System.Random rand = new System.Random();

        private List<float> fitnessXGen;
        public List<Dictionary<int, int>> poblacion = new List<Dictionary<int, int>>();

        public Dictionary<string, List<int>> colaboradoresXServicio = new Dictionary<string, List<int>>();
        public Dictionary<int, OrdenTrabajo> ordenes = new Dictionary<int, OrdenTrabajo>();
        public Dictionary<int, Colaborador> colaboradores = new Dictionary<int, Colaborador>();
        public Dictionary<string, Servicio> servicios = new Dictionary<string, Servicio>();

        public AlgoritmoGenetico(int tipo, int cruces, int tamannoPoblacion, float probabilidadMutacion, 
            float probabilidadCruzada, Dictionary<int, OrdenTrabajo> ordenes, 
            Dictionary<int, Colaborador> colaboradores, 
            Dictionary<string, Servicio> servicios)
        {
            this.tipo = tipo;
            this.cruces = cruces;
            this.probabilidadMutacion = probabilidadMutacion;
            this.probabilidadCruzada = probabilidadCruzada;
            this.ordenes = ordenes;
            this.colaboradores = colaboradores;
            this.servicios = servicios;

            this.tamannoPoblacion = ((tamannoPoblacion & 1) == 1 ? tamannoPoblacion : tamannoPoblacion + 1);

            fitnessXGen = new List<float>();
            for(int i = 0; i < tamannoPoblacion  ; i++)
            {
                fitnessXGen.Add(-1F);
            }
            //Console.Out.WriteLine(fitnessXGen.Count());
            tipos.Add(new Aleatorio("Aleatorio"));
            tipos.Add(new Torneo("Torneo"));
            tipos.Add(new Fortuna("Fortuna"));

            ColaboradoresPorServicio();
            GenerarPoblacionAleatoria();
        }

        private void ColaboradoresPorServicio()
        {
            foreach(KeyValuePair<string,Servicio> servicio in servicios)
            {
                List<int> lista = new List<int>();
                colaboradoresXServicio.Add(servicio.Key, lista);
            }
            foreach(KeyValuePair<int,Colaborador> colaborador in colaboradores)
            {
                foreach(string codigoServicio in colaborador.Value.codigosServicio)
                {
                    colaboradoresXServicio[codigoServicio].Add(colaborador.Key);
                }
            }
        }

        private void GenerarPoblacionAleatoria()
        {
            for (int i = 0; i < tamannoPoblacion; ++i)
            {
                Dictionary<int, int> cromosoma = new Dictionary<int, int>();

                foreach (KeyValuePair<int, OrdenTrabajo> orden in ordenes)
                {
                    cromosoma.Add(orden.Key, AgenteAleatorio(orden.Value.codigoServicio));
                }

                poblacion.Add(cromosoma);
            }
        }

        private int AgenteAleatorio(string codigoServicio)
        {
            return colaboradoresXServicio[codigoServicio][rand.Next(0, colaboradoresXServicio[codigoServicio].Count - 1)];
        }

        private float Fitness(int index)
        {
            // Agent ID : (Commission, Hours)
            Dictionary<int, Pareja<int, int>> tarifaXColaborador = ColaboradorComisionHoras(index);

            int sobretiempo = 0;
            int proporcion = 1000;

            float esperanzaComision = 0.0f;
            foreach (KeyValuePair<int, Pareja<int, int>> colaborador in tarifaXColaborador)
            {
                esperanzaComision += colaborador.Value.valor1;

                // Sum total overtime
                if (colaborador.Value.valor2 > 40) sobretiempo += (colaborador.Value.valor2 - 40);
            }
            esperanzaComision /= colaboradores.Count();

            float varianzaComision = 0.0f;
            foreach (KeyValuePair<int, Pareja<int, int>> colaborador in tarifaXColaborador)
            {
                varianzaComision += ((colaborador.Value.valor1 - esperanzaComision) * 
                    (colaborador.Value.valor1 - esperanzaComision));
            }
            varianzaComision /= colaboradores.Count();

            return varianzaComision + (sobretiempo * proporcion);
            
        }

        private Dictionary<int, int> Mutation(Dictionary<int, int> hijo)
        {
            Dictionary<int, int> temp = new Dictionary<int, int>();
            foreach (KeyValuePair<int, int> gen in hijo)
            {
                if (rand.Next(0, 1000) < (probabilidadMutacion * 1000))
                {
                    string codigoServicio = ordenes[gen.Value].codigoServicio;
                    if (temp.Keys.Contains(hijo[gen.Key]))
                    {
                        temp.Remove(hijo[gen.Key]);                        
                    }
                    temp.Add(hijo[gen.Key], colaboradoresXServicio[codigoServicio][rand.Next(0, colaboradoresXServicio[codigoServicio].Count())]);
                }
            }
            foreach(KeyValuePair<int,int> tempItem in temp)
            {
                hijo.Remove(tempItem.Key);
                hijo.Add(tempItem.Key, tempItem.Value);
            }
            return hijo;
        }

        public void NuevaGeneracion()
        {
            int indiceMejorFit = -1;

            for (int i = 0; i < tamannoPoblacion - 1; ++i)
            {
                fitnessXGen[i] = Fitness(i);

                if (indiceMejorFit != -1)
                {
                    if (fitnessXGen[i] < fitnessXGen[indiceMejorFit]) indiceMejorFit = i;
                }
                else indiceMejorFit = i;
            }

            List<Dictionary<int, int>> hijos = new List<Dictionary<int, int>>();

            for (int i = 0; i < (tamannoPoblacion - 1); i += 2)
            {
                Tuple<int, int> padres = tipos[tipo].Seleccion(fitnessXGen);

                Tuple<Dictionary<int, int>, Dictionary<int, int>> hijo = Crossover(padres.Item1, padres.Item2);

                hijos.Add(Mutation(hijo.Item1));
                hijos.Add(Mutation(hijo.Item2));
            }
            hijos.Add(poblacion[indiceMejorFit]);
            poblacion = hijos;
            finalFitness = fitnessXGen[indiceMejorFit];
        }

        private Dictionary<int, Pareja<int, int>> ColaboradorComisionHoras(int indice)
        {
            // Agent ID : (Commission, Hours)
            Dictionary<int, Pareja<int, int>> comisionColaborador = new Dictionary<int, Pareja<int, int>>();

            // Order ID : Agent ID
            foreach (KeyValuePair<int, int> entrada in poblacion[indice])
            {
                if (comisionColaborador.ContainsKey(entrada.Value))
                {
                    comisionColaborador[entrada.Value].valor1 += servicios[ordenes[entrada.Key].codigoServicio].comision;
                    comisionColaborador[entrada.Value].valor2 += servicios[ordenes[entrada.Key].codigoServicio].duracion;
                }
                else
                {
                    comisionColaborador[entrada.Value] = new Pareja<int, int>(servicios[ordenes[entrada.Key].codigoServicio].comision,
                                                                 servicios[ordenes[entrada.Key].codigoServicio].duracion);
                }
            }
            return comisionColaborador;
        }

        private Tuple<Dictionary<int, int>, Dictionary<int, int>> Crossover(int padreA, int padreB)
        {
            Dictionary<int, int> hijoA = new Dictionary<int, int>();
            Dictionary<int, int> hijoB = new Dictionary<int, int>();

            if (rand.Next(0, 100) > (probabilidadCruzada * 100))
            {
                hijoA = poblacion[padreA];
                hijoB = poblacion[padreB];
            }
            else
            {
                int intervalo = ordenes.Count() / (cruces + 1);
                int contador = 0, intercambios = 0;
                foreach (KeyValuePair<int, int> gen in poblacion[padreA])
                {
                    hijoA[gen.Key] = ((intercambios & 1) == 0 ? gen.Value : poblacion[padreB][gen.Key]);
                    hijoB[gen.Key] = ((intercambios & 1) == 1 ? gen.Value : poblacion[padreB][gen.Key]);

                    contador++;
                    if (contador >= intervalo)
                    {
                        intercambios ^= 1;
                        contador = 0;
                    }
                }
            }
            return Tuple.Create<Dictionary<int, int>, Dictionary<int, int>>(hijoA, hijoB);
        }
    }
}
