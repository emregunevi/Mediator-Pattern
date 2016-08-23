using System;

namespace AraciKalibi
{
    class MainApp
    {
        static void Main()
        {
            SomutAraci sAraci = new SomutAraci();
            SomutKatilimci1 sKatilimci1 =
                        new SomutKatilimci1(sAraci);
            SomutKatilimci2 sKatilimci2 =
                        new SomutKatilimci2(sAraci);
            sAraci.Katilimci1 = sKatilimci1;
            sAraci.Katilimci2 = sKatilimci2;
            sKatilimci1.Gonder("Test Verisi 1");
            sKatilimci2.Gonder("Test Verisi 2");
            Console.ReadKey();
        }
    }

    abstract class Araci
    {
        public abstract void Gonder(string mesaj, Katilimci
                                    katilimci);
    }

    class SomutAraci : Araci
    {
        private SomutKatilimci1 katilimci1;
        private SomutKatilimci2 katilimci2;
        public SomutKatilimci1 Katilimci1
        {
            set { katilimci1 = value; }
        }
        public SomutKatilimci2 Katilimci2
        {
            set { katilimci2 = value; }
        }
        public override void Gonder(string mesaj, Katilimci
                                    katilimci)
        {
            if (katilimci == katilimci1)
            {
                katilimci2.Al(mesaj);
            }
            else
            {
                katilimci1.Al(mesaj);
            }
        }
    }

    abstract class Katilimci
    {
        public Araci araci;

        public Katilimci(Araci araci)
        {
            this.araci = araci;
        }
    }

    class SomutKatilimci1 : Katilimci
    {
        public SomutKatilimci1(Araci araci)
            : base(araci)
        {
            
        }
        public void Gonder(string mesaj)
        {
            araci.Gonder(mesaj, this);
        }
        public void Al(string mesaj)
        {
            Console.WriteLine("Katilimci 1 tarafindan alinan mesaj: " + mesaj);
        }
    }

    class SomutKatilimci2 : Katilimci
    {

        public SomutKatilimci2(Araci araci)
            : base(araci)
        {

        }
       
        public void Gonder(string mesaj)
        {
            araci.Gonder(mesaj, this);
        }
        public void Al(string mesaj)
        {
            Console.WriteLine("Katilimci 2 tarafindan alinan mesaj: " + mesaj);
        }
    }
}
