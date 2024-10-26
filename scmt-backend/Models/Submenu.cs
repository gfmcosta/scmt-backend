using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace scmt_backend.Models;

/// <summary>
/// Submenus a serem disponibilizados no portal, derivados de um determinado Menu
/// </summary>
public class Submenu
{
    /// <summary>
    /// Primary Key
    /// </summary>
    [Key]
    public int id { get; set; }
    
    /// <summary>
    /// Nome visivel
    /// </summary>
    [Required(ErrorMessage = "A {0} é de preenchimento obrigatório")]
    [Display(Name = "Descrição")]
    [RegularExpression("^[a-zçãõáéíóúA-ZÇÃÕÁÉÍÓÚ -]+$", ErrorMessage = "Tem de escrever uma {0} válida")]
    [StringLength(50,ErrorMessage ="A {0} só pode ter apenas {1} caracteres")]
    public string descricao { get; set; }

    /// <summary>
    /// Controlo de Visibilidade do Submenu. Por defeito esta propriedade fica a true.
    /// </summary>
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório")]
    [Display(Name = "Visível")]
    public bool visivel { get; set; } = true;
    
    /// <summary>
    /// FK Menu
    /// </summary>
    [ForeignKey(nameof(Menu))]
    public int menuFK { get; set; }
    public Menu Menu { get; set; }
}