using Amazon.Polly.Model;
using Amazon.Polly;
using Amazon.Runtime;
using Microsoft.AspNetCore.Mvc;
using Amazon;
using System.Xml.Linq;
using System.IO;

namespace Herupu.TextToSpeech.Api.Controllers
{
    [ApiController]
    [Route("api/speech")]
    public class SpeechController : ControllerBase
    {
        [HttpGet()]
        public async Task<IActionResult> Get(string palavra)
        {
            try
            {
                if (string.IsNullOrEmpty(palavra) || string.IsNullOrWhiteSpace(palavra))
                    throw new Exception("É obrigatório informar uma palavra.");

                //if (palavra.Split(" ").Length > 1)
                //    throw new Exception("Para ler mais de uma palavra utilize o método post.");

                var config = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();

                string accessKey = config.GetSection("AwsPolly.AccessKey").Value;
                string secreatKey = config.GetSection("AwsPolly.SecreatKey").Value;

                var credentials = new BasicAWSCredentials(accessKey, secreatKey);
                var polly = new AmazonPollyClient(credentials, RegionEndpoint.USWest2);

                var lexicon = polly.ListLexiconsAsync(new ListLexiconsRequest()).Result;

                List<string> lexicons = new List<string>();
                lexicon.Lexicons.ForEach(l => lexicons.Add(l.Name));

                var req = polly.SynthesizeSpeechAsync(new SynthesizeSpeechRequest
                {
                    LanguageCode = "pt-BR",
                    OutputFormat = "mp3",
                    SampleRate = "8000",
                    Text = palavra,
                    TextType = "text",
                    VoiceId = "Camila",
                    Engine = "Standard",
                    LexiconNames = lexicons
                }).Result;

                var meta = req.ResponseMetadata;

                //var helper = new AudioHelper();
                //helper.SalvarMp3(req, String.Concat(Directory.GetCurrentDirectory(), meta, ".mp3"));

                Task.WaitAll();

               string contentType = req.ContentType;
               int requestCharacters = req.RequestCharacters;

               Response.Clear();
               Response.ContentType = contentType;

               return Ok(req.AudioStream);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
