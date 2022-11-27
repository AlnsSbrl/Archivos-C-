using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenHogwarts
{
    delegate void MyDelegate();
    internal class Drones
    {
        static readonly private object l = new object();
        static private bool isPaused = false;
        static private bool isDoorOcupied = false;
        static int droneNumberToKill = -1;
        //aunque lo hice de otra manera
        //la pista del enunciado es un vector con dos bool
        //tambien se podria hacer con bool[] y que el check de continuar el hilo fuese
        //en vez de droneNumberToKill!=droneNumber
        //bool[droneNumber] cambiando esta al pulsar 1 o 2
        //esto supongo que solucionaria la triquiñuela del combo: pausa->1->2->continuar
        //que solo borra un hilo
        Thread drone1;
        Thread drone2;
        public void RandomInfo()
        {
            lock (l)
            {
                bool enough = false;
                Process[] processes = Process.GetProcesses();
                Random r = new Random();
                Process p = processes[r.Next(0, processes.Length)];
                Console.SetCursorPosition(1, 10);
                Console.Write(new string(' ', 1500)); //modifiqué esto para que limpiase mejor la pantalla
                Console.SetCursorPosition(1, 10);
                ProcessModuleCollection modules = p.Modules;
                string textFile = ("Name: " + p.ProcessName + Environment.NewLine);// + "Modules: "+p.Modules)
                int i = 1;
                foreach (ProcessModule module in modules)
                {
                    if (module.FileName.Contains(".dll") && !enough)
                    {
                        textFile += (i + ": Name:" + module.FileName + Environment.NewLine);
                        i++;
                        if (i > 10)
                        {
                            enough = true;
                        }
                    }
                }

                using (StreamWriter sw = new StreamWriter(Environment.GetEnvironmentVariable("userprofile") + "/randomInfo.txt", true))
                {
                    sw.Write(textFile);
                }
                Console.Write(textFile);
            }
        }
        public void ExceptionControl(MyDelegate funcion)
        {
            try
            {
                funcion.Invoke();
            }
            catch (Exception e)
            {
                Console.Write("Panic error!!");
                Console.Write(e.Message);
            }
        }

        public void ControlaDron(int droneNumber)
        {
            bool isDestinationReached = false;
            Console.SetCursorPosition(0, droneNumber);
            Random r = new Random();
            int valorSleep = r.Next(100, 200);
            int pos = 0;
            while (!isPaused && !isDestinationReached && droneNumberToKill != droneNumber)
            {
                Thread.Sleep(valorSleep);
                lock (l)
                {
                    pos++;
                    Console.SetCursorPosition(pos, droneNumber);
                    Console.Write("".PadLeft(pos, '-')+ (pos > 20 ? "*" : droneNumber));
                    if (pos == 20)
                    {
                        while (isDoorOcupied || isPaused)
                        {
                            Monitor.Wait(l);
                        }
                        if (!isDoorOcupied)
                        {
                            isDoorOcupied = true;
                        }
                    }
                    if (pos == 30 || droneNumberToKill==droneNumber)
                    {
                        Monitor.Pulse(l);
                        isDoorOcupied = false;
                        isDestinationReached = true;
                    }
                    if (isPaused)
                    {
                        Monitor.Wait(l);
                    }
                }
            }
        }

        public void Control()
        {
            bool keepControlling = true;
            while (keepControlling)
            {
                if (Console.KeyAvailable) //if there’s a key in keyboard’s buffer
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.KeyChar)
                    {
                        case 'p': //pause drones
                            lock (l)
                            {
                                isPaused = true;
                            }
                            break;
                        case 'c': //continue drones
                            lock (l)
                            {
                                isPaused = false;
                                Monitor.PulseAll(l);
                            }
                            break;
                        case '1': //finalize drone 1
                            droneNumberToKill = 1;
                            break;
                        case '2': //finalize drone 2
                            droneNumberToKill = 2;
                            //el dron.Abort() está en desuso, ademas lanza exceptions por tos laos
                            break;
                        case 'o': //control off
                            keepControlling = false;
                            break;
                        case 'i': //system information
                                  //ExceptionControl();
                            lock (l)
                            {
                                MyDelegate myDelegate = new MyDelegate(RandomInfo);
                                ExceptionControl(myDelegate);
                            }
                            break;
                    }
                }
            }
        }
        public Drones()
        {
            drone1 = new Thread(() => ControlaDron(1));
            drone2 = new Thread(() => ControlaDron(2));
            Thread control = new Thread(Control);
            control.IsBackground = true;
            drone1.Start();
            drone2.Start();
            control.Start();
            drone1.Join();
            drone2.Join();                   
        }
    }
}
