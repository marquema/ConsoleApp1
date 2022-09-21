using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Program
    {
        const int pos_ini = 1;
        private int pos_win = 100;
        private int li_pos_tablero = 1;

        int tiradas;

        public int tira_dados()
        {
            return new Random((int)DateTime.Now.Ticks & 0x0000FFFF).Next(1, 6);
        }

        public int ComprobarTirada()
        {
            var escalera = new Dictionary<int, int>()
            {
                { 2, 38 },
                { 7, 14},
                { 8, 31},
                { 15, 26},
                { 36, 44},
                { 51, 67},
                { 78, 98},
                { 71, 91},
                { 87, 94}
            };

            var snake = new Dictionary<int, int>()
            {
                { 16, 6 },
                { 49, 11},
                { 46, 25},
                { 64, 60},
                { 62, 19},
                { 74, 53},
                { 89, 68},
                { 95, 75},
                { 92, 88},
                { 99, 80}
            };

            if (escalera.ContainsKey(this.li_pos_tablero))
                return escalera[this.li_pos_tablero];
            if (snake.ContainsKey(this.li_pos_tablero))
                return snake[this.li_pos_tablero];
            return this.li_pos_tablero;
        }

        public bool comprobarpartidaganada()
        {
            if (this.li_pos_tablero == this.pos_win)
                return true;
            return false;
        }

        public void Jugar()
        {
            ConsoleKeyInfo cki;
            bool partidaganada = false;
            int li_cant_devuelve_dado;
            do
            {
                Console.Write("\nOPulse tecla para tirar los dados o Escape para terminar ");
                cki = Console.ReadKey();

                li_cant_devuelve_dado = tira_dados();
                Console.Write("\nTirada: " + li_cant_devuelve_dado.ToString());
                Console.Write("\nPosicion en tablero: " + this.li_pos_tablero.ToString());

                li_pos_tablero += li_cant_devuelve_dado;

                this.li_pos_tablero = ComprobarTirada();

                if (this.li_pos_tablero > this.pos_win)
                    this.li_pos_tablero -= li_cant_devuelve_dado;
                
                if (comprobarpartidaganada())
                {
                    Console.Write("\nCAMPEON ");
                    break;
                }

            } while (cki.Key != ConsoleKey.Escape);
            
        }
        static void Main(string[] args)
        {
            var mp = new Program();
            mp.Jugar();   
        }
    }
}
