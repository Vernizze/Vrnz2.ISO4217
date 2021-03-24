using Serilog;
using System;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Timers;
using System.Xml.Serialization;
using Vrnz2.Infra.CrossCutting.Extensions;
using Vrnz2.Infra.CrossCutting.Libraries.HttpClient;
using Vrnz2.ISO4217.Infrastructure.Data.Repositories.ISO4217;
using ModelXml = Vrnz2.ISO4217.Shared.Models.Xml;

namespace Vrnz2.ISO4217.UseCases.ReadingIso4217Source
{
    public class UpdateIso4217DataSource
    {
        #region Constants

        public const string Iso4217Url = "https://www.currency-iso.org/dam/downloads/lists/list_one.xml";
        public const double DefaultExecutionInterval = 86400000;

        #endregion

        public class Handler
        {
            public const string ResourceName = "Vrnz2.ISO4217.list_one.xml";

            #region Variables

            private static Handler _instance;

            private ILogger _logger = null;
            private Timer _timer;

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

            public void Handle(ILogger logger, double executionInterval = DefaultExecutionInterval)
            {
                if (_logger.IsNull())
                    _logger = logger;

                Handle(executionInterval);
            }

            public void Handle(double executionInterval = DefaultExecutionInterval)
                => StartTimer(executionInterval);

            private void StartTimer(double executionInterval)
            {
                if (_timer.IsNull())
                {
                    _timer = new Timer(executionInterval);
                    _timer.Elapsed += OnTimedEvent;
                    _timer.AutoReset = true;
                    _timer.Enabled = true;
                }
            }

            private void OnTimedEvent(Object source, ElapsedEventArgs e)
                => UpdateDataSource();

            public void UpdateDataSource(ILogger logger)
            {
                if (_logger.IsNull())
                    _logger = logger;

                UpdateDataSource();
            }

            public void UpdateDataSource()
            {
                try
                {
                    Stream iso421XmlContent;

                    WarningLogging($"Starting ISO4217 data update...");

                    var response = GetXmlServerResponse();

                    iso421XmlContent = GetXmlDataStream(response);

                    XmlSerializer serializer = new XmlSerializer(typeof(ModelXml.ISO4217));

                    WarningLogging($"ISO4217 data content parsed...");

                    ISO4217Repository.Instance.FeedIso4217Data((ModelXml.ISO4217)serializer.Deserialize(iso421XmlContent));

                    iso421XmlContent.Dispose();

                    WarningLogging($"Finalizing ISO4217 data update...");
                }
                catch (Exception ex)
                {
                    ErrorLogging($"Error: {ex.Message}-{ex.StackTrace}");
                }
            }

            private HttpResponseMessage GetXmlServerResponse()
            {
                HttpResponseMessage result;

                try
                {
                    result = HttpRequestFactory.Get(Iso4217Url).GetAwaiter().GetResult();
                }
                catch (Exception ex)
                {
                    ErrorLogging($"Error on to try contact '{Iso4217Url}' server! Error: {ex.Message}-{ex.StackTrace}");

                    result = null;
                }

                return result;
            }

            private Stream GetXmlDataStream(HttpResponseMessage httpResponseMessage)
            {
                Stream response = new MemoryStream();

                if (httpResponseMessage.IsNull())
                {
                    WarningLogging($"'https://www.currency-iso.org' doesn't returned data, using local file...");

                    var assembly = Assembly.GetExecutingAssembly();

                    using (StreamReader reader = new StreamReader(assembly.GetManifestResourceStream(ResourceName)))
                        reader.BaseStream.CopyTo(response);
                }
                else
                {
                    WarningLogging($"'https://www.currency-iso.org' data returned...");

                    response = httpResponseMessage.Content.ReadAsStreamAsync().GetAwaiter().GetResult();
                }

                response.Position = 0;

                return response;
            }

            private void ErrorLogging(string msg)
            {
                if (_logger.IsNotNull())
                    _logger.Error(msg);
            }

            private void WarningLogging(string msg)
            {
                if (_logger.IsNotNull())
                    _logger.Warning(msg);
            }

            #endregion
        }
    }
}
