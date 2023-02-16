using System.Diagnostics.Metrics;

namespace FizzBuzzer
{
    public class Fizziest
    {
        public FizzerResponse FizzBuzzer(FizzerRequest req)
        {
            var list = new List<string>();
            var count = 0;
            var startnumber = req.StartNumber;
            var endnumber = req.EndNumber;

            try
            {
                while (startnumber < req.EndNumber && count < req.BatchCountSize)
                {
                    var output = "number " + startnumber + " :";

                    foreach (var pair in req.DividorOutputPairs)
                    {
                        if ((startnumber % pair.Key == 0))
                        {
                            output += pair.Value;
                        }
                    }

                    startnumber++;
                    count++;

                    list.Add(output);
                }
            }
            catch(Exception ex)
            {
                return new FizzerResponse()
                {
                    Error = true,
                    ErrorMessage = ex.Message
                };
            }

            var res = new FizzerResponse();
            res.Results = list;
            res.NextIteration = startnumber++;
            res.Finished = startnumber == endnumber;

            return res;
        }
    }

    public class FizzerRequest
    {
        public int StartNumber { get; set; } = 1;
        public int EndNumber { get; set; } = 2;
        public int BatchCountSize { get; set; } = 50;
        public Dictionary<int, string> DividorOutputPairs { get; set; } = new Dictionary<int, string>();
    }

    public class FizzerResponse
    {
        public bool Finished { get; set; } = false;
        public bool Error { get; set; } = false;
        public string ErrorMessage { get; set; } = "";
        public List<string> Results { get; set; } = new List<string>();
        public int NextIteration { get; set; }

    }
}