using System;
using System.Collections.Generic;
using System.Text;
using Vrnz2.ISO4217.Infrastructure.Data.Repositories.ISO4217;
using Vrnz2.ISO4217.Shared.Models;

namespace Vrnz2.ISO4217.UseCases.GetIso4217InfoByNumber
{
    public class GetIso4217InfoByNumber
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

            public Iso4217Definition GetDefinition(int number)
                => ISO4217Repository.Instance.GetIso4217DefinitionByNumber(number);

            public string GetCode(int number)
                => ISO4217Repository.Instance.GetIso4217CodeByNumber(number);

            #endregion
        }
    }
}
