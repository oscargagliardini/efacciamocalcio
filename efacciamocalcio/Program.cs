namespace calcio
{
    internal class Program
    {

        static double assegnazione(double[]sq1, double[] sq2)
        {
            double p1 = 0;
            double p2 = 0;
            double p3 = 0;
            double percentuale1 = 0;
            double percentuale2 = 0;
            for(int i = 0; i < 11; i++)
            {
                p1=p1+ sq1[i];
                p2=p1+ sq2[i];
            }
            p3 = p1 + p2;

            percentuale1 = p1 / p3;
            percentuale1 = percentuale1 * 100;
            return percentuale1;
          
        }

          
      
        static void Main(string[] args)
        {
            double[] sq1 = new double[11];
            Random rand = new Random();

            for (int i=0;i<11;i++){
                
                sq1[i]= rand.Next(30,100);
            }

            double[] sq2 = new double[11];
            for (int i=0;i<11;i++){
                sq2[i]= rand.Next(30,100);
            }

            int squadra1goal=0;
            int squadra2goal=0;

            Console.WriteLine("Hello, World!");
            for(int i = 1; i <= 90; i++)
            {
                int evento = rand.Next(1, 101);
                if(evento <= 2)
                {
                    Console.WriteLine($"Goal al minuto {i}");
                    double p1 = assegnazione(sq1, sq2 );
                    int pgoal = rand.Next(1, 101);
                    if(pgoal <= p1)
                    {
                        squadra1goal++;
                        Console.WriteLine("ha segnato la squadra 1");
                    }
                    else
                    {
                        squadra2goal++;
                        Console.WriteLine("ha segnato la squadra 2");
                    }
                }

            }
        }
    }
}
