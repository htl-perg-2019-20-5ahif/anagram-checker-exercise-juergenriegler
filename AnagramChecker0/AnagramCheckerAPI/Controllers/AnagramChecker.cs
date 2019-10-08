using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AnagramCheckerLogic;

namespace AnagramCheckerAPI.Controllers
{
    [ApiController]
    [Route("checkAnagram")]
    public class AnagramChecker : ControllerBase
    {
        private readonly ILogger<AnagramChecker> logger;
        public AnagramChecker(ILogger<AnagramChecker> logger)
        {
            this.logger = logger; 
        }

        [HttpPost]
        public IActionResult AnagramCheck([FromBody] Words words)
        {
            /*
            string w1, w2;
            try
            {
                w1 = words["w1"].ToString();
                w2 = words["w2"].ToString();
            }
            catch(Exception ex)
            {
                logger.LogCritical(ex, "expected parameters not found");
                throw;
            }
            */
            ITwoWordChecker anagramChecker = new TwoAnagramChecker();
            if (anagramChecker.checkTwoWords(words.W1, words.W2))
            {
                return Ok(words.W1 + " and " + words.W2 + " are anagrams");
            }
            return BadRequest(words.W1 + " and " + words.W2 + " are no anagrams");
        }
    }
}
