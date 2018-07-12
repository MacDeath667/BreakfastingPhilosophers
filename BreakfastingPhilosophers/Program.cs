using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BreakfastingPhilosophers
{
    class Program
    {
        static void Main(string[] args)
        {
            // за столом сидели
            Philosopher nietzsche = new Philosopher("Ницше");
            Philosopher plato = new Philosopher("Платон");
            Philosopher freud = new Philosopher("Фрейд");
            Philosopher laoTzu = new Philosopher("Лао Цзы");
            Philosopher aristotle = new Philosopher("Аристотель");


            //вилками ели
            Fork forkNietzschePlato = new Fork(1);
            Fork forkPlatoFreud = new Fork(2);
            Fork forkFreudLaoTzu = new Fork(3);
            Fork forkLaoTzuAristotle = new Fork(4);
            Fork forkAristotleNietzsche = new Fork(5);

            //обслуживал их официант
            Officiant officiant = new Officiant();


            //каждая рука - свой поток
            Thread t1 = new Thread(_ =>
            nietzsche.GetFork(officiant.GivePermissionToGetFork(ref forkAristotleNietzsche, ref forkNietzschePlato),
               ref forkAristotleNietzsche, ref forkNietzschePlato));

            Thread t2 = new Thread(_ =>
            plato.GetFork(officiant.GivePermissionToGetFork(ref forkNietzschePlato, ref forkPlatoFreud),
                ref forkNietzschePlato, ref forkPlatoFreud));

            Thread t3 = new Thread(_ =>
            freud.GetFork(officiant.GivePermissionToGetFork(ref forkPlatoFreud, ref forkFreudLaoTzu),
               ref forkPlatoFreud, ref forkFreudLaoTzu));

            Thread t4 = new Thread(_ =>
            laoTzu.GetFork(officiant.GivePermissionToGetFork(ref forkFreudLaoTzu, ref forkLaoTzuAristotle),
                ref forkFreudLaoTzu, ref forkLaoTzuAristotle));

            Thread t5 = new Thread(_ =>
            laoTzu.GetFork(officiant.GivePermissionToGetFork(ref forkLaoTzuAristotle, ref forkAristotleNietzsche),
                ref forkLaoTzuAristotle, ref forkAristotleNietzsche));
            
            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();

            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();
            t5.Join();
        }
    }
}
