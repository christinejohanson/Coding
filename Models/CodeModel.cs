using System.ComponentModel.DataAnnotations;
namespace Coding.Models

{
    public class CodeModel
    {

        //required för att fält är obligatoriska. lägg även till using system component
        //display för att skriva ut bättre namn 
        [Required(ErrorMessage = "Fyll i ett språk n00b")]
        [Display(Name = "Språk/programnamn:")]

        [MinLength(2, ErrorMessage = "det får inte vara kortare än 2 tecken!")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Fyll i en beskrivning")]
        [Display(Name = "Beskrivning:")]
        [MinLength(3, ErrorMessage = "skriv gärna tydlig beskrivning, minst 3 tecken!")]
        public string? Descrip { get; set; }

        public string? Where { get; set; }


        [Display(Name = "Har fått godkänt på kursen:")]
        public bool Accepted { get; set; }
    }
}