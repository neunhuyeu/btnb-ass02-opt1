using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Bee
{
    public class Bee
    {
        public float fHealth = 100;
        public Boolean isDead = false;
        public String type;

        public float Damage(int iDamage)
        {
            if (isDead == false)
            {
                fHealth -= fHealth * iDamage / 100;
            }
            return fHealth;
        }

        public Boolean CheckDead(float fHealth)
        {
            if (fHealth <= 70)
                return true;
            else
                return false;
        }
    }

    public class Worker : Bee
    {
        public String name = "Worker";
    }

    public class Drone : Bee
    {
        public Boolean CheckDead(float fHealth)
        {
            if (fHealth <= 50)
                return true;
            else
                return false;
        }
    }


    public class Green : Bee
    {
        public Boolean CheckDead(float fHealth)
        {
            if (fHealth <= 20)
                return true;
            else
                return false;
        }
    }

    public class listBee
    {
        Bee[] bee = new Bee[30];
        Bee[] dsBee = new Bee[30];
        Random rnd = new Random();
        public Array CreateBee()
        {
            //tao danh sach cac bee moi loai 10 bee
            for (int i = 0; i < 30; i++)
            {
                if (i < 10)
                {
                    bee[i] = new Worker();
                    bee[i].type = "Worker";
                }
                else if (i < 20)
                {
                    bee[i] = new Drone();
                    bee[i].type = "Drone";
                }
                else
                {
                    bee[i] = new Green();
                    bee[i].type = "Green";
                }
            }
            //random va dua ra danh sach ngau nhien tu danh sach da tao tren

            Boolean[] dscs = new Boolean[30];
            for (int i = 0; i < 30; i++)
            {
            nhan1:
                int csBee = rnd.Next(0, 30);
                if (dscs[csBee] == false)
                {
                    dsBee[i] = bee[csBee];
                    dscs[csBee] = true;
                }
                else
                    goto nhan1;
            }
            return dsBee;
        }
        public void HienThi()
        {
            Console.WriteLine("{0}\t {1}\t {2}\t {3}", "STT", "Type", "Health", "isDead");
            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine("{0}\t{1}\t {2}\t {3}", (i + 1).ToString("00"), dsBee[i].type, dsBee[i].fHealth.ToString("00.00"), dsBee[i].isDead);
            }
            Console.WriteLine("Press key:");
            Console.WriteLine("  Key 1    : Create bee list");
            Console.WriteLine("  Key 2    : Attack bees");
            Console.WriteLine("  Other    : End program");
        }
        public Array AttackBee()
        {
            for (int i = 0; i < 30; i++)
            {
                bee[i].Damage(rnd.Next(0, 80));
                bee[i].isDead = bee[i].CheckDead(bee[i].fHealth);
            }
            return dsBee;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(80, 40);
            listBee lstbee = new listBee();
            lstbee.CreateBee();
            lstbee.HienThi();

            while (1 > 0)
            {
                String str = Console.ReadLine();
                if (str == "1")
                {
                    Console.Clear();
                    lstbee.CreateBee();
                    lstbee.HienThi();
                }
                else
                    if (str == "2")
                    {
                        Console.Clear();
                        lstbee.AttackBee();
                        lstbee.HienThi();
                    }
                    else
                        break;
            }
        }
    }
}
