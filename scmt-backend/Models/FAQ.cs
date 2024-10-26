using System.ComponentModel.DataAnnotations;

namespace scmt_backend.Models;

/// <summary>
/// Representação de perguntas frequentes com as respetivas respostas
/// </summary>
public class FAQ
{
    /// <summary>
    /// Primary Key
    /// </summary>
    [Key]
    public int id { get; set; }
    
    /// <summary>
    /// Texto com uma pergunta frequente
    /// </summary>
    [Required(ErrorMessage = "A {0} é de preenchimento obrigatório")]
    [Display(Name = "Pergunta")]
    [RegularExpression("^[a-zçãõáéíóúA-ZÇÃÕÁÉÍÓÚ -]+$", ErrorMessage = "Tem de escrever uma {0} válida")]
    [StringLength(50,ErrorMessage ="A {0} só pode ter apenas {1} caracteres")]
    public string pergunta { get; set; }
    
    /// <summary>
    /// Texto com a resposta a uma pergunta frequente
    /// </summary>
    [Required(ErrorMessage = "A {0} é de preenchimento obrigatório")]
    [Display(Name = "Resposta")]
    [RegularExpression("^[a-zçãõáéíóúA-ZÇÃÕÁÉÍÓÚ -]+$", ErrorMessage = "Tem de escrever uma {0} válida")]
    [StringLength(50,ErrorMessage ="A {0} só pode ter apenas {1} caracteres")]
    public string resposta { get; set; }
    
    /// <summary>
    /// Controlo de Visibilidade do par pergunta/resposta
    /// </summary>
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório")]
    [Display(Name = "Visível")]
    public bool visivel { get; set; }
}