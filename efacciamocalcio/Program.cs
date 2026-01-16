using System.Data;
using System.Runtime.Remoting;
using Microsoft.VisualBasic;

namespace calcio
{
    internal class Program
    {
        //funzione assegnazione goal

        static double assegnazione(double[]sq1, double[] sq2)
        {
            double fa1 = 0; //variabile forza attacco squadra 1
            double fa2 = 0; //variabile forza attacco squadra 2
            double p1 = 0;// variabile potenza totale squadra 1
            double p2 = 0; // variabile potenza totale squadra 2
            double p3 = 0; // variabile potenza totale delle due squadre
            double percentuale1 = 0;
            double percentuale2 = 0;
            for(int i = 0; i < 11; i++) //for scorrimento squadre
            {
                if(sq1[i]>7)
                {
                    fa1=fa1+sq1[i]; //calcolo forza attacco squadra 1
                }
                if(sq2[i]>7)
                {
                    fa2=fa2+sq2[i]; //calcolo forza attacco squadra 2
                }
                
                p1=p1+ sq1[i]; //calcolo potenza totale squadra 1

                p2=p1+ sq2[i]; //calcolo potenza totale squadra 2
            }

            p3 = p1 + p2; //calcolo potenza totale delle due squadre

            percentuale1 = p1 / p3;
            percentuale1 = percentuale1 * 100;
            if(fa1>fa2)
            {
                percentuale1 = percentuale1 + 10;
            }
            else if(fa2>fa1)
            {
                percentuale1 = percentuale1 - 10;
            }
            return percentuale1;
          
        }
        //funzioni cartellini
        static void gialli(double[] sq1, double[] sq2,double[]Contagialli1,double[]Contagialli2)
        {
            double g1 = 0; //variabile  scelta gialli squadra 1
            double g2 = 0; //variabile  scelta gialli squadra 2
            Random random = new Random();
            double giallo = random.Next(1, 101);// decisione di quale squadra prende il giallo
            if (giallo > 0 && giallo < 50)// giallo squadra 1
            {
                g1++;
            }
            else // giallo squadra 2
            {
                g2++;
            }
            int verG = random.Next(0, 11);
            if (g1 > 0)
            {
                if(sq1[verG]<=0)//controllo se il giocatore ha gia preso rosso
                {
                    Console.WriteLine("non puoi dare il giallo a questo giocatore perche ha gia preso rosso ");
                    return;
                }
                if(Contagialli1[verG]==1) //estenzione doppio giallo 
                {
                    sq1[verG]=0;
                    Console.WriteLine($"giocatore numero {verG} della squad 1 ha preso il secondo giallo ed è stato espulso");
                    return;
                }
                sq1[verG] = sq1[verG]-10;
                Console.WriteLine($"giocatore numero {verG} della squad 1 ha preso giallo");//giallo squadra 1

            }
            else 
            {
                if(sq2[verG]<=0)//controllo se il giocatore ha gia preso rosso
                
                {
                    Console.WriteLine("non puoi dare il giallo a questo giocatore perche ha gia preso rosso ");
                    return;
                }
                if(Contagialli2[verG]==1) //estenzione doppio giallo 
                {
                    sq2[verG]=0;
                    Console.WriteLine($"giocatore numero {verG} della squad 2 ha preso il secondo giallo ed è stato espulso");
                    return;
                }
                sq2[verG] = sq2 [verG]-10;
                Console.WriteLine($"giocatore numero {verG} della squad 2 ha preso giallo");
            }

        }
        static void rossi(double[] sq1, double[] sq2)//funzione rosso 
        {
            double rn1 = 0; //variabile  scelta rossi squadra 1
            double rn2 = 0; //variabile  scelta rossi squadra 2
            Random random = new Random();
            double rosso = random.Next(1, 101); // decisione di quale squadra prende il rosso
            if (rosso > 0 && rosso < 50) // rosso squadra 1
            {
                rn1++;
            }
            else // rosso squadra 2
            {
                rn2++;
            }
            int verR = random.Next(0, 11);
            if (rn1 > 0)
            {
                sq1[verR] = 0;
                Console.WriteLine($"giocatore numero  {verR} della squad 1 ha preso rosso");
            }                
            else
            {
                sq2[verR] = 0;
                Console.WriteLine($"giocatore numero {verR} della squad 2 ha preso rosso");


            }


            
        }
        static void sost(double[] sq1, double[] sq2, double[] p1, double[]p2)
        {
            Console.WriteLine("in quale squadra vuoi effetuare un cambio (1) (2) ?");
            int squadra = Convert.ToInt32(Console.ReadLine());
            if(squadra==1)
            {
                Console.WriteLine("inserisci il numero del giocatore da sostituire");
                int num = Convert.ToInt32(Console.ReadLine());
                if(sq1[num]<=0)
                {
                    Console.WriteLine("non puoi sostituire questo giocatore");
                    return;
                }
                Console.WriteLine("inserisci il numero del giocatore che entra");
                int num2 = Convert.ToInt32(Console.ReadLine());
                sq1[num] = p1[num2];
            }
            else
        
            {
                Console.WriteLine("inserisci il numero del giocatore da sostituire");
                int num = Convert.ToInt32(Console.ReadLine());
                if (sq2[num] <= 0)
                {
                    Console.WriteLine("non puoi sostituire questo giocatore");
                    return;
                }
                Console.WriteLine("inserisci il numero del giocatore che entra");
                int num2 = Convert.ToInt32(Console.ReadLine());
                sq2[num] = p2[num2];
            }
        }
        static void infortunio(double[] sq1, double[] sq2,double[] p1, double[] p2)
        {
           Random ran=new Random();
           double asse=ran.Next(1,101);//decisione di quale squadra subisce un infortunio
           if(asse>0 && asse<50)//infortunio squadra 1
           {
                int verIn = ran.Next(0, 11);//selezione giocatore infortunato
                sq1[verIn] = 0;
                Console.WriteLine($"giocatore numero  {verIn} della squad 1 si è infortunato");
                Console.WriteLine("devi sostituirlo");
                sost(sq1, sq2, p1, p2);

           }
           else//infortunio squadra 2
           {
                int verIn = ran.Next(0, 11);//selezione giocatore infortunato
                sq2[verIn] = 0;
                Console.WriteLine($"giocatore numero  {verIn} della squad 2 si è infortunato ");
                 Console.WriteLine("devi sostituirlo");
                sost(sq1, sq2, p1, p2);
           }

        }





        
      
        static void Main(string[] args)
        {
            double[] sq1 = new double[11];//titolari squadra 1
            Random rand = new Random();

            for (int i=0;i<11;i++){
                
                sq1[i]= rand.Next(30,100);
            }

            double[] sq2 = new double[11];// titolari squadra 2
            for (int i=0;i<11;i++){
                sq2[i]= rand.Next(30,100);
            }

            double[] p1 = new double[5];// panchina squadra 1
            Random rando = new Random();

            for (int i=0;i<5;i++){
                
                p1[i]= rand.Next(30,75);
            }

            double[] p2 = new double[5];// panchina squadra 2
            for (int i=0;i<5;i++){
                p2[i]= rand.Next(30,75);
            }

            double[] Contagialli1 = new double[11];//contatori gialli squadra 1
            double[] Contagialli2 = new double[11];//contatori gialli squadra 2
            

            int squadra1goal=0;//contatori goal squadra 1
            int squadra2goal=0;//contatori goal squadra 2

            
            for(int i = 1; i <= 90; i++)//simulazione minuti partita
            {
                int evento = rand.Next(1, 101);
                if(evento <= 2)//evento del goal
                {
                    Console.WriteLine($"Goal al minuto {i}");
                    double p12 = assegnazione(sq1, sq2 );
                    int pgoal = rand.Next(1, 101);
                    if(pgoal <= p12)
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
                if (evento >2 && evento <=6)//evento gialli
                {
                    Console.WriteLine($"Cartellino giallo al minuto {i}");
                     gialli(sq1, sq2,Contagialli1,Contagialli2);
                }
                if (evento==1)//evento rossi
                {
                    rossi(sq1, sq2);

                }
                if (evento == 3)//infortuni
                {
                    Console.WriteLine($"oh no ce stato un infortunio al minuto {i}devi sostituire il giocatore{i}!");
                    infortunio(sq1, sq2,p1,p2);
                }
                if(i>70)//cala la forma fisica
                {
                    Console.WriteLine("le squadre sono stanche avviene un calo fisico");
                    for(int j=0;j<11;j++)

                    {
                        
                        int sott1=rand.Next(5,10);
                        int sott2=rand.Next(5,10);
                        sq1[j]=sq1[j]-sott1;
                        sq2[j]=sq2[j]-sott2;
                        
                    }
                    


                }
                if (evento > 10 && evento <= 30)//evento per il rigore e punizione
                {
                 int rigPun = rand.Next(1, 101);//rigPun= rigore o punizione
                 if (rigPun <= 50)
                 {
                  int rigGoal = rand.Next(1, 101);//rigGoal= rigore gol o no
                  Console.WriteLine($"rigore al minuto {i}");
                 if (rigGoal <= 25)
                {
                 squadra1goal++;
                 Console.WriteLine("ha segnato la squadra 1");
                }
                else if (rigGoal > 25 && rigGoal <= 50)
                {
                 squadra2goal++;
                 Console.WriteLine("ha segnato la squadra 2");
                }
                else if (rigGoal > 50 && rigGoal <= 75)
                {
                 Console.WriteLine("rigore sbagliato per la squadra 1");
                }
                else
                {
                Console.WriteLine("rigore sbagliato per la squadra 2");
                 }




                }
                 else//punizione
                 {
                 int punGoal = rand.Next(1, 101);//punGoal= punizione gol o no
                 Console.WriteLine($"punizione al minuto {i}");
                 if (punGoal <= 15)
                 {
                 squadra1goal++;
                 Console.WriteLine("ha segnato la squadra 1");
                 }
                 else if (punGoal > 15 && punGoal <= 30)
                 {
                  squadra2goal++;
                  Console.WriteLine("ha segnato la squadra 2");
                 }
                 else if (punGoal > 30 && punGoal <= 65)
                 {
                 Console.WriteLine("punizione sbagliata per la squadra 1");
                 }
                 else
                 {
                 Console.WriteLine("punizione sbagliata per la squadra 2");
                 }
                }
                if(evento==60)//nessun evento
                {
                    Console.WriteLine($"nessun evento al minuto {i}");
                }
                }
                if(i==45)//fine primo tempo cronaca
                {
                    Console.WriteLine("fine primo tempo");
                    Console.WriteLine($"il risultato è {squadra1goal} a {squadra2goal}");
                }
                

            }
            
                
            Console.WriteLine("fine partita");//cronaca fine partita 
            Console.WriteLine($"il risultato finale è {squadra1goal} a {squadra2goal}");
                  if(squadra1goal>squadra2goal)
                  {
                        Console.WriteLine("ha vinto la squadra 1");
                    }
                    else if(squadra2goal>squadra1goal)
                    {
                        Console.WriteLine("ha vinto la squadra 2");
                    }
                    else
                    {
                        Console.WriteLine("la partita è finita in pareggio");
                    }
            
        }
    }
}
