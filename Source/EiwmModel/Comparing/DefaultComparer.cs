using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EiwmModel.Comparing
{
    public class CompareResult
    {

    }

    public class DefaultComparer
    {
        public CompareResult Compare(EiwmRoot eiwm1, EiwmRoot eiwm2)
        {
            CompareTemplates(eiwm1.Template, eiwm2.Template);

            return new CompareResult();
        }

        private void CompareTemplates(Template template1, Template template2)
        {
            template1.Id
        }
    }
}
