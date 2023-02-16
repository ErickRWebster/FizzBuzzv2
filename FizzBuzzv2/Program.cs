using FizzBuzzer;

namespace FizzBuzz
{
    internal class Program
    { 
        static void Main(string[] args)
        {
            var buzzer = new Fizziest();
            var finished = false;

            var pairs = new Dictionary<int, string>();
            pairs.Add(3, "fizz");
            pairs.Add(5, "buzz");

            var newreq = new FizzBuzzer.FizzerRequest()
            {
                StartNumber = 1,
                EndNumber = int.MaxValue,
                BatchCountSize = 100,
                DividorOutputPairs = pairs
            };

            while(!finished)
            {
                var batchresponse = buzzer.FizzBuzzer(newreq);
                if(batchresponse.Error)
                {
                    Console.WriteLine(batchresponse.ErrorMessage);
                    finished = true;
                }
                else
                {
                    foreach(var lineitem in batchresponse.Results)
                    {
                        Console.WriteLine(lineitem);
                    }

                    newreq.StartNumber = batchresponse.NextIteration;
                    finished = batchresponse.Finished;
                }

            }
            
        }
    }
}