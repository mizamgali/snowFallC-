using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Snow
{
    class Snow
    {
        public Random RSnow = new Random();

        public const int WIDTH = 100;
        public const int HEIGHT = 20;
        public const string NOTHING = " ";
        public const string SNOW = "*";
        public const string SNOW_UNDER = "■";

        int snowSpd = 1000; //Скорость подения(милисекунды)

        
        public string[,] screen = new string[HEIGHT, WIDTH];

        public Random r = new Random();

        public void snowFall(int duration)
        {
            fillScreen();
            updateScreen();

            for (int i = 0; i < duration; i++)
            {
                makeSnow(12); 
                updateScreen();
                fall();
                wait(1);
            }
        }

        private void fillScreen()
        {
            for(int i = 0; i < HEIGHT; i++)
            {
                for(int j = 0; j < WIDTH; j++)
                {
                    screen[i, j] = NOTHING;
                }
            }
        }

        private void updateScreen()
        {
            Console.Clear();
            for (int i = 0; i < HEIGHT; i++)
            {
                for (int j = 0; j < WIDTH; j++)
                {
                    Console.Write(screen[i, j]);
                }
                Console.WriteLine();
            }

        }
        private void makeSnow(int count)
        {
            int countDiv = count / 4;
            int widthDiv = WIDTH / 4;
            int hLocation = 0;

            for (int i = 0; i < count; i++)
            {
                if (i < countDiv) hLocation = r.Next(0, widthDiv);
                else if (i >= countDiv && i < countDiv * 2) hLocation = r.Next(widthDiv, widthDiv * 2);
                else if (i >= countDiv * 2 && i < countDiv * 3) hLocation = r.Next(widthDiv * 2, widthDiv * 3);
                else if (i >= countDiv * 3 && i < countDiv * 4) hLocation = r.Next(widthDiv * 3, widthDiv * 4);

                if (hLocation != 0 && hLocation != WIDTH - 1)
                {
                    if ((screen[0, hLocation + 1] != SNOW) && (screen[0, hLocation - 1] != SNOW) && (screen[0, hLocation] != SNOW))
                    {
                        screen[0, hLocation] = SNOW;
                    }
                    else
                    {
                        i--;
                    }
                }
            }
        }

        private void wait (int seconds)
        {
            seconds *= snowSpd;
            Thread.Sleep(seconds);
        }
        private void fall()
        {
            for (int i = HEIGHT - 2; i >= 0; i--)
            {
                for (int j = WIDTH - 1; j >= 0; j--)
                {
                    if (screen[i, j] == SNOW && screen[i + 1, j] == SNOW_UNDER) screen[i, j] = SNOW_UNDER;

                    if (screen[i + 1, j] != SNOW_UNDER)
                    {
                        screen[i + 1, j] = screen[i, j];
                        screen[i, j] = " ";
                    }
                }
            }
        }
    }
}
