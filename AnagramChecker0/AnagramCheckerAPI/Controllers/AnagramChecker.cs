using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AnagramCheckerLogic;
using Microsoft.Extensions.Configuration;

namespace AnagramCheckerAPI.Controllers
{
    [ApiController]
    [Route("api")]
    public class AnagramChecker : ControllerBase
    {
        private readonly ILogger<AnagramChecker> logger;
        private readonly IConfiguration config;

        public AnagramChecker(ILogger<AnagramChecker> logger, IConfiguration config)
        {
            this.logger = logger;
            this.config = config;
        }

        [HttpPost]
        [Route("checkAnagram")]
        public IActionResult AnagramCheck([FromBody] Words words)
        {
            ITwoWordChecker anagramChecker = new TwoAnagramChecker();
            if (anagramChecker.checkTwoWords(words.W1, words.W2))
            {
                return Ok(words.W1 + " and " + words.W2 + " are anagrams");
            }
            return BadRequest(words.W1 + " and " + words.W2 + " are no anagrams");
        }

        [HttpGet]
        [Route("getKnown")]
        public IActionResult AnagramFinder([FromQuery] string word)
        {
            IMatchingWordFinder matchingWordFinder = new MatchingAnagramFinder();
            var matching = matchingWordFinder.FindMatching(word, config["dictionaryFileName"]);
            if (matching.Count() == 0) return NotFound();
            return Ok(matching);
        }
    }
}
