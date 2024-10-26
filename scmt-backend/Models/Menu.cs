using System.ComponentModel.DataAnnotations;

namespace scmt_backend.Models;

/// <summary>
/// Menus a serem disponibilizados no portal
/// </summary>
public class Menu
{

    public Menu()
    {
        subMenusList = new HashSet<Submenu>();
    }
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
    /// Controlo de Visibilidade do Menu. Por defeito esta propriedade fica a true.
    /// </summary>
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório")]
    [Display(Name = "Visível")]
    public bool visivel { get; set; } = true;
    
    /// <summary>
    /// Lista dos submenus de um determinado menu
    /// </summary>
    public ICollection<Submenu> subMenusList { get; set; }
}