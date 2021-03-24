using System;
using System.Collections.Generic;
using Vrnz2.Infra.CrossCutting.Extensions;
using Vrnz2.ISO4217.Shared.Models;
using ModelXml = Vrnz2.ISO4217.Shared.Models.Xml;

namespace Vrnz2.ISO4217.Infrastructure.Data.Repositories.ISO4217
{
    public class ISO4217Repository
    {
        #region Variables

        private static ISO4217Repository _instance;
        public static object _lock = new object();

        private Dictionary<string, Iso4217Definition> _definitionsByCode =
            new Dictionary<string, Iso4217Definition>();

        private Dictionary<int, Iso4217Definition> _definitionsByNumber =
            new Dictionary<int, Iso4217Definition>();

        #endregion

        #region Constructors

        private ISO4217Repository() { }

        #endregion

        #region Attributes

        public static ISO4217Repository Instance
        {
            get
            {
                lock (_lock)
                {
                    _instance = _instance ?? new ISO4217Repository();

                    return _instance;
                }
            }
        }

        public DateTime? DateTimeLastVerson { get; private set; }

        internal void FeedIso4217Data(ModelXml.ISO4217 iso4217)
        {
            if (iso4217.IsNotNull() && (DateTimeLastVerson.IsNull() || DateTimeLastVerson < iso4217.Pblshd)) 
            {
                InitDictionaries(iso4217);

                DateTimeLastVerson = iso4217.Pblshd;
            }
        }

        #endregion

        #region Methods

        private void InitDictionaries(ModelXml.ISO4217 iso4217)
            => iso4217?.CcyTbl?.CcyNtry?.ForEach(i =>
                {
                    var validNumber = int.TryParse(i.CcyNbr, out int number);
                    var validExponent = int.TryParse(i.CcyNbr, out int exponent);
                    var alreadyExists =  _definitionsByNumber.TryGetValue(number, out _) && _definitionsByCode.TryGetValue(i.Ccy, out _);

                    if (validNumber && validExponent && !alreadyExists)
                    {
                        _definitionsByNumber.Add(number, new Iso4217Definition(i.Ccy, number, exponent));
                        _definitionsByCode.Add(i.Ccy, new Iso4217Definition(i.Ccy, number, exponent));
                    }
                });

        public Iso4217Definition GetIso4217DefinitionByNumber(int number)
        {
            _definitionsByNumber.TryGetValue(number, out Iso4217Definition result);

            return result;
        }

        public Iso4217Definition GetIso4217DefinitionByCode(string code)
        {
            _definitionsByCode.TryGetValue(code, out Iso4217Definition result);

            return result;
        }

        public string GetIso4217CodeByNumber(int number)
        {
            _definitionsByNumber.TryGetValue(number, out Iso4217Definition result);

            return result?.Code;
        }

        public int? GetIso4217NumberByCode(string code)
        {
            _definitionsByCode.TryGetValue(code, out Iso4217Definition result);

            return result?.Number;
        }

        #endregion
    }
}
