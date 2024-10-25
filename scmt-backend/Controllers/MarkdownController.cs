namespace scmt_backend.Controllers;

using Microsoft.AspNetCore.Mvc;
using System.IO;

[ApiController]
[Route("api/[controller]")]
public class MarkdownController : ControllerBase
{
    private readonly string _filePath;

    public MarkdownController(IWebHostEnvironment env)
    {
        _filePath = Path.Combine(env.ContentRootPath, "wwwroot", "docs", "main.md"); // Altere para o nome do seu arquivo
    }

    [HttpGet("get")]
    public IActionResult GetMarkdown()
    {
        if (!System.IO.File.Exists(_filePath))
            return NotFound();

        var content = System.IO.File.ReadAllText(_filePath);
        return Content(content); // Retorna o conteúdo como texto
    }
}

public class MarkdownContent
{
    public string Content { get; set; }
}
