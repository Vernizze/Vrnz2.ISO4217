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
            private static readonly object _lock = new object();

            #endregion

            #region Constructors

            private Handler() { }

            #endregion

            #region Attributes

            public static Handler Instance
            {
                get
                {
                    lock (_lock)
                    {
                        _instance = _instance ?? new Handler();

                        return _instance;
                    }
                }
            }

            #endregion

            #region Methods

            public Iso4217Definition GetDefinition(string code) 
                => ISO4217Repository.Instance.GetIso4217DefinitionByCode(code);

            public int? GetNumber(string code)
                => ISO4217Repository.Instance.GetIso4217NumberByCode(code);

            #endregion
        }
    }
}
