using Vrnz2.ISO4217.Infrastructure.Data.Repositories.ISO4217;
using Vrnz2.ISO4217.Shared.Models;

namespace Vrnz2.ISO4217.UseCases.GetIso4217InfoByCode
{
    public class GetIso4217InfoByCode
    {
        public class Handler 
        {
            #region Variables

            private static Handler _instance;

            #endregion

            #region Constructors

            private Handler() { }

            #endregion

            #region Attributes

            public static Handler Instance
            {
                get
                {
                    _instance = _instance ?? new Handler();

                    return _instance;
                }
            }

            #endregion

            #region Methods

            public Iso4217Definition GetIso4217DefinitionByCode(string code) 
                => ISO4217Repository.Instance.GetIso4217DefinitionByCode(code);

            public Iso4217Definition GetIso4217DefinitionByNumber(int number)
                => ISO4217Repository.Instance.GetIso4217DefinitionByNumber(number);

            public int? GetIso4217CodeByCode(string code)
                => ISO4217Repository.Instance.GetIso4217NumberByCode(code);

            public string GetIso4217CodeByNumber(int number)
                => ISO4217Repository.Instance.GetIso4217CodeByNumber(number);

            #endregion
        }
    }
}
