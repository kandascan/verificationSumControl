using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace SumControlVeryfication
{
    public static class SumControl
    {
        private static int VerificationSumControl(int iteration, List<int> values)
        {
            var sumControll = 1;

            for (int i = 0; i < iteration; i++)
            {
                sumControll = values.Sum() * sumControll;
            }

            return 1;
        }

        public static int Process(string path)
        {
            try
            {
                var xmlFile = XElement.Load(path);

                int iterations = Convert.ToInt16(xmlFile.Element("iterations").Value);
                if (iterations < 1 || iterations > 8)
                {
                    //throw new Exception("Iteration should be between <1, 8>");
                    return -1;
                }

                int confirmation = Convert.ToInt16(xmlFile.Element("confirmationdata").Value);

                if (confirmation <= 0)
                    return 0;

                var values = new List<int>();

                foreach (XElement value in xmlFile.Descendants("value"))
                {
                    if (Convert.ToInt16(value.Value) < -10 || Convert.ToInt16(value.Value) > 10)
                    {
                        //throw new Exception("Value should be a number between <-10, 10>");
                        return -1;
                    }

                    values.Add(Convert.ToInt16(value.Value));
                }

                if (values.Count > 5 || values.Count == 0)
                {
                    //throw new Exception("List of values cannot be grather than 5");
                    return -1;
                }

                return VerificationSumControl(iterations, values);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
            
        }
    }
}
