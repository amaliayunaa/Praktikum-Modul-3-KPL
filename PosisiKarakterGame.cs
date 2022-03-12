using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace modul3_1302204100
{
    internal class PosisiKarakterGame
    {
        public enum Posisi { Berdiri, Jongkok, Tengkurap, Terbang }
        public enum Trigger { TombolS, TombolX, TombolW }

        public class Transisi
        {
            public Posisi prevState;
            public Posisi nextState;
            public Trigger trigger;

            public Transisi(Posisi prev, Posisi next, Trigger aksi)
            {
                this.prevState = prev;
                this.nextState = next;
                this.trigger = aksi;
            }
        }

        Transisi[] listPerpindahan =
        {
            new Transisi(Posisi.Berdiri, Posisi.Jongkok, Trigger.TombolS),
            new Transisi(Posisi.Berdiri, Posisi.Terbang, Trigger.TombolW),
            new Transisi(Posisi.Terbang, Posisi.Berdiri, Trigger.TombolS),
            new Transisi(Posisi.Terbang, Posisi.Jongkok, Trigger.TombolX),
            new Transisi(Posisi.Jongkok, Posisi.Berdiri, Trigger.TombolW),
            new Transisi(Posisi.Jongkok, Posisi.Tengkurap, Trigger.TombolS),
            new Transisi(Posisi.Tengkurap, Posisi.Jongkok, Trigger.TombolW),
        };

        public Posisi CurrentState = Posisi.Berdiri;

        public Posisi getNextState(Posisi prev, Trigger aksi)
        {
            Posisi StateAkhir = prev;

            for (int i = 0; i < listPerpindahan.Length; i++)
            {
                Posisi StateAwal = listPerpindahan[i].prevState;
                Trigger aksiState = listPerpindahan[i].trigger;

                if (StateAwal == prev && aksiState == aksi)
                {
                    StateAkhir = listPerpindahan[i].nextState;
                }
            }

            return StateAkhir;
        }

        public void activateTrigger(Trigger trigger)
        {
            CurrentState = getNextState(CurrentState, trigger);

            if (trigger == Trigger.TombolS)
            {
                Console.WriteLine("\nTombol arah bawah ditekan");
            }
            else if (trigger == Trigger.TombolW)
            {
                Console.WriteLine("\nTombol arah atas ditekan");
            }
            else if (trigger == Trigger.TombolX)
            {
                Console.WriteLine("\nTombol X ditekan");
            }
        }
    }
}
