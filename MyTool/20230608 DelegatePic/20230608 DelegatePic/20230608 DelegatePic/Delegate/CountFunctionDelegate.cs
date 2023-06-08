using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20230608_DelegatePic.Delegate
{
   public class CountFunctionDelegate
    {

        public delegate string Countfunction(params int[] par);
        private readonly Dictionary<string, Countfunction> _countfunctionDic;
        public CountFunctionDelegate()
        {
            _countfunctionDic = new Dictionary<string, Countfunction>
            {
                {"+",new Countfunction(Plus) },
                { "-",new Countfunction(Mines)},
            };
        }

        public string Counting(string FunName, params int[] par)
        {
            return _countfunctionDic[FunName].Invoke(par);
        }

        private string Plus(params int[] par)
        {
            int result = 0;
            for (int i = 0; i < par.Length; i++)
            {
                result += par[i];
            }
            return result.ToString();
        }

        private string Mines(params int[] par)
        {
            int result = 0;
            for (int i = 0; i < par.Length; i++)
            {
                result -= par[i];
            }
            return result.ToString();
        }
    }
}
