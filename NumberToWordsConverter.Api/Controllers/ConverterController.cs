using Microsoft.AspNetCore.Mvc;
using NumberToWordsConverter.Api.Models;
using NumberToWordsConverter.Api.Services;

namespace NumberToWordsConverter.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConverterController : ControllerBase
{
    private readonly INumberToWordsConverter numberToWordsConverter;

    public ConverterController(INumberToWordsConverter numberToWordsConverter)
    {
        this.numberToWordsConverter = numberToWordsConverter;
    }

    [HttpPost]
    public ActionResult<Words> Convert([FromBody] ConversionRequest request)
    {
        if (request == null || string.IsNullOrWhiteSpace(request.Amount))
        {
            return BadRequest(new Words { Error = "Amount is required." });
        }

        try
        {
            var result = numberToWordsConverter.ConvertToWords(request.Amount);
            return Ok(new Words { Result = result });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new Words { Error = ex.Message });
        }
    }
}