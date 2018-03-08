using System.Collections.Generic;
using System;

namespace cgiEnnakko
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Press x to exit");
            while (true)
            {
                Console.Write("Write id: ");
                string id = System.Console.ReadLine();

                if (id.Equals("x"))
                {
                    break;
                }

                BusinessIdSpecification test = new BusinessIdSpecification();
                test.IsSatisfiedBy(id);

                foreach (string error in test.ReasonsForDissatisfaction)
                {
                    Console.WriteLine(error);
                }
            }
        }
    }

}
